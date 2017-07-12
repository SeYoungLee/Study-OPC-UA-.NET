using System.Windows.Forms;

using Opc.Ua;
using Opc.Ua.Server;
using Opc.Ua.Configuration;

namespace MinimalServer
{
    public partial class MinimalServerMainForm : Form
    {
        private ApplicationConfiguration _config;
        StandardServer _server;

        public MinimalServerMainForm()
        {
            InitializeComponent();

            _config = CreateOpcUaAppConfiguration();
            CheckApplicationInstanceCertificate(_config);

            _server = new StandardServer();
            _server.Start(_config);

            UrlCB.Items.Clear();

            foreach (EndpointDescription endpoint in _server.GetEndpoints())
            {
                if (UrlCB.FindStringExact(endpoint.EndpointUrl) == -1)
                {
                    UrlCB.Items.Add(endpoint.EndpointUrl);
                }
            }

            if (UrlCB.Items.Count > 0)
            {
                UrlCB.SelectedIndex = 0;
            }
        }

        private ApplicationConfiguration CreateOpcUaAppConfiguration()
        {
            var config = new ApplicationConfiguration()
            {
                ApplicationName = "MinimalServer", 
                ApplicationType = ApplicationType.Server,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier()
                    {
                        StoreType = @"Directory",
                        StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault",
                        SubjectName = "CN=MinimalServer, DC=" + System.Net.Dns.GetHostName()
                    },
                    TrustedPeerCertificates = new CertificateTrustList
                    {
                        StoreType = @"Directory",
                        StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications"
                    },
                    NonceLength = 32,
                    AutoAcceptUntrustedCertificates = true
                },
                ServerConfiguration = new ServerConfiguration()
                {
                    SecurityPolicies =
                    {
                        new ServerSecurityPolicy()
                        {
                            SecurityMode = MessageSecurityMode.None,
                            SecurityPolicyUri = SecurityPolicies.None,
                            SecurityLevel = 0
                        }
                    },
                    BaseAddresses = new StringCollection()
                    {
                        "opc.tcp://localhost:51210/UA/MinimalServer"
                    }
                },
                Extensions = new XmlElementCollection()
            };
            
            config.Validate(ApplicationType.Server);
                        
            //신뢰할 수 없는 인증서 허용
            if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                config.CertificateValidator.CertificateValidation += (s, e) =>
                {
                    e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted);
                };
            }
            
            return config;
        }

        private void CheckApplicationInstanceCertificate(ApplicationConfiguration config)
        {
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationConfiguration = config;
            application.CheckApplicationInstanceCertificate(false, 2048);  //인증서를 check하고 없으면 만들고 등록까지한다.
        }

        private void MinimalServerMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.Stop();
        }
    }
}
