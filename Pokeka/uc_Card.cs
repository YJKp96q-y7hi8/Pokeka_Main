using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Pokeka
{
    public partial class uc_Card : UserControl
    {
        OpenFileDialog ofd = new OpenFileDialog();

        public event EventHandler Click_Btn_Select;
        public event EventHandler Click_Btn_Delete;
        public event EventHandler Click_Pbx_Pict;
        public event EventHandler ValueChanged_Nud_Num;

        public uc_Card()
        {
            InitializeComponent();
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Card List");
        }

        protected virtual void OnEvent(EventHandler handle, EventArgs e)
        {
            var handler = handle;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OnEvent(Click_Btn_Select, e);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            OnEvent(Click_Btn_Delete, e);
        }

        private void pbx_Pict_Click(object sender, EventArgs e)
        {
            OnEvent(Click_Pbx_Pict, e);
        }

        private void nud_Num_ValueChanged(object sender, EventArgs e)
        {
            OnEvent(ValueChanged_Nud_Num, e);
            if (nud_Num.Value >= 4)
            {
                if (!gbx_Card.Text.Contains("エネルギー"))
                {
                    nud_Num.Value = 4;
                }
            }
        }
    }
}
