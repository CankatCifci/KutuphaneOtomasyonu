namespace WindowsFormsApp
{
    partial class FrmKitapEkle
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
            this.button2 = new System.Windows.Forms.Button();
            this.txtYazar = new System.Windows.Forms.TextBox();
            this.txtKitapAdi = new System.Windows.Forms.TextBox();
            this.txtKitapId = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnKitapSil = new System.Windows.Forms.Button();
            this.btnKitapDuzenle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(-1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ana Sayfa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(33, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "Kitap Ekle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtYazar
            // 
            this.txtYazar.Location = new System.Drawing.Point(33, 58);
            this.txtYazar.Name = "txtYazar";
            this.txtYazar.Size = new System.Drawing.Size(182, 22);
            this.txtYazar.TabIndex = 2;
            this.txtYazar.Text = "Yazar Adı";
            this.txtYazar.TextChanged += new System.EventHandler(this.txtYazar_TextChanged);
            // 
            // txtKitapAdi
            // 
            this.txtKitapAdi.Location = new System.Drawing.Point(33, 116);
            this.txtKitapAdi.Name = "txtKitapAdi";
            this.txtKitapAdi.Size = new System.Drawing.Size(182, 22);
            this.txtKitapAdi.TabIndex = 3;
            this.txtKitapAdi.Text = "KitapAdi";
            this.txtKitapAdi.TextChanged += new System.EventHandler(this.txtKitapAdi_TextChanged);
            // 
            // txtKitapId
            // 
            this.txtKitapId.Location = new System.Drawing.Point(33, 171);
            this.txtKitapId.Name = "txtKitapId";
            this.txtKitapId.Size = new System.Drawing.Size(182, 22);
            this.txtKitapId.TabIndex = 4;
            this.txtKitapId.TextChanged += new System.EventHandler(this.kitapId_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(275, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(479, 231);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // btnKitapSil
            // 
            this.btnKitapSil.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnKitapSil.Location = new System.Drawing.Point(608, 320);
            this.btnKitapSil.Name = "btnKitapSil";
            this.btnKitapSil.Size = new System.Drawing.Size(108, 42);
            this.btnKitapSil.TabIndex = 6;
            this.btnKitapSil.Text = "Kitap Sil";
            this.btnKitapSil.UseVisualStyleBackColor = false;
            this.btnKitapSil.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnKitapDuzenle
            // 
            this.btnKitapDuzenle.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnKitapDuzenle.Location = new System.Drawing.Point(404, 320);
            this.btnKitapDuzenle.Name = "btnKitapDuzenle";
            this.btnKitapDuzenle.Size = new System.Drawing.Size(108, 42);
            this.btnKitapDuzenle.TabIndex = 7;
            this.btnKitapDuzenle.Text = "Düzenle";
            this.btnKitapDuzenle.UseVisualStyleBackColor = false;
            this.btnKitapDuzenle.Click += new System.EventHandler(this.btnKitapDuzenle_Click);
            // 
            // FrmKitapEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKitapDuzenle);
            this.Controls.Add(this.btnKitapSil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtKitapId);
            this.Controls.Add(this.txtKitapAdi);
            this.Controls.Add(this.txtYazar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmKitapEkle";
            this.Text = "Kitap Ekle";
            this.Load += new System.EventHandler(this.FrmKitapEkle_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtYazar;
        private System.Windows.Forms.TextBox txtKitapAdi;
        private System.Windows.Forms.TextBox txtKitapId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnKitapSil;
        private System.Windows.Forms.Button btnKitapDuzenle;
    }
}
