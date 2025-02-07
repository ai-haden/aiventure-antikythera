namespace Antikythera.RealGear.PlanetaryTrain.Mars
{
    /// <summary>
    /// The gear is driven by the teeth of Ma1.
    /// </summary>
    public class Ma3Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ma3Gear"/> class.
        /// </summary>
        public Ma3Gear()
            : base("Ma3", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
