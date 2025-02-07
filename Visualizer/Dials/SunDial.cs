using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FormControls.Dials
{
    /// <summary>
    /// Class for the Sundial control.
    /// </summary>
    public sealed partial class Sundial : UserControl
    {
        public enum SundialStyle
        {
            Circular = 0,
        };

        private SundialStyle _dialStyle;
        private Color bodyColor;
        private Color needleColor;
        private Color scaleColor;
        private bool viewGlass;
        private double currValue;
        private double minValue;
        private double maxValue;
        private int scaleDivisions;
        private int scaleSubDivisions;
        private SundialRenderer renderer;
        private SundialThresholdCollection listThreshold;

        private PointF needleCenter;
        private RectangleF drawRect;
        private RectangleF glossyRect;
        private RectangleF needleCoverRect;
        private float startAngle;
        private float endAngle;
        private float drawRatio;
        private SundialRenderer defaultRenderer;

        public Sundial()
        {
            // Initialization
            InitializeComponent();

            // Properties initialization
            this.bodyColor = Color.Silver;
            this.needleColor = Color.Goldenrod;
            this.scaleColor = Color.White;
            this._dialStyle = SundialStyle.Circular;
            this.viewGlass = true;
            this.startAngle = 135;
            this.endAngle = 495;
            this.minValue = 0;
            this.maxValue = 365;
            this.currValue = 0;
            this.scaleDivisions = 0;
            this.scaleSubDivisions = 5;
            this.renderer = null;

            // Create the sector list
            this.listThreshold = new SundialThresholdCollection();

            // Set the styles for drawing
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.DoubleBuffer |
                ControlStyles.SupportsTransparentBackColor,
                true);

            // Transparent background
            this.BackColor = Color.Transparent;

            // Create the default renderer
            this.defaultRenderer = new SundialRenderer();
            this.defaultRenderer.Sundial = this;

            this.CalculateDimensions();
        }

        [Category("Sundial"), Description("Style of the control.")]
        public SundialStyle DialStyle
        {
            get { return _dialStyle; }
            set
            {
                _dialStyle = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Color of the body of the control.")]
        public Color BodyColor
        {
            get { return bodyColor; }
            set
            {
                bodyColor = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Color of the needle.")]
        public Color NeedleColor
        {
            get { return needleColor; }
            set
            {
                needleColor = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Show or hide the glass effect.")]
        public bool ViewGlass
        {
            get { return viewGlass; }
            set
            {
                viewGlass = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Color of the scale of the control.")]
        public Color ScaleColor
        {
            get { return scaleColor; }
            set
            {
                scaleColor = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Value of the data.")]
        public double Value
        {
            get { return currValue; }
            set
            {
                double val = value;
                if (val > maxValue)
                    val = maxValue;

                if (val < minValue)
                    val = minValue;

                currValue = val;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Minimum value of the data.")]
        public double MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Maximum value of the data.")]
        public double MaxValue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Number of the scale divisions.")]
        public int ScaleDivisions
        {
            get { return scaleDivisions; }
            set
            {
                scaleDivisions = value;
                CalculateDimensions();
                Invalidate();
            }
        }

        [Category("Sundial"), Description("Number of the scale subdivisions.")]
        public int ScaleSubDivisions
        {
            get { return scaleSubDivisions; }
            set
            {
                scaleSubDivisions = value;
                CalculateDimensions();
                Invalidate();
            }
        }

        [Browsable(false)]
        public SundialThresholdCollection Thresholds
        {
            get { return this.listThreshold; }
        }

        [Browsable(false)]
        public SundialRenderer Renderer
        {
            get { return this.renderer; }
            set
            {
                this.renderer = value;
                if (this.renderer != null)
                    renderer.Sundial = this;
                Invalidate();
            }
        }

        public float GetDrawRatio()
        {
            return this.drawRatio;
        }

        public float GetStartAngle()
        {
            return this.startAngle;
        }

        public float GetEndAngle()
        {
            return this.endAngle;
        }

        public PointF GetNeedleCenter()
        {
            return this.needleCenter;
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Calculate dimensions
            CalculateDimensions();

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF _rc = new RectangleF(0, 0, this.Width, this.Height);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (this.renderer == null)
            {
                this.defaultRenderer.DrawBackground(e.Graphics, _rc);
                this.defaultRenderer.DrawBody(e.Graphics, drawRect);
                this.defaultRenderer.DrawThresholds(e.Graphics, drawRect);
                this.defaultRenderer.DrawDivisions(e.Graphics, drawRect);
                this.defaultRenderer.DrawUm(e.Graphics, drawRect);
                this.defaultRenderer.DrawValue(e.Graphics, drawRect);
                this.defaultRenderer.DrawNeedle(e.Graphics, drawRect);
                this.defaultRenderer.DrawNeedleCover(e.Graphics, this.needleCoverRect);
                this.defaultRenderer.DrawGlass(e.Graphics, this.glossyRect);
                return;
            }

            this.renderer.DrawBackground(e.Graphics, _rc);
            this.renderer.DrawBody(e.Graphics, drawRect);
            this.renderer.DrawThresholds(e.Graphics, drawRect);
            this.renderer.DrawDivisions(e.Graphics, drawRect);
            this.renderer.DrawUm(e.Graphics, drawRect);
            this.renderer.DrawValue(e.Graphics, drawRect);
            this.renderer.DrawNeedle(e.Graphics, drawRect);
            this.renderer.DrawNeedleCover(e.Graphics, this.needleCoverRect);
            this.renderer.DrawGlass(e.Graphics, this.glossyRect);
        }

        private void CalculateDimensions()
        {
            // Rectangle.
            float x, y, w, h;
            x = 0;
            y = 0;
            w = this.Size.Width;
            h = this.Size.Height;

            // Calculate ratio.
            drawRatio = (Math.Min(w, h)) / 200;
            if (drawRatio == 0.0)
                drawRatio = 1;

            // Draw rectangle.
            drawRect.X = x;
            drawRect.Y = y;
            drawRect.Width = w - 2;
            drawRect.Height = h - 2;

            if (w < h)
                drawRect.Height = w;
            else if (w > h)
                drawRect.Width = h;

            if (drawRect.Width < 10)
                drawRect.Width = 10;
            if (drawRect.Height < 10)
                drawRect.Height = 10;

            // Calculate needle center
            needleCenter.X = drawRect.X + (drawRect.Width / 2);
            needleCenter.Y = drawRect.Y + (drawRect.Height / 2);

            // Needle cover rect
            needleCoverRect.X = needleCenter.X - (20 * drawRatio);
            needleCoverRect.Y = needleCenter.Y - (20 * drawRatio);
            needleCoverRect.Width = 40 * drawRatio;
            needleCoverRect.Height = 40 * drawRatio;

            // Glass effect rect
            glossyRect.X = drawRect.X + (20 * drawRatio);
            glossyRect.Y = drawRect.Y + (10 * drawRatio);
            glossyRect.Width = drawRect.Width - (40 * drawRatio);
            glossyRect.Height = needleCenter.Y + (30 * drawRatio);
        }
    }
}
