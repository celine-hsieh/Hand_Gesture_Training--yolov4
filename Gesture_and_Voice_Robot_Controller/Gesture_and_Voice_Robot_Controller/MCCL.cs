using System;
using System.Runtime.InteropServices;


namespace EtherCATSeries
{
    //++
    //
    // Description:
    //
    //     The prototype of custom motion profiling functions.
    //
    // Arguments:
    //
    //     nGroup - [in] Group index.
    //     nSynAxisNum - [in] Amount of the axes of this group.
    //
    // Return Value:
    //
    //     Total distance this motion will walk through (in user-unit).
    //
    // Remarks:
    //
    //
    //--


    #region Structures

    [StructLayout(LayoutKind.Sequential)]
    public struct COMMAND_INFO
    {
        public int nType; // 0: Pont to Point
                          // 1: Line
                          // 2: Clockwise Arc/Circle
                          // 3: Counterclockwise Arc/Circle
        public int nCommandIndex;
        public double dfFeedSpeed;
        //cathy modify to define order(dfPos.n MotionPhase), 20180605
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EtherCATSeries.MCCL.MAX_AXIS_NUM)]
        public double[] dfPos;
        public int nMotionPhase;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_MAC_PARAM
    {
        public ushort wPosToEncoderDir;
        public ushort wRPM;
        public uint dwPPR;
        public double dfPitch;
        public double dfGearRatio;
        public double dfHighLimit;
        public double dfLowLimit;
        public double dfHighLimitOffset;
        public double dfLowLimitOffset;

        public ushort wPulseMode;
        public ushort wPulseWidth;
        public ushort wCommandMode;
        public ushort wPaddle;

        public ushort wOverTravelUpSensorMode;
        public ushort wOverTravelDownSensorMode;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_ENCODER_CONFIG
    {
        public ushort wType;
        public ushort wAInverse;
        public ushort wBInverse;
        public ushort wCInverse;
        public ushort wABSwap;
        public ushort wInputRate;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public ushort[] wPaddle;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_HOME_CONFIG
    {
        public ushort wMode;
        public ushort wDirection;
        public ushort wSensorMode;
        public ushort wPaddel0;

        public int nIndexCount;
        public int nPaddel1;

        public double dfAccTime;
        public double dfDecTime;
        public double dfHighSpeed;
        public double dfLowSpeed;
        public double dfOffset;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_COMP_PARAM
    {
        public uint dwInterval;
        public ushort wHome_No;
        public ushort wPaddle;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EtherCATSeries.MCCL.MAX_COMP_POINT)]
        public int[] nForwardTable;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EtherCATSeries.MCCL.MAX_COMP_POINT)]
        public int[] nBackwardTable;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_CARD_CONFIG
    {
        public ushort wCardType;
        public ushort wCardAddress;
        public ushort wIRQ_No;
        public ushort wPaddle;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_GROUP_INFO
    {
        public int nCardIndex;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EtherCATSeries.MCCL.MAX_AXIS_NUM)]
        public int[] nChannel;//cathy modify to the same name for NCCL, 20180605 //nBackwardTable;
    };

    //[StructLayout(LayoutKind.Sequential) ] 
    //public class SYS_GROUP_CONFIG
    //{
    //    [ MarshalAs( UnmanagedType.ByValArray, SizeConst=EtherCATSeries.MCCL.MAX_GROUP_NUM )]
    //    public int[] nGroupUsed;
    //    [ MarshalAs( UnmanagedType.ByValArray, SizeConst=EtherCATSeries.MCCL.MAX_GROUP_NUM )]
    //    public SYS_GROUP_INFO[] stGroupInfo;
    //    public SYS_GROUP_CONFIG()
    //    {
    //        nGroupUsed = new int[EtherCATSeries.MCCL.MAX_GROUP_NUM];
    //        stGroupInfo = new SYS_GROUP_INFO[EtherCATSeries.MCCL.MAX_GROUP_NUM];
    //    }
    //};

    /////////////////////////////////////////////////////////////////////
    // Old Definitions in MCCL V.4.5
    [StructLayout(LayoutKind.Sequential)]
    public struct HOME_CONFIG
    {
        public ushort wType;
        public ushort wPhase0Dir;
        public ushort wPhase1Dir;
        public ushort wSensorMode;
        public double dfOffset;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct ENCODER_CONFIG
    {
        public ushort wType;
        public ushort wAInverse;
        public ushort wBInverse;
        public ushort wCInverse;
        public ushort wABSwap;
        public ushort wInputRate;
        //cathy modify to the same for NCCL, 20180605
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public ushort[] wPaddle;
        //public ushort wPaddle0;
        //public ushort wPaddle1;

    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_MACH_PARAM
    {
        public ushort wPosToEncoderDir;
        public ushort wRPM;
        public uint dwPPR;
        public double dfPitch;
        public double dfGearRatio;
        public double dfHighLimit;
        public double dfLowLimit;
        public double dfHighLimitOffset;
        public double dfLowLimitOffset;

        public ushort wPulseMode;
        public ushort wPulseWidth;
        public ushort wCommandMode;
        public ushort wPaddle;

        public HOME_CONFIG stHome;
        public ENCODER_CONFIG stEncoder;

        public ushort wOverTravelUpSensorMode;
        public ushort wOverTravelDownSensorMode;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct SYS_GROUP_CONFIG
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EtherCATSeries.MCCL.MAX_GROUP_NUM)]
        public int[] nGroupUsed;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = EtherCATSeries.MCCL.MAX_GROUP_NUM)]
        public SYS_GROUP_INFO[] stGroupInfo;
    };

    //#if !defined(_EPCIO_DEV_H_) && !defined(_ACTADRV_H_)
    [StructLayout(LayoutKind.Sequential)]
    public struct ENCINT
    {
        public byte INDEX0;
        public byte INDEX1;
        public byte INDEX2;
        public byte INDEX3;
        public byte INDEX4;
        public byte INDEX5;
        public byte INDEX6;
        public byte INDEX7;

        public byte COMP0;
        public byte COMP1;
        public byte COMP2;
        public byte COMP3;
        public byte COMP4;
        public byte COMP5;
        public byte COMP6;
        public byte COMP7;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct PCLINT
    {
        public byte OVP0;
        public byte OVP1;
        public byte OVP2;
        public byte OVP3;
        public byte OVP4;
        public byte OVP5;
        public byte OVP6;
        public byte OVP7;

        public byte OVN0;
        public byte OVN1;
        public byte OVN2;
        public byte OVN3;
        public byte OVN4;
        public byte OVN5;
        public byte OVN6;
        public byte OVN7;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct ADCINT
    {
        public byte COMP0;
        public byte COMP1;
        public byte COMP2;
        public byte COMP3;
        public byte COMP4;
        public byte COMP5;
        public byte COMP6;
        public byte COMP7;
        public byte CONV;
        public byte TAG;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct LIOINT
    {
        public byte OTP0;
        public byte OTP1;
        public byte OTP2;
        public byte OTP3;
        public byte OTP4;
        public byte OTP5;
        public byte OTP6;
        public byte OTP7;
        public byte OTN0;
        public byte OTN1;
        public byte OTN2;
        public byte OTN3;
        public byte OTN4;
        public byte OTN5;
        public byte OTN6;
        public byte OTN7;
        public byte HOME0;
        public byte HOME1;
        public byte HOME2;
        public byte HOME3;
        public byte HOME4;
        public byte HOME5;
        public byte HOME6;
        public byte HOME7;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct RIOINT
    {
        public byte SET0_DI0;
        public byte SET0_DI1;
        public byte SET0_DI2;
        public byte SET0_DI3;
        public byte SET0_FAIL;

        public byte SET1_DI0;
        public byte SET1_DI1;
        public byte SET1_DI2;
        public byte SET1_DI3;
        public byte SET1_FAIL;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct TMRINT
    {
        public byte TIMER;
    }

    #endregion Structures

    /// <summary>
    /// Summary description for MCCL.
    /// </summary>
    internal static class MCCL
    {
        #region Constants

        // WIN32 Version
        //private const string LibNameVersion = "MCCLPCI_IMP.dll";

        // EtherCAT version
        //private const string LibNameVersion = "MCCL_Client.dll";
        private const string LibNameVersion = "MCCL_Client.dll"; //debug

        // initiation
        public const int EPCIO_4_AXIS_ISA_CARD = 0;
        public const int EPCIO_6_AXIS_ISA_CARD = 1;
        public const int EPCIO_4_AXIS_PCI_CARD = 2;
        public const int EPCIO_6_AXIS_PCI_CARD = 3;
        public const int IMP_II_8_AXIS_PCI_CARD = 4;

        public const int GROUPINDEX0 = 0;
        public const int GROUPINDEX1 = 1;
        public const int GROUPINDEX2 = 2;
        public const int GROUPINDEX3 = 3;
        public const int GROUPINDEX4 = 4;
        public const int GROUPINDEX5 = 5;

        public const int CARDINDEX0 = 0;
        public const int CARDINDEX1 = 1;

        public const int COMMAND_QUEUE_SIZE = 10000;

        public const int INTERPOLATION_TIME = 1;

        public const int MAX_CARD_NUM = 12;
        public const int MAX_AXIS_NUM = 8;
        public const int MAX_GROUP_NUM = 96;

        public const int _YES_ = 1;
        public const int _NO_ = 0;

        public const int GROUP_VALID = 0;
        public const int GROUP_INVALID = -1;
        public const int AXIS_INVALID = -1;

        public const int INVERSE_YES = 1;
        public const int INVERSE_NO = 0;

        // Range Definitions of Interpolation Period (ms)
        public const int IPO_PERIOD_MIN = 1;
        public const int IPO_PERIOD_MAX = 50;

        // Definitions of Output Command Modes
        public const int OCM_PULSE = 0;
        public const int OCM_VOLTAGE = 1;

        // Unit Definitions
        public const int UNIT_MM = 1;
        public const int UNIT_INCH = 2;

        // Home Mode Definitions (obsolete, just for compatibility)
        public const int HM_NORMAL = 0;
        public const int HM_SENSOR_ONLY = 1;
        public const int HM_INDEX_ONLY = 2;

        // Definitions of Sensor Logic
        public const int SL_NORMAL_OPEN = 0;
        public const int SL_NORMAL_CLOSE = 1;
        public const int SL_UNUSED = 2;

        // Definitions of In-Position Modes
        public const int IPM_ONETIME_BLOCK = 0;
        public const int IPM_ONETIME_UNBLOCK = 1;
        public const int IPM_SETTLE_BLOCK = 2;
        public const int IPM_SETTLE_UNBLOCK = 3;

        // Definitions of Group Motion Status
        public const int GMS_RUNNING = 0;
        public const int GMS_STOP = 1;
        public const int GMS_HOLD = 2;
        public const int GMS_DELAYING = 3;

        // Definitions of MCCL Axis Flag
        public const uint IMP_AXIS_X = 0x0001;
        public const uint IMP_AXIS_Y = 0x0002;
        public const uint IMP_AXIS_Z = 0x0004;
        public const uint IMP_AXIS_U = 0x0008;
        public const uint IMP_AXIS_V = 0x0010;
        public const uint IMP_AXIS_W = 0x0020;
        public const uint IMP_AXIS_A = 0x0040;
        public const uint IMP_AXIS_B = 0x0080;
        public const uint IMP_AXIS_ALL = 0x00FF;

        // Compensation-related Definitions
        public const int MAX_COMP_POINT = 256;

        // Output Pulse Format Definitions
        public const int DDA_FMT_NO = 0x0; // No pulse output
        public const int DDA_FMT_PD = 0x1; // Pulse/Dir
        public const int DDA_FMT_CW = 0x2; // CW/CCW
        public const int DDA_FMT_AB = 0x3; // A/B Phase

        // Encoder Type Definitions
        public const int ENC_TYPE_NO = 0x0; // No pulse input   
        public const int ENC_TYPE_PD = 0x1; // Pulse/Dir 
        public const int ENC_TYPE_CW = 0x2; // CW/CCW
        public const int ENC_TYPE_AB = 0x3; // A/B Phase

        // Output Pulse Format Definitions
        public const int PGE_FMT_NO = 0x0; // No pulse output
        public const int PGE_FMT_PD = 0x1; // Pulse/Dir
        public const int PGE_FMT_CW = 0x2; // CW/CCW
        public const int PGE_FMT_AB = 0x3; // A/B Phase

        // Encoder Type Definitions
        public const int ENC_FMT_NO = 0x0; // No pulse input
        public const int ENC_FMT_PD = 0x1; // Pulse/Dir
        public const int ENC_FMT_CW = 0x2; // CW/CCW
        public const int ENC_FMT_AB = 0x3; // A/B Phase

        // Encoder Latch Trigger Mode Definitions
        public const int ENC_TRIG_FIRST = 0x0;
        public const int ENC_TRIG_LAST = 0x1;

        // Encoder Trigger Source Definitions
        public const int ENC_TRIG_NO = 0x00000000;
        public const int ENC_TRIG_INDEX0 = 0x00000001;
        public const int ENC_TRIG_INDEX1 = 0x00000002;
        public const int ENC_TRIG_INDEX2 = 0x00000004;
        public const int ENC_TRIG_INDEX3 = 0x00000008;
        public const int ENC_TRIG_INDEX4 = 0x00000010;
        public const int ENC_TRIG_INDEX5 = 0x00000020;
        public const int ENC_TRIG_INDEX6 = 0x00000040;
        public const int ENC_TRIG_INDEX7 = 0x00000080;

        public const int ENC_TRIG_OTP0 = 0x00000100;
        public const int ENC_TRIG_OTP1 = 0x00000200;
        public const int ENC_TRIG_OTP2 = 0x00000400;
        public const int ENC_TRIG_OTP3 = 0x00000800;
        public const int ENC_TRIG_OTP4 = 0x00001000;
        public const int ENC_TRIG_OTP5 = 0x00002000;
        public const int ENC_TRIG_OTP6 = 0x00004000;
        public const int ENC_TRIG_OTP7 = 0x00008000;

        public const int ENC_TRIG_OTN0 = 0x00010000;
        public const int ENC_TRIG_OTN1 = 0x00020000;
        public const int ENC_TRIG_OTN2 = 0x00040000;
        public const int ENC_TRIG_OTN3 = 0x00080000;
        public const int ENC_TRIG_OTN4 = 0x00100000;
        public const int ENC_TRIG_OTN5 = 0x00200000;
        public const int ENC_TRIG_OTN6 = 0x00400000;
        public const int ENC_TRIG_OTN7 = 0x00800000;

        // Local I/O Interrupt Trigger Type Definitions
        public const int LIO_INT_NO = 0x0;
        public const int LIO_INT_RISE = 0x1;
        public const int LIO_INT_FALL = 0x2;
        public const int LIO_INT_LEVEL = 0x3;

        // Local I/O Interrupt Trigger Source Definitions
        public const int LIO_LDI_OTP0 = 0;
        public const int LIO_LDI_OTP1 = 1;
        public const int LIO_LDI_OTP2 = 2;
        public const int LIO_LDI_OTP3 = 3;
        public const int LIO_LDI_OTP4 = 4;
        public const int LIO_LDI_OTP5 = 5;
        public const int LIO_LDI_OTP6 = 6;
        public const int LIO_LDI_OTP7 = 7;
        public const int LIO_LDI_OTN0 = 8;
        public const int LIO_LDI_OTN1 = 9;
        public const int LIO_LDI_OTN2 = 10;
        public const int LIO_LDI_OTN3 = 11;
        public const int LIO_LDI_OTN4 = 12;
        public const int LIO_LDI_OTN5 = 13;
        public const int LIO_LDI_OTN6 = 14;
        public const int LIO_LDI_OTN7 = 15;
        public const int LIO_LDI_HOME0 = 16;
        public const int LIO_LDI_HOME1 = 17;
        public const int LIO_LDI_HOME2 = 18;
        public const int LIO_LDI_HOME3 = 19;
        public const int LIO_LDI_HOME4 = 20;
        public const int LIO_LDI_HOME5 = 21;
        public const int LIO_LDI_HOME6 = 22;
        public const int LIO_LDI_HOME7 = 23;

        // DAC Interrupt Trigger Source Definitions
        public const ulong DAC_TRIG_ENC0 = 0x00000001;
        public const ulong DAC_TRIG_ENC1 = 0x00000002;
        public const ulong DAC_TRIG_ENC2 = 0x00000004;
        public const ulong DAC_TRIG_ENC3 = 0x00000008;
        public const ulong DAC_TRIG_ENC4 = 0x00000010;
        public const ulong DAC_TRIG_ENC5 = 0x00000020;
        public const ulong DAC_TRIG_ENC6 = 0x00000040;
        public const ulong DAC_TRIG_ENC7 = 0x00000080;

        // LED Trigger Source Definitions
        public const ulong LED_TRIG_ENC0 = 0x00000001;
        public const ulong LED_TRIG_ENC1 = 0x00000002;
        public const ulong LED_TRIG_ENC2 = 0x00000004;
        public const ulong LED_TRIG_ENC3 = 0x00000008;
        public const ulong LED_TRIG_ENC4 = 0x00000010;
        public const ulong LED_TRIG_ENC5 = 0x00000020;
        public const ulong LED_TRIG_ENC6 = 0x00000040;
        public const ulong LED_TRIG_ENC7 = 0x00000080;

        // ADC Compare Type Definitions
        public const int ADC_COMP_RISE = 0x0;
        public const int ADC_COMP_FALL = 0x1;
        public const int ADC_COMP_LEVEL = 0x2;

        // ADC Compare Mask Definitions
        public const int ADC_MASK_NO = 0x0;
        public const int ADC_MASK_BIT1 = 0x1;
        public const int ADC_MASK_BIT2 = 0x2;
        public const int ADC_MASK_BIT3 = 0x3;

        // ADC Converting Type Definitions
        public const int ADC_TYPE_BIP = 0x0;
        public const int ADC_TYPE_UNI = 0x1;

        // ADC Converting Mode Definitions
        public const int ADC_MODE_SINGLE = 0x0;
        public const int ADC_MODE_FREE = 0x1;

        // Remote I/O Set Definitions
        public const int RIO_SET0 = 0x0;
        public const int RIO_SET1 = 0x1;

        // Remote I/O Slave Definitions
        public const int RIO_SLAVE0 = 0x0;
        public const int RIO_SLAVE1 = 0x1;
        public const int RIO_SLAVE2 = 0x2;
        public const int RIO_SLAVE3 = 0x3;
        public const int RIO_SLAVE4 = 0x4;
        public const int RIO_SLAVE5 = 0x5;
        public const int RIO_SLAVE6 = 0x6;
        public const int RIO_SLAVE7 = 0x7;
        public const int RIO_SLAVE8 = 0x8;
        public const int RIO_SLAVE9 = 0x9;
        public const int RIO_SLAVE10 = 0xA;
        public const int RIO_SLAVE11 = 0xB;
        public const int RIO_SLAVE12 = 0xC;
        public const int RIO_SLAVE13 = 0xD;
        public const int RIO_SLAVE14 = 0xE;
        public const int RIO_SLAVE15 = 0xF;
        public const int RIO_SLAVE16 = 0x10;
        public const int RIO_SLAVE17 = 0x11;
        public const int RIO_SLAVE18 = 0x12;
        public const int RIO_SLAVE19 = 0x13;
        public const int RIO_SLAVE20 = 0x14;
        public const int RIO_SLAVE21 = 0x15;
        public const int RIO_SLAVE22 = 0x16;
        public const int RIO_SLAVE23 = 0x17;
        public const int RIO_SLAVE24 = 0x18;
        public const int RIO_SLAVE25 = 0x19;
        public const int RIO_SLAVE26 = 0x1A;
        public const int RIO_SLAVE27 = 0x1B;
        public const int RIO_SLAVE28 = 0x1C;
        public const int RIO_SLAVE29 = 0x1D;
        public const int RIO_SLAVE30 = 0x1E;
        public const int RIO_SLAVE31 = 0x1F;

        // Remote I/O Port Definitions
        public const int RIO_PORT0 = 0x0;
        public const int RIO_PORT1 = 0x1;
        public const int RIO_PORT2 = 0x2;
        public const int RIO_PORT3 = 0x3;

        // Remote I/O Interrupt Trigger Source Definitions
        public const int RIO_DI0 = 0x0;
        public const int RIO_DI1 = 0x1;
        public const int RIO_DI2 = 0x2;
        public const int RIO_DI3 = 0x3;

        // Remote I/O Interrupt Trigger Type Definitions
        public const int RIO_INT_RISE = 0x0;
        public const int RIO_INT_FALL = 0x1;
        public const int RIO_INT_LEVEL = 0x2;

        // MCCL Error Codes Definitions
        public const int NO_ERR = 0;
        public const int INITIAL_MOTION_ERR = -1;
        public const int COMMAND_BUFFER_FULL_ERR = -2;
        public const int COMMAND_NOTACCEPTED_ERR = -3;
        public const int COMMAND_NOTFINISHED_ERR = -4;
        public const int PARAMETER_ERR = -5;
        public const int GROUP_PARAMETER_ERR = -6;
        public const int FEED_RATE_ERR = -7;
        public const int BLEND_COMMAND_NOTCALLED_ERR = -8;
        public const int VOLTAGE_COMMAND_CHANNEL_ERR = -9;
        public const int HOME_COMMAND_NOTCALLED_ERR = -10;
        public const int HOLD_ILLEGAL_ERR = -11;
        public const int CONTI_ILLEGAL_ERR = -12;
        public const int ABORT_ILLEGAL_ERR = -13;
        public const int RUN_TIME_ERR = -14;
        public const int ABORT_NOT_FINISH_ERR = -15;
        public const int GROUP_RAN_OUT_ERR = -16;

        #endregion Constants

        #region Callbacks

        public delegate void PCLISR(ref PCLINT value);
        public delegate void ADCISR(ref ADCINT value);
        public delegate void LIOISR(ref LIOINT value);
        public delegate void ENCISR(ref ENCINT value);
        public delegate void RIOISR(ref RIOINT value);
        public delegate void TMRISR(ref TMRINT value);

        #endregion Callbacks

        #region Functions

        // Get Library Version
        [DllImport(LibNameVersion)]
        public static extern void MCC_GetVersion(ref char strVersion);

        // Set Configure Parameters
        [DllImport(LibNameVersion)]
        public static extern int MCC_CreateGroup(int xMapToCh, int yMapToCh, int zMapToCh, int uMapToCh, int vMapToCh, int wMapToCh, int aMapToCh, int bMapToCh,
                                                    int xMapToCh1, int yMapToCh1, int zMapToCh1, int uMapToCh1, int vMapToCh1, int wMapToCh1, int aMapToCh1, int bMapToCh1, int nCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CreateGroupEx(int xMapToCh, int yMapToCh, int zMapToCh, int uMapToCh, int vMapToCh, int wMapToCh, int aMapToCh, int bMapToCh, int nCardIndex, int nMotionQueueSize);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CloseGroup(int nGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CloseAllGroups();

        // Set/Get Mechanism Parameters
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetMacParam(ref SYS_MAC_PARAM pstMacParam, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetMacParam(ref SYS_MAC_PARAM pstMacParam, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_UpdateParam();

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetEncoderConfig(ref SYS_ENCODER_CONFIG pstEncoderConfig, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetEncoderConfig(ref SYS_ENCODER_CONFIG pstEncoderConfig, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetConvFactor(ushort wChannel, ushort wCardIndex);

        // Set/Get Max. Feed Speed
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetSysMaxSpeed(double dfMaxSpeed);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetSysMaxSpeed();

        // Set/Get size of motion command queue
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetCmdQueueSize(int nSize, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCmdQueueSize(ushort wGroupIndex);

        // Initialize/Close System
        [DllImport(LibNameVersion)]
        public static extern int MCC_InitSystem(int nInterpolateTime, ref SYS_CARD_CONFIG psCardConfig, ushort wCardNo);

        [DllImport(LibNameVersion)]
        public static extern int MCC_InitSystemEx(double nInterpolateTime, ref SYS_CARD_CONFIG psCardConfig, ushort wCardNo);

        [DllImport(LibNameVersion)]
        public static extern int MCC_InitSimulation(int nInterpolateTime, ref SYS_CARD_CONFIG pstCardConfig, ushort wCardNo);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CloseSystem();

        // Reset MCCL
        [DllImport(LibNameVersion)]
        public static extern int MCC_ResetMotion();

        // Enable/Disable Dry Run
        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableDryRun();

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableDryRun();

        [DllImport(LibNameVersion)]
        public static extern int MCC_CheckDryRun();

        // Servo On/Off
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetServoOn(ushort wChannel, ushort wCardIndex);
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetServoOff(ushort wChannel, ushort wCardIndex);

        // Enable/Disable Position Ready
        [DllImport(LibNameVersion)]
        public static extern int MCC_EnablePosReady(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisablePosReady(ushort wCardIndex);

        // Get Emergency Stop Status
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetEmgcStopStatus(ref ushort pwStatus, ushort wCardIndex);

        // Input Signal Trigger
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetLIORoutine(LIOISR pfnLIORoutine, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetLIOTriggerType(ushort wTriggerType, ushort wPoint, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableLIOTrigger(ushort wPoint, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableLIOTrigger(ushort wPoint, ushort wCardIndex);

        // LED On/Off Control
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetLedLightOn(ushort Channel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetLedLightOff(ushort Channel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetLedLightStatus(ushort Channel, ref ushort Status, ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Coordinate Management

        // Set/Get Coordinate Type
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetAbsolute(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetIncrease(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCoordType(ushort wGroupIndex);

        // Get Current Position & Pulse Position
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCurRefPos(ref double pdfX, ref double pdfY, ref double pdfZ, ref double pdfU, ref double pdfV, ref double pdfW, ref double pdfA, ref double pdfB, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCurPos(ref double pdfX, ref double pdfY, ref double pdfZ, ref double pdfU, ref double pdfV, ref double pdfW, ref double pdfA, ref double pdfB, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetPulsePos(ref int plX, ref int plY, ref int plZ, ref int plU, ref int plV, ref int plW, ref int plA, ref int plB, ushort wGroupIndex);

        // Coordinate Management
        [DllImport(LibNameVersion)]
        public static extern int MCC_DefineOrigin(ushort wAxis, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DefinePosHere(ushort wGroupIndex, uint dwAxisMask);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DefinePos(ushort wAxis, double dfCart, ushort wGroupIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Software Over Travel Check & Hardware Limit Switch Check

        // Enable/Disable Hardware Limit Switch Check
        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableLimitSwitchCheck(int nMode);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableLimitSwitchCheck();

        // Enable/Disable Software Over Travel Check
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetOverTravelCheck(int nOTCheck0, int nOTCheck1, int nOTCheck2, int nOTCheck3, int nOTCheck4, int nOTCheck5, int nOTCheck6, int nOTCheck7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetOverTravelCheck(ref int pnOTCheck0, ref int pnOTCheck1, ref int pnOTCheck2, ref int pnOTCheck3, ref int pnOTCheck4, ref int pnOTCheck5, ref int pnOTCheck6, ref int pnOTCheck7, ushort wGroupIndex);

        // Get Limit Switch Sensor Signal
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetLimitSwitchStatus(ref ushort pwStatus, ushort wUpDown, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetLatchedLimitSwitchStatus(ref ushort pwStatus, ushort wUpDown, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ClearLatchedLimitSwitchStatus(ushort wUpDown, ushort wChannel, ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // General Motions(Line, Arc, Circle, Helical Motions)

        // Set/Get Accleration & Deceleration Types
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetAccType(char cAccType, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetAccType(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDecType(char cDecType, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetDecType(ushort wGroupIndex);

        // Set/Get Accleration & Deceleration Times(Steps)
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetAccTime(double dfAccTime, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetAccTime(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDecTime(double dfDecTime, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetDecTime(ushort wGroupIndex);

        // Set/Get Feed Speed
        [DllImport(LibNameVersion)]
        public static extern double MCC_SetFeedSpeed(double dfFeedSpeed, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetFeedSpeed(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetCurFeedSpeed(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetSpeed(ref double pdfVel0, ref double pdfVel1, ref double pdfVel2, ref double pdfVel3, ref double pdfVel4, ref double pdfVel5, ref double pdfVel6, ref double pdfVel7, ushort wGroupIndex);

        // Set/Get Speed Ratio
        [DllImport(LibNameVersion)]
        public static extern double MCC_SetPtPSpeed(double dfRatio, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetPtPSpeed(ushort wGroupIndex);

        // Point to Point Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_PtP(double dfX0, double dfX1, double dfX2, double dfX3, double dfX4, double dfX5, double dfX6, double dfX7, ushort wGroupIndex, uint dwAxisMask);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPX(double dfX, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPY(double dfY, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPZ(double dfZ, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPU(double dfU, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPV(double dfV, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPW(double dfW, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPA(double dfA, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_PtPB(double dfB, ushort wGroupIndex);

        // Line Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_Line(double dfX0, double dfX1, double dfX2, double dfX3, double dfX4, double dfX5, double dfX6, double dfX7, ushort wGroupIndex, uint dwAxisMask);

        // Arc Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcXYZ(double dfRX0, double dfRX1, double dfRX2, double dfX0, double dfX1, double dfX2, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcXY(double dfRX0, double dfRX1, double dfX0, double dfX1, ushort wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcYZ(double dfRX1, double dfRX2, double dfX1, double dfX2, ushort wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcZX(double dfRX2, double dfRX0, double dfX2, double dfX0, ushort wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcXYZ_Aux(double dfRX0, double dfRX1, double dfRX2, double dfX0, double dfX1, double dfX2, double dfX3, double dfX4, double dfX5, double dfX6, double dfX7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcXY_Aux(double dfRX0, double dfRX1, double dfX0, double dfX1, double dfX3, double dfX4, double dfX5, double dfX6, double dfX7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcYZ_Aux(double dfRX1, double dfRX2, double dfX1, double dfX2, double dfX3, double dfX4, double dfX5, double dfX6, double dfX7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcZX_Aux(double dfRX2, double dfRX0, double dfX2, double dfX0, double dfX3, double dfX4, double dfX5, double dfX6, double dfX7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcThetaXY(double dfCX, double dfCY, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcThetaYZ(double dfCY, double dfCZ, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcThetaZX(double dfCZ, double dfCX, double dfTheta, ushort wGroupIndex);

        // Circle Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleXY(double dfCX, double dfCY, byte byCirDir, ushort wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleYZ(double dfCY, double dfCZ, byte byCirDir, ushort wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleZX(double dfCZ, double dfCX, byte byCirDir, ushort wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleXY_Aux(double dfCX, double dfCY, double dfU, double dfV, double dfW, double dfA, double dfB, byte byCirDir, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleYZ_Aux(double dfCY, double dfCZ, double dfU, double dfV, double dfW, double dfA, double dfB, byte byCirDir, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleZX_Aux(double dfCZ, double dfCX, double dfU, double dfV, double dfW, double dfA, double dfB, byte byCirDir, ushort wGroupIndex);

        // Helica Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_HelicalXY_Z(double dfCX, double dfCY, double dfPitch, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_HelicalYZ_X(double dfCY, double dfCZ, double dfPitch, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_HelicalZX_Y(double dfCZ, double dfCX, double dfPitch, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_HelicalXY_Z_Aux(double dfCX, double dfCY, double dfPitch, double dfU, double dfV, double dfW, double dfA, double dfB, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_HelicalYZ_X_Aux(double dfCZ, double dfCX, double dfPitch, double dfU, double dfV, double dfW, double dfA, double dfB, double dfTheta, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_HelicalZX_Y_Aux(double dfCZ, double dfCX, double dfPitch, double dfU, double dfV, double dfW, double dfA, double dfB, double dfTheta, ushort wGroupIndex);


        //////////////////////////////////////////////////////////////////////////////
        // JOG Motion

        [DllImport(LibNameVersion)]
        public static extern int MCC_JogPulse(int nPulse, char cAxis, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_JogSpace(double dfOffset, double dfRatio, char cAxis, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_JogConti(int nDir, double dfRatio, char cAxis, ushort wGroupIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Point to Point Motion

        // Set/Get Accleration & Deceleration Types
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetPtPAccType(char cAccType0, char cAccType1, char cAccType2, char cAccType3, char cAccType4, char cAccType5, char cAccType6, char cAccType7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetPtPAccType(ref char pcAccType0, ref char pcAccType1, ref char pcAccType2, ref char pcAccType3, ref char pcAccType4, ref char pcAccType5, ref char pcAccType6, ref char pcAccType7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetPtPDecType(char cDecType0, char cDecType1, char cDecType2, char cDecType3, char cDecType4, char cDecType5, char cDecType6, char cDecType7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetPtPDecType(ref char pcDecType0, ref char pcDecType1, ref char pcDecType2, ref char pcDecType3, ref char pcDecType4, ref char pcDecType5, ref char pcDecType6, ref char pcDecType7, ushort wGroupIndex);

        // Set/Get Accleration & Deceleration Times(Steps)
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetPtPAccTime(double dfAccTime0, double dfAccTime1, double dfAccTime2, double dfAccTime3, double dfAccTime4, double dfAccTime5, double dfAccTime6, double dfAccTime7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetPtPAccTime(ref double pdfAccTime0, ref double pdfAccTime1, ref double pdfAccTime2, ref double pdfAccTime3, ref double pdfAccTime4, ref double pdfAccTime5, ref double pdfAccTime6, ref double pdfAccTime7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetPtPDecTime(double dfDecTime0, double dfDecTime1, double dfDecTime2, double dfDecTime3, double dfDecTime4, double dfDecTime5, double dfDecTime6, double dfDecTime7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetPtPDecTime(ref double pdfDecTime0, ref double pdfDecTime1, ref double pdfDecTime2, ref double pdfDecTime3, ref double pdfDecTime4, ref double pdfDecTime5, ref double pdfDecTime6, ref double pdfDecTime7, ushort wGroupIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Motion Status

        // Get Current Motion Status
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetMotionStatus(ushort wGroupIndex);

        // Get Current Executing Motion Command
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCurCommand(ref COMMAND_INFO pstCurCommand, ushort wGroupIndex);

        // Get Motion Command Stock Count
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCommandCount(ref int pnCmdCount, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ResetCommandIndex(ushort wGroupIndex);

        // Set/Get maximum number of the hardware pulse stock
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetMaxPulseStockNum(int nMaxStockNum);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetMaxPulseStockNum();

        // Get hardware pulse stock count
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetCurPulseStockCount(ref ushort pwStockCount, ushort wChannel, ushort wCardIndex);

        // Get/Clear Error Code
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetErrorCode(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ClearError(ushort wGroupIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Go Home

        // Operations 
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetHomeConfig(ref SYS_HOME_CONFIG pstHomeConfig, ushort wChannel, ushort wCardIndex);
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetHomeConfig(ref SYS_HOME_CONFIG pstHomeConfig, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_Home(int nOrder0, int nOrder1, int nOrder2, int nOrder3, int nOrder4, int nOrder5, int nOrder6, int nOrder7, ushort wCardIndex);
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetGoHomeStatus();
        [DllImport(LibNameVersion)]
        public static extern int MCC_AbortGoHome();

        // Get Home Sensor Signal
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetHomeSensorStatus(ref ushort pwStatus, ushort wChannel, ushort wCardIndex);

        //////////////////////////////////////////////////////////////////////////////

        // Position Control

        // Set/Get P Gain for Position Control Loop
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetPGain(ushort wGain0, ushort wGain1, ushort wGain2, ushort wGain3, ushort wGain4, ushort wGain5, ushort wGain6, ushort wGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetPGain(ref ushort pwGain0, ref ushort pwGain1, ref ushort pwGain2, ref ushort pwGain3, ref ushort pwGain4, ref ushort pwGain5, ref ushort pwGain6, ref ushort pwGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetIGain(ushort wGain0, ushort wGain1, ushort wGain2, ushort wGain3, ushort wGain4, ushort wGain5, ushort wGain6, ushort wGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetIGain(ref ushort pwGain0, ref ushort pwGain1, ref ushort pwGain2, ref ushort pwGain3, ref ushort pwGain4, ref ushort pwGain5, ref ushort pwGain6, ref ushort pwGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDGain(ushort wGain0, ushort wGain1, ushort wGain2, ushort wGain3, ushort wGain4, ushort wGain5, ushort wGain6, ushort wGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetDGain(ref ushort pwGain0, ref ushort pwGain1, ref ushort pwGain2, ref ushort pwGain3, ref ushort pwGain4, ref ushort pwGain5, ref ushort pwGain6, ref ushort pwGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetFGain(ushort wGain0, ushort wGain1, ushort wGain2, ushort wGain3, ushort wGain4, ushort wGain5, ushort wGain6, ushort wGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetFGain(ref ushort pwGain0, ref ushort pwGain1, ref ushort pwGain2, ref ushort pwGain3, ref ushort pwGain4, ref ushort pwGain5, ref ushort pwGain6, ref ushort pwGain7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetIGainClockDivider(ushort dwClockDivider, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDGainClockDivider(ushort dwClockDivider, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetErrorCount(ref int pnErrCount0, ref int pnErrCount1, ref int pnErrCount2, ref int pnErrCount3, ref int pnErrCount4, ref int pnErrCount5, ref int pnErrCount6, ref int pnErrCount7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetErrorCountThreshold(ushort wChannel, ushort wPlusThreshold, ushort wMinusThreshold, ushort wCardIndex);

        // Set/Get Pulse Speed & Accleration
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetMaxPulseSpeed(int nPulse0, int nPulse1, int nPulse2, int nPulse3, int nPulse4, int nPulse5, int nPulse6, int nPulse7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetMaxPulseSpeed(ref int pnSpeed0, ref int pnSpeed1, ref int pnSpeed2, ref int pnSpeed3, ref int pnSpeed4, ref int pnSpeed5, ref int pnSpeed6, ref int pnSpeed7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetMaxPulseAcc(int nPulseAcc0, int nPulseAcc1, int nPulseAcc2, int nPulseAcc3, int nPulseAcc4, int nPulseAcc5, int nPulseAcc6, int nPulseAcc7, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetMaxPulseAcc(ref int pnPulseAcc0, ref int pnPulseAcc1, ref int pnPulseAcc2, ref int pnPulseAcc3, ref int pnPulseAcc4, ref int pnPulseAcc5, ref int pnPulseAcc6, ref int pnPulseAcc7, ushort wCardIndex);

        // In Postion Operations
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetInPosMode(ushort wMode, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetInPosMaxCheckTime(ushort wMaxCheckTime, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetInPosSettleTime(ushort wSettleTime, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableInPos(ushort wGroupIndex, uint dwAxisMask);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableInPos(ushort wGroupIndex, uint dwAxisMask);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetInPosToleranceEx(double dfTolerance0, double dfTolerance1, double dfTolerance2, double dfTolerance3, double dfTolerance4, double dfTolerance5, double dfTolerance6, double dfTolerance7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetInPosToleranceEx(ref double pdfTolerance0, ref double pdfTolerance1, ref double pdfTolerance2, ref double pdfTolerance3, double dfTolerance4, double dfTolerance5, double dfTolerance6, double dfTolerance7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetInPosStatus(ref byte pbyInPos0, ref byte pbyInPos1, ref byte pbyInPos2, ref byte pbyInPos3, ref byte pbyInPos4, ref byte pbyInPos5, ref byte pbyInPos6, ref byte pbyInPos7, ushort wGroupIndex);

        // Tracking Error Detection
        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableTrackError(ushort wGroupIndex, uint dwAxisMask);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableTrackError(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetTrackErrorLimit(double dfLimit, char cAxis, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetTrackErrorLimit(ref double pdfLimit, char cAxis, ushort wGroupIndex);

        // Link PCL Interrupt Service Function
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetPCLRoutine(PCLISR pfnPCLRoutine, ushort wCardIndex);

        // Set Compensation Table
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetCompParam(ref SYS_COMP_PARAM pstCompParam, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_UpdateCompParam();


        //////////////////////////////////////////////////////////////////////////////
        // Advanced Trajectory Planning

        // Hold/Continue/Abort Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_HoldMotion(ushort wGroupIndex, bool bAfterCmd);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ContiMotion(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_AbortMotionEx(double dfDecTime, ushort wGroupIndex);

        // Enable/Disable Motion Blending
        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableBlendInstant(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableBlendInstant(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableBlend(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableBlend(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CheckBlend(ushort wGroupIndex);

        // Set Delay Time
        [DllImport(LibNameVersion)]
        public static extern int MCC_DelayMotion(uint dwTime, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_CheckDelay(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern void MCC_TimeDelay(uint dwTime);

        // Set/Get Over-Speed Ratio for General Motions
        [DllImport(LibNameVersion)]
        public static extern double MCC_OverrideSpeed(double dfRate, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_OverrideSpeedEx(double dfRate, bool bInstant, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetOverrideRate(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_FixSpeed(bool bFix, ushort wGroupIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Encoder Control

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCRoutine(ENCISR pfnEncoderRoutine, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCFilterClock(ushort wDivider, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCInputRate(ushort wInputRate, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_ClearENCCounter(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetENCValue(ref int plValue, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCLatchType(ushort wType, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCLatchSource(ushort wSource, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetENCLatchValue(ref int plLatchValue, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableENCIndexTrigger(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableENCIndexTrigger(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetENCIndexStatus(ref ushort pwStatus, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCCompValue(int lValue, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableENCCompTrigger(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableENCCompTrigger(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetENCGearRate(double dfGearRate, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetGantryLock(ushort wMChannel, ushort wSChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetGantryGain(int wPGain, int wIGain, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetGantryErrorLimit(int wError, ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Timer & Watch Dog Control
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetTMRRoutine(TMRISR pfnLIORoutine, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetTimer(uint dwValue, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableTimer(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableTimer(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableTimerTrigger(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableTimerTrigger(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetWatchDogTimer(uint wValue, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetWatchDogResetPeriod(uint dwValue, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableWatchDogTimer(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableWatchDogTimer(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_RefreshWatchDogTimer(ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Remote Input/Output Control

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetRIORoutine(RIOISR pfnRIORoutine, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableRIOSetControl(ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableRIOSetControl(ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableRIOSlaveControl(ushort wSet, ushort wSlave, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableRIOSlaveControl(ushort wSet, ushort wSlave, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetRIOTransStatus(ref ushort pwStatus, ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetRIOMasterStatus(ref ushort pwStatus, ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetRIOSlaveStatus(ref uint pwStatus, ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetRIOSlaveFail(ref uint pdwStatus, ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetRIOInputValue(ref ushort pwValue, ushort wSet, ushort wSlave, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetRIOOutputValue(ushort wValue, ushort wSet, ushort wSlave, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetRIOTransError(ushort wTime, ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetRIOTriggerType(ushort wType, ushort wSet, ushort wDigitalInput, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableRIOInputTrigger(ushort wSet, ushort wDigitalInput, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableRIOInputTrigger(ushort wSet, ushort wDigitalInput, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableRIOTransTrigger(ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableRIOTransTrigger(ushort wSet, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetRIOOutputValue(ref ushort pwValue, ushort wSet, ushort wPort, ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // D/A Converter Control

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDACOutput(float fVoltage, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDACTriggerOutput(float fVoltage, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetDACTriggerSource(uint dwSource, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableDACTriggerMode(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableDACTriggerMode(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_StartDACConv(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_StopDACConv(ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // A/D Converter Control

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCRoutine(ADCISR pfnADCRoutine, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCConvType(ushort wConvType, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetADCConvType(ref ushort pwConvType, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCConvMode(ushort wConvMode, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetADCInput(ref float pfInput, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCSingleChannel(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetADCWorkStatus(ref ushort pwSTatus, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableADCConvTrigger(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableADCConvTrigger(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCTagChannel(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableADCTagTrigger(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableADCTagTrigger(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCCompMask(ushort wMask, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCCompType(ushort wCompType, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetADCCompValue(float fValue, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetADCCompValue(ref float pfValue, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableADCCompTrigger(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableADCCompTrigger(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EnableADCConvChannel(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_DisableADCConvChannel(ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_StartADCConv(ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_StopADCConv(ushort wCardIndex);


        //////////////////////////////////////////////////////////////////////////////
        // Robot Func.
        // Customize kinematics transformation rules
        //

        // Point-to-Point Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_PtP_V6(double j0, double j1, double j2, double j3, double j4, double j5, double j6, double j7, ushort wGroupIndex = 0, UInt32 dwAxisMask = EtherCATSeries.MCCL.IMP_AXIS_ALL);

        // Linear Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_Line_V6(double x, double y, double z, double rx, double ry, double rz, bool bOverrideMotion = false, ushort wGroupIndex = 0, UInt32 dwAxisMask = EtherCATSeries.MCCL.IMP_AXIS_ALL);

        // Circular Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_Arc_V6(double x0, double y0, double z0, double x1, double y1, double z1, double rx, double ry, double rz, UInt32 posture = 0, ushort wGroupIndex = 0, UInt32 dwAxisMask = EtherCATSeries.MCCL.IMP_AXIS_ALL);
        // x0, ref. point for x axis
        // y0, ref. point for y axis
        // z0, ref. point for z axis
        // x1, target point for x axis
        // y1, target point for y axis
        // z1, target point for z axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation

        // Circular Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_ArcTheta_V6(double cx, double cy, double cz, double nv0, double nv1, double nv2, double theta, double rx, double ry, double rz, UInt32 posture = 0, ushort wGroupIndex = 0, UInt32 dwAxisMask = EtherCATSeries.MCCL.IMP_AXIS_ALL);
        // cx,   center point for x axis
        // cy,   center point for y axis
        // cz,   center point for z axis
        // nv0,  normal vector for x direction
        // nv1,  normal vector for y direction
        // nv2,  normal vector for z direction
        // theta,degree, +/- stands for direction
        // rx,   target point for x orientation
        // ry,   target point for y orientation
        // rz,   target point for z orientation

        // Circular Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleXY_V6(double cx, double cy, double rx, double ry, double rz, byte byCirDir, UInt32 posture = 0, ushort wGroupIndex = 0);
        // cx, center point for x axis
        // cy, center point for y axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation

        // Circular Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleYZ_V6(double cy, double cz, double rx, double ry, double rz, byte byCirDir, UInt32 posture = 0, ushort wGroupIndex = 0);
        // cy, center point for y axis
        // cz, center point for z axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation
        // CW or CCW

        // Circular Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_CircleZX_V6(double cz, double cx, double rx, double ry, double rz, byte byCirDir, UInt32 posture = 0, ushort wGroupIndex = 0);
        // cz, center point for z axis
        // cx, center point for x axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation
        // CW or CCW

        // Circular Motion
        [DllImport(LibNameVersion)]
        public static extern int MCC_Circle_V6(double x0, double y0, double z0, double x1, double y1, double z1, double rx, double ry, double rz, UInt32 posture = 0, ushort wGroupIndex = 0, UInt32 dwAxisMask = EtherCATSeries.MCCL.IMP_AXIS_ALL);
        // x0, 1st ref. point for x axis
        // y0, 1st ref. point for y axis
        // z0, 1st ref. point for z axis
        // x1, 2nd ref. point for x axis
        // y1, 2nd ref. point for y axis
        // z1, 2nd ref. point for z axis
        // rx, target point for x orientation
        // ry, target point for y orientation
        // rz, target point for z orientation


        //////////////////////////////////////////////////////////////////////////////
        // Obsolete functions in earlier MCCL version (just for compatibility)

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineX(double dfX, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineY(double dfY, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineZ(double dfZ, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineU(double dfU, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineV(double dfV, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineW(double dfW, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineA(double dfA, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_LineB(double dfB, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetMachParam(ref SYS_MACH_PARAM pstMachParam, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetMachParam(ref SYS_MACH_PARAM pstMachParam, ushort wChannel, ushort wCardIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_UpdateMachParam();

        [DllImport(LibNameVersion)]
        public static extern int MCC_AbortMotion(ushort wGroupIndex, bool bAfterCurCmd);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetInPosCheckTime(ushort wCheckTime, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetInPosStableTime(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetInPosTolerance(ushort lTolerance0, ushort lTolerance1, ushort lTolerance2, ushort lTolerance3, ushort lTolerance4, ushort lTolerance5, ushort lTolerance6, ushort lTolerance7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetInPosTolerance(ref ushort plTolerance0, ref ushort plTolerance1, ref ushort plTolerance2, ref ushort plTolerance3, ref ushort plTolerance4, ref ushort plTolerance5, ref ushort plTolerance6, ref ushort plTolerance7, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_SetOverSpeed(double dfRate, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_GetOverSpeed(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern double MCC_ChangeFeedSpeed(double dfSpeed, ushort wGroupIndex);

        // Set/Get Coordinate Unit
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetUnit(int nUnitMode, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_GetUnit(ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetARIOClockDivider(ushort wDivider, ushort wSet, ushort wCardIndex);


        // MCCL system fxns for RTX
        [DllImport(LibNameVersion)]
        public static extern bool MCC_StartEcServer();

        [DllImport(LibNameVersion)]
        public static extern int MCC_RtxInit(int nAxis);

        [DllImport(LibNameVersion)]
        public static extern int MCC_RtxClose();

        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatHome();
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetHomeMode(int nMode, int nChannel);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetHomeZeroSpeed(int nSpeed, int nChannel);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetHomeSwitchSpeed(int nSpeed, int nChannel);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetHomeAxis(byte cAxisX, byte cAxisY = 0, byte cAxisZ = 0, byte cAxisU = 0, byte cAxisV = 0, byte cAxisW = 0, byte cAxisA = 0, byte cAxisB = 0,
                                        byte cAxisX1 = 0, byte cAxisY1 = 0, byte cAxisZ1 = 0, byte cAxisU1 = 0, byte cAxisV1 = 0, byte cAxisW1 = 0, byte cAxisA1 = 0, byte cAxisB1 = 0);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatGetGoHomeStatus();

        [DllImport(LibNameVersion)]
        public static extern int MCC_SetIPOUnit(int Unit);
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetBusTime(int usecTime);
        [DllImport(LibNameVersion)]
        public static extern int MCC_SetIPOInterval(int usecTime);
        [DllImport(LibNameVersion)]
        public static extern int MCC_GetIoStatus(ref byte Value, int nIndex);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetControlCode(ushort wStatus, int nChannel);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatGetStatusCode(ref ushort pwControlCode, int nChannel);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatGetControlCode(ref ushort pwStatus, int nChannel);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetTargetPos(int nPosition, int nChannel);
        //[DllImport(LibNameVersion)]
        //public static extern int MCC_EcatSetModeOfOp(int nOperation, int nChannel);


        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatCoeSdoDownload(uint dwSlaveId, ushort wObIndex, byte byObSubIndex, System.IntPtr pbyData, uint dwDataLen);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatCoeSdoUpload(uint dwSlaveId, ushort wObIndex, byte byObSubIndex, System.IntPtr pbyData, uint dwDataLen, ref uint pdwOutDataLen);


        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatStartAction(uint dwSlaveId);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatGetTargetPos(ref int nTargetPos, uint dwSlaveId);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetOutput(uint dwSlaveId, uint dwOutData);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatGetOutput(uint dwSlaveId, ref uint dwInData);
        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatGetInput(uint dwSlaveId, ref uint dwInData);

        [DllImport(LibNameVersion)]
        public static extern int MCC_EcatSetOutputEnqueue(uint dwSlaveId, uint dwOutData, ushort wGroupIndex);

        [DllImport(LibNameVersion)]
        public static extern bool MCC_EcatReset(uint dwSlaveId);


        #endregion Functions
    }
}