using System.Drawing;

namespace GM_Tool_V5
{
    public class XColors
    {
        static public XColorStyle CURRENT_COLOR = XColorStyle.Blue;

        public virtual Color getBorderColor() { return Color.Black; }
        public virtual Color getBackgroundColor() { return Color.FromArgb(45, 45, 48); }
        public virtual Color getForeColor() { return Color.FromArgb(241, 241, 241); }
        public virtual Color getHoverColor() { return Color.FromArgb(63, 63, 65); }
        public virtual Color getTabBGColor() { return Color.Black; }
    }

    public enum XColorStyle
    {
        Blue = 0,
        Red
    }

    class XRed : XColors
    {
        public override Color getBorderColor()
        {
            return Color.FromArgb(156, 47, 65);
        }

        public override Color getTabBGColor()
        {
            return getBorderColor();
        }
    }

    class XBlue : XColors
    {
        public override Color getBorderColor()
        {
            return Color.FromArgb(0, 122, 204);
        }

        public override Color getTabBGColor()
        {
            return getBorderColor();
        }
    }
}
