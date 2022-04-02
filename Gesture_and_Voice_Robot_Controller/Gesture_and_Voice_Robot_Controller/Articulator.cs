using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using Calculation;


namespace Robot
{
    using EtherCATSeries;

    public class Articulator : RobotArm
    {
        #region Fields

        private const string sArticulator   = "ARTICULATOR";
        private const int SYS_SYN_AXIS      = 6;
        private const double SYS_MAX_SPEED  = 200;
        private const double SYS_DEF_SPEED = 5;
        private const double SYS_DEF_JSPEED = 5;

        private double tmp1, tmp2;

        #endregion

        #region Property

        /// <summary>
        /// Initialize and allocate the memory for building up a robot
        /// </summary>
        public Articulator(string type, string name)
        {
            TYPE = type;
            NAME = name;

            SYN_AXIS = SYS_SYN_AXIS;
            uGroupIndex = 0;
            CURPOS = 0;
            SysMaxSpd = SYS_MAX_SPEED;

            DHPARM = new DH_PARAM(0,0,0,0,0,0,0,0,0);
            TLPARM = new Euler_PARAM(0,0,0,0,0,0);
            MACPARM = new SYS_MAC_PARAM[6];
            ENCCFG = new SYS_ENCODER_CONFIG[6];
            CARDCFG = new SYS_CARD_CONFIG();

            JHOME = new JNT_POS(0, 0, 0, 0, 0, 0);
            ABSENC_OFFSET = new JNT_POS(0, 0, 0, 0, 0, 0);
        }

        public override void GetDHParms(ref DH_PARAM dh)
        {
            RCCL.rbt_GetDHParam(ref dh);
        }

        public override string Init_SYS(string SysType, int OverTrl_ON)
        {
            int nRet = -1;

            //if (SysType == "RUNTIME")
            //{
                // run a rtx thread
                nRet = MCCL.MCC_RtxInit(SYS_SYN_AXIS);
         
                if (nRet != MCCL.NO_ERR) 
                {
                    return MCCL.INITIAL_MOTION_ERR.ToString();
                }
            //}

            // setup a robot
            RCCL.rbt_SetDHParam(DHPARM);
            RCCL.EnableTLMD(TLPARM, true);

            if (RCCL.rbt_SetKinematicTrans(true) != MCCL.NO_ERR)
            { 
                return MCCL.INITIAL_MOTION_ERR.ToString(); 
            }

            MCCL.MCC_SetSysMaxSpeed(SYS_MAX_SPEED);//  set max. feed rate

            for (ushort wChannel=0; wChannel<SYS_SYN_AXIS; wChannel++)
            {
                if (MCCL.MCC_SetMacParam(ref MACPARM[wChannel], wChannel, MCCL.CARDINDEX0) != MCCL.NO_ERR)
                { 
                    return MCCL.INITIAL_MOTION_ERR.ToString(); 
                }

                if (MCCL.MCC_SetEncoderConfig(ref ENCCFG[wChannel], wChannel, MCCL.CARDINDEX0) != MCCL.NO_ERR)
                { 
                    return MCCL.INITIAL_MOTION_ERR.ToString(); 
                };
            }

            int[] pulse_limit = new int[SYS_SYN_AXIS];

            for (int i = 0; i < SYS_SYN_AXIS; i++)
            {
                pulse_limit[i] = Convert.ToInt32(Convert.ToDouble(MCCL.INTERPOLATION_TIME * MACPARM[i].wRPM * MACPARM[i].dwPPR) / 60.0 / 1000.0);
            }

            // set group parameters
            MCCL.MCC_CloseAllGroups();
            uGroupIndex = Convert.ToUInt16(MCCL.MCC_CreateGroup(0, 1, 2, 3, 4, 5, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, MCCL.CARDINDEX0));

            if (uGroupIndex < 0)
            {
                return MCCL.INITIAL_MOTION_ERR.ToString();
            }

            if (SysType == "3DSIM")
            {
                nRet = MCCL.MCC_InitSimulation(MCCL.INTERPOLATION_TIME, ref CARDCFG, 1);
            }
            else if (SysType == "RUNTIME")
            {

                nRet = MCCL.MCC_InitSystem(MCCL.INTERPOLATION_TIME, ref CARDCFG, 1);
            }

            if (nRet == MCCL.NO_ERR)
            {
                MCCL.MCC_SetPGain(60, 60, 60, 60, 60, 60, 60, 60, MCCL.CARDINDEX0); 
                MCCL.MCC_SetUnit(MCCL.UNIT_MM, uGroupIndex);                        
                MCCL.MCC_SetAbsolute(uGroupIndex);                                  

                // Set Accel/Decel time for Line Motion
                MCCL.MCC_SetAccTime(300, uGroupIndex);// unit : ms
                MCCL.MCC_SetDecTime(300, uGroupIndex);// unit : ms
                MCCL.MCC_SetFeedSpeed(SYS_DEF_SPEED, uGroupIndex);

                // Set Accel/Decel time for PtP Motion
                MCCL.MCC_SetPtPAccTime(300, 300, 300, 300, 300, 300, 300, 300, uGroupIndex);
                MCCL.MCC_SetPtPDecTime(300, 300, 300, 300, 300, 300, 300, 300, uGroupIndex);
                MCCL.MCC_SetPtPSpeed(SYS_DEF_JSPEED, uGroupIndex);

                // 安全機制
                MCCL.MCC_SetMaxPulseSpeed(10000000,
                                          10000000,
                                          10000000,
                                          10000000,
                                          10000000,
                                          10000000,
                                          10000000,
                                          10000000,
                                          MCCL.CARDINDEX0);

                MCCL.MCC_SetMaxPulseAcc(10000000,
                                        10000000,
                                        10000000,
                                        10000000,
                                        10000000,
                                        10000000,
                                        10000000,
                                        10000000,
                                        MCCL.CARDINDEX0);

                // Enable Soft Limit Check
                MCCL.MCC_SetOverTravelCheck(OverTrl_ON, OverTrl_ON, OverTrl_ON,
                                            OverTrl_ON, OverTrl_ON, OverTrl_ON,
                                            0, 0, uGroupIndex);
            }
            else
            {   
                int nRetError = MCCL.MCC_GetErrorCode(uGroupIndex);
                return ("Error Code: " + nRetError.ToString());
            }

            return ("Open " + SysType + " System " + "success");
        }

        public override void CloseSYS(string str)
        {
            MCCL.MCC_CloseSystem();
        }

        public override int DefinePOS(JNT_POS JPos)
        {
            MCCL.MCC_DefinePos(0, JPos.J1, uGroupIndex);
            MCCL.MCC_DefinePos(1, JPos.J2, uGroupIndex);
            MCCL.MCC_DefinePos(2, JPos.J3, uGroupIndex);
            MCCL.MCC_DefinePos(3, JPos.J4, uGroupIndex);
            MCCL.MCC_DefinePos(4, JPos.J5, uGroupIndex);
            MCCL.MCC_DefinePos(5, JPos.J6, uGroupIndex);

            return MCCL.NO_ERR;
        }

        #endregion

        #region 運動控制

        public override int iKine(ref CARTESIAN_POS cartP, ref JNT_POS jntP, System.UInt32 uPos)
        {
            double[] cpos = new double[6] { cartP.x, cartP.y, cartP.z, cartP.rx, cartP.ry, cartP.rz };
            double[] jpos = new double[6];

            int Ret = RCCL.rbt_InvKinematics_V6(ref cpos[0], uPos, ref jpos[0]);

            jntP.J1 = jpos[0];
            jntP.J2 = jpos[1];
            jntP.J3 = jpos[2];
            jntP.J4 = jpos[3];
            jntP.J5 = jpos[4];
            jntP.J6 = jpos[5];

            return Ret;
        }

        public override int Kine(ref JNT_POS jntP, ref CARTESIAN_POS cartP, ref System.UInt32 uPos)
        {
            double[] cpos = new double[6];
            double[] jpos = new double[6] { jntP.J1, jntP.J2, jntP.J3, jntP.J4, jntP.J5, jntP.J6 };

            int Ret = RCCL.rbt_FwdKinematics_V6(ref jpos[0], ref cpos[0], ref uPos);

            cartP.x = cpos[0];
            cartP.y = cpos[1];
            cartP.z = cpos[2];
            cartP.rx = cpos[3];
            cartP.ry = cpos[4];
            cartP.rz = cpos[5];

            return Ret;
        }

        public override int GetCurJPOS()
        {
            int Ret;
            double dJ1 = 0, dJ2 = 0, dJ3 = 0, dJ4 = 0, dJ5 = 0, dJ6 = 0;

            Ret = RCCL.rbt_GetCurJPos(ref dJ1, ref dJ2, ref dJ3, ref dJ4, ref dJ5, ref dJ6, ref tmp1, ref tmp2);

            //更新數據綁定變數
            CURJ1 = dJ1;
            CURJ2 = dJ2;
            CURJ3 = dJ3;
            CURJ4 = dJ4;
            CURJ5 = dJ5;
            CURJ6 = dJ6;

            return Ret;
        }

        public override int GetCurCPOS()
        {
            int Ret;
            double dx = 0, dy = 0, dz = 0, drx = 0, dry = 0, drz = 0;

            Ret = RCCL.rbt_GetCurCPos(ref dx, ref dy, ref dz, ref drx, ref dry, ref drz, ref CURPOS, uGroupIndex);

            //更新數據綁定變數
            CURX  = dx;
            CURY  = dy;
            CURZ  = dz;
            CURQX = drx;
            CURQY = dry;
            CURQZ = drz;

            return Ret;
        }

        public override int Line(CARTESIAN_POS cartP)
        {
            int Ret = MCCL.MCC_Line_V6(cartP.x,
                                       cartP.y,
                                       cartP.z,
                                       cartP.rx,
                                       cartP.ry,
                                       cartP.rz);
            return Ret;
        }

        public override int PtP(JNT_POS jntP)
        {
            int Ret = RCCL.rbt_PtP(jntP.J1,
                                   jntP.J2,
                                   jntP.J3,
                                   jntP.J4,
                                   jntP.J5,
                                   jntP.J6,
                                   0,
                                   0);
            return Ret;
        }

        public override int ArcXY(double x0, double y0, double z0, double x1, double y1, double z1, double rx, double ry, double rz, uint posture)
        {
            return MCCL.MCC_Arc_V6(x0, y0, z0, x1, y1, z1, rx, ry, rz, posture);
        }
        // x0, ref. point for x axis
        // y0, ref. point for y axis
        // z0, ref. point for z axis
        // x1, target point for x axis
        // y1, target point for y axis
        // z1, target point for z axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation    

        public override int CircleXY(double cx, double cy, double rx, double ry, double rz, byte byCirDir, uint posture)
        {
            return MCCL.MCC_CircleXY_V6(cx, cy, rx, ry, rz, byCirDir, posture);
        }
        // cx, center point for x axis
        // cy, center point for y axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation

        public override int CircleYZ(double cy, double cz, double rx, double ry, double rz, byte byCirDir, uint posture)
        {
            return MCCL.MCC_CircleYZ_V6(cy, cz, rx, ry, rz, byCirDir, posture);
        }
        // cy, center point for y axis
        // cz, center point for z axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation
        // CW or CCW

        public override int CircleZX(double cz, double cx, double rx, double ry, double rz, byte byCirDir, uint posture)
        {
            return MCCL.MCC_CircleZX_V6(cz, cx, rx, ry, rz, byCirDir, posture);
        }
        // cz, center point for z axis
        // cx, center point for x axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation
        // CW or CCW


        public override int PtpConti_Axis4(int nDir, double MaxPosSpace, double MaxNegSpace)
        {
            int Ret = -1;
            double dJ1 = 0, dJ2 = 0, dJ3 = 0, dJ4 = 0, dJ5 = 0, dJ6 = 0;

            RCCL.rbt_GetCurJPos(ref dJ1, ref dJ2, ref dJ3, ref dJ4, ref dJ5, ref dJ6, ref tmp1, ref tmp2);


            if (nDir == 1)
            {
                Ret = RCCL.rbt_PtP(dJ1, dJ2, dJ3, MaxPosSpace, dJ5, dJ6, 0, 0, 0, 0x00F8);// disable the first three axes.
            }
            else if (nDir == -1)
            {
                Ret = RCCL.rbt_PtP(dJ1, dJ2, dJ3, MaxNegSpace, dJ5, dJ6, 0, 0, 0, 0x00F8);// disable the first three axes.
            }

            return Ret;
        }

        public override int PtpConti_Axis5(int nDir, double MaxPosSpace, double MaxNegSpace)
        {
            int Ret = -1;
            double dJ1 = 0, dJ2 = 0, dJ3 = 0, dJ4 = 0, dJ5 = 0, dJ6 = 0;

            RCCL.rbt_GetCurJPos(ref dJ1, ref dJ2, ref dJ3, ref dJ4, ref dJ5, ref dJ6, ref tmp1, ref tmp2);


            if (nDir == 1)
            {
                Ret = RCCL.rbt_PtP(dJ1, dJ2, dJ3, dJ4, MaxPosSpace, dJ6, 0, 0, 0, 0x00F0);// disable the first four axes.
            }
            else if (nDir == -1)
            {
                Ret = RCCL.rbt_PtP(dJ1, dJ2, dJ3, dJ4, MaxNegSpace, dJ6, 0, 0, 0, 0x00F0);// disable the first four axes.
            }

            return Ret;
        }

        #endregion

        #region 輸出入點控制

        public override int Init_RemoteIOSet()
        {
            return MCCL.NO_ERR;
        }

        // Read ABSEnc -->Defien Cur. Robot's Pos. -->All Axes ServON -->Rdy to move.
        public override int ReadFrm_ABSEnc(ref JNT_POS AbsJPos)
        {
            int[] lAbsEnc = new int[6];

            // 絕對型編碼器取值

            MCCL.MCC_GetENCValue(ref lAbsEnc[0], 0, MCCL.CARDINDEX0);
            MCCL.MCC_GetENCValue(ref lAbsEnc[1], 1, MCCL.CARDINDEX0);
            MCCL.MCC_GetENCValue(ref lAbsEnc[2], 2, MCCL.CARDINDEX0);
            MCCL.MCC_GetENCValue(ref lAbsEnc[3], 3, MCCL.CARDINDEX0);
            MCCL.MCC_GetENCValue(ref lAbsEnc[4], 4, MCCL.CARDINDEX0);
            MCCL.MCC_GetENCValue(ref lAbsEnc[5], 5, MCCL.CARDINDEX0);

            // change to joint position(rad) 

            AbsJPos.J1 = (lAbsEnc[0] * 2 * Math.PI) / MACPARM[0].dwPPR / MACPARM[0].dfGearRatio - USRFXN.DEG2RAD(ABSENC_OFFSET.J1);
            AbsJPos.J2 = (lAbsEnc[1] * 2 * Math.PI) / MACPARM[1].dwPPR / MACPARM[1].dfGearRatio - USRFXN.DEG2RAD(ABSENC_OFFSET.J2);
            AbsJPos.J3 = (lAbsEnc[2] * 2 * Math.PI) / MACPARM[2].dwPPR / MACPARM[2].dfGearRatio - USRFXN.DEG2RAD(ABSENC_OFFSET.J3);
            AbsJPos.J4 = (lAbsEnc[3] * 2 * Math.PI) / MACPARM[3].dwPPR / MACPARM[3].dfGearRatio - USRFXN.DEG2RAD(ABSENC_OFFSET.J4);
            AbsJPos.J5 = (lAbsEnc[4] * 2 * Math.PI) / MACPARM[4].dwPPR / MACPARM[4].dfGearRatio - USRFXN.DEG2RAD(ABSENC_OFFSET.J5);
            AbsJPos.J6 = (lAbsEnc[5] * 2 * Math.PI) / MACPARM[5].dwPPR / MACPARM[5].dfGearRatio - USRFXN.DEG2RAD(ABSENC_OFFSET.J6);

            return MCCL.NO_ERR;
        }

        public override void UpdateRioStatus(ref ushort RioOut0, ref ushort RioOut1)
        {
        }

        public override int CheckDrvStatus()
        {
            return MCCL.NO_ERR;
        }

        // 對各軸的Driver作Reset
        public override int RIO_DrvRest(int nAxisNum)
        {
            return MCCL.NO_ERR;
        }

        // 必須先servo off, 才能servo brk, 1st, 6th Axis沒有brk
        public override int RIO_DrvBrk(int nAxisNum)
        {
            return MCCL.NO_ERR;
        }

        // 必須先servo off, 才能clr absenc's value
        public override int RIO_ClrAbs()
        {
            MCCL.MCC_ResetMotion();
            return MCCL.NO_ERR;
        }

        public override int RIO_ServoOn(ushort nAxisNum)
        {
            MCCL.MCC_SetServoOn(nAxisNum, MCCL.CARDINDEX0);
            return MCCL.NO_ERR;
        }

        public override int RIO_ServoOff(ushort nAxisNum)
        {
            MCCL.MCC_SetServoOff(nAxisNum, MCCL.CARDINDEX0);
            return MCCL.NO_ERR;
        }

        #endregion

    } // class Articulator

}
