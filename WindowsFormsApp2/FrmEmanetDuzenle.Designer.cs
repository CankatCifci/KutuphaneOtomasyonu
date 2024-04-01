namespace WindowsFormsApp2
{
    partial class FrmEmanetDuzenle
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
            this.cmbUyeler = new System.Windows.Forms.ComboBox();
            this.lstKitaplar = new System.Windows.Forms.ListBox();
            this.dgvEmanetler = new System.Windows.Forms.DataGridView();
            this.btnEmanet = new System.Windows.Forms.Button();
            this.txtEkBilgi = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmanetler)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUyeler
            // 
            this.cmbUyeler.FormattingEnabled = true;
            this.cmbUyeler.Location = new System.Drawing.Point(29, 28);
            this.cmbUyeler.Name = "cmbUyeler";
            this.cmbUyeler.Size = new System.Drawing.Size(121, 24);
            this.cmbUyeler.TabIndex = 0;
            // 
            // lstKitaplar
            // 
            this.lstKitaplar.FormattingEnabled = true;
            this.lstKitaplar.ItemHeight = 16;
            this.lstKitaplar.Location = new System.Drawing.Point(212, 28);
            this.lstKitaplar.Name = "lstKitaplar";
            this.lstKitaplar.Size = new System.Drawing.Size(120, 84);
            this.lstKitaplar.TabIndex = 1;
            this.lstKitaplar.SelectedIndexChanged += new System.EventHandler(this.lstKitaplar_SelectedIndexChanged);
            // 
            // dgvEmanetler
            // 
            this.dgvEmanetler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmanetler.Location = new System.Drawing.Point(13, 238);
            this.dgvEmanetler.Name = "dgvEmanetler";
            this.dgvEmanetler.RowHeadersWidth = 51;
            this.dgvEmanetler.RowTemplate.Height = 24;
            this.dgvEmanetler.Size = new System.Drawing.Size(759, 150);
            this.dgvEmanetler.TabIndex = 2;
            // 
            // btnEmanet
            // 
            this.btnEmanet.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEmanet.Location = new System.Drawing.Point(649, 28);
            this.btnEmanet.Name = "btnEmanet";
            this.btnEmanet.Size = new System.Drawing.Size(113, 48);
            this.btnEmanet.TabIndex = 3;
            this.btnEmanet.Text = "Düzenle";
            this.btnEmanet.UseVisualStyleBackColor = false;
            this.btnEmanet.Click += new System.EventHandler(this.btnEmanet_Click);
            // 
            // txtEkBilgi
            // 
            this.txtEkBilgi.Location = new System.Drawing.Point(416, 29);
            this.txtEkBilgi.Name = "txtEkBilgi";
            this.txtEkBilgi.Size = new System.Drawing.Size(155, 22);
            this.txtEkBilgi.TabIndex = 5;
            // 
            // FrmEmanetDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEkBilgi);
            this.Controls.Add(this.btnEmanet);
            this.Controls.Add(this.dgvEmanetler);
            this.Controls.Add(this.lstKitaplar);
            this.Controls.Add(this.cmbUyeler);
            this.Name = "FrmEmanetDuzenle";
            this.Text = "FrmEmanetIslemleriDuzenle";
            this.Load += new System.EventHandler(this.FrmEmanetIslemleriDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmanetler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUyeler;
        private System.Windows.Forms.ListBox lstKitaplar;
        private System.Windows.Forms.DataGridView dgvEmanetler;
        private System.Windows.Forms.Button btnEmanet;
        private System.Windows.Forms.TextBox txtEkBilgi;
    }
}