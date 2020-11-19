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

            FormMain formMain = FormMain.Form1Instance;
            pbx_Image.ImageLocation = formMain.selectCardPath;
        }

        private void pbx_Image_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowPict_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }
    }
}
