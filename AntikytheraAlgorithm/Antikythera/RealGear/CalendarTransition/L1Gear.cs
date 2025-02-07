namespace Antikythera.RealGear.CalendarTransition
{
    /// <summary>
    /// The L1 gear.
    /// </summary>
    public class L1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="L1Gear"/> class. Using the modeled (calculated) parameters from [2]
        /// listed in Table 3, p. 224, Table 9, p.229.
        /// </summary>
        public L1Gear()
            : base("L1", 38, 1.122, 9.994, 1.651)
        { }
    }
}
