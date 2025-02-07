using System.Drawing;
using System.Drawing.Drawing2D;
using FormControls.Utilities;

namespace FormControls.Items
{
    /// <summary>
    /// Base class for the renderers of the knob
    /// </summary>
    public class KnobRenderer
    {
        /// <summary>
        /// Control to render
        /// </summary>
        private Knob _knob = null;
        /// <summary>
        /// Gets or sets the knob.
        /// </summary>
        /// <value>
        /// The knob.
        /// </value>
        public Knob Knob
        {
            set { this._knob = value; }
            get { return this._knob; }
        }
        /// <summary>
        /// Draw the background of the control
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public virtual bool DrawBackground(Graphics graphics, RectangleF rectangle)
        {
            if (this.Knob == null)
                return false;

            Color backColor = this.Knob.BackColor;
            SolidBrush solidBrush = new SolidBrush(backColor);
            Pen pen = new Pen(backColor);

            Rectangle rcTmp = new Rectangle(0, 0, this.Knob.Width, this.Knob.Height);
            graphics.DrawRectangle(pen, rcTmp);
            graphics.FillRectangle(solidBrush, rectangle);

            solidBrush.Dispose();
            pen.Dispose();

            return true;
        }
        /// <summary>
        /// Draw the scale of the control
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawScale(Graphics Gr, RectangleF rc)
        {
            if (this.Knob == null)
                return false;

            Color cKnob = this.Knob.ScaleColor;
            Color cKnobDark = ColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(rc, cKnobDark, cKnob, 45);

            Gr.FillEllipse(br, rc);

            br.Dispose();

            return true;
        }
        /// <summary>
        /// Draw the knob of the control
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public virtual bool DrawKnob(Graphics graphics, RectangleF rectangle)
        {
            if (this.Knob == null)
                return false;

            Color cKnob = this.Knob.KnobColor;
            Color cKnobDark = ColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(rectangle, cKnob, cKnobDark, 45);

            graphics.FillEllipse(br, rectangle);

            br.Dispose();

            return true;
        }
        /// <summary>
        /// Draws the knob indicator.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public virtual bool DrawKnobIndicator(Graphics graphics, RectangleF rectangle, PointF position)
        {
            if (this.Knob == null)
                return false;

            RectangleF _rc = rectangle;
            _rc.X = position.X - 4;
            _rc.Y = position.Y - 4;
            _rc.Width = 8;
            _rc.Height = 8;

            Color cKnob = this.Knob.IndicatorColor;
            Color cKnobDark = ColorManager.StepColor(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(_rc, cKnobDark, cKnob, 45);

            graphics.FillEllipse(br, _rc);

            br.Dispose();

            return true;
        }
    }
}
