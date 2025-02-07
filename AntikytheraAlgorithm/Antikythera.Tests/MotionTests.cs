using Antikythera;
using Antikythera.CalibrationGear;
using Antikythera.Dynamics;
using Antikythera.Dynamics.Validate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Antikythera.Tests
{
    [TestClass]
    public class MotionTests
    {
        [TestMethod]
        public void EccentricityTest()
        {
            var one = new GearOne();
            var two = new GearTwo();
            two.SharesShaft = true;
            two.PinSlot = true;

            var gearsList = new List<Gear> { one, two };
            Motion.GearMovement(255, gearsList);
            //Assert.AreEqual(two.Degree.Movement, 244.54);// A sample number until a calculation can be determined.

        }
        [TestMethod]
        public void InternalDictionaryTest()
        {
            var one = new GearOne();
            var two = new GearTwo();
            two.SharesShaft = true;

            var gearsList = new List<Gear> { one, two };
            Motion.GearMovement(255, gearsList);
            Assert.AreEqual(two.Degree.Movement, 255);
        }
        [TestMethod]
        public void SharingShaftGears()
        {
            var one = new GearOne();
            var two = new GearTwo();
            two.SharesShaft = true;

            var gearsList = new List<Gear> { one, two };
            var gearsDict = new Dictionary<int, Gear> { { 0, one }, { 1, two } };

            Motion.GearMovement(255, gearsList, gearsDict);
            Assert.AreEqual(two.Degree.Movement, 255);
        }
        [TestMethod]
        public void FourGearsMoving()
        {
            // try to verify the verify of the double-check routine of sin and cos.
            var one = new GearOne();
            var two = new GearTwo();
            var three = new GearThree();
            var four = new GearFour();

            // Add List<gear> to process. // This config: stop at Panhellenic pointer.
            var gearsList = new List<Gear>{one, two, three,four};
            var gearsDict = new Dictionary<int, Gear> {{0, one}, {1, two}, {2, three}, {3, four}};

            // What to do with this information?
            var what = Motion.GearMovement(270, gearsList, gearsDict);
            var todo = CheckMotion.VerifyRotation(gearsList, gearsDict, 360);
            // How about something visual which shows the output?
            var form = new Antikythera.Forms.MotionTestsForm();
            var calendar = new Antikythera.Forms.CalendarTestsForm();
            form.ImportGears(gearsList, 3);
            Application.Run(form);
            Application.Run(calendar);
        }
        [TestMethod]
        public void SunMoonGearsMoving()
        {
            var one = new Antikythera.RealGear.SunTrain.B1Gear223();
            // Continue here.
        }
    }
}
