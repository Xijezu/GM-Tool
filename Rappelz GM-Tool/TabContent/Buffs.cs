using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Buffs
        private void AddBuff(object sender, EventArgs e) {
            // /run add_state(time, level, time, name)
            SFM.CopyToClipboard("/run add_state({0}, {1}, {2}, \"{3}\")", SFM.GetSelection(dgvBuffs), tbBuffsLevel.Text, SFM.GetTimeValue(lboxBuffTime, tbBuffsTime), GetSelectedCharacter());
        }

        private void AddCreatureBuff(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run add_cstate({0}, {1}, {2}, \"{3}\")", SFM.GetSelection(dgvBuffs), tbBuffsLevel.Text, SFM.GetTimeValue(lboxBuffTime, tbBuffsTime), GetSelectedCharacter());
        }

        private void AddEventBuff(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run add_event_state({0}, {1})", SFM.GetSelection(dgvBuffs), tbBuffsLevel.Text);
        }

        private void RemoveBuff(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run remove_state({0}, get_state_level({0}), \"{1}\")", SFM.GetSelection(dgvBuffs), GetSelectedCharacter());
        }

        private void RemoveEventBuff(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run remove_event_state({0})", SFM.GetSelection(dgvBuffs));
        }

        #endregion
    }
}
