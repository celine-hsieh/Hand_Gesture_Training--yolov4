using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Calculation;
using Robot;
using EtherCATSeries;

namespace Gesture_and_Voice_Robot_Controller.View
{
    public partial class Manual_Controller : UserControl
    {
        public Manual_Controller()
        {
            InitializeComponent();
        }
 
        JNT_POS cmdP = new JNT_POS(0,0,0,0,0,0);
        private void PtpMove(object sender, EventArgs e)
        {
            Control PtpCmd = (Control)sender;
            if (PtpCmd.Enabled == false)
                return;

            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            switch (PtpCmd.Name)
            {
                case "BtnXPlus":
                    MainView.myManip.CMDJ1 += USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnXMinus":
                    MainView.myManip.CMDJ1 -= USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnYPlus":
                    MainView.myManip.CMDJ2 += USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnYMinus":
                    MainView.myManip.CMDJ2 -= USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnZPlus":
                    MainView.myManip.CMDJ3 += USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnZMinus":
                    MainView.myManip.CMDJ3 -= USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnRXPlus":
                    MainView.myManip.CMDJ4 += USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnRXMinus":
                    MainView.myManip.CMDJ4 -= USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnRYPlus":
                    MainView.myManip.CMDJ5 += USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnRYMinus":
                    MainView.myManip.CMDJ5 -= USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnRZPlus":
                    MainView.myManip.CMDJ6 += USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "BtnRZMinus":
                    MainView.myManip.CMDJ6 -= USRFXN.DEG2RAD(5);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
            }
        }

        public void Move_to_Home()
        {
            double Q1 = 0;
            double Q2 = 90;
            double Q3 = 0;
            double Q4 = 0;
            double Q5 = -90;
            double Q6 = 0;

            MainView.myManip.CMDJ1 = USRFXN.DEG2RAD(Q1);
            MainView.myManip.CMDJ2 = USRFXN.DEG2RAD(Q2);
            MainView.myManip.CMDJ3 = USRFXN.DEG2RAD(Q3);
            MainView.myManip.CMDJ4 = USRFXN.DEG2RAD(Q4);
            MainView.myManip.CMDJ5 = USRFXN.DEG2RAD(Q5);
            MainView.myManip.CMDJ6 = USRFXN.DEG2RAD(Q6);

            JNT_POS cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                        MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);

            MainView.myManip.PtP(cmdP);
        }
        public void Stop_Robot()
        {
            MainView.myManip.AbortMotion();
        }

        private void XPjog_MouseDown_1(object sender, MouseEventArgs e)
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            MainView.myManip.CMDJ1 += USRFXN.DEG2RAD(50);
            cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            MainView.myManip.PtP(cmdP);
        }

        private void XPjog_MouseUp_1(object sender, MouseEventArgs e)
        {
            MainView.myManip.AbortMotion();
        }

        private void XMjog_MouseDown(object sender, MouseEventArgs e)
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            MainView.myManip.CMDJ1 -= USRFXN.DEG2RAD(50);
            cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            MainView.myManip.PtP(cmdP);
        }

        private void XMjog_MouseUp(object sender, MouseEventArgs e)
        {
            MainView.myManip.AbortMotion();
        }

        private void YPjog_MouseDown(object sender, MouseEventArgs e)
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            MainView.myManip.CMDJ2 += USRFXN.DEG2RAD(50);
            cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            MainView.myManip.PtP(cmdP);
        }

        private void YPjog_MouseUp(object sender, MouseEventArgs e)
        {
            MainView.myManip.AbortMotion();
        }

        private void YMjog_MouseDown(object sender, MouseEventArgs e)
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            MainView.myManip.CMDJ2 -= USRFXN.DEG2RAD(50);
            cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            MainView.myManip.PtP(cmdP);
        }

        private void YMjog_MouseUp(object sender, MouseEventArgs e)
        {
            MainView.myManip.AbortMotion();
        }

        private void ZPjog_MouseDown(object sender, MouseEventArgs e)
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            MainView.myManip.CMDJ3 += USRFXN.DEG2RAD(50);
            cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            MainView.myManip.PtP(cmdP);
        }

        private void ZPjog_MouseUp(object sender, MouseEventArgs e)
        {
            MainView.myManip.AbortMotion();
        }

        private void ZMjog_MouseDown(object sender, MouseEventArgs e)
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;

            MainView.myManip.CMDJ3 -= USRFXN.DEG2RAD(50);
            cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            MainView.myManip.PtP(cmdP);
        }

        private void ZMjog_MouseUp(object sender, MouseEventArgs e)
        {
            MainView.myManip.AbortMotion();
        }

        private void BtnGripper_Click(object sender, EventArgs e)
        {
            Gripper();

        }
        bool GripperStatus = false;
        byte IOcmd = 0x00;
        private void Gripper()
        {
            IOcmd = 0x08;
            if (GripperStatus)
            {
                btnGripper.BackColor = Color.White;
                GripperStatus = false;
                MCCL.MCC_EcatSetOutputEnqueue(6, 0x00, 0);
            }
            else
            {
                btnGripper.BackColor = Color.Khaki;
                GripperStatus = true;
                MCCL.MCC_EcatSetOutputEnqueue(6, IOcmd, 0);
            }
        }
        bool StatusConveyor = false;
        private void Conveyor()
        {
            IOcmd = 0x10;
            if (StatusConveyor)
            {
                btnConveyor.BackColor = Color.White;
                StatusConveyor = false;
                MCCL.MCC_EcatSetOutputEnqueue(6, 0x00, 0);
            }
            else
            {
                btnConveyor.BackColor = Color.Khaki;
                StatusConveyor = true;
                MCCL.MCC_EcatSetOutputEnqueue(6, IOcmd, 0);
            }
        }


        JNT_POS cmdTrajectoryPosition;
        List<JNT_POS> listTrajectory = new List<JNT_POS>();
        private void BtnListTrajectory_Click(object sender, EventArgs e)
        {
            AddTrajectoryToList();
        }
        private void AddTrajectoryToList()
        {
            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;
            cmdTrajectoryPosition = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                       MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
            listTrajectory.Add(cmdTrajectoryPosition);
        }
        private void RunTraj(object sender,EventArgs e)
        {
            Control temp = (Control)sender;
            switch (temp.Name)
            {
                case "btnT1":
                    MainView.myManip.PtP(listTrajectory[0]);
                    break;
                case "btnT2":
                    MainView.myManip.PtP(listTrajectory[1]);
                    break;
                case "btnT3":
                    MainView.myManip.PtP(listTrajectory[2]);
                    break;
                case "btnT4":
                    MainView.myManip.PtP(listTrajectory[3]);
                    break;
            }
        }

        private void BtnConveyor_Click(object sender, EventArgs e)
        {
            Conveyor();
        }
    }
}
