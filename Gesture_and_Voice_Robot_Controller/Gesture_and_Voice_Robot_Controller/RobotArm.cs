using System;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading;
using Calculation;

namespace Robot
{
    using EtherCATSeries;

    /// <summary>
    /// 定義抽象類別，以利實作多種型別的機器人
    /// </summary>
    /// 
    public abstract class RobotArm : INotifyPropertyChanged
    {
        #region Fields

        public string TYPE;
        public string NAME;
        public int SYN_AXIS;

        public JNT_POS JHOME;
        public JNT_POS ABSENC_OFFSET;
        public uint CURPOS;

        public DH_PARAM DHPARM;
        public Euler_PARAM TLPARM;
        public SYS_MAC_PARAM[] MACPARM;
        public SYS_ENCODER_CONFIG[] ENCCFG;
        public SYS_CARD_CONFIG CARDCFG;

        private int _RunType;
        private double _FeedSpeed, _PtPSpeed;

        // 系統資訊
        protected double SysMaxSpd;
        protected ushort uGroupIndex;

        // 運動控制回饋資訊
        protected double _CURJ1, _CURJ2, _CURJ3, _CURJ4, _CURJ5, _CURJ6;
        protected double _CURX, _CURY, _CURZ, _CURQX, _CURQY, _CURQZ;

        // 運動控制命令
        protected double _CMDJ1, _CMDJ2, _CMDJ3, _CMDJ4, _CMDJ5, _CMDJ6;
        protected double _CMDX, _CMDY, _CMDZ, _CMDQX, _CMDQY, _CMDQZ;

        #endregion

        #region Property

        /// <summary>
        /// Declare the event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        /// <summary>
        /// 運動控制回饋資訊
        /// </summary>
        /// 
        public double CURJ1
        {
            get
            {
                return _CURJ1;
            }
            set
            {
                _CURJ1 = value;
                NotifyPropertyChanged("CURJ1");
            }
        }

        public double CURJ2
        {
            get
            {
                return _CURJ2;
            }
            set
            {
                _CURJ2 = value;
                NotifyPropertyChanged("CURJ2");
            }
        }

        public double CURJ3
        {
            get
            {
                return _CURJ3;
            }
            set
            {
                _CURJ3 = value;
                NotifyPropertyChanged("CURJ3");
            }
        }

        public double CURJ4
        {
            get
            {
                return _CURJ4;
            }
            set
            {
                _CURJ4 = value;
                NotifyPropertyChanged("CURJ4");
            }
        }

        public double CURJ5
        {
            get
            {
                return _CURJ5;
            }
            set
            {
                _CURJ5 = value;
                NotifyPropertyChanged("CURJ5");
            }
        }

        public double CURJ6
        {
            get
            {
                return _CURJ6;
            }
            set
            {
                _CURJ6 = value;
                NotifyPropertyChanged("CURJ6");
            }
        }

        public double CURX
        {
            get
            {
                return _CURX;
            }
            set
            {
                _CURX = value;
                NotifyPropertyChanged("CURX");
            }
        }

        public double CURY
        {
            get
            {
                return _CURY;
            }
            set
            {
                _CURY = value;
                NotifyPropertyChanged("CURY");
            }
        }

        public double CURZ
        {
            get
            {
                return _CURZ;
            }
            set
            {
                _CURZ = value;
                NotifyPropertyChanged("CURZ");
            }
        }

        public double CURQX
        {
            get
            {
                return _CURQX;
            }
            set
            {
                _CURQX = value;
                NotifyPropertyChanged("CURQX");
            }
        }

        public double CURQY
        {
            get
            {
                return _CURQY;
            }
            set
            {
                _CURQY = value;
                NotifyPropertyChanged("CURQY");
            }
        }

        public double CURQZ
        {
            get
            {
                return _CURQZ;
            }
            set
            {
                _CURQZ = value;
                NotifyPropertyChanged("CURQZ");
            }
        }

        /// <summary>
        /// 運動控制命令
        /// </summary>
        /// 
        public double CMDJ1
        {
            get
            {
                return _CMDJ1;
            }
            set
            {
                _CMDJ1 = value;
                NotifyPropertyChanged("CMDJ1");
            }
        }

        public double CMDJ2
        {
            get
            {
                return _CMDJ2;
            }
            set
            {
                _CMDJ2 = value;
                NotifyPropertyChanged("CMDJ2");
            }
        }

        public double CMDJ3
        {
            get
            {
                return _CMDJ3;
            }
            set
            {
                _CMDJ3 = value;
                NotifyPropertyChanged("CMDJ3");
            }
        }

        public double CMDJ4
        {
            get
            {
                return _CMDJ4;
            }
            set
            {
                _CMDJ4 = value;
                NotifyPropertyChanged("CMDJ4");
            }
        }

        public double CMDJ5
        {
            get
            {
                return _CMDJ5;
            }
            set
            {
                _CMDJ5 = value;
                NotifyPropertyChanged("CMDJ5");
            }
        }

        public double CMDJ6
        {
            get
            {
                return _CMDJ6;
            }
            set
            {
                _CMDJ6 = value;
                NotifyPropertyChanged("CMDJ6");
            }
        }

        public double CMDX
        {
            get
            {
                return _CMDX;
            }
            set
            {
                _CMDX = value;
                NotifyPropertyChanged("CMDX");
            }
        }

        public double CMDY
        {
            get
            {
                return _CMDY;
            }
            set
            {
                _CMDY = value;
                NotifyPropertyChanged("CMDY");
            }
        }

        public double CMDZ
        {
            get
            {
                return _CMDZ;
            }
            set
            {
                _CMDZ = value;
                NotifyPropertyChanged("CMDZ");
            }
        }

        public double CMDQX
        {
            get
            {
                return _CMDQX;
            }
            set
            {
                _CMDQX = value;
                NotifyPropertyChanged("CMDQX");
            }
        }

        public double CMDQY
        {
            get
            {
                return _CMDQY;
            }
            set
            {
                _CMDQY = value;
                NotifyPropertyChanged("CMDQY");
            }
        }

        public double CMDQZ
        {
            get
            {
                return _CMDQZ;
            }
            set
            {
                _CMDQZ = value;
                NotifyPropertyChanged("CMDQZ");
            }
        }

        /// <summary>
        /// 實作部分的方法，其餘抽象的部分再交由延伸類別實作。
        /// </summary>
        /// 
        public RobotArm()
        {
        }

        public int RUNTYPE
        {
            get
            {
                return _RunType;
            }
            set
            {
                _RunType = value;
            }
        }

        public double FeedSpeed
        {
            get
            {
                _FeedSpeed = MCCL.MCC_GetFeedSpeed(uGroupIndex);
                return _FeedSpeed;
            }
            set
            {
                if (value > 0 && value <= SysMaxSpd)
                {
                    _FeedSpeed = value;
                    MCCL.MCC_SetFeedSpeed(_FeedSpeed, uGroupIndex);
                }

                NotifyPropertyChanged("FeedSpeed");
            }
        }

        public double PtPSpeed
        {
            get
            {
                _PtPSpeed = MCCL.MCC_GetPtPSpeed(uGroupIndex);
                return _PtPSpeed;
            }
            set
            {
                if (value > 0 && value <= 100)
                {
                    _PtPSpeed = value;
                    MCCL.MCC_SetPtPSpeed(_PtPSpeed, uGroupIndex);
                }

                NotifyPropertyChanged("PtPSpeed");
            }
        }

        // "機構參數，TOOL參數，軸卡參數，輸出入點位資訊"
        public double[] ReadSYSParms(DataSet ds)
        {
            // set DH Params with values
            DHPARM.a1 = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][0]);
            DHPARM.a2 = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][1]);
            DHPARM.a3 = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][2]);
            DHPARM.d3 = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][3]);
            DHPARM.d4 = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][4]);
            DHPARM.d6 = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][5]);
            DHPARM.z_offset = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][6]);

            // set DH coupling of Aexs
            DHPARM.J4J5_Coupling = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][7]);
            DHPARM.J5J6_Coupling = Convert.ToDouble(ds.Tables["DH_SETUP"].Rows[0][8]);

            // set TOOL Params with values
            TLPARM.lx = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][0]);
            TLPARM.ly = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][1]);
            TLPARM.lz = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][2]);
            TLPARM.rx = USRFXN.DEG2RAD(Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][3]));
            TLPARM.ry = USRFXN.DEG2RAD(Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][4]));
            TLPARM.rz = USRFXN.DEG2RAD(Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][5]));

            // set AbsEnc Offset
            ABSENC_OFFSET.J1 = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][6]);
            ABSENC_OFFSET.J2 = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][7]);
            ABSENC_OFFSET.J3 = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][8]);
            ABSENC_OFFSET.J4 = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][9]);
            ABSENC_OFFSET.J5 = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][10]);
            ABSENC_OFFSET.J6 = Convert.ToDouble(ds.Tables["TOOL_PARMS"].Rows[0][11]);

            // set Axis Parms with values
            DataTable dt = ds.Tables["AXIS"];
            for (int i = 0; i < SYN_AXIS; i++)
            {
                MACPARM[i].wPosToEncoderDir = Convert.ToUInt16(dt.Rows[i][0]);
                MACPARM[i].wRPM = Convert.ToUInt16(dt.Rows[i][1]);
                MACPARM[i].dwPPR = Convert.ToUInt32(dt.Rows[i][2]);
                MACPARM[i].dfPitch = Convert.ToDouble(dt.Rows[i][3]) * Math.PI; // UNIT: 2*PI
                MACPARM[i].dfGearRatio = Convert.ToDouble(dt.Rows[i][4]);
                MACPARM[i].dfHighLimit = USRFXN.DEG2RAD(Convert.ToDouble(dt.Rows[i][5]));
                MACPARM[i].dfLowLimit = USRFXN.DEG2RAD(Convert.ToDouble(dt.Rows[i][6]));
                MACPARM[i].dfHighLimitOffset = Convert.ToDouble(dt.Rows[i][7]);
                MACPARM[i].dfLowLimitOffset = Convert.ToDouble(dt.Rows[i][8]);
                MACPARM[i].wPulseMode = Convert.ToUInt16(dt.Rows[i][9]);
                MACPARM[i].wPulseWidth = Convert.ToUInt16(dt.Rows[i][10]);
                MACPARM[i].wCommandMode = Convert.ToUInt16(dt.Rows[i][11]);
                MACPARM[i].wOverTravelUpSensorMode = Convert.ToUInt16(dt.Rows[i][12]);  //  not use
                MACPARM[i].wOverTravelDownSensorMode = Convert.ToUInt16(dt.Rows[i][13]);//  not use
            }

            // set Encoder Parms with values
            DataTable dtEnc = ds.Tables["ENC"];
            for (int i = 0; i < SYN_AXIS; i++)
            {
                ENCCFG[i].wType = Convert.ToUInt16(dtEnc.Rows[i][0]);
                ENCCFG[i].wAInverse = Convert.ToUInt16(dtEnc.Rows[i][1]);
                ENCCFG[i].wBInverse = Convert.ToUInt16(dtEnc.Rows[i][2]);
                ENCCFG[i].wCInverse = Convert.ToUInt16(dtEnc.Rows[i][3]);
                ENCCFG[i].wABSwap = Convert.ToUInt16(dtEnc.Rows[i][4]);
                ENCCFG[i].wInputRate = Convert.ToUInt16(dtEnc.Rows[i][5]);
            }

            //return MCCL.NO_ERR;
            return (new double[] { DHPARM.a1, DHPARM.a2, DHPARM.a3, DHPARM.d4, DHPARM.d6, DHPARM.z_offset });
        }

        // 找出單筆為"HOME"的資料
        public int ReadJHome(DataSet ds)
        {
            // 找出單筆為"HOME"的資料
            DataRow[] rwHome = ds.Tables[0].Select("Name='HOME'");

            JHOME.J1 = USRFXN.DEG2RAD(Convert.ToDouble(rwHome[0][1]));// J1
            JHOME.J2 = USRFXN.DEG2RAD(Convert.ToDouble(rwHome[0][2]));// J2
            JHOME.J3 = USRFXN.DEG2RAD(Convert.ToDouble(rwHome[0][3]));// J3
            JHOME.J4 = USRFXN.DEG2RAD(Convert.ToDouble(rwHome[0][4]));// J4
            JHOME.J5 = USRFXN.DEG2RAD(Convert.ToDouble(rwHome[0][5]));// J5
            JHOME.J6 = USRFXN.DEG2RAD(Convert.ToDouble(rwHome[0][6]));// J6

            return MCCL.NO_ERR;
        }

        // setup the motion card
        public int SetupCard(ushort cardType)
        {
            // set Card Parms with values
            CARDCFG.wCardType = cardType;
            CARDCFG.wCardAddress = 0x240;
            CARDCFG.wIRQ_No = 5;
            CARDCFG.wPaddle = 0;

            return MCCL.NO_ERR;
        }

        public int AbortMotion()
        {
            return MCCL.MCC_AbortMotionEx(0, uGroupIndex);
        }

        public int ResetMotion()
        {
            return MCCL.MCC_ResetMotion();
        }

        public int HoldMotion()
        {
            return MCCL.MCC_HoldMotion(uGroupIndex, false);
        }

        public int ContiMotion()
        {
            return MCCL.MCC_ContiMotion(uGroupIndex);
        }

        public int GetMotionStatus()
        {
            return MCCL.MCC_GetMotionStatus(uGroupIndex);
        }

        public int GetErrorCode()
        {
            return MCCL.MCC_GetErrorCode(uGroupIndex);
        }

        public int ClearError()
        {
            return MCCL.MCC_ClearError(uGroupIndex);
        }

        public void CloseSYS()
        {
            MCCL.MCC_CloseSystem();
        }

        public int JogConti(int nDir, double dfRatio, char cAxis)
        {
            return MCCL.MCC_JogConti(nDir, dfRatio, cAxis, uGroupIndex);
        }

        /// <summary>
        /// 更正為有 coupling of Axes 算法
        /// </summary>
        /// 
        public virtual int PtpConti_Axis4(int nDir, double MaxPosSpace, double MaxNegSpace)
        {
            return 0;
        }

        public virtual int PtpConti_Axis5(int nDir, double MaxPosSpace, double MaxNegSpace)
        {
            return 0;
        }

        /// <summary>
        /// 各型別機器人特殊的方法，交給延伸類別來實作。
        /// </summary>
        /// 
        public virtual void GetDHParms(ref DH_PARAM dh)
        {
        }

        public virtual string Init_SYS(string SysType, int OverTrl_ON)
        {
            return "System ON";
        }

        public virtual int DefinePOS(JNT_POS JPos)
        {
            return MCCL.NO_ERR;
        }

        public virtual void CloseSYS(string str)
        {
        }

        /// <summary>
        /// 運動學計算函式
        /// </summary>
        /// 
        public virtual int iKine(ref CARTESIAN_POS cartP, ref JNT_POS jntP, System.UInt32 uPos)
        {
            return MCCL.NO_ERR;
        }

        public virtual int Kine(ref JNT_POS jntP, ref CARTESIAN_POS cartP, ref System.UInt32 uPos)
        {
            return MCCL.NO_ERR;
        }

        /// <summary>
        /// 運動控制函式
        /// </summary>
        /// 
        public virtual int GetCurJPOS()
        {
            return MCCL.NO_ERR;
        }

        public virtual int GetCurCPOS()
        {
            return MCCL.NO_ERR;
        }

        public virtual int Line(CARTESIAN_POS cartP)
        {
            return MCCL.NO_ERR;
        }

        public virtual int PtP(JNT_POS jntP)
        {
            return MCCL.NO_ERR;
        }

        public virtual int CircleXY(double dfCX, double dfCY, byte byCirDir)
        {
            return MCCL.NO_ERR;
        }

        public virtual int ArcXY(double dfRX0, double dfRX1, double dfX0, double dfX1)
        {
            return MCCL.NO_ERR;
        }

        public virtual int ArcXY(double x0, double y0, double z0, double x1, double y1, double z1, double rx, double ry, double rz, uint posture)
        {
            return MCCL.NO_ERR;
        }

        public virtual int CircleXY(double cx, double cy, double rx, double ry, double rz, byte byCirDir, uint posture)
        {
            return MCCL.NO_ERR;
        }

        public virtual int CircleYZ(double cy, double cz, double rx, double ry, double rz, byte byCirDir, uint posture)
        {
            return MCCL.NO_ERR;
        }

        public virtual int CircleZX(double cz, double cx, double rx, double ry, double rz, byte byCirDir, uint posture)
        {
            return MCCL.NO_ERR;
        }

        /// <summary>
        /// 遠端控制I/O方法
        /// </summary>
        /// 
        public virtual int Init_RemoteIOSet()
        {
            return MCCL.NO_ERR;
        }

        public virtual void UpdateRioStatus(ref ushort RioOut0, ref ushort RioOut1)
        {
        }

        public virtual int RIO_DrvRest(int nAxisNum)
        {
            return -1;
        }

        public virtual int RIO_DrvBrk(int nAxisNum)
        {
            return -1;
        }

        public virtual int RIO_ClrAbs()
        {
            return -1;
        }

        public virtual int RIO_ServoOn(ushort nAxisNum)
        {
            return -1;
        }

        public virtual int RIO_ServoOff(ushort nAxisNum)
        {
            return -1;
        }

        public virtual int CheckDrvStatus()
        {
            return MCCL.NO_ERR;
        }

        /// <summary>
        /// 讀取絕對值編碼器
        /// </summary>
        /// 
        public virtual int ReadFrm_ABSEnc(ref JNT_POS AbsJPos)
        {
            return MCCL.NO_ERR;
        }

        #endregion

    }
}

