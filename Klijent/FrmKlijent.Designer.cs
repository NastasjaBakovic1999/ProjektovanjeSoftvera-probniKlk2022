namespace Klijent
{
    partial class FrmKlijent
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
            this.rtbPoruka = new System.Windows.Forms.RichTextBox();
            this.btnPosaljiSvima = new System.Windows.Forms.Button();
            this.dgvPrijavljeniKorisnici = new System.Windows.Forms.DataGridView();
            this.btnPosaljiJednom = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvOstalePoruke = new System.Windows.Forms.DataGridView();
            this.dgvPoslednje3Poruke = new System.Windows.Forms.DataGridView();
            this.dgvPorukeKorisnika = new System.Windows.Forms.DataGridView();
            this.btnPrikaziPoruke = new System.Windows.Forms.Button();
            this.lblPorukeKorisnika = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrijavljeniKorisnici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOstalePoruke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslednje3Poruke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorukeKorisnika)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbPoruka
            // 
            this.rtbPoruka.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rtbPoruka.Location = new System.Drawing.Point(14, 11);
            this.rtbPoruka.MaxLength = 200;
            this.rtbPoruka.Name = "rtbPoruka";
            this.rtbPoruka.Size = new System.Drawing.Size(573, 52);
            this.rtbPoruka.TabIndex = 0;
            this.rtbPoruka.Text = "";
            // 
            // btnPosaljiSvima
            // 
            this.btnPosaljiSvima.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosaljiSvima.Location = new System.Drawing.Point(14, 66);
            this.btnPosaljiSvima.Name = "btnPosaljiSvima";
            this.btnPosaljiSvima.Size = new System.Drawing.Size(214, 31);
            this.btnPosaljiSvima.TabIndex = 1;
            this.btnPosaljiSvima.Text = "Posalji svima";
            this.btnPosaljiSvima.UseVisualStyleBackColor = true;
            this.btnPosaljiSvima.Click += new System.EventHandler(this.btnPosaljiSvima_Click);
            // 
            // dgvPrijavljeniKorisnici
            // 
            this.dgvPrijavljeniKorisnici.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPrijavljeniKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrijavljeniKorisnici.Location = new System.Drawing.Point(14, 131);
            this.dgvPrijavljeniKorisnici.Name = "dgvPrijavljeniKorisnici";
            this.dgvPrijavljeniKorisnici.RowHeadersWidth = 51;
            this.dgvPrijavljeniKorisnici.RowTemplate.Height = 24;
            this.dgvPrijavljeniKorisnici.Size = new System.Drawing.Size(573, 167);
            this.dgvPrijavljeniKorisnici.TabIndex = 2;
            // 
            // btnPosaljiJednom
            // 
            this.btnPosaljiJednom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPosaljiJednom.Location = new System.Drawing.Point(373, 69);
            this.btnPosaljiJednom.Name = "btnPosaljiJednom";
            this.btnPosaljiJednom.Size = new System.Drawing.Size(214, 31);
            this.btnPosaljiJednom.TabIndex = 3;
            this.btnPosaljiJednom.Text = "Posalji odabranom korisniku";
            this.btnPosaljiJednom.UseVisualStyleBackColor = true;
            this.btnPosaljiJednom.Click += new System.EventHandler(this.btnPosaljiJednom_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(597, -96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primljene poruke";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "poslednje 3:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "ostale:";
            // 
            // dgvOstalePoruke
            // 
            this.dgvOstalePoruke.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvOstalePoruke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOstalePoruke.Location = new System.Drawing.Point(610, 214);
            this.dgvOstalePoruke.Name = "dgvOstalePoruke";
            this.dgvOstalePoruke.RowHeadersWidth = 51;
            this.dgvOstalePoruke.RowTemplate.Height = 24;
            this.dgvOstalePoruke.Size = new System.Drawing.Size(573, 335);
            this.dgvOstalePoruke.TabIndex = 7;
            // 
            // dgvPoslednje3Poruke
            // 
            this.dgvPoslednje3Poruke.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPoslednje3Poruke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoslednje3Poruke.Location = new System.Drawing.Point(610, 66);
            this.dgvPoslednje3Poruke.Name = "dgvPoslednje3Poruke";
            this.dgvPoslednje3Poruke.RowHeadersWidth = 51;
            this.dgvPoslednje3Poruke.RowTemplate.Height = 24;
            this.dgvPoslednje3Poruke.Size = new System.Drawing.Size(573, 105);
            this.dgvPoslednje3Poruke.TabIndex = 8;
            // 
            // dgvPorukeKorisnika
            // 
            this.dgvPorukeKorisnika.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPorukeKorisnika.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPorukeKorisnika.Location = new System.Drawing.Point(14, 367);
            this.dgvPorukeKorisnika.Name = "dgvPorukeKorisnika";
            this.dgvPorukeKorisnika.RowHeadersWidth = 51;
            this.dgvPorukeKorisnika.RowTemplate.Height = 24;
            this.dgvPorukeKorisnika.Size = new System.Drawing.Size(573, 182);
            this.dgvPorukeKorisnika.TabIndex = 9;
            // 
            // btnPrikaziPoruke
            // 
            this.btnPrikaziPoruke.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrikaziPoruke.Location = new System.Drawing.Point(14, 304);
            this.btnPrikaziPoruke.Name = "btnPrikaziPoruke";
            this.btnPrikaziPoruke.Size = new System.Drawing.Size(573, 30);
            this.btnPrikaziPoruke.TabIndex = 10;
            this.btnPrikaziPoruke.Text = "Prikazi poruke od korisnika";
            this.btnPrikaziPoruke.UseVisualStyleBackColor = true;
            this.btnPrikaziPoruke.Click += new System.EventHandler(this.btnPrikaziPoruke_Click);
            // 
            // lblPorukeKorisnika
            // 
            this.lblPorukeKorisnika.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPorukeKorisnika.AutoSize = true;
            this.lblPorukeKorisnika.Location = new System.Drawing.Point(14, 337);
            this.lblPorukeKorisnika.Name = "lblPorukeKorisnika";
            this.lblPorukeKorisnika.Size = new System.Drawing.Size(180, 16);
            this.lblPorukeKorisnika.TabIndex = 11;
            this.lblPorukeKorisnika.Text = "Poruke odabranog korisnika:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(607, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sve poruke:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Prijavljeni korisnici:";
            // 
            // FrmKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 557);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPorukeKorisnika);
            this.Controls.Add(this.btnPrikaziPoruke);
            this.Controls.Add(this.dgvPorukeKorisnika);
            this.Controls.Add(this.dgvPoslednje3Poruke);
            this.Controls.Add(this.dgvOstalePoruke);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPosaljiJednom);
            this.Controls.Add(this.dgvPrijavljeniKorisnici);
            this.Controls.Add(this.btnPosaljiSvima);
            this.Controls.Add(this.rtbPoruka);
            this.Name = "FrmKlijent";
            this.Text = "Klijent";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrijavljeniKorisnici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOstalePoruke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslednje3Poruke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorukeKorisnika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbPoruka;
        private System.Windows.Forms.Button btnPosaljiSvima;
        private System.Windows.Forms.DataGridView dgvPrijavljeniKorisnici;
        private System.Windows.Forms.Button btnPosaljiJednom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvOstalePoruke;
        private System.Windows.Forms.DataGridView dgvPoslednje3Poruke;
        private System.Windows.Forms.DataGridView dgvPorukeKorisnika;
        private System.Windows.Forms.Button btnPrikaziPoruke;
        private System.Windows.Forms.Label lblPorukeKorisnika;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

