using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Net;


namespace WinCertInstallNetFree
{
    public partial class NetFree : Form
    {
        Cert cert;


        private void update()
        {
            if (cert.IsCertInstall)
            {
                this.bt_remove.Enabled = true;
                this.s_cert.Text = "מותקן";
                this.s_cert.ForeColor = Color.Green;

            }
            else
            {
                this.bt_remove.Enabled = false;
                this.s_cert.Text = "לא מותקן";
                this.s_cert.ForeColor = Color.Red;
            }

            if (cert.IsProviderInstall)
            {
                this.bt_install.Enabled = true;
                this.s_isp.Text = "מחובר";
                this.s_isp.ForeColor = Color.Green;
            }
            else
            {
                this.bt_install.Enabled = false;
                this.s_isp.Text = "לא מחובר";
                this.s_isp.ForeColor = Color.Red;
            }

        }
        public NetFree()
        {
            cert = new Cert();
            
            cert.PropertyChanged +=cert_PropertyChanged;
            InitializeComponent();
            update();
        }

        private void cert_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            update();
        }

        private void bt_install_Click(object sender, EventArgs e)
        {
            cert.install();
        }

        private void bt_remove_Click(object sender, EventArgs e)
        {
            cert.Remove();
        }
        private void recheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cert.ReCheckProvider();
        }

        class Cert : System.ComponentModel.INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public bool IsCertInstall { get; private set; }
            public bool IsProviderInstall { get; private set; }

            string certUrl = "http://google.com/netfree-ca.crt";

            //For testing without provider
            //string certUrl = @"https://github.com/magicode/NetFree/raw/master/lib/ssl/ca/ca.crt";

            X509Certificate2 cert;
            X509Store store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);

            public Cert()
            {
                ReCheckProvider();

                store.Open(OpenFlags.ReadOnly);

                IsCertInstall = CheckCert();

                store.Close();
            }

            public void ReCheckProvider()
            {
                using (var wc = new WebClient())
                {
                    try
                    {
                        cert = new X509Certificate2(wc.DownloadData(certUrl));
                        IsProviderInstall = true;
                    }
                    catch (System.Exception ex)
                    {
                        IsProviderInstall = false;
                    }
                }

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsProviderInstall"));
            }

            public void install()
            {
                store.Open(OpenFlags.ReadWrite);

                foreach (var ct in store.Certificates)
                    if (ct.IssuerName.Name.Contains("O=NetFree"))
                        store.Remove(ct);

                store.Add(cert);
                store.Close();

                IsCertInstall = true;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsCertInstall"));
            }

            public void Remove()
            {
                if (!IsCertInstall) return;

                store.Open(OpenFlags.ReadWrite);

                foreach (var ct in store.Certificates)
                    if (ct.IssuerName.Name.Contains("O=NetFree"))
                        store.Remove(ct);

                store.Close();

                IsCertInstall = false;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsCertInstall"));

            }

            bool CheckCert()
            {
                foreach (var ct in store.Certificates)
                    if (ct.IssuerName.Name.Contains("O=NetFree"))
                        return true;

                return false;
            }

        }



        
    }
}
