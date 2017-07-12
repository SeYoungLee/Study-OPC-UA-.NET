namespace MinimalClient
{
    partial class MinimalClient
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectButton = new System.Windows.Forms.Button();
            this.EndpointCB = new System.Windows.Forms.ComboBox();
            this.browseTreeCtrl1 = new Opc.Ua.Sample.Controls.BrowseTreeCtrl();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(384, 19);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(91, 26);
            this.ConnectButton.TabIndex = 2;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // EndpointCB
            // 
            this.EndpointCB.FormattingEnabled = true;
            this.EndpointCB.Items.AddRange(new object[] {
            "opc.tcp://localhost:51210/UA/MinimalServer",
            "opc.tcp://localhost:51210/UA/SampleServer"});
            this.EndpointCB.Location = new System.Drawing.Point(13, 19);
            this.EndpointCB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.EndpointCB.Name = "EndpointCB";
            this.EndpointCB.Size = new System.Drawing.Size(363, 23);
            this.EndpointCB.TabIndex = 3;
            // 
            // browseTreeCtrl1
            // 
            this.browseTreeCtrl1.AttributesCtrl = null;
            this.browseTreeCtrl1.EnableDragging = false;
            this.browseTreeCtrl1.Location = new System.Drawing.Point(13, 62);
            this.browseTreeCtrl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browseTreeCtrl1.Name = "browseTreeCtrl1";
            this.browseTreeCtrl1.SessionTreeCtrl = null;
            this.browseTreeCtrl1.Size = new System.Drawing.Size(462, 353);
            this.browseTreeCtrl1.TabIndex = 4;
            // 
            // MinimalClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 445);
            this.Controls.Add(this.browseTreeCtrl1);
            this.Controls.Add(this.EndpointCB);
            this.Controls.Add(this.ConnectButton);
            this.Name = "MinimalClient";
            this.Text = "MinimalClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MinimalClient_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox EndpointCB;
        private Opc.Ua.Sample.Controls.BrowseTreeCtrl browseTreeCtrl1;
    }
}

