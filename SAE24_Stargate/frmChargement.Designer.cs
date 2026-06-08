namespace SAE24_Stargate
{
    partial class frmChargement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargement));
            this.lblChargement = new System.Windows.Forms.Label();
            this.pgbChargement = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblChargement
            // 
            this.lblChargement.Font = new System.Drawing.Font("Agency FB", 25.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChargement.ForeColor = System.Drawing.Color.Gold;
            this.lblChargement.Location = new System.Drawing.Point(12, 103);
            this.lblChargement.Name = "lblChargement";
            this.lblChargement.Size = new System.Drawing.Size(776, 55);
            this.lblChargement.TabIndex = 0;
            this.lblChargement.Text = "Chargement";
            this.lblChargement.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pgbChargement
            // 
            this.pgbChargement.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pgbChargement.Location = new System.Drawing.Point(54, 254);
            this.pgbChargement.Name = "pgbChargement";
            this.pgbChargement.Size = new System.Drawing.Size(700, 60);
            this.pgbChargement.TabIndex = 2;
            // 
            // frmChargement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pgbChargement);
            this.Controls.Add(this.lblChargement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChargement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chargement des donnÃ©es";
            this.Load += new System.EventHandler(this.frmChargement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblChargement;
        private System.Windows.Forms.ProgressBar pgbChargement;
    }
}