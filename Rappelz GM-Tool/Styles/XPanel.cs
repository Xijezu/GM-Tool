using System.Drawing;
using System.Windows.Forms;

namespace GM_Tool_V5 {
    class XPanel : Panel
    {
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
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(0, 122, 204)), 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }        
    }
}
