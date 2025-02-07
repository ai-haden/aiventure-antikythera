using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using FormControls.Utilities;
using Math = System.Math;

namespace FormControls.Dials
{
    /// <summary>
    /// Base class for the renderers of the analog dial.
    /// </summary>
    /// <remarks>This is the most successful fulfilling the needs of the gearing model.</remarks>
    public class SundialRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SundialRenderer"/> class.
        /// </summary>
        public SundialRenderer()
        {
            Sundial = null;
        }

        public Sundial Sundial { get; set; }

        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.Sundial == null)
                return false;

            Color c = this.Sundial.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle rcTmp = new Rectangle(0, 0, this.Sundial.Width, this.Sundial.Height);
            gr.DrawRectangle(pen, rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }
        /// <summary>
        /// Draws the body.
        /// </summary>
        /// <param name="gr">The graphics.</param>
        /// <param name="rc">The rectangle.</param>
        public virtual bool DrawBody(Graphics gr, RectangleF rc)
        {
            if (this.Sundial == null)
                return false;

            Color bodyColor = this.Sundial.BodyColor;
            Color cDark = ColorManager.StepColor(bodyColor, 20);

            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               bodyColor,
                                                               cDark,
                                                               45);
            gr.FillEllipse(br1, rc);

            float drawRatio = this.Sundial.GetDrawRatio();

            RectangleF _rc = rc;
            _rc.X += 3 * drawRatio;
            _rc.Y += 3 * drawRatio;
            _rc.Width -= 6 * drawRatio;
            _rc.Height -= 6 * drawRatio;

            LinearGradientBrush br2 = new LinearGradientBrush(_rc,
                                                               cDark,
                                                               bodyColor,
                                                               45);
            gr.FillEllipse(br2, _rc);

            return true;
        }
        /// <summary>
        /// Draws the thresholds.
        /// </summary>
        /// <param name="gr">The graphics.</param>
        /// <param name="rc">The rectangle.</param>
        /// <returns></returns>
        public virtual bool DrawThresholds(Graphics gr, RectangleF rc)
        {
            if (this.Sundial == null)
                return false;

            float drawRatio = (float)this.Sundial.GetDrawRatio();

            RectangleF _rc = rc;
            _rc.Inflate(-18F * drawRatio, -18F * drawRatio);

            double w = _rc.Width;
            double radius = w / 2 - (w * 0.075);

            float startAngle = this.Sundial.GetStartAngle();
            float endAngle = this.Sundial.GetEndAngle();
            float rangeAngle = endAngle - startAngle;
            float minValue = (float)this.Sundial.MinValue;
            float maxValue = (float)this.Sundial.MaxValue;

            double stepVal = rangeAngle / (maxValue - minValue);

            foreach (SundialThreshold sect in this.Sundial.Thresholds)
            {

                float startPathAngle = ((float)(startAngle + (stepVal * sect.StartValue)));
                float endPathAngle = ((float)((stepVal * (sect.EndValue - sect.StartValue))));

                GraphicsPath pth = new GraphicsPath();
                pth.AddArc(_rc, startPathAngle, endPathAngle);

                Pen pen = new Pen(sect.Color, 4.5F * drawRatio);

                gr.DrawPath(pen, pth);

                pen.Dispose();
                pth.Dispose();
            }
            return false;
        }
        /// <summary>
        /// Draws the divisions.
        /// </summary>
        /// <param name="gr">The graphics.</param>
        /// <param name="rc">The rectangle.</param>
        public virtual bool DrawDivisions(Graphics gr, RectangleF rc)
        {
            if (Sundial == null)
                return false;

            PointF needleCenter = Sundial.GetNeedleCenter();
            float startAngle = Sundial.GetStartAngle();
            float endAngle = Sundial.GetEndAngle();
            float scaleDivisions = Sundial.ScaleDivisions;
            float scaleSubDivisions = Sundial.ScaleSubDivisions;
            float drawRatio = Sundial.GetDrawRatio();
            double minValue = Sundial.MinValue;
            double maxValue = Sundial.MaxValue;
            Color scaleColor = Sundial.ScaleColor;

            float cx = needleCenter.X;
            float cy = needleCenter.Y;
            float w = rc.Width;
            float h = rc.Height;

            float incr = Utilities.Math.GetRadianFloat((endAngle - startAngle) / ((scaleDivisions - 1) * (scaleSubDivisions + 1)));
            float currentAngle = Utilities.Math.GetRadianFloat(startAngle);
            float radius = (float)(w / 2 - (w * 0.08));
            float rulerValue = (float)minValue;

            Pen pen = new Pen(scaleColor, (1 * drawRatio));
            SolidBrush br = new SolidBrush(scaleColor);

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);
            int n = 0;
            for (; n < scaleDivisions; n++)
            {
                // Draw thick line.
                ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                ptEnd.X = (float)(cx + (radius - w / 20) * Math.Cos(currentAngle));
                ptEnd.Y = (float)(cy + (radius - w / 20) * Math.Sin(currentAngle));
                gr.DrawLine(pen, ptStart, ptEnd);

                // Draw strings.
                Font font = new Font(Sundial.Font.FontFamily, (float)(6F * drawRatio));

                float tx = (float)(cx + (radius - (20 * drawRatio)) * Math.Cos(currentAngle));
                float ty = (float)(cy + (radius - (20 * drawRatio)) * Math.Sin(currentAngle));
                double val = Math.Round(rulerValue);
                String str = String.Format("{0,0:D}", (int)val);

                SizeF size = gr.MeasureString(str, font);
                if ((str != "0") && (str != "1")) // Don't draw the zeroth or first graticule.
                {
                    gr.DrawString(str,
                                  font,
                                  br,
                                  tx - (float)(size.Width * 0.5),
                                  ty - (float)(size.Height * 0.5));
                }

                rulerValue += (float)((maxValue - minValue) / (scaleDivisions - 1));

                if (n == scaleDivisions - 1)
                {
                    font.Dispose();
                    break;
                }

                if (scaleDivisions <= 0)
                    currentAngle += incr;
                else
                {
                    for (int j = 0; j <= scaleSubDivisions; j++)
                    {
                        currentAngle += incr;
                        ptStart.X = (float)(cx + radius * Math.Cos(currentAngle));
                        ptStart.Y = (float)(cy + radius * Math.Sin(currentAngle));
                        ptEnd.X = (float)(cx + (radius - w / 50) * Math.Cos(currentAngle));
                        ptEnd.Y = (float)(cy + (radius - w / 50) * Math.Sin(currentAngle));
                        gr.DrawLine(pen, ptStart, ptEnd);
                    }
                }

                font.Dispose();
            }

            return true;
        }

        public virtual bool DrawUm(Graphics gr, RectangleF rc)
        {
            return false;
        }

        public virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            return false;
        }

        public virtual bool DrawNeedle(Graphics gr, RectangleF rc)
        {
            if (this.Sundial == null)
                return false;

            float w, h;
            w = rc.Width;
            h = rc.Height;

            double minValue = Sundial.MinValue;
            double maxValue = Sundial.MaxValue;
            double currValue = Sundial.Value;
            float startAngle = Sundial.GetStartAngle();
            float endAngle = Sundial.GetEndAngle();
            PointF needleCenter = Sundial.GetNeedleCenter();

            float radius = (float)(w / 2 - (w * 0.12));
            float val = (float)(maxValue - minValue);

            val = (float)((100 * (currValue - minValue)) / val);
            val = ((endAngle - startAngle) * val) / 100;
            val += startAngle;

            float angle = Utilities.Math.GetRadianFloat(val);

            float cx = needleCenter.X;
            float cy = needleCenter.Y;

            PointF ptStart = new PointF(0, 0);
            PointF ptEnd = new PointF(0, 0);

            GraphicsPath pth1 = new GraphicsPath();

            ptStart.X = cx;
            ptStart.Y = cy;
            angle = Utilities.Math.GetRadianFloat(val + 10);
            ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
            ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            ptStart = ptEnd;
            angle = Utilities.Math.GetRadianFloat(val);
            ptEnd.X = (float)(cx + radius * Math.Cos(angle));
            ptEnd.Y = (float)(cy + radius * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            ptStart = ptEnd;
            angle = Utilities.Math.GetRadianFloat(val - 10);
            ptEnd.X = (float)(cx + (w * .09F) * Math.Cos(angle));
            ptEnd.Y = (float)(cy + (w * .09F) * Math.Sin(angle));
            pth1.AddLine(ptStart, ptEnd);

            pth1.CloseFigure();

            SolidBrush br = new SolidBrush(Sundial.NeedleColor);
            Pen pen = new Pen(Sundial.NeedleColor);
            gr.DrawPath(pen, pth1);
            gr.FillPath(br, pth1);

            return true;
        }

        public virtual bool DrawNeedleCover(Graphics gr, RectangleF rc)
        {
            if (Sundial == null)
                return false;

            Color clr = Sundial.NeedleColor;
            RectangleF _rc = rc;
            float drawRatio = Sundial.GetDrawRatio();

            Color clr1 = Color.FromArgb(70, clr);

            _rc.Inflate(5 * drawRatio, 5 * drawRatio);

            SolidBrush brTransp = new SolidBrush(clr1);
            gr.FillEllipse(brTransp, _rc);

            clr1 = clr;
            Color clr2 = ColorManager.StepColor(clr, 75);
            LinearGradientBrush br1 = new LinearGradientBrush(rc, clr1, clr2, 45);
            gr.FillEllipse(br1, rc);
            return true;
        }

        public virtual bool DrawGlass(Graphics gr, RectangleF rc)
        {
            if (this.Sundial == null)
                return false;

            if (this.Sundial.ViewGlass == false)
                return true;

            Color clr1 = Color.FromArgb(40, 200, 200, 200);

            Color clr2 = Color.FromArgb(0, 200, 200, 200);
            LinearGradientBrush br1 = new LinearGradientBrush(rc, clr1, clr2, 45);
            gr.FillEllipse(br1, rc);

            return true;
        }
    }
}
