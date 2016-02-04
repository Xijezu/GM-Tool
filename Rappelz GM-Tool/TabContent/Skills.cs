using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Buffs
        private void LearnSkill(object sender, EventArgs e) {
            SFM.CopyToClipboard( "/run learn_skill({0})", SFM.GetSelection( dgvSkills ) );
        }
        private void LearnCreatureSkill(object sender, EventArgs e) {
            SFM.CopyToClipboard( "/run  creature_learn_skill({0}, gcv(get_creature_handle(0), \"handle\"), \"{1}\")", SFM.GetSelection( dgvSkills ), GetSelectedCharacter() );
        }
        private void ResetSkill(object sender, EventArgs e) {
            SFM.CopyToClipboard( "/run reset_skill(0)" );
        }
        #endregion
    }
}