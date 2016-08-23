using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace GM_Tool_V5
{
    class XListBox : ListBox
    {
        private XColorStyle _colorStyle = XColorStyle.Blue;
        private XColors _colors = new XBlue();

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

        public XListBox()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            this.BackColor = Color.FromArgb(37, 37, 38);
            this.BorderStyle = BorderStyle.None;
            this.ForeColor = _colors.getForeColor();
            this.FormattingEnabled = true;
            this.ItemHeight = 14;
            base.DrawItem += new DrawItemEventHandler(this.DoDrawItem);
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void DoDrawItem(object sender, DrawItemEventArgs e)
        {
            if (e == null || e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          _colors.getBorderColor());//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(this.Items[e.Index].ToString(), e.Font, new SolidBrush(this.ForeColor), e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
}
