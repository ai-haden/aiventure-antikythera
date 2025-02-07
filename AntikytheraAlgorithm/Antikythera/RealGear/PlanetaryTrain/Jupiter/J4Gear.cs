namespace Antikythera.RealGear.PlanetaryTrain.Jupiter
{
    /// <summary>
    /// The gear (shares) is driven by the shaft of J3 and the teeth of J2. ??
    /// </summary>
    public class J4Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="J4Gear"/> class.
        /// </summary>
        public J4Gear()
            : base("J4", 86, 1.122, 19.988, 1.652)
        { }  // The tip radius is derived as a percentage of size from gear J3.
    }
}
