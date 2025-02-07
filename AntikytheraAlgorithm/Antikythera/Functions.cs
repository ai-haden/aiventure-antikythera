using System;

namespace Antikythera
{
    public class Functions
    {
        /// <summary>
        /// Calculates the angular displacement for a single gear.
        /// </summary>
        /// <param name="inputRotation">The input rotation.</param>
        /// <param name="input">The input gear.</param>
        /// <returns></returns>
        public static double CalculateAngularDisplacement(double inputRotation, Gear input)
        {
            var radiusInput = input.TipRadiusValue; // in mm.
            var movement = inputRotation * (2 * Math.PI * radiusInput); // in mm.
            return movement;
        }
        /// <summary>
        /// Calculates the angular displacement for two gears, outputting the displacement.
        /// </summary>
        /// <param name="inputRotation">The input rotation.</param>
        /// <param name="input">The input gear.</param>
        /// <param name="output">The output gear.</param>
        /// <returns></returns>
        public static double CalculateAngularDisplacement(double inputRotation, Gear input, Gear output)
        {
            var radiusOutput = output.TipRadiusValue; // in mm.
            var ratio = CalculateGearRatio(input, output);
            var outputRotation = inputRotation * (ratio * (2 * Math.PI * radiusOutput)); // in mm.
            return outputRotation;
        }
        /// <summary>
        /// Calculates the gear ratio.
        /// </summary>
        /// <param name="drive">The driving gear.</param>
        /// <param name="slave">The slave gear.</param>
        public static double CalculateGearRatio(Gear drive, Gear slave)
        {
            var ratio = drive.TipRadiusValue / slave.TipRadiusValue;
            return ratio;
        }
        /// <summary>
        /// Calculates the mean gear ratio.
        /// </summary>
        /// <param name="drive">The driving gear.</param>
        /// <param name="slave">The slave gear.</param>
        public static double CalculateMeanGearRatio(Gear drive, Gear slave)
        {
            var ratio = drive.MeanGearRadius / slave.MeanGearRadius;
            return ratio;
        }
        /// <summary>
        /// Calculates the eccentricity.
        /// </summary>
        /// <param name="gear">The gear.</param>
        public static double CalculateEccentricity(Gear drive, Gear slave)
        {
            double eccentricity = 0;
            if (slave.PinSlot == true)
            {
                // An example to return a value.
                eccentricity = (drive.Circumference - drive.ChordLength) - (slave.Circumference - slave.ChordLength);
                
            }
            return slave.Eccentricity = eccentricity;
        }
        /// <summary>
        /// Calculates the number of teeth.
        /// </summary>
        /// <param name="gear">The gear.</param>
        /// <param name="chordLength">The calculated chord length.</param>
        public static double CalculateTeeth2(Gear gear, double chordLength)
        {
            var circumference = (2 * Math.PI * gear.TipRadiusValue); // in mm.
            var teeth = circumference / gear.ChordLength;
            return teeth;
        }
    }
}
