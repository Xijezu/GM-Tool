using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace GM_Tool_V5 {
    class XTabControl : TabControl
    {
        /// <summary>
        /// Properties
        /// </summary>
        public Color TabBackgroundColor { get; set; }
        public Color SelectedTabBackroundColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Font TabFont { get; set; }
        public Color TabForeColor { get; set; }
        private XColorStyle _colorStyle = XColorStyle.Blue;
        private XColors _colors = new XBlue();
        /// <summary>
        /// Constructor
        /// </summary>
        public XTabControl()
        {
            // set styles
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw, true);
            this.ItemSize = new Size(100, 28);
            this.SizeMode = TabSizeMode.Normal;
            this.TabFont = new Font("Segoe UI", 9.0f, FontStyle.Regular, GraphicsUnit.Point);
        }
        /// <summary>
        /// Overridden paint event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // System paint
            base.OnPaint(e);
            // Background
            e.Graphics.Clear(this.BackgroundColor);
            // Tabs
            for (int i = 0; i < base.TabPages.Count; i++)
                if (i != this.SelectedIndex)
                    PaintTab(i, e.Graphics);
            // Draw selected tab
            this.PaintSelectedTab(e.Graphics);
        }

        private void setStyle()
        {
            if (_colorStyle == XColorStyle.Blue)
                _colors = new XBlue();
            else if (_colorStyle == XColorStyle.Red)
                _colors = new XRed();
            this.TabBackgroundColor = _colors.getBackgroundColor();
            this.SelectedTabBackroundColor = _colors.getTabBGColor();
            this.BackgroundColor = _colors.getBackgroundColor();
            this.TabForeColor = _colors.getForeColor();
        }

        [Category("Appearance")]
        public XColorStyle ColorStyle
        {
            get { return _colorStyle; }
            set
            {
                _colorStyle = value;
                setStyle();
                Invalidate(); // causes control to be redrawn
            }
        }


        /// <summary>
        /// Paint tab
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="e"></param>
        private void PaintTab(int Index, Graphics e)
        {
            // Tab rectangle
            Rectangle TabRect = base.GetTabRect(Index);
            // Darker line color
            Color TabLineColor = _colors.getTabBGColor();
            // Tab bitmap & graphics object
            Bitmap TabBmp = new Bitmap(TabRect.Width, TabRect.Height);
            Graphics g = Graphics.FromImage(TabBmp);
            // Top rectangle
            g.FillRectangle(new SolidBrush(this.TabBackgroundColor), 2, 0, TabBmp.Width - 4, TabBmp.Height - 10);
            // Line
            g.DrawLine(new Pen(new SolidBrush(TabLineColor), 2), new Point(2, TabBmp.Height - 10), new Point(TabBmp.Width - 2, TabBmp.Height - 10));
            // String
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;
            g.DrawString(this.TabPages[Index].Text, this.TabFont, new SolidBrush(this.TabForeColor), new Rectangle(2, 0, TabBmp.Width - 4, TabBmp.Height - 10), sf);
            // Draw Image on tabpage
            e.DrawImage(TabBmp, TabRect);
        }
        /// <summary>
        /// Paint selected tab
        /// </summary>
        /// <param name="e"></param>
        private void PaintSelectedTab(Graphics e)
        {
            // Index in range?
            if (this.SelectedIndex < 0)
                return;
            // Tab rectangle
            Rectangle TabRect = base.GetTabRect(this.SelectedIndex);
            // Darker line color
            Color TabLineColor = _colors.getTabBGColor();
            // Tab bitmap & graphics object
            Bitmap TabBmp = new Bitmap(TabRect.Width, TabRect.Height);
            Graphics g = Graphics.FromImage(TabBmp);
            // Top rectangle
            g.FillRectangle(new SolidBrush(this.SelectedTabBackroundColor), new Rectangle(2, 0, TabBmp.Width - 4, TabBmp.Height - 10));
            // Line
            g.DrawLine(new Pen(new SolidBrush(TabLineColor), 2), new Point(2, TabBmp.Height - 10), new Point(TabBmp.Width - 2, TabBmp.Height - 10));
            // String
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;
            g.DrawString(this.TabPages[this.SelectedIndex].Text, this.TabFont, new SolidBrush(this.TabForeColor), new Rectangle(2, 0, TabBmp.Width - 4, TabBmp.Height - 10), sf);
            // Traw Image on tabpage
            e.DrawImage(TabBmp, TabRect);
        }
    }
}
