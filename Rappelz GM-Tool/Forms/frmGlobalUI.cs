using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Linq;
using System.Diagnostics;

namespace GM_Tool_V5 {
    public partial class frmGlobalUI : Form {
        #region Form functions
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute( "user32.dll" )]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute( "user32.dll" )]
        public static extern bool ReleaseCapture();

        /*
        Constants in Windows API
        0x84 = WM_NCHITTEST - Mouse Capture Test
        0x1 = HTCLIENT - Application Client Area
        0x2 = HTCAPTION - Application Title Bar

        This function intercepts all the commands sent to the application. 
        It checks to see of the message is a mouse click in the application. 
        It passes the action to the base action by default. It reassigns 
        the action to the title bar if it occured in the client area
        to allow the drag and move behavior.
        */

        protected override void WndProc(ref Message m) {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if ( m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE ) {
                Size formSize = this.Size;
                Point screenPoint = new Point( m.LParam.ToInt32() );
                Point clientPoint = this.PointToClient( screenPoint );

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
            {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
            {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
            {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
            {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
            {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
            {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
        };

                foreach ( KeyValuePair<UInt32, Rectangle> hitBox in boxes ) {
                    if ( hitBox.Value.Contains( clientPoint ) ) {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if ( !handled )
                base.WndProc( ref m );
        }

        private void MouseMove_Window(object sender, MouseEventArgs e) {
            if ( e.Button == MouseButtons.Left ) {
                ReleaseCapture();
                SendMessage( Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0 );
            }
        }

        private void btn_Window_Close_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btn_Window_Minimize_Click(object sender, EventArgs e) {
            base.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Lists
        public List<SFM.ListInterface> pListItems, pListBuffs, pListPets, pListMonster, pListSkills;
        private BindingList<SFM.WarpInterface> pListWarps;
        private BindingList<string> pListCharacters;
        #endregion

        #region Initiations
        public frmGlobalUI() {
            InitializeComponent();
            tbSendNotice1.Text = Properties.Settings.Default.NoticeOne;
            tbSendNotice2.Text = Properties.Settings.Default.NoticeTwo;
            tbSendNotice3.Text = Properties.Settings.Default.NoticeThree;
            tbSendNotice4.Text = Properties.Settings.Default.NoticeFour;
            mainMenu.Renderer = new ToolStripColors();
            Benchmark( Initiation, 1 );
        }

        public void Initiation() {
            SFM.OnApplicationStartup();
            LoadLists();
        }

        private void Benchmark(Action act, int iterations) {
            GC.Collect();
            //act.Invoke(); // run once outside of loop to avoid initialization costs
            Stopwatch sw = Stopwatch.StartNew();
            for ( int i = 0; i < iterations; i++ ) {
                act.Invoke();
            }
            sw.Stop();
            lbBenchmark.Text += string.Format( "Loaded in {0}ms!", ( sw.ElapsedMilliseconds / iterations ).ToString() );
        }

        public void LoadLists() {
            pListItems = SFM.ReadFile( "items.txt", dgvItems );
            pListBuffs = SFM.ReadFile( "buffs.txt", dgvBuffs );
            pListPets = SFM.ReadFile( "pets.txt", dgvPets );
            pListSkills = SFM.ReadFile( "skills.txt", dgvSkills );
            pListMonster = SFM.ReadFile( "monster.txt", dgvMonster );
            pListWarps = SFM.ReadWarpFile( "warplist.txt", dgvWarps );
            pListCharacters = SFM.ReadCharacter( "characters.txt" );
            lbCharacter.DataSource = pListCharacters;
        }
        #endregion

        #region Search function
        private void SearchGridView(object sender, EventArgs e) {
            List<SFM.ListInterface> pList = null;
            DataGridView dgv = null;
            string search = "";
            if ( sender.Equals( btnSearchItems ) ) {
                pList = pListItems;
                dgv = dgvItems;
                search = tbItemsSearch.Text;
            }
            else if ( sender.Equals( btnBuffsSearch ) ) {
                pList = pListBuffs;
                dgv = dgvBuffs;
                search = tbBuffsSearch.Text;
            }
            else if ( sender.Equals( btnMonsterSearch ) ) {
                pList = pListMonster;
                dgv = dgvMonster;
                search = tbMonsterSearch.Text;
            }
            else if ( sender.Equals( btnPetsSearch ) ) {
                pList = pListPets;
                dgv = dgvPets;
                search = tbPetsSearch.Text;
            }
            else if ( sender.Equals( btnSkillsSearch ) ) {
                pList = pListSkills;
                dgv = dgvSkills;
                search = tbSkillsSearch.Text;
            }
            var pSearch = pList.FindAll( i => i.Name.ToLower().Contains( search.ToLower() ) );
            SFM.UpdateDataGridView( dgv, pSearch );
        }

        private void ResetGridView(object sender, EventArgs e) {
            if ( sender.Equals( btnItemsResetList ) )
                SFM.UpdateDataGridView( dgvItems, pListItems );
            else if ( sender.Equals( btnBuffsResetList ) )
                SFM.UpdateDataGridView( dgvBuffs, pListBuffs );
            else if ( sender.Equals( btnMonsterResetList ) )
                SFM.UpdateDataGridView( dgvMonster, pListMonster );
            else if ( sender.Equals( btnPetsResetList ) )
                SFM.UpdateDataGridView( dgvPets, pListPets );
            else if ( sender.Equals( btnSkillsResetList ) )
                SFM.UpdateDataGridView( dgvSkills, pListSkills );
                return;
        }

        #endregion

        #region Sidebar character
        private void AddCharacter(object sender, EventArgs e) {
            if ( tbCharacter.Text != string.Empty ) {
                pListCharacters.Add( tbCharacter.Text );
                SFM.UpdateCharacterList( pListCharacters.ToList<string>() );
                tbCharacter.Text = String.Empty;
            }
        }

        private void DeleteCharacter(object sender, EventArgs e) {
            try {
                pListCharacters.RemoveAt( lbCharacter.SelectedIndex );
                SFM.UpdateCharacterList( pListCharacters.ToList<string>() );
            }
            catch { }
        }
        #endregion

        #region GUI-Events
        private void tsmiDatabase_Click(object sender, EventArgs e) {
            frmDatabase dbForm = new frmDatabase( this );
            dbForm.ShowDialog();
        }

        private void tsmiImportListClicked(object sender, EventArgs e) {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text Files (.txt)|*.txt";
            openDialog.Multiselect = false;
            DialogResult diaResult = openDialog.ShowDialog();
            if ( diaResult != System.Windows.Forms.DialogResult.OK ) {
                return;
            }

            string szFilename = String.Empty;
            DataGridView dgv = null;

            if ( sender.Equals( tsmiListItem ) ) {
                szFilename = "items.txt";
                dgv = dgvItems;
            }
            else if ( sender.Equals( tsmiListBuffs ) ) {
                szFilename = "buffs.txt";
                dgv = dgvBuffs;
            }
            else if ( sender.Equals( tsmiListMonster ) ) {
                szFilename = "monster.txt";
                dgv = dgvMonster;
            }
            else if ( sender.Equals( tsmiListPets ) ) {
                szFilename = "pets.txt";
                dgv = dgvPets;
            }
            else if ( sender.Equals( tsmiListWarps ) ) {
                szFilename = "warplist.txt";
                dgv = dgvWarps;
            }
            else if ( sender.Equals( tsmiListSkills ) ) {
                szFilename = "skills.txt";
                dgv = dgvSkills;
            }
            else {
                return;
            }

            if ( szFilename == string.Empty ) {
                return;
            }

            SFM.ImportList( openDialog.FileName, szFilename, dgv );
        }

        private void tsmiExportListClicked(object sender, EventArgs e) {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text Files (.txt)|*.txt";
            DialogResult diaResult = saveDialog.ShowDialog();
            if ( diaResult != System.Windows.Forms.DialogResult.OK ) {
                return;
            }

            string szFilename = string.Empty;

            if ( sender.Equals( tsmiExportItem ) ) {
                szFilename = "items.txt";
            }
            else if ( sender.Equals( tsmiExportBuff ) ) {
                szFilename = "buffs.txt";
            }
            else if ( sender.Equals( tsmiExportMonster ) ) {
                szFilename = "monster.txt";
            }
            else if ( sender.Equals( tsmiExportPets ) ) {
                szFilename = "pets.txt";
            }
            else if ( sender.Equals( tsmiExportWarp ) ) {
                szFilename = "warplist.txt";
            }
            else if ( sender.Equals( tsmiExportSkill ) ) {
                szFilename = "skills.txt";
            }
            else {
                return;
            }

            SFM.ExportList( saveDialog.FileName, szFilename );
        }

        private void frmGlobalGUI_Closed(object sender, FormClosedEventArgs e) {
            Properties.Settings.Default.NoticeOne = tbSendNotice1.Text;
            Properties.Settings.Default.NoticeTwo = tbSendNotice2.Text;
            Properties.Settings.Default.NoticeThree = tbSendNotice3.Text;
            Properties.Settings.Default.NoticeFour = tbSendNotice4.Text;
            Properties.Settings.Default.Save();
        }

        private void CopyrightClicked(object sender, EventArgs e) {
            Process.Start( "http://xijezu.com/" );
        }

        private void useOldPetListToolStripMenuItem_CheckStateChanged(object sender, EventArgs e) {
            MessageBox.Show( "You might have to load a new list into the tool when it's using the wrong one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
            if ( useOldPetListToolStripMenuItem.Checked ) {
                cbPetsTamed.Show();
                tbPetsSearch.Hide();
                btnPetsResetList.Hide();
                btnPetsSearch.Hide();
            }
            else {
                cbPetsTamed.Hide();
                tbPetsSearch.Show();
                btnPetsResetList.Show();
                btnPetsSearch.Show();
            }
        }
        #endregion
    }
}