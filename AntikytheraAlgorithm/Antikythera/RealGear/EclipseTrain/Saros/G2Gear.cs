namespace Antikythera.RealGear.EclipseTrain.Saros
{
    /// <summary>
    /// The Moon train follows on from the sun train through gears B2/C1 * C2/D1 * D2/E2 than transferring 
    /// through the idling E3 and E4 to E5. The mechanism of E5/K1 * K2/E6 is interesting in that K1 and K2 
    /// are not coaxial and in using E4 as a platform they are in effect epicyclic. By employing a pin and 
    /// slot the gears can induce a varied motion imitating the eccentric behaviour of the moon's orbit. The 
    /// motion then passes through to E1/B3 and through the B2 gear and sun indicator shaft to the moon spindle. 
    /// The use of bevel gearing allows the moon to rotate indicating the phase as well as the location. The total 
    /// ratio in relation to the sun gear is 13.37.
    /// 
    /// The Exeligmos train follows on from the Saros train. Gears G2/H1 * H2/I1 with a total ratio to the sun gear of 0.018.
    /// </summary>
    public class G2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="G2Gear"/> class. Using the modeled parameters from the authors
        /// listed in Table 1, p. 221, Table 9, p.229.  This gear is swapped from G1 from Price and Wright.
        /// </summary>
        public G2Gear()
            : base("G2", 20, 1.122, 5.26, 1.646)
        { }
    }
}
