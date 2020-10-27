using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokeka
{
    public partial class SearchForm : Form
    {
        PictureBox[] pictureBoxes = new PictureBox[30];

        int listNum = 0;

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
    }
}
