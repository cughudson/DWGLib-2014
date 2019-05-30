namespace DWGLib.Dialog
{
    partial class Register
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.RegisterCodeInput = new System.Windows.Forms.TextBox();
            this.RegisterInput = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.hint = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.RegisterCodeInput);
            this.panel1.Controls.Add(this.RegisterInput);
            this.panel1.Location = new System.Drawing.Point(18, 41);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.panel1.Size = new System.Drawing.Size(264, 31);
            this.panel1.TabIndex = 0;
            // 
            // RegisterCodeInput
            // 
            this.RegisterCodeInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RegisterCodeInput.Location = new System.Drawing.Point(8, 7);
            this.RegisterCodeInput.Name = "RegisterCodeInput";
            this.RegisterCodeInput.Size = new System.Drawing.Size(248, 14);
            this.RegisterCodeInput.TabIndex = 0;
            // 
            // RegisterInput
            // 
            this.RegisterInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RegisterInput.Location = new System.Drawing.Point(4, 8);
            this.RegisterInput.Name = "RegisterInput";
            this.RegisterInput.Size = new System.Drawing.Size(201, 14);
            this.RegisterInput.TabIndex = 0;
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(288, 41);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 31);
            this.Submit.TabIndex = 1;
            this.Submit.Text = "确认";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(16, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "1.插件注册后才能够使用。\r\n2.仅首次加载插件时需要进行注册";
            // 
            // hint
            // 
            this.hint.AutoSize = true;
            this.hint.ForeColor = System.Drawing.Color.Red;
            this.hint.Location = new System.Drawing.Point(16, 94);
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(89, 12);
            this.hint.TabIndex = 3;
            this.hint.Text = "验证码输入错误";
            this.hint.Visible = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.hint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox RegisterInput;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox RegisterCodeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label hint;
    }
}