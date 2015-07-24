using System.Drawing;
using System.Windows.Forms;

namespace GM_Tool_V5 {
    #region Toolstrip
    public class ToolStripColors : ToolStripProfessionalRenderer
    {
        public ToolStripColors() : base(new TSColors()) { }
    }

    public class TSColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(63, 63, 65); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(63, 63, 65); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(63, 63, 65); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(63, 63, 65); }
        }

        public override Color MenuStripGradientBegin
        {
            get { return Color.FromArgb(63, 63, 65); }
        }

        public override Color MenuStripGradientEnd
        {
            get { return Color.FromArgb(63, 63, 65); }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(63, 63, 65); }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(45, 45, 48); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(63, 63, 65); }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(45, 45, 48); }
        }
    }
    #endregion
}
