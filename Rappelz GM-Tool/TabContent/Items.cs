using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Items
        private void AddItem(object sender, EventArgs e) {
            if ( SFM.IsInt( tbItemEnchant.Text ) && SFM.IsInt( tbItemEnchant.Text )
                && !SFM.IsNullOrEmpty( tbItemEnchant.Text ) && !SFM.IsNullOrEmpty( tbItemLevel.Text ) ) {
                SFM.CopyToClipboard( "/run insert_item({0}, {1}, {2}, {3}, 2)",
                                    SFM.GetSelection( dgvItems ),
                                    ( SFM.IsInt( tbItemValue.Text ) ? tbItemValue.Text : "1" ),
                                    tbItemEnchant.Text,
                                    tbItemLevel.Text );
            }
            else {
                SFM.CopyToClipboard( "/run insert_item({0}, {1})",
                                 SFM.GetSelection( dgvItems ),
                                 ( SFM.IsInt( tbItemValue.Text ) ? tbItemValue.Text : "1" ) );
            }
        }
        #endregion
    }
}