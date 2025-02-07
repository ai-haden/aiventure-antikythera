namespace Antikythera.RealGear.Metonic
{
    /// <summary>
    /// This gear is from the missing set and belongs somewhere to be determined.
    /// </summary>
    public class N3Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="N3Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public N3Gear()
            : base("N3", 57, 1.122, 14.991, 1.652)
        { }
    }
}
