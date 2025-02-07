namespace Antikythera.RealGear.PlanetaryTrain.Venus
{
    /// <summary>
    /// The gear is driven by the teeth of V1.
    /// </summary>
    public class V3Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V3Gear"/> class.
        /// </summary>
        public V3Gear()
            : base("V3", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
