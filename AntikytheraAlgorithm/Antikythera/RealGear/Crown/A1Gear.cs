namespace Antikythera.RealGear.Crown.Input
{
    /// <summary>
    /// The input gear where the handle is attached to begin the motions. This is a crown gear.
    /// </summary>
    /// <remarks>It says in Table 1 this gear has 48 teeth.</remarks>
    public class A1Gear : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="A1Gear"/> class. Found error in Table10 data.
        /// </summary>
        public A1Gear()
            : base("A1", 48, 1.122, 13.6, 1.444)// Crown tip radius = 0.965.
            // Data as given by [2] has an error in table format:
            // Adjusted by moving columns one to the left, wrapped text.
            // HABIT: Take the mean average of tip radius from [2] as a starting point.
            // RELEVANT?-->Error in check calculation demands, radius change 13.6 +/- 0.2
            // WHAT IS THIS?-->Chord length shows error of 0.311mm.
            //
            // From the assumption of equal chord lengths for meshing gears, the value from [2] is changed to two decimal places
            // of the B1 gear. Chordal length was 1.444.
            //
            // Have introduced a correction for the chord length. Keep data values here sourced.

            // NOTE:  Must surmise the tip radius when using this gear. Also surmise the tooth height from the other gears.
        { }
    }
}
