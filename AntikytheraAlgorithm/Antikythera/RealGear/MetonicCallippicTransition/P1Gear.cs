namespace Antikythera.RealGear.MetonicCallippicTransition
{
    /// <summary>
    /// The Callippic train follows on from the Metonic. Gears N2/P1 * P2/O1 
    /// with a total ratio to the sun gear of 0.0132.
    /// </summary>
    public class P1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="P1Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public P1Gear()
            : base("P1", 60, 1.122, 13.8, 1.444)
        {
            
        }
    }
}
