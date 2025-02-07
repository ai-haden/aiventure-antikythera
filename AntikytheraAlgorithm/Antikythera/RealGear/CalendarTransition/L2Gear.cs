namespace Antikythera.RealGear.CalendarTransition
{
    /// <summary>
    /// The L2 gear.
    /// </summary>
    public class L2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L2Gear"/> class. Using the modeled (calculated) parameters from [2]
        /// listed in Table 3, p. 224, Table 9, p.229.
        /// </summary>
        public L2Gear()
            : base("L2", 53, 1.122, 13.939, 1.652)
        { }
    }
}
