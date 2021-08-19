
namespace TPLogAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStsPath = new System.Windows.Forms.TextBox();
            this.tbDevPath = new System.Windows.Forms.TextBox();
            this.btStsChoosePath = new System.Windows.Forms.Button();
            this.btDevChoosePath = new System.Windows.Forms.Button();
            this.btStsStartTransfer = new System.Windows.Forms.Button();
            this.ofdStsLog = new System.Windows.Forms.OpenFileDialog();
            this.ofdDevLog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyConfigFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btDevStartTransfer = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sts Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dev Path";
            // 
            // tbStsPath
            // 
            this.tbStsPath.Location = new System.Drawing.Point(86, 51);
            this.tbStsPath.Name = "tbStsPath";
            this.tbStsPath.Size = new System.Drawing.Size(255, 20);
            this.tbStsPath.TabIndex = 2;
            // 
            // tbDevPath
            // 
            this.tbDevPath.Location = new System.Drawing.Point(86, 79);
            this.tbDevPath.Name = "tbDevPath";
            this.tbDevPath.Size = new System.Drawing.Size(255, 20);
            this.tbDevPath.TabIndex = 3;
            // 
            // btStsChoosePath
            // 
            this.btStsChoosePath.Location = new System.Drawing.Point(347, 51);
            this.btStsChoosePath.Name = "btStsChoosePath";
            this.btStsChoosePath.Size = new System.Drawing.Size(21, 20);
            this.btStsChoosePath.TabIndex = 4;
            this.btStsChoosePath.Text = "···";
            this.btStsChoosePath.UseVisualStyleBackColor = true;
            this.btStsChoosePath.Click += new System.EventHandler(this.btStsChoosePath_Click);
            // 
            // btDevChoosePath
            // 
            this.btDevChoosePath.Location = new System.Drawing.Point(347, 77);
            this.btDevChoosePath.Name = "btDevChoosePath";
            this.btDevChoosePath.Size = new System.Drawing.Size(21, 23);
            this.btDevChoosePath.TabIndex = 5;
            this.btDevChoosePath.Text = "···";
            this.btDevChoosePath.UseVisualStyleBackColor = true;
            this.btDevChoosePath.Click += new System.EventHandler(this.btDevChoosePath_Click);
            // 
            // btStsStartTransfer
            // 
            this.btStsStartTransfer.Location = new System.Drawing.Point(374, 50);
            this.btStsStartTransfer.Name = "btStsStartTransfer";
            this.btStsStartTransfer.Size = new System.Drawing.Size(75, 23);
            this.btStsStartTransfer.TabIndex = 6;
            this.btStsStartTransfer.Text = "Sts Start";
            this.btStsStartTransfer.UseVisualStyleBackColor = true;
            this.btStsStartTransfer.Click += new System.EventHandler(this.btStartTransfer_Click);
            // 
            // ofdStsLog
            // 
            this.ofdStsLog.FileName = "StsLogOFD";
            this.ofdStsLog.Filter = "text|Sts*.txt|all files|*.*";
            this.ofdStsLog.InitialDirectory = "G:\\Code\\C#\\WinForm\\LogExample";
            this.ofdStsLog.Multiselect = true;
            // 
            // ofdDevLog
            // 
            this.ofdDevLog.FileName = "DevLogOFD";
            this.ofdDevLog.Filter = "text|Dev*.txt|all files|*.*";
            this.ofdDevLog.InitialDirectory = "G:\\Code\\C#\\WinForm\\LogExample";
            this.ofdDevLog.Multiselect = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(478, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "msConfig";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifyConfigFileToolStripMenuItem});
            this.configToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.configToolStripMenuItem.Text = "&Config";
            // 
            // modifyConfigFileToolStripMenuItem
            // 
            this.modifyConfigFileToolStripMenuItem.Name = "modifyConfigFileToolStripMenuItem";
            this.modifyConfigFileToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modifyConfigFileToolStripMenuItem.Text = "&Modify Config File";
            this.modifyConfigFileToolStripMenuItem.Click += new System.EventHandler(this.modifyConfigFileToolStripMenuItem_Click);
            // 
            // btDevStartTransfer
            // 
            this.btDevStartTransfer.Location = new System.Drawing.Point(374, 76);
            this.btDevStartTransfer.Name = "btDevStartTransfer";
            this.btDevStartTransfer.Size = new System.Drawing.Size(75, 23);
            this.btDevStartTransfer.TabIndex = 8;
            this.btDevStartTransfer.Text = "Dev Start";
            this.btDevStartTransfer.UseVisualStyleBackColor = true;
            this.btDevStartTransfer.Click += new System.EventHandler(this.btDevStartTransfer_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 247);
            this.Controls.Add(this.btDevStartTransfer);
            this.Controls.Add(this.btStsStartTransfer);
            this.Controls.Add(this.btDevChoosePath);
            this.Controls.Add(this.btStsChoosePath);
            this.Controls.Add(this.tbDevPath);
            this.Controls.Add(this.tbStsPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "TPLog";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStsPath;
        private System.Windows.Forms.TextBox tbDevPath;
        private System.Windows.Forms.Button btStsChoosePath;
        private System.Windows.Forms.Button btDevChoosePath;
        private System.Windows.Forms.Button btStsStartTransfer;
        private System.Windows.Forms.OpenFileDialog ofdStsLog;
        private System.Windows.Forms.OpenFileDialog ofdDevLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyConfigFileToolStripMenuItem;
        private System.Windows.Forms.Button btDevStartTransfer;
    }
}

