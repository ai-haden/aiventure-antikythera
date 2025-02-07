namespace Antikythera.RealGear.Panhellenic
{
    /// <summary>
    /// The Callippic train follows on from the Metonic. Gears N2/P1 * P2/O1 
    /// with a total ratio to the sun gear of 0.0132.
    /// 
    /// This gear forms the Panhellenic games calendar. 
    /// From Freeth revised figure (Nature 2008).
    /// </summary>
    public class O1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="O1Gear"/> class. Using the modeled (calculated) parameters from [2]
        /// listed in Table 3, p. 224, Table 9, p.229.
        /// </summary>
        public O1Gear()
            : base("O1", 60, 1.122, 15.78, 1.444)
        {   // Tip radius was 15.78, where did this come from?
            
        }
    }
}
