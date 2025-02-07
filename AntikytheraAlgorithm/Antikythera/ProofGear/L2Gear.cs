namespace Antikythera.ProofGear
{
    /// <summary>
    /// The second gear in the proof train.
    /// </summary>
    public class L2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L2Gear"/> class.
        /// </summary>
        public L2Gear()
            : base("L2", 40, 3.175, 20, 3.175)// 0.5 mm error in TipRadius.
            // By the calculation, this gear DOES NOT have 36 teeth.
        { }
    }
}
