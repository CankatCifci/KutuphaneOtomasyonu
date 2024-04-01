namespace WindowsFormsApp
{
    partial class FrmUyeEkle
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
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.UyeId = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UyeSil = new System.Windows.Forms.Button();
            this.UyeDuzenle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 42);
            this.button1.TabIndex = 0;
            this.button1.Text = "AnaSayfa";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(24, 225);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 46);
            this.button2.TabIndex = 1;
            this.button2.Text = "Üye Ekle";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(24, 73);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(163, 22);
            this.txtAd.TabIndex = 2;
            this.txtAd.Text = "Ad";
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(24, 117);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(163, 22);
            this.txtSoyad.TabIndex = 3;
            this.txtSoyad.Text = "Soyad";
            // 
            // UyeId
            // 
            this.UyeId.Location = new System.Drawing.Point(24, 160);
            this.UyeId.Name = "UyeId";
            this.UyeId.Size = new System.Drawing.Size(163, 22);
            this.UyeId.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(421, 198);
            this.dataGridView1.TabIndex = 5;
            // 
            // UyeSil
            // 
            this.UyeSil.BackColor = System.Drawing.SystemColors.Highlight;
            this.UyeSil.Location = new System.Drawing.Point(611, 289);
            this.UyeSil.Name = "UyeSil";
            this.UyeSil.Size = new System.Drawing.Size(122, 51);
            this.UyeSil.TabIndex = 6;
            this.UyeSil.Text = "Üyeyi Sil";
            this.UyeSil.UseVisualStyleBackColor = false;
            this.UyeSil.Click += new System.EventHandler(this.UyeSil_Click);
            // 
            // UyeDuzenle
            // 
            this.UyeDuzenle.BackColor = System.Drawing.SystemColors.Highlight;
            this.UyeDuzenle.Location = new System.Drawing.Point(470, 289);
            this.UyeDuzenle.Name = "UyeDuzenle";
            this.UyeDuzenle.Size = new System.Drawing.Size(122, 51);
            this.UyeDuzenle.TabIndex = 7;
            this.UyeDuzenle.Text = "Üye Düzenle";
            this.UyeDuzenle.UseVisualStyleBackColor = false;
            this.UyeDuzenle.Click += new System.EventHandler(this.UyeDuzenle_Click);
            // 
            // FrmUyeEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UyeDuzenle);
            this.Controls.Add(this.UyeSil);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.UyeId);
            this.Controls.Add(this.txtSoyad);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FrmUyeEkle";
            this.Text = "Uye Ekle";
            this.Load += new System.EventHandler(this.FrmUyeEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox UyeId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button UyeSil;
        private System.Windows.Forms.Button UyeDuzenle;
    }
}