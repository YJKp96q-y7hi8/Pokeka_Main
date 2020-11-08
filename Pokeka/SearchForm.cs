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
    public partial class SearchForm : Form
    {
        PictureBox[] pictureBoxes = new PictureBox[30];
        int listNum = 0;

        //FormMainオブジェクトを保持ずるためのフィールド
        private static SearchForm _searchFormInstance;
        //FormMainオブジェクトを取得・設定するためのプロパティ
        public static SearchForm SearchFormInstance
        {
            get { return _searchFormInstance; }
            set { _searchFormInstance = value; }
        }

        public SearchForm()
        {
            InitializeComponent();
            pictureBoxes[0] = pbx_01;
            pictureBoxes[1] = pbx_02;
            pictureBoxes[2] = pbx_03;
            pictureBoxes[3] = pbx_04;
            pictureBoxes[4] = pbx_05;
            pictureBoxes[5] = pbx_06;
            pictureBoxes[6] = pbx_07;
            pictureBoxes[7] = pbx_08;
            pictureBoxes[8] = pbx_09;
            pictureBoxes[9] = pbx_10;
            pictureBoxes[10] = pbx_11;
            pictureBoxes[11] = pbx_12;
            pictureBoxes[12] = pbx_13;
            pictureBoxes[13] = pbx_14;
            pictureBoxes[14] = pbx_15;
            pictureBoxes[15] = pbx_16;
            pictureBoxes[16] = pbx_17;
            pictureBoxes[17] = pbx_18;
            pictureBoxes[18] = pbx_19;
            pictureBoxes[19] = pbx_20;
            pictureBoxes[20] = pbx_21;
            pictureBoxes[21] = pbx_22;
            pictureBoxes[22] = pbx_23;
            pictureBoxes[23] = pbx_24;
            pictureBoxes[24] = pbx_25;
            pictureBoxes[25] = pbx_26;
            pictureBoxes[26] = pbx_27;
            pictureBoxes[27] = pbx_28;
            pictureBoxes[28] = pbx_29;
            pictureBoxes[29] = pbx_30;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            if(FormMain.Form1Instance.searchCardList.Count == 0)
            {
                return;
            }

            if (FormMain.Form1Instance.searchCardList.Count > 30)
            {
                for (int i = 0; i < 30; i++)
                {
                    pictureBoxes[i].ImageLocation = FormMain.Form1Instance.searchCardList[i];
                }
            }
            else
            {
                for (int i = 0; i < FormMain.Form1Instance.searchCardList.Count; i++)
                {
                    pictureBoxes[i].ImageLocation = FormMain.Form1Instance.searchCardList[i];
                }
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (listNum + 30 > FormMain.Form1Instance.searchCardList.Count)
            {
                return;
            }

            for (int i = 0; i < 30; i++)
            {
                pictureBoxes[i].ImageLocation = "";
            }

            listNum += 30;
            if (FormMain.Form1Instance.searchCardList.Count > listNum + 30)
            {
                for (int i = listNum; i < listNum + 30; i++)
                {
                    pictureBoxes[i - listNum].ImageLocation = FormMain.Form1Instance.searchCardList[i];
                }
            }
            else
            {
                for (int i = listNum; i < FormMain.Form1Instance.searchCardList.Count; i++)
                {
                    pictureBoxes[i - listNum].ImageLocation = FormMain.Form1Instance.searchCardList[i];
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (listNum - 30 < 0)
            {
                return;
            }

            for (int i = 0; i < 30; i++)
            {
                pictureBoxes[i].ImageLocation = "";
            }

            listNum -= 30;
            for (int i = listNum; i < listNum + 30; i++)
            {
                pictureBoxes[i - listNum].ImageLocation = FormMain.Form1Instance.searchCardList[i];
            }
        }

        private void SelectCard(PictureBox sender)
        {
            if(sender.ImageLocation == null)
            {
                return;
            }

            try
            {
                CardInfo newCardInfo = null;
                uc_Card newUcCard = null;
                for(int i = 1; i<31; i++)
                {
                    if(FormMain.Form1Instance._cardInfo[i] == null)
                    {
                        FormMain.Form1Instance._cardInfo[i] = new CardInfo();
                        newCardInfo = FormMain.Form1Instance._cardInfo[i];
                        newUcCard = FormMain.Form1Instance._ucCard[i];
                        break;
                    }
                }
                if(newCardInfo == null || newUcCard == null)
                {
                    MessageBox.Show("追加できません");
                    return;
                }
                newCardInfo.SetCardInfo(Path.GetFileName(sender.ImageLocation), sender.ImageLocation);
                FormMain.Form1Instance.SetCardInfo(newUcCard, newCardInfo, 1);
                FormMain.Form1Instance.Nud_ValueChanged(newCardInfo, newUcCard);
            }
            catch
            {
                MessageBox.Show("謎エラー");
            }
            this.Close();
        }

        private void pbx_Click(object sender, EventArgs e)
        {
            SelectCard((PictureBox)sender);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchForm_Shown(object sender, EventArgs e)
        {
            pbx_01.Focus();
        }
    }
}
