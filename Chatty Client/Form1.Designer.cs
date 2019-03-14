namespace Chatty_Client
{
    partial class Form1
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
            this.tbLogs = new System.Windows.Forms.TextBox();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.btSendMessage = new System.Windows.Forms.Button();
            this.btLogin = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tvChatTree = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.btCreateRoom = new System.Windows.Forms.Button();
            this.tbCreateRoom = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.wbChat = new System.Windows.Forms.WebBrowser();
            this.bwConnect = new System.ComponentModel.BackgroundWorker();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbLogs
            // 
            this.tbLogs.Location = new System.Drawing.Point(15, 578);
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.ReadOnly = true;
            this.tbLogs.Size = new System.Drawing.Size(116, 84);
            this.tbLogs.TabIndex = 2;
            this.tbLogs.Visible = false;
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(12, 426);
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(331, 20);
            this.tbMsg.TabIndex = 1;
            this.tbMsg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMsg_KeyDown);
            // 
            // btSendMessage
            // 
            this.btSendMessage.Location = new System.Drawing.Point(349, 426);
            this.btSendMessage.Name = "btSendMessage";
            this.btSendMessage.Size = new System.Drawing.Size(75, 23);
            this.btSendMessage.TabIndex = 2;
            this.btSendMessage.Text = "Wyślij";
            this.btSendMessage.UseVisualStyleBackColor = true;
            this.btSendMessage.Click += new System.EventHandler(this.btSendMessage_Click);
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(99, 71);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(95, 23);
            this.btLogin.TabIndex = 4;
            this.btLogin.Text = "Zaloguj";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(61, 48);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(133, 20);
            this.tbUserName.TabIndex = 0;
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Controls.Add(this.nudPort);
            this.gbLogin.Controls.Add(this.tbIp);
            this.gbLogin.Controls.Add(this.label1);
            this.gbLogin.Controls.Add(this.tbUserName);
            this.gbLogin.Controls.Add(this.btLogin);
            this.gbLogin.Location = new System.Drawing.Point(1, 0);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(200, 100);
            this.gbLogin.TabIndex = 6;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Logowanie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "IP:";
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(134, 22);
            this.nudPort.Maximum = new decimal(new int[] {
            65565,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(60, 20);
            this.nudPort.TabIndex = 8;
            this.nudPort.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(33, 22);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(95, 20);
            this.tbIp.TabIndex = 7;
            this.tbIp.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // tvChatTree
            // 
            this.tvChatTree.Location = new System.Drawing.Point(6, 19);
            this.tvChatTree.Name = "tvChatTree";
            this.tvChatTree.Size = new System.Drawing.Size(190, 358);
            this.tvChatTree.TabIndex = 8;
            this.tvChatTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvChatTree_NodeMouseDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Dołącz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCreateRoom
            // 
            this.btCreateRoom.Location = new System.Drawing.Point(121, 412);
            this.btCreateRoom.Name = "btCreateRoom";
            this.btCreateRoom.Size = new System.Drawing.Size(75, 23);
            this.btCreateRoom.TabIndex = 5;
            this.btCreateRoom.Text = "Stwórz nowy";
            this.btCreateRoom.UseVisualStyleBackColor = true;
            this.btCreateRoom.Click += new System.EventHandler(this.btCreateRoom_Click);
            // 
            // tbCreateRoom
            // 
            this.tbCreateRoom.Location = new System.Drawing.Point(6, 412);
            this.tbCreateRoom.Name = "tbCreateRoom";
            this.tbCreateRoom.Size = new System.Drawing.Size(109, 20);
            this.tbCreateRoom.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btCreateRoom);
            this.groupBox3.Controls.Add(this.tbCreateRoom);
            this.groupBox3.Controls.Add(this.tvChatTree);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(430, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(203, 442);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pokoje czatowe";
            // 
            // wbChat
            // 
            this.wbChat.Location = new System.Drawing.Point(12, 19);
            this.wbChat.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbChat.Name = "wbChat";
            this.wbChat.Size = new System.Drawing.Size(412, 399);
            this.wbChat.TabIndex = 8;
            // 
            // bwConnect
            // 
            this.bwConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnect_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 459);
            this.Controls.Add(this.gbLogin);
            this.Controls.Add(this.wbChat);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btSendMessage);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.tbLogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Chatty Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogs;
        private System.Windows.Forms.TextBox tbMsg;
        private System.Windows.Forms.Button btSendMessage;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tvChatTree;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btCreateRoom;
        private System.Windows.Forms.TextBox tbCreateRoom;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.WebBrowser wbChat;
        private System.ComponentModel.BackgroundWorker bwConnect;
    }
}

