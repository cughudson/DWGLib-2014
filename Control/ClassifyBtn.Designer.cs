namespace DWGLib.Control
{
    partial class ClassifyBtn
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ArrowImage = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClasslifyName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ArrowImage)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArrowImage
            // 
            this.ArrowImage.BackColor = System.Drawing.Color.Transparent;
            this.ArrowImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ArrowImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ArrowImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ArrowImage.Image = global::DWGLib.Properties.Resources.rightarrow_black;
            this.ArrowImage.Location = new System.Drawing.Point(182, 3);
            this.ArrowImage.Margin = new System.Windows.Forms.Padding(2);
            this.ArrowImage.Name = "ArrowImage";
            this.ArrowImage.Padding = new System.Windows.Forms.Padding(3);
            this.ArrowImage.Size = new System.Drawing.Size(20, 20);
            this.ArrowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ArrowImage.TabIndex = 0;
            this.ArrowImage.TabStop = false;
            this.ArrowImage.Click += new System.EventHandler(this.ClasslifyPicture_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Controls.Add(this.ArrowImage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(205, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ClasslifyName);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 0, 2, 5);
            this.panel1.Size = new System.Drawing.Size(178, 24);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // ClasslifyName
            // 
            this.ClasslifyName.AutoEllipsis = true;
            this.ClasslifyName.AutoSize = true;
            this.ClasslifyName.Location = new System.Drawing.Point(6, 5);
            this.ClasslifyName.Name = "ClasslifyName";
            this.ClasslifyName.Size = new System.Drawing.Size(53, 12);
            this.ClasslifyName.TabIndex = 0;
            this.ClasslifyName.Text = "类别名称";
            this.ClasslifyName.Click += new System.EventHandler(this.ClasslifyName_Click);
            // 
            // ClassifyBtn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClassifyBtn";
            this.Size = new System.Drawing.Size(205, 26);
            ((System.ComponentModel.ISupportInitialize)(this.ArrowImage)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ArrowImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label ClasslifyName;
    }
}
