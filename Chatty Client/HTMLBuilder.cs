using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;

namespace Chatty_Client
{
    /// <summary>
    /// Klasa zajmująca się wyświetlaniem czatu w kontrolce WebBrowser.
    /// 
    /// </summary>
    class HTMLBuilder
    {
        private WebBrowser browser;
        /// <summary>
        /// CSS
        /// </summary>
        private string style = "<style>\n" +
        "    .nick{\n" +
        "        margin-bottom: 0;\n" +
        "        color: rgb(59,89,152);\n" +
        "        font-size: x-small;\n" +
        "    }    \n" +
        "    .date{\n" +
        "        margin-bottom: 0;\n" +
        "        margin-top: 0;\n" +
        "        margin-left: 20px;\n" +
        "\n" +
        "        color: rgb(175,180,189);\n" +
        "        font-size: xx-small;\n" +
        "    }    \n" +
        "    .msg{\n" +
        "        margin-bottom: 0;\n" +
        "        margin-top: 4px;\n" +
        "        margin-left: 20px;\n" +
        "        color: darkslategray;\n" +
        "        font-size: medium;\n" +
        "    }\n" +
        "    .servMsg{\n"+
        //"        font-variant: small-caps;\n"+
        "        font-weight: bold;\n"+
        "        margin-bottom: 0;\n"+
        "        margin-top: 5px;\n"+
        "        margin-left: 0;\n"+
        "        color: rgb(59,89,152);\n"+
        "        font-size: small;\n"+
        "    }" +
        "    </style>";

        /// <summary>
        /// JavaScript
        /// </summary>
        private string script = "        function appendMsg (msg, date){\n" +
        "            var d = document.createElement(\"div\");\n" +
        "            var p1 = document.createElement(\"p\");\n" +
        "            var p2 = document.createElement(\"p2\");\n" +
        "\n" +
        "            p1.className = \"msg\";\n" +
        "            p2.className = \"date\";\n" +
        "            p1.innerHTML = msg;\n" +
        "            p2.innerHTML = date;\n" +
        "            d.appendChild(p1);\n" +
        "            d.appendChild(p2);\n" +
        "            document.body.appendChild(d);\n" +
        "            scrollBottom();\n" +
        "        }\n" +
        "        function appendAuthor(author, msg, date){\n" +
        "            var d = document.createElement(\"div\");\n" +
        "            var p1 = document.createElement(\"p\");\n" +
        "            var p2 = document.createElement(\"p2\");\n" +
        "            var p3 = document.createElement(\"p3\");\n" +
        "\n" +
        "            p1.className = \"msg\";\n" +
        "            p2.className = \"date\";\n" +
        "            p3.className = \"nick\";\n" +
        "            p3.innerHTML = author + \" napisał:\";\n" +
        "            p1.innerHTML = msg;\n" +
        "            p2.innerHTML = date;\n" +
        "            d.appendChild(p3);\n" +
        "            d.appendChild(p1);\n" +
        "            d.appendChild(p2);\n" +
        "            document.body.appendChild(d);\n" +
        "            scrollBottom();\n" +
        "        }\n" +
        "        function appendServer (msg){\n" +
        "            var d = document.createElement(\"div\");\n" +
        "            var p1 = document.createElement(\"p\");\n" +
        "            p1.className = \"servMsg\";\n" +
        "            p1.innerHTML = msg;\n" +
        "            d.appendChild(p1);\n" +
        "            document.body.appendChild(d);\n" +
        "            scrollBottom();\n" +
        "        }\n" +
        "        function scrollBottom(){\n" +
        "            window.scroll(0,document.body.scrollHeight);\n" +
        "        }";
        private string lastUsername = "";
        private bool scriptLoaded = false;
        public HTMLBuilder(WebBrowser wb)
        {
            browser = wb;
            
            //browser.DocumentText = "<div></div>";
            browser.DocumentText = style;
            
            //browser.Navigate("javascript:var s = function() { window.scrollBy(0,100); setTimeout(s, 100); }; s();");
        }
        private void loadScript()
        {
            HtmlElement head = browser.Document.GetElementsByTagName("head")[0];
            HtmlElement scriptEl = browser.Document.CreateElement("script");
            IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
            element.text = script;
            head.AppendChild(scriptEl);
            
        }

        /// <summary>
        /// Wyświetla wiadomość od użytkownika w kontrolce WebBrowser,
        /// przez wywołanie funkcji załadowanego wcześniej skryptu JavaScript.
        /// Dzięki temu mogę automatycznie przewijać ekran przeglądarki na sam dół, 
        /// na co nie pozwalało dodawanie metodą Document.Body.AppendChild(), z powodu
        /// jej asynchroniczności (nie można było przewijać zaraz po wykonaniu tej metody,
        /// gdyż elementy dopiero po jakimś czasie się dodawały do drzewa DOM, automatycznie 
        /// przewijając ekran przeglądarki do góry).
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="nick"></param>
        public void appendAuthorMessage(string msg, string nick)
        {
            if (!scriptLoaded)
            {
                loadScript();
                scriptLoaded = true;
            }

            msg = System.Security.SecurityElement.Escape(msg);
            string time = DateTime.Now.ToString("h:mm:ss tt");
            if (nick == lastUsername)
            {
                string[] args = { msg, time };
                browser.Document.InvokeScript("appendMsg", args);
                //html = "<p class='msg'>" + msg + "</p>"
                //          + "<p class='date'>" + time + "</p>";
            }
            else
            {
                string[] args = { nick, msg, time };
                browser.Document.InvokeScript("appendAuthor", args);
                //html = "<p class='nick'>" + nick + " napisał:</p>"
                //          + "<p class='msg'>" + msg + "</p>"
                //          + "<p class='date'>" + time + "</p>";
                lastUsername = nick;
            }
            //HtmlElement div = browser.Document.CreateElement("div");
            //div.InnerHtml = html;
            //browser.Document.Body.AppendChild(div);
            //browser.Document.Window.ScrollTo(0, int.MaxValue);
            //browser.AutoScrollOffset = new Point(0, browser.Height);
            

        }

        public void appendServerMessage(string msg)
        {
            if (!scriptLoaded)
            {
                loadScript();
                scriptLoaded = true;
            }
            //HtmlElement div = browser.Document.CreateElement("div");
            //div.InnerHtml = "<p class='servMsg'>" + msg + "</p>";

            //browser.Document.Body.AppendChild(div);
            //browser.Document.Window.ScrollTo(0, int.MaxValue);
            //browser.AutoScrollOffset = new Point(0, browser.Height);
            string[] arr = {msg};
            browser.Document.InvokeScript("appendServer", arr);
        }
    }
}
