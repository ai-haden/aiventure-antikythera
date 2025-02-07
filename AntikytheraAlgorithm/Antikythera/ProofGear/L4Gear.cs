namespace Antikythera.ProofGear
{
    /// <summary>
    /// The fourth gear in the proof train.
    /// </summary>
    public class L4Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L4Gear"/> class.
        /// </summary>
        public L4Gear()
            : base("L4", 24, 3.175, 12, 3.175)// 0.5 mm error in TipRadius.
            
        { }
    }
}
