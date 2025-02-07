namespace Antikythera.RealGear.PlanetaryTrain.Saturn
{
    /// <summary>
    /// The gear is driven at the teeth by B1-223 and contains the pin of the pin-in-slot.
    /// </summary>
    public class S1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="S1Gear"/> class.
        /// </summary>
        public S1Gear()
            : base("S1", 60, 1.122, 15.78, 1.652)
        { } // The tip radius is copied from gear H1.
    }
}
