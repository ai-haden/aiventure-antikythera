namespace Antikythera.RealGear.PlanetaryTrain.Venus
{
    /// <summary>
    /// The gear is driven at the teeth by B1-223 and contains the pin of the pin-in-slot.
    /// </summary>
    public class V1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V1Gear"/> class.
        /// </summary>
        public V1Gear()
            : base("V1", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
