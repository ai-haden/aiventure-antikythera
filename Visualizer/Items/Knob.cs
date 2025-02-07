using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FormControls.Items
{
    /// <summary>
    /// Description of knob.
    /// </summary>
    public partial class Knob : UserControl
    {
        #region Enumerators
        public enum KnobStyle
        {
            Circular = 0,
        }
        #endregion

        #region Properties variables
        private float _minValue = 0.0F;
        private float _maxValue = 1.0F;
        private float _stepValue = 0.1F;
        private float _currentValue = 0.0F;
        private KnobStyle _style = KnobStyle.Circular;
        private KnobRenderer _renderer = null;
        private Color _scaleColor = Color.Green;
        private Color _knobColor = Color.Black;
        private Color _indicatorColor = Color.Red;
        private float _indicatorOffset = 10F;
        #endregion

        #region Class variables
        private RectangleF _drawRect;
        private RectangleF _rectScale;
        private RectangleF _rectKnob;
        private float _drawRatio;
        private KnobRenderer defaultRenderer = null;
        private bool _isKnobRotating = false;
        private PointF _knobCenter;
        private PointF _knobIndicatorPosition;
        #endregion

        #region Constructor
        public Knob()
        {
            InitializeComponent();

            // Set the styles for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            // Transparent background
            this.BackColor = Color.Transparent;

            this.defaultRenderer = new KnobRenderer();
            this.defaultRenderer.Knob = this;

            this.CalculateDimensions();
        }
        #endregion

        #region Properties
        [
            Category("Knob"),
            Description("Minimum value of the knob")
        ]
        public float MinValue
        {
            set
            {
                this._minValue = value;
                this.Invalidate();
            }
            get { return this._minValue; }
        }

        [
            Category("Knob"),
            Description("Maximum value of the knob")
        ]
        public float MaxValue
        {
            set
            {
                this._maxValue = value;
                this.Invalidate();
            }
            get { return this._maxValue; }
        }

        [
            Category("Knob"),
            Description("Step value of the knob")
        ]
        public float StepValue
        {
            set
            {
                this._stepValue = value;
                this.Invalidate();
            }
            get { return this._stepValue; }
        }

        [
            Category("Knob"),
            Description("Current value of the knob")
        ]
        public float Value
        {
            set
            {
                if (value != this._currentValue)
                {
                    this._currentValue = value;
                    this._knobIndicatorPosition = this.GetPositionFromValue(this._currentValue);
                    this.Invalidate();

                    KnobEventArgs e = new KnobEventArgs();
                    e.Value = this._currentValue;
                    this.OnKnobChangeValue(e);
                }
            }
            get { return this._currentValue; }
        }

        [
            Category("Knob"),
            Description("Style of the knob")
        ]
        public KnobStyle Style
        {
            set
            {
                this._style = value;
                this.Invalidate();
            }
            get { return this._style; }
        }

        [
            Category("Knob"),
            Description("Color of the knob")
        ]
        public Color KnobColor
        {
            set
            {
                this._knobColor = value;
                this.Invalidate();
            }
            get { return this._knobColor; }
        }

        [
            Category("Knob"),
            Description("Color of the scale")
        ]
        public Color ScaleColor
        {
            set
            {
                this._scaleColor = value;
                this.Invalidate();
            }
            get { return this._scaleColor; }
        }

        [
            Category("Knob"),
            Description("Color of the indicator")
        ]
        public Color IndicatorColor
        {
            set
            {
                this._indicatorColor = value;
                this.Invalidate();
            }
            get { return this._indicatorColor; }
        }

        [
            Category("Knob"),
            Description("Offset of the indicator from the kob border")
        ]
        public float IndicatorOffset
        {
            set
            {
                this._indicatorOffset = value;
                this.CalculateDimensions();
                this.Invalidate();
            }
            get { return this._indicatorOffset; }
        }

        [Browsable(false)]
        public KnobRenderer Renderer
        {
            get { return this._renderer; }
            set
            {
                this._renderer = value;
                if (this._renderer != null)
                    _renderer.Knob = this;
                Invalidate();
            }
        }

        [Browsable(false)]
        public PointF KnobCenter
        {
            get { return this._knobCenter; }
        }
        #endregion

        #region Events delegates

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool blResult = true;

            // Specified WM_KEYDOWN enumeration value.
            const int WM_KEYDOWN = 0x0100;

            // Specified WM_SYSKEYDOWN enumeration value.
            const int WM_SYSKEYDOWN = 0x0104;

            float val = this.Value;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Up:
                        val += this.StepValue;
                        if (val <= this.MaxValue)
                            this.Value = val;
                        break;

                    case Keys.Down:
                        val -= this.StepValue;
                        if (val >= this.MinValue)
                            this.Value = val;
                        break;

                    case Keys.PageUp:
                        if (val < this.MaxValue)
                        {
                            val += (this.StepValue * 10);
                            this.Value = val;
                        }
                        break;

                    case Keys.PageDown:
                        if (val > this.MinValue)
                        {
                            val -= (this.StepValue * 10);
                            this.Value = val;
                        }
                        break;

                    case Keys.Home:
                        this.Value = this.MinValue;
                        break;

                    case Keys.End:
                        this.Value = this.MaxValue;
                        break;

                    default:
                        blResult = base.ProcessCmdKey(ref msg, keyData);
                        break;
                }
            }

            return blResult;
        }

        [EditorBrowsable()]
        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            this.Invalidate();
            base.OnClick(e);
        }

        void OnMouseUp(object sender, MouseEventArgs e)
        {
            this._isKnobRotating = false;

            if (this._rectKnob.Contains(e.Location) == false)
                return;

            float val = this.GetValueFromPosition(e.Location);
            if (val != this.Value)
            {
                this.Value = val;
                this.Invalidate();
            }
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (this._rectKnob.Contains(e.Location) == false)
                return;

            this._isKnobRotating = true;

            this.Focus();
        }

        void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (this._isKnobRotating == false)
                return;

            float val = this.GetValueFromPosition(e.Location);
            if (val != this.Value)
            {
                this.Value = val;
                this.Invalidate();
            }
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            float val = this.Value;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    val = this.Value + this.StepValue;
                    break;

                case Keys.Down:
                    val = this.Value - this.StepValue;
                    break;
            }

            if (val < this.MinValue)
                val = this.MinValue;

            if (val > this.MaxValue)
                val = this.MaxValue;

            this.Value = val;
        }


        [EditorBrowsable()]
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            this.CalculateDimensions();

            this.Invalidate();
        }

        [EditorBrowsable()]
        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF _rc = new RectangleF(0, 0, this.Width, this.Height);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (this.Renderer == null)
            {
                this.defaultRenderer.DrawBackground(e.Graphics, _rc);
                this.defaultRenderer.DrawScale(e.Graphics, this._rectScale);
                this.defaultRenderer.DrawKnob(e.Graphics, this._rectKnob);
                this.defaultRenderer.DrawKnobIndicator(e.Graphics, this._rectKnob, this._knobIndicatorPosition);
                return;
            }

            this.Renderer.DrawBackground(e.Graphics, _rc);
            this.Renderer.DrawScale(e.Graphics, this._rectScale);
            this.Renderer.DrawKnob(e.Graphics, this._rectKnob);
            this.Renderer.DrawKnobIndicator(e.Graphics, this._rectKnob, this._knobIndicatorPosition);
        }
        #endregion

        #region Virtual functions
        protected virtual void CalculateDimensions()
        {
            // Rectangle
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Size.Width;
            h = this.Size.Height;

            // Calculate ratio
            _drawRatio = (Math.Min(w, h)) / 200;
            if (_drawRatio == 0.0)
                _drawRatio = 1;

            // Draw rectangle
            _drawRect.X = x;
            _drawRect.Y = y;
            _drawRect.Width = w - 2;
            _drawRect.Height = h - 2;

            if (w < h)
                _drawRect.Height = w;
            else if (w > h)
                _drawRect.Width = h;

            if (_drawRect.Width < 10)
                _drawRect.Width = 10;
            if (_drawRect.Height < 10)
                _drawRect.Height = 10;

            this._rectScale = this._drawRect;
            this._rectKnob = this._drawRect;
            this._rectKnob.Inflate(-20 * this._drawRatio, -20 * this._drawRatio);

            this._knobCenter.X = this._rectKnob.Left + (this._rectKnob.Width * 0.5F);
            this._knobCenter.Y = this._rectKnob.Top + (this._rectKnob.Height * 0.5F);

            this._knobIndicatorPosition = this.GetPositionFromValue(this.Value);
        }

        public virtual float GetValueFromPosition(PointF position)
        {
            float degree = 0.0F;
            float v = 0.0F;

            PointF center = this.KnobCenter;

            if (position.X <= center.X)
            {
                degree = (center.Y - position.Y) / (center.X - position.X);
                degree = (float)Math.Atan(degree);
                degree = (float)((degree) * (180F / Math.PI) + 45F);
                v = (degree * (this.MaxValue - this.MinValue) / 270F);
            }
            else
            {
                if (position.X > center.X)
                {
                    degree = (position.Y - center.Y) / (position.X - center.X);
                    degree = (float)Math.Atan(degree);
                    degree = (float)(225F + (degree) * (180F / Math.PI));
                    v = (degree * (this.MaxValue - this.MinValue) / 270F);
                }
            }

            if (v > this.MaxValue)
                v = this.MaxValue;

            if (v < this.MinValue)
                v = this.MinValue;

            return v;
        }

        public virtual PointF GetPositionFromValue(float val)
        {
            PointF pos = new PointF(0.0F, 0.0F);

            // Elimina la divisione per 0
            if ((this.MaxValue - this.MinValue) == 0)
                return pos;

            float _indicatorOffset = this.IndicatorOffset * this._drawRatio;

            float degree = 270F * val / (this.MaxValue - this.MinValue);
            degree = (degree + 135F) * (float)Math.PI / 180F;

            pos.X = (int)(Math.Cos(degree) * ((this._rectKnob.Width * 0.5F) - this._indicatorOffset) + this._rectKnob.X + (this._rectKnob.Width * 0.5F));
            pos.Y = (int)(Math.Sin(degree) * ((this._rectKnob.Width * 0.5F) - this._indicatorOffset) + this._rectKnob.Y + (this._rectKnob.Height * 0.5F));

            return pos;
        }
        #endregion

        #region Fire events
        public event KnobChangeValue KnobChangeValue;
        protected virtual void OnKnobChangeValue(KnobEventArgs e)
        {
            if (this.KnobChangeValue != null)
                this.KnobChangeValue(this, e);
        }
        #endregion
    }

    #region Classes for event and event delagates args

    #region Event args class
    /// <summary>
    /// Class for events delegates
    /// </summary>
    public class KnobEventArgs : EventArgs
    {
        private float _val;

        public KnobEventArgs()
        {
        }

        public float Value
        {
            get { return this._val; }
            set { this._val = value; }
        }
    }
    #endregion

    #region Delegates
    public delegate void KnobChangeValue(object sender, KnobEventArgs e);
    #endregion

    #endregion
}
