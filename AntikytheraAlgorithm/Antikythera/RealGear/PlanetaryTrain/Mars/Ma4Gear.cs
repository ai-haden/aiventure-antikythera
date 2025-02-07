namespace Antikythera.RealGear.PlanetaryTrain.Mars
{
    /// <summary>
    /// The gear (shares) is driven by the shaft of Ma3 and the teeth of Ma2. ??
    /// </summary>
    public class Ma4Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ma4Gear"/> class.
        /// </summary>
        public Ma4Gear()
            : base("Ma4", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
