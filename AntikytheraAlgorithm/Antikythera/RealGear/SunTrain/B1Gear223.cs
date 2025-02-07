namespace Antikythera.RealGear.SunTrain
{
    /// <summary>
    /// The drive gear which drives the other gears.
    /// </summary>
    /// <remarks>This is the year gear.</remarks>
    public class B1Gear223 : Gear
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="B1Gear223"/> class.
        /// </summary>
        public B1Gear223()
            : base("B1-223", 223, 1.122, 64.9, 1.853)
            // Since this is the pivotal gear (receives movement from the external source), 
            // I will assume this chordal value to be the parent value. Was 1.8286, where did this come from?
            // Chordal length value is taken from [2].
            //
            // Therefore: all meshing gears MUST have an approximate chordal meshing error.
            // That is, at a maximum deviation where there is error in the motion.
        { }
    }
}
