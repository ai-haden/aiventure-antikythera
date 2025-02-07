namespace Antikythera.RealGear.PlanetaryTrain.Mercury
{
    /// <summary>
    /// The gear is driven by the teeth of Me1.
    /// </summary>
    public class Me3Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Me3Gear"/> class.
        /// </summary>
        public Me3Gear()
            : base("Me3", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
