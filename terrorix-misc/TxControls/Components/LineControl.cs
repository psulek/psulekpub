using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace THE.GenerateUsers.Components
{
    public class LineControl : Control
    {
        private LineType lineType;
        private Orientation orientation;

        public LineControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.FixedHeight |
              ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            lineType = LineType.Etched;
        }

        public override System.Drawing.Size GetPreferredSize(Size proposedSize)
        {
            if (proposedSize == Size.Empty)
                return new Size(150, 10);
            return proposedSize;
        }

        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get { return this.orientation; }
            set
            {
                if (this.orientation != value)
                {
                    this.orientation = value;
                    this.Invalidate();
                }
            }
        }

        [DefaultValue(LineType.Etched)]
        public LineType LineType
        {
            get
            {
                return lineType;
            }
            set
            {
                if (lineType != value)
                {
                    lineType = value;
                    CreatePen();
                    Invalidate();
                }
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                CreatePen();
            }
        }

        Pen pen;
        void CreatePen()
        {
            if (pen != null)
            {
                pen.Dispose();
                pen = null;
            }

            if (lineType == LineType.Single)
                pen = new Pen(ForeColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            bool isHorizontal = this.Orientation == Orientation.Horizontal;
            switch (lineType)
            {
                case LineType.Etched:
                {
                    Border3DSide borderSide = isHorizontal ? Border3DSide.Top : Border3DSide.Left;
                    ControlPaint.DrawBorder3D(e.Graphics, ClientRectangle, Border3DStyle.Etched, borderSide);
                    break;
                }
                case LineType.Single:
                {
                    int x1 = 0;
                    int y1 = 0;
                    int x2 = isHorizontal ? Width - 1 : 0;
                    int y2 = isHorizontal ? 0 : Height - 1;

                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                    break;
                }
            }
        }
    }

    public enum LineType
    {
        Etched,
        Single
    }
}