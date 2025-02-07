namespace Antikythera.RealGear.PlanetaryTrain.Mars
{
    /// <summary>
    /// The gear is driven at the teeth by B1-223 and contains the pin of the pin-in-slot.
    /// </summary>
    public class Ma1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ma1Gear"/> class.
        /// </summary>
        public Ma1Gear()
            : base("Ma1", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
