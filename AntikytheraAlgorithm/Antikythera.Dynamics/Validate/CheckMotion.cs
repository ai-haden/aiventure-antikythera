using System.Collections.Generic;

namespace Antikythera.Dynamics.Validate
{
    public static class CheckMotion
    {
        /// <summary>
        /// Verifies the rotation, using sin and cos.
        /// </summary>
        /// <param name="gears">The list of gears.</param>
        /// <param name="gearDict">The dictionary of gears.</param>
        /// <param name="rotation">The rotation of the gears, in degrees.</param>
        public static string VerifyRotation(List<Gear> gears, Dictionary<int, Gear> gearDict, double rotation)
        {
            var result = "0";
            // how do I get a representation of what rotations are occuring?
            return result;
        }
    }
}
