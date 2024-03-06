using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager {
    public partial class MainForm : Form
    {
        public ModManager ModManager;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var uri = new Uri("file:///ModCatalog.xml");
            var uri = new Uri("https://github.com/haramako/speedrun/raw/feature/mod-manager/DragonFangZ/Mod/ModManager/ModManager/ModCatalog.xml");
            ModManager = new ModManager(uri);
            ModManager.OnLog += Log;
            loadCatalog().ConfigureAwait(true);
        }

        private async Task loadCatalog()
        {
            Log("カタログ取得中...");
            var catalog = await ModManager.LoadCatalog();
            Log($"カタログ取得完了。 {catalog.Entries.Length}個のMODがあります。");
            Redraw();
        }

        private void Redraw()
        {
            modList.Items.Clear();
            foreach (var e in ModManager.Catalog.Entries)
            {
                var installedText = e.Installed ? "●" : "　";
                var text = $"{installedText} {e.Name} (v{e.Version})";
                modList.Items.Add(text, e.Checked);
            }
        }

        private void installButton_Click(object sender, EventArgs e)
        {
            installAll().ConfigureAwait(true);
        }

        private async Task installAll()
        {
            await ModManager.InstallAll();
            Redraw();
            Log("インストール完了");
        }

        public void Log(string message)
        {
            logText.Text += message + "\r\n";
            logText.Select(logText.Text.Length, 0);
            logText.ScrollToCaret();
        }

        private void modList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var idx = e.Index;
            ModManager.Catalog.Entries[idx].Checked = e.NewValue == CheckState.Checked;
        }

        private void checkallButton_Click(object sender, EventArgs ev)
        {
            foreach (var e in ModManager.Catalog.Entries)
            {
                e.Checked = true;
            }
            Redraw();
        }

        private void button1_Click(object sender, EventArgs ev)
        {
            foreach (var e in ModManager.Catalog.Entries)
            {
                e.Checked = false;
            }
            Redraw();
        }
    }
}
