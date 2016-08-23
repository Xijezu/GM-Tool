using System;

namespace GM_Tool_V5 {
    partial class frmGlobalUI {
        #region Buffs
        private void AddBuff(object sender, EventArgs e)
        {
            var time = SFM.GetTimeValue(lboxBuffTime, tbBuffsTime);
            SFM.CopyToClipboardWC(GetSelectedCharacter(), "/run add_state({0}, {1}, {2})",
                            SFM.GetSelection(dgvBuffs),
                            (SFM.IsInt(tbBuffsLevel.Text) ? tbBuffsLevel.Text : "1"),
                            (time > 0 ? time : 360000));
        }

        private void AddCreatureBuff(object sender, EventArgs e)
        {
            var time = SFM.GetTimeValue(lboxBuffTime, tbBuffsTime);
            SFM.CopyToClipboardWC(GetSelectedCharacter(), "/run add_cstate({0}, {1}, {2})",
                            SFM.GetSelection(dgvBuffs),
                            (SFM.IsInt(tbBuffsLevel.Text) ? tbBuffsLevel.Text : "1"),
                            (time > 0 ? time : 360000));
        }

        private void AddEventBuff(object sender, EventArgs e) {
            SFM.CopyToClipboard( "/run add_event_state({0}, {1})", SFM.GetSelection( dgvBuffs ), tbBuffsLevel.Text );
        }

        private void RemoveBuff(object sender, EventArgs e) {
                SFM.CopyToClipboardWC(GetSelectedCharacter(), "/run remove_state({0}, get_state_level({0}))", SFM.GetSelection(dgvBuffs));
        }

        private void RemoveEventBuff(object sender, EventArgs e) {
            SFM.CopyToClipboard( "/run remove_event_state({0})", SFM.GetSelection( dgvBuffs ) );
        }

        #endregion
    }
}