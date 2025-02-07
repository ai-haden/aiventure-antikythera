namespace Antikythera.RealGear.CalendarTransition
{
    /// <summary>
    /// This gear is from the missing set by authors [2].
    /// </summary>
    public class M3Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="M3Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public M3Gear()
            : base("M3", 27, 1.122, 7.101, 1.649)
        { }
    }
}
