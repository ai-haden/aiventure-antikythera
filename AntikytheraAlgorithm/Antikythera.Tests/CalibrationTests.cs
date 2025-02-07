using System.Collections.Generic;
using Antikythera.CalibrationGear;
using Antikythera.Dynamics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Antikythera.Tests
{
    /// <summary>
    /// Represented in the paper, this is the validation set of gear states.
    /// </summary>
    [TestClass]
    public class CalibrationTests
    {
        [TestMethod]
        public void CalibrateSharesShaft()
        {
            // Two gears who don't share a shaft.
            var one = new GearOne();
            var two = new GearTwo();
            var sansShaftList = new List<Gear> { one, two };
            var sansShaftDict = new Dictionary<int, Gear> { { 0, one }, { 1, two } };
            Motion.GearMovement(270, sansShaftList, sansShaftDict);
            // THe gears who share a shaft.
            var shareOne = new GearOne();
            var shareTwo = new GearTwo {SharesShaft = true};
            var shaftList = new List<Gear> { shareOne, shareTwo };
            var shaftDict = new Dictionary<int, Gear> { { 0, shareOne }, { 1, shareTwo } };
            Motion.GearMovement(270, shaftList, shaftDict);
        }
    }
}
