using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SpeechRecTest
{
    class SocketServer
    {
        private static byte[] result = new byte[1024];
        private static string host = "192.168.50.106";//wifi6 設定網路IP

        //private static string host = "192.168.50.145";//wifi6
        //private static string host = "192.168.66.8";
        private static int port = 0001; //設定連接阜
        static Socket serverSocket, clientSocket; 

        //建立server並持續監聽
        public static void BindAddress()
        {    
            //建立server
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //定義server的IP
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(host), port));
            //server開始監聽,且server最大連線數量是3
            serverSocket.Listen(3);
            Console.WriteLine("啟動監聽{0}成功", serverSocket.LocalEndPoint.ToString());
            //接受clientsocket連線
            clientSocket = serverSocket.Accept();
            clientSocket.Send(Encoding.UTF8.GetBytes("Socket2 Connected"));            
        }
        public static void SendResults()
        {
            clientSocket.Send(Encoding.UTF8.GetBytes(Form1.ServerMessage));
        }

    }
}
