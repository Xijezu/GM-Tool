using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Pets
        private void AddPet(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run insert_item({0}, 1, {1}, 0, {3}, \"{2}\")",
                                SFM.GetSelection(dgvPets),
                                cbPetsTamed.Checked ? cbPetsStage.Text : "0",
                                GetSelectedCharacter(),
                                cbPetsTamed.Checked ? "-2147483648" : "2");
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
            SFM.CopyToClipboard("/run insert_item({0}, 1, 0, 0, 2, \"{1}\")", iItem, GetSelectedCharacter());
        }
        #endregion
    }
}
