namespace WindowsFormsApp2
{
    partial class FrmEmanetIslemleri
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
            this.button1 = new System.Windows.Forms.Button();
            this.cmbUyeler = new System.Windows.Forms.ComboBox();
            this.lstKitaplar = new System.Windows.Forms.ListBox();
            this.btnEmanet = new System.Windows.Forms.Button();
            this.btnIade = new System.Windows.Forms.Button();
            this.txtEkBilgi = new System.Windows.Forms.TextBox();
            this.dgvEmanetler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmanetler)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ana sayfa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbUyeler
            // 
            this.cmbUyeler.FormattingEnabled = true;
            this.cmbUyeler.Location = new System.Drawing.Point(100, 41);
            this.cmbUyeler.Name = "cmbUyeler";
            this.cmbUyeler.Size = new System.Drawing.Size(131, 24);
            this.cmbUyeler.TabIndex = 1;
            // 
            // lstKitaplar
            // 
            this.lstKitaplar.FormattingEnabled = true;
            this.lstKitaplar.ItemHeight = 16;
            this.lstKitaplar.Location = new System.Drawing.Point(240, 41);
            this.lstKitaplar.Name = "lstKitaplar";
            this.lstKitaplar.Size = new System.Drawing.Size(120, 116);
            this.lstKitaplar.TabIndex = 2;
            this.lstKitaplar.SelectedIndexChanged += new System.EventHandler(this.lstKitaplar_SelectedIndexChanged);
            // 
            // btnEmanet
            // 
            this.btnEmanet.Location = new System.Drawing.Point(670, 41);
            this.btnEmanet.Name = "btnEmanet";
            this.btnEmanet.Size = new System.Drawing.Size(80, 40);
            this.btnEmanet.TabIndex = 3;
            this.btnEmanet.Text = "Emanet et";
            this.btnEmanet.UseVisualStyleBackColor = true;
            this.btnEmanet.Click += new System.EventHandler(this.btnEmanet_Click_1);
            // 
            // btnIade
            // 
            this.btnIade.Location = new System.Drawing.Point(670, 102);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(80, 40);
            this.btnIade.TabIndex = 4;
            this.btnIade.Text = "iade";
            this.btnIade.UseVisualStyleBackColor = true;
            this.btnIade.Click += new System.EventHandler(this.btnIade_Click_1);
            // 
            // txtEkBilgi
            // 
            this.txtEkBilgi.Location = new System.Drawing.Point(383, 41);
            this.txtEkBilgi.Name = "txtEkBilgi";
            this.txtEkBilgi.Size = new System.Drawing.Size(140, 22);
            this.txtEkBilgi.TabIndex = 6;
            // 
            // dgvEmanetler
            // 
            this.dgvEmanetler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmanetler.Location = new System.Drawing.Point(29, 238);
            this.dgvEmanetler.Name = "dgvEmanetler";
            this.dgvEmanetler.RowHeadersWidth = 51;
            this.dgvEmanetler.RowTemplate.Height = 24;
            this.dgvEmanetler.Size = new System.Drawing.Size(734, 150);
            this.dgvEmanetler.TabIndex = 7;
            this.dgvEmanetler.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmanetler_CellContentClick);
            // 
            // FrmEmanetIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvEmanetler);
            this.Controls.Add(this.txtEkBilgi);
            this.Controls.Add(this.btnIade);
            this.Controls.Add(this.btnEmanet);
            this.Controls.Add(this.lstKitaplar);
            this.Controls.Add(this.cmbUyeler);
            this.Controls.Add(this.button1);
            this.Name = "FrmEmanetIslemleri";
            this.Text = "Emanet Islemleri";
            this.Load += new System.EventHandler(this.EmanetIslemleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmanetler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.ComboBox cmbUyeler;
        public System.Windows.Forms.ListBox lstKitaplar;
        public System.Windows.Forms.Button btnEmanet;
        public System.Windows.Forms.Button btnIade;
        public System.Windows.Forms.TextBox txtEkBilgi;
        private System.Windows.Forms.DataGridView dgvEmanetler;
    }
}