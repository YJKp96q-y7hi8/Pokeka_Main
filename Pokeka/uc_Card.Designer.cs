namespace Pokeka
{
    partial class uc_Card
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbx_Card = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.pbx_Pict = new System.Windows.Forms.PictureBox();
            this.nud_Num = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.gbx_Card.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Pict)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Num)).BeginInit();
            this.SuspendLayout();
            // 
            // gbx_Card
            // 
            this.gbx_Card.Controls.Add(this.tableLayoutPanel1);
            this.gbx_Card.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_Card.Location = new System.Drawing.Point(0, 0);
            this.gbx_Card.Name = "gbx_Card";
            this.gbx_Card.Size = new System.Drawing.Size(191, 282);
            this.gbx_Card.TabIndex = 1;
            this.gbx_Card.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.50485F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.74757F));
            this.tableLayoutPanel1.Controls.Add(this.pbx_Pict, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.nud_Num, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btn_Delete, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 261);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.Location = new System.Drawing.Point(33, 227);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(71, 28);
            this.btn_Delete.TabIndex = 2;
            this.btn_Delete.Text = "削除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // pbx_Pict
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pbx_Pict, 3);
            this.pbx_Pict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_Pict.Location = new System.Drawing.Point(3, 3);
            this.pbx_Pict.Name = "pbx_Pict";
            this.pbx_Pict.Size = new System.Drawing.Size(179, 215);
            this.pbx_Pict.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_Pict.TabIndex = 3;
            this.pbx_Pict.TabStop = false;
            this.pbx_Pict.WaitOnLoad = true;
            this.pbx_Pict.Click += new System.EventHandler(this.pbx_Pict_Click);
            // 
            // nud_Num
            // 
            this.nud_Num.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nud_Num.Enabled = false;
            this.nud_Num.Location = new System.Drawing.Point(109, 230);
            this.nud_Num.Margin = new System.Windows.Forms.Padding(2);
            this.nud_Num.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nud_Num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Num.Name = "nud_Num";
            this.nud_Num.Size = new System.Drawing.Size(74, 22);
            this.nud_Num.TabIndex = 0;
            this.nud_Num.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Num.ValueChanged += new System.EventHandler(this.nud_Num_ValueChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 232);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(24, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // uc_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gbx_Card);
            this.Name = "uc_Card";
            this.Size = new System.Drawing.Size(191, 282);
            this.gbx_Card.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Pict)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Num)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbx_Card;
        public System.Windows.Forms.PictureBox pbx_Pict;
        public System.Windows.Forms.Button btn_Delete;
        public System.Windows.Forms.NumericUpDown nud_Num;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
