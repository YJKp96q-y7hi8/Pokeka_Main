namespace Pokeka
{
    partial class ShowPict
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
            this.pbx_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_Image
            // 
            this.pbx_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_Image.Location = new System.Drawing.Point(0, 0);
            this.pbx_Image.Name = "pbx_Image";
            this.pbx_Image.Size = new System.Drawing.Size(538, 699);
            this.pbx_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbx_Image.TabIndex = 0;
            this.pbx_Image.TabStop = false;
            this.pbx_Image.Click += new System.EventHandler(this.pbx_Image_Click);
            // 
            // ShowPict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 652);
            this.Controls.Add(this.pbx_Image);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(538, 699);
            this.MinimumSize = new System.Drawing.Size(538, 699);
            this.Name = "ShowPict";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pbx_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_Image;
    }
}