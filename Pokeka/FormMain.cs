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
        OpenFileDialog ofd = new OpenFileDialog();
        OpenFileDialog ofdDeck = new OpenFileDialog();
        internal CardInfo[] _cardInfo = new CardInfo[31];    //CardInfoのインスタンス
        internal uc_Card[] _ucCard = new uc_Card[31];    //ユーザーコントロールのインスタンス
        internal int cardNum = 0;

        public FormMain()
        {
            InitializeComponent();
            FormMain.Form1Instance = this;
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Card List");
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

        private void Btn_Select_Click(CardInfo cardInfo, uc_Card ucCard, int num)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                cardInfo.SetCardInfo(ofd.SafeFileName, ofd.FileName);
                SetCardInfo(ucCard, cardInfo, cardInfo.Num);
            }
            else
            {
                btn_Search.Focus();
                return;
            }

            Nud_ValueChanged(cardInfo, ucCard);
            cardNum = num;
            btn_Search.Focus();
        }

        private void Btn_Delete_Click(CardInfo cardInfo, uc_Card ucCard)
        {
            ucCard.pbx_Pict.ImageLocation = "";
            ucCard.gbx_Card.Text = "";
            if (cardInfo != null)
            {
                cardInfo.DeleteCardInfo();
            }
            ucCard.nud_Num.Value = 1;
            ucCard.nud_Num.Enabled = false;
            ucCard.BackColor = System.Drawing.SystemColors.Control;
            int arrayNum = Array.IndexOf(_cardInfo, cardInfo);
            _cardInfo[arrayNum] = null;
            if (cardInfo != null)
            {
                Nud_ValueChanged(cardInfo, ucCard);
            }
            btn_Search.Focus();
        }

        private void Pbx_Pict_Click(int num)
        {
            if(_cardInfo[num] == null)
            {
                return;
            }
            cardNum = num;
            ShowPict showPict = new ShowPict();
            showPict.ShowDialog();
        }

        internal void Nud_ValueChanged(CardInfo cardInfo, uc_Card ucCard)
        {
            cardInfo.Num = (int)ucCard.nud_Num.Value;
            int allNum = 0;
            for(int i=0; i< _cardInfo.Length; i++)
            {
                if(_cardInfo[i] != null)
                {
                    allNum += _cardInfo[i].Num;
                }
            }
            tbx_Info_Num.Text = allNum.ToString();
        }

        internal void SetCardInfo(uc_Card ucCard, CardInfo cardInfo, int nums)
        {
            ucCard.pbx_Pict.ImageLocation = cardInfo.PictPass;
            ucCard.gbx_Card.Text = cardInfo.Category;
            if(ucCard.gbx_Card.Text == "ポケモン")
            { ucCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))); }
            if (ucCard.gbx_Card.Text == "グッズ")
            { ucCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))); }
            if (ucCard.gbx_Card.Text == "サポート")
            { ucCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))); }
            if (ucCard.gbx_Card.Text == "スタジアム")
            { ucCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))); }
            if (ucCard.gbx_Card.Text == "エネルギー")
            { ucCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255))))); }

            ucCard.nud_Num.Enabled = true;
            ucCard.nud_Num.Value = nums;
        }

        private void btn_Rec_Set_Click(object sender, EventArgs e)
        {
            if (ofdDeck.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new System.IO.StreamReader(@ofdDeck.FileName, Encoding.UTF8))
                {
                    int srNum = 1;
                    while (sr.EndOfStream == false)
                    {
                        string[] read = sr.ReadLine().Split(',');
                        _cardInfo[srNum] = new CardInfo();
                        _cardInfo[srNum].SetCardInfo(read[0] + ".jpg", read[2]);
                        _cardInfo[srNum].Num = int.Parse(read[3]);

                        if (_cardInfo[srNum] != null)
                        {
                            SetCardInfo(_ucCard[srNum], _cardInfo[srNum], _cardInfo[srNum].Num);
                        }
                        srNum++;
                    }
                    for(int i=srNum; i< _cardInfo.Length; i++)
                    {
                        if (_cardInfo[i] != null)
                        {
                            Btn_Delete_Click(_cardInfo[i], _ucCard[i]);
                        }
                    }
                    tbx_Info_DeckName.Text = ofdDeck.SafeFileName.Replace(".csv", "");
                }
                //num = 1;
            }

            btn_Search.Focus();
        }

        private void btn_Rec_Save_Click(object sender, EventArgs e)
        {
            if (tbx_Info_DeckName.Text == "")
            {
                MessageBox.Show("デッキ名を入力してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Search.Focus();
                return;
            }

            var result = MessageBox.Show("「" + tbx_Info_DeckName.Text + "」を保存しますか？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.No)
            {
                btn_Search.Focus();
                return;
            }
            
            string pass = @"Deck List\\" + tbx_Info_DeckName.Text + ".csv";
            if (File.Exists(pass))
            {
                MessageBox.Show("「" + tbx_Info_DeckName.Text + "」は既に存在します。\r\n上書きしてもよろしいですか？", 
                    "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    btn_Search.Focus();
                    return;
                }
            }

            using (var sw = new System.IO.StreamWriter(pass, false, Encoding.UTF8))
            {
                for (int i = 1; i < _cardInfo.Length; i++)
                {
                    if (_cardInfo[i] != null)
                    {
                        sw.WriteLine("{0},{1},{2},{3}", _cardInfo[i].Name, _cardInfo[i].Category, _cardInfo[i].PictPass, _cardInfo[i].Num);

                    }
                }
            }
            btn_Search.Focus();
        }

        private void btn_Info_Show_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < _cardInfo.Length; i++)
            {
                if (_cardInfo[i] == null)
                {
                    //btn_Search.Focus();
                    //return;
                }
                Btn_Delete_Click(_cardInfo[i], _ucCard[i]);
            }
            tbx_Info_DeckName.Text = "";
            tbx_Info_Num.Text = "";

            btn_Search.Focus();
        }

        public List<string> searchCardList = new List<string>();
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchCard();
        }

        private void SearchCard()
        {
            searchCardList.Clear();
            string directoryPath = @"Card List";

            if (cbx_SearchCatego1.Text != "カテゴリ(すべて)")
            {
                if (cbx_SearchCatego3.Text != "パック(すべて)")
                {
                    if (cbx_SearchCatego2.Text != "すべて" && cbx_SearchCatego2.Text != "")
                    {
                        directoryPath += @"\" + cbx_SearchCatego1.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego1.Text;
                        directoryPath += "\\" + cbx_SearchCatego3.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego3.Text;
                        string directory2Path = cbx_SearchCatego2.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego2.Text;

                        string[] filesFullPath = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.AllDirectories);
                        foreach (string pathes in filesFullPath)
                        {
                            if (pathes.Contains(directory2Path))
                                searchCardList.Add(pathes);
                        }
                    }
                    else
                    {
                        directoryPath += @"\" + cbx_SearchCatego1.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego1.Text;
                        directoryPath += "\\" + cbx_SearchCatego3.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego3.Text;
                        string[] filesFullPath = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.AllDirectories);
                        foreach (string pathes in filesFullPath)
                        {
                            searchCardList.Add(pathes);
                        }
                    }
                }
                else if (cbx_SearchCatego2.Text != "すべて" && cbx_SearchCatego2.Text != "")
                {
                    directoryPath += @"\\" + cbx_SearchCatego1.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego1.Text;
                    string directory2Path = cbx_SearchCatego2.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego2.Text;

                    string[] filesFullPath = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.AllDirectories);
                    foreach (string pathes in filesFullPath)
                    {
                        if(pathes.Contains(directory2Path))
                            searchCardList.Add(pathes);
                    }
                }
                else
                {
                    directoryPath += @"\\" + cbx_SearchCatego1.SelectedIndex.ToString("X2") + "_" + cbx_SearchCatego1.Text;
                    string[] filesFullPath = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.AllDirectories);
                    foreach (string pathes in filesFullPath)
                    {
                        searchCardList.Add(pathes);
                    }
                }
            }
            else if (cbx_SearchCatego3.Text != "パック(すべて)")
            {

            }
            else
            {
                string[] filesFullPath = Directory.GetFiles(@"Card List", "*.jpg", SearchOption.AllDirectories);
                foreach (string pathes in filesFullPath)
                {
                    searchCardList.Add(pathes);
                }
            }
            //string[] filesFullPath = Directory.GetFiles(@"Card List", "*.jpg", SearchOption.AllDirectories);

            //foreach (string pathes in filesFullPath)
            //{
            //    if (cbx_SearchCatego2.Text != "すべて" && cbx_SearchCatego2.Text != "")
            //    {
            //        if (pathes.Contains(tbx_Search.Text))
            //        {
            //            if ((pathes.Contains(cbx_SearchCatego1.Text)))
            //            {
            //                if ((pathes.Contains(cbx_SearchCatego2.Text)))
            //                {
            //                    searchCardList.Add(pathes);
            //                }
            //            }
            //        }
            //    }
            //    else if (cbx_SearchCatego1.Text != "カテゴリ(すべて)")
            //    {
            //        if (pathes.Contains(tbx_Search.Text))
            //        {
            //            if ((pathes.Contains(cbx_SearchCatego1.Text)))
            //            {
            //                searchCardList.Add(pathes);
            //            }
            //        }
            //    }
            //    else if (pathes.Contains(tbx_Search.Text))
            //    {
            //        searchCardList.Add(pathes);
            //    }

            //}

            SearchForm sf = new SearchForm();
            sf.ShowDialog();
        }

        private void cbx_SearchCatego_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_SearchCatego2.Text = "";
            cbx_SearchCatego3.Text = "パック(すべて)";
            cbx_SearchCatego2.Items.Clear();

            if (cbx_SearchCatego1.Text == "ポケモン")
            {
                cbx_SearchCatego2.Text = "すべて";
                cbx_SearchCatego2.Items.AddRange(new object[]
                {"すべて", "無", "草", "炎", "水", "雷", "超", "闘", "鋼", "悪", "龍", "妖"});
            }
            if (cbx_SearchCatego1.Text == "エネルギー")
            {
                cbx_SearchCatego3.Enabled = false;
                cbx_SearchCatego2.Text = "すべて";
                cbx_SearchCatego2.Items.AddRange(new object[]
                {"すべて", "基本エネルギー", "特殊エネルギー"});
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchCard();
            }
        }

        private void ClickBtnSelect(string sender)
        {
            UInt16 ctrNum = ushort.Parse(sender.Replace("uc_Card", ""));

            _cardInfo[ctrNum] = new CardInfo();
            Btn_Select_Click(_cardInfo[ctrNum], _ucCard[ctrNum], ctrNum);
        }

        private void ClickBtnDelete(string sender)
        {
            UInt16 ctrNum = ushort.Parse(sender.Replace("uc_Card", ""));

            Btn_Delete_Click(_cardInfo[ctrNum], _ucCard[ctrNum]);
        }

        private void ClickPbxPict(string sender)
        {
            UInt16 ctrNum = ushort.Parse(sender.Replace("uc_Card", ""));

            Pbx_Pict_Click(ctrNum);
        }

        private void ValueChangedNudNum(string sender)
        {
            UInt16 ctrNum = ushort.Parse(sender.Replace("uc_Card", ""));

            Nud_ValueChanged(_cardInfo[ctrNum], _ucCard[ctrNum]);
        }

        // ========== イベント関連 ==========
        private void UcCardSet()
        {
            _ucCard[1] = uc_Card1;
            _ucCard[2] = uc_Card2;
            _ucCard[3] = uc_Card3;
            _ucCard[4] = uc_Card4;
            _ucCard[5] = uc_Card5;
            _ucCard[6] = uc_Card6;
            _ucCard[7] = uc_Card7;
            _ucCard[8] = uc_Card8;
            _ucCard[9] = uc_Card9;
            _ucCard[10] = uc_Card10;
            _ucCard[11] = uc_Card11;
            _ucCard[12] = uc_Card12;
            _ucCard[13] = uc_Card13;
            _ucCard[14] = uc_Card14;
            _ucCard[15] = uc_Card15;
            _ucCard[16] = uc_Card16;
            _ucCard[17] = uc_Card17;
            _ucCard[18] = uc_Card18;
            _ucCard[19] = uc_Card19;
            _ucCard[20] = uc_Card20;
            _ucCard[21] = uc_Card21;
            _ucCard[22] = uc_Card22;
            _ucCard[23] = uc_Card23;
            _ucCard[24] = uc_Card24;
            _ucCard[25] = uc_Card25;
            _ucCard[26] = uc_Card26;
            _ucCard[27] = uc_Card27;
            _ucCard[28] = uc_Card28;
            _ucCard[29] = uc_Card29;
            _ucCard[30] = uc_Card30;
        }

        private void Click_Btn_Select(object sender, EventArgs e)
        {
            ClickBtnSelect((sender as uc_Card).Name);
        }

        private void Click_Btn_Delete(object sender, EventArgs e)
        {
            ClickBtnDelete((sender as uc_Card).Name);
        }

        private void Click_Pbx_Pict(object sender, EventArgs e)
        {
            ClickPbxPict((sender as uc_Card).Name);
        }

        private void Click_Nud_Num(object sender, EventArgs e)
        {
            ValueChangedNudNum((sender as uc_Card).Name);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbx_Search_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
            }
        }

        private void cbx_SearchCatego3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
