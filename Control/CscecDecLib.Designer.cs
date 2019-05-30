namespace DWGLib.Control
{
    partial class CSCECDECLib
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
            this.FolderTree = new System.Windows.Forms.TreeView();
            this.Splitter = new System.Windows.Forms.Splitter();
            this.FlowPanelControl = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // FolderTree
            // 
            this.FolderTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.FolderTree.Location = new System.Drawing.Point(5, 5);
            this.FolderTree.Name = "FolderTree";
            this.FolderTree.Size = new System.Drawing.Size(164, 625);
            this.FolderTree.TabIndex = 0;
            this.FolderTree.Click += new System.EventHandler(this.FolderTree_Click);
            // 
            // Splitter
            // 
            this.Splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Splitter.Location = new System.Drawing.Point(169, 5);
            this.Splitter.MinExtra = 100;
            this.Splitter.MinSize = 75;
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(3, 625);
            this.Splitter.TabIndex = 1;
            this.Splitter.TabStop = false;
            // 
            // FlowPanelControl
            // 
            this.FlowPanelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPanelControl.Location = new System.Drawing.Point(172, 5);
            this.FlowPanelControl.Name = "FlowPanelControl";
            this.FlowPanelControl.Size = new System.Drawing.Size(413, 625);
            this.FlowPanelControl.TabIndex = 2;
            // 
            // CSCECDECLib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FlowPanelControl);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.FolderTree);
            this.Name = "CSCECDECLib";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(590, 635);
            this.Load += new System.EventHandler(this.CSCECDECLib_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView FolderTree;
        private System.Windows.Forms.Splitter Splitter;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelControl;
    }
}
