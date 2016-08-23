using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

// Static Function Manager class

namespace GM_Tool_V5
{
    static public class SFM
    {
        #region Global variables
        static public string APP_FOLDER = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Xijezu/GM-Tool/");
        #endregion

        #region OnApplicationStartup
        static public void OnApplicationStartup()
        {
            if (!Directory.Exists(APP_FOLDER))
                Directory.CreateDirectory(APP_FOLDER);

            string[] pszFiles = { "buffs.txt", "items.txt", "characters.txt", "monster.txt", "pets.txt", "warplist.txt", "skills.txt" };
            foreach (string szFile in pszFiles)
            {
                if (!File.Exists(APP_FOLDER + szFile))
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    var resourceName = "GM_Tool_V5.Resources." + szFile;
                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        File.WriteAllText(APP_FOLDER + szFile, reader.ReadToEnd());
                    }
                }
            }
        }
        #endregion

        #region Read functions
        static public List<ListInterface> ReadFile(string file, DataGridView pDgv)
        {
            List<ListInterface> pList = new List<ListInterface>();
            using (StreamReader sr = new StreamReader(APP_FOLDER + file, Encoding.Default, true))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    ListInterface l = new ListInterface(s.Split('\t'));
                    pList.Add(l);
                }
            }
            UpdateDataGridView(pDgv, pList);
            return pList;
        }


        static public BindingList<WarpInterface> ReadWarpFile(string file, DataGridView dgv)
        {
            BindingList<WarpInterface> pList = new BindingList<WarpInterface>(); ;
            using (StreamReader sr = new StreamReader(APP_FOLDER + file, Encoding.Default, true))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    WarpInterface l = new WarpInterface(s.Split('\t'));
                    pList.Add(l);
                }
            }
            UpdateDataGridView(dgv, pList);
            return pList;
        }

        static public BindingList<string> ReadCharacter(string file)
        {
            BindingList<string> pList = new BindingList<string>();
            using (StreamReader sr = new StreamReader(APP_FOLDER + file, Encoding.Default, true))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    pList.Add(s);
                }
            }
            return pList;
        }
        #endregion

        #region Save functions
        static public void SafeFile(List<ListInterface> pList, string szFile)
        {
            using (TextWriter tr = new StreamWriter(APP_FOLDER + szFile, false))
            {
                foreach (ListInterface lInterface in pList)
                    tr.WriteLine(string.Format("{0}\t{1}", lInterface.ID, lInterface.Name));
            }
        }

        static public void UpdateCharacterList(List<string> lCharacter)
        {
            using (TextWriter tr = new StreamWriter(APP_FOLDER + "characters.txt", false))
            {
                foreach (string s in lCharacter)
                    tr.WriteLine(s);
            }
        }

        static public void UpdateWarpList(List<WarpInterface> lWarps)
        {
            using (TextWriter tr = new StreamWriter(APP_FOLDER + "warplist.txt", false))
            {
                foreach (WarpInterface s in lWarps)
                    tr.WriteLine(string.Format("{0}\t{1}\t{2}", s.X, s.Y, s.Name));
            }
        }
        #endregion

        #region Import and Export
        static public void ImportList(string szFilename, string szType, DataGridView dgv)
        {
            try
            {
                if (File.Exists(APP_FOLDER + szType))
                {
                    File.Delete(APP_FOLDER + szType);
                }
                File.Copy(szFilename, APP_FOLDER + szType);
                if (szType.Equals("warplist.txt"))
                {
                    ReadWarpFile(szType, dgv);
                }
                else
                {
                    ReadFile(szType, dgv);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        static public void ExportList(string szLocation, string szType)
        {
            try
            {
                if (File.Exists(szLocation))
                {
                    File.Delete(szLocation);
                }
                File.Copy(APP_FOLDER + szType, szLocation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Clipboard functions

        static public void CopyToClipboardWC(string szName, string form, params object[] val)
        {
            if (szName.Contains("<"))
            {
                CopyToClipboard(form, val);
                return;
            }

            form = form.Remove(form.Length - 1);
            form += form.Contains("learn_all_skill") ? "\"" + szName + "\")" : ", \"" + szName + "\")";

            CopyToClipboard(form, val);
        }

        static public void CopyToClipboard(string form, params object[] val)
        {
            Clipboard.SetText(string.Format(form, val), TextDataFormat.UnicodeText);
        }

        static public void CopyToClipboard(string szValue)
        {
            Clipboard.SetText(szValue, TextDataFormat.Text);
        }
        #endregion

        #region GUI Enhancements
        public static int GetJobID(string szJob)
        {
            switch (szJob)
            {
                case "Rogue":
                    return 100;
                case "Fighter":
                    return 101;
                case "Kahuna":
                    return 102;
                case "Spell Singer":
                    return 103;
                case "Champion":
                    return 110;
                case "Archer":
                    return 111;
                case "Druid":
                    return 112;
                case "Battle Kahuna":
                    return 113;
                case "Evoker":
                    return 114;
                case "Berserker":
                    return 120;
                case "Marksman":
                    return 121;
                case "Magus":
                    return 122;
                case "War Kahuna":
                    return 123;
                case "Beast Master":
                    return 124;
                case "Guide":
                    return 200;
                case "Holy Warrior":
                    return 201;
                case "Cleric":
                    return 202;
                case "Breeder":
                    return 203;
                case "Knight":
                    return 210;
                case "Soldier":
                    return 211;
                case "Bishop":
                    return 212;
                case "Priest":
                    return 213;
                case "Soul Breeder":
                    return 214;
                case "Templar":
                    return 220;
                case "Mercenary":
                    return 221;
                case "Cardinal":
                    return 222;
                case "Oracle":
                    return 223;
                case "Master Breeder":
                    return 224;
                case "Stepper":
                    return 300;
                case "Strider":
                    return 301;
                case "Dark Magician":
                    return 302;
                case "Sorcerer":
                    return 303;
                case "Assassin":
                    return 310;
                case "Shadow Hunter":
                    return 311;
                case "Chaos Magician":
                    return 312;
                case "Warlock":
                    return 313;
                case "Battle Summoner":
                    return 314;
                case "Slayer":
                    return 320;
                case "Deadeye":
                    return 321;
                case "Void Mage":
                    return 322;
                case "Corruptor":
                    return 323;
                case "Overlord":
                    return 324;
                default:
                    return 0;
            }
        }

        static public long GetTimeValue(ListBox lb, TextBox tb)
        {
            try
            {
                long num2 = 0, num3 = 0;
                long.TryParse(tb.Text, out num2);

                switch (lb.SelectedItem.ToString())
                {
                    case "Seconds":
                        num3 = (long)(num2 * 100);
                        break;
                    case "Minutes":
                        num3 = (long)(num2 * 6000);
                        break;
                    case "Hours":
                        num3 = (long)(num2 * 360000);
                        break;
                    case "Days":
                        num3 = (long)(num2 * 8640000);
                        break;
                    case "Weeks":
                        num3 = (long)(num2 * 60480000);
                        break;
                    case "Months":
                        num3 = (long)(num2 * 259200000);
                        break;
                    default:
                        num3 = (long)(num2 * 100);
                        break;
                }
                return num3;
            }
            catch
            {
                return 0;
            }
        }

        static public bool IsInt(object val) {
            int i = 0;
            return int.TryParse( val.ToString(), out i );
        }
        
        static public bool IsNullOrEmpty(string val) {

            if ( string.IsNullOrEmpty( val ) ) {
                return true;
            }

            if(val == "0") {
                return true;
            }

            return false;
        }

        static public int GetSelection(DataGridView pView)
        {
            try
            {
                string szVal = pView.Rows[pView.Rows.GetFirstRow(DataGridViewElementStates.Selected)].Cells[0].Value.ToString();
                int i = 0;
                if (int.TryParse(szVal, out i))
                {
                    return i;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        static public void UpdateDataGridView(DataGridView dgv, List<ListInterface> pList)
        {
            dgv.ColumnHeadersVisible = false;
            dgv.DataSource = pList;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.ColumnHeadersVisible = true;
        }

        static public void UpdateDataGridView(DataGridView dgv, BindingList<WarpInterface> pList)
        {
            dgv.ColumnHeadersVisible = false;
            dgv.DataSource = pList;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.ColumnHeadersVisible = true;
        }
        #endregion

        #region Structs
        public class ListInterface
        {
            public string ID { get; set; }
            public string Name { get; set; }

            public ListInterface(string key, string value)
            {
                ID = key;
                Name = value;
            }

            public ListInterface(string[] value)
            {
                ID = value[0];
                Name = value[1];
            }
        }

        public class WarpInterface
        {
            public string X { get; set; }
            public string Y { get; set; }
            public string Name { get; set; }

            public WarpInterface(string[] value)
            {
                X = value[0];
                Y = value[1];
                Name = value[2];
            }
        }
        #endregion
    }
}