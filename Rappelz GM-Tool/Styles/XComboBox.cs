using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace GM_Tool_V5 {
    class XComboBox : ComboBox
{
    private Brush BorderBrush = new SolidBrush(Color.FromArgb(45,45,48));
    private Brush ArrowBrush = new SolidBrush(Color.FromArgb(153, 153, 153));
    private Brush DropButtonBrush = new SolidBrush(Color.FromArgb(45, 45, 48));

    private Color _borderColor = Color.Black;
    private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;

    private Color _ButtonColor = Color.FromArgb(0, 122, 204);

    public Color ButtonColor
    {
        get { return _ButtonColor; }
        set
        {
            _ButtonColor = value;
            DropButtonBrush = new SolidBrush(this.ButtonColor);
            this.Invalidate();
        }
    }

    public XComboBox()
    {
        this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.BackColor = Color.FromArgb(45, 45, 48);
        this.ForeColor = Color.FromArgb(241, 241, 241);
        this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);

        switch (m.Msg)
        {
            case 0xf:
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.FromArgb(45, 45, 48));
                g.FillRectangle(BorderBrush, this.ClientRectangle);

                //Draw the background of the dropdown button
                Rectangle rect = new Rectangle(this.Width - 17, 0, 17, this.Height);
                g.FillRectangle(DropButtonBrush, rect);

                // Draw the name of the selected item
                if (this.DropDownStyle == ComboBoxStyle.DropDownList) {
                    g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), 2, (this.Height / 2) - (this.Font.Size / 2));
                }

                //Create the path for the arrow
                System.Drawing.Drawing2D.GraphicsPath pth = new System.Drawing.Drawing2D.GraphicsPath();
                PointF TopLeft = new PointF(this.Width - 13, (this.Height - 5) / 2);
                PointF TopRight = new PointF(this.Width - 6, (this.Height - 5) / 2);
                PointF Bottom = new PointF(this.Width - 9, (this.Height + 2) / 2);
                pth.AddLine(TopLeft, TopRight);
                pth.AddLine(TopRight, Bottom);
                if(this.DroppedDown)
                {
                    ArrowBrush = new SolidBrush(Color.FromArgb(0, 122, 204));
                }
                else
                {
                    ArrowBrush  = new SolidBrush(Color.FromArgb(153, 153, 153));
                }

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //Draw the arrow
                g.FillPath(ArrowBrush, pth);

                break;
            default:
                break;
        }
    }

    [Category("Appearance")]
    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            Invalidate(); // causes control to be redrawn
        }
    }

    [Category("Appearance")]
    public ButtonBorderStyle BorderStyle
    {
        get { return _borderStyle; }
        set
        {
            _borderStyle = value;
            Invalidate();
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
