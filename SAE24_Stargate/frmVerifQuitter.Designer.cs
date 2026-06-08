namespace SAE24_Stargate
{
    partial class frmVerifQuitter
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
            this.lblAttention = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPasQuitter = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAttention
            // 
            this.lblAttention.Font = new System.Drawing.Font("Agency FB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttention.ForeColor = System.Drawing.Color.Gold;
            this.lblAttention.Location = new System.Drawing.Point(12, 53);
            this.lblAttention.Name = "lblAttention";
            this.lblAttention.Size = new System.Drawing.Size(776, 100);
            this.lblAttention.TabIndex = 1;
            this.lblAttention.Text = "Attention !";
            this.lblAttention.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Khaki;
            this.label2.Location = new System.Drawing.Point(7, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(787, 124);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vous êtes sur le point de quitter la création de la mission, toutes les donnés dé" +
    "jà enregistrés seront perdus. Souhaitez-vous poursuivre ?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPasQuitter
            // 
            this.btnPasQuitter.AutoSize = true;
            this.btnPasQuitter.BackColor = System.Drawing.Color.Gold;
            this.btnPasQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPasQuitter.Font = new System.Drawing.Font("Agency FB", 14.2F);
            this.btnPasQuitter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPasQuitter.Location = new System.Drawing.Point(24, 334);
            this.btnPasQuitter.Name = "btnPasQuitter";
            this.btnPasQuitter.Size = new System.Drawing.Size(292, 68);
            this.btnPasQuitter.TabIndex = 18;
            this.btnPasQuitter.Tag = "true";
            this.btnPasQuitter.Text = "Non, je souhaite rester sur la page";
            this.btnPasQuitter.UseVisualStyleBackColor = false;
            this.btnPasQuitter.Click += new System.EventHandler(this.btnPasQuitter_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.AutoSize = true;
            this.btnQuitter.BackColor = System.Drawing.Color.Gold;
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.Font = new System.Drawing.Font("Agency FB", 14.2F);
            this.btnQuitter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuitter.Location = new System.Drawing.Point(475, 334);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(300, 68);
            this.btnQuitter.TabIndex = 19;
            this.btnQuitter.Tag = "true";
            this.btnQuitter.Text = "Oui, je souhaite quitter la page";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // frmVerifQuitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnPasQuitter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAttention);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerifQuitter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmVerifQuitter";
            this.Load += new System.EventHandler(this.frmVerifQuitter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttention;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPasQuitter;
        private System.Windows.Forms.Button btnQuitter;
    }
}