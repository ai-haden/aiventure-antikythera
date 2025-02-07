namespace Antikythera.RealGear.LunarTrain.LunarPhase
{
    /// <summary>
    /// This gear is from the lunar phase display following on from the shaft from B3.
    /// </summary>
    public class B0Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B0Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230.
        /// </summary>
        public B0Gear()
            : base("B0", 27, 1.122, 7.101, 1.649)
        { }
    }
}
