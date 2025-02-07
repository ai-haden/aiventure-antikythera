using System;

namespace FormControls.Utilities
{
    /// <summary>
    /// Mathematical functions
    /// </summary>
    public class Math : Object
    {
        public static float GetRadianFloat(float val)
        {
            return (float)(val * System.Math.PI / 180);
        }
        public static double GetRadian(double val)
        {
            return (val * System.Math.PI / 180);
        }
    }
}
