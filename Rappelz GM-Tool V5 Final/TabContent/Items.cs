using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Items
        private void AddItem(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run insert_item({0}, {1}, {2}, {3}, 2, \"{4}\")",
                                SFM.GetSelection(dgvItems),
                                tbItemValue.Text,
                                tbItemEnchant.Text,
                                tbItemLevel.Text,
                                GetSelectedCharacter());
        }
        #endregion
    }
}
