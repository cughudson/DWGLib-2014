using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace Installerhelper
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        private string DestPath = null;
        private string SourcePath = null;
        public Installer()
        {
            InitializeComponent();

            this.AfterInstall += Installer_AfterInstall;
        }
        protected override void OnCommitting(IDictionary savedState)
        {

        }
        private void Installer_AfterInstall(object sender, InstallEventArgs e)
        {

        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }
    }
}
