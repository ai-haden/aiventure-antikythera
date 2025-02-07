namespace Antikythera.RealGear.PlanetaryTrain.Venus
{
    /// <summary>
    /// The gear is driven by the shaft of V1 and contains slot of the pin-in-slot.
    /// </summary>
    public class V2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V2Gear"/> class.
        /// </summary>
        public V2Gear()
            : base("V2", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
