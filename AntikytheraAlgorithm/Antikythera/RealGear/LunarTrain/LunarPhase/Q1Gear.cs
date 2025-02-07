namespace Antikythera.RealGear.LunarTrain.LunarPhase
{
    /// <summary>
    /// The Callippic train follows on from the Metonic. Gears N2/P1 * P2/O1 
    /// with a total ratio to the sun gear of 0.0132.
    /// 
    /// This gear forms the Callippic calendar. From Freeth revised figure (Nature 2008).
    /// 
    /// NOTE: This is a crown gear!
    /// 
    /// ======
    /// 
    /// This is now altered to the Q1 display for the lunar phase, as a crown gear coupled to B0.
    /// 
    /// There is also other graphics which show a mb1 and mb2 gear in place of Q1. I don't know if my
    /// </summary>
    public class Q1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Q1Gear"/> class. Calculated geometrical elements from the authors
        /// listed in Table 10, p. 230. This is one of the "missing" gears.
        /// </summary>
        public Q1Gear()
            : base("Q1", 60, 1.122, 13.8, 1.444)
        {
            
        }
    }
}
