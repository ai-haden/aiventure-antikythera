using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using FormControls.Utilities;
using Math = System.Math;

namespace FormControls.Items
{
    /// <summary>
    /// Base class for the renderers of the analog dial.
    /// </summary>
    public class AnalogDialRenderer
    {
        public AnalogDialRenderer()
        {
            AnalogDial = null;
        }

        public AnalogDial AnalogDial { get; set; }

        public virtual bool DrawBackground(Graphics gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            Color c = this.AnalogDial.BackColor;
            SolidBrush br = new SolidBrush(c);
            Pen pen = new Pen(c);

            Rectangle _rcTmp = new Rectangle(0, 0, this.AnalogDial.Width, this.AnalogDial.Height);
            gr.DrawRectangle(pen, _rcTmp);
            gr.FillRectangle(br, rc);

            br.Dispose();
            pen.Dispose();

            return true;
        }

        public virtual bool DrawBody(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            Color bodyColor = this.AnalogDial.BodyColor;
            Color cDark = ColorManager.StepColor(bodyColor, 20);

            var br1 = new LinearGradientBrush(rc, bodyColor, cDark, 45);
            Gr.FillEllipse(br1, rc);

            float drawRatio = this.AnalogDial.GetDrawRatio();

            RectangleF _rc = rc;
            _rc.X += 3 * drawRatio;
            _rc.Y += 3 * drawRatio;
            _rc.Width -= 6 * drawRatio;
            _rc.Height -= 6 * drawRatio;

            var br2 = new LinearGradientBrush(_rc, cDark, bodyColor, 45);
            Gr.FillEllipse(br2, _rc);

            return true;
        }

        public virtual bool DrawThresholds(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            float drawRatio = (float)this.AnalogDial.GetDrawRatio();

            RectangleF _rc = rc;
            _rc.Inflate(-18F * drawRatio, -18F * drawRatio);

            double w = _rc.Width;
            double radius = w / 2 - (w * 0.075);

            float startAngle = this.AnalogDial.GetStartAngle();
            float endAngle = this.AnalogDial.GetEndAngle();
            float rangeAngle = endAngle - startAngle;
            float minValue = (float)this.AnalogDial.MinValue;
            float maxValue = (float)this.AnalogDial.MaxValue;

            double stepVal = rangeAngle / (maxValue - minValue);

            foreach (DialThreshold sect in this.AnalogDial.Thresholds)
            {

                float startPathAngle = ((float)(startAngle + (stepVal * sect.StartValue)));
                float endPathAngle = ((float)((stepVal * (sect.EndValue - sect.StartValue))));

                GraphicsPath pth = new GraphicsPath();
                pth.AddArc(_rc, startPathAngle, endPathAngle);

                Pen pen = new Pen(sect.Color, 4.5F * drawRatio);

                Gr.DrawPath(pen, pth);

                pen.Dispose();
                pth.Dispose();
            }

            return false;
        }

        public virtual bool DrawDivisions(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            PointF needleCenter = this.AnalogDial.GetNeedleCenter();
            float startAngle = this.AnalogDial.GetStartAngle();
            float endAngle = this.AnalogDial.GetEndAngle();
            float scaleDivisions = this.AnalogDial.ScaleDivisions;
            float scaleSubDivisions = this.AnalogDial.ScaleSubDivisions;
            float drawRatio = this.AnalogDial.GetDrawRatio();
            double minValue = this.AnalogDial.MinValue;
            double maxValue = this.AnalogDial.MaxValue;
            Color scaleColor = this.AnalogDial.ScaleColor;

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
                Gr.DrawLine(pen, ptStart, ptEnd);

                // Draw strings.
                Font font = new Font(this.AnalogDial.Font.FontFamily, (float)(6F * drawRatio));

                float tx = (float)(cx + (radius - (20 * drawRatio)) * Math.Cos(currentAngle));
                float ty = (float)(cy + (radius - (20 * drawRatio)) * Math.Sin(currentAngle));
                double val = Math.Round(rulerValue);
                String str = String.Format("{0,0:D}", (int)val);

                SizeF size = Gr.MeasureString(str, font);
                Gr.DrawString(str,
                                font,
                                br,
                                tx - (float)(size.Width * 0.5),
                                ty - (float)(size.Height * 0.5));

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
                        Gr.DrawLine(pen, ptStart, ptEnd);
                    }
                }

                font.Dispose();
            }

            return true;
        }

        public virtual bool DrawUM(Graphics gr, RectangleF rc)
        {
            return false;
        }

        public virtual bool DrawValue(Graphics gr, RectangleF rc)
        {
            return false;
        }

        public virtual bool DrawNeedle(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            float w, h;
            w = rc.Width;
            h = rc.Height;

            double minValue = this.AnalogDial.MinValue;
            double maxValue = this.AnalogDial.MaxValue;
            double currValue = this.AnalogDial.Value;
            float startAngle = this.AnalogDial.GetStartAngle();
            float endAngle = this.AnalogDial.GetEndAngle();
            PointF needleCenter = this.AnalogDial.GetNeedleCenter();

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

            SolidBrush br = new SolidBrush(this.AnalogDial.NeedleColor);
            Pen pen = new Pen(this.AnalogDial.NeedleColor);
            Gr.DrawPath(pen, pth1);
            Gr.FillPath(br, pth1);

            return true;
        }

        public virtual bool DrawNeedleCover(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            Color clr = this.AnalogDial.NeedleColor;
            RectangleF _rc = rc;
            float drawRatio = this.AnalogDial.GetDrawRatio();

            Color clr1 = Color.FromArgb(70, clr);

            _rc.Inflate(5 * drawRatio, 5 * drawRatio);

            SolidBrush brTransp = new SolidBrush(clr1);
            Gr.FillEllipse(brTransp, _rc);

            clr1 = clr;
            Color clr2 = ColorManager.StepColor(clr, 75);
            LinearGradientBrush br1 = new LinearGradientBrush(rc,
                                                               clr1,
                                                               clr2,
                                                               45);
            Gr.FillEllipse(br1, rc);
            return true;
        }

        public virtual bool DrawGlass(Graphics Gr, RectangleF rc)
        {
            if (this.AnalogDial == null)
                return false;

            if (this.AnalogDial.ViewGlass == false)
                return true;

            Color clr1 = Color.FromArgb(40, 200, 200, 200);

            Color clr2 = Color.FromArgb(0, 200, 200, 200);
            LinearGradientBrush br1 = new LinearGradientBrush(rc, clr1, clr2, 45);
            Gr.FillEllipse(br1, rc);

            return true;
        }
    }
}
