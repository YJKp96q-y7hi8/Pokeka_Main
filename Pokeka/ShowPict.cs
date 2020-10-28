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
    public partial class ShowPict : Form
    {
        public ShowPict()
        {
            InitializeComponent();
            switch (FormMain.Form1Instance.cardNum)
            {
                case 1:
                    //this.Text = FormMain.Form1Instance.card[1].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[1].PictPass;
                    break;
                case 2:
                    //this.Text = FormMain.Form1Instance.card[2].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[2].PictPass;
                    break;
                case 3:
                    //this.Text = FormMain.Form1Instance.card[3].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[3].PictPass;
                    break;
                case 4:
                    //this.Text = FormMain.Form1Instance.card[4].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[4].PictPass;
                    break;
                case 5:
                    //this.Text = FormMain.Form1Instance.card[5].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[5].PictPass;
                    break;
                case 6:
                    //this.Text = FormMain.Form1Instance.card[6].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[6].PictPass;
                    break;
                case 7:
                    //this.Text = FormMain.Form1Instance.card[7].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[7].PictPass;
                    break;
                case 8:
                    //this.Text = FormMain.Form1Instance.card[8].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[8].PictPass;
                    break;
                case 9:
                    //this.Text = FormMain.Form1Instance.card[9].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[9].PictPass;
                    break;
                case 10:
                    //this.Text = FormMain.Form1Instance.card[10].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[10].PictPass;
                    break;
                case 11:
                    //this.Text = FormMain.Form1Instance.card[11].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[11].PictPass;
                    break;
                case 12:
                    //this.Text = FormMain.Form1Instance.card[12].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[12].PictPass;
                    break;
                case 13:
                    //this.Text = FormMain.Form1Instance.card[13].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[13].PictPass;
                    break;
                case 14:
                    //this.Text = FormMain.Form1Instance.card[14].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[14].PictPass;
                    break;
                case 15:
                    //this.Text = FormMain.Form1Instance.card[15].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[15].PictPass;
                    break;
                case 16:
                    //this.Text = FormMain.Form1Instance.card[16].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[16].PictPass;
                    break;
                case 17:
                    //this.Text = FormMain.Form1Instance.card[17].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[17].PictPass;
                    break;
                case 18:
                    //this.Text = FormMain.Form1Instance.card[18].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[18].PictPass;
                    break;
                case 19:
                    //this.Text = FormMain.Form1Instance.card[19].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[19].PictPass;
                    break;
                case 20:
                    //this.Text = FormMain.Form1Instance.card[20].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[20].PictPass;
                    break;
                case 21:
                    //this.Text = FormMain.Form1Instance.card[21].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[21].PictPass;
                    break;
                case 22:
                    //this.Text = FormMain.Form1Instance.card[22].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[22].PictPass;
                    break;
                case 23:
                    //this.Text = FormMain.Form1Instance.card[23].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[23].PictPass;
                    break;
                case 24:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[24].PictPass;
                    break;
                case 25:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[25].PictPass;
                    break;
                case 26:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[26].PictPass;
                    break;
                case 27:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[27].PictPass;
                    break;
                case 28:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[28].PictPass;
                    break;
                case 29:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[29].PictPass;
                    break;
                case 30:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance._cardInfo[30].PictPass;
                    break;
            }        
        }

        private void pbx_Image_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
