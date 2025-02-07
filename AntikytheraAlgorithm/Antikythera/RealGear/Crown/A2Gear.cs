namespace Antikythera.RealGear.Crown
{
    /// <summary>
    /// The input gear where the handle is attached to begin the motions. This is a crown gear.
    /// </summary>
    /// <remarks>It says in Table 1 this gear has 48 teeth.</remarks>
    public class A2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="A2Gear"/> class.
        /// </summary>
        public A2Gear()
            : base("A2", 20, 1.122, 5.667, 1.646) // Crown tip radius = 1.137.
            // Must surmise the tip radius when using this gear.
        { }
    }
}
