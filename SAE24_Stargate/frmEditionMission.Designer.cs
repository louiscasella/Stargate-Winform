namespace SAE24_Stargate
{
    partial class frmEditionMission
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.lblTitreMission = new System.Windows.Forms.Label();
            this.tabEdition = new System.Windows.Forms.TabControl();
            this.tabContact = new System.Windows.Forms.TabPage();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblInformateur = new System.Windows.Forms.Label();
            this.cboInformateur = new System.Windows.Forms.ComboBox();
            this.lblDateContact = new System.Windows.Forms.Label();
            this.dtpContact = new System.Windows.Forms.DateTimePicker();
            this.lblSomme = new System.Windows.Forms.Label();
            this.txtSomme = new System.Windows.Forms.TextBox();
            this.lblDevise = new System.Windows.Forms.Label();
            this.lblAppreciation = new System.Windows.Forms.Label();
            this.txtAppréciation = new System.Windows.Forms.TextBox();
            this.btnAjouterContact = new System.Windows.Forms.Button();
            this.tabDepense = new System.Windows.Forms.TabPage();
            this.grpDepense = new System.Windows.Forms.GroupBox();
            this.lblDepense = new System.Windows.Forms.Label();
            this.lblDateDepense = new System.Windows.Forms.Label();
            this.dtpDepense = new System.Windows.Forms.DateTimePicker();
            this.lblMontant = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.lblEuro = new System.Windows.Forms.Label();
            this.lblMotif = new System.Windows.Forms.Label();
            this.txtMotif = new System.Windows.Forms.TextBox();
            this.lblTypeDepense = new System.Windows.Forms.Label();
            this.cboTypeDepense = new System.Windows.Forms.ComboBox();
            this.btnAjouterDepense = new System.Windows.Forms.Button();
            this.tabJournal = new System.Windows.Forms.TabPage();
            this.grpJournal = new System.Windows.Forms.GroupBox();
            this.lblJournal = new System.Windows.Forms.Label();
            this.lblDateJournal = new System.Windows.Forms.Label();
            this.dtpJournal = new System.Windows.Forms.DateTimePicker();
            this.lblCommentaire = new System.Windows.Forms.Label();
            this.txtCommentaire = new System.Windows.Forms.TextBox();
            this.btnAjouterEvenement = new System.Windows.Forms.Button();
            this.tabCaptures = new System.Windows.Forms.TabPage();
            this.grpCaptures = new System.Windows.Forms.GroupBox();
            this.lblCaptures = new System.Windows.Forms.Label();
            this.lblInfoCaptures = new System.Windows.Forms.Label();
            this.dgvCaptures = new System.Windows.Forms.DataGridView();
            this.colNomEspece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdEspece = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colObjectif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCapturesActuelles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNouveauNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnValiderCaptures = new System.Windows.Forms.Button();
            this.pnlBas = new System.Windows.Forms.Panel();
            this.lblStatut = new System.Windows.Forms.Label();
            this.btnFermer = new System.Windows.Forms.Button();
            this.tabEdition.SuspendLayout();
            this.tabContact.SuspendLayout();
            this.grpContact.SuspendLayout();
            this.tabDepense.SuspendLayout();
            this.grpDepense.SuspendLayout();
            this.tabJournal.SuspendLayout();
            this.grpJournal.SuspendLayout();
            this.tabCaptures.SuspendLayout();
            this.grpCaptures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaptures)).BeginInit();
            this.pnlBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitreMission
            // 
            this.lblTitreMission.BackColor = System.Drawing.Color.Black;
            this.lblTitreMission.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitreMission.Font = new System.Drawing.Font("Agency FB", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitreMission.ForeColor = System.Drawing.Color.Gold;
            this.lblTitreMission.Location = new System.Drawing.Point(0, 0);
            this.lblTitreMission.Name = "lblTitreMission";
            this.lblTitreMission.Size = new System.Drawing.Size(962, 60);
            this.lblTitreMission.TabIndex = 2;
            this.lblTitreMission.Text = "ÉDITION DE LA MISSION";
            this.lblTitreMission.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabEdition
            // 
            this.tabEdition.Controls.Add(this.tabContact);
            this.tabEdition.Controls.Add(this.tabDepense);
            this.tabEdition.Controls.Add(this.tabJournal);
            this.tabEdition.Controls.Add(this.tabCaptures);
            this.tabEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabEdition.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.tabEdition.ItemSize = new System.Drawing.Size(180, 36);
            this.tabEdition.Location = new System.Drawing.Point(0, 60);
            this.tabEdition.Name = "tabEdition";
            this.tabEdition.SelectedIndex = 0;
            this.tabEdition.Size = new System.Drawing.Size(962, 627);
            this.tabEdition.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabEdition.TabIndex = 0;
            // 
            // tabContact
            // 
            this.tabContact.BackColor = System.Drawing.Color.Black;
            this.tabContact.Controls.Add(this.grpContact);
            this.tabContact.Location = new System.Drawing.Point(4, 40);
            this.tabContact.Name = "tabContact";
            this.tabContact.Size = new System.Drawing.Size(954, 583);
            this.tabContact.TabIndex = 0;
            this.tabContact.Text = "  Contact ET  ";
            // 
            // grpContact
            // 
            this.grpContact.BackColor = System.Drawing.Color.Black;
            this.grpContact.Controls.Add(this.lblContact);
            this.grpContact.Controls.Add(this.lblInformateur);
            this.grpContact.Controls.Add(this.cboInformateur);
            this.grpContact.Controls.Add(this.lblDateContact);
            this.grpContact.Controls.Add(this.dtpContact);
            this.grpContact.Controls.Add(this.lblSomme);
            this.grpContact.Controls.Add(this.txtSomme);
            this.grpContact.Controls.Add(this.lblDevise);
            this.grpContact.Controls.Add(this.lblAppreciation);
            this.grpContact.Controls.Add(this.txtAppréciation);
            this.grpContact.Controls.Add(this.btnAjouterContact);
            this.grpContact.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.grpContact.ForeColor = System.Drawing.Color.Gold;
            this.grpContact.Location = new System.Drawing.Point(30, 20);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(887, 535);
            this.grpContact.TabIndex = 0;
            this.grpContact.TabStop = false;
            this.grpContact.Text = "Nouveau contact avec un informateur";
            // 
            // lblContact
            // 
            this.lblContact.Font = new System.Drawing.Font("Agency FB", 13F);
            this.lblContact.ForeColor = System.Drawing.Color.White;
            this.lblContact.Location = new System.Drawing.Point(15, 35);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(640, 30);
            this.lblContact.TabIndex = 0;
            this.lblContact.Text = "Renseignez les informations du contact extraterrestre :";
            // 
            // lblInformateur
            // 
            this.lblInformateur.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblInformateur.ForeColor = System.Drawing.Color.Gold;
            this.lblInformateur.Location = new System.Drawing.Point(15, 80);
            this.lblInformateur.Name = "lblInformateur";
            this.lblInformateur.Size = new System.Drawing.Size(150, 28);
            this.lblInformateur.TabIndex = 1;
            this.lblInformateur.Text = "Informateur :";
            // 
            // cboInformateur
            // 
            this.cboInformateur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cboInformateur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInformateur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInformateur.Font = new System.Drawing.Font("Agency FB", 13F);
            this.cboInformateur.ForeColor = System.Drawing.Color.White;
            this.cboInformateur.Location = new System.Drawing.Point(175, 77);
            this.cboInformateur.Name = "cboInformateur";
            this.cboInformateur.Size = new System.Drawing.Size(470, 34);
            this.cboInformateur.TabIndex = 2;
            // 
            // lblDateContact
            // 
            this.lblDateContact.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblDateContact.ForeColor = System.Drawing.Color.Gold;
            this.lblDateContact.Location = new System.Drawing.Point(15, 130);
            this.lblDateContact.Name = "lblDateContact";
            this.lblDateContact.Size = new System.Drawing.Size(150, 28);
            this.lblDateContact.TabIndex = 3;
            this.lblDateContact.Text = "Date :";
            // 
            // dtpContact
            // 
            this.dtpContact.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpContact.Location = new System.Drawing.Point(175, 127);
            this.dtpContact.Name = "dtpContact";
            this.dtpContact.Size = new System.Drawing.Size(250, 33);
            this.dtpContact.TabIndex = 4;
            // 
            // lblSomme
            // 
            this.lblSomme.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblSomme.ForeColor = System.Drawing.Color.Gold;
            this.lblSomme.Location = new System.Drawing.Point(15, 180);
            this.lblSomme.Name = "lblSomme";
            this.lblSomme.Size = new System.Drawing.Size(155, 28);
            this.lblSomme.TabIndex = 5;
            this.lblSomme.Text = "Somme versée :";
            // 
            // txtSomme
            // 
            this.txtSomme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtSomme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSomme.Font = new System.Drawing.Font("Agency FB", 13F);
            this.txtSomme.ForeColor = System.Drawing.Color.White;
            this.txtSomme.Location = new System.Drawing.Point(175, 177);
            this.txtSomme.Name = "txtSomme";
            this.txtSomme.Size = new System.Drawing.Size(160, 33);
            this.txtSomme.TabIndex = 6;
            // 
            // lblDevise
            // 
            this.lblDevise.Font = new System.Drawing.Font("Agency FB", 13F);
            this.lblDevise.ForeColor = System.Drawing.Color.White;
            this.lblDevise.Location = new System.Drawing.Point(345, 180);
            this.lblDevise.Name = "lblDevise";
            this.lblDevise.Size = new System.Drawing.Size(150, 28);
            this.lblDevise.TabIndex = 7;
            this.lblDevise.Text = "$ galactiques";
            // 
            // lblAppreciation
            // 
            this.lblAppreciation.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblAppreciation.ForeColor = System.Drawing.Color.Gold;
            this.lblAppreciation.Location = new System.Drawing.Point(15, 230);
            this.lblAppreciation.Name = "lblAppreciation";
            this.lblAppreciation.Size = new System.Drawing.Size(150, 28);
            this.lblAppreciation.TabIndex = 8;
            this.lblAppreciation.Text = "Appréciation :";
            // 
            // txtAppréciation
            // 
            this.txtAppréciation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtAppréciation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAppréciation.Font = new System.Drawing.Font("Agency FB", 13F);
            this.txtAppréciation.ForeColor = System.Drawing.Color.White;
            this.txtAppréciation.Location = new System.Drawing.Point(175, 227);
            this.txtAppréciation.Multiline = true;
            this.txtAppréciation.Name = "txtAppréciation";
            this.txtAppréciation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAppréciation.Size = new System.Drawing.Size(470, 80);
            this.txtAppréciation.TabIndex = 9;
            // 
            // btnAjouterContact
            // 
            this.btnAjouterContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAjouterContact.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnAjouterContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterContact.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.btnAjouterContact.ForeColor = System.Drawing.Color.White;
            this.btnAjouterContact.Location = new System.Drawing.Point(612, 460);
            this.btnAjouterContact.Name = "btnAjouterContact";
            this.btnAjouterContact.Size = new System.Drawing.Size(258, 55);
            this.btnAjouterContact.TabIndex = 10;
            this.btnAjouterContact.Text = "✚  Enregistrer le contact";
            this.btnAjouterContact.UseVisualStyleBackColor = false;
            this.btnAjouterContact.Click += new System.EventHandler(this.btnAjouterContact_Click);
            // 
            // tabDepense
            // 
            this.tabDepense.BackColor = System.Drawing.Color.Black;
            this.tabDepense.Controls.Add(this.grpDepense);
            this.tabDepense.Location = new System.Drawing.Point(4, 40);
            this.tabDepense.Name = "tabDepense";
            this.tabDepense.Size = new System.Drawing.Size(954, 583);
            this.tabDepense.TabIndex = 1;
            this.tabDepense.Text = "  Dépense  ";
            // 
            // grpDepense
            // 
            this.grpDepense.BackColor = System.Drawing.Color.Black;
            this.grpDepense.Controls.Add(this.lblDepense);
            this.grpDepense.Controls.Add(this.lblDateDepense);
            this.grpDepense.Controls.Add(this.dtpDepense);
            this.grpDepense.Controls.Add(this.lblMontant);
            this.grpDepense.Controls.Add(this.txtMontant);
            this.grpDepense.Controls.Add(this.lblEuro);
            this.grpDepense.Controls.Add(this.lblMotif);
            this.grpDepense.Controls.Add(this.txtMotif);
            this.grpDepense.Controls.Add(this.lblTypeDepense);
            this.grpDepense.Controls.Add(this.cboTypeDepense);
            this.grpDepense.Controls.Add(this.btnAjouterDepense);
            this.grpDepense.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.grpDepense.ForeColor = System.Drawing.Color.Gold;
            this.grpDepense.Location = new System.Drawing.Point(30, 20);
            this.grpDepense.Name = "grpDepense";
            this.grpDepense.Size = new System.Drawing.Size(900, 545);
            this.grpDepense.TabIndex = 0;
            this.grpDepense.TabStop = false;
            this.grpDepense.Text = "Nouvelle dépense effectuée";
            // 
            // lblDepense
            // 
            this.lblDepense.Font = new System.Drawing.Font("Agency FB", 13F);
            this.lblDepense.ForeColor = System.Drawing.Color.White;
            this.lblDepense.Location = new System.Drawing.Point(15, 35);
            this.lblDepense.Name = "lblDepense";
            this.lblDepense.Size = new System.Drawing.Size(640, 30);
            this.lblDepense.TabIndex = 0;
            this.lblDepense.Text = "Renseignez les informations de la dépense :";
            // 
            // lblDateDepense
            // 
            this.lblDateDepense.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblDateDepense.ForeColor = System.Drawing.Color.Gold;
            this.lblDateDepense.Location = new System.Drawing.Point(15, 80);
            this.lblDateDepense.Name = "lblDateDepense";
            this.lblDateDepense.Size = new System.Drawing.Size(150, 28);
            this.lblDateDepense.TabIndex = 1;
            this.lblDateDepense.Text = "Date :";
            // 
            // dtpDepense
            // 
            this.dtpDepense.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepense.Location = new System.Drawing.Point(175, 77);
            this.dtpDepense.Name = "dtpDepense";
            this.dtpDepense.Size = new System.Drawing.Size(250, 33);
            this.dtpDepense.TabIndex = 2;
            // 
            // lblMontant
            // 
            this.lblMontant.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblMontant.ForeColor = System.Drawing.Color.Gold;
            this.lblMontant.Location = new System.Drawing.Point(15, 130);
            this.lblMontant.Name = "lblMontant";
            this.lblMontant.Size = new System.Drawing.Size(150, 28);
            this.lblMontant.TabIndex = 3;
            this.lblMontant.Text = "Montant :";
            // 
            // txtMontant
            // 
            this.txtMontant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtMontant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontant.Font = new System.Drawing.Font("Agency FB", 13F);
            this.txtMontant.ForeColor = System.Drawing.Color.White;
            this.txtMontant.Location = new System.Drawing.Point(175, 127);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(160, 33);
            this.txtMontant.TabIndex = 4;
            // 
            // lblEuro
            // 
            this.lblEuro.Font = new System.Drawing.Font("Agency FB", 14F, System.Drawing.FontStyle.Bold);
            this.lblEuro.ForeColor = System.Drawing.Color.White;
            this.lblEuro.Location = new System.Drawing.Point(345, 130);
            this.lblEuro.Name = "lblEuro";
            this.lblEuro.Size = new System.Drawing.Size(30, 28);
            this.lblEuro.TabIndex = 5;
            this.lblEuro.Text = "€";
            // 
            // lblMotif
            // 
            this.lblMotif.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblMotif.ForeColor = System.Drawing.Color.Gold;
            this.lblMotif.Location = new System.Drawing.Point(15, 230);
            this.lblMotif.Name = "lblMotif";
            this.lblMotif.Size = new System.Drawing.Size(150, 28);
            this.lblMotif.TabIndex = 6;
            this.lblMotif.Text = "Motif :";
            // 
            // txtMotif
            // 
            this.txtMotif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtMotif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotif.Font = new System.Drawing.Font("Agency FB", 13F);
            this.txtMotif.ForeColor = System.Drawing.Color.White;
            this.txtMotif.Location = new System.Drawing.Point(175, 227);
            this.txtMotif.Multiline = true;
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotif.Size = new System.Drawing.Size(470, 80);
            this.txtMotif.TabIndex = 7;
            // 
            // lblTypeDepense
            // 
            this.lblTypeDepense.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblTypeDepense.ForeColor = System.Drawing.Color.Gold;
            this.lblTypeDepense.Location = new System.Drawing.Point(15, 180);
            this.lblTypeDepense.Name = "lblTypeDepense";
            this.lblTypeDepense.Size = new System.Drawing.Size(150, 28);
            this.lblTypeDepense.TabIndex = 8;
            this.lblTypeDepense.Text = "Type :";
            // 
            // cboTypeDepense
            // 
            this.cboTypeDepense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.cboTypeDepense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeDepense.Font = new System.Drawing.Font("Agency FB", 13F);
            this.cboTypeDepense.ForeColor = System.Drawing.Color.White;
            this.cboTypeDepense.Location = new System.Drawing.Point(175, 177);
            this.cboTypeDepense.Name = "cboTypeDepense";
            this.cboTypeDepense.Size = new System.Drawing.Size(300, 34);
            this.cboTypeDepense.TabIndex = 9;
            // 
            // btnAjouterDepense
            // 
            this.btnAjouterDepense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAjouterDepense.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnAjouterDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterDepense.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.btnAjouterDepense.ForeColor = System.Drawing.Color.White;
            this.btnAjouterDepense.Location = new System.Drawing.Point(637, 474);
            this.btnAjouterDepense.Name = "btnAjouterDepense";
            this.btnAjouterDepense.Size = new System.Drawing.Size(245, 53);
            this.btnAjouterDepense.TabIndex = 10;
            this.btnAjouterDepense.Text = "✚  Enregistrer la dépense";
            this.btnAjouterDepense.UseVisualStyleBackColor = false;
            this.btnAjouterDepense.Click += new System.EventHandler(this.btnAjouterDepense_Click);
            // 
            // tabJournal
            // 
            this.tabJournal.BackColor = System.Drawing.Color.Black;
            this.tabJournal.Controls.Add(this.grpJournal);
            this.tabJournal.Location = new System.Drawing.Point(4, 40);
            this.tabJournal.Name = "tabJournal";
            this.tabJournal.Size = new System.Drawing.Size(954, 583);
            this.tabJournal.TabIndex = 2;
            this.tabJournal.Text = "  Journal de bord  ";
            // 
            // grpJournal
            // 
            this.grpJournal.BackColor = System.Drawing.Color.Black;
            this.grpJournal.Controls.Add(this.lblJournal);
            this.grpJournal.Controls.Add(this.lblDateJournal);
            this.grpJournal.Controls.Add(this.dtpJournal);
            this.grpJournal.Controls.Add(this.lblCommentaire);
            this.grpJournal.Controls.Add(this.txtCommentaire);
            this.grpJournal.Controls.Add(this.btnAjouterEvenement);
            this.grpJournal.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.grpJournal.ForeColor = System.Drawing.Color.Gold;
            this.grpJournal.Location = new System.Drawing.Point(30, 20);
            this.grpJournal.Name = "grpJournal";
            this.grpJournal.Size = new System.Drawing.Size(680, 400);
            this.grpJournal.TabIndex = 0;
            this.grpJournal.TabStop = false;
            this.grpJournal.Text = "Nouvel événement dans le journal de bord";
            // 
            // lblJournal
            // 
            this.lblJournal.Font = new System.Drawing.Font("Agency FB", 13F);
            this.lblJournal.ForeColor = System.Drawing.Color.White;
            this.lblJournal.Location = new System.Drawing.Point(15, 35);
            this.lblJournal.Name = "lblJournal";
            this.lblJournal.Size = new System.Drawing.Size(640, 30);
            this.lblJournal.TabIndex = 0;
            this.lblJournal.Text = "Consignez un événement survenu lors de la mission :";
            // 
            // lblDateJournal
            // 
            this.lblDateJournal.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblDateJournal.ForeColor = System.Drawing.Color.Gold;
            this.lblDateJournal.Location = new System.Drawing.Point(15, 80);
            this.lblDateJournal.Name = "lblDateJournal";
            this.lblDateJournal.Size = new System.Drawing.Size(150, 28);
            this.lblDateJournal.TabIndex = 1;
            this.lblDateJournal.Text = "Date :";
            // 
            // dtpJournal
            // 
            this.dtpJournal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpJournal.Location = new System.Drawing.Point(175, 77);
            this.dtpJournal.Name = "dtpJournal";
            this.dtpJournal.Size = new System.Drawing.Size(250, 33);
            this.dtpJournal.TabIndex = 2;
            // 
            // lblCommentaire
            // 
            this.lblCommentaire.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.lblCommentaire.ForeColor = System.Drawing.Color.Gold;
            this.lblCommentaire.Location = new System.Drawing.Point(15, 130);
            this.lblCommentaire.Name = "lblCommentaire";
            this.lblCommentaire.Size = new System.Drawing.Size(150, 28);
            this.lblCommentaire.TabIndex = 3;
            this.lblCommentaire.Text = "Commentaire :";
            // 
            // txtCommentaire
            // 
            this.txtCommentaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.txtCommentaire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommentaire.Font = new System.Drawing.Font("Agency FB", 13F);
            this.txtCommentaire.ForeColor = System.Drawing.Color.White;
            this.txtCommentaire.Location = new System.Drawing.Point(175, 127);
            this.txtCommentaire.Multiline = true;
            this.txtCommentaire.Name = "txtCommentaire";
            this.txtCommentaire.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCommentaire.Size = new System.Drawing.Size(470, 150);
            this.txtCommentaire.TabIndex = 4;
            // 
            // btnAjouterEvenement
            // 
            this.btnAjouterEvenement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAjouterEvenement.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnAjouterEvenement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterEvenement.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.btnAjouterEvenement.ForeColor = System.Drawing.Color.White;
            this.btnAjouterEvenement.Location = new System.Drawing.Point(415, 310);
            this.btnAjouterEvenement.Name = "btnAjouterEvenement";
            this.btnAjouterEvenement.Size = new System.Drawing.Size(230, 45);
            this.btnAjouterEvenement.TabIndex = 5;
            this.btnAjouterEvenement.Text = "✚  Enregistrer l\'événement";
            this.btnAjouterEvenement.UseVisualStyleBackColor = false;
            this.btnAjouterEvenement.Click += new System.EventHandler(this.btnAjouterEvenement_Click);
            // 
            // tabCaptures
            // 
            this.tabCaptures.BackColor = System.Drawing.Color.Black;
            this.tabCaptures.Controls.Add(this.grpCaptures);
            this.tabCaptures.Location = new System.Drawing.Point(4, 40);
            this.tabCaptures.Name = "tabCaptures";
            this.tabCaptures.Size = new System.Drawing.Size(954, 583);
            this.tabCaptures.TabIndex = 3;
            this.tabCaptures.Text = "  Captures  ";
            // 
            // grpCaptures
            // 
            this.grpCaptures.BackColor = System.Drawing.Color.Black;
            this.grpCaptures.Controls.Add(this.lblCaptures);
            this.grpCaptures.Controls.Add(this.lblInfoCaptures);
            this.grpCaptures.Controls.Add(this.dgvCaptures);
            this.grpCaptures.Controls.Add(this.btnValiderCaptures);
            this.grpCaptures.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.grpCaptures.ForeColor = System.Drawing.Color.Gold;
            this.grpCaptures.Location = new System.Drawing.Point(30, 20);
            this.grpCaptures.Name = "grpCaptures";
            this.grpCaptures.Size = new System.Drawing.Size(700, 440);
            this.grpCaptures.TabIndex = 0;
            this.grpCaptures.TabStop = false;
            this.grpCaptures.Text = "Mise à jour des captures réelles";
            // 
            // lblCaptures
            // 
            this.lblCaptures.Font = new System.Drawing.Font("Agency FB", 13F);
            this.lblCaptures.ForeColor = System.Drawing.Color.White;
            this.lblCaptures.Location = new System.Drawing.Point(15, 32);
            this.lblCaptures.Name = "lblCaptures";
            this.lblCaptures.Size = new System.Drawing.Size(670, 28);
            this.lblCaptures.TabIndex = 0;
            this.lblCaptures.Text = "Modifiez le nombre réel de captures pour chaque espèce ennemie :";
            // 
            // lblInfoCaptures
            // 
            this.lblInfoCaptures.Font = new System.Drawing.Font("Agency FB", 12F, System.Drawing.FontStyle.Italic);
            this.lblInfoCaptures.ForeColor = System.Drawing.Color.Gold;
            this.lblInfoCaptures.Location = new System.Drawing.Point(15, 62);
            this.lblInfoCaptures.Name = "lblInfoCaptures";
            this.lblInfoCaptures.Size = new System.Drawing.Size(670, 28);
            this.lblInfoCaptures.TabIndex = 1;
            this.lblInfoCaptures.Text = "→ Modifiez uniquement la colonne « Nouveau nombre » puis validez.";
            // 
            // dgvCaptures
            // 
            this.dgvCaptures.ColumnHeadersHeight = 29;
            this.dgvCaptures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomEspece,
            this.colIdEspece,
            this.colObjectif,
            this.colCapturesActuelles,
            this.colNouveauNombre});
            this.dgvCaptures.Location = new System.Drawing.Point(15, 100);
            this.dgvCaptures.Name = "dgvCaptures";
            this.dgvCaptures.RowHeadersWidth = 51;
            this.dgvCaptures.Size = new System.Drawing.Size(665, 280);
            this.dgvCaptures.TabIndex = 2;
            // 
            // colNomEspece
            // 
            this.colNomEspece.FillWeight = 25F;
            this.colNomEspece.HeaderText = "Espèce ennemie";
            this.colNomEspece.MinimumWidth = 6;
            this.colNomEspece.Name = "colNomEspece";
            this.colNomEspece.ReadOnly = true;
            this.colNomEspece.Width = 125;
            // 
            // colIdEspece
            // 
            this.colIdEspece.HeaderText = "ID";
            this.colIdEspece.MinimumWidth = 6;
            this.colIdEspece.Name = "colIdEspece";
            this.colIdEspece.ReadOnly = true;
            this.colIdEspece.Visible = false;
            this.colIdEspece.Width = 125;
            // 
            // colObjectif
            // 
            this.colObjectif.FillWeight = 20F;
            this.colObjectif.HeaderText = "Objectif";
            this.colObjectif.MinimumWidth = 6;
            this.colObjectif.Name = "colObjectif";
            this.colObjectif.ReadOnly = true;
            this.colObjectif.Width = 125;
            // 
            // colCapturesActuelles
            // 
            this.colCapturesActuelles.FillWeight = 25F;
            this.colCapturesActuelles.HeaderText = "Captures actuelles";
            this.colCapturesActuelles.MinimumWidth = 6;
            this.colCapturesActuelles.Name = "colCapturesActuelles";
            this.colCapturesActuelles.ReadOnly = true;
            this.colCapturesActuelles.Width = 125;
            // 
            // colNouveauNombre
            // 
            this.colNouveauNombre.FillWeight = 30F;
            this.colNouveauNombre.HeaderText = "Nouveau nombre ✏";
            this.colNouveauNombre.MinimumWidth = 6;
            this.colNouveauNombre.Name = "colNouveauNombre";
            this.colNouveauNombre.Width = 125;
            // 
            // btnValiderCaptures
            // 
            this.btnValiderCaptures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnValiderCaptures.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.btnValiderCaptures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderCaptures.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.btnValiderCaptures.ForeColor = System.Drawing.Color.White;
            this.btnValiderCaptures.Location = new System.Drawing.Point(450, 392);
            this.btnValiderCaptures.Name = "btnValiderCaptures";
            this.btnValiderCaptures.Size = new System.Drawing.Size(230, 45);
            this.btnValiderCaptures.TabIndex = 3;
            this.btnValiderCaptures.Text = "✔  Valider les captures";
            this.btnValiderCaptures.UseVisualStyleBackColor = false;
            this.btnValiderCaptures.Click += new System.EventHandler(this.btnValiderCaptures_Click);
            // 
            // pnlBas
            // 
            this.pnlBas.BackColor = System.Drawing.Color.Black;
            this.pnlBas.Controls.Add(this.lblStatut);
            this.pnlBas.Controls.Add(this.btnFermer);
            this.pnlBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBas.Location = new System.Drawing.Point(0, 687);
            this.pnlBas.Name = "pnlBas";
            this.pnlBas.Size = new System.Drawing.Size(962, 60);
            this.pnlBas.TabIndex = 1;
            // 
            // lblStatut
            // 
            this.lblStatut.BackColor = System.Drawing.Color.Black;
            this.lblStatut.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Italic);
            this.lblStatut.ForeColor = System.Drawing.Color.White;
            this.lblStatut.Location = new System.Drawing.Point(7, 3);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(600, 47);
            this.lblStatut.TabIndex = 0;
            // 
            // btnFermer
            // 
            this.btnFermer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnFermer.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFermer.Font = new System.Drawing.Font("Agency FB", 13F, System.Drawing.FontStyle.Bold);
            this.btnFermer.ForeColor = System.Drawing.Color.White;
            this.btnFermer.Location = new System.Drawing.Point(804, 8);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(130, 42);
            this.btnFermer.TabIndex = 1;
            this.btnFermer.Text = "✕  Fermer";
            this.btnFermer.UseVisualStyleBackColor = false;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // frmEditionMission
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(962, 747);
            this.Controls.Add(this.tabEdition);
            this.Controls.Add(this.pnlBas);
            this.Controls.Add(this.lblTitreMission);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditionMission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Édition de mission – Stargate";
            this.Load += new System.EventHandler(this.frmEditionMission_Load);
            this.Shown += new System.EventHandler(this.frmEditionMission_Shown);
            this.tabEdition.ResumeLayout(false);
            this.tabContact.ResumeLayout(false);
            this.grpContact.ResumeLayout(false);
            this.grpContact.PerformLayout();
            this.tabDepense.ResumeLayout(false);
            this.grpDepense.ResumeLayout(false);
            this.grpDepense.PerformLayout();
            this.tabJournal.ResumeLayout(false);
            this.grpJournal.ResumeLayout(false);
            this.grpJournal.PerformLayout();
            this.tabCaptures.ResumeLayout(false);
            this.grpCaptures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaptures)).EndInit();
            this.pnlBas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        // ── Déclarations des contrôles ──────────────────────────────────────────
        private System.Windows.Forms.Label lblTitreMission;
        private System.Windows.Forms.TabControl tabEdition;
        private System.Windows.Forms.TabPage tabContact;
        private System.Windows.Forms.GroupBox grpContact;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblInformateur;
        private System.Windows.Forms.ComboBox cboInformateur;
        private System.Windows.Forms.Label lblDateContact;
        private System.Windows.Forms.DateTimePicker dtpContact;
        private System.Windows.Forms.Label lblSomme;
        private System.Windows.Forms.TextBox txtSomme;
        private System.Windows.Forms.Label lblDevise;
        private System.Windows.Forms.Label lblAppreciation;
        private System.Windows.Forms.TextBox txtAppréciation;
        private System.Windows.Forms.Button btnAjouterContact;
        private System.Windows.Forms.TabPage tabDepense;
        private System.Windows.Forms.GroupBox grpDepense;
        private System.Windows.Forms.Label lblDepense;
        private System.Windows.Forms.Label lblDateDepense;
        private System.Windows.Forms.DateTimePicker dtpDepense;
        private System.Windows.Forms.Label lblMontant;
        private System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label lblEuro;
        private System.Windows.Forms.Label lblMotif;
        private System.Windows.Forms.TextBox txtMotif;
        private System.Windows.Forms.Label lblTypeDepense;
        private System.Windows.Forms.ComboBox cboTypeDepense;
        private System.Windows.Forms.Button btnAjouterDepense;
        private System.Windows.Forms.TabPage tabJournal;
        private System.Windows.Forms.GroupBox grpJournal;
        private System.Windows.Forms.Label lblJournal;
        private System.Windows.Forms.Label lblDateJournal;
        private System.Windows.Forms.DateTimePicker dtpJournal;
        private System.Windows.Forms.Label lblCommentaire;
        private System.Windows.Forms.TextBox txtCommentaire;
        private System.Windows.Forms.Button btnAjouterEvenement;
        private System.Windows.Forms.TabPage tabCaptures;
        private System.Windows.Forms.GroupBox grpCaptures;
        private System.Windows.Forms.Label lblCaptures;
        private System.Windows.Forms.Label lblInfoCaptures;
        private System.Windows.Forms.DataGridView dgvCaptures;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomEspece;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEspece;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectif;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCapturesActuelles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNouveauNombre;
        private System.Windows.Forms.Button btnValiderCaptures;
        private System.Windows.Forms.Panel pnlBas;
        private System.Windows.Forms.Label lblStatut;
        private System.Windows.Forms.Button btnFermer;
    }
}