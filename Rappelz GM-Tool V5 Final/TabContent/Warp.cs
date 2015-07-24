using System;
using System.Linq;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        private void Warp(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run warp({0}, {1}, \"{2}\")", tbWarpX.Text, tbWarpY.Text, GetSelectedCharacter());
        }

        private void WarpToYou(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run warp(gv(\"x\"), gv(\"y\"), \"{0}\")", GetSelectedCharacter());
        }

        private void WarpToSomeone(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run warp(gv(\"x\", \"{0}\"), gv(\"y\", \"{0}\"))", GetSelectedCharacter());
        }

        private void OpenWarpmap(object sender, EventArgs e) {
            frmWarpMap pMap = new frmWarpMap(this);
            pMap.ShowDialog();
        }

        private void AddWarpLocation(object sender, EventArgs e) {
            if (tbWarpAddX.Text != string.Empty && tbWarpAddY.Text != string.Empty && tbWarpAddName.Text != string.Empty) {
                string[] val = { tbWarpAddX.Text, tbWarpAddY.Text, tbWarpAddName.Text };
                pListWarps.Add(new SFM.WarpInterface(val));
                SFM.UpdateWarpList(pListWarps.ToList<SFM.WarpInterface>());
                tbWarpAddX.Text = "X";
                tbWarpAddX.Text = "Y";
                tbWarpAddName.Text = "Location name";
            }
        }

        private void DeleteWarpLocation(object sender, EventArgs e) {
            try {
                pListWarps.RemoveAt(dgvWarps.SelectedRows[0].Index);
                SFM.UpdateWarpList(pListWarps.ToList<SFM.WarpInterface>());
            } catch { }
        }

        private void dgvWarpSelectionChanged(object sender, EventArgs e) {
            try {
                var row = dgvWarps.Rows[dgvWarps.Rows.GetFirstRow(System.Windows.Forms.DataGridViewElementStates.Selected)];
                tbWarpX.Text = row.Cells[0].Value.ToString();
                tbWarpY.Text = row.Cells[1].Value.ToString();
            } catch { }
        }

        public void UpdateWarpCoordinates(int iX, int iY) {
            tbWarpX.Text = iX.ToString();
            tbWarpY.Text = iY.ToString();
        }
    }
}
