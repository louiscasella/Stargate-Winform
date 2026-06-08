namespace ucAlien_formPlanete
{
    partial class ucAlienPlanete
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcbAlien = new System.Windows.Forms.PictureBox();
            this.lblNomAlien = new System.Windows.Forms.Label();
            this.lblEnnemiAllie = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAlien)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbAlien
            // 
            this.pcbAlien.Location = new System.Drawing.Point(16, 15);
            this.pcbAlien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pcbAlien.Name = "pcbAlien";
            this.pcbAlien.Size = new System.Drawing.Size(81, 69);
            this.pcbAlien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAlien.TabIndex = 0;
            this.pcbAlien.TabStop = false;
            // 
            // lblNomAlien
            // 
            this.lblNomAlien.AutoSize = true;
            this.lblNomAlien.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomAlien.ForeColor = System.Drawing.SystemColors.Control;
            this.lblNomAlien.Location = new System.Drawing.Point(127, 15);
            this.lblNomAlien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomAlien.Name = "lblNomAlien";
            this.lblNomAlien.Size = new System.Drawing.Size(63, 35);
            this.lblNomAlien.TabIndex = 1;
            this.lblNomAlien.Text = "label1";
            // 
            // lblEnnemiAllie
            // 
            this.lblEnnemiAllie.AutoSize = true;
            this.lblEnnemiAllie.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnnemiAllie.ForeColor = System.Drawing.SystemColors.Control;
            this.lblEnnemiAllie.Location = new System.Drawing.Point(127, 50);
            this.lblEnnemiAllie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEnnemiAllie.Name = "lblEnnemiAllie";
            this.lblEnnemiAllie.Size = new System.Drawing.Size(70, 35);
            this.lblEnnemiAllie.TabIndex = 2;
            this.lblEnnemiAllie.Text = "label2";
            // 
            // ucAlienPlanete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.lblEnnemiAllie);
            this.Controls.Add(this.lblNomAlien);
            this.Controls.Add(this.pcbAlien);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ucAlienPlanete";
            this.Size = new System.Drawing.Size(427, 98);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAlien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbAlien;
        private System.Windows.Forms.Label lblNomAlien;
        private System.Windows.Forms.Label lblEnnemiAllie;
    }
}
