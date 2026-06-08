using System.Drawing;

namespace SAE24_Stargate
{
    partial class frmTableauDeBord
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTableauDeBord));
            this.pcbFlecheDroite = new System.Windows.Forms.PictureBox();
            this.pcbFlecheGauche = new System.Windows.Forms.PictureBox();
            this.ucRecapMissionEntierFinal = new SAE24_Stargate.ucRecapMissionEntier();
            this.pnlConteneurMission = new System.Windows.Forms.Panel();
            this.txtAucunMissionCorrespond = new System.Windows.Forms.TextBox();
            this.pcbFullGauche = new System.Windows.Forms.PictureBox();
            this.pcbFullDroite = new System.Windows.Forms.PictureBox();
            this.pnlFiltresMissions = new System.Windows.Forms.Panel();
            this.grpFondEcran = new System.Windows.Forms.GroupBox();
            this.txtCodeRGB = new System.Windows.Forms.TextBox();
            this.pnlCouleurChoisie = new System.Windows.Forms.Panel();
            this.txtChoixCouleur = new System.Windows.Forms.TextBox();
            this.cboChoixCouleur = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtFondColore = new System.Windows.Forms.TextBox();
            this.cboFondPasColore = new System.Windows.Forms.CheckBox();
            this.cboFondColore = new System.Windows.Forms.CheckBox();
            this.pcbResetFiltres = new System.Windows.Forms.PictureBox();
            this.grpFiltreChefPlanete = new System.Windows.Forms.GroupBox();
            this.txtFiltreChef = new System.Windows.Forms.TextBox();
            this.txtFiltrePlanete = new System.Windows.Forms.TextBox();
            this.cboFiltreChef = new System.Windows.Forms.ComboBox();
            this.cboFiltrePlanete = new System.Windows.Forms.ComboBox();
            this.grpFiltreBudget = new System.Windows.Forms.GroupBox();
            this.txtFiltreBudgetMaximum = new System.Windows.Forms.TextBox();
            this.txtFiltreBudgetMinimum = new System.Windows.Forms.TextBox();
            this.hsbFiltreBudgetMaximum = new System.Windows.Forms.HScrollBar();
            this.pcbAppliquerFiltres = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.hsbFiltreBudgetMinimum = new System.Windows.Forms.HScrollBar();
            this.txtResetFiltre = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtBudgetPreMission = new System.Windows.Forms.TextBox();
            this.cboMissionPasse = new System.Windows.Forms.CheckBox();
            this.txtFiltresMissions = new System.Windows.Forms.TextBox();
            this.cboMissionPresent = new System.Windows.Forms.CheckBox();
            this.cboMissionFutur = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFlecheDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFlecheGauche)).BeginInit();
            this.pnlConteneurMission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFullGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFullDroite)).BeginInit();
            this.pnlFiltresMissions.SuspendLayout();
            this.grpFondEcran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbResetFiltres)).BeginInit();
            this.grpFiltreChefPlanete.SuspendLayout();
            this.grpFiltreBudget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAppliquerFiltres)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pcbFlecheDroite
            // 
            this.pcbFlecheDroite.BackColor = System.Drawing.Color.Black;
            this.pcbFlecheDroite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbFlecheDroite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbFlecheDroite.Location = new System.Drawing.Point(1798, 494);
            this.pcbFlecheDroite.Name = "pcbFlecheDroite";
            this.pcbFlecheDroite.Size = new System.Drawing.Size(80, 80);
            this.pcbFlecheDroite.TabIndex = 3;
            this.pcbFlecheDroite.TabStop = false;
            this.pcbFlecheDroite.Click += new System.EventHandler(this.pcbFlecheDroite_Click);
            // 
            // pcbFlecheGauche
            // 
            this.pcbFlecheGauche.BackColor = System.Drawing.Color.Black;
            this.pcbFlecheGauche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbFlecheGauche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbFlecheGauche.Location = new System.Drawing.Point(65, 494);
            this.pcbFlecheGauche.Name = "pcbFlecheGauche";
            this.pcbFlecheGauche.Size = new System.Drawing.Size(80, 80);
            this.pcbFlecheGauche.TabIndex = 2;
            this.pcbFlecheGauche.TabStop = false;
            this.pcbFlecheGauche.Click += new System.EventHandler(this.pcbFlecheGauche_Click);
            // 
            // ucRecapMissionEntierFinal
            // 
            this.ucRecapMissionEntierFinal.AutoScroll = true;
            this.ucRecapMissionEntierFinal.BackColor = System.Drawing.Color.Black;
            this.ucRecapMissionEntierFinal.Location = new System.Drawing.Point(30, 372);
            this.ucRecapMissionEntierFinal.Name = "ucRecapMissionEntierFinal";
            this.ucRecapMissionEntierFinal.OnDemandeEdition = null;
            this.ucRecapMissionEntierFinal.Size = new System.Drawing.Size(1848, 769);
            this.ucRecapMissionEntierFinal.TabIndex = 6;
            // 
            // pnlConteneurMission
            // 
            this.pnlConteneurMission.BackColor = System.Drawing.Color.Transparent;
            this.pnlConteneurMission.Controls.Add(this.txtAucunMissionCorrespond);
            this.pnlConteneurMission.Location = new System.Drawing.Point(151, 372);
            this.pnlConteneurMission.Name = "pnlConteneurMission";
            this.pnlConteneurMission.Size = new System.Drawing.Size(1625, 487);
            this.pnlConteneurMission.TabIndex = 10;
            // 
            // txtAucunMissionCorrespond
            // 
            this.txtAucunMissionCorrespond.BackColor = System.Drawing.Color.Black;
            this.txtAucunMissionCorrespond.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAucunMissionCorrespond.Font = new System.Drawing.Font("Agency FB", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAucunMissionCorrespond.ForeColor = System.Drawing.Color.White;
            this.txtAucunMissionCorrespond.Location = new System.Drawing.Point(193, 76);
            this.txtAucunMissionCorrespond.Multiline = true;
            this.txtAucunMissionCorrespond.Name = "txtAucunMissionCorrespond";
            this.txtAucunMissionCorrespond.ReadOnly = true;
            this.txtAucunMissionCorrespond.Size = new System.Drawing.Size(1255, 290);
            this.txtAucunMissionCorrespond.TabIndex = 16;
            this.txtAucunMissionCorrespond.Text = "Aucune mission ne correspond à vos filtres";
            this.txtAucunMissionCorrespond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pcbFullGauche
            // 
            this.pcbFullGauche.BackColor = System.Drawing.Color.Black;
            this.pcbFullGauche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbFullGauche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbFullGauche.Location = new System.Drawing.Point(65, 580);
            this.pcbFullGauche.Name = "pcbFullGauche";
            this.pcbFullGauche.Size = new System.Drawing.Size(80, 80);
            this.pcbFullGauche.TabIndex = 11;
            this.pcbFullGauche.TabStop = false;
            this.pcbFullGauche.Click += new System.EventHandler(this.pcbFullGauche_Click);
            // 
            // pcbFullDroite
            // 
            this.pcbFullDroite.BackColor = System.Drawing.Color.Black;
            this.pcbFullDroite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pcbFullDroite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbFullDroite.Location = new System.Drawing.Point(1798, 580);
            this.pcbFullDroite.Name = "pcbFullDroite";
            this.pcbFullDroite.Size = new System.Drawing.Size(80, 80);
            this.pcbFullDroite.TabIndex = 12;
            this.pcbFullDroite.TabStop = false;
            this.pcbFullDroite.Click += new System.EventHandler(this.pcbFullDroite_Click);
            // 
            // pnlFiltresMissions
            // 
            this.pnlFiltresMissions.BackColor = System.Drawing.Color.Black;
            this.pnlFiltresMissions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFiltresMissions.Controls.Add(this.grpFondEcran);
            this.pnlFiltresMissions.Controls.Add(this.pcbResetFiltres);
            this.pnlFiltresMissions.Controls.Add(this.grpFiltreChefPlanete);
            this.pnlFiltresMissions.Controls.Add(this.grpFiltreBudget);
            this.pnlFiltresMissions.Controls.Add(this.txtResetFiltre);
            this.pnlFiltresMissions.Controls.Add(this.textBox3);
            this.pnlFiltresMissions.Controls.Add(this.textBox2);
            this.pnlFiltresMissions.Controls.Add(this.txtBudgetPreMission);
            this.pnlFiltresMissions.Controls.Add(this.cboMissionPasse);
            this.pnlFiltresMissions.Controls.Add(this.txtFiltresMissions);
            this.pnlFiltresMissions.Controls.Add(this.cboMissionPresent);
            this.pnlFiltresMissions.Controls.Add(this.cboMissionFutur);
            this.pnlFiltresMissions.Location = new System.Drawing.Point(30, 114);
            this.pnlFiltresMissions.Name = "pnlFiltresMissions";
            this.pnlFiltresMissions.Size = new System.Drawing.Size(1860, 235);
            this.pnlFiltresMissions.TabIndex = 13;
            // 
            // grpFondEcran
            // 
            this.grpFondEcran.BackColor = System.Drawing.Color.Black;
            this.grpFondEcran.Controls.Add(this.txtCodeRGB);
            this.grpFondEcran.Controls.Add(this.pnlCouleurChoisie);
            this.grpFondEcran.Controls.Add(this.txtChoixCouleur);
            this.grpFondEcran.Controls.Add(this.cboChoixCouleur);
            this.grpFondEcran.Controls.Add(this.textBox4);
            this.grpFondEcran.Controls.Add(this.txtFondColore);
            this.grpFondEcran.Controls.Add(this.cboFondPasColore);
            this.grpFondEcran.Controls.Add(this.cboFondColore);
            this.grpFondEcran.Font = new System.Drawing.Font("Agency FB", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFondEcran.ForeColor = System.Drawing.Color.White;
            this.grpFondEcran.Location = new System.Drawing.Point(1617, 11);
            this.grpFondEcran.Name = "grpFondEcran";
            this.grpFondEcran.Size = new System.Drawing.Size(229, 195);
            this.grpFondEcran.TabIndex = 22;
            this.grpFondEcran.TabStop = false;
            this.grpFondEcran.Text = "Modifier le fond :";
            // 
            // txtCodeRGB
            // 
            this.txtCodeRGB.BackColor = System.Drawing.Color.Black;
            this.txtCodeRGB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCodeRGB.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeRGB.ForeColor = System.Drawing.Color.White;
            this.txtCodeRGB.Location = new System.Drawing.Point(10, 160);
            this.txtCodeRGB.Name = "txtCodeRGB";
            this.txtCodeRGB.ReadOnly = true;
            this.txtCodeRGB.Size = new System.Drawing.Size(206, 24);
            this.txtCodeRGB.TabIndex = 33;
            this.txtCodeRGB.Text = "Code RGB :";
            this.txtCodeRGB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodeRGB.Visible = false;
            // 
            // pnlCouleurChoisie
            // 
            this.pnlCouleurChoisie.Location = new System.Drawing.Point(6, 126);
            this.pnlCouleurChoisie.Name = "pnlCouleurChoisie";
            this.pnlCouleurChoisie.Size = new System.Drawing.Size(210, 28);
            this.pnlCouleurChoisie.TabIndex = 32;
            // 
            // txtChoixCouleur
            // 
            this.txtChoixCouleur.BackColor = System.Drawing.Color.Black;
            this.txtChoixCouleur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChoixCouleur.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtChoixCouleur.ForeColor = System.Drawing.Color.White;
            this.txtChoixCouleur.Location = new System.Drawing.Point(6, 96);
            this.txtChoixCouleur.Name = "txtChoixCouleur";
            this.txtChoixCouleur.ReadOnly = true;
            this.txtChoixCouleur.Size = new System.Drawing.Size(167, 28);
            this.txtChoixCouleur.TabIndex = 31;
            this.txtChoixCouleur.Text = "Couleur personnalisée :";
            this.txtChoixCouleur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboChoixCouleur
            // 
            this.cboChoixCouleur.AutoSize = true;
            this.cboChoixCouleur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboChoixCouleur.Location = new System.Drawing.Point(179, 105);
            this.cboChoixCouleur.Name = "cboChoixCouleur";
            this.cboChoixCouleur.Size = new System.Drawing.Size(18, 17);
            this.cboChoixCouleur.TabIndex = 30;
            this.cboChoixCouleur.UseVisualStyleBackColor = true;
            this.cboChoixCouleur.Click += new System.EventHandler(this.cboChoixCouleur_Click);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Black;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Agency FB", 14F);
            this.textBox4.ForeColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(6, 62);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(167, 28);
            this.textBox4.TabIndex = 29;
            this.textBox4.Text = "Fond achromatique :";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFondColore
            // 
            this.txtFondColore.BackColor = System.Drawing.Color.Black;
            this.txtFondColore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFondColore.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtFondColore.ForeColor = System.Drawing.Color.White;
            this.txtFondColore.Location = new System.Drawing.Point(6, 28);
            this.txtFondColore.Name = "txtFondColore";
            this.txtFondColore.ReadOnly = true;
            this.txtFondColore.Size = new System.Drawing.Size(167, 28);
            this.txtFondColore.TabIndex = 27;
            this.txtFondColore.Text = "Fond coloré :";
            this.txtFondColore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboFondPasColore
            // 
            this.cboFondPasColore.AutoSize = true;
            this.cboFondPasColore.Checked = true;
            this.cboFondPasColore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboFondPasColore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboFondPasColore.Location = new System.Drawing.Point(179, 71);
            this.cboFondPasColore.Name = "cboFondPasColore";
            this.cboFondPasColore.Size = new System.Drawing.Size(18, 17);
            this.cboFondPasColore.TabIndex = 27;
            this.cboFondPasColore.UseVisualStyleBackColor = true;
            this.cboFondPasColore.CheckedChanged += new System.EventHandler(this.cboFondPasColore_CheckedChanged);
            // 
            // cboFondColore
            // 
            this.cboFondColore.AutoSize = true;
            this.cboFondColore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboFondColore.Location = new System.Drawing.Point(179, 39);
            this.cboFondColore.Name = "cboFondColore";
            this.cboFondColore.Size = new System.Drawing.Size(18, 17);
            this.cboFondColore.TabIndex = 28;
            this.cboFondColore.UseVisualStyleBackColor = true;
            this.cboFondColore.CheckedChanged += new System.EventHandler(this.cboFondColore_CheckedChanged);
            // 
            // pcbResetFiltres
            // 
            this.pcbResetFiltres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbResetFiltres.BackgroundImage")));
            this.pcbResetFiltres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbResetFiltres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbResetFiltres.Location = new System.Drawing.Point(131, 120);
            this.pcbResetFiltres.Name = "pcbResetFiltres";
            this.pcbResetFiltres.Size = new System.Drawing.Size(105, 86);
            this.pcbResetFiltres.TabIndex = 26;
            this.pcbResetFiltres.TabStop = false;
            this.pcbResetFiltres.Click += new System.EventHandler(this.pcbResetFiltres_Click);
            // 
            // grpFiltreChefPlanete
            // 
            this.grpFiltreChefPlanete.Controls.Add(this.txtFiltreChef);
            this.grpFiltreChefPlanete.Controls.Add(this.txtFiltrePlanete);
            this.grpFiltreChefPlanete.Controls.Add(this.cboFiltreChef);
            this.grpFiltreChefPlanete.Controls.Add(this.cboFiltrePlanete);
            this.grpFiltreChefPlanete.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltreChefPlanete.ForeColor = System.Drawing.Color.White;
            this.grpFiltreChefPlanete.Location = new System.Drawing.Point(608, 18);
            this.grpFiltreChefPlanete.Name = "grpFiltreChefPlanete";
            this.grpFiltreChefPlanete.Size = new System.Drawing.Size(331, 186);
            this.grpFiltreChefPlanete.TabIndex = 22;
            this.grpFiltreChefPlanete.TabStop = false;
            this.grpFiltreChefPlanete.Text = "Filtrer le chef et les planètes";
            // 
            // txtFiltreChef
            // 
            this.txtFiltreChef.BackColor = System.Drawing.Color.Black;
            this.txtFiltreChef.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltreChef.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtFiltreChef.ForeColor = System.Drawing.Color.White;
            this.txtFiltreChef.Location = new System.Drawing.Point(12, 34);
            this.txtFiltreChef.Name = "txtFiltreChef";
            this.txtFiltreChef.ReadOnly = true;
            this.txtFiltreChef.Size = new System.Drawing.Size(253, 28);
            this.txtFiltreChef.TabIndex = 23;
            this.txtFiltreChef.Text = "Choix d\'un chef :";
            this.txtFiltreChef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFiltrePlanete
            // 
            this.txtFiltrePlanete.BackColor = System.Drawing.Color.Black;
            this.txtFiltrePlanete.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltrePlanete.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtFiltrePlanete.ForeColor = System.Drawing.Color.White;
            this.txtFiltrePlanete.Location = new System.Drawing.Point(12, 116);
            this.txtFiltrePlanete.Name = "txtFiltrePlanete";
            this.txtFiltrePlanete.ReadOnly = true;
            this.txtFiltrePlanete.Size = new System.Drawing.Size(253, 28);
            this.txtFiltrePlanete.TabIndex = 22;
            this.txtFiltrePlanete.Text = "Choix d\'une planète :";
            this.txtFiltrePlanete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboFiltreChef
            // 
            this.cboFiltreChef.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboFiltreChef.FormattingEnabled = true;
            this.cboFiltreChef.Location = new System.Drawing.Point(12, 59);
            this.cboFiltreChef.Name = "cboFiltreChef";
            this.cboFiltreChef.Size = new System.Drawing.Size(253, 32);
            this.cboFiltreChef.TabIndex = 20;
            this.cboFiltreChef.SelectedIndexChanged += new System.EventHandler(this.cboFiltreChef_SelectedIndexChanged);
            // 
            // cboFiltrePlanete
            // 
            this.cboFiltrePlanete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboFiltrePlanete.FormattingEnabled = true;
            this.cboFiltrePlanete.Location = new System.Drawing.Point(12, 141);
            this.cboFiltrePlanete.Name = "cboFiltrePlanete";
            this.cboFiltrePlanete.Size = new System.Drawing.Size(253, 32);
            this.cboFiltrePlanete.TabIndex = 21;
            this.cboFiltrePlanete.SelectedIndexChanged += new System.EventHandler(this.cboFiltrePlanete_SelectedIndexChanged);
            // 
            // grpFiltreBudget
            // 
            this.grpFiltreBudget.Controls.Add(this.txtFiltreBudgetMaximum);
            this.grpFiltreBudget.Controls.Add(this.txtFiltreBudgetMinimum);
            this.grpFiltreBudget.Controls.Add(this.hsbFiltreBudgetMaximum);
            this.grpFiltreBudget.Controls.Add(this.pcbAppliquerFiltres);
            this.grpFiltreBudget.Controls.Add(this.textBox1);
            this.grpFiltreBudget.Controls.Add(this.hsbFiltreBudgetMinimum);
            this.grpFiltreBudget.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFiltreBudget.ForeColor = System.Drawing.Color.White;
            this.grpFiltreBudget.Location = new System.Drawing.Point(960, 20);
            this.grpFiltreBudget.Name = "grpFiltreBudget";
            this.grpFiltreBudget.Size = new System.Drawing.Size(651, 186);
            this.grpFiltreBudget.TabIndex = 18;
            this.grpFiltreBudget.TabStop = false;
            this.grpFiltreBudget.Text = "Filtrer le budget";
            // 
            // txtFiltreBudgetMaximum
            // 
            this.txtFiltreBudgetMaximum.BackColor = System.Drawing.Color.Black;
            this.txtFiltreBudgetMaximum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltreBudgetMaximum.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtFiltreBudgetMaximum.ForeColor = System.Drawing.Color.White;
            this.txtFiltreBudgetMaximum.Location = new System.Drawing.Point(6, 116);
            this.txtFiltreBudgetMaximum.Name = "txtFiltreBudgetMaximum";
            this.txtFiltreBudgetMaximum.ReadOnly = true;
            this.txtFiltreBudgetMaximum.Size = new System.Drawing.Size(420, 28);
            this.txtFiltreBudgetMaximum.TabIndex = 17;
            this.txtFiltreBudgetMaximum.Text = "Budget maximum : 10000€";
            this.txtFiltreBudgetMaximum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFiltreBudgetMinimum
            // 
            this.txtFiltreBudgetMinimum.BackColor = System.Drawing.Color.Black;
            this.txtFiltreBudgetMinimum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltreBudgetMinimum.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtFiltreBudgetMinimum.ForeColor = System.Drawing.Color.White;
            this.txtFiltreBudgetMinimum.Location = new System.Drawing.Point(6, 34);
            this.txtFiltreBudgetMinimum.Name = "txtFiltreBudgetMinimum";
            this.txtFiltreBudgetMinimum.ReadOnly = true;
            this.txtFiltreBudgetMinimum.Size = new System.Drawing.Size(420, 28);
            this.txtFiltreBudgetMinimum.TabIndex = 16;
            this.txtFiltreBudgetMinimum.Text = "Budget minimum : 0€";
            this.txtFiltreBudgetMinimum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hsbFiltreBudgetMaximum
            // 
            this.hsbFiltreBudgetMaximum.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.hsbFiltreBudgetMaximum.LargeChange = 1000;
            this.hsbFiltreBudgetMaximum.Location = new System.Drawing.Point(6, 147);
            this.hsbFiltreBudgetMaximum.Maximum = 109999;
            this.hsbFiltreBudgetMaximum.Name = "hsbFiltreBudgetMaximum";
            this.hsbFiltreBudgetMaximum.Size = new System.Drawing.Size(448, 26);
            this.hsbFiltreBudgetMaximum.SmallChange = 100;
            this.hsbFiltreBudgetMaximum.TabIndex = 4;
            this.hsbFiltreBudgetMaximum.Value = 100000;
            this.hsbFiltreBudgetMaximum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hsbFiltreBudgetMaximum_MouseUp);
            this.hsbFiltreBudgetMaximum.ValueChanged += new System.EventHandler(this.hsbFiltreBudgetMaximum_ValueChanged);
            // 
            // pcbAppliquerFiltres
            // 
            this.pcbAppliquerFiltres.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcbAppliquerFiltres.BackgroundImage")));
            this.pcbAppliquerFiltres.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbAppliquerFiltres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbAppliquerFiltres.Location = new System.Drawing.Point(492, 76);
            this.pcbAppliquerFiltres.Name = "pcbAppliquerFiltres";
            this.pcbAppliquerFiltres.Size = new System.Drawing.Size(115, 90);
            this.pcbAppliquerFiltres.TabIndex = 23;
            this.pcbAppliquerFiltres.TabStop = false;
            this.pcbAppliquerFiltres.Click += new System.EventHandler(this.pcbAppliquerFiltres_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(473, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(172, 28);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "Appliquer le budget :";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hsbFiltreBudgetMinimum
            // 
            this.hsbFiltreBudgetMinimum.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.hsbFiltreBudgetMinimum.LargeChange = 1000;
            this.hsbFiltreBudgetMinimum.Location = new System.Drawing.Point(6, 65);
            this.hsbFiltreBudgetMinimum.Maximum = 10999;
            this.hsbFiltreBudgetMinimum.Name = "hsbFiltreBudgetMinimum";
            this.hsbFiltreBudgetMinimum.Size = new System.Drawing.Size(448, 26);
            this.hsbFiltreBudgetMinimum.SmallChange = 100;
            this.hsbFiltreBudgetMinimum.TabIndex = 3;
            this.hsbFiltreBudgetMinimum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hsbFiltreBudgetMinimum_MouseUp);
            this.hsbFiltreBudgetMinimum.ValueChanged += new System.EventHandler(this.hsbFiltreBudgetMinimum_ValueChanged);
            // 
            // txtResetFiltre
            // 
            this.txtResetFiltre.BackColor = System.Drawing.Color.Black;
            this.txtResetFiltre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResetFiltre.Font = new System.Drawing.Font("Agency FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResetFiltre.ForeColor = System.Drawing.Color.White;
            this.txtResetFiltre.Location = new System.Drawing.Point(87, 81);
            this.txtResetFiltre.Name = "txtResetFiltre";
            this.txtResetFiltre.ReadOnly = true;
            this.txtResetFiltre.Size = new System.Drawing.Size(203, 28);
            this.txtResetFiltre.TabIndex = 25;
            this.txtResetFiltre.Text = "Réinitialiser les filtres :";
            this.txtResetFiltre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Black;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Agency FB", 14F);
            this.textBox3.ForeColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(363, 144);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(184, 28);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "Mission à venir";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Agency FB", 14F);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(363, 83);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(184, 28);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Mission en cours";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBudgetPreMission
            // 
            this.txtBudgetPreMission.BackColor = System.Drawing.Color.Black;
            this.txtBudgetPreMission.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBudgetPreMission.Font = new System.Drawing.Font("Agency FB", 14F);
            this.txtBudgetPreMission.ForeColor = System.Drawing.Color.White;
            this.txtBudgetPreMission.Location = new System.Drawing.Point(363, 29);
            this.txtBudgetPreMission.Name = "txtBudgetPreMission";
            this.txtBudgetPreMission.ReadOnly = true;
            this.txtBudgetPreMission.Size = new System.Drawing.Size(184, 28);
            this.txtBudgetPreMission.TabIndex = 11;
            this.txtBudgetPreMission.Text = "Mission passées";
            this.txtBudgetPreMission.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboMissionPasse
            // 
            this.cboMissionPasse.AutoSize = true;
            this.cboMissionPasse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMissionPasse.Location = new System.Drawing.Point(553, 37);
            this.cboMissionPasse.Name = "cboMissionPasse";
            this.cboMissionPasse.Size = new System.Drawing.Size(18, 17);
            this.cboMissionPasse.TabIndex = 2;
            this.cboMissionPasse.UseVisualStyleBackColor = true;
            this.cboMissionPasse.CheckedChanged += new System.EventHandler(this.cboMissionPasse_CheckedChanged);
            // 
            // txtFiltresMissions
            // 
            this.txtFiltresMissions.BackColor = System.Drawing.Color.Black;
            this.txtFiltresMissions.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltresMissions.ForeColor = System.Drawing.Color.White;
            this.txtFiltresMissions.Location = new System.Drawing.Point(14, 16);
            this.txtFiltresMissions.Name = "txtFiltresMissions";
            this.txtFiltresMissions.ReadOnly = true;
            this.txtFiltresMissions.Size = new System.Drawing.Size(355, 43);
            this.txtFiltresMissions.TabIndex = 15;
            this.txtFiltresMissions.Text = "Filtres pour l\'affichage des missions :";
            this.txtFiltresMissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cboMissionPresent
            // 
            this.cboMissionPresent.AutoSize = true;
            this.cboMissionPresent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMissionPresent.Location = new System.Drawing.Point(553, 94);
            this.cboMissionPresent.Name = "cboMissionPresent";
            this.cboMissionPresent.Size = new System.Drawing.Size(18, 17);
            this.cboMissionPresent.TabIndex = 1;
            this.cboMissionPresent.UseVisualStyleBackColor = true;
            this.cboMissionPresent.CheckedChanged += new System.EventHandler(this.cboMissionPresent_CheckedChanged);
            // 
            // cboMissionFutur
            // 
            this.cboMissionFutur.AutoSize = true;
            this.cboMissionFutur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMissionFutur.Location = new System.Drawing.Point(553, 155);
            this.cboMissionFutur.Name = "cboMissionFutur";
            this.cboMissionFutur.Size = new System.Drawing.Size(18, 17);
            this.cboMissionFutur.TabIndex = 0;
            this.cboMissionFutur.UseVisualStyleBackColor = true;
            this.cboMissionFutur.CheckedChanged += new System.EventHandler(this.cboMissionFutur_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnAccueil);
            this.panel1.Controls.Add(this.pcbLogo);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Location = new System.Drawing.Point(30, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1860, 95);
            this.panel1.TabIndex = 14;
            // 
            // btnAccueil
            // 
            this.btnAccueil.BackColor = System.Drawing.Color.Black;
            this.btnAccueil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccueil.BackgroundImage")));
            this.btnAccueil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccueil.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.White;
            this.btnAccueil.Location = new System.Drawing.Point(1659, 6);
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
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.Black;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Agency FB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(451, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(1098, 96);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "Tableau de bord :";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTableauDeBord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1902, 1153);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ucRecapMissionEntierFinal);
            this.Controls.Add(this.pnlFiltresMissions);
            this.Controls.Add(this.pcbFullDroite);
            this.Controls.Add(this.pcbFullGauche);
            this.Controls.Add(this.pcbFlecheGauche);
            this.Controls.Add(this.pnlConteneurMission);
            this.Controls.Add(this.pcbFlecheDroite);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTableauDeBord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tableau de Bord";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcbFlecheDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFlecheGauche)).EndInit();
            this.pnlConteneurMission.ResumeLayout(false);
            this.pnlConteneurMission.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFullGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFullDroite)).EndInit();
            this.pnlFiltresMissions.ResumeLayout(false);
            this.pnlFiltresMissions.PerformLayout();
            this.grpFondEcran.ResumeLayout(false);
            this.grpFondEcran.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbResetFiltres)).EndInit();
            this.grpFiltreChefPlanete.ResumeLayout(false);
            this.grpFiltreChefPlanete.PerformLayout();
            this.grpFiltreBudget.ResumeLayout(false);
            this.grpFiltreBudget.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAppliquerFiltres)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ucRecapMissionEntier ucRecapMissionEntierFinal;
        private System.Windows.Forms.PictureBox pcbFlecheGauche;
        private System.Windows.Forms.PictureBox pcbFlecheDroite;
        private System.Windows.Forms.Panel pnlConteneurMission;
        private System.Windows.Forms.PictureBox pcbFullGauche;
        private System.Windows.Forms.PictureBox pcbFullDroite;
        private System.Windows.Forms.Panel pnlFiltresMissions;
        private System.Windows.Forms.CheckBox cboMissionFutur;
        private System.Windows.Forms.CheckBox cboMissionPasse;
        private System.Windows.Forms.CheckBox cboMissionPresent;
        private System.Windows.Forms.HScrollBar hsbFiltreBudgetMinimum;
        private System.Windows.Forms.HScrollBar hsbFiltreBudgetMaximum;
        private System.Windows.Forms.TextBox txtBudgetPreMission;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtFiltresMissions;
        private System.Windows.Forms.GroupBox grpFiltreBudget;
        private System.Windows.Forms.TextBox txtFiltreBudgetMaximum;
        private System.Windows.Forms.TextBox txtFiltreBudgetMinimum;
        private System.Windows.Forms.ComboBox cboFiltrePlanete;
        private System.Windows.Forms.ComboBox cboFiltreChef;
        private System.Windows.Forms.GroupBox grpFiltreChefPlanete;
        private System.Windows.Forms.TextBox txtFiltreChef;
        private System.Windows.Forms.TextBox txtFiltrePlanete;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pcbAppliquerFiltres;
        private System.Windows.Forms.PictureBox pcbResetFiltres;
        private System.Windows.Forms.TextBox txtResetFiltre;
        private System.Windows.Forms.GroupBox grpFondEcran;
        private System.Windows.Forms.CheckBox cboFondPasColore;
        private System.Windows.Forms.CheckBox cboFondColore;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtFondColore;
        private System.Windows.Forms.Panel pnlCouleurChoisie;
        private System.Windows.Forms.TextBox txtChoixCouleur;
        private System.Windows.Forms.CheckBox cboChoixCouleur;
        private System.Windows.Forms.TextBox txtCodeRGB;
        private System.Windows.Forms.TextBox txtAucunMissionCorrespond;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.TextBox textBox5;
    }
}