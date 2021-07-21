
namespace TPLogAnalyzer
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStsPath = new System.Windows.Forms.TextBox();
            this.tbDevPath = new System.Windows.Forms.TextBox();
            this.btStsChoosePath = new System.Windows.Forms.Button();
            this.btDevChoosePath = new System.Windows.Forms.Button();
            this.btStartTransfer = new System.Windows.Forms.Button();
            this.ofdStsLog = new System.Windows.Forms.OpenFileDialog();
            this.ofdDevLog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sts Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dev Path";
            // 
            // tbStsPath
            // 
            this.tbStsPath.Location = new System.Drawing.Point(150, 51);
            this.tbStsPath.Name = "tbStsPath";
            this.tbStsPath.Size = new System.Drawing.Size(186, 20);
            this.tbStsPath.TabIndex = 2;
            // 
            // tbDevPath
            // 
            this.tbDevPath.Location = new System.Drawing.Point(150, 79);
            this.tbDevPath.Name = "tbDevPath";
            this.tbDevPath.Size = new System.Drawing.Size(186, 20);
            this.tbDevPath.TabIndex = 3;
            // 
            // btStsChoosePath
            // 
            this.btStsChoosePath.Location = new System.Drawing.Point(342, 51);
            this.btStsChoosePath.Name = "btStsChoosePath";
            this.btStsChoosePath.Size = new System.Drawing.Size(31, 20);
            this.btStsChoosePath.TabIndex = 4;
            this.btStsChoosePath.Text = "···";
            this.btStsChoosePath.UseVisualStyleBackColor = true;
            this.btStsChoosePath.Click += new System.EventHandler(this.btStsChoosePath_Click);
            // 
            // btDevChoosePath
            // 
            this.btDevChoosePath.Location = new System.Drawing.Point(342, 77);
            this.btDevChoosePath.Name = "btDevChoosePath";
            this.btDevChoosePath.Size = new System.Drawing.Size(31, 23);
            this.btDevChoosePath.TabIndex = 5;
            this.btDevChoosePath.Text = "···";
            this.btDevChoosePath.UseVisualStyleBackColor = true;
            this.btDevChoosePath.Click += new System.EventHandler(this.btDevChoosePath_Click);
            // 
            // btStartTransfer
            // 
            this.btStartTransfer.Location = new System.Drawing.Point(391, 50);
            this.btStartTransfer.Name = "btStartTransfer";
            this.btStartTransfer.Size = new System.Drawing.Size(75, 23);
            this.btStartTransfer.TabIndex = 6;
            this.btStartTransfer.Text = "Start";
            this.btStartTransfer.UseVisualStyleBackColor = true;
            this.btStartTransfer.Click += new System.EventHandler(this.btStartTransfer_Click);
            // 
            // ofdStsLog
            // 
            this.ofdStsLog.FileName = "StsLogOFD";
            this.ofdStsLog.Filter = "text|Sts*.txt|all files|*.*";
            this.ofdStsLog.InitialDirectory = "G:\\Code\\C#\\WinForm\\LogExample";
            // 
            // ofdDevLog
            // 
            this.ofdDevLog.FileName = "DevLogOFD";
            this.ofdDevLog.Filter = "text|Dev*.txt|all files|*.*";
            this.ofdDevLog.InitialDirectory = "G:\\Code\\C#\\WinForm\\LogExample";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 247);
            this.Controls.Add(this.btStartTransfer);
            this.Controls.Add(this.btDevChoosePath);
            this.Controls.Add(this.btStsChoosePath);
            this.Controls.Add(this.tbDevPath);
            this.Controls.Add(this.tbStsPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "TPLog";
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
        private System.Windows.Forms.Button btStartTransfer;
        private System.Windows.Forms.OpenFileDialog ofdStsLog;
        private System.Windows.Forms.OpenFileDialog ofdDevLog;
    }
}

