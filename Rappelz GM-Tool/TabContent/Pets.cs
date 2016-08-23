using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Pets
        private void AddPet(object sender, EventArgs e) {
            if ( this.useOldPetListToolStripMenuItem.Checked ) {
                SFM.CopyToClipboard( "/run insert_item({0}, 1, 0, 0, {1})",
                                    SFM.GetSelection( dgvPets ),
                                    cbPetsTamed.Checked ? "-2147483648" : "2" );
            }
            else {
                SFM.CopyToClipboard( "/run insert_summon_by_summon_id({0})", SFM.GetSelection( dgvPets ) );
            }
        }

        private void SetStage(object sender, EventArgs e) {
            if(SFM.IsInt(cbPetsStage.Text) && SFM.IsInt(cbPetsSlot.Text)) {
                SFM.CopyToClipboard( "/run creature_enhance({0}, {1})", cbPetsSlot.Text, cbPetsStage.Text );
            }
        }

        private void AddPetSpecificItem(object sender, EventArgs e) {
            int iItem = 0;
            if (sender.Equals(btnPetsCataclyst)) {
                iItem = 710001;
            } else if (sender.Equals(btnPetsFragment)) {
                iItem = 710002;
            } else {
                iItem = 710003;
            }
            SFM.CopyToClipboard("/run insert_item({0}, 1)", iItem);
        }
        #endregion
    }
}
