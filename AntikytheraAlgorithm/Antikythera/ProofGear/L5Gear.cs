namespace Antikythera.ProofGear
{
    /// <summary>
    /// The fifth gear in the proof train.
    /// </summary>
    public class L5Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L5Gear"/> class.
        /// </summary>
        public L5Gear()
            : base("L5", 16, 3.175, 8, 3.175)// 0.5 mm error in TipRadius.
            
        { }
    }
}
