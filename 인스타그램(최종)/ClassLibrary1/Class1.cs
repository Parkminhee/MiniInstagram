using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary1
{
    public enum PacketType
    {
        회원가입 = 0,
        로그인,
        계정검색,
        게시물업로드,
        프로필정보,
        바둑판,
        리스트
    }

    [Serializable]
    public class Packet
    {
        public int Type;

        public Packet()
        {
            Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Deserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            foreach (byte b in bt)
            {
                ms.WriteByte(b);
            }

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();
            return obj;
        }
    }

    [Serializable]
    public class Join : Packet
    {
        public string id;
        public string pw;
        public string chk;

        public Join()
        {
            id = null;
            pw = null;
            chk = null;
        }
    }

    [Serializable]
    public class Login : Packet
    {
        public string id;
        public string pw;
        public string chk;

        public Login()
        {
            id = null;
            pw = null;
            chk = null;
        }
    }

    [Serializable]
    public class Search : Packet
    {
        public string id;
        public int count;

        public Search()
        {
            id = null;
            count = 0;
        }
    }

    [Serializable]
    public class Upload : Packet
    {
        public string id;
        public string ext;
        public int size;
        public int sendCount;
        public string txt;

        public Upload()
        {
            id = null;
            ext = null;
            size = 0;
            sendCount = 0;
            txt = null;
        }
    }

    [Serializable]
    public class Profile : Packet
    {
        public string id;
        public int count;

        public Profile()
        {
            id = null;
            count = 0;
        }
    }

    [Serializable]
    public class TileType : Packet
    {
        public string id;
        public string ext;
        public int size;
        public int postCount;
        public int sendCount;

        public TileType()
        {
            id = null;
            ext = null;
            size = 0;
            postCount = 0;
            sendCount = 0;
        }
    }

    [Serializable]
    public class ListType : Packet
    {
        public string id;
        public string ext;
        public int size;
        public int postCount;
        public int sendCount;
        public string txt;

        public ListType()
        {
            id = null;
            ext = null;
            size = 0;
            postCount = 0;
            sendCount = 0;
            txt = null;
        }
    }
}
