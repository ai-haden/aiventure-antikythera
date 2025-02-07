namespace Antikythera.RealGear.PlanetaryTrain.Venus
{
    /// <summary>
    /// The gear (shares) is driven by the shaft of V3 and the teeth of V2. ??
    /// </summary>
    public class V4Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="V4Gear"/> class.
        /// </summary>
        public V4Gear()
            : base("V4", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
