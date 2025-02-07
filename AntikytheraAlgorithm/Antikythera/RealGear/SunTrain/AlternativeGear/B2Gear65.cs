namespace Antikythera.RealGear.SunTrain.AlternativeGear
{
    /// <summary>
    /// The "Sun gear" is essentially operated from the hand operated crank (B1) 
    /// and drives the rest of the gear sets. The sun gear is B2 and it has 65 teeth.
    /// </summary>
    public class B2Gear65 : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B2Gear65"/> class.
        /// </summary>
        public B2Gear65()
            : base("B2-65", 65, 1.122, 15.5, 1.4983)
        { }
    }
}
