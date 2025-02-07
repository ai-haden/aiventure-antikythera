namespace Antikythera.RealGear.PlanetaryTrain.Mercury
{
    /// <summary>
    /// The gear (shares) is driven by the shaft of Me3 and the teeth of Me2. ??
    /// </summary>
    public class Me4Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Me4Gear"/> class.
        /// </summary>
        public Me4Gear()
            : base("Me4", 86, 1.122, 22.618, 1.652)
        { } // The tip radius is derived as a percentage of size from gear M1.
            // The gear property values here are preliminary.
    }
}
