using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EtherCATSeries;
using HandGestureRecognition.SkinDetector;
using System.IO;
using Robot;

namespace Gesture_and_Voice_Robot_Controller.View
{
    public partial class Gesture_and_Voice_Controller : UserControl
    {  
        public Gesture_and_Voice_Controller()
        {
            InitializeComponent();
            timerUpdateLabel.Interval = 30;//0.03秒
            timerUpdateLabel.Start();
        }

        Gesture_Speech_Control_Mode G_S_ControlMode = new Gesture_Speech_Control_Mode();
        private bool simulation = true;//切換上機/模擬
        private void LabelMotionMode_TextChanged(object sender, EventArgs e)
        {
            if (simulation == false)
            {
                G_S_ControlMode.MotionCommand = labelMotionMode.Text;
                G_S_ControlMode.RobotMotion();
            }
        }

        private bool speech_recognizing;//timer用於判斷是否更新語音指令標籤
        private void BtnSpeechRec_Click(object sender, EventArgs e)
        {
            if (speech_recognizing == false)
            {
                SocketSetting.BindAddress("Connect_SpeechRec_Func");
                speech_recognizing = true;
            }
            else 
            {
                SocketSetting.BindAddress("Disconnect_SpeechRec_Func");
                speech_recognizing = false;
            }
        }

        private void TimerUpdateLabel_Tick(object sender, EventArgs e)
        {
            //更新手勢標籤
            labelLeftHand.Text = HandMessageProcessing.Gesture_Left;
            labelRightHand.Text = HandMessageProcessing.Gesture_Right;

            //更新語音標籤
            if (speech_recognizing == true)
            {
                labelSpeech.Text = SocketSetting.speech_server_message;
            }
        }

        private string confirming_command;//儲存當前待確認是否執行之指令
        private string filepath;//儲存腳本路徑
        //語音標籤改變
        private void LabelSpeech_TextChanged(object sender, EventArgs e)
        {
            if(SocketSetting.speech_server_message == "Socket2 Connected")
            {
                //接收到連線確認之訊息無須處理
            }
            else if(SocketSetting.speech_server_message == "確認" || SocketSetting.speech_server_message == "取消")
            {
                TextBox_Guide.Text = "";
                if(SocketSetting.speech_server_message == "確認")
                {
                    labelMotionMode.Text = confirming_command;

                    if (confirming_command == "執行一號腳本"|| confirming_command == "執行二號腳本")
                    {
                        EventRunPath();
                    }

                    confirming_command = "";//清空待確認指令
                }
            }
            else if (SocketSetting.speech_server_message == "暫停")
            {
                //暫停指令無須確認可直接執行
                TextBox_Guide.Text = "暫停";
                confirming_command = SocketSetting.speech_server_message;
                labelMotionMode.Text = confirming_command;
                confirming_command = "";
            }
            else if (SocketSetting.speech_server_message == "執行一號腳本" || SocketSetting.speech_server_message == "執行二號腳本")
            {
                TextBox_Guide.Text = "確認並「" + SocketSetting.speech_server_message + "」?";
                confirming_command = SocketSetting.speech_server_message;//把當前語音內容儲存為待確認指令
                dgv_Path.Rows.Clear();//清空表格
                if(SocketSetting.speech_server_message == "執行一號腳本")
                {
                    filepath = "\\MotionScript\\Script1.txt";
                }
                else
                {
                    filepath = "\\MotionScript\\Script2.txt";
                }
                StreamReader sr = new StreamReader(Environment.CurrentDirectory + filepath);
                String line = sr.ReadToEnd();
                string[] stringLines = line.Split('\n'); //cut line

                for (int num = 0; num < stringLines.Count(); num++)
                {
                    string[] stringwords = stringLines[num].Split(','); //cut line
                    dgv_Path.Rows.Add();
                    dgv_Path.Rows[num].Cells[0].Value = stringwords[0];
                    dgv_Path.Rows[num].Cells[1].Value = stringwords[1];
                    dgv_Path.Rows[num].Cells[2].Value = stringwords[2];
                    dgv_Path.Rows[num].Cells[3].Value = stringwords[3];
                    dgv_Path.Rows[num].Cells[4].Value = stringwords[4];
                    dgv_Path.Rows[num].Cells[5].Value = stringwords[5];
                    dgv_Path.Rows[num].Cells[6].Value = stringwords[6];
                    dgv_Path.Rows[num].Cells[7].Value = stringwords[7];
                }
                sr.Close();
            }
            else
            {
                TextBox_Guide.Text = "確認並執行「" + SocketSetting.speech_server_message + "」?";
                confirming_command = SocketSetting.speech_server_message;//把當前語音內容儲存為待確認指令
            }
        }

        private void Simulation_Switch(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "Simulation")
            {
                simulation = true;
                btnOperation.Enabled = true;
                btnSimulation.Enabled = false;
            }
            else
            {
                simulation = false;
                MCCL.MCC_OverrideSpeed(100, 0);//100%
                btnOperation.Enabled = false;
                btnSimulation.Enabled = true;
            }
        }

        string nowMotion = null;
        private void EventRunPath()
        {
            if (simulation == false)
            {
                for (int cnt = 0; cnt < dgv_Path.RowCount - 1; cnt++)
                {
                    nowMotion = dgv_Path.Rows[cnt].Cells[0].Value.ToString();
                    if (nowMotion == "PtP")
                    {
                        JNT_POS cmdP = new JNT_POS(Convert.ToDouble(dgv_Path.Rows[cnt].Cells[1].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[2].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[3].Value),
                                           Convert.ToDouble(dgv_Path.Rows[cnt].Cells[4].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[5].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[6].Value));
                        MainView.myManip.PtP(cmdP);

                    }
                    else if (nowMotion == "Line")
                    {
                        int ret = MCCL.MCC_Line_V6(Convert.ToDouble(dgv_Path.Rows[cnt].Cells[1].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[2].Value),
                            Convert.ToDouble(dgv_Path.Rows[cnt].Cells[3].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[4].Value),
                            Convert.ToDouble(dgv_Path.Rows[cnt].Cells[5].Value), Convert.ToDouble(dgv_Path.Rows[cnt].Cells[6].Value));
                    }
                    else
                    {
                        MainView.myManip.AbortMotion();
                    }
                    MCCL.MCC_DelayMotion(700, 0);
                    MCCL.MCC_EcatSetOutputEnqueue(6, Convert.ToByte(dgv_Path.Rows[cnt].Cells[7].Value.ToString()), 0);
                }
            }
        }
    }
}
