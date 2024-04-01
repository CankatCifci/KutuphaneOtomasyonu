namespace WindowsFormsApp2
{
    partial class FrmKitapDuzenle
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.txtYeniKitapAdi = new System.Windows.Forms.TextBox();
            this.txtYeniYazar = new System.Windows.Forms.TextBox();
            this.txtKitapId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnKaydet.Location = new System.Drawing.Point(208, 260);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(103, 50);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnIptal.Location = new System.Drawing.Point(401, 260);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(103, 50);
            this.btnIptal.TabIndex = 1;
            this.btnIptal.Text = "iptal";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // txtYeniKitapAdi
            // 
            this.txtYeniKitapAdi.Location = new System.Drawing.Point(286, 47);
            this.txtYeniKitapAdi.Name = "txtYeniKitapAdi";
            this.txtYeniKitapAdi.Size = new System.Drawing.Size(139, 22);
            this.txtYeniKitapAdi.TabIndex = 2;
            // 
            // txtYeniYazar
            // 
            this.txtYeniYazar.Location = new System.Drawing.Point(286, 110);
            this.txtYeniYazar.Name = "txtYeniYazar";
            this.txtYeniYazar.Size = new System.Drawing.Size(139, 22);
            this.txtYeniYazar.TabIndex = 3;
            // 
            // txtKitapId
            // 
            this.txtKitapId.Location = new System.Drawing.Point(286, 168);
            this.txtKitapId.Name = "txtKitapId";
            this.txtKitapId.Size = new System.Drawing.Size(139, 22);
            this.txtKitapId.TabIndex = 4;
            // 
            // FrmKitapDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtKitapId);
            this.Controls.Add(this.txtYeniYazar);
            this.Controls.Add(this.txtYeniKitapAdi);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Name = "FrmKitapDuzenle";
            this.Text = "FrmKitapDuzenle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.TextBox txtYeniKitapAdi;
        private System.Windows.Forms.TextBox txtYeniYazar;
        private System.Windows.Forms.TextBox txtKitapId;
    }
}