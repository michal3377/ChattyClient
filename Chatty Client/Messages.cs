using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatty_Client
{
    /// <summary>
    /// Parsuje polecenia i zwraca je w odpowiedniej formie.
    /// </summary>
    public class ServerMessageParser
    {
        public class Room
        {
            public string name { get; set; }
            public string[] members { get; set; }
        }

        #region =====SPECIAL CHARS=====
        /// <summary>
        /// Znaki specjalne, potrzebne do parsowania wiadomosci. 
        /// Musza byc takie same jak na serwerze. Dla bezpieczenstwa mozna je zamienic
        /// na jakies dziwne znaki z Unicode.
        /// </summary>
        public static readonly char MESSAGE_END = '~';
        public static readonly char STRING_SEPARATOR = '|';
        public static readonly char ROOM_SEPARATOR = '}';
        public static readonly char USER_SEPARATOR = '{';
        #endregion

        public string[] parseCommands(string msg)
        {
            msg = msg.Remove(msg.Length - 1);
            return msg.Split(MESSAGE_END);
        }

        public string getMsgType(string msg)
        {
            return msg.Split(STRING_SEPARATOR)[0];
        }

        public string[] parseUserList(string msg)
        {
            return msg.Split(STRING_SEPARATOR).Skip(1).ToArray();
        }
        public string[] parseRoomList(string msg)
        {
            return msg.Split(STRING_SEPARATOR).Skip(1).ToArray();
        }
        public List<Room> parseChatTree(string msg)
        {
            List<Room> rooms = new List<Room>();
            var roomMsg = msg.Split(STRING_SEPARATOR)[1];
            var roomsArr = roomMsg.Split(ROOM_SEPARATOR);

            foreach (var roomStr in roomsArr)
            {
                var room = new Room();
                var roomUsers = roomStr.Split(USER_SEPARATOR);
                room.name = roomUsers[0];
                room.members = roomUsers.Skip(1).ToArray();
                rooms.Add(room);
            }
            return rooms;
            //return msg.Split(STRING_SEPARATOR).Skip(1).ToArray();
        }

        public string parseServerMsg(string msg)
        {
            return msg.Split(STRING_SEPARATOR)[1];
        }

        public string[] parseAuthorMsg(string msg)
        {
            return msg.Split(STRING_SEPARATOR).Skip(1).ToArray();
        }
    }

    /// <summary>
    /// Tworzy tekstowe polecenia, które są później parsowane i interpretowane po stronie serwera.
    /// </summary>
    public class ClientMessageGenerator
    {
        public readonly char STRING_SEPARATOR = '|';

        public string generateLoginMsg(string username)
        {
            string output = "login" + STRING_SEPARATOR + username;
            return output;
        }
        public string generateJoinRoomMsg(string name)
        {
            string output = "join" + STRING_SEPARATOR + name;
            return output;
        }
        public string generateRoomMsg(string msg)
        {
            string output = "roomMsg" + STRING_SEPARATOR + msg;
            return output;
        }
        public string generateCreateRoomMsg(string roomName)
        {
            string output = "createRoom" + STRING_SEPARATOR + roomName;
            return output;
        }
    }
}
