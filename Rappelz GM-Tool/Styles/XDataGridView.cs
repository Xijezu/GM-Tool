using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace GM_Tool_V5
{
    public class XDataGridView : DataGridView
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
                this.AlternatingRowsDefaultCellStyle = GenerateCellStyle(true);
                this.DefaultCellStyle = GenerateCellStyle(false);
                Invalidate(); // causes control to be redrawn
            }
        }

        private DataGridViewCellStyle GenerateCellStyle(bool isAlternate)
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = isAlternate ? Color.FromArgb(42, 42, 44) : Color.FromArgb(45, 45, 48);
            cellStyle.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            cellStyle.ForeColor = Color.White;
            cellStyle.SelectionBackColor = _colors.getBorderColor();
            cellStyle.SelectionForeColor = Color.White;
            return cellStyle;
        }



        private DataGridViewCellStyle GenerateColumnHeaderStyle()
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cellStyle.BackColor = Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(44)))));
            cellStyle.Font = new Font("Segoe UI", 8.25F);
            cellStyle.ForeColor = Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(121)))));
            cellStyle.Padding = new Padding(3);
            cellStyle.SelectionBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            cellStyle.SelectionForeColor = Color.White;
            cellStyle.WrapMode = DataGridViewTriState.True;
            return cellStyle;
        }

        public XDataGridView()
        {
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeColumns = false;
            this.AllowUserToResizeRows = false;
            this.AlternatingRowsDefaultCellStyle = GenerateCellStyle(true);
            this.DefaultCellStyle = GenerateCellStyle(false);
            this.ColumnHeadersDefaultCellStyle = GenerateColumnHeaderStyle();
            this.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
            | AnchorStyles.Left) 
            | AnchorStyles.Right)));
            this.BackgroundColor = Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.BorderStyle = BorderStyle.None;
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.MultiSelect = false;
            this.ReadOnly = true;
            this.RowHeadersVisible = false;
            this.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 8.25F);
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
    }
}
