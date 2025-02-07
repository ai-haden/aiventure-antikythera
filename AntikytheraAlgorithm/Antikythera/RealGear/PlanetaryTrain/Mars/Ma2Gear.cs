namespace Antikythera.RealGear.PlanetaryTrain.Mars
{
    /// <summary>
    /// The gear is driven by the shaft of Ma1 and contains slot of the pin-in-slot.
    /// </summary>
    public class Ma2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ma2Gear"/> class.
        /// </summary>
        public Ma2Gear()
            : base("Ma2", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
