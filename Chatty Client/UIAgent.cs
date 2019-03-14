using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatty_Client
{
    /// <summary>
    /// Klasa pośrednicząca między mechanizmem klienta czatu a interfejsem użytkownika.
    /// Nadaje elastycznosci i dowolnosci w tworzeniu GUI.
    /// </summary>
    public class UIAgent
    {

        private TreeView tvChatTree;
        private TextBox tbLog;
        private WebBrowser wb;
        private HTMLBuilder builder;

        public UIAgent(TextBox tb, TreeView tvChat, WebBrowser wb)
        {
            tbLog = tb;
            this.wb = wb;
            tvChatTree = tvChat;
            builder = new HTMLBuilder(wb);
        }

        public void log(string msg)
        {
            tbLog.Invoke((MethodInvoker)(() => tbLog.Text += msg + Environment.NewLine));
        }

        public void appendMessage(string nickname, string msg)
        {
            wb.Invoke((MethodInvoker)(() => builder.appendAuthorMessage(msg, nickname)));
        }
        public void appendServerMessage(string msg)
        {
            wb.Invoke((MethodInvoker)(() => builder.appendServerMessage(msg)));
        }

        public void clearChatTree()
        {
            tvChatTree.Invoke((MethodInvoker)(() => tvChatTree.Nodes.Clear()));
        }
        public void addChatRoom(string roomName, string[] users)
        {
            tvChatTree.Invoke((MethodInvoker)(() =>
            {
                var node = tvChatTree.Nodes.Add(roomName);
                foreach (var user in users)
                {
                    node.Nodes.Add(user);
                }
            }));
        }

        public void expandChatTree()
        {
            tvChatTree.Invoke((MethodInvoker)(() => tvChatTree.ExpandAll()));
        }

    }
}
