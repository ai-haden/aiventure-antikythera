
using System;

namespace GearStudy
{
    public class Gear
    {
        public string Name { get; set; }
        public double NumberOfTeeth { get; set; }
        public double ChordLength { get; set; }
        //public double InnerRadiusValue { get { return InnerRadius.Value; } }
        //public double InnerRadiusTolerance { get { return InnerRadius.Tolerance; } }
        public double TipRadiusValue { get; set; }
        //public double TipRadiusTolerance { get; set; }
        public double Circumference { get; set; }
        //public double TipRadiusValue { get { return TipRadius.Value; } }
        //public double TipRadiusTolerance { get { return TipRadius.Tolerance; } }

        //public static class TipRadius
        //{
        //    public double Value { get; set; }
        //    public double Tolerance { get; set; }
        //    public TipRadius()
        //    {
               
        //    } // Leave this sexiness for the next version.
            
        //}

        //internal class InnerRadius
        //{
        //    public static double Value { get; set; }
        //    public static double Tolerance { get; set; }
        //}
        protected double GetCircumference()
        {
            return Circumference = (2 * Math.PI) * TipRadiusValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gear"/> class.
        /// </summary>
        public Gear() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Gear"/> class with four arguments.
        /// </summary>
        /// <param name="name">The name of the gear.</param>
        /// <param name="numberOfTeeth">The number of teeth the gear contains.</param>
        /// <param name="tipRadius">The tip radius of the gear.</param>
        /// <param name="chordLength">The chord length of the gear.</param>
        public Gear(string name, double numberOfTeeth, double tipRadius, double chordLength)
        {
            Name = name;
            NumberOfTeeth = numberOfTeeth;
            TipRadiusValue = tipRadius;
            ChordLength = chordLength;
            Circumference = GetCircumference();
        }
        ///// <summary>
        ///// Initializes a new instance of the <see cref="Gear"/> class with five arguments.
        ///// </summary>
        ///// <param name="name">The name of the gear.</param>
        ///// <param name="numberOfTeeth">The number of teeth the gear contains.</param>
        ///// <param name="tipRadiusValue">The tip radius of the gear.</param>
        ///// <param name="tipRadiusTolerance">The tip radius tolerance of the gear.</param>
        ///// <param name="chordLength">The chord length of the gear.</param>
        ///// <remarks>Optional in the present coding effort.</remarks>
        //public Gear(string name, double numberOfTeeth, double tipRadiusValue, double tipRadiusTolerance, double chordLength)
        //{
        //    Name = name;
        //    NumberOfTeeth = numberOfTeeth;
        //    TipRadiusValue = tipRadiusValue;
        //    TipRadiusTolerance = tipRadiusTolerance;
        //    ChordLength = chordLength;
        //}
    }
}
