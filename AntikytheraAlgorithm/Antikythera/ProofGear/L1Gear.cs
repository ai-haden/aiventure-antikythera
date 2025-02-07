namespace Antikythera.ProofGear
{
    /// <summary>
    /// The input gear to the proof train. This is a crown gear.
    /// </summary>
    public class L1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L1Gear"/> class.
        /// </summary>
        public L1Gear()
            : base("L1", 24, 3.175, 12, 3.175)// 0.5 mm error in TipRadius.
            
        { }
    }
}
