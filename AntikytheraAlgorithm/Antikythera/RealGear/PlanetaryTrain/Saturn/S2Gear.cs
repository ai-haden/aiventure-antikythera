namespace Antikythera.RealGear.PlanetaryTrain.Saturn
{
    /// <summary>
    /// The gear is driven by the shaft of S1 and contains slot of the pin-in-slot.
    /// </summary>
    public class S2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="S2Gear"/> class.
        /// </summary>
        public S2Gear()
            : base("S2", 59, 1.122, 15.517, 1.652)
        { }  // The tip radius is derived as a percentage of teeth-size from gear S1.
    }
}
