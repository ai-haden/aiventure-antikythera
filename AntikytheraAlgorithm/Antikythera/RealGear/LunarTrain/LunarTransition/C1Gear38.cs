namespace Antikythera.RealGear.LunarTrain.LunarTransition
{
    /// <summary>
    /// The Moon train follows on from the sun train through gears B2/C1 * C2/D1 * D2/E2 than transferring 
    /// through the idling E3 and E4 to E5. The mechanism of E5/K1 * K2/E6 is interesting in that K1 and K2 
    /// are not coaxial and in using E4 as a platform they are in effect epicyclic. By employing a pin and 
    /// slot the gears can induce a varied motion imitating the eccentric behaviour of the moon's orbit. The 
    /// motion then passes through to E1/B3 and through the B2 gear and sun indicator shaft to the moon spindle. 
    /// The use of bevel gearing allows the moon to rotate indicating the phase as well as the location. The total 
    /// ratio in relation to the sun gear is 13.37.
    /// </summary>
    public class C1Gear38 : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="C1Gear38"/> class.
        /// </summary>
        /// <remarks></remarks>
        public C1Gear38()
            : base("C1-38", 38, 1.122, 11.21, 1.851)
            // A corrected value of 1.7031 is here. Reverting to the data from source [2].
            // Old tip radius value is 10.3. Revising to agree with data from source [2].
        { }
    }
}
