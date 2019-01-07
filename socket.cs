using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cocaro
{
    class SocketManager
    {
        #region Client
        Socket client;
        public bool ConnectServer()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(ipe);
                return true;
            }
            catch { return false; };
           
        }
        #endregion
        #region Server
        Socket server;
        public void CreateServer()
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(ipe);
            //doi ket noi
            server.Listen(10);
            Thread acceeptClient = new Thread(() =>
              {
                  client = server.Accept();
              });
            acceeptClient.IsBackground = true;
            acceeptClient.Start();
        }
        
        #endregion
        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 9999;
        public const int BUFFER=1024;
        public bool Isserver = true;
        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
            
                //client
             return Senddata(client, sendData);
           
        }
        public object Receive()
        {
            byte[] receiceData = new byte[BUFFER];
            bool isok = Receivedata(client,receiceData);
            return DeserializeData(receiceData);
        }
        private bool Senddata(Socket target,byte[] data)
        {
            return target.Send(data) == 1 ? true : false;
        }
        private bool Receivedata(Socket target,byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        //phan tich thah mang byte
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
       
        //tu byte phan tich nguoc lai
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }


        public string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }
        #endregion
    }
}
