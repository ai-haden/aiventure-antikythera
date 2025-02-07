namespace Antikythera.RealGear.LunarTrain.LunarPhase.Alternate
{
    /// <summary>
    /// This gear is shown for the lunar phase display from Freeth 2008.
    /// </summary>
    public class MB2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MB2Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public MB2Gear()
            : base("MB2", 20, 1.122, 5.26, 1.646)
        { }
    }
}
