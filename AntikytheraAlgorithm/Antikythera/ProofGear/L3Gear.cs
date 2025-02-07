namespace Antikythera.ProofGear
{
    /// <summary>
    /// The third gear in the proof train.
    /// </summary>
    public class L3Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L3Gear"/> class.
        /// </summary>
        public L3Gear()
            : base("L3", 24, 3.175, 12, 3.175)// 0.5 mm error in TipRadius.
            
        { }
    }
}
