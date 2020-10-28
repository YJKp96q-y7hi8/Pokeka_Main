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
            EventSet();
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
                return;
            }

            Nud_ValueChanged(cardInfo, ucCard);
            cardNum = num;
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
            Nud_ValueChanged(cardInfo, ucCard);
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

            //int allNum = 0;
            //for (int i = 0; i < _cardInfo.Length; i++)
            //{
            //    if (_cardInfo[i] != null)
            //    {
            //        allNum += _cardInfo[i].Num;
            //    }
            //}
            //tbx_Info_Num.Text = allNum.ToString();
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
                for (int i = 1; i < _cardInfo.Length; i++)
                {
                    if (_cardInfo[i] != null)
                    {
                        sw.WriteLine("{0},{1},{2},{3}", _cardInfo[i].Name, _cardInfo[i].Category, _cardInfo[i].PictPass, _cardInfo[i].Num);

                    }
                }
            }
        }

        private void btn_Info_Show_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < _cardInfo.Length; i++)
            {
                if (_cardInfo[i] == null)
                {
                    return;
                    //Btn_Delete_Click(_cardInfo[i], _ucCard[i]);
                }
                Btn_Delete_Click(_cardInfo[i], _ucCard[i]);
            }
            tbx_Info_DeckName.Text = "";
            tbx_Info_Num.Text = "";
        }

        public List<string> searchCardList = new List<string>();
        private void btn_Search_Click(object sender, EventArgs e)
        {
            searchCardList.Clear();
            string[] filesFullPath = Directory.GetFiles(@"Card List", "*.jpg", SearchOption.AllDirectories);

            foreach (string pathes in filesFullPath)
            {
                if (cbx_SearchCatego2.Text != "すべて" && cbx_SearchCatego2.Text != "")
                {
                    if (pathes.Contains(tbx_Search.Text))
                    {
                        if ((pathes.Contains(cbx_SearchCatego.Text)))
                        {
                            if ((pathes.Contains(cbx_SearchCatego2.Text)))
                            {
                                searchCardList.Add(pathes);
                            }
                        }
                    }
                }
                else if (cbx_SearchCatego.Text != "すべて")
                {
                    if (pathes.Contains(tbx_Search.Text))
                    {
                        if ((pathes.Contains(cbx_SearchCatego.Text)))
                        {
                            searchCardList.Add(pathes);
                        }
                    }
                }
                else if (pathes.Contains(tbx_Search.Text))
                {
                    searchCardList.Add(pathes);
                }

            }

            SearchForm sf = new SearchForm();
            sf.Show();
        }

        private void cbx_SearchCatego_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbx_SearchCatego.SelectedIndex == 0)
            //{
            //    cbx_SearchCatego2.SelectedIndex = 0;
            //    return;
            //}
            cbx_SearchCatego2.Text = "";
            cbx_SearchCatego2.Items.Clear();

            if (cbx_SearchCatego.Text == "ポケモン")
            {
                cbx_SearchCatego2.Text = "すべて";
                cbx_SearchCatego2.Items.AddRange(new object[]
                {"すべて", "無", "草", "炎", "水", "雷", "超", "闘", "鋼", "悪", "龍", "妖"});
            }
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

        private void EventSet()
        {
            uc_Card1.btn_Select.Click += new System.EventHandler(Uc_Card1_btn_SelectClick);
            uc_Card1.btn_Delete.Click += new System.EventHandler(Uc_Card1_btn_DeleteClick);
            uc_Card1.pbx_Pict.Click += new System.EventHandler(Uc_Card1_pbx_PictClick);
            uc_Card1.nud_Num.ValueChanged += new System.EventHandler(Uc_Card1_nud_ValueChanged);
            uc_Card2.btn_Select.Click += new System.EventHandler(Uc_Card2_btn_SelectClick);
            uc_Card2.btn_Delete.Click += new System.EventHandler(Uc_Card2_btn_DeleteClick);
            uc_Card2.pbx_Pict.Click += new System.EventHandler(Uc_Card2_pbx_PictClick);
            uc_Card2.nud_Num.ValueChanged += new System.EventHandler(Uc_Card2_nud_ValueChanged);
            uc_Card3.btn_Select.Click += new System.EventHandler(Uc_Card3_btn_SelectClick);
            uc_Card3.btn_Delete.Click += new System.EventHandler(Uc_Card3_btn_DeleteClick);
            uc_Card3.pbx_Pict.Click += new System.EventHandler(Uc_Card3_pbx_PictClick);
            uc_Card3.nud_Num.ValueChanged += new System.EventHandler(Uc_Card3_nud_ValueChanged);
            uc_Card4.btn_Select.Click += new System.EventHandler(Uc_Card4_btn_SelectClick);
            uc_Card4.btn_Delete.Click += new System.EventHandler(Uc_Card4_btn_DeleteClick);
            uc_Card4.pbx_Pict.Click += new System.EventHandler(Uc_Card4_pbx_PictClick);
            uc_Card4.nud_Num.ValueChanged += new System.EventHandler(Uc_Card4_nud_ValueChanged);
            uc_Card5.btn_Select.Click += new System.EventHandler(Uc_Card5_btn_SelectClick);
            uc_Card5.btn_Delete.Click += new System.EventHandler(Uc_Card5_btn_DeleteClick);
            uc_Card5.pbx_Pict.Click += new System.EventHandler(Uc_Card5_pbx_PictClick);
            uc_Card5.nud_Num.ValueChanged += new System.EventHandler(Uc_Card5_nud_ValueChanged);
            uc_Card6.btn_Select.Click += new System.EventHandler(Uc_Card6_btn_SelectClick);
            uc_Card6.btn_Delete.Click += new System.EventHandler(Uc_Card6_btn_DeleteClick);
            uc_Card6.pbx_Pict.Click += new System.EventHandler(Uc_Card6_pbx_PictClick);
            uc_Card6.nud_Num.ValueChanged += new System.EventHandler(Uc_Card6_nud_ValueChanged);
            uc_Card7.btn_Select.Click += new System.EventHandler(Uc_Card7_btn_SelectClick);
            uc_Card7.btn_Delete.Click += new System.EventHandler(Uc_Card7_btn_DeleteClick);
            uc_Card7.nud_Num.ValueChanged += new System.EventHandler(Uc_Card7_nud_ValueChanged);
            uc_Card7.pbx_Pict.Click += new System.EventHandler(Uc_Card7_pbx_PictClick);
            uc_Card8.btn_Select.Click += new System.EventHandler(Uc_Card8_btn_SelectClick);
            uc_Card8.btn_Delete.Click += new System.EventHandler(Uc_Card8_btn_DeleteClick);
            uc_Card8.pbx_Pict.Click += new System.EventHandler(Uc_Card8_pbx_PictClick);
            uc_Card8.nud_Num.ValueChanged += new System.EventHandler(Uc_Card8_nud_ValueChanged);
            uc_Card9.btn_Select.Click += new System.EventHandler(Uc_Card9_btn_SelectClick);
            uc_Card9.btn_Delete.Click += new System.EventHandler(Uc_Card9_btn_DeleteClick);
            uc_Card9.pbx_Pict.Click += new System.EventHandler(Uc_Card9_pbx_PictClick);
            uc_Card9.nud_Num.ValueChanged += new System.EventHandler(Uc_Card9_nud_ValueChanged);
            uc_Card10.btn_Select.Click += new System.EventHandler(Uc_Card10_btn_SelectClick);
            uc_Card10.btn_Delete.Click += new System.EventHandler(Uc_Card10_btn_DeleteClick);
            uc_Card10.pbx_Pict.Click += new System.EventHandler(Uc_Card10_pbx_PictClick);
            uc_Card10.nud_Num.ValueChanged += new System.EventHandler(Uc_Card10_nud_ValueChanged);
            uc_Card11.btn_Select.Click += new System.EventHandler(Uc_Card11_btn_SelectClick);
            uc_Card11.btn_Delete.Click += new System.EventHandler(Uc_Card11_btn_DeleteClick);
            uc_Card11.pbx_Pict.Click += new System.EventHandler(Uc_Card11_pbx_PictClick);
            uc_Card11.nud_Num.ValueChanged += new System.EventHandler(Uc_Card11_nud_ValueChanged);
            uc_Card12.btn_Select.Click += new System.EventHandler(Uc_Card12_btn_SelectClick);
            uc_Card12.btn_Delete.Click += new System.EventHandler(Uc_Card12_btn_DeleteClick);
            uc_Card12.pbx_Pict.Click += new System.EventHandler(Uc_Card12_pbx_PictClick);
            uc_Card12.nud_Num.ValueChanged += new System.EventHandler(Uc_Card12_nud_ValueChanged);
            uc_Card13.btn_Select.Click += new System.EventHandler(Uc_Card13_btn_SelectClick);
            uc_Card13.btn_Delete.Click += new System.EventHandler(Uc_Card13_btn_DeleteClick);
            uc_Card13.pbx_Pict.Click += new System.EventHandler(Uc_Card13_pbx_PictClick);
            uc_Card13.nud_Num.ValueChanged += new System.EventHandler(Uc_Card13_nud_ValueChanged);
            uc_Card14.btn_Select.Click += new System.EventHandler(Uc_Card14_btn_SelectClick);
            uc_Card14.btn_Delete.Click += new System.EventHandler(Uc_Card14_btn_DeleteClick);
            uc_Card14.pbx_Pict.Click += new System.EventHandler(Uc_Card14_pbx_PictClick);
            uc_Card14.nud_Num.ValueChanged += new System.EventHandler(Uc_Card14_nud_ValueChanged);
            uc_Card15.btn_Select.Click += new System.EventHandler(Uc_Card15_btn_SelectClick);
            uc_Card15.btn_Delete.Click += new System.EventHandler(Uc_Card15_btn_DeleteClick);
            uc_Card15.pbx_Pict.Click += new System.EventHandler(Uc_Card15_pbx_PictClick);
            uc_Card15.nud_Num.ValueChanged += new System.EventHandler(Uc_Card15_nud_ValueChanged);
            uc_Card16.btn_Select.Click += new System.EventHandler(Uc_Card16_btn_SelectClick);
            uc_Card16.btn_Delete.Click += new System.EventHandler(Uc_Card16_btn_DeleteClick);
            uc_Card16.pbx_Pict.Click += new System.EventHandler(Uc_Card16_pbx_PictClick);
            uc_Card16.nud_Num.ValueChanged += new System.EventHandler(Uc_Card16_nud_ValueChanged);
            uc_Card17.btn_Select.Click += new System.EventHandler(Uc_Card17_btn_SelectClick);
            uc_Card17.btn_Delete.Click += new System.EventHandler(Uc_Card17_btn_DeleteClick);
            uc_Card17.pbx_Pict.Click += new System.EventHandler(Uc_Card17_pbx_PictClick);
            uc_Card17.nud_Num.ValueChanged += new System.EventHandler(Uc_Card17_nud_ValueChanged);
            uc_Card18.btn_Select.Click += new System.EventHandler(Uc_Card18_btn_SelectClick);
            uc_Card18.btn_Delete.Click += new System.EventHandler(Uc_Card18_btn_DeleteClick);
            uc_Card18.pbx_Pict.Click += new System.EventHandler(Uc_Card18_pbx_PictClick);
            uc_Card18.nud_Num.ValueChanged += new System.EventHandler(Uc_Card18_nud_ValueChanged);
            uc_Card19.btn_Select.Click += new System.EventHandler(Uc_Card19_btn_SelectClick);
            uc_Card19.btn_Delete.Click += new System.EventHandler(Uc_Card19_btn_DeleteClick);
            uc_Card19.pbx_Pict.Click += new System.EventHandler(Uc_Card19_pbx_PictClick);
            uc_Card19.nud_Num.ValueChanged += new System.EventHandler(Uc_Card19_nud_ValueChanged);
            uc_Card20.btn_Select.Click += new System.EventHandler(Uc_Card20_btn_SelectClick);
            uc_Card20.btn_Delete.Click += new System.EventHandler(Uc_Card20_btn_DeleteClick);
            uc_Card20.pbx_Pict.Click += new System.EventHandler(Uc_Card20_pbx_PictClick);
            uc_Card20.nud_Num.ValueChanged += new System.EventHandler(Uc_Card20_nud_ValueChanged);
            uc_Card21.btn_Select.Click += new System.EventHandler(Uc_Card21_btn_SelectClick);
            uc_Card21.btn_Delete.Click += new System.EventHandler(Uc_Card21_btn_DeleteClick);
            uc_Card21.pbx_Pict.Click += new System.EventHandler(Uc_Card21_pbx_PictClick);
            uc_Card21.nud_Num.ValueChanged += new System.EventHandler(Uc_Card21_nud_ValueChanged);
            uc_Card22.btn_Select.Click += new System.EventHandler(Uc_Card22_btn_SelectClick);
            uc_Card22.btn_Delete.Click += new System.EventHandler(Uc_Card22_btn_DeleteClick);
            uc_Card22.pbx_Pict.Click += new System.EventHandler(Uc_Card22_pbx_PictClick);
            uc_Card22.nud_Num.ValueChanged += new System.EventHandler(Uc_Card22_nud_ValueChanged);
            uc_Card23.btn_Select.Click += new System.EventHandler(Uc_Card23_btn_SelectClick);
            uc_Card23.btn_Delete.Click += new System.EventHandler(Uc_Card23_btn_DeleteClick);
            uc_Card23.pbx_Pict.Click += new System.EventHandler(Uc_Card23_pbx_PictClick);
            uc_Card23.nud_Num.ValueChanged += new System.EventHandler(Uc_Card23_nud_ValueChanged);
            uc_Card24.btn_Select.Click += new System.EventHandler(Uc_Card24_btn_SelectClick);
            uc_Card24.btn_Delete.Click += new System.EventHandler(Uc_Card24_btn_DeleteClick);
            uc_Card24.pbx_Pict.Click += new System.EventHandler(Uc_Card24_pbx_PictClick);
            uc_Card24.nud_Num.ValueChanged += new System.EventHandler(Uc_Card24_nud_ValueChanged);
            uc_Card25.btn_Select.Click += new System.EventHandler(Uc_Card25_btn_SelectClick);
            uc_Card25.btn_Delete.Click += new System.EventHandler(Uc_Card25_btn_DeleteClick);
            uc_Card25.pbx_Pict.Click += new System.EventHandler(Uc_Card25_pbx_PictClick);
            uc_Card25.nud_Num.ValueChanged += new System.EventHandler(Uc_Card25_nud_ValueChanged);
            uc_Card26.btn_Select.Click += new System.EventHandler(Uc_Card26_btn_SelectClick);
            uc_Card26.btn_Delete.Click += new System.EventHandler(Uc_Card26_btn_DeleteClick);
            uc_Card26.pbx_Pict.Click += new System.EventHandler(Uc_Card26_pbx_PictClick);
            uc_Card26.nud_Num.ValueChanged += new System.EventHandler(Uc_Card26_nud_ValueChanged);
            uc_Card27.btn_Select.Click += new System.EventHandler(Uc_Card27_btn_SelectClick);
            uc_Card27.btn_Delete.Click += new System.EventHandler(Uc_Card27_btn_DeleteClick);
            uc_Card27.pbx_Pict.Click += new System.EventHandler(Uc_Card27_pbx_PictClick);
            uc_Card27.nud_Num.ValueChanged += new System.EventHandler(Uc_Card27_nud_ValueChanged);
            uc_Card28.btn_Select.Click += new System.EventHandler(Uc_Card28_btn_SelectClick);
            uc_Card28.btn_Delete.Click += new System.EventHandler(Uc_Card28_btn_DeleteClick);
            uc_Card28.pbx_Pict.Click += new System.EventHandler(Uc_Card28_pbx_PictClick);
            uc_Card28.nud_Num.ValueChanged += new System.EventHandler(Uc_Card28_nud_ValueChanged);
            uc_Card29.btn_Select.Click += new System.EventHandler(Uc_Card29_btn_SelectClick);
            uc_Card29.btn_Delete.Click += new System.EventHandler(Uc_Card29_btn_DeleteClick);
            uc_Card29.pbx_Pict.Click += new System.EventHandler(Uc_Card29_pbx_PictClick);
            uc_Card29.nud_Num.ValueChanged += new System.EventHandler(Uc_Card29_nud_ValueChanged);
            uc_Card30.btn_Select.Click += new System.EventHandler(Uc_Card30_btn_SelectClick);
            uc_Card30.btn_Delete.Click += new System.EventHandler(Uc_Card30_btn_DeleteClick);
            uc_Card30.pbx_Pict.Click += new System.EventHandler(Uc_Card30_pbx_PictClick);
            uc_Card30.nud_Num.ValueChanged += new System.EventHandler(Uc_Card30_nud_ValueChanged);
        }

        private void Uc_Card1_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[1] = new CardInfo();
            Btn_Select_Click(_cardInfo[1], uc_Card1, 1);
        }

        private void Uc_Card1_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[1], uc_Card1);
        }

        private void Uc_Card1_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(1);
        }

        private void Uc_Card1_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[1], uc_Card1);
        }

        private void Uc_Card2_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[2] = new CardInfo();
            Btn_Select_Click(_cardInfo[2], uc_Card2, 2);
        }

        private void Uc_Card2_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[2], uc_Card2);
        }
        private void Uc_Card2_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(2);
        }
        private void Uc_Card2_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[2], uc_Card2);
        }

        private void Uc_Card3_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[3] = new CardInfo();
            Btn_Select_Click(_cardInfo[3], uc_Card3,3);
        }

        private void Uc_Card3_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[3], uc_Card3);
        }

        private void Uc_Card3_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(3);
        }
        private void Uc_Card3_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[3], uc_Card3);
        }

        private void Uc_Card4_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[4] = new CardInfo();
            Btn_Select_Click(_cardInfo[4], uc_Card4, 4);
        }

        private void Uc_Card4_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[4], uc_Card4);
        }
        private void Uc_Card4_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(4);
        }

        private void Uc_Card4_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[4], uc_Card4);
        }
        private void Uc_Card5_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[5] = new CardInfo();
            Btn_Select_Click(_cardInfo[5], uc_Card5, 5);
        }

        private void Uc_Card5_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[5], uc_Card5);
        }

        private void Uc_Card5_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(5);
        }
        private void Uc_Card5_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[5], uc_Card5);
        }
        private void Uc_Card6_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[6] = new CardInfo();
            Btn_Select_Click(_cardInfo[6], uc_Card6, 6);
        }

        private void Uc_Card6_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[6], uc_Card6);
        }
        private void Uc_Card6_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(6);
        }
        private void Uc_Card6_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[6], uc_Card6);
        }
        private void Uc_Card7_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[7] = new CardInfo();
            Btn_Select_Click(_cardInfo[7], uc_Card7, 7);
        }

        private void Uc_Card7_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[7], uc_Card7);
        }

        private void Uc_Card7_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(7);
        }
        private void Uc_Card7_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[7], uc_Card7);
        }
        private void Uc_Card8_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[8] = new CardInfo();
            Btn_Select_Click(_cardInfo[8], uc_Card8, 8);
        }

        private void Uc_Card8_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[8], uc_Card8);
        }
        private void Uc_Card8_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(8);
        }
        private void Uc_Card8_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[8], uc_Card8);
        }
        private void Uc_Card9_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[9] = new CardInfo();
            Btn_Select_Click(_cardInfo[9], uc_Card9, 9);
        }

        private void Uc_Card9_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[9], uc_Card9);
        }

        private void Uc_Card9_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(9);
        }
        private void Uc_Card9_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[9], uc_Card9);
        }

        private void Uc_Card10_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[10] = new CardInfo();
            Btn_Select_Click(_cardInfo[10], uc_Card10, 10);
        }

        private void Uc_Card10_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[10], uc_Card10);
        }
        private void Uc_Card10_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(10);
        }
        private void Uc_Card10_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[10], uc_Card10);
        }
        private void Uc_Card11_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[11] = new CardInfo();
            Btn_Select_Click(_cardInfo[11], uc_Card11, 11);
        }

        private void Uc_Card11_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[11], uc_Card11);
        }

        private void Uc_Card11_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(11);
        }
        private void Uc_Card11_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[11], uc_Card11);
        }
        private void Uc_Card12_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[12] = new CardInfo();
            Btn_Select_Click(_cardInfo[12], uc_Card12, 12);
        }

        private void Uc_Card12_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[12], uc_Card12);
        }
        private void Uc_Card12_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(12);
        }
        private void Uc_Card12_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[12], uc_Card12);
        }
        private void Uc_Card13_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[13] = new CardInfo();
            Btn_Select_Click(_cardInfo[13], uc_Card13, 13);
        }

        private void Uc_Card13_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[13], uc_Card13);
        }

        private void Uc_Card13_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(13);
        }
        private void Uc_Card13_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[13], uc_Card13);
        }
        private void Uc_Card14_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[14] = new CardInfo();
            Btn_Select_Click(_cardInfo[14], uc_Card14, 14);
        }

        private void Uc_Card14_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[14], uc_Card14);
        }
        private void Uc_Card14_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(14);
        }
        private void Uc_Card14_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[14], uc_Card14);
        }
        private void Uc_Card15_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[15] = new CardInfo();
            Btn_Select_Click(_cardInfo[15], uc_Card15, 15);
        }

        private void Uc_Card15_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[15], uc_Card15);
        }

        private void Uc_Card15_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(15);
        }
        private void Uc_Card15_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[15], uc_Card15);
        }
        private void Uc_Card16_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[16] = new CardInfo();
            Btn_Select_Click(_cardInfo[16], uc_Card16, 16);
        }

        private void Uc_Card16_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[16], uc_Card16);
        }
        private void Uc_Card16_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(16);
        }
        private void Uc_Card16_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[16], uc_Card16);
        }
        private void Uc_Card17_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[17] = new CardInfo();
            Btn_Select_Click(_cardInfo[17], uc_Card17, 17);
        }

        private void Uc_Card17_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[17], uc_Card17);
        }
        private void Uc_Card17_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(17);
        }
        private void Uc_Card17_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[17], uc_Card17);
        }
        private void Uc_Card18_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[18] = new CardInfo();
            Btn_Select_Click(_cardInfo[18], uc_Card18, 18);
        }

        private void Uc_Card18_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[18], uc_Card18);
        }
        private void Uc_Card18_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(18);
        }
        private void Uc_Card18_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[18], uc_Card18);
        }
        private void Uc_Card19_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[19] = new CardInfo();
            Btn_Select_Click(_cardInfo[19], uc_Card19, 19);
        }

        private void Uc_Card19_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[19], uc_Card19);
        }
        private void Uc_Card19_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(19);
        }
        private void Uc_Card19_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[19], uc_Card19);
        }
        private void Uc_Card20_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[20] = new CardInfo();
            Btn_Select_Click(_cardInfo[20], uc_Card20, 20);
        }

        private void Uc_Card20_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[20], uc_Card20);
        }
        private void Uc_Card20_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(20);
        }
        private void Uc_Card20_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[20], uc_Card20);
        }
        private void Uc_Card21_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[21] = new CardInfo();
            Btn_Select_Click(_cardInfo[21], uc_Card21, 21);
        }

        private void Uc_Card21_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[21], uc_Card21);
        }
        private void Uc_Card21_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(21);
        }
        private void Uc_Card21_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[21], uc_Card21);
        }
        private void Uc_Card22_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[22] = new CardInfo();
            Btn_Select_Click(_cardInfo[22], uc_Card22, 22);
        }

        private void Uc_Card22_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[22], uc_Card22);
        }
        private void Uc_Card22_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(22);
        }
        private void Uc_Card22_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[22], uc_Card22);
        }
        private void Uc_Card23_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[23] = new CardInfo();
            Btn_Select_Click(_cardInfo[23], uc_Card23, 23);
        }

        private void Uc_Card23_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[23], uc_Card23);
        }
        private void Uc_Card23_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(23);
        }
        private void Uc_Card23_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[23], uc_Card23);
        }
        private void Uc_Card24_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[24] = new CardInfo();
            Btn_Select_Click(_cardInfo[24], uc_Card24, 24);
        }

        private void Uc_Card24_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[24], uc_Card24);
        }
        private void Uc_Card24_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(24);
        }
        private void Uc_Card24_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[24], uc_Card24);
        }

        private void Uc_Card25_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[25] = new CardInfo();
            Btn_Select_Click(_cardInfo[25], uc_Card25, 25);
        }

        private void Uc_Card25_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[25], uc_Card25);
        }
        private void Uc_Card25_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(25);
        }
        private void Uc_Card25_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[25], uc_Card25);
        }
        private void Uc_Card26_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[26] = new CardInfo();
            Btn_Select_Click(_cardInfo[26], uc_Card26, 26);
        }

        private void Uc_Card26_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[26], uc_Card26);
        }
        private void Uc_Card26_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(26);
        }
        private void Uc_Card26_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[26], uc_Card26);
        }
        private void Uc_Card27_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[27] = new CardInfo();
            Btn_Select_Click(_cardInfo[27], uc_Card27, 27);
        }

        private void Uc_Card27_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[27], uc_Card27);
        }
        private void Uc_Card27_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(27);
        }
        private void Uc_Card27_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[27], uc_Card27);
        }
        private void Uc_Card28_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[28] = new CardInfo();
            Btn_Select_Click(_cardInfo[28], uc_Card28, 28);
        }

        private void Uc_Card28_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[28], uc_Card28);
        }
        private void Uc_Card28_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(28);
        }
        private void Uc_Card28_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[28], uc_Card28);
        }
        private void Uc_Card29_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[29] = new CardInfo();
            Btn_Select_Click(_cardInfo[29], uc_Card29, 29);
        }

        private void Uc_Card29_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[29], uc_Card29);
        }
        private void Uc_Card29_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(29);
        }
        private void Uc_Card29_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[29], uc_Card29);
        }
        private void Uc_Card30_btn_SelectClick(object sender, EventArgs e)
        {
            _cardInfo[30] = new CardInfo();
            Btn_Select_Click(_cardInfo[30], uc_Card30, 30);
        }

        private void Uc_Card30_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(_cardInfo[30], uc_Card30);
        }
        private void Uc_Card30_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(30);
        }
        private void Uc_Card30_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(_cardInfo[30], uc_Card30);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
