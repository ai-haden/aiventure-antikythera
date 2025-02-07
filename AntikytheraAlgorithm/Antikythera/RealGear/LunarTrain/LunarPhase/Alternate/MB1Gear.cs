namespace Antikythera.RealGear.LunarTrain.LunarPhase.Alternate
{
    /// <summary>
    /// This gear is shown for the lunar phase display from Freeth 2008.
    /// </summary>
    public class MB1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MB1Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public MB1Gear()
            : base("MB1", 27, 1.122, 7.101, 1.649)
        { }
    }
}
