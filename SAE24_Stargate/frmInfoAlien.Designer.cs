namespace SAE24_Stargate
{
    partial class frmInfoAlien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoAlien));
            this.flpAlien = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.txtFiltresMissions = new System.Windows.Forms.TextBox();
            this.cboNom = new System.Windows.Forms.ComboBox();
            this.cboCouleur = new System.Windows.Forms.ComboBox();
            this.cboPlanete = new System.Windows.Forms.ComboBox();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.grpFiltresRaces = new System.Windows.Forms.GroupBox();
            this.pcbResetFiltres = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.grpFiltresRaces.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbResetFiltres)).BeginInit();
            this.SuspendLayout();
            // 
            // flpAlien
            // 
            this.flpAlien.AutoScroll = true;
            this.flpAlien.Location = new System.Drawing.Point(13, 115);
            this.flpAlien.Margin = new System.Windows.Forms.Padding(4);
            this.flpAlien.Name = "flpAlien";
            this.flpAlien.Size = new System.Drawing.Size(1646, 1023);
            this.flpAlien.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnAccueil);
            this.panel1.Controls.Add(this.pcbLogo);
            this.panel1.Controls.Add(this.txtFiltresMissions);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1894, 95);
            this.panel1.TabIndex = 5;
            // 
            // btnAccueil
            // 
            this.btnAccueil.BackColor = System.Drawing.Color.Black;
            this.btnAccueil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccueil.BackgroundImage")));
            this.btnAccueil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccueil.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.White;
            this.btnAccueil.Location = new System.Drawing.Point(1690, 3);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Size = new System.Drawing.Size(201, 89);
            this.btnAccueil.TabIndex = 18;
            this.btnAccueil.Text = "Revenir à la page d\'accueil";
            this.btnAccueil.UseVisualStyleBackColor = false;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // pcbLogo
            // 
            this.pcbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogo.Image")));
            this.pcbLogo.Location = new System.Drawing.Point(39, 2);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(90, 90);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 17;
            this.pcbLogo.TabStop = false;
            // 
            // txtFiltresMissions
            // 
            this.txtFiltresMissions.BackColor = System.Drawing.Color.Black;
            this.txtFiltresMissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltresMissions.Font = new System.Drawing.Font("Agency FB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltresMissions.ForeColor = System.Drawing.Color.White;
            this.txtFiltresMissions.Location = new System.Drawing.Point(451, 0);
            this.txtFiltresMissions.Name = "txtFiltresMissions";
            this.txtFiltresMissions.ReadOnly = true;
            this.txtFiltresMissions.Size = new System.Drawing.Size(1098, 96);
            this.txtFiltresMissions.TabIndex = 16;
            this.txtFiltresMissions.TabStop = false;
            this.txtFiltresMissions.Text = "Informations sur les races :";
            this.txtFiltresMissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboNom
            // 
            this.cboNom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNom.FormattingEnabled = true;
            this.cboNom.Location = new System.Drawing.Point(6, 91);
            this.cboNom.Name = "cboNom";
            this.cboNom.Size = new System.Drawing.Size(219, 36);
            this.cboNom.TabIndex = 6;
            this.cboNom.SelectedIndexChanged += new System.EventHandler(this.cboNom_SelectedIndexChanged);
            // 
            // cboCouleur
            // 
            this.cboCouleur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCouleur.FormattingEnabled = true;
            this.cboCouleur.Location = new System.Drawing.Point(6, 196);
            this.cboCouleur.Name = "cboCouleur";
            this.cboCouleur.Size = new System.Drawing.Size(219, 36);
            this.cboCouleur.TabIndex = 7;
            this.cboCouleur.SelectedIndexChanged += new System.EventHandler(this.cboCouleur_SelectedIndexChanged);
            // 
            // cboPlanete
            // 
            this.cboPlanete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPlanete.FormattingEnabled = true;
            this.cboPlanete.Location = new System.Drawing.Point(6, 305);
            this.cboPlanete.Name = "cboPlanete";
            this.cboPlanete.Size = new System.Drawing.Size(213, 36);
            this.cboPlanete.TabIndex = 8;
            this.cboPlanete.SelectedIndexChanged += new System.EventHandler(this.cboPlanete_SelectedIndexChanged);
            // 
            // cboCategorie
            // 
            this.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorie.FormattingEnabled = true;
            this.cboCategorie.Location = new System.Drawing.Point(6, 414);
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(213, 36);
            this.cboCategorie.TabIndex = 9;
            this.cboCategorie.SelectedIndexChanged += new System.EventHandler(this.cboCategorie_SelectedIndexChanged);
            // 
            // grpFiltresRaces
            // 
            this.grpFiltresRaces.Controls.Add(this.pcbResetFiltres);
            this.grpFiltresRaces.Controls.Add(this.label5);
            this.grpFiltresRaces.Controls.Add(this.label4);
            this.grpFiltresRaces.Controls.Add(this.label3);
            this.grpFiltresRaces.Controls.Add(this.label2);
            this.grpFiltresRaces.Controls.Add(this.label1);
            this.grpFiltresRaces.Controls.Add(this.cboNom);
            this.grpFiltresRaces.Controls.Add(this.cboCouleur);
            this.grpFiltresRaces.Controls.Add(this.cboCategorie);
            this.grpFiltresRaces.Controls.Add(this.cboPlanete);
            this.grpFiltresRaces.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltresRaces.ForeColor = System.Drawing.Color.White;
            this.grpFiltresRaces.Location = new System.Drawing.Point(1666, 135);
            this.grpFiltresRaces.Name = "grpFiltresRaces";
            this.grpFiltresRaces.Size = new System.Drawing.Size(237, 614);
            this.grpFiltresRaces.TabIndex = 11;
            this.grpFiltresRaces.TabStop = false;
            this.grpFiltresRaces.Text = "Filtrer les races :";
            // 
            // pcbResetFiltres
            // 
            this.pcbResetFiltres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbResetFiltres.BackgroundImage")));
            this.pcbResetFiltres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbResetFiltres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbResetFiltres.Location = new System.Drawing.Point(62, 510);
            this.pcbResetFiltres.Name = "pcbResetFiltres";
            this.pcbResetFiltres.Size = new System.Drawing.Size(105, 86);
            this.pcbResetFiltres.TabIndex = 27;
            this.pcbResetFiltres.TabStop = false;
            this.pcbResetFiltres.Click += new System.EventHandler(this.pcbResetFiltres_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 474);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 33);
            this.label5.TabIndex = 15;
            this.label5.Text = "Réinitialiser les filtres :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 33);
            this.label4.TabIndex = 14;
            this.label4.Text = "Filtrer par aggresivité :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 33);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filtrer par planète :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 33);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filtrer par Couleur :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 33);
            this.label1.TabIndex = 11;
            this.label1.Text = "Filtrer par nom :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInfoAlien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.grpFiltresRaces);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpAlien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInfoAlien";
            this.Text = "frmInfoAlien";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInfoAlien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.grpFiltresRaces.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbResetFiltres)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpAlien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.TextBox txtFiltresMissions;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.ComboBox cboNom;
        private System.Windows.Forms.ComboBox cboCouleur;
        private System.Windows.Forms.ComboBox cboPlanete;
        private System.Windows.Forms.ComboBox cboCategorie;
        private System.Windows.Forms.GroupBox grpFiltresRaces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pcbResetFiltres;
    }
}