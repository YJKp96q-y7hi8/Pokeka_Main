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
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[1].pictPass;
                    break;
                case 2:
                    //this.Text = FormMain.Form1Instance.card[2].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[2].pictPass;
                    break;
                case 3:
                    //this.Text = FormMain.Form1Instance.card[3].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[3].pictPass;
                    break;
                case 4:
                    //this.Text = FormMain.Form1Instance.card[4].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[4].pictPass;
                    break;
                case 5:
                    //this.Text = FormMain.Form1Instance.card[5].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[5].pictPass;
                    break;
                case 6:
                    //this.Text = FormMain.Form1Instance.card[6].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[6].pictPass;
                    break;
                case 7:
                    //this.Text = FormMain.Form1Instance.card[7].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[7].pictPass;
                    break;
                case 8:
                    //this.Text = FormMain.Form1Instance.card[8].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[8].pictPass;
                    break;
                case 9:
                    //this.Text = FormMain.Form1Instance.card[9].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[9].pictPass;
                    break;
                case 10:
                    //this.Text = FormMain.Form1Instance.card[10].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[10].pictPass;
                    break;
                case 11:
                    //this.Text = FormMain.Form1Instance.card[11].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[11].pictPass;
                    break;
                case 12:
                    //this.Text = FormMain.Form1Instance.card[12].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[12].pictPass;
                    break;
                case 13:
                    //this.Text = FormMain.Form1Instance.card[13].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[13].pictPass;
                    break;
                case 14:
                    //this.Text = FormMain.Form1Instance.card[14].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[14].pictPass;
                    break;
                case 15:
                    //this.Text = FormMain.Form1Instance.card[15].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[15].pictPass;
                    break;
                case 16:
                    //this.Text = FormMain.Form1Instance.card[16].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[16].pictPass;
                    break;
                case 17:
                    //this.Text = FormMain.Form1Instance.card[17].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[17].pictPass;
                    break;
                case 18:
                    //this.Text = FormMain.Form1Instance.card[18].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[18].pictPass;
                    break;
                case 19:
                    //this.Text = FormMain.Form1Instance.card[19].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[19].pictPass;
                    break;
                case 20:
                    //this.Text = FormMain.Form1Instance.card[20].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[20].pictPass;
                    break;
                case 21:
                    //this.Text = FormMain.Form1Instance.card[21].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[21].pictPass;
                    break;
                case 22:
                    //this.Text = FormMain.Form1Instance.card[22].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[22].pictPass;
                    break;
                case 23:
                    //this.Text = FormMain.Form1Instance.card[23].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[23].pictPass;
                    break;
                case 24:
                    //this.Text = FormMain.Form1Instance.card[24].name;
                    pbx_Image.ImageLocation = FormMain.Form1Instance.card[24].pictPass;
                    break;
            }        
        }

        private void pbx_Image_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
