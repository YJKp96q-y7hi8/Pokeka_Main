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
        internal CardInfo[] card = new CardInfo[31];    //各CardInfoのインスタンス
        internal int cardNum = 0;

        public FormMain()
        {
            InitializeComponent();
            FormMain.Form1Instance = this;
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Card List");
            ofdDeck.InitialDirectory = Path.Combine(Application.StartupPath, @"Deck List");
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
                SetCardInfo(ucCard, cardInfo, cardInfo.num);
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
            int arrayNum = Array.IndexOf(card, cardInfo);
            card[arrayNum] = null;
        }

        private void Pbx_Pict_Click(int num)
        {
            if(card[num] == null)
            {
                return;
            }
            cardNum = num;
            ShowPict showPict = new ShowPict();
            showPict.ShowDialog();
        }

        private void Nud_ValueChanged(CardInfo cardInfo, uc_Card ucCard)
        {
            cardInfo.num = (int)ucCard.nud_Num.Value;
            int allNum = 0;
            for(int i=0; i<card.Length; i++)
            {
                if(card[i] != null)
                {
                    allNum += card[i].num;
                }
            }
            tbx_Info_Num.Text = allNum.ToString();
        }

        private void SetCardInfo(uc_Card ucCard, CardInfo cardInfo, int nums)
        {
            ucCard.pbx_Pict.ImageLocation = cardInfo.pictPass;
            ucCard.gbx_Card.Text = cardInfo.category;
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

        int num = 1;
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
                        card[num] = new CardInfo();
                        card[num].SetCardInfo(read[0] + ".jpg", read[2]);
                        card[num].num = int.Parse(read[3]);
                        switch (num)
                        {
                            case 1:
                                SetCardInfo(uc_Card1, card[num], card[num].num);
                                break;
                            case 2:
                                SetCardInfo(uc_Card2, card[num], card[num].num);
                                break;
                            case 3:
                                SetCardInfo(uc_Card3, card[num], card[num].num);
                                break;
                            case 4:
                                SetCardInfo(uc_Card4, card[num], card[num].num);
                                break;
                            case 5:
                                SetCardInfo(uc_Card5, card[num], card[num].num);
                                break;
                            case 6:
                                SetCardInfo(uc_Card6, card[num], card[num].num);
                                break;
                            case 7:
                                SetCardInfo(uc_Card7, card[num], card[num].num);
                                break;
                            case 8:
                                SetCardInfo(uc_Card8, card[num], card[num].num);
                                break;
                            case 9:
                                SetCardInfo(uc_Card9, card[num], card[num].num);
                                break;
                            case 10:
                                SetCardInfo(uc_Card10, card[num], card[num].num);
                                break;
                            case 11:
                                SetCardInfo(uc_Card11, card[num], card[num].num);
                                break;
                            case 12:
                                SetCardInfo(uc_Card12, card[num], card[num].num);
                                break;
                            case 13:
                                SetCardInfo(uc_Card13, card[num], card[num].num);
                                break;
                            case 14:
                                SetCardInfo(uc_Card14, card[num], card[num].num);
                                break;
                            case 15:
                                SetCardInfo(uc_Card15, card[num], card[num].num);
                                break;
                            case 16:
                                SetCardInfo(uc_Card16, card[num], card[num].num);
                                break;
                            case 17:
                                SetCardInfo(uc_Card17, card[num], card[num].num);
                                break;
                            case 18:
                                SetCardInfo(uc_Card18, card[num], card[num].num);
                                break;
                            case 19:
                                SetCardInfo(uc_Card19, card[num], card[num].num);
                                break;
                            case 20:
                                SetCardInfo(uc_Card20, card[num], card[num].num);
                                break;
                            case 21:
                                SetCardInfo(uc_Card21, card[num], card[num].num);
                                break;
                            case 22:
                                SetCardInfo(uc_Card22, card[num], card[num].num);
                                break;
                            case 23:
                                SetCardInfo(uc_Card23, card[num], card[num].num);
                                break;
                            case 24:
                                SetCardInfo(uc_Card24, card[num], card[num].num);
                                break;
                            case 25:
                                SetCardInfo(uc_Card25, card[num], card[num].num);
                                break;
                            case 26:
                                SetCardInfo(uc_Card26, card[num], card[num].num);
                                break;
                            case 27:
                                SetCardInfo(uc_Card27, card[num], card[num].num);
                                break;
                            case 28:
                                SetCardInfo(uc_Card28, card[num], card[num].num);
                                break;
                            case 29:
                                SetCardInfo(uc_Card29, card[num], card[num].num);
                                break;
                            case 30:
                                SetCardInfo(uc_Card30, card[num], card[num].num);
                                break;
                        }
                        num++;
                        srNum++;
                    }
                    for(int i=srNum; i<card.Length; i++)
                    {
                        if (card[i] != null)
                        {
                            switch (i)
                            {
                                case 1: Btn_Delete_Click(card[i], uc_Card1); break;
                                case 2: Btn_Delete_Click(card[i], uc_Card2); break;
                                case 3: Btn_Delete_Click(card[i], uc_Card3); break;
                                case 4: Btn_Delete_Click(card[i], uc_Card4); break;
                                case 5: Btn_Delete_Click(card[i], uc_Card5); break;
                                case 6: Btn_Delete_Click(card[i], uc_Card6); break;
                                case 7: Btn_Delete_Click(card[i], uc_Card7); break;
                                case 8: Btn_Delete_Click(card[i], uc_Card8); break;
                                case 9: Btn_Delete_Click(card[i], uc_Card9); break;
                                case 10: Btn_Delete_Click(card[i], uc_Card10); break;
                                case 11: Btn_Delete_Click(card[i], uc_Card11); break;
                                case 12: Btn_Delete_Click(card[i], uc_Card12); break;
                                case 13: Btn_Delete_Click(card[i], uc_Card13); break;
                                case 14: Btn_Delete_Click(card[i], uc_Card14); break;
                                case 15: Btn_Delete_Click(card[i], uc_Card15); break;
                                case 16: Btn_Delete_Click(card[i], uc_Card16); break;
                                case 17: Btn_Delete_Click(card[i], uc_Card17); break;
                                case 18: Btn_Delete_Click(card[i], uc_Card18); break;
                                case 19: Btn_Delete_Click(card[i], uc_Card19); break;
                                case 20: Btn_Delete_Click(card[i], uc_Card20); break;
                                case 21: Btn_Delete_Click(card[i], uc_Card21); break;
                                case 22: Btn_Delete_Click(card[i], uc_Card22); break;
                                case 23: Btn_Delete_Click(card[i], uc_Card23); break;
                                case 24: Btn_Delete_Click(card[i], uc_Card24); break;
                                case 25: Btn_Delete_Click(card[i], uc_Card25); break;
                                case 26: Btn_Delete_Click(card[i], uc_Card26); break;
                                case 27: Btn_Delete_Click(card[i], uc_Card27); break;
                                case 28: Btn_Delete_Click(card[i], uc_Card28); break;
                                case 29: Btn_Delete_Click(card[i], uc_Card29); break;
                                case 30: Btn_Delete_Click(card[i], uc_Card30); break;
                            }
                        }
                    }
                    tbx_Info_DeckName.Text = ofdDeck.SafeFileName.Replace(".csv", "");
                }
                num = 1;
            }

            int allNum = 0;
            for (int i = 0; i < card.Length; i++)
            {
                if (card[i] != null)
                {
                    allNum += card[i].num;
                }
            }
            tbx_Info_Num.Text = allNum.ToString();
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
                for (int i = 1; i < card.Length; i++)
                {
                    if (card[i] != null)
                    {
                        sw.WriteLine("{0}, {1}, {2}, {3}", card[i].name, card[i].category, card[i].pictPass, card[i].num);

                    }
                }
            }
        }

        private void btn_Info_Show_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < card.Length; i++)
            {
                if (card[i] != null)
                {
                    switch (i)
                    {
                        case 1: Btn_Delete_Click(card[i], uc_Card1); break;
                        case 2: Btn_Delete_Click(card[i], uc_Card2); break;
                        case 3: Btn_Delete_Click(card[i], uc_Card3); break;
                        case 4: Btn_Delete_Click(card[i], uc_Card4); break;
                        case 5: Btn_Delete_Click(card[i], uc_Card5); break;
                        case 6: Btn_Delete_Click(card[i], uc_Card6); break;
                        case 7: Btn_Delete_Click(card[i], uc_Card7); break;
                        case 8: Btn_Delete_Click(card[i], uc_Card8); break;
                        case 9: Btn_Delete_Click(card[i], uc_Card9); break;
                        case 10: Btn_Delete_Click(card[i], uc_Card10); break;
                        case 11: Btn_Delete_Click(card[i], uc_Card11); break;
                        case 12: Btn_Delete_Click(card[i], uc_Card12); break;
                        case 13: Btn_Delete_Click(card[i], uc_Card13); break;
                        case 14: Btn_Delete_Click(card[i], uc_Card14); break;
                        case 15: Btn_Delete_Click(card[i], uc_Card15); break;
                        case 16: Btn_Delete_Click(card[i], uc_Card16); break;
                        case 17: Btn_Delete_Click(card[i], uc_Card17); break;
                        case 18: Btn_Delete_Click(card[i], uc_Card18); break;
                        case 19: Btn_Delete_Click(card[i], uc_Card19); break;
                        case 20: Btn_Delete_Click(card[i], uc_Card20); break;
                        case 21: Btn_Delete_Click(card[i], uc_Card21); break;
                        case 22: Btn_Delete_Click(card[i], uc_Card22); break;
                        case 23: Btn_Delete_Click(card[i], uc_Card23); break;
                        case 24: Btn_Delete_Click(card[i], uc_Card24); break;
                        case 25: Btn_Delete_Click(card[i], uc_Card25); break;
                        case 26: Btn_Delete_Click(card[i], uc_Card26); break;
                        case 27: Btn_Delete_Click(card[i], uc_Card27); break;
                        case 28: Btn_Delete_Click(card[i], uc_Card28); break;
                        case 29: Btn_Delete_Click(card[i], uc_Card29); break;
                        case 30: Btn_Delete_Click(card[i], uc_Card30); break;
                    }
                }
            }
            tbx_Info_DeckName.Text = "";
            tbx_Info_Num.Text = "";
        }

        // ========== イベント関連 ==========
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
            card[1] = new CardInfo();
            Btn_Select_Click(card[1], uc_Card1, 1);
        }

        private void Uc_Card1_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[1], uc_Card1);
        }

        private void Uc_Card1_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(1);
        }

        private void Uc_Card1_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[1], uc_Card1);
        }

        private void Uc_Card2_btn_SelectClick(object sender, EventArgs e)
        {
            card[2] = new CardInfo();
            Btn_Select_Click(card[2], uc_Card2, 2);
        }

        private void Uc_Card2_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[2], uc_Card2);
        }
        private void Uc_Card2_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(2);
        }
        private void Uc_Card2_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[2], uc_Card2);
        }

        private void Uc_Card3_btn_SelectClick(object sender, EventArgs e)
        {
            card[3] = new CardInfo();
            Btn_Select_Click(card[3], uc_Card3,3);
        }

        private void Uc_Card3_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[3], uc_Card3);
        }

        private void Uc_Card3_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(3);
        }
        private void Uc_Card3_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[3], uc_Card3);
        }

        private void Uc_Card4_btn_SelectClick(object sender, EventArgs e)
        {
            card[4] = new CardInfo();
            Btn_Select_Click(card[4], uc_Card4, 4);
        }

        private void Uc_Card4_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[4], uc_Card4);
        }
        private void Uc_Card4_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(4);
        }

        private void Uc_Card4_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[4], uc_Card4);
        }
        private void Uc_Card5_btn_SelectClick(object sender, EventArgs e)
        {
            card[5] = new CardInfo();
            Btn_Select_Click(card[5], uc_Card5, 5);
        }

        private void Uc_Card5_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[5], uc_Card5);
        }

        private void Uc_Card5_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(5);
        }
        private void Uc_Card5_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[5], uc_Card5);
        }
        private void Uc_Card6_btn_SelectClick(object sender, EventArgs e)
        {
            card[6] = new CardInfo();
            Btn_Select_Click(card[6], uc_Card6, 6);
        }

        private void Uc_Card6_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[6], uc_Card6);
        }
        private void Uc_Card6_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(6);
        }
        private void Uc_Card6_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[6], uc_Card6);
        }
        private void Uc_Card7_btn_SelectClick(object sender, EventArgs e)
        {
            card[7] = new CardInfo();
            Btn_Select_Click(card[7], uc_Card7, 7);
        }

        private void Uc_Card7_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[7], uc_Card7);
        }

        private void Uc_Card7_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(7);
        }
        private void Uc_Card7_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[7], uc_Card7);
        }
        private void Uc_Card8_btn_SelectClick(object sender, EventArgs e)
        {
            card[8] = new CardInfo();
            Btn_Select_Click(card[8], uc_Card8, 8);
        }

        private void Uc_Card8_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[8], uc_Card8);
        }
        private void Uc_Card8_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(8);
        }
        private void Uc_Card8_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[8], uc_Card8);
        }
        private void Uc_Card9_btn_SelectClick(object sender, EventArgs e)
        {
            card[9] = new CardInfo();
            Btn_Select_Click(card[9], uc_Card9, 9);
        }

        private void Uc_Card9_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[9], uc_Card9);
        }

        private void Uc_Card9_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(9);
        }
        private void Uc_Card9_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[9], uc_Card9);
        }

        private void Uc_Card10_btn_SelectClick(object sender, EventArgs e)
        {
            card[10] = new CardInfo();
            Btn_Select_Click(card[10], uc_Card10, 10);
        }

        private void Uc_Card10_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[10], uc_Card10);
        }
        private void Uc_Card10_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(10);
        }
        private void Uc_Card10_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[10], uc_Card10);
        }
        private void Uc_Card11_btn_SelectClick(object sender, EventArgs e)
        {
            card[11] = new CardInfo();
            Btn_Select_Click(card[11], uc_Card11, 11);
        }

        private void Uc_Card11_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[11], uc_Card11);
        }

        private void Uc_Card11_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(11);
        }
        private void Uc_Card11_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[11], uc_Card11);
        }
        private void Uc_Card12_btn_SelectClick(object sender, EventArgs e)
        {
            card[12] = new CardInfo();
            Btn_Select_Click(card[12], uc_Card12, 12);
        }

        private void Uc_Card12_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[12], uc_Card12);
        }
        private void Uc_Card12_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(12);
        }
        private void Uc_Card12_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[12], uc_Card12);
        }
        private void Uc_Card13_btn_SelectClick(object sender, EventArgs e)
        {
            card[13] = new CardInfo();
            Btn_Select_Click(card[13], uc_Card13, 13);
        }

        private void Uc_Card13_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[13], uc_Card13);
        }

        private void Uc_Card13_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(13);
        }
        private void Uc_Card13_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[13], uc_Card13);
        }
        private void Uc_Card14_btn_SelectClick(object sender, EventArgs e)
        {
            card[14] = new CardInfo();
            Btn_Select_Click(card[14], uc_Card14, 14);
        }

        private void Uc_Card14_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[14], uc_Card14);
        }
        private void Uc_Card14_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(14);
        }
        private void Uc_Card14_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[14], uc_Card14);
        }
        private void Uc_Card15_btn_SelectClick(object sender, EventArgs e)
        {
            card[15] = new CardInfo();
            Btn_Select_Click(card[15], uc_Card15, 15);
        }

        private void Uc_Card15_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[15], uc_Card15);
        }

        private void Uc_Card15_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(15);
        }
        private void Uc_Card15_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[15], uc_Card15);
        }
        private void Uc_Card16_btn_SelectClick(object sender, EventArgs e)
        {
            card[16] = new CardInfo();
            Btn_Select_Click(card[16], uc_Card16, 16);
        }

        private void Uc_Card16_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[16], uc_Card16);
        }
        private void Uc_Card16_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(16);
        }
        private void Uc_Card16_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[16], uc_Card16);
        }
        private void Uc_Card17_btn_SelectClick(object sender, EventArgs e)
        {
            card[17] = new CardInfo();
            Btn_Select_Click(card[17], uc_Card17, 17);
        }

        private void Uc_Card17_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[17], uc_Card17);
        }
        private void Uc_Card17_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(17);
        }
        private void Uc_Card17_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[17], uc_Card17);
        }
        private void Uc_Card18_btn_SelectClick(object sender, EventArgs e)
        {
            card[18] = new CardInfo();
            Btn_Select_Click(card[18], uc_Card18, 18);
        }

        private void Uc_Card18_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[18], uc_Card18);
        }
        private void Uc_Card18_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(18);
        }
        private void Uc_Card18_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[18], uc_Card18);
        }
        private void Uc_Card19_btn_SelectClick(object sender, EventArgs e)
        {
            card[19] = new CardInfo();
            Btn_Select_Click(card[19], uc_Card19, 19);
        }

        private void Uc_Card19_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[19], uc_Card19);
        }
        private void Uc_Card19_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(19);
        }
        private void Uc_Card19_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[19], uc_Card19);
        }
        private void Uc_Card20_btn_SelectClick(object sender, EventArgs e)
        {
            card[20] = new CardInfo();
            Btn_Select_Click(card[20], uc_Card20, 20);
        }

        private void Uc_Card20_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[20], uc_Card20);
        }
        private void Uc_Card20_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(20);
        }
        private void Uc_Card20_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[20], uc_Card20);
        }
        private void Uc_Card21_btn_SelectClick(object sender, EventArgs e)
        {
            card[21] = new CardInfo();
            Btn_Select_Click(card[21], uc_Card21, 21);
        }

        private void Uc_Card21_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[21], uc_Card21);
        }
        private void Uc_Card21_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(21);
        }
        private void Uc_Card21_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[21], uc_Card21);
        }
        private void Uc_Card22_btn_SelectClick(object sender, EventArgs e)
        {
            card[22] = new CardInfo();
            Btn_Select_Click(card[22], uc_Card22, 22);
        }

        private void Uc_Card22_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[22], uc_Card22);
        }
        private void Uc_Card22_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(22);
        }
        private void Uc_Card22_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[22], uc_Card22);
        }
        private void Uc_Card23_btn_SelectClick(object sender, EventArgs e)
        {
            card[23] = new CardInfo();
            Btn_Select_Click(card[23], uc_Card23, 23);
        }

        private void Uc_Card23_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[23], uc_Card23);
        }
        private void Uc_Card23_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(23);
        }
        private void Uc_Card23_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[23], uc_Card23);
        }
        private void Uc_Card24_btn_SelectClick(object sender, EventArgs e)
        {
            card[24] = new CardInfo();
            Btn_Select_Click(card[24], uc_Card24, 24);
        }

        private void Uc_Card24_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[24], uc_Card24);
        }
        private void Uc_Card24_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(24);
        }
        private void Uc_Card24_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[24], uc_Card24);
        }

        private void Uc_Card25_btn_SelectClick(object sender, EventArgs e)
        {
            card[25] = new CardInfo();
            Btn_Select_Click(card[25], uc_Card25, 25);
        }

        private void Uc_Card25_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[25], uc_Card25);
        }
        private void Uc_Card25_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(25);
        }
        private void Uc_Card25_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[25], uc_Card25);
        }
        private void Uc_Card26_btn_SelectClick(object sender, EventArgs e)
        {
            card[26] = new CardInfo();
            Btn_Select_Click(card[26], uc_Card26, 26);
        }

        private void Uc_Card26_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[26], uc_Card26);
        }
        private void Uc_Card26_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(26);
        }
        private void Uc_Card26_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[26], uc_Card26);
        }
        private void Uc_Card27_btn_SelectClick(object sender, EventArgs e)
        {
            card[27] = new CardInfo();
            Btn_Select_Click(card[27], uc_Card27, 27);
        }

        private void Uc_Card27_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[27], uc_Card27);
        }
        private void Uc_Card27_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(27);
        }
        private void Uc_Card27_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[27], uc_Card27);
        }
        private void Uc_Card28_btn_SelectClick(object sender, EventArgs e)
        {
            card[28] = new CardInfo();
            Btn_Select_Click(card[28], uc_Card28, 28);
        }

        private void Uc_Card28_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[28], uc_Card28);
        }
        private void Uc_Card28_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(28);
        }
        private void Uc_Card28_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[28], uc_Card28);
        }
        private void Uc_Card29_btn_SelectClick(object sender, EventArgs e)
        {
            card[29] = new CardInfo();
            Btn_Select_Click(card[29], uc_Card29, 29);
        }

        private void Uc_Card29_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[29], uc_Card29);
        }
        private void Uc_Card29_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(29);
        }
        private void Uc_Card29_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[29], uc_Card29);
        }
        private void Uc_Card30_btn_SelectClick(object sender, EventArgs e)
        {
            card[30] = new CardInfo();
            Btn_Select_Click(card[30], uc_Card30, 30);
        }

        private void Uc_Card30_btn_DeleteClick(object sender, EventArgs e)
        {
            Btn_Delete_Click(card[30], uc_Card30);
        }
        private void Uc_Card30_pbx_PictClick(object sender, EventArgs e)
        {
            Pbx_Pict_Click(30);
        }
        private void Uc_Card30_nud_ValueChanged(object sender, EventArgs e)
        {
            Nud_ValueChanged(card[30], uc_Card30);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
            if(cbx_SearchCatego.SelectedIndex == 0)
            {
                cbx_SearchCatego2.SelectedIndex = 0;
                return;
            }

            if (cbx_SearchCatego.Text == "ポケモン")
            {
                cbx_SearchCatego2.Text = "すべて";
                cbx_SearchCatego2.Items.AddRange(new object[] 
                {"すべて", "無", "草", "炎", "水", "雷", "超", "闘", "鋼", "悪", "龍", "妖"});
            }
        }
    }
}
