namespace ThumnailPreProcess
{
    partial class ThumnailPreProcess
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.BackGroundSelect = new System.Windows.Forms.GroupBox();
            this.WhiteRadio = new System.Windows.Forms.RadioButton();
            this.BlockRadio = new System.Windows.Forms.RadioButton();
            this.StartProcessBtn = new System.Windows.Forms.Button();
            this.OpenRootFolderBtn = new System.Windows.Forms.Button();
            this.RootPath = new System.Windows.Forms.Label();
            this.CurrentFile = new System.Windows.Forms.Label();
            this.Percent = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.StartCAD = new System.Windows.Forms.Button();
            this.BackGroundSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 196);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(610, 30);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 2;
            // 
            // BackGroundSelect
            // 
            this.BackGroundSelect.Controls.Add(this.WhiteRadio);
            this.BackGroundSelect.Controls.Add(this.BlockRadio);
            this.BackGroundSelect.Location = new System.Drawing.Point(12, 85);
            this.BackGroundSelect.Name = "BackGroundSelect";
            this.BackGroundSelect.Size = new System.Drawing.Size(611, 65);
            this.BackGroundSelect.TabIndex = 5;
            this.BackGroundSelect.TabStop = false;
            this.BackGroundSelect.Text = "背景颜色选择";
            // 
            // WhiteRadio
            // 
            this.WhiteRadio.AutoSize = true;
            this.WhiteRadio.Location = new System.Drawing.Point(112, 31);
            this.WhiteRadio.Name = "WhiteRadio";
            this.WhiteRadio.Size = new System.Drawing.Size(47, 16);
            this.WhiteRadio.TabIndex = 5;
            this.WhiteRadio.TabStop = true;
            this.WhiteRadio.Text = "白色";
            this.WhiteRadio.UseVisualStyleBackColor = true;
            this.WhiteRadio.Click += new System.EventHandler(this.WhiteRadio_Click);
            // 
            // BlockRadio
            // 
            this.BlockRadio.AutoSize = true;
            this.BlockRadio.Checked = true;
            this.BlockRadio.Location = new System.Drawing.Point(18, 31);
            this.BlockRadio.Name = "BlockRadio";
            this.BlockRadio.Size = new System.Drawing.Size(47, 16);
            this.BlockRadio.TabIndex = 4;
            this.BlockRadio.TabStop = true;
            this.BlockRadio.Text = "黑色";
            this.BlockRadio.UseVisualStyleBackColor = true;
            this.BlockRadio.Click += new System.EventHandler(this.BlockRadio_Click);
            // 
            // StartProcessBtn
            // 
            this.StartProcessBtn.Enabled = false;
            this.StartProcessBtn.Location = new System.Drawing.Point(119, 27);
            this.StartProcessBtn.Name = "StartProcessBtn";
            this.StartProcessBtn.Size = new System.Drawing.Size(75, 35);
            this.StartProcessBtn.TabIndex = 1;
            this.StartProcessBtn.Text = "开始处理";
            this.StartProcessBtn.UseVisualStyleBackColor = true;
            this.StartProcessBtn.Click += new System.EventHandler(this.StartProcess);
            // 
            // OpenRootFolderBtn
            // 
            this.OpenRootFolderBtn.Location = new System.Drawing.Point(12, 27);
            this.OpenRootFolderBtn.Name = "OpenRootFolderBtn";
            this.OpenRootFolderBtn.Size = new System.Drawing.Size(86, 35);
            this.OpenRootFolderBtn.TabIndex = 0;
            this.OpenRootFolderBtn.Text = "打开文件夹";
            this.OpenRootFolderBtn.UseVisualStyleBackColor = true;
            this.OpenRootFolderBtn.Click += new System.EventHandler(this.SelectProcessFolder);
            // 
            // RootPath
            // 
            this.RootPath.AutoSize = true;
            this.RootPath.Location = new System.Drawing.Point(12, 164);
            this.RootPath.Name = "RootPath";
            this.RootPath.Size = new System.Drawing.Size(42, 19);
            this.RootPath.TabIndex = 6;
            this.RootPath.Text = "根目录";
            this.RootPath.UseCompatibleTextRendering = true;
            // 
            // CurrentFile
            // 
            this.CurrentFile.AutoSize = true;
            this.CurrentFile.Location = new System.Drawing.Point(10, 247);
            this.CurrentFile.Name = "CurrentFile";
            this.CurrentFile.Size = new System.Drawing.Size(53, 12);
            this.CurrentFile.TabIndex = 7;
            this.CurrentFile.Text = "当前文件";
            // 
            // Percent
            // 
            this.Percent.AutoSize = true;
            this.Percent.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Percent.Location = new System.Drawing.Point(573, 41);
            this.Percent.Name = "Percent";
            this.Percent.Size = new System.Drawing.Size(32, 21);
            this.Percent.TabIndex = 8;
            this.Percent.Text = "00";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ProcessDWGFile);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProcessChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ProcessComplelte);
            // 
            // StartCAD
            // 
            this.StartCAD.Location = new System.Drawing.Point(220, 27);
            this.StartCAD.Name = "StartCAD";
            this.StartCAD.Size = new System.Drawing.Size(75, 35);
            this.StartCAD.TabIndex = 9;
            this.StartCAD.Text = "启动CAD";
            this.StartCAD.UseVisualStyleBackColor = true;
            this.StartCAD.Click += new System.EventHandler(this.StartUpAutoCAD);
            // 
            // ThumnailPreProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 301);
            this.Controls.Add(this.StartCAD);
            this.Controls.Add(this.Percent);
            this.Controls.Add(this.CurrentFile);
            this.Controls.Add(this.RootPath);
            this.Controls.Add(this.OpenRootFolderBtn);
            this.Controls.Add(this.BackGroundSelect);
            this.Controls.Add(this.StartProcessBtn);
            this.Controls.Add(this.progressBar);
            this.HelpButton = true;
            this.Icon = global::ThumnailPreProcess.Properties.Resources.logo;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 340);
            this.Name = "ThumnailPreProcess";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "缩略图预处理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThumnailPreProcess_FormClosing);
            this.BackGroundSelect.ResumeLayout(false);
            this.BackGroundSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox BackGroundSelect;
        public System.Windows.Forms.RadioButton WhiteRadio;
        private System.Windows.Forms.RadioButton BlockRadio;
        private System.Windows.Forms.Button StartProcessBtn;
        private System.Windows.Forms.Button OpenRootFolderBtn;
        private System.Windows.Forms.Label RootPath;
        private System.Windows.Forms.Label CurrentFile;
        private System.Windows.Forms.Label Percent;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button StartCAD;
    }
}

