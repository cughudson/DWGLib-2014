using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace DWGLib.Dialog
{
    public partial class Register : Form
    {
        string EncryString = Environment.MachineName + "cscecdec";
        public Register()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string Code = GetMd5Hash(MD5.Create(), EncryString);
            if (this.RegisterCodeInput.Text != Code)
            {
                this.hint.Visible = true;
            }
            else
            {
                Properties.Settings.Default.verifycode = this.RegisterCodeInput.Text;
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
        }
        private string GetMd5Hash(MD5 md5Hash, string str)
        {
            byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }
    }
}
