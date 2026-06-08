using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace SAE24_Stargate
{
    /// <summary>
    /// Formulaire d'édition d'une mission en cours.
    /// Permet d'ajouter : contacts avec informateurs, dépenses, événements du journal et captures réelles.
    /// Fonctionne en MODE CONNECTÉ (écritures en base SQLite).
    /// </summary>
    public partial class frmEditionMission : Form
    {
        // ─── Données de la mission courante ───────────────────────────────────────
        private string nomPlanete;
        private int numeroMission;

        // ─── Dictionnaire pour les informateurs (nomCode → rowData) ──────────────
        // Clé = "NomCode - NomEspece", Valeur = nomCode brut
        private System.Collections.Generic.Dictionary<string, string> dicoInformateurs
            = new System.Collections.Generic.Dictionary<string, string>();

        // ─── Dictionnaire pour les types de dépense (libellé → id) ───────────────
        private System.Collections.Generic.Dictionary<string, int> dicoTypesDepense
            = new System.Collections.Generic.Dictionary<string, int>();

        // ─────────────────────────────────────────────────────────────────────────
        public frmEditionMission(string planete, int numero)
        {
            InitializeComponent();
            this.nomPlanete = planete;
            this.numeroMission = numero;
        }

        // =========================================================================
        //  CHARGEMENT DU FORMULAIRE
        // =========================================================================
        private void frmEditionMission_Load(object sender, EventArgs e)
        {
            // ── Style général ──
            this.BackColor = Color.Black;
            AppliquerStyleGlobal();

            // ── Titre du formulaire ──
            lblTitreMission.Text = $"ÉDITION DE LA MISSION  {nomPlanete}-{numeroMission}";

            // ── Initialisation des onglets ──
            ChargerInformateurs();
            ChargerTypesDepense();
            InitialiserDatePickers();

            // ── Sélection du premier onglet par défaut ──
            tabEdition.SelectedIndex = 0;
        }

        // =========================================================================
        //  CHARGEMENT DES DONNÉES DEPUIS LE DATASET (mode déconnecté côté lecture)
        // =========================================================================

        /// <summary>Remplit la ComboBox des informateurs depuis la table Informateur du DataSet.</summary>
        private void ChargerInformateurs()
        {
            dicoInformateurs.Clear();
            cboInformateur.Items.Clear();

            if (!MesDatas.DsGlobal.Tables.Contains("Informateur")) return;

            DataTable dtInfo = MesDatas.DsGlobal.Tables["Informateur"];
            DataTable dtEsp = MesDatas.DsGlobal.Tables.Contains("Espece")
                               ? MesDatas.DsGlobal.Tables["Espece"] : null;

            foreach (DataRow dr in dtInfo.Rows)
            {
                string nomCode = dr["nomCode"].ToString();
                string espece = "";
                string nomComplet = dr["nom"].ToString();

                if (dtEsp != null)
                {
                    // Informateur.idEspeceEnnemi → Espece.id
                    DataRow[] lignes = dtEsp.Select($"id = {dr["idEspeceEnnemi"]}");
                    if (lignes.Length > 0)
                        espece = lignes[0]["nom"].ToString();
                }

                string affichage = $"{nomCode}  [{espece}]";
                dicoInformateurs[affichage] = nomCode;
                cboInformateur.Items.Add(affichage);
            }

            if (cboInformateur.Items.Count > 0)
                cboInformateur.SelectedIndex = 0;
        }

        /// <summary>Remplit la ComboBox des types de dépense depuis la table TypeDepense du DataSet.</summary>
        private void ChargerTypesDepense()
        {
            dicoTypesDepense.Clear();
            cboTypeDepense.Items.Clear();

            if (!MesDatas.DsGlobal.Tables.Contains("TypeDepense")) return;

            foreach (DataRow dr in MesDatas.DsGlobal.Tables["TypeDepense"].Rows)
            {
                string libelle = dr["libelle"].ToString();
                int id = Convert.ToInt32(dr["id"]);
                dicoTypesDepense[libelle] = id;
                cboTypeDepense.Items.Add(libelle);
            }

            if (cboTypeDepense.Items.Count > 0)
                cboTypeDepense.SelectedIndex = 0;
        }

        /// <summary>Initialise les DateTimePickers à la date du jour.</summary>
        private void InitialiserDatePickers()
        {
            dtpContact.Value = DateTime.Today;
            dtpDepense.Value = DateTime.Today;
            dtpJournal.Value = DateTime.Today;
        }

        // =========================================================================
        //  ONGLET 1 – NOUVEAU CONTACT AVEC UN INFORMATEUR
        // =========================================================================

        private void btnAjouterContact_Click(object sender, EventArgs e)
        {
            // ── Validation des champs ──────────────────────────────────────────
            if (cboInformateur.SelectedIndex < 0)
            {
                AfficherErreur("Veuillez sélectionner un informateur.");
                return;
            }

            if (!decimal.TryParse(txtSomme.Text.Trim(), out decimal somme) || somme <= 0)
            {
                AfficherErreur("La somme versée doit être un nombre positif.");
                txtSomme.Focus();
                return;
            }

            if (txtAppréciation.Text.Trim() == "")
            {
                AfficherErreur("Saisissez une appréciation pour ce contact.");
                txtAppréciation.Focus();
                return;
            }

            string nomCodeInformateur = dicoInformateurs[cboInformateur.SelectedItem.ToString()];
            string dateContact = dtpContact.Value.ToString("yyyy-MM-dd");
            string appreciation = txtAppréciation.Text.Trim().Replace("'", "''");

            try
            {
                // ── Connexion et insertion ────────────────────────────────────
                string sql = $@"INSERT INTO Contact
                                (nomPlanete, numeroMission, dateC, sommeVersee, appreciation, nomCodeInformateur)
                                VALUES ('{nomPlanete}', {numeroMission}, '{dateContact}',
                                        {somme}, '{appreciation}', '{nomCodeInformateur}')";

                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                cmd.ExecuteNonQuery();
                Connexion.FermerConnexion();

                AfficherSucces("Contact enregistré avec succès !");
                ViderChampsContact();

                // ── Mise à jour du DataSet local ──────────────────────────────
                if (MesDatas.DsGlobal.Tables.Contains("Contact"))
                {
                    DataRow nouvelleL = MesDatas.DsGlobal.Tables["Contact"].NewRow();
                    nouvelleL["nomPlanete"] = nomPlanete;
                    nouvelleL["numeroMission"] = numeroMission;
                    nouvelleL["dateC"] = dateContact;
                    nouvelleL["sommeVersee"] = somme;
                    nouvelleL["appreciation"] = txtAppréciation.Text.Trim();
                    nouvelleL["nomCodeInformateur"] = nomCodeInformateur;
                    MesDatas.DsGlobal.Tables["Contact"].Rows.Add(nouvelleL);
                }
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur lors de l'insertion du contact :\n" + ex.Message);
            }
        }

        private void ViderChampsContact()
        {
            txtSomme.Clear();
            txtAppréciation.Clear();
            dtpContact.Value = DateTime.Today;
        }

        // =========================================================================
        //  ONGLET 2 – NOUVELLE DÉPENSE
        // =========================================================================

        private void btnAjouterDepense_Click(object sender, EventArgs e)
        {
            // ── Validation ────────────────────────────────────────────────────
            if (!decimal.TryParse(txtMontant.Text.Trim(), out decimal montant) || montant <= 0)
            {
                AfficherErreur("Le montant doit être un nombre positif.");
                txtMontant.Focus();
                return;
            }

            if (txtMotif.Text.Trim() == "")
            {
                AfficherErreur("Saisissez un motif pour la dépense.");
                txtMotif.Focus();
                return;
            }

            if (cboTypeDepense.SelectedIndex < 0)
            {
                AfficherErreur("Veuillez choisir un type de dépense.");
                return;
            }

            int idType = dicoTypesDepense[cboTypeDepense.SelectedItem.ToString()];
            string dateDepense = dtpDepense.Value.ToString("yyyy-MM-dd");
            string motif = txtMotif.Text.Trim().Replace("'", "''");

            // ── Vérification du budget disponible ────────────────────────────
            if (MesDatas.DsGlobal.Tables.Contains("Mission"))
            {
                string filtreMission = $"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numero = {numeroMission}";
                DataRow[] missionRows = MesDatas.DsGlobal.Tables["Mission"].Select(filtreMission);
                if (missionRows.Length > 0 && missionRows[0]["budget"] != DBNull.Value)
                {
                    decimal budgetInitial = Convert.ToDecimal(missionRows[0]["budget"]);

                    // Calculer le total des dépenses déjà enregistrées pour cette mission
                    decimal totalDepenses = 0;
                    if (MesDatas.DsGlobal.Tables.Contains("Depense"))
                    {
                        string filtreDepense = $"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numeroMission = {numeroMission}";
                        foreach (DataRow drDep in MesDatas.DsGlobal.Tables["Depense"].Select(filtreDepense))
                        {
                            if (drDep["montant"] != DBNull.Value)
                                totalDepenses += Convert.ToDecimal(drDep["montant"]);
                        }
                    }

                    decimal budgetRestant = budgetInitial - totalDepenses;
                    if (montant > budgetRestant)
                    {
                        AfficherErreur($"Budget insuffisant ! Budget restant : {budgetRestant}€. Cette dépense de {montant}€ dépasserait le budget.");
                        txtMontant.Focus();
                        return;
                    }
                }
            }

            try
            {
                string sql = $@"INSERT INTO Depense
                                (nomPlanete, numeroMission, dateD, montant, motif, idTypeDepense)
                                VALUES ('{nomPlanete}', {numeroMission}, '{dateDepense}',
                                        {montant}, '{motif}', {idType})";

                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                cmd.ExecuteNonQuery();
                Connexion.FermerConnexion();

                AfficherSucces("Dépense enregistrée avec succès !");
                ViderChampsDepense();

                // ── Mise à jour du DataSet local ──────────────────────────────
                if (MesDatas.DsGlobal.Tables.Contains("Depense"))
                {
                    DataRow nouvelleL = MesDatas.DsGlobal.Tables["Depense"].NewRow();
                    nouvelleL["nomPlanete"] = nomPlanete;
                    nouvelleL["numeroMission"] = numeroMission;
                    nouvelleL["dateD"] = dateDepense;
                    nouvelleL["montant"] = montant;
                    nouvelleL["motif"] = txtMotif.Text.Trim();
                    nouvelleL["idTypeDepense"] = idType;
                    MesDatas.DsGlobal.Tables["Depense"].Rows.Add(nouvelleL);
                }
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur lors de l'insertion de la dépense :\n" + ex.Message);
            }
        }

        private void ViderChampsDepense()
        {
            txtMontant.Clear();
            txtMotif.Clear();
            dtpDepense.Value = DateTime.Today;
        }

        // =========================================================================
        //  ONGLET 3 – NOUVEL ÉVÉNEMENT (JOURNAL DE BORD)
        // =========================================================================

        private void btnAjouterEvenement_Click(object sender, EventArgs e)
        {
            // ── Validation ────────────────────────────────────────────────────
            if (txtCommentaire.Text.Trim() == "")
            {
                AfficherErreur("Saisissez le commentaire de l'événement.");
                txtCommentaire.Focus();
                return;
            }

            string dateJournal = dtpJournal.Value.ToString("yyyy-MM-dd");
            string commentaire = txtCommentaire.Text.Trim().Replace("'", "''");

            try
            {
                string sql = $@"INSERT INTO JournalDeBord
                                (nomPlanete, numero, dateJ, commentaires)
                                VALUES ('{nomPlanete}', {numeroMission}, '{dateJournal}', '{commentaire}')";

                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                cmd.ExecuteNonQuery();
                Connexion.FermerConnexion();

                AfficherSucces("Événement enregistré dans le journal !");
                ViderChampsJournal();

                // ── Mise à jour du DataSet local ──────────────────────────────
                if (MesDatas.DsGlobal.Tables.Contains("JournalDeBord"))
                {
                    DataRow nouvelleL = MesDatas.DsGlobal.Tables["JournalDeBord"].NewRow();
                    nouvelleL["nomPlanete"] = nomPlanete;
                    nouvelleL["numero"] = numeroMission;
                    nouvelleL["dateJ"] = dateJournal;
                    nouvelleL["commentaires"] = txtCommentaire.Text.Trim();
                    MesDatas.DsGlobal.Tables["JournalDeBord"].Rows.Add(nouvelleL);
                }
            }
            catch (Exception ex)
            {
                AfficherErreur("Erreur lors de l'insertion de l'événement :\n" + ex.Message);
            }
        }

        private void ViderChampsJournal()
        {
            txtCommentaire.Clear();
            dtpJournal.Value = DateTime.Today;
        }

        // =========================================================================
        //  ONGLET 4 – CAPTURES RÉELLES (MISE À JOUR ou INSERTION)
        // =========================================================================

        private void frmEditionMission_Shown(object sender, EventArgs e)
        {
            // Charger les espèces ennemies ayant un objectif sur cette mission
            ChargerEspecesCapture();
        }

        /// <summary>
        /// Charge dans le DataGridView les espèces avec objectif + captures actuelles
        /// pour permettre la mise à jour.
        /// </summary>
        private void ChargerEspecesCapture()
        {
            dgvCaptures.Rows.Clear();

            if (!MesDatas.DsGlobal.Tables.Contains("ObjectifCapture") ||
                !MesDatas.DsGlobal.Tables.Contains("Espece"))
                return;

            DataTable dtObj = MesDatas.DsGlobal.Tables["ObjectifCapture"];
            DataTable dtEspece = MesDatas.DsGlobal.Tables["Espece"];
            DataTable dtCapture = MesDatas.DsGlobal.Tables.Contains("Capturer")
                                  ? MesDatas.DsGlobal.Tables["Capturer"] : null;

            string filtre = $"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numeroMission = {numeroMission}";
            DataRow[] objRows = dtObj.Select(filtre);

            foreach (DataRow drObj in objRows)
            {
                int idEsp = Convert.ToInt32(drObj["idEspeceEnnemi"]);
                int objectif = Convert.ToInt32(drObj["objectif"]);

                // Nom de l'espèce
                DataRow[] lignesEsp = dtEspece.Select($"id = {idEsp}");
                string nomEsp = lignesEsp.Length > 0 ? lignesEsp[0]["nom"].ToString() : "Inconnue";

                // Captures actuelles
                int capturesActuelles = 0;
                if (dtCapture != null)
                {
                    DataRow[] capRows = dtCapture.Select(
                        $"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numeroMission = {numeroMission} AND idEspeceEnnemi = {idEsp}");
                    if (capRows.Length > 0)
                        capturesActuelles = Convert.ToInt32(capRows[0]["nombre"]);
                }

                // On ajoute une ligne éditable (colonne "NouveauNombre" est modifiable)
                int rowIdx = dgvCaptures.Rows.Add(nomEsp, idEsp, objectif, capturesActuelles, capturesActuelles);
            }
        }

        private void btnValiderCaptures_Click(object sender, EventArgs e)
        {
            bool erreur = false;

            foreach (DataGridViewRow row in dgvCaptures.Rows)
            {
                if (row.IsNewRow) continue;

                int idEspece = Convert.ToInt32(row.Cells["colIdEspece"].Value);
                int objectif = Convert.ToInt32(row.Cells["colObjectif"].Value);
                string valSaisie = row.Cells["colNouveauNombre"].Value?.ToString() ?? "0";

                if (!int.TryParse(valSaisie, out int nouveauNombre) || nouveauNombre < 0)
                {
                    row.DefaultCellStyle.BackColor = Color.DarkRed;
                    erreur = true;
                    continue;
                }

                row.DefaultCellStyle.BackColor = Color.FromArgb(20, 20, 20);

                // ── Vérifier si une entrée Capturer existe déjà pour cette espèce ──
                bool existe = false;
                if (MesDatas.DsGlobal.Tables.Contains("Capturer"))
                {
                    DataRow[] capRows = MesDatas.DsGlobal.Tables["Capturer"].Select(
                        $"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numeroMission = {numeroMission} AND idEspeceEnnemi = {idEspece}");
                    existe = capRows.Length > 0;
                }

                try
                {
                    string sql;
                    if (existe)
                    {
                        sql = $@"UPDATE Capturer
                                 SET nombre = {nouveauNombre}
                                 WHERE nomPlanete = '{nomPlanete}' 
                                   AND numeroMission = {numeroMission}
                                   AND idEspeceEnnemi = {idEspece}";
                    }
                    else
                    {
                        sql = $@"INSERT INTO Capturer (nomPlanete, numeroMission, idEspeceEnnemi, nombre)
                                 VALUES ('{nomPlanete}', {numeroMission}, {idEspece}, {nouveauNombre})";
                    }

                    SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                    cmd.ExecuteNonQuery();

                    // ── Mise à jour du DataSet local ──────────────────────────────
                    if (MesDatas.DsGlobal.Tables.Contains("Capturer"))
                    {
                        DataRow[] capRows = MesDatas.DsGlobal.Tables["Capturer"].Select(
                            $"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numeroMission = {numeroMission} AND idEspeceEnnemi = {idEspece}");

                        if (capRows.Length > 0)
                        {
                            capRows[0]["nombre"] = nouveauNombre;
                        }
                        else
                        {
                            DataRow nouvelleL = MesDatas.DsGlobal.Tables["Capturer"].NewRow();
                            nouvelleL["nomPlanete"] = nomPlanete;
                            nouvelleL["numeroMission"] = numeroMission;
                            nouvelleL["idEspeceEnnemi"] = idEspece;
                            nouvelleL["nombre"] = nouveauNombre;
                            MesDatas.DsGlobal.Tables["Capturer"].Rows.Add(nouvelleL);
                        }
                    }

                    // Mettre à jour la colonne d'affichage dans la grille
                    row.Cells["colCapturesActuelles"].Value = nouveauNombre;
                }
                catch (Exception ex)
                {
                    AfficherErreur($"Erreur lors de la mise à jour des captures :\n{ex.Message}");
                    erreur = true;
                }
            }

            Connexion.FermerConnexion();

            if (!erreur)
                AfficherSucces("Captures mises à jour avec succès !");
        }

        // =========================================================================
        //  UTILITAIRES D'AFFICHAGE
        // =========================================================================

        /// <summary>Affiche un message d'erreur dans le label de statut (rouge).</summary>
        private void AfficherErreur(string message)
        {
            lblStatut.ForeColor = Color.OrangeRed;
            lblStatut.Text = "⚠  " + message;
        }

        /// <summary>Affiche un message de succès dans le label de statut (vert).</summary>
        private void AfficherSucces(string message)
        {
            lblStatut.ForeColor = Color.LimeGreen;
            lblStatut.Text = "✔  " + message;
        }

        // =========================================================================
        //  STYLE GÉNÉRAL – reprend les couleurs et polices du TableauDeBord
        // =========================================================================
        private void AppliquerStyleGlobal()
        {
            // ── Titre ──
            lblTitreMission.Font = new Font("Agency FB", 22, FontStyle.Bold);
            lblTitreMission.ForeColor = Color.Gold;
            lblTitreMission.BackColor = Color.Black;

            // ── TabControl ──
            tabEdition.BackColor = Color.Black;
            tabEdition.Font = new Font("Agency FB", 13, FontStyle.Bold);

            // ── Chaque onglet ──
            foreach (TabPage tp in tabEdition.TabPages)
            {
                tp.BackColor = Color.Black;
                tp.ForeColor = Color.White;
                AppliquerStyleRecursif(tp);
            }

            // ── DataGridView Captures ──
            StyliserDataGridView(dgvCaptures);

            // ── Label statut ──
            lblStatut.Font = new Font("Agency FB", 13, FontStyle.Italic);
            lblStatut.ForeColor = Color.White;
            lblStatut.BackColor = Color.Black;

            // ── Bouton fermer ──
            btnFermer.BackColor = Color.FromArgb(40, 40, 40);
            btnFermer.ForeColor = Color.White;
            btnFermer.Font = new Font("Agency FB", 14, FontStyle.Bold);
            btnFermer.FlatStyle = FlatStyle.Flat;
            btnFermer.FlatAppearance.BorderColor = Color.Gold;
        }

        /// <summary>Applique le style Stargate à tous les contrôles d'un conteneur.</summary>
        private void AppliquerStyleRecursif(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.BackColor = Color.Black;
                c.ForeColor = Color.White;
                c.Font = new Font("Agency FB", 13);

                if (c is Label lbl)
                {
                    lbl.ForeColor = Color.Gold;
                    lbl.Font = new Font("Agency FB", 13, FontStyle.Bold);
                }
                else if (c is TextBox tb)
                {
                    tb.BackColor = Color.FromArgb(20, 20, 20);
                    tb.ForeColor = Color.White;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cbo)
                {
                    cbo.BackColor = Color.FromArgb(20, 20, 20);
                    cbo.ForeColor = Color.White;
                    cbo.FlatStyle = FlatStyle.Flat;
                }
                else if (c is Button btn)
                {
                    btn.BackColor = Color.FromArgb(40, 40, 40);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Gold;
                    btn.Font = new Font("Agency FB", 13, FontStyle.Bold);
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.CalendarForeColor = Color.White;
                    dtp.CalendarMonthBackground = Color.FromArgb(20, 20, 20);
                    dtp.CalendarTitleBackColor = Color.Black;
                    dtp.CalendarTitleForeColor = Color.Gold;
                }
                else if (c is GroupBox grp)
                {
                    grp.ForeColor = Color.Gold;
                    grp.Font = new Font("Agency FB", 13, FontStyle.Bold);
                }

                // Récursion
                if (c.HasChildren)
                    AppliquerStyleRecursif(c);
            }
        }

        /// <summary>Applique le style Stargate identique à celui du TableauDeBord.</summary>
        private void StyliserDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.Black;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;

            var cellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.White,
                Font = new Font("Agency FB", 13),
                SelectionBackColor = Color.FromArgb(50, 50, 50),
                SelectionForeColor = Color.Gold,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgv.DefaultCellStyle = cellStyle;

            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Black,
                ForeColor = Color.Gold,
                Font = new Font("Agency FB", 13, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }

        // =========================================================================
        //  BOUTON FERMER
        // =========================================================================
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}