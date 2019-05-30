namespace DWGLib.Dialog
{
    partial class SetttingDlg
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
            this.components = new System.ComponentModel.Container();
            this.libPathSetting = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.OKBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StdSysPathLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.StdBlockPatnLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.SysPathBtn = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.BlockPathBtn = new System.Windows.Forms.Button();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.libPathSetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // libPathSetting
            // 
            this.libPathSetting.Controls.Add(this.tableLayoutPanel1);
            this.libPathSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.libPathSetting.Location = new System.Drawing.Point(10, 10);
            this.libPathSetting.Name = "libPathSetting";
            this.libPathSetting.Size = new System.Drawing.Size(504, 181);
            this.libPathSetting.TabIndex = 0;
            this.libPathSetting.TabStop = false;
            this.libPathSetting.Text = "图库路径设置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 161);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 99);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.panel1.Size = new System.Drawing.Size(492, 59);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel8, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(482, 39);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(276, 33);
            this.panel6.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(285, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(94, 33);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.OKBtn);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(385, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(94, 33);
            this.panel8.TabIndex = 2;
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(14, 1);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(75, 30);
            this.OKBtn.TabIndex = 1;
            this.OKBtn.Text = "保存";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StdSysPathLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 28);
            this.panel2.TabIndex = 1;
            // 
            // StdSysPathLabel
            // 
            this.StdSysPathLabel.AutoEllipsis = true;
            this.StdSysPathLabel.AutoSize = true;
            this.StdSysPathLabel.Location = new System.Drawing.Point(3, 9);
            this.StdSysPathLabel.Name = "StdSysPathLabel";
            this.StdSysPathLabel.Size = new System.Drawing.Size(101, 12);
            this.StdSysPathLabel.TabIndex = 0;
            this.StdSysPathLabel.Text = "设置系统图库路径";
            this.StdSysPathLabel.MouseHover += new System.EventHandler(this.StdSysPathLabel_MouseHover);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.StdBlockPatnLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(5, 10, 10, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 33);
            this.panel3.TabIndex = 2;
            // 
            // StdBlockPatnLabel
            // 
            this.StdBlockPatnLabel.AutoEllipsis = true;
            this.StdBlockPatnLabel.AutoSize = true;
            this.StdBlockPatnLabel.Location = new System.Drawing.Point(3, 11);
            this.StdBlockPatnLabel.Name = "StdBlockPatnLabel";
            this.StdBlockPatnLabel.Size = new System.Drawing.Size(101, 12);
            this.StdBlockPatnLabel.TabIndex = 0;
            this.StdBlockPatnLabel.Text = "设置图块图库路径";
            this.StdBlockPatnLabel.MouseHover += new System.EventHandler(this.StdBlockPatnLabel_MouseHover);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.SysPathBtn);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(401, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(94, 42);
            this.panel4.TabIndex = 3;
            // 
            // SysPathBtn
            // 
            this.SysPathBtn.Location = new System.Drawing.Point(6, 7);
            this.SysPathBtn.Name = "SysPathBtn";
            this.SysPathBtn.Size = new System.Drawing.Size(75, 30);
            this.SysPathBtn.TabIndex = 0;
            this.SysPathBtn.Text = "系统图库";
            this.SysPathBtn.UseVisualStyleBackColor = true;
            this.SysPathBtn.Click += new System.EventHandler(this.SysPathBtn_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.BlockPathBtn);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(401, 51);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(94, 42);
            this.panel5.TabIndex = 4;
            // 
            // BlockPathBtn
            // 
            this.BlockPathBtn.Location = new System.Drawing.Point(6, 9);
            this.BlockPathBtn.Name = "BlockPathBtn";
            this.BlockPathBtn.Size = new System.Drawing.Size(75, 30);
            this.BlockPathBtn.TabIndex = 0;
            this.BlockPathBtn.Text = "图块图库";
            this.BlockPathBtn.UseVisualStyleBackColor = true;
            this.BlockPathBtn.Click += new System.EventHandler(this.BlockPathBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "鼠标悬停在路径上面可以看到完整的路径";
            // 
            // SetttingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 201);
            this.Controls.Add(this.libPathSetting);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(540, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 240);
            this.Name = "SetttingDlg";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetttingDlg_FormClosing);
            this.libPathSetting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox libPathSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label StdSysPathLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label StdBlockPatnLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button SysPathBtn;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BlockPathBtn;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
    }
}