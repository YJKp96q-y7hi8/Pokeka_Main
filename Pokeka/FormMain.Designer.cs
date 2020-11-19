namespace Pokeka
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbx_Info = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Info_Show = new System.Windows.Forms.Button();
            this.lbl_Info_DeckName = new System.Windows.Forms.Label();
            this.tbx_Info_Num = new System.Windows.Forms.TextBox();
            this.tbx_Info_DeckName = new System.Windows.Forms.TextBox();
            this.lbl_Info_Num = new System.Windows.Forms.Label();
            this.gbx_Rec = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Rec_Set = new System.Windows.Forms.Button();
            this.btn_Rec_Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.gbx_Info.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbx_Rec.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_Info
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.gbx_Info, 4);
            this.gbx_Info.Controls.Add(this.tableLayoutPanel1);
            this.gbx_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Info.Location = new System.Drawing.Point(3, 3);
            this.gbx_Info.Name = "gbx_Info";
            this.gbx_Info.Size = new System.Drawing.Size(930, 51);
            this.gbx_Info.TabIndex = 25;
            this.gbx_Info.TabStop = false;
            this.gbx_Info.Text = "デッキ情報";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Info_Show, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Info_DeckName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbx_Info_Num, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbx_Info_DeckName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_Info_Num, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(924, 30);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // btn_Info_Show
            // 
            this.btn_Info_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Info_Show.Location = new System.Drawing.Point(785, 3);
            this.btn_Info_Show.Name = "btn_Info_Show";
            this.btn_Info_Show.Size = new System.Drawing.Size(136, 24);
            this.btn_Info_Show.TabIndex = 4;
            this.btn_Info_Show.Text = "リセット";
            this.btn_Info_Show.UseVisualStyleBackColor = true;
            this.btn_Info_Show.Click += new System.EventHandler(this.btn_Info_Reset_Click);
            // 
            // lbl_Info_DeckName
            // 
            this.lbl_Info_DeckName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info_DeckName.AutoSize = true;
            this.lbl_Info_DeckName.Location = new System.Drawing.Point(3, 7);
            this.lbl_Info_DeckName.Name = "lbl_Info_DeckName";
            this.lbl_Info_DeckName.Size = new System.Drawing.Size(104, 15);
            this.lbl_Info_DeckName.TabIndex = 5;
            this.lbl_Info_DeckName.Text = "デッキ名";
            this.lbl_Info_DeckName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbx_Info_Num
            // 
            this.tbx_Info_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Info_Num.Location = new System.Drawing.Point(712, 4);
            this.tbx_Info_Num.Name = "tbx_Info_Num";
            this.tbx_Info_Num.ReadOnly = true;
            this.tbx_Info_Num.Size = new System.Drawing.Size(67, 22);
            this.tbx_Info_Num.TabIndex = 2;
            this.tbx_Info_Num.Text = "0";
            // 
            // tbx_Info_DeckName
            // 
            this.tbx_Info_DeckName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Info_DeckName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tbx_Info_DeckName.Location = new System.Drawing.Point(113, 4);
            this.tbx_Info_DeckName.Name = "tbx_Info_DeckName";
            this.tbx_Info_DeckName.Size = new System.Drawing.Size(483, 22);
            this.tbx_Info_DeckName.TabIndex = 0;
            // 
            // lbl_Info_Num
            // 
            this.lbl_Info_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Info_Num.AutoSize = true;
            this.lbl_Info_Num.Location = new System.Drawing.Point(602, 7);
            this.lbl_Info_Num.Name = "lbl_Info_Num";
            this.lbl_Info_Num.Size = new System.Drawing.Size(104, 15);
            this.lbl_Info_Num.TabIndex = 1;
            this.lbl_Info_Num.Text = "合計枚数";
            this.lbl_Info_Num.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbx_Rec
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.gbx_Rec, 2);
            this.gbx_Rec.Controls.Add(this.tableLayoutPanel2);
            this.gbx_Rec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Rec.Location = new System.Drawing.Point(939, 3);
            this.gbx_Rec.Name = "gbx_Rec";
            this.gbx_Rec.Size = new System.Drawing.Size(462, 51);
            this.gbx_Rec.TabIndex = 26;
            this.gbx_Rec.TabStop = false;
            this.gbx_Rec.Text = "記録";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_Rec_Set, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Rec_Save, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(456, 30);
            this.tableLayoutPanel2.TabIndex = 33;
            // 
            // btn_Rec_Set
            // 
            this.btn_Rec_Set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Rec_Set.Location = new System.Drawing.Point(231, 3);
            this.btn_Rec_Set.Name = "btn_Rec_Set";
            this.btn_Rec_Set.Size = new System.Drawing.Size(222, 24);
            this.btn_Rec_Set.TabIndex = 5;
            this.btn_Rec_Set.Text = "デッキセット";
            this.btn_Rec_Set.UseVisualStyleBackColor = true;
            this.btn_Rec_Set.Click += new System.EventHandler(this.btn_Rec_Set_Click);
            // 
            // btn_Rec_Save
            // 
            this.btn_Rec_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Rec_Save.Location = new System.Drawing.Point(3, 3);
            this.btn_Rec_Save.Name = "btn_Rec_Save";
            this.btn_Rec_Save.Size = new System.Drawing.Size(222, 24);
            this.btn_Rec_Save.TabIndex = 4;
            this.btn_Rec_Save.Text = "デッキ保存";
            this.btn_Rec_Save.UseVisualStyleBackColor = true;
            this.btn_Rec_Save.Click += new System.EventHandler(this.btn_Rec_Save_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Controls.Add(this.gbx_Rec, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.gbx_Info, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_Search, 8, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.761905F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(2344, 1200);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.btn_Search, 2);
            this.btn_Search.Location = new System.Drawing.Point(1875, 3);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(466, 51);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "検索";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(2365, 833);
            this.Controls.Add(this.tableLayoutPanel3);
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "ポケカデッキメーカー";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbx_Info.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.gbx_Rec.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbx_Info;
        private System.Windows.Forms.TextBox tbx_Info_Num;
        private System.Windows.Forms.Label lbl_Info_Num;
        private System.Windows.Forms.TextBox tbx_Info_DeckName;
        private System.Windows.Forms.GroupBox gbx_Rec;
        private System.Windows.Forms.Button btn_Rec_Set;
        private System.Windows.Forms.Button btn_Rec_Save;
        private System.Windows.Forms.Button btn_Info_Show;
        private System.Windows.Forms.Label lbl_Info_DeckName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_Search;
    }
}

