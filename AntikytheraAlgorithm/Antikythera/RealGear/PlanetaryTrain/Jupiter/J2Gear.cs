namespace Antikythera.RealGear.PlanetaryTrain.Jupiter
{
    /// <summary>
    /// The gear is driven by the shaft of J1 and contains slot of the pin-in-slot.
    /// </summary>
    public class J2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="J2Gear"/> class.
        /// </summary>
        public J2Gear()
            : base("J2", 83, 1.122, 21.829, 1.652)
        { } // The tip radius is derived as a percentage of size from gear J1.
    }
}
