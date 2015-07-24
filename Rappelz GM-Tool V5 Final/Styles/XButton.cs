using System.Drawing;
using System.Windows.Forms;

namespace GM_Tool_V5 {
    class XButton : Button
    {
        public XButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint
                    | ControlStyles.UserPaint
                    | ControlStyles.OptimizedDoubleBuffer
                    | ControlStyles.ResizeRedraw, true);
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.FromArgb(45, 45, 48);
            this.ForeColor = Color.FromArgb(241, 241, 241);
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 122, 204);
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(63, 63, 65);
            this.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 122, 204);
            this.Font = new System.Drawing.Font("Segoe UI", 8F);

            this.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }
    }
}
