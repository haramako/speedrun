namespace ModManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.installButton = new System.Windows.Forms.Button();
            this.logText = new System.Windows.Forms.TextBox();
            this.modList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkallButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // installButton
            // 
            this.installButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.installButton.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.installButton.Location = new System.Drawing.Point(684, 158);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(177, 42);
            this.installButton.TabIndex = 0;
            this.installButton.Text = "インストール";
            this.installButton.UseVisualStyleBackColor = false;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // logText
            // 
            this.logText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logText.Location = new System.Drawing.Point(12, 238);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.Size = new System.Drawing.Size(849, 178);
            this.logText.TabIndex = 4;
            // 
            // modList
            // 
            this.modList.CheckOnClick = true;
            this.modList.FormattingEnabled = true;
            this.modList.Location = new System.Drawing.Point(12, 12);
            this.modList.Name = "modList";
            this.modList.Size = new System.Drawing.Size(849, 140);
            this.modList.TabIndex = 5;
            this.modList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.modList_ItemCheck);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "ログ";
            // 
            // checkallButton
            // 
            this.checkallButton.Location = new System.Drawing.Point(169, 158);
            this.checkallButton.Name = "checkallButton";
            this.checkallButton.Size = new System.Drawing.Size(139, 42);
            this.checkallButton.TabIndex = 7;
            this.checkallButton.Text = "全部チェック";
            this.checkallButton.UseVisualStyleBackColor = true;
            this.checkallButton.Click += new System.EventHandler(this.checkallButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "全部チェックはずす";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkallButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modList);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.installButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.Text = "Dragon Fang Z MOD Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.CheckedListBox modList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checkallButton;
        private System.Windows.Forms.Button button1;
    }
}