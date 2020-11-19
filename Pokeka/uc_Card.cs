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

        public event EventHandler Click_Btn_Delete;
        public event EventHandler Click_Pbx_Pict;
        public event EventHandler ValueChanged_Nud_Num;
        public event EventHandler CheckedChanged_Chbx_Check;

        public uc_Card()
        {
            InitializeComponent();
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"Card List");
        }

        public PictureBox Pict
        {
            get { return pbx_Pict; }
        }

        public string GbxText
        {
            get { return gbx_Card.Text; }
            set { gbx_Card.Text = value; }
        }

        public bool ChbxChecked
        {
            get { return chbx_Check.Checked; }
            set { chbx_Check.Checked = value; }
        }

        public NumericUpDown Nud
        {
            get { return nud_Num; }
        }

        //枚数変更前の枚数を保存するための変数
        public int Num;

        public void SetCardInfo(string fileName, string pass)
        {
            string category = "";

            if (pass.Replace(fileName, "").Contains("ポケモン")) { category = "ポケモン"; }
            if (pass.Replace(fileName, "").Contains("グッズ")) { category = "グッズ"; }
            if (pass.Replace(fileName, "").Contains("サポート")) { category = "サポート"; }
            if (pass.Replace(fileName, "").Contains("スタジアム")) { category = "スタジアム"; }
            if (pass.Replace(fileName, "").Contains("エネルギー")) { category = "エネルギー"; }

            gbx_Card.Text = category;
            pbx_Pict.ImageLocation = pass;
        }

        protected virtual void OnEvent(EventHandler handle, EventArgs e)
        {
            var handler = handle;
            if(handler != null)
            {
                handler(this, e);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            OnEvent(Click_Btn_Delete, e);
        }

        private void pbx_Pict_Click(object sender, EventArgs e)
        {
            OnEvent(Click_Pbx_Pict, e);
        }

        private void chbx_Check_CheckedChanged(object sender, EventArgs e)
        {
            OnEvent(CheckedChanged_Chbx_Check, e);
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

        private void gbx_Card_TextChanged(object sender, EventArgs e)
        {
            if(pbx_Pict.ImageLocation != null)
            {
                nud_Num.Value = 1;
                nud_Num.Enabled = true;
            }
            else
            {
                nud_Num.Value = 0;
                nud_Num.Enabled = false;
            }
        }
    }
}
