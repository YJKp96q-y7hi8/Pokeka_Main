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
        private List<string> searchCardList = new List<string>(); 
        private List<PictureBox> manyPict = new List<PictureBox>();
        private int pageNum = 0;
        private int LIST_MAX = 50;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            string directoryPath = @"Card List";
            SearchCommon(directoryPath);

            if (searchCardList.Count == 0)
            {
                return;
            }

            int h = Screen.GetWorkingArea(this).Height;
            int w = Screen.GetWorkingArea(this).Width;

            Console.WriteLine("h:{0}, w:{1}", h, w);

            this.SetDesktopLocation(w - w / 4, 0);
            this.Width = w / 4;
            this.Height = h;

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;

            int loopNum = searchCardList.Count;
            if (loopNum > LIST_MAX)
            {
                loopNum = LIST_MAX;
            }
            for (int i = 0; i < loopNum; i++)
            {
                PictureBox pict = new PictureBox();
                manyPict.Add(pict);

                int numX = i % 5;
                int numY = i / 5 + 1;

                tableLayoutPanel1.Controls.Add(manyPict[i], numX, numY);

                manyPict[i].Dock = DockStyle.Fill;
                manyPict[i].Name = "pict_" + i;
                manyPict[i].SizeMode = PictureBoxSizeMode.Zoom;
                manyPict[i].ImageLocation = searchCardList[i];

                manyPict[i].Click += new EventHandler(pbx_Click);
            }
        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            pageNum++;
            int startNum = LIST_MAX * pageNum;
            if (startNum > searchCardList.Count)
            {
                pageNum--;
                return;
            }

            PageChange(startNum);
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            if (pageNum == 0) { return; }

            pageNum--;
            int startNum = LIST_MAX * pageNum;

            PageChange(startNum);
        }

        private void PageChange(int startNum)
        {
            for (int i = 0; i < LIST_MAX; i++)
            {
                manyPict[i].ImageLocation = "";
            }

            int loopNum = searchCardList.Count - startNum;
            if (loopNum > LIST_MAX)
            {
                loopNum = LIST_MAX;
            }

            for (int i = 0; i < loopNum; i++)
            {
                manyPict[i].ImageLocation = searchCardList[startNum + i];
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
        }

        /// <summary>
        /// 検索アルゴリズム
        /// </summary>
        private void SearchCard()
        {
            searchCardList.Clear();
            string directoryPath = @"Card List";

            if (cbx_SearchCatego1.Text != "カテゴリ")
            {
                if (cbx_SearchCatego3.Text != "パック")
                {
                    if (cbx_SearchCatego2.Text != "すべて" && cbx_SearchCatego2.Text != "")
                    {
                        directoryPath += @"\" + cbx_SearchCatego1.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego1.Text;
                        directoryPath += "\\" + cbx_SearchCatego3.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego3.Text;
                        string directory2Path = cbx_SearchCatego2.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego2.Text;

                        SearchCommon(directoryPath, directory2Path);
                    }
                    else
                    {
                        directoryPath += @"\" + cbx_SearchCatego1.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego1.Text;
                        directoryPath += "\\" + cbx_SearchCatego3.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego3.Text;

                        SearchCommon(directoryPath);
                    }
                }
                else if (cbx_SearchCatego2.Text != "すべて" && cbx_SearchCatego2.Text != "")
                {
                    directoryPath += @"\\" + cbx_SearchCatego1.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego1.Text;
                    string directory2Path = cbx_SearchCatego2.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego2.Text;

                    SearchCommon(directoryPath, directory2Path);
                }
                else
                {
                    directoryPath += @"\\" + cbx_SearchCatego1.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego1.Text;

                    SearchCommon(directoryPath);
                }
            }
            else if (cbx_SearchCatego3.Text != "パック")
            {
                string directory2Path = cbx_SearchCatego3.SelectedIndex.ToString("D2") + "_" + cbx_SearchCatego3.Text;

                SearchCommon(directoryPath, directory2Path);
            }
            else
            {
                SearchCommon(directoryPath);
            }

            PageChange(0);
        }

        /// <summary>
        /// 検索アルゴリズム共通部分
        /// </summary>
        /// <param name="directoryPath">ディレクトリパス1</param>
        /// <param name="directory2Path">ディレクトリパス2</param>
        private void SearchCommon(string directoryPath, string directory2Path = "")
        {
            string[] filesFullPath = Directory.GetFiles(directoryPath, "*.jpg", SearchOption.AllDirectories);
            foreach (string pathes in filesFullPath)
            {
                if (pathes.Contains(directory2Path))
                {
                    if (tbx_Search.Text != "")
                    {
                        if (pathes.Contains(tbx_Search.Text))
                            searchCardList.Add(pathes);
                    }
                    else
                    {
                        searchCardList.Add(pathes);
                    }
                }
            }
        }

        private void cbx_SearchCatego_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_SearchCatego2.Text = "";
            cbx_SearchCatego2.Enabled = true;
            cbx_SearchCatego3.Enabled = true;
            cbx_SearchCatego3.Text = "パック";
            cbx_SearchCatego2.Items.Clear();

            if (cbx_SearchCatego1.Text == "ポケモン")
            {
                cbx_SearchCatego2.Enabled = true;
                cbx_SearchCatego2.Text = "すべて";
                cbx_SearchCatego2.Items.AddRange(new object[]
                {"すべて", "無", "草", "炎", "水", "雷", "超", "闘", "悪", "鋼", "龍", "妖"});
            }
            else if (cbx_SearchCatego1.Text == "エネルギー")
            {
                cbx_SearchCatego3.Enabled = false;
                cbx_SearchCatego3.SelectedIndex = 0;
                cbx_SearchCatego2.Enabled = false;
                cbx_SearchCatego2.Text = "すべて";
                cbx_SearchCatego2.Items.AddRange(new object[]
                {"すべて", "基本エネルギー", "特殊エネルギー"});
            }
            else
            {
                cbx_SearchCatego2.Enabled = false;
            }
        }

        private void pbx_Click(object sender, EventArgs e)
        {
            SelectCard((PictureBox)sender);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchCard(object sender, EventArgs e)
        {
            pageNum = 0;
            SearchCard();
        }
    }
}
