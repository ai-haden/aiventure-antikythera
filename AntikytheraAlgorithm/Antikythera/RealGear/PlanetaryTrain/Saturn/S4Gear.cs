namespace Antikythera.RealGear.PlanetaryTrain.Saturn
{
    /// <summary>
    /// The gear (shares) is driven by the shaft of S3 and the teeth of S2. ??
    /// </summary>
    public class S4Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="S4Gear"/> class.
        /// </summary>
        public S4Gear()
            : base("S4", 57, 1.122, 14.991, 1.652)
        { }  // The tip radius is derived as a percentage of teeth-size from gear S1, S3.
    }
}
