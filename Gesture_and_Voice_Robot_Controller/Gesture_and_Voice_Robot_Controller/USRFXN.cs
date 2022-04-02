using System;

namespace Calculation
{
    internal static class USRFXN
    {
        public static double DEG2RAD(double d)
        {
            return (d * Math.PI / 180.0);
        }

        public static double RAD2DEG(double r)
        {
            return (r * 180 / Math.PI);
        }

        // 限制最大和最小值
        public static double LIMITORANGE(this double value, double inclusiveMinimum, double inclusiveMaximum)
        {
            if (value < inclusiveMinimum) { return inclusiveMinimum; }
            if (value > inclusiveMaximum) { return inclusiveMaximum; }
            return value;
        }

    }
}
