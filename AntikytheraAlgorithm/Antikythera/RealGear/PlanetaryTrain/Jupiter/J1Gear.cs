namespace Antikythera.RealGear.PlanetaryTrain.Jupiter
{
    /// <summary>
    /// The gear is driven at the teeth by B1-223 and contains the pin of the pin-in-slot.
    /// </summary>
    public class J1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="J1Gear"/> class.
        /// </summary>
        public J1Gear()
            : base("J1", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
    }
}
