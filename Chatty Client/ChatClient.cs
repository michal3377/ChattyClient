using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chatty_Client
{
    public delegate void ChatClientCallback(string msg);

    /// <summary>
    /// Główna klasa klienta czatu. Odbiera i interpretuje polecenia, wysyła wiadomości.
    /// </summary>
    class ChatClient
    {
        private ServerMessageParser parser = new ServerMessageParser();
        private ClientMessageGenerator generator = new ClientMessageGenerator();
        private ChatClientCallback onDisconnectCallback;
        private UIAgent ui;
        private int port;
        private Socket clientSocket;
        byte[] receivedBuf = new byte[1024];

        public ChatClient(UIAgent agent, ChatClientCallback onDisconnectCallback)
        {
            ui = agent;
            this.onDisconnectCallback = onDisconnectCallback;
        }


        public void connect(string ip, int port, string username)
        {
            try
            {
                this.port = port;
                var address = IPAddress.Parse(ip);
                clientSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                loopConnect(address);
                clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(receiveData), clientSocket);
                var msg = generator.generateLoginMsg(username);
                sendMessage(msg);
            }
            catch (FormatException)
            {
                onDisconnectCallback("Podano nieprawidłową kombinację IP:Port");

            }
            catch (SocketException)
            {
                onDisconnectCallback("Nie można połączyć się z serwerem.");
            }
            catch (Exception)
            {
                onDisconnectCallback("Błąd");
            }
            
        }

        public void disconnect()
        {
            clientSocket.Close();
            receivedBuf = new byte[1024];

            onDisconnectCallback("Rozłączono z serwerem!");
        }

        private void receiveData(IAsyncResult ar)
        {
            try
            {
                Socket socket = (Socket)ar.AsyncState;
                int received = socket.EndReceive(ar);
                byte[] dataBuf = new byte[received];
                Array.Copy(receivedBuf, dataBuf, received);
                string data = Encoding.UTF8.GetString(dataBuf);
                //ui.log(data);
                handleMessage(data);
                clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(receiveData), clientSocket);
            }
            catch (Exception)
            {
                disconnect();
            }

        }


        private void handleMessage(string command)
        {
            //ui.log("COM: >" + command + "<");
            string[] commands = parser.parseCommands(command);

            foreach (var msg in commands)
            {
                switch (parser.getMsgType(msg))
                {
                    //case "userList":
                    //    var t = parser.parseUserList(msg);
                    //    ui.clearUsers();
                    //    foreach (var user in t)
                    //    {
                    //        ui.addUser(user);
                    //    }
                    //    break;

                    //case "roomList":
                    //    var roomss = parser.parseRoomList(msg);
                    //    ui.clearRooms();
                    //    foreach (var r in roomss)
                    //    {
                    //        ui.addRoom(r);
                    //    }
                    //    break;
                    case "msgAuthor":
                        var ms = parser.parseAuthorMsg(msg);
                        ui.appendMessage(ms[0], ms[1]);
                        ui.log(ms[1]);
                        break;
                    case "msgServer":
                        var mss = parser.parseServerMsg(msg);
                        ui.appendServerMessage(mss);
                        ui.log(mss);
                        break;

                    case "chatTree":
                        var rooms = parser.parseChatTree(msg);
                        ui.clearChatTree();
                        foreach (var room in rooms)
                        {
                            ui.addChatRoom(room.name, room.members);
                        }
                        ui.expandChatTree();
                        break;

                    default:
                        ui.appendServerMessage("Received unsupported command!");

                        break;
                }
            }

        }

        private void loopConnect(IPAddress address)
        {
            int attempts = 0;
            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    clientSocket.Connect(address, port);
                }
                catch (SocketException)
                {
                    ui.appendServerMessage("Próby łączenia: " + attempts.ToString());
                }
            }
            ui.appendServerMessage("Połączono!");
        }

        public void sendMessage(string msg)
        {
            if (clientSocket.Connected)
            {

                byte[] buffer = Encoding.UTF8.GetBytes(msg);
                clientSocket.Send(buffer);
            }
        }

        public void sendRoomMessage(string msg)
        {
            var str = generator.generateRoomMsg(msg);
            sendMessage(str);
        }

        public void joinChatRoom(string name)
        {
            sendMessage(generator.generateJoinRoomMsg(name));
        }

        public void createChatRoom(string name)
        {
            sendMessage(generator.generateCreateRoomMsg(name));
        }


    }
}
