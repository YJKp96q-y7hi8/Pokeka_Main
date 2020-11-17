namespace Pokeka
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbx_Search = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_Search = new System.Windows.Forms.TextBox();
            this.cbx_SearchCatego1 = new System.Windows.Forms.ComboBox();
            this.cbx_SearchCatego3 = new System.Windows.Forms.ComboBox();
            this.cbx_SearchCatego2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbx_Search.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Next
            // 
            this.btn_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Next.Location = new System.Drawing.Point(411, 921);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(98, 29);
            this.btn_Next.TabIndex = 30;
            this.btn_Next.Text = "次へ";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Back.Location = new System.Drawing.Point(3, 921);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(96, 29);
            this.btn_Back.TabIndex = 31;
            this.btn_Back.Text = "前へ";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Close.Location = new System.Drawing.Point(207, 921);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(96, 29);
            this.btn_Close.TabIndex = 32;
            this.btn_Close.Text = "閉じる";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.gbx_Search, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Back, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.btn_Next, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.btn_Close, 2, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.135988F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.929232F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.571692F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(512, 953);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // gbx_Search
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.gbx_Search, 5);
            this.gbx_Search.Controls.Add(this.tableLayoutPanel4);
            this.gbx_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Search.Location = new System.Drawing.Point(3, 3);
            this.gbx_Search.Name = "gbx_Search";
            this.gbx_Search.Size = new System.Drawing.Size(506, 62);
            this.gbx_Search.TabIndex = 33;
            this.gbx_Search.TabStop = false;
            this.gbx_Search.Text = "検索";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tbx_Search, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbx_SearchCatego1, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbx_SearchCatego3, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbx_SearchCatego2, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(500, 41);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tbx_Search
            // 
            this.tbx_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Search.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tbx_Search.Location = new System.Drawing.Point(3, 9);
            this.tbx_Search.Name = "tbx_Search";
            this.tbx_Search.Size = new System.Drawing.Size(194, 22);
            this.tbx_Search.TabIndex = 1;
            this.tbx_Search.TextChanged += new System.EventHandler(this.SearchCard);
            // 
            // cbx_SearchCatego1
            // 
            this.cbx_SearchCatego1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_SearchCatego1.FormattingEnabled = true;
            this.cbx_SearchCatego1.Items.AddRange(new object[] {
            "カテゴリ",
            "ポケモン",
            "グッズ",
            "サポート",
            "スタジアム",
            "エネルギー"});
            this.cbx_SearchCatego1.Location = new System.Drawing.Point(203, 9);
            this.cbx_SearchCatego1.Name = "cbx_SearchCatego1";
            this.cbx_SearchCatego1.Size = new System.Drawing.Size(94, 23);
            this.cbx_SearchCatego1.TabIndex = 2;
            this.cbx_SearchCatego1.Text = "カテゴリ";
            this.cbx_SearchCatego1.SelectedIndexChanged += new System.EventHandler(this.cbx_SearchCatego_SelectedIndexChanged);
            this.cbx_SearchCatego1.TextChanged += new System.EventHandler(this.SearchCard);
            // 
            // cbx_SearchCatego3
            // 
            this.cbx_SearchCatego3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_SearchCatego3.FormattingEnabled = true;
            this.cbx_SearchCatego3.Items.AddRange(new object[] {
            "パック",
            "仰天のボルテッカー",
            "伝説の鼓動",
            "ムゲンゾーン",
            "爆炎ウォーカー",
            "反逆クラッシュ",
            "VMAXライジング",
            "シールド",
            "ソード",
            "タッグオールスターズ",
            "その他"});
            this.cbx_SearchCatego3.Location = new System.Drawing.Point(403, 9);
            this.cbx_SearchCatego3.Name = "cbx_SearchCatego3";
            this.cbx_SearchCatego3.Size = new System.Drawing.Size(94, 23);
            this.cbx_SearchCatego3.TabIndex = 4;
            this.cbx_SearchCatego3.Text = "パック";
            this.cbx_SearchCatego3.TextChanged += new System.EventHandler(this.SearchCard);
            // 
            // cbx_SearchCatego2
            // 
            this.cbx_SearchCatego2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_SearchCatego2.Enabled = false;
            this.cbx_SearchCatego2.FormattingEnabled = true;
            this.cbx_SearchCatego2.Location = new System.Drawing.Point(303, 9);
            this.cbx_SearchCatego2.Name = "cbx_SearchCatego2";
            this.cbx_SearchCatego2.Size = new System.Drawing.Size(94, 23);
            this.cbx_SearchCatego2.TabIndex = 3;
            this.cbx_SearchCatego2.TextChanged += new System.EventHandler(this.SearchCard);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 953);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SearchForm";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbx_Search.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbx_Search;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox tbx_Search;
        private System.Windows.Forms.ComboBox cbx_SearchCatego1;
        private System.Windows.Forms.ComboBox cbx_SearchCatego3;
        private System.Windows.Forms.ComboBox cbx_SearchCatego2;
    }
}