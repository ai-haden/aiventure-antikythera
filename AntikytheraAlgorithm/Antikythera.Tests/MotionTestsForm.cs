using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Antikythera.Tests
{
    public partial class MotionTestsForm : Form
    {
        int lastGear = 0;

        public MotionTestsForm()
        {
            InitializeComponent();
            planetaryGearSets.SelectedItem = "Moon Gear Set";
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Imports the gears list.
        /// </summary>
        /// <param name="gears">The list of gears.</param>
        /// <param name="lastGear">The last gear in the list, which is the output.</param>
        public void ImportGears(List<Gear> gears, int lastGear)
        {
            inputDial.Value = gears[0].Degree.Movement;
            outputDial.Value = gears[lastGear].Degree.Movement;
            inputDegreesLabel.Text = inputDial.Value.ToString(CultureInfo.InvariantCulture);
            outputDegreesLabel.Text = outputDial.Value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The list of gears required for the sequence for displaying the moon position.
        /// </summary>
        public List<Gear> InputMoonPositionGears()
        {
            var moonPositionDisplayGears = new List<Gear>();
            // Input crown gear.
            var inputGear = new Antikythera.RealGear.Crown.Input.A1Gear();
            // Sun gear.
            var sunGear1 = new Antikythera.RealGear.SunTrain.B1Gear223();
            var sunGear2 = new Antikythera.RealGear.SunTrain.B2Gear64();
            sunGear2.SharesShaft = true;
            // Lunar transition gear.
            var lunarTransitionGear1 = new Antikythera.RealGear.LunarTrain.LunarTransition.C1Gear38();
            var lunarTransitionGear2 = new Antikythera.RealGear.LunarTrain.LunarTransition.C2Gear48();
            lunarTransitionGear2.SharesShaft = true;
            var lunarTransitionGear3 = new Antikythera.RealGear.LunarTrain.LunarTransition.D1Gear();
            var lunarTransitionGear4 = new Antikythera.RealGear.LunarTrain.LunarTransition.D2Gear();
            lunarTransitionGear4.SharesShaft = true;
            var lunarTransitionGear5 = new Antikythera.RealGear.LunarTrain.LunarTransition.E2Gear();
            // Epicyclic gear.
            var epicyclicGear1 = new Antikythera.RealGear.LunarTrain.Epicyclic.E1Gear();
            epicyclicGear1.SharesShaft = true;
            var epicyclicGear2 = new Antikythera.RealGear.LunarTrain.Epicyclic.B3Gear();
            // Add the sequence to the moon position set.
            moonPositionDisplayGears.Add(inputGear);
            moonPositionDisplayGears.Add(sunGear1);
            moonPositionDisplayGears.Add(sunGear2);
            moonPositionDisplayGears.Add(lunarTransitionGear1);
            moonPositionDisplayGears.Add(lunarTransitionGear2);
            moonPositionDisplayGears.Add(lunarTransitionGear3);
            moonPositionDisplayGears.Add(lunarTransitionGear4);
            moonPositionDisplayGears.Add(lunarTransitionGear5);
            moonPositionDisplayGears.Add(epicyclicGear1);
            moonPositionDisplayGears.Add(epicyclicGear2);
            // Set the number for the last gear on the list.
            lastGear = moonPositionDisplayGears.Count - 1;

            return moonPositionDisplayGears;
        }
        /// <summary>
        /// The list of gears required for the sequence for displaying the moon position.
        /// </summary>
        public List<Gear> InputMoonPhaseGears()
        {
            var moonPhaseDisplayGears = new List<Gear>();
            // Input crown gear.
            var inputGear = new Antikythera.RealGear.Crown.Input.A1Gear();
            // Sun gear.
            var sunGear1 = new Antikythera.RealGear.SunTrain.B1Gear223();
            var sunGear2 = new Antikythera.RealGear.SunTrain.B2Gear64();
            sunGear2.SharesShaft = true;
            // Lunar transition gear.
            var lunarTransitionGear1 = new Antikythera.RealGear.LunarTrain.LunarTransition.C1Gear38();
            var lunarTransitionGear2 = new Antikythera.RealGear.LunarTrain.LunarTransition.C2Gear48();
            lunarTransitionGear2.SharesShaft = true;
            var lunarTransitionGear3 = new Antikythera.RealGear.LunarTrain.LunarTransition.D1Gear();
            var lunarTransitionGear4 = new Antikythera.RealGear.LunarTrain.LunarTransition.D2Gear();
            lunarTransitionGear4.SharesShaft = true;
            var lunarTransitionGear5 = new Antikythera.RealGear.LunarTrain.LunarTransition.E2Gear();
            // Epicyclic gear.
            var epicyclicGear1 = new Antikythera.RealGear.LunarTrain.Epicyclic.E1Gear();
            epicyclicGear1.SharesShaft = true;
            var epicyclicGear2 = new Antikythera.RealGear.LunarTrain.Epicyclic.B3Gear();
            // Add the sequence to the moon position set.
            moonPhaseDisplayGears.Add(inputGear);
            moonPhaseDisplayGears.Add(sunGear1);
            moonPhaseDisplayGears.Add(sunGear2);
            moonPhaseDisplayGears.Add(lunarTransitionGear1);
            moonPhaseDisplayGears.Add(lunarTransitionGear2);
            moonPhaseDisplayGears.Add(lunarTransitionGear3);
            moonPhaseDisplayGears.Add(lunarTransitionGear4);
            moonPhaseDisplayGears.Add(lunarTransitionGear5);
            moonPhaseDisplayGears.Add(epicyclicGear1);
            moonPhaseDisplayGears.Add(epicyclicGear2);
            // The moon phase display gears.
            var lunarPhaseDisplay1 = new Antikythera.RealGear.LunarTrain.LunarPhase.B0Gear();
            // It shares the shaft with gear B3.
            lunarPhaseDisplay1.SharesShaft = true;
            // Note: this is a crown gear.
            var lunarPhaseDisplay2 = new Antikythera.RealGear.LunarTrain.LunarPhase.Q1Gear();
            // Add the sequence for the moon phase set.
            moonPhaseDisplayGears.Add(lunarPhaseDisplay1);
            moonPhaseDisplayGears.Add(lunarPhaseDisplay2);
            // Set the number for the last gear on the list.
            lastGear = moonPhaseDisplayGears.Count - 1;

            return moonPhaseDisplayGears;
        }
        /// <summary>
        /// Sends the movement button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SendMovementButtonClick(object sender, EventArgs e)
        {
            if (sendMovementTextBox.Text != "")
            {
                var value = Convert.ToDouble(sendMovementTextBox.Text);
                // How to re-enter the test method?
                if (planetaryGearSets.SelectedItem.ToString() == "Moon Gear Set")
                {
                    // Pick the gear set and place into the list object.
                    var moonPositionDisplayGears = InputMoonPositionGears();
                    Antikythera.Dynamics.Motion.GearMovement(value, moonPositionDisplayGears);
                    inputDial.Value = moonPositionDisplayGears[0].Degree.Movement;
                    outputDial.Value = moonPositionDisplayGears[lastGear].Degree.Movement;
                    inputDegreesLabel.Text = inputDial.Value.ToString(CultureInfo.InvariantCulture);
                    outputDegreesLabel.Text = outputDial.Value.ToString(CultureInfo.InvariantCulture);
                }
            }
        }
    }
}
