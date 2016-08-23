using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace GM_Tool_V5
{
    class XComboBox : ComboBox
    {
        private XColorStyle _colorStyle = XColorStyle.Blue;
        private XColors _colors = new XRed();
        private Brush ArrowBrush = new SolidBrush(Color.FromArgb(153, 153, 153));

        public XComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += new DrawItemEventHandler(DoDrawItem);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.BackColor = _colors.getBackgroundColor();
            this.ForeColor = _colors.getForeColor();
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
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
            e.Graphics.DrawString(this.Items[e.Index].ToString(), this.Font, new SolidBrush(this.ForeColor), e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            switch (m.Msg)
            {
                case 0xf:
                    Graphics g = this.CreateGraphics();
                    g.FillRectangle(new SolidBrush(_colors.getBackgroundColor()), this.ClientRectangle);

                    //Draw the background of the dropdown button
                    Rectangle rect = new Rectangle(this.Width - 17, 0, 17, this.Height);
                    g.FillRectangle(new SolidBrush(_colors.getBackgroundColor()), rect);

                    // Draw the name of the selected item
                    if (this.DropDownStyle == ComboBoxStyle.DropDownList)
                    {
                        g.DrawString(this.Text, this.Font, new SolidBrush(_colors.getForeColor()), 2, (this.Height / 2) - (this.Font.Size / 2));
                    }

                    //Create the path for the arrow
                    System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                    PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                    PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                    PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                    pth.AddLine(TopLeft, TopRight);
                    pth.AddLine(TopRight, Bottom);

                    Rectangle bounds = new Rectangle(0, 0, Width, Height);
                    ControlPaint.DrawBorder(g, bounds, _colors.getBorderColor(), ButtonBorderStyle.Solid);

                    if (this.DroppedDown)
                    {
                        ArrowBrush = new SolidBrush(_colors.getBorderColor());

                    }
                    else
                    {
                        ArrowBrush = new SolidBrush(_colors.getForeColor());
                    }

                    //Draw the arrow
                    g.FillPath(ArrowBrush, pth);
                    break;
                default:
                    break;
            }
        }

        private void setStyle()
        {
            if (_colorStyle == XColorStyle.Blue)
                _colors = new XBlue();
            else if (_colorStyle == XColorStyle.Red)
                _colors = new XRed();
//             this.TabBackgroundColor = _colors.getBackgroundColor();
//             this.SelectedTabBackroundColor = _colors.getTabBGColor();
//             this.BackgroundColor = _colors.getBackgroundColor();
//             this.TabForeColor = _colors.getForeColor();
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

        protected override void OnLostFocus(System.EventArgs e)
        {
            base.OnLostFocus(e);
            this.Invalidate();
        }

        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            this.Invalidate();
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }
    }
}
