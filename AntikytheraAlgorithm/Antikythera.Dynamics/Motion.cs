using System;
using System.Collections;
using System.Collections.Generic;
using Antikythera.Dynamics.Validate;

namespace Antikythera.Dynamics
{
    public static class Motion
    {
        /// <summary>
        /// Generates the gear dictionary.
        /// </summary>
        /// <param name="gearList">The gear list.</param>
        private static Dictionary<int, Gear> GenerateGearDictionary(List<Gear> gearList)
        {
            var gearsDict = new Dictionary<int, Gear>();
            // Iterate through the list and build the dictionary.
            for (var i = 0; i < gearList.Count; i++)
            {
                gearsDict.Add(i, gearList[i]);
            }

            return gearsDict;
        }
        /// <summary>
        /// Calculates the movement of the input objects.
        /// </summary>
        /// <param name="rotationDegree">The rotation degree at the input.</param>
        /// <param name="gears">The list of gears.</param>
        public static string GearMovement(double rotationDegree, List<Gear> gears)
        {
            var result = "0";
            var inputRatio = rotationDegree / 360;
            var last = gears.Count - 1;
            gears[0].InputScalar = inputRatio;
            gears[0].FirstGear = true;
            gears[last].InputScalar = inputRatio;
            gears[last].LastGear = true;
            var gearDict = GenerateGearDictionary(gears);
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

                    ////var toothCouplingRatio = Functions.CalculateGearRatio(firstGear, secondGear); // Change to mean values.
                    var meanGearCouplingRatio = Functions.CalculateMeanGearRatio(firstGear, secondGear); // dimensionless. <-- ERROR IS BETWEEN HERE...
                    var firstDisplacement = Functions.CalculateAngularDisplacement(inputRatio, firstGear);// in mm.
                    ////var twoDisplacement = oneTwoRatio * two.Circumference;// in mm. This is an error.
                    var secondDisplacement = meanGearCouplingRatio * inputRatio * secondGear.Circumference;// in mm.
                    ////var secondMeanDisplacement = meanGearCouplingRatio * inputRatio * secondGear.Circumference;// in mm.
                    var secondRotation = 360 * (1 / (secondGear.Circumference / secondDisplacement)); // in degrees.
                    ////var secondMeanRotation = 360 * (1 / (secondGear.Circumference / secondMeanDisplacement)); // in degrees.

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

                            if (secondGear.SharesShaft && secondGear.PinSlot)// Because it can only be eccentric if sharing a shaft.
                            {
                                // Calculate the Eccentricity due to the PinSlot arrangement.

                            }
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
                    // Step back one to find the ratio of the next gear coupling. ??
                    // Double-check the value of rotation.
                    CheckMotion.VerifyRotation(gears, gearDict, rotationDegree);
                }
            }
            return result;
        }
        /// <summary>
        /// Calculates the movement of the input objects.
        /// </summary>
        /// <param name="rotationDegree">The rotation degree at the input.</param>
        /// <param name="gears">The list of gears.</param>
        /// <param name="gearDict">The dictionary of gears.</param>
        /// <remarks>The source of the truth.</remarks>
        public static string GearMovement(double rotationDegree, List<Gear> gears, Dictionary<int, Gear> gearDicts)
        {
            // Maybe change this to generate the dictionary internally.
            
            var result = "0";
            var inputRatio = rotationDegree / 360;
            var last = gears.Count - 1;
            gears[0].InputScalar = inputRatio;
            gears[0].FirstGear = true;
            gears[last].InputScalar = inputRatio;
            gears[last].LastGear = true;

            IDictionaryEnumerator iterator = gearDicts.GetEnumerator();

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
                    // Step back one to find the ratio of the next gear coupling. ??
                    // Double-check the value of rotation.
                    CheckMotion.VerifyRotation(gears, gearDicts, rotationDegree);
                }
            }
            return result;
        }

        #region old code

        private static void TrainTwoGears(double rotationDegree, Gear one, Gear two)
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

        private static void TrainThreeGears(double rotationDegree, Gear three, Gear four, Gear five)
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

            //Assert.AreEqual(rotationDegree, threeRotation, Delta);
        }

        private static void TrainFourGears(double rotationDegree, Gear six, Gear seven, Gear eight, Gear nine)
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
