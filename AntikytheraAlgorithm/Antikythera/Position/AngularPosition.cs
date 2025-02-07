using Antikythera.Interfaces;

namespace Antikythera.Position
{
    public class AngularPosition : IAngularPosition
    {
        //public double Increment { get; set; }

        /// <summary>
        /// Gets or sets the total movement in millimeters.
        /// </summary>
        public double Movement { get; set; }

        public double SetIncrement(Time particle)
        {
            // All velocities will be in deg/sec.

            var sum = 1;
            return sum;
        }
    }
}