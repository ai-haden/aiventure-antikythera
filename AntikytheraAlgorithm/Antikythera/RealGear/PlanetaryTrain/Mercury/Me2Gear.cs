namespace Antikythera.RealGear.PlanetaryTrain.Mercury
{
    /// <summary>
    /// The gear is driven by the shaft of Me1 and contains slot of the pin-in-slot.
    /// </summary>
    public class Me2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Me2Gear"/> class.
        /// </summary>
        public Me2Gear()
            : base("Me2", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
