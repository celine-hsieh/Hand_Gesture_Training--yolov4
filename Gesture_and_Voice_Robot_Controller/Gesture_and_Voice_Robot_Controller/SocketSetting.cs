using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using EtherCATSeries;
using Robot;

namespace Gesture_and_Voice_Robot_Controller
{
    public static class SocketSetting
    {
        static string host = "192.168.50.106";//wifi6
        //private static string host = "192.168.50.145";//wifi6
        //private static string host = "192.168.66.8";
        static int port_speech = 0001;//For語音辨識
        static int port_gesture = 0002;//For手勢辨識
        static Thread thread1, thread2;
        //構建SOCKET實例，並連接指定的服務端
        static Socket client_speech = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static Socket client_gesture = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public static string gesture_server_message, gesture_client_message, speech_server_message, speech_client_message;
        private static bool gesture_socket_already_exist, speech_socket_already_exist;

        public static void BindAddress(string client_name)
        {
            if (client_name == "Connect_HGRec_Func")//使用者按下 開啟 手勢辨識按鈕
            {
                if(gesture_socket_already_exist == false)//未建立過連線
                {
                    gesture_socket_already_exist = true;
                    client_speech.Connect(new IPEndPoint(IPAddress.Parse(host), port_gesture));
                    thread1 = new Thread(ConnectToSocketServer_HGRec);

                    thread1.Start();
                }
                else//已建立過連線
                {
                    thread1 = new Thread(ConnectToSocketServer_HGRec);
                    thread1.Start();                   
                }         
            }
            else if (client_name == "Disconnect_HGRec_Func")//使用者按下 關閉 手勢辨識按鈕
            {
                thread1.Abort();//結束手勢指令處理之執行緒
            }
            else if (client_name == "Connect_SpeechRec_Func")//使用者按下 開啟 語音辨識按鈕
            {
                if (speech_socket_already_exist == false)//未建立過連線
                {
                    speech_socket_already_exist = true;
                    client_gesture.Connect(new IPEndPoint(IPAddress.Parse(host), port_speech));
                    thread2 = new Thread(ConnectToSocketServer_SpeechRec);
                    thread2.Start();
                }
                else//已建立過連線
                {
                    thread2 = new Thread(ConnectToSocketServer_SpeechRec);
                    thread2.Start();
                }
            }
            else if (client_name == "Disconnect_SpeechRec_Func")//使用者按下 關閉 語音辨識按鈕
            {
                thread2.Abort();//結束語音指令處理之執行緒
            }
        }
        static bool first_time = true;
        private static void ConnectToSocketServer_HGRec()
        {
            var bytes = new byte[1024];
            while (true)
            {
                var count = client_speech.Receive(bytes);
                gesture_server_message = Encoding.UTF8.GetString(bytes, 0, count);
                Console.WriteLine(gesture_server_message);
                if (first_time == true)
                {
                    gesture_client_message = "使用者欲辨識手勢";
                    client_speech.Send(Encoding.UTF8.GetBytes(gesture_client_message));
                    first_time = false;
                }
            }
        }
        private static void ConnectToSocketServer_SpeechRec()
        {
            while (true)
            {
                var bytes = new byte[1024];
                var count = client_gesture.Receive(bytes);
                speech_server_message = Encoding.UTF8.GetString(bytes, 0, count);
                Console.WriteLine(speech_server_message);
            }
        }
    }
}
