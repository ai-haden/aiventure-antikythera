namespace Antikythera.RealGear.Metonic
{
    /// <summary>
    /// The Metonic train is driven from the sun gear through B2/L1 * L2/M1 * M2/N1. 
    /// The total ratio for this train is 0.26.
    /// 
    /// This gear forms the Metonic calendar.
    /// </summary>
    public class N1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="N1Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public N1Gear()
            : base("N1", 53, 1.122, 13.939, 1.652)
        { }
    }
}
