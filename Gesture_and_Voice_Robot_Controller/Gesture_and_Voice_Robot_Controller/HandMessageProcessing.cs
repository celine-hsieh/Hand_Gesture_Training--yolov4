using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Gesture_and_Voice_Robot_Controller
{
    static class HandMessageProcessing
    {
        public static string Number_of_Hand, Which_Hand, Gesture_Left, Gesture_Right;
        public static void MessageProcessing(string server_message)
        {
            try
            {
                //server_message格式為"單手左手手勢零"or"雙手左手手勢零右手手勢零"
                Number_of_Hand = server_message.Substring(0, 2);
                if (Number_of_Hand == "單手")
                {
                    if (server_message.Substring(2, 2) == "左手")
                    {
                        Which_Hand = "左手";
                        Gesture_Left = server_message.Substring(4, 3);
                        Gesture_Right = "-----";
                        if (Gesture_Left == "手勢O")
                        {
                            Gesture_Left = "手勢OK";
                        }
                        else if (Gesture_Left == "手R1")
                        {
                            Gesture_Left = "手勢R1";
                        }
                        else if (Gesture_Left == "手R2")
                        {
                            Gesture_Left = "手勢R2";
                        }
                        else if (Gesture_Left == "手R3")
                        {
                            Gesture_Left = "手勢R3";
                        }
                        else if (Gesture_Left == "手R4")
                        {
                            Gesture_Left = "手勢R4";
                        }
                        else if (Gesture_Left == "手R5")
                        {
                            Gesture_Left = "手勢R5";
                        }
                        else if (Gesture_Left == "手R6")
                        {
                            Gesture_Left = "手勢R6";
                        }
                    }
                    else if (server_message.Substring(2, 2) == "右手")
                    {
                        Which_Hand = "右手";
                        Gesture_Right = server_message.Substring(4, 3);
                        Gesture_Left = "-----";
                        if (Gesture_Right == "手勢O")
                        {
                            Gesture_Right = "手勢OK";
                        }
                        else if (Gesture_Right == "手R1")
                        {
                            Gesture_Right = "手勢R1";
                        }
                        else if (Gesture_Right == "手R2")
                        {
                            Gesture_Right = "手勢R2";
                        }
                        else if (Gesture_Right == "手R3")
                        {
                            Gesture_Right = "手勢R3";
                        }
                        else if (Gesture_Right == "手R4")
                        {
                            Gesture_Right = "手勢R4";
                        }
                        else if (Gesture_Right == "手R5")
                        {
                            Gesture_Right = "手勢R5";
                        }
                        else if (Gesture_Right == "手R6")
                        {
                            Gesture_Right = "手勢R6";
                        }
                    }
                }
                else if (Number_of_Hand == "雙手")
                {
                    Which_Hand = "";
                    Gesture_Left = server_message.Substring(4, 3);
                    Gesture_Right = server_message.Substring(9, 3);
                    //左手
                    if (Gesture_Left == "手勢O")
                    {
                        Gesture_Left = "手勢OK";
                    }
                    else if (Gesture_Left == "手R1")
                    {
                        Gesture_Left = "手勢R1";
                    }
                    else if (Gesture_Left == "手R2")
                    {
                        Gesture_Left = "手勢R2";
                    }
                    else if (Gesture_Left == "手R3")
                    {
                        Gesture_Left = "手勢R3";
                    }
                    else if (Gesture_Left == "手R4")
                    {
                        Gesture_Left = "手勢R4";
                    }
                    else if (Gesture_Left == "手R5")
                    {
                        Gesture_Left = "手勢R5";
                    }
                    else if (Gesture_Left == "手R6")
                    {
                        Gesture_Left = "手勢R6";
                    }
                    //右手
                    if (Gesture_Right == "手勢O")
                    {
                        Gesture_Right = "手勢OK";
                    }
                    else if (Gesture_Right == "手R1")
                    {
                        Gesture_Right = "手勢R1";
                    }
                    else if (Gesture_Right == "手R2")
                    {
                        Gesture_Right = "手勢R2";
                    }
                    else if (Gesture_Right == "手R3")
                    {
                        Gesture_Right = "手勢R3";
                    }
                    else if (Gesture_Right == "手R4")
                    {
                        Gesture_Right = "手勢R4";
                    }
                    else if (Gesture_Right == "手R5")
                    {
                        Gesture_Right = "手勢R5";
                    }
                    else if (Gesture_Right == "手R6")
                    {
                        Gesture_Right = "手勢R6";
                    }
                }
                else if (Number_of_Hand == "無手")
                {
                    Gesture_Left = "-----";
                    Gesture_Right = "-----";
                }
            }
            catch
            {
                
            }
        }
    }
}
