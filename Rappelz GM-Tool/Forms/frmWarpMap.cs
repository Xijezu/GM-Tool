using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GM_Tool_V5 {
    public class frmWarpMap : Form {
        private IContainer components;
        private PictureBox pbMapImage;
        private frmGlobalUI wndGlobalUI;

        public frmWarpMap(frmGlobalUI pForm) {
            this.InitializeComponent();
            this.wndGlobalUI = pForm;
        }

        protected override void Dispose(bool disposing) {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(frmWarpMap));
            this.pbMapImage = new PictureBox();
            ((ISupportInitialize)this.pbMapImage).BeginInit();
            this.SuspendLayout();
            this.pbMapImage.Cursor = Cursors.Cross;
            this.pbMapImage.Image = GM_Tool_V5.Properties.Resources.Worldmap;
            this.pbMapImage.Location = new Point(1, 2);
            this.pbMapImage.Name = "pbMapImage";
            this.pbMapImage.Size = new Size(564, 643);
            this.pbMapImage.TabIndex = 0;
            this.pbMapImage.TabStop = false;
            this.pbMapImage.MouseClick += new MouseEventHandler(this.pictureBox1_MouseClick);
            this.pbMapImage.MouseMove += new MouseEventHandler(this.pictureBox1_MouseMove);
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(564, 643);
            this.Controls.Add((Control)this.pbMapImage);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Name = "map";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Select Coordinates";
            ((ISupportInitialize)this.pbMapImage).EndInit();
            this.ResumeLayout(false);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
            int iCoordinateX = (e.X * 200) + 81000;
            int iCoordinateY = (e.Y * -200) + 165000;
            this.Text = string.Format("Select Coordinates - X: {0}; Y: {1}", iCoordinateX, iCoordinateY);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
            int iCoordinateX = (e.X * 200) + 81000;
            int iCoordinateY = (e.Y * -200) + 165000;
            wndGlobalUI.UpdateWarpCoordinates(iCoordinateX, iCoordinateY);
            this.Close();
        }
    }
}
