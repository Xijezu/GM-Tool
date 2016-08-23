using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;


namespace GM_Tool_V5 {
    class XButton : Button
    {

        private XColorStyle _colorStyle = XColorStyle.Blue;
        private XColors _colors;

        public XButton()
        {
             _colors = new XBlue();
            SetStyle(ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.UserPaint
                    | ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.ResizeRedraw, true);

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
            setColors();
            this.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void setColors()
        {
            if (_colorStyle == XColorStyle.Blue)
                _colors = new XBlue();
            else if (_colorStyle == XColorStyle.Red)
                _colors = new XRed();
            
            this.BackColor = _colors.getBackgroundColor();
            this.ForeColor = _colors.getForeColor();
            this.FlatAppearance.BorderColor = _colors.getBorderColor();
            this.FlatAppearance.MouseOverBackColor = _colors.getHoverColor();
            this.FlatAppearance.MouseDownBackColor = _colors.getBorderColor();
        }

        [Category("Appearance")]
        public XColorStyle ColorStyle
        {
            get { return _colorStyle; }
            set
            {
                _colorStyle = value;
                setColors();
                Invalidate(); // causes control to be redrawn
            }
        }
    }
}
