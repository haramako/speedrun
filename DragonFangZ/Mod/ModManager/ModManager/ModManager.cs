using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Xml.Serialization;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Xml;
using System.Net.Configuration;
using System.Text;

namespace ModManager
{
    public class CatalogEntry
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }

        // Runtime data
        public bool Installed { get; set; }
        public bool Checked { get; set; }
    }

    public class Catalog
    {
        public int Version { get; set; }
        public CatalogEntry[] Entries { get; set; }
    }

    public class ModManager
    {
        HttpClient client;
        Uri catalogUri;

        public Catalog Catalog { get; private set; }

        public string SteamInstallPath { get; private set; }

        public delegate void OnLogEvent(string message);
        public event OnLogEvent OnLog;

        public ModManager(Uri _catalogUri)
        {
            catalogUri = _catalogUri;
            client = new HttpClient();
            SteamInstallPath = GetSteamInstallPath();
        }

        /// <summary>
        /// Catalogをロードする.
        /// </summary>
        public async Task<Catalog> LoadCatalog()
        {
            var text = await GetText(catalogUri);
            var settings = new XmlReaderSettings { IgnoreWhitespace = false };
            var xmlReader = XmlReader.Create(new MemoryStream(UTF8Encoding.UTF8.GetBytes(text)), settings);
            var serializer = new XmlSerializer(typeof(Catalog));
            Catalog = serializer.Deserialize(xmlReader) as Catalog;
            foreach (var e in Catalog.Entries)
            {
                // インストール済みかの情報を更新
                if(File.Exists(GetMODPath(e)))
                {
                    e.Installed = true;
                e.Checked = true;
                }
            }
            return Catalog;
        }

        public Task<string> GetText(string uri) => GetText(new Uri(uri));

        public async Task<string> GetText(Uri uri)
        {
            using (var s = await GetStream(uri))
            {
                return new StreamReader(s).ReadToEnd();
            }
        }

        public Task<Stream> GetStream(string uri) => GetStream(new Uri(uri));
        public async Task<Stream> GetStream(Uri uri)
        {
            if (uri.Scheme == "file")
            {
                var path = uri.ToString().Substring("file:///".Length);
                return File.OpenRead(path);
            }
            else
            {
                var res = await client.GetAsync(uri);
                return await res.Content.ReadAsStreamAsync();
            }
        }

        public async Task InstallAll()
        {
            foreach (var e in Catalog.Entries)
            {
                if (e.Checked != e.Installed)
                {
                    if (e.Checked)
                    {
                        await Install(e);
                    }
                    else
                    {
                        Uninstall(e);
                    }
                }
            }
        }

        public string GetMODPath(CatalogEntry entry)
        {
            var filename = Path.GetFileName(entry.Uri);
            var localPath = Path.Combine(ModInstallPath, filename);
            return localPath;
        }

        public async Task Install(CatalogEntry entry)
        {
            //log($"ダウンロード中... {entry.Name}, URL={entry.Uri}");
            using (var downloadStream = await GetStream(entry.Uri))
            {
                using (var ws = File.OpenWrite(GetMODPath(entry)))
                {
                    await downloadStream.CopyToAsync(ws);
                }
            }
            log($"インストール成功 {entry.Name}");
            entry.Installed = true;
        }

        public void Uninstall(CatalogEntry entry)
        {
            File.Delete(GetMODPath(entry));
            log($"アンインストール成功 {entry.Name}");
            entry.Installed = false;
        }

        public string ModInstallPath => Path.Combine(SteamInstallPath, "steamapps", "common", "DragonFangZ", "Mods");

        public string GetSteamInstallPath()
        {
            var baseKey = "HKEY_LOCAL_MACHINE\\SOFTWARE\\Wow6432Node\\Valve\\Steam";
            var installPath = Registry.GetValue(baseKey, "InstallPath", null) as string;
            return installPath;
        }

        private void log(string message)
        {
            OnLog?.Invoke(message);
        }

    }
}
