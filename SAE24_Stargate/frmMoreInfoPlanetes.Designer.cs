namespace SAE24_Stargate
{
    partial class frmMoreInfoPlanetes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoreInfoPlanetes));
            this.pnlInfoPla = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAlienPresence = new System.Windows.Forms.Panel();
            this.pnlMissions = new System.Windows.Forms.Panel();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnlInfoPla
            // 
            this.pnlInfoPla.Location = new System.Drawing.Point(72, 46);
            this.pnlInfoPla.Margin = new System.Windows.Forms.Padding(4);
            this.pnlInfoPla.Name = "pnlInfoPla";
            this.pnlInfoPla.Size = new System.Drawing.Size(395, 661);
            this.pnlInfoPla.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(523, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 44);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alien présents :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(525, 373);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 44);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mission effectuées :";
            // 
            // pnlAlienPresence
            // 
            this.pnlAlienPresence.AutoScroll = true;
            this.pnlAlienPresence.Location = new System.Drawing.Point(532, 86);
            this.pnlAlienPresence.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAlienPresence.Name = "pnlAlienPresence";
            this.pnlAlienPresence.Size = new System.Drawing.Size(651, 271);
            this.pnlAlienPresence.TabIndex = 4;
            // 
            // pnlMissions
            // 
            this.pnlMissions.AutoScroll = true;
            this.pnlMissions.Location = new System.Drawing.Point(529, 433);
            this.pnlMissions.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMissions.Name = "pnlMissions";
            this.pnlMissions.Size = new System.Drawing.Size(715, 222);
            this.pnlMissions.TabIndex = 5;
            // 
            // btnAccueil
            // 
            this.btnAccueil.BackColor = System.Drawing.Color.Black;
            this.btnAccueil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccueil.BackgroundImage")));
            this.btnAccueil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccueil.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.White;
            this.btnAccueil.Location = new System.Drawing.Point(1199, 12);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Size = new System.Drawing.Size(142, 83);
            this.btnAccueil.TabIndex = 19;
            this.btnAccueil.Text = "Fermer cet onglet";
            this.btnAccueil.UseVisualStyleBackColor = false;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // frmMoreInfoPlanetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1353, 736);
            this.Controls.Add(this.btnAccueil);
            this.Controls.Add(this.pnlMissions);
            this.Controls.Add(this.pnlAlienPresence);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlInfoPla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMoreInfoPlanetes";
            this.Text = "Plus d\'infos sur la planète";
            this.Load += new System.EventHandler(this.frmMoreInfoPlanetes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlInfoPla;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlAlienPresence;
        private System.Windows.Forms.Panel pnlMissions;
        private System.Windows.Forms.Button btnAccueil;
    }
}