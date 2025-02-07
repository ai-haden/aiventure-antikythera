using System;
using Antikythera.Interfaces;
using Antikythera.Position;

namespace Antikythera
{
    public class Gear : Time, IGear
    {
        public string Name { get; set; }
        public double NumberOfTeeth { get; set; }
        public double NumberOfTeethCalculated { get; set; }
        public double ToothHeight { get; set; }
        public double InnerRadiusValue { get; set; }
        public double MeanGearRadius { get; set; }
        public double TipRadiusValue { get; set; }
        public double ChordLength { get; set; }
        public double ChordLengthCalculated { get; set; }
        public double ChordLengthDifferential { get; set; }
        public double Circumference { get; set; }
        public double CheckScalar { get; set; }
        public Degree Degree { get; set; }
        public AngularPosition AngularPosition { get; set; }
        public double Eccentricity { get; set; }
        public bool FirstGear { get; set; }
        public bool LastGear { get; set; }
        public bool Crown { get; set; }
        public double? CrownRatio { get; set; }
        public bool SharesShaft { get; set; }
        public bool PinSlot { get; set; }
        /// <summary>
        /// Gets the input scalar ratio of the gear coupling scheme. This is the input number.
        /// </summary>
        public double? InputScalar { get; set; }
        /// <summary>
        /// Sets the output scalar ratio of the gear coupling scheme. This is the output number.
        /// </summary>
        public double? OutputScalar { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Gear"/> class.
        /// </summary>
        public Gear() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Gear"/> class with four arguments.
        /// </summary>
        /// <param name="name">The name of the gear.</param>
        /// <param name="numberOfTeeth">The number of teeth the gear contains.</param>
        /// <param name="toothHeight">The height of the tooth.</param>
        /// <param name="tipRadius">The tip radius of the gear.</param>
        /// <param name="chordLength">The chord length of the gear.</param>
        public Gear(string name, double numberOfTeeth, double toothHeight, double tipRadius, double chordLength)
        {
            Degree = new Degree();
            AngularPosition = new AngularPosition();
            Name = name;
            NumberOfTeeth = numberOfTeeth;
            ToothHeight = toothHeight;
            TipRadiusValue = tipRadius;
            ChordLength = chordLength;
            Circumference = GetCircumference();
            MeanGearRadius = CalculateMeanGearRadius(this);
            ChordLengthCalculated = CalculateChordLength(this);
            NumberOfTeethCalculated = CalculateTeeth(this);
        }
        /// <summary>
        /// Calculates the mean gear radius.
        /// </summary>
        /// <param name="gear">The gear.</param>
        protected static double CalculateMeanGearRadius(Gear gear)
        {
            var innerRadius = gear.TipRadiusValue - gear.ToothHeight;
            gear.InnerRadiusValue = innerRadius;
            var meanRadius = 0.5 * (gear.TipRadiusValue + gear.InnerRadiusValue);
            gear.MeanGearRadius = meanRadius;
            return meanRadius;
        }
        /// <summary>
        /// Calculates the chord length of the gear.
        /// </summary>
        /// <param name="gear">The gear.</param>
        public static double CalculateChordLength(Gear gear)
        {
            double circumference;
            double calculatedChordLength;
            if (gear.Crown)
            {
                circumference = (2 * Math.PI * gear.TipRadiusValue); // in mm.
                calculatedChordLength = circumference / gear.NumberOfTeeth;
                SetCrownRatio(gear, calculatedChordLength);// A primitive error ratio calculation.
                gear.ChordLengthCalculated = calculatedChordLength; // Set the calculated chord length, keeping the specification value.
                //chordLength = gear.ChordLength + gear.CrownRatio; // in mm.
                //SetRevisedChordLength(gear, chordLength);
            }
            else
            {
                circumference = (2 * Math.PI * gear.TipRadiusValue); // in mm.
                calculatedChordLength = circumference / gear.NumberOfTeeth;
                SetChordDifferential(gear, calculatedChordLength);
                gear.ChordLengthCalculated = calculatedChordLength; // Set the calculated chord length, keeping the specification value.
            }

            return calculatedChordLength;
        }
        public static double? SetCrownRatio(Gear gear, double calculatedChord) // <-- what is this for?
        {
            var value = Math.Abs(calculatedChord - gear.ChordLength);
            gear.ChordLengthDifferential = value;
            return gear.CrownRatio = value;
        }
        public static double SetChordDifferential(Gear gear, double calculatedChord)
        {
            var value = Math.Abs(calculatedChord - gear.ChordLength);
            return gear.ChordLengthDifferential = value;
        }
        //public static double SetCorrectedChordRatio(Gear gear, double calculatedChord)
        //{
        //    var value = Math.Abs(calculatedChord - gear.ChordLength);
        //    return gear.ChordError = value;
        //}
        public static double SetRevisedChordLength(Gear gear, double chord)
        {
            return gear.ChordLength = chord;
        }
        /// <summary>
        /// Calculates the number of teeth.
        /// </summary>
        /// <param name="gear">The gear.</param>
        public static double CalculateTeeth(Gear gear)
        {
            // Check tooth-count with specification.
            var teethSpecification = gear.Circumference / gear.ChordLength;
            // Check tooth-count from calculation. This will agree with what is stored in the Gear object.
            var teethCalculated = gear.Circumference / gear.ChordLengthCalculated;
            return teethSpecification;
        }
        /// <summary>
        /// Stores the check calculated by unsure what to do with it.
        /// </summary>
        public double StoreCheck(double check)
        {
            return CheckScalar = check;
        }
        /// <summary>
        /// Stores the mean radius of the gear.
        /// </summary>
        public double StoreMeanRadius(double value)
        {
            return MeanGearRadius = value;
        }
        /// <summary>
        /// Gets the circumference.
        /// </summary>
        public double GetCircumference()
        {
            return Circumference = (2 * Math.PI) * TipRadiusValue;
        }
        /// <summary>
        /// Stores the output scalar (percentage) of a concentric set of moving gears.
        /// </summary>
        public double? StoreInputScalar(double value)
        {
            return InputScalar = value;
        }
        /// <summary>
        /// Stores the output scalar (percentage) of a concentric set of moving gears.
        /// </summary>
        public double? StoreOutputScalar(double value)
        {
            return OutputScalar = value;
        }
        
        #region Commented
        //
        //public double GetRotationalPositionCircle { get; set; }
        //public double SetRotationalPositionCircle { get; set; }
        //public double Rotation { get; set; }
        //public double Percentage { get; set; }
        ///// <summary>
        ///// Stores the rotation in degrees. This is done by the class more simply.
        ///// </summary>
        ///// <param name="rotation">The rotation in degrees.</param>
        //protected double StoreRotation(double rotation)
        //{
        //    return Rotation = rotation;
        //}
        ///// <summary>
        ///// Reveals the percentange of something that I don't know exactly just yet. But it seems important!
        ///// </summary>
        ///// <param name="value">The value.</param>
        //protected double RevealPercentange(double value)
        //{
        //    return Percentage = value;
        //}
        //public double SetRotationalPosition(Time particle, double period)
        //{
        //    #region commented
        //    //const double tickCircle = 1 / 360;
        //    //var next = particle.Second + 1;
        //    //var d = next++;
        //    //// need some kind of loop to hold the runtime.
        //    //// loop using the period argument
        //    //for (var i = 0; i < period; i++)
        //    //{
        //    //    d = tickCircle + tickCircle;
        //    //    SetRotationalPositionCircle = d;
        //    //}
        //    #endregion

        //    //particle.Timer.Interval = 1000;
        //    //Timer.Start(); // Where best to put this?
        //    particle.Second = Degree.SetIncrement(particle);
        //    SetRotationalPositionCircle = particle.Second;
        //    return SetRotationalPositionCircle;
        //}

        //public double GetRotationalPosition()
        //{


        //    return GetRotationalPositionCircle;
        //}
        ///// <summary>
        ///// Stores the whole output percentage.
        ///// </summary>
        ///// <param name="value">The value.</param>
        //
        #endregion
    }
}
