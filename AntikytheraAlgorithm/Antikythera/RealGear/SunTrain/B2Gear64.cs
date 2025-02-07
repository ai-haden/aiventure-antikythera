namespace Antikythera.RealGear.SunTrain
{
    /// <summary>
    /// The "Sun gear" is essentially operated from the hand operated crank (B1) 
    /// and drives the rest of the gear sets. The sun gear is B2 and it has 64 teeth.
    /// </summary>
    public class B2Gear64 : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B2Gear64"/> class.
        /// </summary>
        public B2Gear64()
            : base("B2-64", 64, 1.122, 15.5, 1.445)
            // Was chord length of 1.5217. Where did this come from?
        { }
    }
}
