using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;


namespace GM_Tool_V5 {
    class XTextBox : TextBox
    {
        private XColorStyle _colorStyle = XColorStyle.Blue;
        private XColors _colors;

        private string _baseText = "";

        private bool _firstEnter = false;
        private bool _isChanged = false;
        private bool _isNumeric = false;

        public XTextBox()
        {
            setColors();
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.Font = new System.Drawing.Font("Segoe UI", 8.0F);
            //SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (!_firstEnter) {
                _baseText = this.Text;
                _firstEnter = true;
            }

            if (!_isChanged)
            {
                this.Text = "";
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (_isNumeric) {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                    (e.KeyChar != '.')) {
                        e.Handled = true;
                }
            }

            if (!e.Handled)
                _isChanged = true;

            base.OnKeyPress(e);
        }

        protected override void OnLeave(EventArgs e) {
            base.OnLeave(e);
            if (!_isChanged || this.Text == string.Empty) {
                this.Text = _baseText;
            }
        }

        [Category("Behavior")]
        public bool NumericTextBox {
            get { return _isNumeric; }
            set {
                _isNumeric = value;
                Invalidate();
            }
        }

        private void setColors()
        {
            if (_colorStyle == XColorStyle.Blue)
                _colors = new XBlue();
            else if (_colorStyle == XColorStyle.Red)
                _colors = new XRed();

            this.BackColor = _colors.getBackgroundColor();
            this.ForeColor = _colors.getForeColor();
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
