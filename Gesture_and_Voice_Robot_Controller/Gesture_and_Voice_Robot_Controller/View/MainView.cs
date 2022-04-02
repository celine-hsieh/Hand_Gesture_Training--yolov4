using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;                            // Robot Funcs.
using EtherCATSeries;
using Robot;
using Gesture_and_Voice_Robot_Controller.View;
using Calculation;

namespace Gesture_and_Voice_Robot_Controller
{
    public partial class MainView : Form
    {
        public static double[] UAServer_DHvar = new double[5];
        #region Field
        enum MotionType { MTN_3DSIM, MTN_RUNTIME, MTN_UNDEF }; // "3DSIM" / "RUNTIME", Both of them is mutex.
        // ------------------------------------------
        // 宣告 RobotArm as currrent manipulator
        // ------------------------------------------
        public static RobotArm myManip;
        public JNT_POS TMP_CURJ;
        public CARTESIAN_POS TMP_CURC;

        // ------------------------------------------
        // store the file path & name for current manipulator.
        // ------------------------------------------
        string CurInitialDirectory;
        string CurXMLPath;
        string CurJLSPath;
        string CurFBXPath;
        string CurCXXPath;

        // ------------------------------------------
        // 把 XML的資料存在這些變數
        // ------------------------------------------
        DataSet dsPrmsfrmXml;// 機器手臂硬體參數
        DataSet dsPtRcds;    // 空間/點位
        #endregion

        Gesture_and_Voice_Controller Gesture_Controller;
        Manual_Controller Manual_Controller;
        public MainView()
        {
            InitializeComponent();
            // for Dataset
            dsPrmsfrmXml = new System.Data.DataSet();
            dsPtRcds = new System.Data.DataSet();

            Gesture_Controller = new Gesture_and_Voice_Controller();
            Manual_Controller = new Manual_Controller();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            #region Load
            string sRBTXsdPath, sJLSXsdPath, sFileName, sFileNamePath, sInitialDirectory;
            string CurManipName, CurManipType;

            /// <summary>
            /// 載入"機器人參數資料表 articulator.xml"
            /// </summary>
            /// 
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // 取得目前檔案名稱和目錄
                sFileName = openFileDialog1.SafeFileName;
                sFileNamePath = openFileDialog1.FileName;
                sInitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);

                // 更新 saveFileDialog1
                saveFileDialog1.FileName = sFileNamePath;
                saveFileDialog1.InitialDirectory = sInitialDirectory;


                /// <summary>
                /// 首先取得機器人TYPE
                /// </summary>
                /// 
                CurInitialDirectory = sInitialDirectory;
                CurXMLPath = sFileNamePath;
                CurManipType = sFileName.Substring(0, 2);
                CurManipName = sFileName.Substring("**_".Length, (sFileName.Length - "**_.xml".Length));

                // default
                sJLSXsdPath = sInitialDirectory + "\\Jls.xsd";          // 取得 JLS's xsd
                sRBTXsdPath = sInitialDirectory + "\\Articulator.xsd";  // 取得 XML's xsd


                if (CurManipType == "AR")
                {
                    myManip = new Articulator(CurManipType, CurManipName);  // initialize the current manipulator.

                    sRBTXsdPath = sInitialDirectory + "\\Articulator.xsd";  // 取得對應的xsd檔
                    CurJLSPath = CurXMLPath.Replace(".xml", "_JLS.xml");
                    CurFBXPath = CurXMLPath.Replace(".xml", ".fbx");        // 取得FBX的路徑檔
                }
                //else if (CurManipulator == "SC")
                //{ 
                //    myManip = new Scara(CurManipulator);
                //}
                //else if (CurManipulator == "DE")
                //{ 
                //    myManip = new Delta(CurManipulator);
                //}


                /// <summary>
                /// 載入"機器人系統參數 *.xml"並儲存到 "dsPrmsfrmXml"
                /// </summary>
                /// 
                try
                {
                    dsPrmsfrmXml.ReadXmlSchema(sRBTXsdPath);
                    dsPrmsfrmXml.ReadXml(CurXMLPath);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    //this.Close();
                }

                /// <summary>
                /// 載入"教導點資料表 jls.xml"並儲存至 "dsPtRcds"
                /// </summary>
                try
                {
                    dsPtRcds.ReadXmlSchema(sJLSXsdPath);
                    dsPtRcds.ReadXml(CurJLSPath);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    //this.Close();
                }

                /// <summary>
                /// 載入 "機構參數，TOOL參數，軸卡參數，輸出入點位資訊" 至機器人
                /// </summary>
                /// 
                UAServer_DHvar = myManip.ReadSYSParms(dsPrmsfrmXml);
                myManip.ReadJHome(dsPtRcds);
                myManip.SetupCard(MCCL.IMP_II_8_AXIS_PCI_CARD);

                // 設置 RUNTIME 旗標
                myManip.RUNTYPE = (int)MotionType.MTN_UNDEF;



                // show information in SysInfLog
                Trace.WriteLine("Load System File Success: " + CurXMLPath);
                Trace.WriteLine("Load Joint List File Success: " + CurJLSPath);
            }
            #endregion
        }

        private void BtnInitial_Click(object sender, EventArgs e)
        {
            #region Initial

            Process.Start(@"C:\Users\User\Desktop\EMP_Robot_20190522\Robot\test\SimpleRobot\EcServer.rtss");
            Thread.Sleep(2000);


            // 設置 RUNTIME 旗標
            myManip.RUNTYPE = (int)MotionType.MTN_RUNTIME;

            //初始化系統
            string statInitSys = myManip.Init_SYS("RUNTIME", 0);
            MCCL.MCC_EnableBlend(0);
            //string statInitSys = myManip.Init_SYS("3DSIM", 0); //sim mode for debug

            Trace.WriteLine(statInitSys);

            //取得絕對編碼器值
            JNT_POS AbsPos = new JNT_POS();
            myManip.ReadFrm_ABSEnc(ref AbsPos);

            //定義座標位置
            myManip.DefinePOS(AbsPos);
            Thread.Sleep(10);// 10ms
            #endregion
        }

        private void BtnServoOn_Click(object sender, EventArgs e)
        {
            myManip.RIO_ServoOn(0);
            myManip.RIO_ServoOn(1);
            myManip.RIO_ServoOn(2);
            myManip.RIO_ServoOn(3);
            myManip.RIO_ServoOn(4);
            myManip.RIO_ServoOn(5);
        }

        private void BtnServoOff_Click(object sender, EventArgs e)
        {
            myManip.RIO_ServoOff(0);
            myManip.RIO_ServoOff(1);
            myManip.RIO_ServoOff(2);
            myManip.RIO_ServoOff(3);
            myManip.RIO_ServoOff(4);
            myManip.RIO_ServoOff(5);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MainPnl.Controls.Clear();
            MainPnl.Controls.Add(Manual_Controller);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MainPnl.Controls.Clear();
            MainPnl.Controls.Add(Gesture_Controller);
        }


        public void Move_to_Home()
        {
            double Q1 = 0;
            double Q2 = 90;
            double Q3 = 0;
            double Q4 = 0;
            double Q5 = -90;
            double Q6 = 0;
            
            myManip.CMDJ1 = USRFXN.DEG2RAD(Q1);
            myManip.CMDJ2 = USRFXN.DEG2RAD(Q2);
            myManip.CMDJ3 = USRFXN.DEG2RAD(Q3);
            myManip.CMDJ4 = USRFXN.DEG2RAD(Q4);
            myManip.CMDJ5 = USRFXN.DEG2RAD(Q5);
            myManip.CMDJ6 = USRFXN.DEG2RAD(Q6);

            JNT_POS cmdP = new JNT_POS(myManip.CMDJ1, myManip.CMDJ2, myManip.CMDJ3,
                                        myManip.CMDJ4, myManip.CMDJ5, myManip.CMDJ6);

            myManip.PtP(cmdP);
        }
        public static double[] material_point = new double[] { 10, 10, 0 };
        public static double[] des_point = new double[] { 20, 20, 0 };
        
        private void Button_Home_Click(object sender, EventArgs e)
        {
            Move_to_Home();
        }

        private void Button_Stop_Click(object sender, EventArgs e)
        {
            myManip.AbortMotion();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form change_form = new PointSettingForm(ref material_point,ref des_point);
            change_form.ShowDialog(this);
        }
    }
}
