using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Antikythera;
using Antikythera.CalibrationGear;
using Antikythera.Position;
using Timer = System.Windows.Forms.Timer;

namespace TimeTester
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StartButton.Enabled = true;
        }

        #region delegates et. al
        BackgroundWorker bw = new BackgroundWorker();
        Thread _worker = null;
        //bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        //bw.RunWorkerAsync();

        private delegate void SetOutputLabelCallback(Label outputLabel);
        private delegate void SetCurrentTimeLabelCallback(Label currentTimeLabel);

        public void SetOutputLabel(Label outputLabel)
        {
            if (this.outputLabel.InvokeRequired)
            {
                SetOutputLabelCallback d = new SetOutputLabelCallback(SetOutputLabel);
                this.Invoke(d, new object[] {outputLabel});
            }
            else
            {
                this.outputLabel.Text = _sum.Second.ToString(CultureInfo.InvariantCulture);
            }
        }
        public void SetCurrentTimeLabel(Label currentTimeLabel)
        {
            if (this.currentTimeLabel.InvokeRequired)
            {
                SetCurrentTimeLabelCallback d = new SetCurrentTimeLabelCallback(SetCurrentTimeLabel);
                this.currentTimeLabel.Invoke(d, new object[] {currentTimeLabel});
            }
            else
            {
                this.currentTimeLabel.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }
        }
        // do work on background thread
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var period = 5000;
            _timer.Interval = 1000;
            _timer.Start();

            while (_timer.Interval < period)
            {
                StartButton.Enabled = false;
                _sum.Second = DateTime.Now.Second;
                //sum.Wait(2);
                outputLabel.Text = _sum.Second.ToString(CultureInfo.InvariantCulture);
                //outputLabel.Refresh();
                currentTimeLabel.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                //currentTimeLabel.Refresh();
                Refresh();
                _timer.Interval++;
            }
            _timer.Stop();
            StartButton.Enabled = true;
        }
        #endregion

        private readonly Time _sum = new Time();
        
        private readonly Timer _timer = new Timer {Interval = 1000};
        const double RotationAngleDegreeCal = 360; // 1/2.
        const double InputRatio = RotationAngleDegreeCal / 360;
        readonly GearOne _one = new GearOne { FirstGear = true };
        readonly GearTwo _two = new GearTwo();
        readonly GearThree _three = new GearThree();
        readonly GearFour _four = new GearFour { LastGear = true };
        private double _rotationDegree;
        private const int Period = 5000;
        private double _turned;

        protected double TurningGears(Time time, Gear one, Gear two, Gear three, Gear four)
        {
            if (time == null) throw new ArgumentNullException("time");

            double result = 0;
            if (one.FirstGear)
            {
                time = _sum;
                //one.Degree.Increment = 1;
                one.Degree.Movement = 360;
                // Attach velocity. Begin by moving rotation one degree per second.

                //time.Second = one.SetRotationalPosition(_sum, Period); // DONT KNOW IF THIS IS USEFUL.
                // Stopped here.

                // Output the total turned number of degrees that will be visible to a dial interface.
                result = time.Second;
            }
            return result;
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            bw.RunWorkerAsync();

            _timer.Interval = 1000;
            _timer.Start();

            while (_timer.Interval < Period)
            {
                StartButton.Enabled = false;
                _sum.Second = DateTime.Now.Second;
                
                _turned = TurningGears(_sum, _one, _two, _three, _four);
                outputDegreesTextBox.Text = _turned.ToString(CultureInfo.InvariantCulture);

                #region commented
                //sum.Wait(2);
                //this._worker = new Thread(new ThreadStart(SetOutputLabel));
                //this._worker.Start();
                #endregion

                outputLabel.Text = _sum.Second.ToString(CultureInfo.InvariantCulture);
                //outputLabel.Refresh();
                currentTimeLabel.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
                //currentTimeLabel.Refresh();
                Refresh();
                _timer.Interval++;
            }
            _timer.Stop();
            StartButton.Enabled = true;
        }


        ~MainForm()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
