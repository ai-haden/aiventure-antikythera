namespace Antikythera.RealGear.CalendarTransition
{
    /// <summary>
    /// The Metonic train is driven from the sun gear through B2/L1 * L2/M1 * M2/N1. 
    /// The total ratio for this train is 0.26.
    /// </summary>
    public class M2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="M2Gear"/> class. Using the modeled (calculated) parameters from [2]
        /// listed in Table 3, p. 224, Table 9, p.229.
        /// </summary>
        public M2Gear()
            : base("M2", 15, 1.122, 3.45, 1.435)
        { }

    }
}
