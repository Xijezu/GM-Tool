using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace GM_Tool_V5 {
    class XPanel : Panel
    {
        private XColorStyle _colorStyle = XColorStyle.Blue;
        private XColors _colors = new XBlue();

        public XPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(new Pen(_colors.getBorderColor()), 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

        [Category("Appearance")]
        public XColorStyle ColorStyle
        {
            get { return _colorStyle; }
            set
            {
                _colorStyle = value;
                if (_colorStyle == XColorStyle.Blue)
                    _colors = new XBlue();
                else if (_colorStyle == XColorStyle.Red)
                    _colors = new XRed();
                Invalidate(); // causes control to be redrawn
            }
        }
    }
}
