using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace GM_Tool_V5 {
    public partial class frmDatabase : Form {
        private frmGlobalUI wndGlobalUI = null;
        public frmDatabase(frmGlobalUI wndGlobal) {
            InitializeComponent();
            tbDbAddress.Text = Properties.Settings.Default.dbAddress;
            tbDbDatabase.Text = Properties.Settings.Default.dbDatabase;
            tbDbUsername.Text = Properties.Settings.Default.dbUsername;
            tbDbPassword.Text = Properties.Settings.Default.dbPassword;
            wndGlobalUI = wndGlobal;
        }

        #region Form functions
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
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
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE) {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

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

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes) {
                    if (hitBox.Value.Contains(clientPoint)) {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }

        private void btn_Window_Close_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btn_Window_Minimize_Click(object sender, EventArgs e) {
            base.WindowState = FormWindowState.Minimized;
        }

        #endregion

        private SqlConnection GenerateSqlConnection() {
            SqlConnection sqlCon = new SqlConnection(string.Format("Server={0};Database={1};User Id={2};Password={3};",
                                                                    tbDbAddress.Text,
                                                                    tbDbDatabase.Text,
                                                                    tbDbUsername.Text,
                                                                    tbDbPassword.Text));
            return sqlCon;
        }

        private string GetSqlQuery(string value) {
            switch (value) {
                case "Itemlist":
                    return "SELECT i.id AS id, s.value AS value FROM ItemResource i LEFT JOIN StringResource s ON i.name_id = s.code;";
                case "Bufflist":
                    return "SELECT i.state_id AS id, s.value AS value FROM StateResource i LEFT JOIN StringResource s ON i.text_id = s.code;";
                case "Monsterlist":
                    return "SELECT i.id AS id, s.value AS value FROM MonsterResource i LEFT JOIN StringResource s ON i.name_id = s.code;";
                case "Petlist":
                    return "SELECT distinct i.id AS id, s.value AS value FROM ItemResource i LEFT JOIN StringResource s ON i.name_id = s.code LEFT JOIN SummonResource sr ON i.id = sr.card_id WHERE i.name_id = s.code and i.id = sr.card_id;";
                default:
                    return String.Empty;
            }
        }

        private void btnGenerateList_Click(object sender, EventArgs e) {
            if (cbSelectedList.Text == string.Empty)
                return;
            try {
                using (SqlConnection sqlCon = GenerateSqlConnection()) {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(GetSqlQuery(cbSelectedList.Text), sqlCon);
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SFM.ListInterface> pNewList = new List<SFM.ListInterface>();

                    while (dr.Read()) {
                        string[] val = { dr["id"].ToString(), dr["value"].ToString() };
                        SFM.ListInterface pInterface = new SFM.ListInterface(val);
                        pNewList.Add(pInterface);
                    }
                    sqlCon.Close();

                    switch (cbSelectedList.Text) {
                        case "Itemlist":
                            wndGlobalUI.pListItems = pNewList;
                            SFM.SafeFile(pNewList, "items.txt");
                            SFM.UpdateDataGridView(wndGlobalUI.dgvItems, pNewList);
                            break;
                        case "BuffList":
                            wndGlobalUI.pListBuffs = pNewList;
                            SFM.SafeFile(pNewList, "buffs.txt");
                            SFM.UpdateDataGridView(wndGlobalUI.dgvBuffs, pNewList);
                            break;
                        case "Monsterlist":
                            wndGlobalUI.pListMonster = pNewList;
                            SFM.SafeFile(pNewList, "monster.txt");
                            SFM.UpdateDataGridView(wndGlobalUI.dgvMonster, pNewList);
                            break;
                        case "Petlist":
                            wndGlobalUI.pListPets = pNewList;
                            SFM.SafeFile(pNewList, "pets.txt");
                            SFM.UpdateDataGridView(wndGlobalUI.dgvPets, pNewList);
                            break;
                        default:
                            break;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Properties.Settings.Default.dbAddress = tbDbAddress.Text;
            Properties.Settings.Default.dbDatabase = tbDbDatabase.Text;
            Properties.Settings.Default.dbUsername = tbDbUsername.Text;
            if (cbSavePassword.Checked) {
                Properties.Settings.Default.dbPassword = tbDbPassword.Text;
            }
            Properties.Settings.Default.Save();
            this.Close();
        }

    }
}
