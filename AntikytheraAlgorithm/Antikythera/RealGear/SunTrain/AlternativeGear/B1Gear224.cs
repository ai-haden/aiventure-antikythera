namespace Antikythera.RealGear.SunTrain.AlternativeGear
{
    /// <summary>
    /// Here is a separate class for gears with a disparity in the number of teeth.
    /// </summary>
    public class B1Gear224 : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B1Gear224"/> class.
        /// </summary>
        public B1Gear224()
            : base("B1-224", 1.122, 224, 64.9, 1.853)
            // I will assume this chordal value to be the parent value. Was 1.8204, where did this come from?
            // Differential value is to fit the extra/missing tooth with the tip radius. A correction.
        { }
    }
}
