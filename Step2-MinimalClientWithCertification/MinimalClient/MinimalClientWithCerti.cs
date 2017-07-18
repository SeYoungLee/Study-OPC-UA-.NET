using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using Opc.Ua.Sample.Controls;

namespace MinimalClient
{
    public partial class MinimalClientWithCerti : Form
    {
        private ApplicationConfiguration m_config;
        private Session m_session;

        public MinimalClientWithCerti()
        {
            InitializeComponent();
            
            if(EndpointCB.Items.Count > 0)
            {
                EndpointCB.SelectedIndex = 0;
            }

            //"1 - Load config info from file"
            m_config = LoadConfigFromFile();

        }
        
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string endPointUrl = this.EndpointCB.Text;
            Uri uri = new Uri(endPointUrl);

            //2 - Create EndpointDescription
            EndpointDescription description = new EndpointDescription();
            description.EndpointUrl = uri.ToString();
            description.SecurityMode = MessageSecurityMode.SignAndEncrypt;
            description.SecurityPolicyUri = SecurityPolicies.Basic128Rsa15;
            description.Server.ApplicationUri = Utils.UpdateInstanceUri(uri.ToString());
            description.Server.ApplicationName = uri.AbsolutePath;

            //3 - Create Endpoint
            ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, description);

            //4 - Create Session
            m_session = Session.Create(m_config, endpoint, true, "", 60000, null, null);

            //5 - Show the server namespace
            browseTreeCtrl1.SetView(m_session, BrowseViewType.Objects, null);
            
        }

        private ApplicationConfiguration LoadConfigFromFile()
        {
            ApplicationInstance application = new ApplicationInstance();
            // application.ApplicationName = "MinimalClientWithCerti";
            //application.ApplicationType = ApplicationType.ClientAndServer;
            application.ConfigSectionName = "MinimalClientWithCerti";
            

            // load the application configuration. 
            // app.config 파일에서 위에서 설정한 ConfigSectionName 아래에 있는 filePath 경로를 참조하여 파일로드(app.config 참조)
            // 없으면 '어셈블리이름'.xml파일을 찾음
            application.LoadApplicationConfiguration(false);

            // check the application certificate.
            application.CheckApplicationInstanceCertificate(false, 2048);

            return application.ApplicationConfiguration;
        }        

        private void MinimalClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        public void Disconnect()
        {
            if (m_session != null)
            {
                m_session.Close();
                m_session = null;
            }            
        }
    }
}
