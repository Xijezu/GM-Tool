using System;
using System.Windows.Forms;

namespace GM_Tool_V5 {
    partial class frmGlobalUI : Form
    {
        private string GetSelectedCharacter() {
            try {
                return this.lbCharacter.SelectedItem.ToString();
            } catch {
                return "NULL";
            }
        }

        #region Character
        private void InsertGold(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run insert_gold({0}, \"{1}\")", tbCharacterGold.Text, GetSelectedCharacter());
        }

        private void SetValue(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run sv(\"{0}\", \"{1}\", \"{2}\")", cbSetValue.Text, tbSVValue.Text, GetSelectedCharacter());
        }

        private void SetCreatureValue(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run scv( get_creature_handle({0}), \"{1}\", \"{2}\", \"{3}\")", tbCreatureSlot.Text, cbSetCreatureValue.Text, tbSetCreatureValue.Text, GetSelectedCharacter());
        }

        private void ChangeJob(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run Run_JobChange_common(\"{0}\", {1})", cbChangeJob.Text, SFM.GetJobID(cbChangeJob.Text));
        }

        private void LearnAllSkill(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run learn_all_skill(\"{0}\")", GetSelectedCharacter());
        }

        private void LearnCreatureAllSkill(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run learn_creature_all_skill(\"XijezuIsGod\", \"{0}\")", GetSelectedCharacter());
        }

        private void SendNotice(object sender, EventArgs e) {
            string szNotice = "";
            if (sender.Equals(btnSendNotice1))
                szNotice = tbSendNotice1.Text;
            else if (sender.Equals(btnSendNotice2))
                szNotice = tbSendNotice2.Text;
            else if (sender.Equals(btnSendNotice3))
                szNotice = tbSendNotice3.Text;
            else if (sender.Equals(btnSendNotice4))
                szNotice = tbSendNotice4.Text;
            SFM.CopyToClipboard("/run notice(\"{0}\")", szNotice);
        }

        private void MutePlayer(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run block_chat(\"{0}\", {1})", tbMuteCharacter.Text, tbMuteTime.Text);
        }

        private void KickPlayer(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run kick(\"{0}\")", tbKickCharacter.Text);
        }

        private void KillTarget(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run kill_target()");
        }

        private void AddHuntaholicPoints(object sender, EventArgs e) {
            SFM.CopyToClipboard("/run set_huntaholic_point(gv(\"huntaholic_point\") + {0}, \"{1}\")", tbHuntaholicPoints.Text, GetSelectedCharacter());
        }
        #endregion
    }
}
