using SAE24_Stargate.Properties;
using System.Resources;

namespace SAE24_Stargate
{
    partial class frmStargate
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStargate));
            this.btnTDB = new System.Windows.Forms.PictureBox();
            this.btnIP = new System.Windows.Forms.PictureBox();
            this.btnDR = new System.Windows.Forms.PictureBox();
            this.btnNM = new System.Windows.Forms.PictureBox();
            this.btnStat = new System.Windows.Forms.PictureBox();
            this.lblNM = new System.Windows.Forms.Label();
            this.lblDR = new System.Windows.Forms.Label();
            this.lblTDB = new System.Windows.Forms.Label();
            this.lblStat = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.btnQuitter = new System.Windows.Forms.PictureBox();
            this.btnContact = new System.Windows.Forms.PictureBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblQuitter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnTDB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnContact)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTDB
            // 
            this.btnTDB.BackColor = System.Drawing.Color.Transparent;
            this.btnTDB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTDB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTDB.Location = new System.Drawing.Point(687, 147);
            this.btnTDB.Name = "btnTDB";
            this.btnTDB.Size = new System.Drawing.Size(289, 191);
            this.btnTDB.TabIndex = 0;
            this.btnTDB.TabStop = false;
            this.btnTDB.Click += new System.EventHandler(this.btnTB_Click);
            this.btnTDB.MouseEnter += new System.EventHandler(this.btnTDB_MouseEnter);
            this.btnTDB.MouseLeave += new System.EventHandler(this.btnTDB_MouseLeave);
            // 
            // btnIP
            // 
            this.btnIP.BackColor = System.Drawing.Color.Transparent;
            this.btnIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIP.Location = new System.Drawing.Point(1284, 506);
            this.btnIP.Name = "btnIP";
            this.btnIP.Size = new System.Drawing.Size(250, 250);
            this.btnIP.TabIndex = 1;
            this.btnIP.TabStop = false;
            this.btnIP.Click += new System.EventHandler(this.btnIP_Click);
            this.btnIP.MouseEnter += new System.EventHandler(this.btnIP_MouseEnter);
            this.btnIP.MouseLeave += new System.EventHandler(this.btnIP_MouseLeave);
            // 
            // btnDR
            // 
            this.btnDR.BackColor = System.Drawing.Color.Transparent;
            this.btnDR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDR.Location = new System.Drawing.Point(1158, 133);
            this.btnDR.Name = "btnDR";
            this.btnDR.Size = new System.Drawing.Size(230, 230);
            this.btnDR.TabIndex = 2;
            this.btnDR.TabStop = false;
            this.btnDR.Click += new System.EventHandler(this.btnDR_Click);
            this.btnDR.MouseEnter += new System.EventHandler(this.btnDR_MouseEnter);
            this.btnDR.MouseLeave += new System.EventHandler(this.btnDR_MouseLeave);
            // 
            // btnNM
            // 
            this.btnNM.BackColor = System.Drawing.Color.Transparent;
            this.btnNM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNM.Location = new System.Drawing.Point(808, 828);
            this.btnNM.Name = "btnNM";
            this.btnNM.Size = new System.Drawing.Size(299, 263);
            this.btnNM.TabIndex = 3;
            this.btnNM.TabStop = false;
            this.btnNM.Click += new System.EventHandler(this.btnNM_Click);
            this.btnNM.MouseEnter += new System.EventHandler(this.btnNM_MouseEnter);
            this.btnNM.MouseLeave += new System.EventHandler(this.btnNM_MouseLeave);
            // 
            // btnStat
            // 
            this.btnStat.BackColor = System.Drawing.Color.Transparent;
            this.btnStat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStat.Location = new System.Drawing.Point(517, 506);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(250, 250);
            this.btnStat.TabIndex = 4;
            this.btnStat.TabStop = false;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            this.btnStat.MouseEnter += new System.EventHandler(this.btnStat_MouseEnter);
            this.btnStat.MouseLeave += new System.EventHandler(this.btnStat_MouseLeave);
            // 
            // lblNM
            // 
            this.lblNM.AutoSize = true;
            this.lblNM.BackColor = System.Drawing.Color.Transparent;
            this.lblNM.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNM.ForeColor = System.Drawing.Color.White;
            this.lblNM.Location = new System.Drawing.Point(840, 752);
            this.lblNM.Name = "lblNM";
            this.lblNM.Size = new System.Drawing.Size(95, 50);
            this.lblNM.TabIndex = 5;
            this.lblNM.Text = "label1";
            this.lblNM.Visible = false;
            // 
            // lblDR
            // 
            this.lblDR.AutoSize = true;
            this.lblDR.BackColor = System.Drawing.Color.Transparent;
            this.lblDR.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDR.ForeColor = System.Drawing.Color.White;
            this.lblDR.Location = new System.Drawing.Point(1159, 68);
            this.lblDR.Name = "lblDR";
            this.lblDR.Size = new System.Drawing.Size(95, 50);
            this.lblDR.TabIndex = 6;
            this.lblDR.Text = "label1";
            this.lblDR.Visible = false;
            // 
            // lblTDB
            // 
            this.lblTDB.AutoSize = true;
            this.lblTDB.BackColor = System.Drawing.Color.Transparent;
            this.lblTDB.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTDB.ForeColor = System.Drawing.Color.White;
            this.lblTDB.Location = new System.Drawing.Point(710, 68);
            this.lblTDB.Name = "lblTDB";
            this.lblTDB.Size = new System.Drawing.Size(95, 50);
            this.lblTDB.TabIndex = 7;
            this.lblTDB.Text = "label1";
            this.lblTDB.Visible = false;
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.BackColor = System.Drawing.Color.Transparent;
            this.lblStat.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStat.ForeColor = System.Drawing.Color.White;
            this.lblStat.Location = new System.Drawing.Point(543, 428);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(95, 50);
            this.lblStat.TabIndex = 8;
            this.lblStat.Text = "label1";
            this.lblStat.Visible = false;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.BackColor = System.Drawing.Color.Transparent;
            this.lblIP.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.Color.White;
            this.lblIP.Location = new System.Drawing.Point(1312, 428);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(95, 50);
            this.lblIP.TabIndex = 9;
            this.lblIP.Text = "label1";
            this.lblIP.Visible = false;
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitter.Location = new System.Drawing.Point(910, 480);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(160, 160);
            this.btnQuitter.TabIndex = 10;
            this.btnQuitter.TabStop = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            this.btnQuitter.MouseEnter += new System.EventHandler(this.btnQuitter_MouseEnter);
            this.btnQuitter.MouseLeave += new System.EventHandler(this.btnQuitter_MouseLeave);
            // 
            // btnContact
            // 
            this.btnContact.BackColor = System.Drawing.Color.Transparent;
            this.btnContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContact.Image = ((System.Drawing.Image)(resources.GetObject("btnContact.Image")));
            this.btnContact.Location = new System.Drawing.Point(23, 998);
            this.btnContact.Name = "btnContact";
            this.btnContact.Size = new System.Drawing.Size(150, 150);
            this.btnContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnContact.TabIndex = 11;
            this.btnContact.TabStop = false;
            this.btnContact.Click += new System.EventHandler(this.pcblogo_Click);
            this.btnContact.MouseEnter += new System.EventHandler(this.btnContact_MouseEnter);
            this.btnContact.MouseLeave += new System.EventHandler(this.btnContact_MouseLeave);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.ForeColor = System.Drawing.Color.White;
            this.lblContact.Location = new System.Drawing.Point(47, 924);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(126, 50);
            this.lblContact.TabIndex = 12;
            this.lblContact.Text = "Contact";
            this.lblContact.Visible = false;
            // 
            // lblQuitter
            // 
            this.lblQuitter.AutoSize = true;
            this.lblQuitter.BackColor = System.Drawing.Color.Transparent;
            this.lblQuitter.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuitter.ForeColor = System.Drawing.Color.White;
            this.lblQuitter.Location = new System.Drawing.Point(939, 403);
            this.lblQuitter.Name = "lblQuitter";
            this.lblQuitter.Size = new System.Drawing.Size(95, 50);
            this.lblQuitter.TabIndex = 13;
            this.lblQuitter.Text = "label1";
            this.lblQuitter.Visible = false;
            // 
            // frmStargate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1103);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.lblQuitter);
            this.Controls.Add(this.btnContact);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.btnIP);
            this.Controls.Add(this.btnDR);
            this.Controls.Add(this.btnTDB);
            this.Controls.Add(this.btnStat);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.lblTDB);
            this.Controls.Add(this.lblDR);
            this.Controls.Add(this.btnNM);
            this.Controls.Add(this.lblNM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStargate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accueil";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStargate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnTDB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnTDB;
        private System.Windows.Forms.PictureBox btnIP;
        private System.Windows.Forms.PictureBox btnDR;
        private System.Windows.Forms.PictureBox btnNM;
        private System.Windows.Forms.PictureBox btnStat;
        private System.Windows.Forms.Label lblNM;
        private System.Windows.Forms.Label lblDR;
        private System.Windows.Forms.Label lblTDB;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.PictureBox btnQuitter;
        private System.Windows.Forms.PictureBox btnContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblQuitter;
    }
}

