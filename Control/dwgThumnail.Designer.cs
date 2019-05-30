namespace DWGLib.Control
{
    partial class DwgThumnail
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            this.DwgTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BlockImage = new System.Windows.Forms.PictureBox();
            this.Panel = new System.Windows.Forms.Panel();
            this.BlockName = new System.Windows.Forms.Label();
            this.ViewDWG = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockImage)).BeginInit();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DwgTooltip
            // 
            this.DwgTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.BlockImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Panel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(94, 114);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BlockImage
            // 
            this.BlockImage.BackColor = System.Drawing.Color.Black;
            this.BlockImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BlockImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BlockImage.ErrorImage = global::DWGLib.Properties.Resources.dwg_icon;
            this.BlockImage.Location = new System.Drawing.Point(3, 3);
            this.BlockImage.Name = "BlockImage";
            this.BlockImage.Padding = new System.Windows.Forms.Padding(5);
            this.BlockImage.Size = new System.Drawing.Size(88, 78);
            this.BlockImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BlockImage.TabIndex = 0;
            this.BlockImage.TabStop = false;
            this.BlockImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BlockImage_MouseClick);
            this.BlockImage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.BlockImage_MouseDoubleClick);
            this.BlockImage.MouseLeave += new System.EventHandler(this.BlockImage_MouseLeave);
            this.BlockImage.MouseHover += new System.EventHandler(this.BlockImage_MouseHover);
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.BlockName);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(3, 87);
            this.Panel.Name = "Panel";
            this.Panel.Padding = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.Panel.Size = new System.Drawing.Size(88, 24);
            this.Panel.TabIndex = 1;
            // 
            // BlockName
            // 
            this.BlockName.AutoEllipsis = true;
            this.BlockName.Location = new System.Drawing.Point(0, 6);
            this.BlockName.Name = "BlockName";
            this.BlockName.Size = new System.Drawing.Size(84, 14);
            this.BlockName.TabIndex = 0;
            this.BlockName.Text = "图块名称";
            this.BlockName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewDWG
            // 
            this.ViewDWG.Image = global::DWGLib.Properties.Resources.viewer1;
            this.ViewDWG.Name = "ViewDWG";
            this.ViewDWG.Size = new System.Drawing.Size(152, 22);
            this.ViewDWG.Text = "在程序中查看";
            this.ViewDWG.Click += new System.EventHandler(this.ViewDWG_Click);
            // 
            // DwgThumnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SimSun", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DwgThumnail";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(100, 120);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlockImage)).EndInit();
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ToolTip DwgTooltip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel Panel;
        public System.Windows.Forms.PictureBox BlockImage;
        private System.Windows.Forms.Label BlockName;
       // private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ViewDWG;
    }
}
