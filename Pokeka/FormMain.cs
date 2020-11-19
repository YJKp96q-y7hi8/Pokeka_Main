using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokeka
{
    public partial class FormMain : Form
    {
        OpenFileDialog ofdCard = new OpenFileDialog();
        OpenFileDialog ofdDeck = new OpenFileDialog();
        internal string selectCardPath;

        internal List<uc_Card> uc_DeckCard = new List<uc_Card>();
        int LIST_MAX = 40;
        int deckNum = 0;

        private bool chekedFlag = false;
        private uc_Card checkedUC = null;

        public FormMain()
        {
            InitializeComponent();
            FormMain.Form1Instance = this;
            ofdCard.InitialDirectory = Path.Combine(Application.StartupPath, @"Card List");
            ofdDeck.InitialDirectory = Path.Combine(Application.StartupPath, @"Deck List");
            UcCardSet();
        }

        //FormMainオブジェクトを保持ずるためのフィールド
        private static FormMain _form1Instance;
        //FormMainオブジェクトを取得・設定するためのプロパティ
        public static FormMain Form1Instance
        {
            get { return _form1Instance; }
            set { _form1Instance = value; }
        }

        private void Btn_Delete_Click(int num)
        {
            uc_DeckCard[num].Pict.ImageLocation = null;
            uc_DeckCard[num].GbxText = "";
            uc_DeckCard[num].Nud.Value = 0;
            uc_DeckCard[num].Nud.Enabled = false;
            uc_DeckCard[num].BackColor = System.Drawing.SystemColors.Control;
        }

        private void Pbx_Pict_Click(int num)
        {
            if(uc_DeckCard[num].Pict.ImageLocation == null)
            {
                return;
            }
            selectCardPath = uc_DeckCard[num].Pict.ImageLocation;

            ShowPict showPict = new ShowPict();
            showPict.ShowDialog();
        }

        internal void SetColor(int num)
        {
            if(uc_DeckCard[num].GbxText == "ポケモン")
            { uc_DeckCard[num].BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))); }
            if (uc_DeckCard[num].GbxText == "グッズ")
            { uc_DeckCard[num].BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))); }
            if (uc_DeckCard[num].GbxText == "サポート")
            { uc_DeckCard[num].BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); }
            if (uc_DeckCard[num].GbxText == "スタジアム")
            { uc_DeckCard[num].BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))); }
            if (uc_DeckCard[num].GbxText == "エネルギー")
            { uc_DeckCard[num].BackColor = Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))); }
        }

        private void btn_Rec_Set_Click(object sender, EventArgs e)
        {
            if (ofdDeck.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new System.IO.StreamReader(@ofdDeck.FileName, Encoding.UTF8))
                {
                    int srNum = 0;
                    while (sr.EndOfStream == false)
                    {
                        string[] read = sr.ReadLine().Split(',');
                        uc_DeckCard[srNum].SetCardInfo(Path.GetFileName(read[1]), read[1]);
                        uc_DeckCard[srNum].Nud.Value = int.Parse(read[2]);
                        uc_DeckCard[srNum].Nud.Enabled = true;

                        SetColor(srNum);
                        srNum++;
                    }
                    for(int i=srNum; i< uc_DeckCard.Count; i++)
                    {
                        if (uc_DeckCard[i].Pict.ImageLocation != null)
                        {
                            Btn_Delete_Click(i);
                        }
                    }
                    tbx_Info_DeckName.Text = ofdDeck.SafeFileName.Replace(".csv", "");
                }
            }
        }

        private void AllNumChange()
        {
            int allNum = 0;
            for (int i = 0; i < uc_DeckCard.Count; i++)
            {
                allNum += (int)uc_DeckCard[i].Nud.Value;
            }
            tbx_Info_Num.Text = allNum.ToString();
        }

        private void DeckNumChange(int num)
        {
            deckNum -= (uc_DeckCard[num].Num - (int)uc_DeckCard[num].Nud.Value);
            tbx_Info_Num.Text = deckNum.ToString();
            uc_DeckCard[num].Num = (int)uc_DeckCard[num].Nud.Value;
        }

        private void btn_Rec_Save_Click(object sender, EventArgs e)
        {
            if (tbx_Info_DeckName.Text == "")
            {
                MessageBox.Show("デッキ名を入力してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("「" + tbx_Info_DeckName.Text + "」を保存しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                return;
            }
            
            string pass = @"Deck List\\" + tbx_Info_DeckName.Text + ".csv";
            if (File.Exists(pass))
            {
                MessageBox.Show("「" + tbx_Info_DeckName.Text + "」は既に存在します。\r\n上書きしてもよろしいですか？", 
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            using (var sw = new System.IO.StreamWriter(pass, false, Encoding.UTF8))
            {
                for (int i = 0; i < uc_DeckCard.Count; i++)
                {
                    if (uc_DeckCard[i].Pict.ImageLocation != null)
                    {
                        sw.WriteLine("{0},{1},{2}", uc_DeckCard[i].GbxText, uc_DeckCard[i].Pict.ImageLocation, uc_DeckCard[i].Nud.Value);
                    }
                }
            }
        }

        private void btn_Info_Reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < uc_DeckCard.Count; i++)
            {
                if (uc_DeckCard[i].Pict.ImageLocation == null)
                {
                    //return;
                }
                Btn_Delete_Click(i);
            }
            tbx_Info_DeckName.Text = "";
            tbx_Info_Num.Text = "0";
        }

        private SearchForm staySF = null;
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchForm sf = new SearchForm();
            sf.Show();
        }

        private void UcCardSet()
        {
            for(int i = 0; i < LIST_MAX; i++)
            {
                uc_Card newCard = new uc_Card();
                uc_DeckCard.Add(newCard);

                int numX = i % 10;
                int numY = i / 10 + 1;

                tableLayoutPanel3.Controls.Add(uc_DeckCard[i], numX, numY);

                uc_DeckCard[i].Dock = DockStyle.Fill;
                uc_DeckCard[i].Name = "uc_DeckCard" + i;

                uc_DeckCard[i].Click_Btn_Delete += new EventHandler(Click_Btn_Delete);
                uc_DeckCard[i].Click_Pbx_Pict += new EventHandler(Click_Pbx_Pict);
                uc_DeckCard[i].ValueChanged_Nud_Num += new EventHandler(ValueChanged_Nud_Num);
                uc_DeckCard[i].CheckedChanged_Chbx_Check += new EventHandler(CheckedChanged_Chbx_Check);
            }
        }

        // ========== イベント関連 ==========
        private void Click_Btn_Delete(object sender, EventArgs e)
        {
            string ctrlName = (sender as uc_Card).Name;
            int ctrlNum = int.Parse(ctrlName.Replace("uc_DeckCard", ""));
            Btn_Delete_Click(ctrlNum);

            for (int i = ctrlNum; i < uc_DeckCard.Count; i++)
            {
                if(i == LIST_MAX - 1)
                {
                    uc_DeckCard[i].Pict.ImageLocation = null;
                    uc_DeckCard[i].GbxText = "";
                    uc_DeckCard[i].BackColor = System.Drawing.SystemColors.Control;
                    break;
                }

                if (uc_DeckCard[i + 1].Pict.ImageLocation != null)
                {
                    uc_DeckCard[i].Pict.ImageLocation = uc_DeckCard[i + 1].Pict.ImageLocation;
                    uc_DeckCard[i].GbxText = uc_DeckCard[i + 1].GbxText;
                    uc_DeckCard[i].Nud.Value = uc_DeckCard[i + 1].Nud.Value;
                    uc_DeckCard[i].Num = uc_DeckCard[i + 1].Num;
                    uc_DeckCard[i].BackColor = uc_DeckCard[i + 1].BackColor;
                }
                else
                {
                    uc_DeckCard[i].Pict.ImageLocation = null;
                    uc_DeckCard[i].GbxText = "";
                    uc_DeckCard[i].BackColor = System.Drawing.SystemColors.Control;
                    break;
                }
            }
        }

        private void Click_Pbx_Pict(object sender, EventArgs e)
        {
            string ctrlName = (sender as uc_Card).Name;
            int ctrlNum = int.Parse(ctrlName.Replace("uc_DeckCard", ""));
            Pbx_Pict_Click(ctrlNum);
        }

        private void ValueChanged_Nud_Num(object sender, EventArgs e)
        {
            string ctrlName = (sender as uc_Card).Name;
            int ctrlNum = int.Parse(ctrlName.Replace("uc_DeckCard", ""));
            DeckNumChange(ctrlNum);
        }

        private void CheckedChanged_Chbx_Check(object sender, EventArgs e)
        {
            string ctrlName = (sender as uc_Card).Name;
            int ctrlNum = int.Parse(ctrlName.Replace("uc_DeckCard", ""));

            if(uc_DeckCard[ctrlNum].ChbxChecked)
            {
                if(!chekedFlag)
                {
                    uc_DeckCard[ctrlNum].Pict.BorderStyle = BorderStyle.Fixed3D;
                    chekedFlag = true;
                    checkedUC = uc_DeckCard[ctrlNum];
                }
                else
                {
                    //パラメータを入れ替える
                    string ucPict = uc_DeckCard[ctrlNum].Pict.ImageLocation;
                    string ucCatego = uc_DeckCard[ctrlNum].GbxText;
                    decimal ucNum = uc_DeckCard[ctrlNum].Nud.Value;
                    Color ucColor = uc_DeckCard[ctrlNum].BackColor;
                    uc_DeckCard[ctrlNum].Pict.ImageLocation = checkedUC.Pict.ImageLocation;
                    uc_DeckCard[ctrlNum].GbxText = checkedUC.GbxText;
                    uc_DeckCard[ctrlNum].Nud.Value = checkedUC.Nud.Value;
                    uc_DeckCard[ctrlNum].Num = (int)checkedUC.Nud.Value;
                    uc_DeckCard[ctrlNum].BackColor = checkedUC.BackColor;
                    checkedUC.Pict.ImageLocation = ucPict;
                    checkedUC.GbxText = ucCatego;
                    checkedUC.Nud.Value = ucNum;
                    checkedUC.Num = (int)ucNum;
                    checkedUC.BackColor = ucColor;

                    //グラフィックを元の状態に戻す
                    CheckedClear(checkedUC, uc_DeckCard[ctrlNum]);
                    checkedUC.Pict.BorderStyle = BorderStyle.None;
                    chekedFlag = false;
                    checkedUC = null;
                }
            }
            else
            {
                uc_DeckCard[ctrlNum].Pict.BorderStyle = BorderStyle.None;
                chekedFlag = false;
                checkedUC = null;
            }
        }

        private void CheckedClear(uc_Card uc1, uc_Card uc2)
        {
            uc1.CheckedChanged_Chbx_Check -= new EventHandler(CheckedChanged_Chbx_Check);
            uc2.CheckedChanged_Chbx_Check -= new EventHandler(CheckedChanged_Chbx_Check);
            uc1.ChbxChecked = false;
            uc2.ChbxChecked = false;
            uc1.CheckedChanged_Chbx_Check += new EventHandler(CheckedChanged_Chbx_Check);
            uc2.CheckedChanged_Chbx_Check += new EventHandler(CheckedChanged_Chbx_Check);
        }
    }
}
