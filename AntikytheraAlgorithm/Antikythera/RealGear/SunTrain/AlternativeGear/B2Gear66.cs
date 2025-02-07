namespace Antikythera.RealGear.SunTrain.AlternativeGear
{
    /// <summary>
    /// The "Sun gear" is essentially operated from the hand operated crank (B1) 
    /// and drives the rest of the gear sets. The sun gear is B2 and it has 66 teeth.
    /// </summary>
    public class B2Gear66 : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B2Gear66"/> class.
        /// </summary>
        public B2Gear66()
            : base("B2-66", 66, 1.122, 15.5, 1.4756)
        { }
    }
}
