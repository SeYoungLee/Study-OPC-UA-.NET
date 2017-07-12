using System;
using System.Windows.Forms;

using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using Opc.Ua.Sample.Controls;


namespace MinimalClient
{
    public partial class MinimalClient : Form
    {
        private ApplicationConfiguration _config;
        private Session _session;

        public MinimalClient()
        {
            InitializeComponent();

            if (EndpointCB.Items.Count > 0)
                EndpointCB.SelectedIndex = 0;

            //"1 - Create a config"
            _config = CreateOpcUaAppConfiguration();
        }
        
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string endPointUrl = this.EndpointCB.Text;

            //2 - Create Session
            _session = Session.Create(_config, new ConfiguredEndpoint(null, new EndpointDescription(endPointUrl)), true, "", 60000, null, null);
            
            //3 - Show the server namespace
            browseTreeCtrl1.SetView(_session, BrowseViewType.Objects, null);


            //BrowsTreeControl을 사용하지 않는 경우 아래 코드를 사용하여 AddressSpace를 순회할 수 있다.

            //ReferenceDescriptionCollection refs;
            //byte[] continuationPoint;

            //_session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out continuationPoint, out refs);

            //foreach (var rd in refs)
            //{
            //    Console.WriteLine("{0}: {1}, {2}", rd.DisplayName, rd.BrowseName, rd.NodeClass);
            //    ReferenceDescriptionCollection nextRefs;
            //    byte[] nextCp;
            //    _session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, _session.NamespaceUris), 0u, BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true, (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp, out nextRefs);
            //    foreach (var nextRd in nextRefs)
            //    {
            //        Console.WriteLine("+ {0}: {1}, {2}", nextRd.DisplayName, nextRd.BrowseName, nextRd.NodeClass);
            //    }
            //}                

        }
        
        private ApplicationConfiguration CreateOpcUaAppConfiguration()
        {
            var config = new ApplicationConfiguration()
            {
                ApplicationName = "MinimalClient",
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier(),
                    AutoAcceptUntrustedCertificates = true   //신뢰할 수 없는 인증서 허용
                },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
            };
            
            config.Validate(ApplicationType.Client);

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

        private void MinimalClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        public void Disconnect()
        {
            if (_session != null)
            {
                _session.Close();
                _session = null;
            }            
        }
    }
}
