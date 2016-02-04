using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Monster
        private void SpawnMonster(object sender, EventArgs e) {
            if ( !cbCustomCoordinates.Checked ) {
                SFM.CopyToClipboard( "//regenerate {0} {1}", SFM.GetSelection( dgvMonster ), ( SFM.IsInt( tbMonsterAmount.Text ) ? tbMonsterAmount.Text : "1" ) );
            }
            else {
                SFM.CopyToClipboard( "/run add_npc({0}, {1}, {3}, {2})", tbMonsterX.Text, tbMonsterY.Text, tbMonsterAmount.Text, SFM.GetSelection( dgvMonster ) );
            }
        }

        private void CustomCoordinatesCheckChanged(object sender, EventArgs e) {
            if ( cbCustomCoordinates.Checked ) {
                tbMonsterX.Enabled = true;
                tbMonsterY.Enabled = true;
            }
            else {
                tbMonsterX.Enabled = false;
                tbMonsterY.Enabled = false;
            }
        }
        #endregion

    }
}
