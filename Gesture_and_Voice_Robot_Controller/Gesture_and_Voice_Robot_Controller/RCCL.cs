using System;
using System.Runtime.InteropServices;


namespace Robot
{
    using EtherCATSeries;

    /// <summary>
    /// Define some common structures for a robot
    /// </summary>
    /// 
    #region Structures

    [StructLayout(LayoutKind.Sequential)]
    public struct DH_PARAM
    {
        public double a1;
        public double a2;
        public double a3;
        public double d3;
        public double d4;
        public double d6;
        public double z_offset;

        public double J4J5_Coupling;
        public double J5J6_Coupling;

        public DH_PARAM(double pa1, double pa2, double pa3, double pd3, double pd4, double pd6, double pz_offset, double pj4j5, double pj5j6)
        {
            a1 = pa1;
            a2 = pa2;
            a3 = pa3;
            d3 = pd3;
            d4 = pd4;
            d6 = pd6;
            z_offset = pz_offset;

            J4J5_Coupling = pj4j5;
            J5J6_Coupling = pj5j6;
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct Euler_PARAM
    {
        public double lx;
        public double ly;
        public double lz;
        public double rx;
        public double ry;
        public double rz;

        public Euler_PARAM(double dx, double dy, double dz, double drx, double dry, double drz)
        {
            lx = dx;
            ly = dy;
            lz = dz;
            rx = drx;
            ry = dry;
            rz = drz;
        }
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct JNT_POS
    {
        public double J1;
        public double J2; 
        public double J3; 
        public double J4; 
        public double J5;
        public double J6;

        public JNT_POS(double j1, double j2, double j3, double j4, double j5, double j6)
        {
            J1 = j1; 
            J2 = j2; 
            J3 = j3; 
            J4 = j4; 
            J5 = j5; 
            J6 = j6;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CARTESIAN_POS
    {
        public double x; 
        public double y; 
        public double z; 
        public double rx; 
        public double ry;
        public double rz;

        public CARTESIAN_POS(double px, double py, double pz, double prx, double pry, double prz)
        {
            x = px;
            y = py;
            z = pz;
            rx = prx;
            ry = pry;
            rz = prz;
        }
    }

    #endregion Structures


    internal static class RCCL
    {
        #region Constants

        // EtherCAT version with RtxClientDll.dll
        public const string LibNameVersion = "MCCL_Client.dll";
        //public const string LibNameVersion = "MCCL_Clientd.dll";
        #endregion Constants


        #region Functions

        [DllImport(LibNameVersion)]
        public static extern void   rbt_SetDHParam(DH_PARAM dhp);

        [DllImport(LibNameVersion)]
        public static extern void   rbt_GetDHParam(ref DH_PARAM pdhp);

        [DllImport(LibNameVersion)]
        public static extern int    rbt_SetKinematicTrans(bool bSet);

        [DllImport(LibNameVersion)]
        public static extern int    rbt_FwdKinematics_V6(ref double pdfJntPos, ref double pdfCrtPos, ref System.UInt32 pdwPosture, System.UInt16 wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int    rbt_InvKinematics_V6(ref double pdfCrtPos, System.UInt32 dwPosture, ref double pdfJntPos, System.UInt16 wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int    rbt_GetCurJPos(ref double j0, ref double j1, ref double j2, ref double j3, ref double j4, ref double j5, ref double j6, ref double j7, System.UInt16 wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int    rbt_GetCurCPos(ref double x, ref double y, ref double z, ref double rx, ref double ry, ref double rz, ref System.UInt32 pdwPosture, System.UInt16 wGroupIndex = 0);

        [DllImport(LibNameVersion)]
        public static extern int    EnableTLMD(Euler_PARAM dptool, bool bEnTLMD);

        [DllImport(LibNameVersion)]
        public static extern int    rbt_PtP(double j0, double j1, double j2, double j3, double j4, double j5, double j6, double j7, System.UInt16 wGroupIndex = 0, System.UInt32 dwAxisMask = 0x00FF);

        #endregion Functions

        //public class SCR
        //{
        //    public SCR()
        //    {
        //        //...
        //    }

        //    /////////////////////////////////////////////////////////////////////
        //    // Variable definitions
        //    public const string LibNameVersion = "RobotDll.dll";


        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern void scrbt_SetDHParam(ref DH_PARAM dhp);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern void scrbt_GetDHParam(ref DH_PARAM dhp);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_SetKinematicTrans(bool bSet);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_FwdKine_V4(ref double pdfJntPos, ref double pdfCrtPos, ref System.UInt32 pdwPosture, System.UInt16 wGroupIndex = 0);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_InvKine_V4(ref double pdfCrtPos, System.UInt32 dwPosture, ref double pdfJntPos, System.UInt16 wGroupIndex = 0);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_PtP(double j0, double j1, double j2, double j3, System.UInt16 wGroupIndex = 0);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_Line(double x, double y, double z, double phi, bool boverridemotion = false, System.UInt16 wGroupIndex = 0, System.UInt32 IMP_AXIS_ALL = 0x00FF);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_GetCurJPos(ref double j0, ref double j1, ref double j2, ref double j3, ref double j4, ref double j5, ref double j6, ref double j7, System.UInt16 wGroupIndex = 0);

        //    [DllImport(LibNameVersion, CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        //    public static extern int scrbt_GetCurCPos(ref double x, ref double y, ref double z, ref double rx, ref double ry, ref double rz, ref System.UInt32 pdwPosture, System.UInt16 wGroupIndex = 0);
        //}

    }

}