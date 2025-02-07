using System;
using System.Collections;
using System.Collections.Generic;
using Antikythera;
using Antikythera.CalibrationGear;
using Antikythera.Position;
using Antikythera.ProofGear;
using Antikythera.RealGear.CalendarTransition;
using Antikythera.RealGear.Callippic;
using Antikythera.RealGear.Crown;
using Antikythera.RealGear.Metonic;
using Antikythera.RealGear.MetonicCallippicTransition;
using Antikythera.RealGear.Panhellenic;
using Antikythera.RealGear.SunTrain;
using Antikythera.Dynamics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using L1Gear = Antikythera.ProofGear.L1Gear;
using L2Gear = Antikythera.ProofGear.L2Gear;

namespace GearRepresenationTests
{
    [TestClass]
    public class ProjectTests
    {
        const double Delta = 0.01;

        #region System tests
        [TestMethod]
        public void SanityCheck()
        {
            // Set the amount of rotation.
            const double rotationAngleDegree = 180;
            const double schemeRatio = rotationAngleDegree / 360;
            // Set the gear parameter space.
            var one = new GearOne();
            var two = new SanityGear();
            // Calculate the displacements.
            var initialDisplacement = Functions.CalculateAngularDisplacement(schemeRatio, one);
            var finalDisplacement = Functions.CalculateAngularDisplacement(schemeRatio, one, two);
            Assert.AreEqual(initialDisplacement, finalDisplacement);
        }
        [TestMethod]
        public void TeethCalcCheckOne()
        {
            const double delta = 0.2; // Separation is over 1.6. Added correction.
            var one = new GearOne();
            var teethOne = Functions.CalculateTeeth(one);
            Assert.AreEqual(one.NumberOfTeeth, teethOne, delta);
            // Check into keeping chord length as a value in the derived gear classes.
            var chordLength = Functions.CalculateChordLength(one); // Chord length is actually 1.6525.
            // Continue for tests of the other gears.
            var two = new GearTwo();
            var teethTwo = Functions.CalculateTeeth(two);
            Assert.AreEqual(two.NumberOfTeeth, teethTwo, delta);
            var sanity = new SanityGear();
            var teethSanity = Functions.CalculateTeeth(sanity);
            Assert.AreEqual(sanity.NumberOfTeeth, teethSanity, delta);
        }
        [TestMethod]
        public void TeethCalcCheckTwo()
        {
            const double delta = 0.2; // OK!
            var one = new GearThree();
            var teethOne = Functions.CalculateTeeth(one);
            Assert.AreEqual(one.NumberOfTeeth, teethOne, delta);
            // Check into keeping chord length as a value in the derived gear classes.
            var chordLength = Functions.CalculateChordLength(one);
            // Continue for tests of the other gears.
            var two = new GearFour();
            var teethTwo = Functions.CalculateTeeth(two);
            Assert.AreEqual(two.NumberOfTeeth, teethTwo, delta);
            var sanity = new SanityGear();
            var teethSanity = Functions.CalculateTeeth(sanity);
            Assert.AreEqual(sanity.NumberOfTeeth, teethSanity, delta);
        }
        #endregion

        #region Computational methods (PAPER)
        /// <summary>
        /// Processes the geometry of the input objects.
        /// </summary>
        /// <param name="gears">The list of gears.</param>
        public void GeometricAssumptionSunDuplication(List<Gear> gears)
        {
            const double delta = 0.01;

            foreach(var gear in gears)
            {
                var oneChordLength = Functions.CalculateChordLength(gear);
                Assert.AreEqual(gear.ChordLength, oneChordLength, delta);
                var oneTeeth = Functions.CalculateTeeth(gear);
                Assert.AreEqual(gear.NumberOfTeeth, oneTeeth, delta);
                gear.MeanGearRadius = Functions.CalculateMeanGearRadius(gear);
            }
        }
        /// <summary>
        /// Calculates the movement of the input objects.
        /// </summary>
        /// <param name="rotationDegree">The rotation degree at the input.</param>
        /// <param name="gears">The list of gears.</param>
        /// <param name="gearDict">The dictionary of gears.</param>
        public void GearTrainMovement(double rotationDegree, List<Gear> gears, Dictionary<int, Gear> gearDict)
        {
            var inputRatio = rotationDegree / 360;
            var last = gears.Count - 1;
            gears[0].InputScalar = inputRatio;
            gears[0].FirstGear = true;
            gears[last].InputScalar = inputRatio;
            gears[last].LastGear = true;

            IDictionaryEnumerator iterator = gearDict.GetEnumerator();
            for (var n = 0; n <= gears.Count; n++)
            {
                if (n == 0)
                iterator.MoveNext();
                if (n < gears.Count - 1)
                {
                    var firstGear = (Gear)iterator.Value;
                    iterator.MoveNext();
                    var secondGear = (Gear)iterator.Value;

                    //var toothCouplingRatio = Functions.CalculateGearRatio(firstGear, secondGear); // Change to mean values.
                    var meanGearCouplingRatio = Functions.CalculateMeanGearRatio(firstGear, secondGear); // dimensionless. <-- ERROR IS BETWEEN HERE...
                    var firstDisplacement = Functions.CalculateAngularDisplacement(inputRatio, firstGear);// in mm.
                    //var twoDisplacement = oneTwoRatio * two.Circumference;// in mm. This is an error.
                    var secondDisplacement = meanGearCouplingRatio * inputRatio * secondGear.Circumference;// in mm.
                    //var secondMeanDisplacement = meanGearCouplingRatio * inputRatio * secondGear.Circumference;// in mm.
                    var secondRotation = 360 * (1 / (secondGear.Circumference / secondDisplacement)); // in degrees.
                    //var secondMeanRotation = 360 * (1 / (secondGear.Circumference / secondMeanDisplacement)); // in degrees.

                    // Assign to the gear properties.
                    const double epsilon = 0.0001;
                    if (Math.Abs(firstGear.AngularPosition.Movement) < epsilon && Math.Abs(firstGear.Degree.Movement) < epsilon)
                    {
                        firstGear.Degree.Movement = rotationDegree;
                        firstGear.AngularPosition.Movement = firstDisplacement;
                    }
                    if (Math.Abs(secondGear.AngularPosition.Movement) < epsilon && Math.Abs(secondGear.Degree.Movement) < epsilon)
                    {
                        if (secondGear.SharesShaft)
                        {
                            secondGear.Degree.Movement = firstGear.Degree.Movement; // in degrees the rotation is the same. 
                            var displacement = (secondGear.Degree.Movement / 360) * secondGear.Circumference;// in mm.
                            secondGear.AngularPosition.Movement = displacement;// in mm.
                            // What do these checks mean?
                            var check1 = inputRatio * (firstDisplacement / firstGear.Circumference);// What do these numbers represent?
                            var check2 = inputRatio * (displacement / secondGear.Circumference);// What do these numbers represent?
                            // As unknown presently, store them on the objects.
                            firstGear.CheckScalar = check1;
                            secondGear.CheckScalar = check2;
                        }
                        else
                        {
                            secondGear.Degree.Movement = secondRotation;
                            secondGear.AngularPosition.Movement = secondDisplacement;                                       // <-- ...AND HERE 
                            // What are these checks meaning?
                            var check1 = inputRatio * (firstDisplacement / firstGear.Circumference);// What do these numbers represent?
                            var check2 = inputRatio * (secondDisplacement / secondGear.Circumference);// What do these numbers represent?
                            // As unknown presently, store them on the objects.
                            firstGear.CheckScalar = check1;
                            secondGear.CheckScalar = check2;
                        }
                        //Assert.AreEqual(secondRotation, secondMeanRotation, Delta);// Mean sure changes the rotations!
                    }

                    // Finally...
                    secondGear.OutputScalar = secondGear.CheckScalar;
                    // Step back one to find the ratio of the next gear coupling.
                    
                }
            }          
        }

        #endregion

        #region Temporal methods (PAPER)

        //[TestMethod]
        public void RuntimeTest(Gear one, Gear two, Gear three, Gear four)
        {
            //TrainFourGears();// For loop check.
            if (one.FirstGear)
            {
                // Attach velocity. Begin by moving rotation one degree per second.
                var sum = new Time();
                //one.SetRotationalPosition(
                // For runtim simulation, create a loop with a period.
                var period = 2000;
                var timer = new System.Timers.Timer(1000);
                timer.Start();
                //for (var i = 1; i < period; i++)
                //{
                //    timer.Start();
                //    sum.Second = DateTime.Now.Second;
                //    i++;
                //}

                while (timer.Interval < period)
                {
                    sum.Second = DateTime.Now.Second;
                    sum.Wait(1);
                    //System.Threading.Thread.Sleep(1000);
                    //sum.Second = DateTime.Now.Second;
                    timer.Interval++;
                }
                timer.Stop();
            }

        }

        #endregion  

        #region Calibration tests (PAPER)

        /// <summary>
        /// Represented in the paper, this is the calibration set of gears routine.
        /// </summary>
        /// <remarks>This is the initial calibration set.</remarks>
        [TestMethod]
        public void CalibrationGearTrain()
        {
            // Set the amount of initial rotation. 
            // The ratio of turns of a gear object; the input number, indicates the amount of turns at a crank handle.
            //const double rotationDegree = 90; // 1/4.
            //const double rotationDegree = 180; // 1/2.
            //const double rotationDegree = 270; // 3/4.
            //const double rotationDegree = 360; // 1.
            //const double rotationDegree = 720; // 2.
            const double rotationDegree = 1440; // 4.

            // Add gears to be tested.
            var one = new GearOne();
            var two = new GearTwo();
            var three = new GearThree();
            var four = new GearFour();
            var five = new GearFive();
            var six = new GearSix();
            var seven = new GearSeven();
            var eight = new GearEight();
            var nine = new GearNine();

            // Perform a check on the geometric assumption of the physical ratio of the represented object.
            GeometricAssumptionTestCalibration(one, two, three, four);

            // Upon pass, link the train according the published data (Nature 2008), using Efstathiou 2012.

            // Calculate the rotation of the nth gear.
            TrainTwoGears(rotationDegree, one, two);
            TrainThreeGears(rotationDegree, three, four, five);
            TrainFourGears(rotationDegree, six, seven, eight, nine);
            
            // Can go to automated runtime tests.
            //RuntimeTest(
            //DisplacementTest(

            // Hold for the Visual Studio watch and debugger.
            var hold = 0;

            // Considering Price's comments, how should time be best represented?
            

        }

       #endregion

        #region Calendar and Sun Train Calibration-Duplication tests (PAPER) - HERE

        /// <summary>
        /// Represented in the paper, this is the sun gear and indicator set routine.
        /// </summary>
        /// <remarks>This is the sun/timebase model set.</remarks>
        [TestMethod]
        public void FirstActualGearTrain()
        {
            // Set the amount of initial rotation. 
            // The ratio of turns of a gear object; the input number, indicates the amount of turns at a crank handle.
            //const double rotationDegree = 90; // 1/4.
            //const double rotationDegree = 180; // 1/2.
            //const double rotationDegree = 270; // 3/4.
            //const double rotationDegree = 360; // 1.
            const double rotationDegree = 720; // 2.
            //const double rotationDegree = 1080; // 3.
            //const double rotationDegree = 1440; // 4.

            // Add gears for the sun and date indicator.
            var a1 = new A1Gear {Crown = true};
            var b1223 = new B1Gear223();
            var b264 = new B2Gear64 {SharesShaft = true};
            var l1 = new L1Gear();
            var l2 = new L2Gear {SharesShaft = true};
            var m1 = new M1Gear();
            var m2 = new M2Gear {SharesShaft = true};
            var n1 = new N1Gear();
            var n2 = new N2Gear {SharesShaft = true};
            var o1 = new O1Gear();
            // think how to support three gears on one shaft.
            var n3 = new N3Gear();
            var p1 = new P1Gear();
            var p2 = new P2Gear {SharesShaft = true};
            var q1 = new Q1Gear();

            // Add List<gear> to process. // This config: stop at Panhellenic pointer.
            var gearsList = new List<Gear> {a1, b1223, b264, l1, l2, m1, m2, n1, n2, o1};
            var gearsDict = new Dictionary<int, Gear> {{0, a1}, {1, b1223}, {2, b264}, {3, l1},
                                                        {4, l2}, {5, m1}, {6, m2}, {7, n1}, {8, n2}, {9, o1}};

            GeometricAssumptionSunDuplication(gearsList);
            GearTrainMovement(rotationDegree, gearsList, gearsDict);
            // Perform a check on the geometric assumption of the physical ratio of the represented object in the code.
            //GeometricAssumptionSunDuplication(a1, b1223); // OK. Had to alter the chord length of the crown gear. NO! Only note the corrections.
            //GeometricAssumptionSunDuplication(a1, b1223, b264);
            //GeometricAssumptionSunDuplication(a1, b1223, b264, l1);
            // Upon pass, link the train according the published data (Nature 2008), using Efstathiou 2012.

            // Calculate the rotation of the nth gear.
            //TrainTwoGears(rotationDegree, a1, b1223); //--> for an input of one, output of 0.2096 is shown.
            //TrainThreeGears(rotationDegree, a1, b1223, b264);
            //TrainFourGears(rotationDegree, a1, b1223, b264, l1);

            // Can go to automated runtime tests.
            //RuntimeTest(
            //DisplacementTest(

            // Hold for the Visual Studio watch and debugger.
            var hold = 0;

            // Considering Price's comments, how should time be best represented?
        }
        /// <summary>
        /// The proof of the suppositional argument of gears performing calculations by their orientation.
        /// </summary>
        [TestMethod]
        public void AProofGearTrain()
        {
            //  Set the amount of initial rotation. 
            //  The ratio of turns of a gear object; the input number, 
            //  indicates the amount of turns at a crank handle.
            //const double rotationDegree = 90; // 1/4.
            const double rotationDegree = 180; // 1/2.
            //const double rotationDegree = 270; // 3/4.
            //const double rotationDegree = 360; // 1.
            //const double rotationDegree = 720; // 2.
            //const double rotationDegree = 1080; // 3.
            //const double rotationDegree = 1440; // 4.
            var one = new L1Gear() { Crown = true };
            var two = new L2Gear();
            var three = new L3Gear();
            var four = new L4Gear() { SharesShaft = true };
            var five = new L5Gear();

            // Add List<gear> to process. This config has four pointers.
            var gearsList = new List<Gear> {one, two, three, four, five};
            var gearsDict = new Dictionary<int, Gear> {{0, one}, {1, two}, {2, three}, {3, four}, {4, five}};

            //GeometricAssumptionSunDuplication(gearsList);
            //GearTrainMovement(rotationDegree, gearsList, gearsDict);

            // Create new methods.
            Motion.VerifyGearToothProperties(gearsList);
            Motion.GearMovement(rotationDegree, gearsList, gearsDict);
            // Hold for the Visual Studio watch and debugger.
            var hold = 0;
        }
        
        #endregion

        

        #region Calendar and Sun Train Real Duplication tests (PAPER)

        /// <summary>
        /// Represented in the paper, this is the real-value set of gears routine.
        /// </summary>
        [TestMethod]
        public void PanHellenicCalendarRealValuedGearTrain()
        {
            
        }


        #endregion

        #region Commented
        [TestMethod]
        public void TrainTest()
        {
            // TBD.
            // Calculate the coupled-gear ratios for the preferred geometrics.
            //var a1b1Ratio = Functions.CalculateGearRatio(a1, b1223); // move this to another test block.
            //// b2 takes the rotation input from b1. Diff.
            //var b2c1Ratio = Functions.CalculateGearRatio(b264, c138);
            //// c2 takes the rotation input from c1. Diff.
            //var c2d1Ratio = Functions.CalculateGearRatio(c247, d1);
            //// d2 takes the rotation input from d1. Diff
            //var d2e2Ratio = Functions.CalculateGearRatio(d2, e2);
            //// e1 takes the rotation input from e2. Same.
            //var e1b3Ratio = Functions.CalculateGearRatio(e1, b3); // --> from rotation of b3, go now to the pointer... 
            //// Calculate the displacement along the train.
            //// STEP 1:
            //var a1Displacement = Functions.CalculateAngularDisplacement(rotationAngleDegree, a1);   // Initial displacement (mm).
            ////var b1Displacement = a1b1Ratio * a1Displacement;                                        // Sequential displacement (mm).
            //var b1Rotation = a1b1Ratio * rotationAngleDegree;                                      // Degree rotation.
            //// Check the rotation.
            // var b1Displacement = calibrate this first.
        }
        #endregion

        #region primitive methods
        /// <summary>
        /// The geometry check for the code gear objects based on [1, 2, 4, 5].
        /// </summary>
        /// <param name="one">Input crown gear.</param>
        /// <param name="two">Sun gear.</param>
        public void GeometricAssumptionSunDuplication(Gear one, Gear two)
        {
            const double delta = 0.01;

            var oneChordLength = Functions.CalculateChordLength(one);
            Assert.AreEqual(one.ChordLength, oneChordLength, delta);
            var oneTeeth = Functions.CalculateTeeth(one);
            Assert.AreEqual(one.NumberOfTeeth, oneTeeth, delta);

            var twoChordLength = Functions.CalculateChordLength(two);
            Assert.AreEqual(two.ChordLength, twoChordLength, delta);
            var twoTeeth = Functions.CalculateTeeth(two);
            Assert.AreEqual(two.NumberOfTeeth, twoTeeth, delta);
        }
        /// <summary>
        /// The geometry check for the code gear objects based on [1, 2, 4, 5].
        /// </summary>
        /// <param name="one">Input crown gear.</param>
        /// <param name="two">Sun gear.</param>
        /// <param name="three">The drivng gear from the sun gear.</param>
        public void GeometricAssumptionSunDuplication(Gear one, Gear two, Gear three)
        {
            const double delta = 0.01;

            var oneChordLength = Functions.CalculateChordLength(one);
            Assert.AreEqual(one.ChordLength, oneChordLength, delta);
            var oneTeeth = Functions.CalculateTeeth(one);
            Assert.AreEqual(one.NumberOfTeeth, oneTeeth, delta);

            var twoChordLength = Functions.CalculateChordLength(two);
            Assert.AreEqual(two.ChordLength, twoChordLength, delta);
            var twoTeeth = Functions.CalculateTeeth(two);
            Assert.AreEqual(two.NumberOfTeeth, twoTeeth, delta);

            var threeChordLength = Functions.CalculateChordLength(three);
            Assert.AreEqual(three.ChordLength, threeChordLength, delta);
            var threeTeeth = Functions.CalculateTeeth(three);
            Assert.AreEqual(three.NumberOfTeeth, threeTeeth, delta);
        }
        /// <summary>
        /// The geometry check for the code gear objects based on [1, 2, 4, 5].
        /// </summary>
        /// <param name="one">Input crown gear.</param>
        /// <param name="two">Sun gear.</param>
        /// <param name="three">The drivng gear from the sun gear.</param>
        /// <param name="four">The next gear in mesh series.</param>
        public void GeometricAssumptionSunDuplication(Gear one, Gear two, Gear three, Gear four)
        {
            const double delta = 0.01;

            var oneChordLength = Functions.CalculateChordLength(one);
            Assert.AreEqual(one.ChordLength, oneChordLength, delta);
            var oneTeeth = Functions.CalculateTeeth(one);
            Assert.AreEqual(one.NumberOfTeeth, oneTeeth, delta);

            var twoChordLength = Functions.CalculateChordLength(two);
            Assert.AreEqual(two.ChordLength, twoChordLength, delta);
            var twoTeeth = Functions.CalculateTeeth(two);
            Assert.AreEqual(two.NumberOfTeeth, twoTeeth, delta);

            var threeChordLength = Functions.CalculateChordLength(three);
            Assert.AreEqual(three.ChordLength, threeChordLength, delta);
            var threeTeeth = Functions.CalculateTeeth(three);
            Assert.AreEqual(three.NumberOfTeeth, threeTeeth, delta);

            var fourChordLength = Functions.CalculateChordLength(four);
            Assert.AreEqual(four.ChordLength, fourChordLength, delta);
            var fourTeeth = Functions.CalculateTeeth(four);
            Assert.AreEqual(four.NumberOfTeeth, fourTeeth, delta);
        }
        /// <summary>
        /// Tests the geometric assumption of the chord length to the number of teeth as a (fixed) ratio.
        /// </summary>
        public void GeometricAssumptionTestCalibration(Gear one, Gear two, Gear three, Gear four)
        {
            const double delta = 0.01;

            var oneChordLength = Functions.CalculateChordLength(one);
            Assert.AreEqual(one.ChordLength, oneChordLength, delta);
            var oneTeeth = Functions.CalculateTeeth(one);
            Assert.AreEqual(one.NumberOfTeeth, oneTeeth, delta);

            var twoChordLength = Functions.CalculateChordLength(two);
            Assert.AreEqual(two.ChordLength, twoChordLength, delta);
            var twoTeeth = Functions.CalculateTeeth(two);
            Assert.AreEqual(two.NumberOfTeeth, twoTeeth, delta);

            var threeChordLength = Functions.CalculateChordLength(three);
            Assert.AreEqual(three.ChordLength, threeChordLength, delta);
            var threeTeeth = Functions.CalculateTeeth(three);
            Assert.AreEqual(three.NumberOfTeeth, threeTeeth, delta);

            var fourChordLength = Functions.CalculateChordLength(four);
            Assert.AreEqual(four.ChordLength, fourChordLength, delta);
            var fourTeeth = Functions.CalculateTeeth(four);
            Assert.AreEqual(four.NumberOfTeeth, fourTeeth, delta);
        }

        public void GeometricAssumptionTestRealValued(Gear a1, Gear b1223, Gear b1224, Gear b264, Gear b265, Gear b266, Gear c138, Gear c139, Gear c247,
            Gear c248, Gear c249, Gear d1, Gear d2, Gear e2, Gear e1, Gear b3)
        {
            const double delta = 0.01;

            var b1223ChordLength = Functions.CalculateChordLength(b1223);
            Assert.AreEqual(b1223.ChordLength, b1223ChordLength, delta);
            var b1223Teeth = Functions.CalculateTeeth(b1223);
            Assert.AreEqual(b1223.NumberOfTeeth, b1223Teeth, delta);

            // B1 also has a possible 224 teeth.
            var b1224ChordLength = Functions.CalculateChordLength(b1224);
            Assert.AreEqual(b1224.ChordLength, b1224ChordLength, delta);
            var b1224Teeth = Functions.CalculateTeeth(b1224);
            Assert.AreEqual(b1224.NumberOfTeeth, b1224Teeth, delta);

            var b264ChordLength = Functions.CalculateChordLength(b264);
            Assert.AreEqual(b264.ChordLength, b264ChordLength, delta);
            var b264Teeth = Functions.CalculateTeeth(b264);
            Assert.AreEqual(b264.NumberOfTeeth, b264Teeth, delta);

            var b265ChordLength = Functions.CalculateChordLength(b265);
            Assert.AreEqual(b265.ChordLength, b265ChordLength, delta);
            var b265Teeth = Functions.CalculateTeeth(b265);
            Assert.AreEqual(b265.NumberOfTeeth, b265Teeth, delta);

            var b266ChordLength = Functions.CalculateChordLength(b266);
            Assert.AreEqual(b266.ChordLength, b266ChordLength, delta);
            var b266Teeth = Functions.CalculateTeeth(b266);
            Assert.AreEqual(b266.NumberOfTeeth, b266Teeth, delta);

            var c138ChordLength = Functions.CalculateChordLength(c138);
            Assert.AreEqual(c138.ChordLength, c138ChordLength, delta);
            var c138Teeth = Functions.CalculateTeeth(c138);
            Assert.AreEqual(c138.NumberOfTeeth, c138Teeth, delta);

            var c139ChordLength = Functions.CalculateChordLength(c139);
            Assert.AreEqual(c139.ChordLength, c139ChordLength, delta);
            var c139Teeth = Functions.CalculateTeeth(c139);
            Assert.AreEqual(c139.NumberOfTeeth, c139Teeth, delta);

            var c247ChordLength = Functions.CalculateChordLength(c247);
            Assert.AreEqual(c247.ChordLength, c247ChordLength, delta);
            var c247Teeth = Functions.CalculateTeeth(c247);
            Assert.AreEqual(c247.NumberOfTeeth, c247Teeth, delta);

            var c248ChordLength = Functions.CalculateChordLength(c248);
            Assert.AreEqual(c248.ChordLength, c248ChordLength, delta);
            var c248Teeth = Functions.CalculateTeeth(c248);
            Assert.AreEqual(c248.NumberOfTeeth, c248Teeth, delta);

            var c249ChordLength = Functions.CalculateChordLength(c249);
            Assert.AreEqual(c249.ChordLength, c249ChordLength, delta);
            var c249Teeth = Functions.CalculateTeeth(c249);
            Assert.AreEqual(c249.NumberOfTeeth, c249Teeth, delta);

            var d1ChordLength = Functions.CalculateChordLength(d1);
            Assert.AreEqual(d1.ChordLength, d1ChordLength, delta);
            var d1Teeth = Functions.CalculateTeeth(d1);
            Assert.AreEqual(d1.NumberOfTeeth, d1Teeth, delta);

            var d2ChordLength = Functions.CalculateChordLength(d2);
            Assert.AreEqual(d2.ChordLength, d2ChordLength, delta);
            var d2Teeth = Functions.CalculateTeeth(d2);
            Assert.AreEqual(d2.NumberOfTeeth, d2Teeth, delta);

            var e2ChordLength = Functions.CalculateChordLength(e2);
            Assert.AreEqual(e2.ChordLength, e2ChordLength, delta);
            var e2Teeth = Functions.CalculateTeeth(e2);
            Assert.AreEqual(e2.NumberOfTeeth, e2Teeth, delta);

            var e1ChordLength = Functions.CalculateChordLength(e1);
            Assert.AreEqual(e1.ChordLength, e1ChordLength, delta);
            var e1Teeth = Functions.CalculateTeeth(e1);
            Assert.AreEqual(e1.NumberOfTeeth, e1Teeth, delta);

            var b3ChordLength = Functions.CalculateChordLength(b3);
            Assert.AreEqual(b3.ChordLength, b3ChordLength, delta);
            var b3Teeth = Functions.CalculateTeeth(b3);
            Assert.AreEqual(b3.NumberOfTeeth, b3Teeth, delta);
        }

        public void TrainTwoGears(double rotationDegree, Gear one, Gear two)
        {
            var inputRatio = rotationDegree / 360;

            // Set first and last gears to record the ratio.
            one.InputScalar = inputRatio;
            two.InputScalar = inputRatio;
            one.FirstGear = true;
            two.LastGear = true;

            var oneTwoRatio = Functions.CalculateGearRatio(one, two);// dimensionless.
            var oneDisplacement = Functions.CalculateAngularDisplacement(inputRatio, one);// in mm.
            //var twoDisplacement = oneTwoRatio * two.Circumference;// in mm. This is an error.
            var twoDisplacement = oneTwoRatio * inputRatio * two.Circumference;// in mm.
            var twoRotation = 360 * (1 / (two.Circumference / twoDisplacement)); // in degrees.

            // Assign to the gear properties.
            one.Degree.Movement = rotationDegree;
            one.AngularPosition.Movement = oneDisplacement;
            two.Degree.Movement = twoRotation;
            two.AngularPosition.Movement = twoDisplacement;

            // What are these checks meaning?
            var check1 = inputRatio * (oneDisplacement / one.Circumference);// What do these numbers represent?
            var check2 = inputRatio * (twoDisplacement / two.Circumference);// What do these numbers represent?

            // As unknown presently, store them on the objects.
            one.CheckScalar = check1;
            two.CheckScalar = check2;

            // Finally...
            two.OutputScalar = two.CheckScalar; //--> this goes out to an indicator or dial.
        }

        public void TrainThreeGears(double rotationDegree, Gear three, Gear four, Gear five)
        {
            var inputRatio = rotationDegree / 360;

            // Set first and last gears to record the ratio.
            three.InputScalar = inputRatio;
            five.InputScalar = inputRatio;
            three.FirstGear = true;
            five.LastGear = true;

            var threefourRatio = Functions.CalculateGearRatio(three, four);// dimensionless.
            var fourFiveRatio = Functions.CalculateGearRatio(four, five);// dimensionless.
            var threeDisplacement = Functions.CalculateAngularDisplacement(inputRatio, three);// in mm.
            var fourDisplacement = threefourRatio * four.Circumference;// in mm.
            var fiveDisplacement = fourFiveRatio * five.Circumference;// in mm.
            var threeRotation = 360 * (1 / (three.Circumference / threeDisplacement));// in degrees.
            var fourRotation = 360 * (1 / (four.Circumference / fourDisplacement));// in degrees.
            var fiveRotation = 360 * (1 / (five.Circumference / fiveDisplacement));// in degrees

            // Assign to the gear properties.
            three.FirstGear = true;
            three.Degree.Movement = threeRotation; // Can also be rotationDegree.
            three.AngularPosition.Movement = threeDisplacement;
            four.Degree.Movement = fourRotation;
            four.AngularPosition.Movement = fourDisplacement;
            five.Degree.Movement = fiveRotation;
            five.AngularPosition.Movement = fiveDisplacement;

            // Perform checks.
            var check1 = inputRatio * (threeDisplacement / three.Circumference);// What do these numbers represent?
            var check2 = inputRatio * (fourDisplacement / four.Circumference);// What do these numbers represent?
            var check3 = inputRatio * (fiveDisplacement / five.Circumference);// What do these numbers represent?

            // As unknown presently, store them on the objects. Store these numbers.
            three.CheckScalar = check1;
            four.CheckScalar = check2;
            five.CheckScalar = check3;

            // Finally...
            five.OutputScalar = five.CheckScalar; //--> this goes out to an indicator or dial.

            Assert.AreEqual(rotationDegree, threeRotation, Delta);
        }

        public void TrainFourGears(double rotationDegree, Gear six, Gear seven, Gear eight, Gear nine)
        {
            var inputRatio = rotationDegree / 360;

            // Set first and last gears to record the ratio.
            six.InputScalar = inputRatio;
            nine.InputScalar = inputRatio;
            six.FirstGear = true; //= new GearSix { FirstGear = true }; // Sexy notation.
            nine.LastGear = true;

            var sixSevenRatio = Functions.CalculateGearRatio(six, seven);// dimensionless.
            var sevenEightRatio = Functions.CalculateGearRatio(seven, eight);// dimensionless.
            var eightNineRatio = Functions.CalculateGearRatio(eight, nine);// dimensionless.
            var sixDisplacement = Functions.CalculateAngularDisplacement(inputRatio, six);// in mm.
            var sevenDisplacement = sixSevenRatio * seven.Circumference;// in mm.
            var eightDisplacement = sevenEightRatio * eight.Circumference;// in mm.
            var nineDisplacement = eightNineRatio * nine.Circumference;// in mm.
            var sixRotation = 360 * (1 / (six.Circumference / sixDisplacement));// in degrees.
            var sevenRotation = 360 * (1 / (seven.Circumference / sevenDisplacement));// in degrees.
            var eightRotation = 360 * (1 / (eight.Circumference / eightDisplacement));// in degrees.
            var nineRotation = 360 * (1 / (nine.Circumference / nineDisplacement));// in degrees.

            // Store the rotations: Assign to the gear properties.
            six.Degree.Movement = sixRotation;// Using a different means of computation, it calculates against itself.
            six.AngularPosition.Movement = sixDisplacement;
            seven.Degree.Movement = sevenRotation;
            seven.AngularPosition.Movement = sevenDisplacement;
            eight.Degree.Movement = eightRotation;
            eight.AngularPosition.Movement = eightDisplacement;
            nine.Degree.Movement = nineRotation;
            nine.AngularPosition.Movement = nineDisplacement;

            // Perform checks.
            var check1 = inputRatio * (sixDisplacement / six.Circumference);// What do these numbers represent? Dimensionless. OUTPUT SCALARS
            var check2 = inputRatio * (sevenDisplacement / seven.Circumference);// What do these numbers represent? Dimensionless.
            var check3 = inputRatio * (eightDisplacement / eight.Circumference);// What do these numbers represent? Dimensionless.
            var check4 = inputRatio * (nineDisplacement / nine.Circumference);// What do these numbers represent? Dimensionless. IS THIS A CORRECT OUTPUT SCALAR?

            // Store these numbers.
            six.CheckScalar = check1;
            seven.CheckScalar = check2;
            eight.CheckScalar = check3;
            nine.CheckScalar = check4;

            // Finally...
            nine.OutputScalar = nine.CheckScalar; //--> this goes out to an indicator or dial.

            //RuntimeTest(six, seven, eight, nine);

        }
        #endregion
    }
}