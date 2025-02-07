namespace Antikythera.RealGear.EclipseTrain.Exeligmos
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
    public class H2Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="H2Gear"/> class. Using the modeled (calculated) parameters from the authors
        /// listed in Table 3, p. 224, Table 9, p.229.
        /// </summary>
        public H2Gear()
            : base("H2", 15, 1.122, 3.45, 1.435)
        { }

    }
}
