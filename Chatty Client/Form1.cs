using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatty_Client
{

    /// <summary>
    /// Projekt serwera i klienta TCP, oparty asynchronicznych socketach.
    /// Projekt ma na zadanie przedstawić aplikację czatu w ujęciu obiektowym,
    /// gdzie funkcjonalność jest oddzielona od interfejsu graficznego, a kod
    /// napisany jest w wystarczającej abstrakcji umożliwiającej zarówno własną implementację
    /// oraz edycję poszczególnych działań i zachowań jak i przyszły ich rozwój w elastyczny sposób.
    /// 
    /// Michał Czopek, Krzysztof Szymański, 3ic1
    /// </summary>
    public partial class Form1 : Form
    {
        private ChatClient chatClient;
        public Form1()
        {
            InitializeComponent();
            this.Width = 218;
            this.Height = 138;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UIAgent agent = new UIAgent(tbLogs, tvChatTree, wbChat);
            chatClient = new ChatClient(agent, onServerDisconnected);
            tbUserName.Focus();
        }

        private void setLoginForm()
        {
            gbLogin.Visible = true;
            tbLogs.Visible = false;
            this.Width = 218;
            this.Height = 138;
        }

        private void setChatForm()
        {
            //652; 498
            gbLogin.Visible = false;
            tvChatTree.Nodes.Clear();
            tbLogs.Text = "";
            tbLogs.Visible = true;
            this.Width = 652;
            this.Height = 498;
        }

        private void onServerDisconnected(string msg)
        {
            this.Invoke((MethodInvoker)(() => setLoginForm()));
            //setLoginForm();
            MessageBox.Show(msg);
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            setChatForm();
            bwConnect.RunWorkerAsync();
        }

        private void btSendMessage_Click(object sender, EventArgs e)
        {
            if(tbMsg.Text != "")
                chatClient.sendRoomMessage(tbMsg.Text);
            tbMsg.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            joinToSelectedRoom();
        }
        private void joinToSelectedRoom()
        {
            var node = tvChatTree.SelectedNode;
            if (node != null)
            {
                if (node.Parent != null)
                {
                    node = node.Parent;
                }
                chatClient.joinChatRoom(node.Text);
            }
        }

        private void btCreateRoom_Click(object sender, EventArgs e)
        {
            chatClient.createChatRoom(tbCreateRoom.Text);
        }

        private void tvChatTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            joinToSelectedRoom();
        }

        private void tbMsg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tbMsg.Text != "")
                    chatClient.sendRoomMessage(tbMsg.Text);
                tbMsg.Text = "";
            }
        }

        private void bwConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            chatClient.connect(tbIp.Text, Decimal.ToInt32(nudPort.Value), tbUserName.Text);
        }
    }

   
}
