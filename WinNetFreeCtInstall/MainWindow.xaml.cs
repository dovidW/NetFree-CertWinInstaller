using System.Linq;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System.Net;

namespace WinNetFreeCtInstall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Cert cert;

        public MainWindow()
        {
            cert = new Cert();
            DataContext = cert;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cert.IsCertInstall)
                cert.Remove();
            else
                cert.install();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            cert.ReCheckProvider();
        }
    }


    class Cert : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsCertInstall { get; private set; } = false;
        public bool IsProviderInstall { get; private set; } = false;

        //string certUrl = "http://google.com/netfree-ca.crt";

        //For testing without provider
        string certUrl = "https://github.com/magicode/NetFree/raw/master/lib/ssl/ca/ca.crt";

        X509Certificate2 cert;
        byte[] publicKey = new byte[] { 48, 129, 137, 2, 129, 129, 0, 177, 208, 32, 238, 169, 230, 73, 71, 151, 255, 164, 58, 84, 25, 251, 247, 83, 156, 144, 7, 108, 102, 192, 155, 198, 144, 253, 238, 114, 124, 216, 155, 112, 34, 72, 126, 166, 17, 63, 6, 135, 222, 170, 191, 136, 203, 142, 48, 112, 23, 194, 238, 74, 121, 25, 163, 164, 23, 172, 204, 235, 9, 53, 203, 147, 238, 44, 103, 240, 90, 255, 122, 228, 109, 92, 145, 119, 123, 147, 213, 190, 232, 38, 239, 55, 62, 12, 247, 130, 168, 14, 245, 165, 11, 78, 165, 179, 57, 139, 181, 162, 79, 238, 105, 73, 109, 113, 56, 107, 71, 19, 147, 136, 35, 55, 190, 210, 42, 57, 123, 127, 140, 83, 33, 109, 28, 162, 247, 2, 3, 1, 0, 1 };
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
                    cert = new X509Certificate2(new WebClient().DownloadData(certUrl));
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
            if (IsCertInstall) return;
            store.Open(OpenFlags.ReadWrite);
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
            store.Remove(cert);
            store.Close();
            IsCertInstall = false;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("IsCertInstall"));

        }

        bool CheckCert()
        {
            foreach (var ct in store.Certificates)
                if (ct.PublicKey.EncodedKeyValue.RawData.SequenceEqual(publicKey))
                    return true;

            return false;
        }

    }



}
