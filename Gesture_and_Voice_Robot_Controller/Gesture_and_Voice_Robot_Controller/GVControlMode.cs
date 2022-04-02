using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using System.Media;
using Gesture_and_Voice_Robot_Controller.View;
using Calculation;
using Robot;
using EtherCATSeries;

namespace Gesture_and_Voice_Robot_Controller
{
    public class Gesture_Speech_Control_Mode
    {
        public string MotionCommand;

        List<JNT_POS> listTrajectory = new List<JNT_POS>();

        public void RobotMotion()
        {
            JNT_POS cmdP;

            MainView.myManip.GetCurJPOS();
            MainView.myManip.CMDJ1 = MainView.myManip.CURJ1;
            MainView.myManip.CMDJ2 = MainView.myManip.CURJ2;
            MainView.myManip.CMDJ3 = MainView.myManip.CURJ3;
            MainView.myManip.CMDJ4 = MainView.myManip.CURJ4;
            MainView.myManip.CMDJ5 = MainView.myManip.CURJ5;
            MainView.myManip.CMDJ6 = MainView.myManip.CURJ6;
            switch (MotionCommand)
            {
                
                case "下降":
                    MainView.myManip.CMDJ2 -= USRFXN.DEG2RAD(100);
                    //MainView.myManip.CMDJ3 -= USRFXN.DEG2RAD(100);
                    cmdP = new JNT_POS(MainView.myManip.CMDJ1, MainView.myManip.CMDJ2, MainView.myManip.CMDJ3,
                                               MainView.myManip.CMDJ4, MainView.myManip.CMDJ5, MainView.myManip.CMDJ6);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "移動至材料點":
                    MainView.myManip.GetCurCPOS();
                    CARTESIAN_POS mp = new CARTESIAN_POS(MainView.material_point[0], MainView.material_point[1], MainView.material_point[2],
                        0, 0, 0);

                    cmdP = new JNT_POS(0, 0, 0, 0, 0, 0);
                    uint pos = MainView.myManip.CURPOS;
                    MainView.myManip.iKine(ref mp, ref cmdP, pos);
                    MainView.myManip.PtP(cmdP);
                    break;
                case "移動至目的點":

                    MainView.myManip.GetCurCPOS();
                    CARTESIAN_POS mp_d = new CARTESIAN_POS(MainView.des_point[0], MainView.des_point[1], MainView.des_point[2],
                        0, 0, 0);
                    cmdP = new JNT_POS(0,0,0,0,0,0);
                    uint pos_d = MainView.myManip.CURPOS;
                    MainView.myManip.iKine(ref mp_d,ref cmdP,pos_d);
                    
                    MainView.myManip.PtP(cmdP);
                    break;
                case "暫停":
                    MainView.myManip.AbortMotion();
                    break;
                case "夾取":
                    MCCL.MCC_EcatSetOutputEnqueue(6, 0x08, 0);
                    break;
                case "鬆開":
                    MCCL.MCC_EcatSetOutputEnqueue(6, 0x00, 0);
                    break;
                case "開始操作":
                    MainView.myManip.RIO_ServoOn(0);
                    MainView.myManip.RIO_ServoOn(1);
                    MainView.myManip.RIO_ServoOn(2);
                    MainView.myManip.RIO_ServoOn(3);
                    MainView.myManip.RIO_ServoOn(4);
                    MainView.myManip.RIO_ServoOn(5);
                    break;
                case "結束操作":
                    MainView.myManip.RIO_ServoOff(0);
                    MainView.myManip.RIO_ServoOff(1);
                    MainView.myManip.RIO_ServoOff(2);
                    MainView.myManip.RIO_ServoOff(3);
                    MainView.myManip.RIO_ServoOff(4);
                    MainView.myManip.RIO_ServoOff(5);
                    break;
                    

            }
        }
    }
}
