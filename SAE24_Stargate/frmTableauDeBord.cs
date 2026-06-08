using SAE24_Stargate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;

namespace SAE24_Stargate
{
    public partial class frmTableauDeBord : Form
    {
        // =====================================================================
        // VARIABLES DE LA CLASSE
        // =====================================================================

        // Index de la première mission affichée dans le carrousel (pagination)
        private int indexRecapMission = 0;

        // Index de la mission actuellement ouverte dans le récap complet (-1 = aucune)
        private int missionOuverte = -1;

        // Table de données contenant les missions après application des filtres
        private DataTable dtMissionsCourantes;

        // BindingSource pour naviguer dans les entrées du journal de bord
        private BindingSource bsJournalDeBord = new BindingSource();

        // Empêche les déclenchements en cascade lors du reset des filtres
        private bool _filtrageDesactive = false;

        // Nombre de cartes mission affichées en même temps dans le carrousel
        private const int NB_MISSIONS_VISIBLES = 5;

        // Liste des UserControls affichant chaque carte mission
        private List<ucRecapMission> ucMissions = new List<ucRecapMission>();

        // Liste des BindingSources liées à chaque carte mission
        private List<BindingSource> bsMissions = new List<BindingSource>();


        // =====================================================================
        // CONSTRUCTEUR
        // =====================================================================

        public frmTableauDeBord()
        {
            InitializeComponent();

            // Désactive la navigation par Tab sur toutes les TextBox du formulaire
            DesactiverTousLesTabStops(this);
        }


        // =====================================================================
        // CHARGEMENT DU FORMULAIRE
        // =====================================================================

        private void Form1_Load(object sender, EventArgs e)
        {
            // Charge toutes les tables de la base de données dans le DataSet global
            SAE24_Stargate.frmStargate.ChargerBaseComplete();

            DataTable dtMissions = MesDatas.DsGlobal.Tables["Mission"];

            // Ajoute une colonne calculée pour afficher "PlanèteName-NuméroMission"
            if (!dtMissions.Columns.Contains("MissionAffichage"))
            {
                dtMissions.Columns.Add("MissionAffichage", typeof(string), "nomPlanete + '-' + numero");
            }

            // Ajoute une colonne pour numéroter les missions globalement (1, 2, 3...)
            if (!dtMissions.Columns.Contains("NumeroGlobal"))
            {
                dtMissions.Columns.Add("NumeroGlobal", typeof(int));

                for (int i = 0; i < dtMissions.Rows.Count; i++)
                {
                    dtMissions.Rows[i]["NumeroGlobal"] = i + 1;
                }
            }

            // Crée la table "BilanCapture" dans le DataSet si elle n'existe pas encore
            // Elle sert à stocker les statistiques de captures pour l'affichage
            if (!MesDatas.DsGlobal.Tables.Contains("BilanCapture"))
            {
                DataTable dtBilan = new DataTable("BilanCapture");
                dtBilan.Columns.Add("NomEspece", typeof(string));
                dtBilan.Columns.Add("ObjectifInitial", typeof(int));
                dtBilan.Columns.Add("NombreCaptures", typeof(int));
                dtBilan.Columns.Add("TauxCapture", typeof(double)); // Stocke le pourcentage
                MesDatas.DsGlobal.Tables.Add(dtBilan);
            }

            // On garde une référence vers la table des missions pour les filtres
            this.dtMissionsCourantes = dtMissions;

            // Trouve le budget le plus élevé parmi toutes les missions
            // pour définir le maximum des barres de filtrage de budget
            int budgetLePlusHaut = 0;
            foreach (DataRow row in dtMissions.Rows)
            {
                if (row["budget"] != DBNull.Value)
                {
                    int budgetMission = Convert.ToInt32(row["budget"]);
                    if (budgetMission > budgetLePlusHaut)
                    {
                        budgetLePlusHaut = budgetMission;
                    }
                }
            }

            // Configure les barres de défilement du filtre budget avec le bon maximum
            hsbFiltreBudgetMinimum.Maximum = budgetLePlusHaut + 1000;
            hsbFiltreBudgetMaximum.Maximum = budgetLePlusHaut + 1000;

            // Positionne les curseurs : minimum à 0, maximum au budget le plus haut
            hsbFiltreBudgetMaximum.Value = budgetLePlusHaut;
            hsbFiltreBudgetMinimum.Value = 0;

            // Met à jour les textes affichés au-dessus des barres
            txtFiltreBudgetMinimum.Text = "Budget minimum : 0€";
            txtFiltreBudgetMaximum.Text = $"Budget maximum : {budgetLePlusHaut}€";

            // Place et configure les cartes mission dans le panel
            ConfigurerPositionControles();

            // Branche les événements de clic sur chaque carte mission
            ConfigurerEvenementsClic();

            // Remplit les cartes avec les données de la base
            AfficherMissionsVisibles();

            // Remplit les ComboBox des filtres (planètes, chefs)
            InitialiserFiltresCombobox();

            // Cache le panneau de récap complet au démarrage
            ucRecapMissionEntierFinal.Visible = false;

            // Cache le message "aucun résultat" au démarrage
            txtAucunMissionCorrespond.Visible = false;

            // Charge les images de fond et des boutons
            this.BackgroundImage = System.Drawing.Image.FromFile("image/fondPourTableauDeBordV2.png");
            pcbFlecheGauche.BackgroundImage = System.Drawing.Image.FromFile("image/angle-left-solid.png");
            pcbFlecheDroite.BackgroundImage = System.Drawing.Image.FromFile("image/angle-right-solid.png");
            pcbFullGauche.BackgroundImage = System.Drawing.Image.FromFile("image/angles-left-solid.png");
            pcbFullDroite.BackgroundImage = System.Drawing.Image.FromFile("image/angles-right-solid.png");

            // Branche le bouton d'édition du récap complet sur la méthode d'ouverture
            ucRecapMissionEntierFinal.OnDemandeEdition = (indexMission) => OuvrirEditionMission(indexMission);

            // Branche les boutons du récap complet (PDF et fermeture)
            ucRecapMissionEntierFinal.PictureBoxCréationPDF.Click += PictureBoxCréationPDF_Click;
            ucRecapMissionEntierFinal.PictureBoxFermerRecapComplet.Click += PictureBoxFermerRecapComplet_Click;
        }


        // =====================================================================
        // CONFIGURATION DES CONTRÔLES
        // =====================================================================

        // Parcourt récursivement tous les contrôles du formulaire
        // et désactive la navigation par touche Tab sur les TextBox
        private void DesactiverTousLesTabStops(Control conteneur)
        {
            foreach (Control c in conteneur.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).TabStop = false;
                }

                // Si le contrôle contient lui-même d'autres contrôles (ex: Panel), on fouille dedans
                if (c.HasChildren)
                {
                    DesactiverTousLesTabStops(c);
                }
            }
        }

        // Crée et positionne les cartes mission (UserControls) dans le panel du carrousel
        private void ConfigurerPositionControles()
        {
            // Vide le panel et les listes avant de tout recréer
            pnlConteneurMission.Controls.Clear();
            ucMissions.Clear();
            bsMissions.Clear();

            // Remet la TextBox "aucun résultat" dans le panel (Clear() l'enlève)
            pnlConteneurMission.Controls.Add(txtAucunMissionCorrespond);
            txtAucunMissionCorrespond.Visible = false;

            // Crée les cartes et leurs sources de données
            for (int i = 0; i < NB_MISSIONS_VISIBLES; i++)
            {
                ucMissions.Add(new ucRecapMission());
                bsMissions.Add(new BindingSource { DataSource = dtMissionsCourantes });
            }

            int largeurCarte = ucMissions[0].Width;
            int hauteurCarte = ucMissions[0].Height;

            // Calcul automatique de l'espace entre les cartes selon la largeur du panel
            int espaceEntre = (pnlConteneurMission.Width - NB_MISSIONS_VISIBLES * largeurCarte) / (NB_MISSIONS_VISIBLES + 1);
            if (espaceEntre < 5)
            {
                espaceEntre = 5; // minimum 5px pour ne pas coller
            }

            int startX = espaceEntre;
            int posY = (pnlConteneurMission.Height - hauteurCarte) / 2;

            // Place chaque carte à la bonne position dans le panel
            for (int i = 0; i < NB_MISSIONS_VISIBLES; i++)
            {
                int posX = startX + i * (largeurCarte + espaceEntre);
                ucMissions[i].Location = new Point(posX, posY);
                ucMissions[i].LierDonneesRecap(bsMissions[i]);
                pnlConteneurMission.Controls.Add(ucMissions[i]);
            }

            // La TextBox "aucun résultat" doit toujours être par-dessus les cartes
            txtAucunMissionCorrespond.BringToFront();
        }

        // Branche l'événement de clic sur chaque carte mission
        private void ConfigurerEvenementsClic()
        {
            for (int i = 0; i < NB_MISSIONS_VISIBLES; i++)
            {
                int offset = i; // capture de la variable locale pour l'expression lambda
                ucMissions[i].BoutonRecapClique += (s, e) => GererClicMission(indexRecapMission + offset);
            }
        }


        // =====================================================================
        // AFFICHAGE DU CARROUSEL DE MISSIONS
        // =====================================================================

        // Gère le clic sur une carte mission :
        // - si la même mission est déjà ouverte → on ferme le récap complet
        // - sinon → on affiche le récap complet de la mission cliquée
        private void GererClicMission(int missionIndex)
        {
            if (ucRecapMissionEntierFinal.Visible && missionOuverte == missionIndex)
            {
                // La mission cliquée est déjà affichée → on ferme le panneau
                ucRecapMissionEntierFinal.Visible = false;
                missionOuverte = -1;
            }
            else
            {
                // On ouvre le récap complet de la mission cliquée
                missionOuverte = missionIndex;
                AfficherRecapEntier(missionIndex);
                ucRecapMissionEntierFinal.Visible = true;
                ucRecapMissionEntierFinal.BringToFront();
            }
        }

        // Met à jour les cartes visibles dans le carrousel selon l'index de pagination
        private void AfficherMissionsVisibles()
        {
            DataTable dtMissions = this.dtMissionsCourantes;

            // Si aucune mission, on cache toutes les cartes
            if (dtMissions.Rows.Count == 0)
            {
                foreach (var uc in ucMissions)
                {
                    uc.Visible = false;
                }
                return;
            }

            int totalMissions = dtMissions.Rows.Count;

            // Pour chaque emplacement de carte dans le carrousel
            for (int i = 0; i < NB_MISSIONS_VISIBLES; i++)
            {
                int idx = indexRecapMission + i;

                if (idx < totalMissions)
                {
                    // Il y a une mission à afficher à cet emplacement
                    ucMissions[i].Visible = true;
                    bsMissions[i].Position = idx;
                    ucMissions[i].TextBoxNumeroMissionEnBas = $"{idx + 1} / {totalMissions}";
                }
                else
                {
                    // Plus de mission à afficher → on cache la carte
                    ucMissions[i].Visible = false;
                }
            }

            // Met à jour le nom du chef et l'image de la planète sur chaque carte
            MettreAjourChefEtImageMission();
        }

        // Met à jour le nom du chef de mission et l'image de la planète
        // sur chaque carte mission visible dans le carrousel
        private void MettreAjourChefEtImageMission()
        {
            DataTable dtMissions = this.dtMissionsCourantes;
            DataTable dtMembres = MesDatas.DsGlobal.Tables["Membre"];

            for (int i = 0; i < NB_MISSIONS_VISIBLES; i++)
            {
                int idx = indexRecapMission + i;

                if (idx < dtMissions.Rows.Count)
                {
                    DataRow dr = dtMissions.Rows[idx];

                    // Récupère et affiche le nom complet du chef de la mission
                    DataRow[] ligneChef = dtMembres.Select($"matricule = '{dr["matriculeChef"]}'");
                    if (ligneChef.Length > 0)
                    {
                        ucMissions[i].textBoxChef = $"{ligneChef[0]["nom"]} {ligneChef[0]["prenom"]}";
                    }

                    // Charge l'image de la planète correspondant à la mission
                    string nomPlanete = dr["nomPlanete"].ToString();
                    string cheminImage = $"image/planete/{nomPlanete}.png";

                    try
                    {
                        // Libère l'ancienne image pour éviter les fuites mémoire
                        if (ucMissions[i].PictureBoxImageMission.Image != null)
                        {
                            ucMissions[i].PictureBoxImageMission.Image.Dispose();
                        }

                        if (File.Exists(cheminImage))
                        {
                            ucMissions[i].PictureBoxImageMission.Image = Image.FromFile(cheminImage);
                        }
                        else
                        {
                            // Si l'image n'existe pas, on tente une image par défaut
                            string cheminDefault = "image/planete/default.png";
                            if (File.Exists(cheminDefault))
                            {
                                ucMissions[i].PictureBoxImageMission.Image = Image.FromFile(cheminDefault);
                            }
                            else
                            {
                                ucMissions[i].PictureBoxImageMission.Image = null;
                            }
                        }

                        // L'image s'adapte à la taille de la PictureBox sans se déformer
                        ucMissions[i].PictureBoxImageMission.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception)
                    {
                        // En cas d'erreur de chargement, on laisse la PictureBox vide
                        ucMissions[i].PictureBoxImageMission.Image = null;
                    }
                }
            }
        }


        // =====================================================================
        // NAVIGATION DANS LE CARROUSEL (flèches de pagination)
        // =====================================================================

        // Affiche la mission précédente (flèche gauche simple)
        private void pcbFlecheGauche_Click(object sender, EventArgs e)
        {
            if (indexRecapMission > 0)
            {
                indexRecapMission--;
                AfficherMissionsVisibles();
            }
        }

        // Affiche la mission suivante (flèche droite simple)
        private void pcbFlecheDroite_Click(object sender, EventArgs e)
        {
            if (indexRecapMission + NB_MISSIONS_VISIBLES < dtMissionsCourantes.Rows.Count)
            {
                indexRecapMission++;
                AfficherMissionsVisibles();
            }
        }

        // Revient à la toute première mission (flèche gauche double)
        private void pcbFullGauche_Click(object sender, EventArgs e)
        {
            if (indexRecapMission > 0)
            {
                indexRecapMission = 0;
                AfficherMissionsVisibles();
            }
        }

        // Va à la dernière page de missions (flèche droite double)
        private void pcbFullDroite_Click(object sender, EventArgs e)
        {
            int total = dtMissionsCourantes.Rows.Count;
            indexRecapMission = Math.Max(0, total - NB_MISSIONS_VISIBLES);
            AfficherMissionsVisibles();
        }


        // =====================================================================
        // AFFICHAGE DU RÉCAP COMPLET D'UNE MISSION
        // =====================================================================

        // Remplit le UserControl de récap complet avec toutes les données de la mission
        private void AfficherRecapEntier(int missionIndex)
        {
            DataTable dtMissions = this.dtMissionsCourantes;
            DataRow drMission = dtMissions.Rows[missionIndex];

            string planeteCourante = drMission["nomPlanete"].ToString();
            string numCourant = drMission["numero"].ToString();

            // Remplit les informations générales de la mission
            AfficherInfosGeneralesMission(drMission, planeteCourante, numCourant);

            // Remplit le tableau des dépenses
            AfficherDepensesMission(drMission, planeteCourante, numCourant);

            // Remplit le tableau des membres de l'équipe
            AfficherMembresMission(drMission, planeteCourante, numCourant);

            // Remplit le bilan des captures d'espèces
            AfficherBilanCapturesMission(planeteCourante, numCourant);

            // Remplit le journal de bord
            AfficherJournalDeBordMission(planeteCourante, numCourant);

            // Remplit le tableau des contacts avec les informateurs
            AfficherContactsInformateursMission(planeteCourante, numCourant);

            // Remplit la zone de négociation Databaz
            AfficherNegociationDatabaz(drMission, planeteCourante, numCourant);
        }

        // Affiche les informations générales (titre, planète, chef, dates, budget, feuille de route)
        private void AfficherInfosGeneralesMission(DataRow drMission, string planeteCourante, string numCourant)
        {
            DataTable dtMembre = MesDatas.DsGlobal.Tables["Membre"];

            // Titre du récap
            ucRecapMissionEntierFinal.TextBoxTitreRecap = $"Récapitulatif entier de la mission {drMission["nomPlanete"]}-{drMission["numero"]}";

            // Planète visitée
            ucRecapMissionEntierFinal.TextBoxPlaneteVisitee = $"Planete visitee : {drMission["nomPlanete"]}";

            // Nom du chef de mission
            DataRow ligneChef = dtMembre.Select($"matricule = '{drMission["matriculeChef"]}'")[0];
            ucRecapMissionEntierFinal.TextBoxChefRecapEntier = $"Chef(fe) de la mission : {ligneChef["nom"]} {ligneChef["prenom"]}";

            // Numéro de la mission sur cette planète
            ucRecapMissionEntierFinal.TextBoxNumeroMission = $"Mission numéro {drMission["numero"]} sur cette planète";

            // Dates de départ et de retour
            ucRecapMissionEntierFinal.TextBoxDateDepartEtRetour = $"Du {drMission["dateDepart"]} au {drMission["dateRetour"]}";

            // Budget avant la mission
            ucRecapMissionEntierFinal.TextBoxBudgetPreMission = $"Budget pre mission : {drMission["budget"]}€";

            // Contenu de la feuille de route
            ucRecapMissionEntierFinal.TextBoxContenuFeuilleDeRoute = $"{drMission["feuilleDeRoute"]}";

            // Image de la planète en arrière-plan du récap
            ucRecapMissionEntierFinal.PictureBoxImageMission.BackgroundImage = Image.FromFile($"image/planete/{planeteCourante}.png");

            // Affiche ou cache le bouton d'édition selon si la mission est en cours
            if (EstMissionEnCours(planeteCourante, Convert.ToInt32(numCourant)) == 0)
            {
                ucRecapMissionEntierFinal.TextBoxEditionMission.Visible = true;
                ucRecapMissionEntierFinal.PictureBoxEditionMission.Visible = true;
            }
            else
            {
                ucRecapMissionEntierFinal.TextBoxEditionMission.Visible = false;
                ucRecapMissionEntierFinal.PictureBoxEditionMission.Visible = false;
            }
        }

        // Affiche les dépenses de la mission dans le DataGridView des dépenses
        private void AfficherDepensesMission(DataRow drMission, string planeteCourante, string numCourant)
        {
            DataTable dtDepense = MesDatas.DsGlobal.Tables["Depense"];

            // Calcule le total des dépenses de cette mission
            int totalDepenses = 0;
            for (int i = 0; i < dtDepense.Rows.Count; i++)
            {
                DataRow drDepense = dtDepense.Rows[i];
                if (drDepense["nomPlanete"].ToString() == drMission["nomPlanete"].ToString()
                    && drDepense["numeroMission"].ToString() == drMission["numero"].ToString())
                {
                    totalDepenses += Convert.ToInt32(drDepense["montant"]);
                }
            }

            // Calcule le budget restant et l'affiche en rouge si inférieur à 500€
            int budgetPostMission = Convert.ToInt32(drMission["budget"]) - totalDepenses;
            if (budgetPostMission <= 500)
            {
                ucRecapMissionEntierFinal.TextBoxBudgetPostMission.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                ucRecapMissionEntierFinal.TextBoxBudgetPostMission.ForeColor = System.Drawing.Color.White;
            }
            ucRecapMissionEntierFinal.TextBoxBudgetPostMission.Text = $"Budget post mission : {budgetPostMission}€";

            // Filtre les dépenses pour n'afficher que celles de la mission en cours
            DataView viewDepenses = new DataView(dtDepense);
            viewDepenses.RowFilter = $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant}";

            // Style et liaison des données au DataGridView
            StyliserDataGridView(ucRecapMissionEntierFinal.DataGridViewDepenses);
            ucRecapMissionEntierFinal.DataGridViewDepenses.DataSource = viewDepenses;

            // Renomme les colonnes pour un affichage lisible
            ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["dateD"].HeaderText = "Date";
            ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["montant"].HeaderText = "Montant";
            ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["motif"].HeaderText = "Motif / Description";

            // Ajoute une colonne texte pour le type de dépense si elle n'existe pas encore
            if (!dtDepense.Columns.Contains("TypeTexte"))
            {
                dtDepense.Columns.Add("TypeTexte", typeof(string));
            }

            // Remplit la colonne TypeTexte avec le libellé correspondant
            foreach (DataRow row in dtDepense.Rows)
            {
                DataRow[] ligneType = MesDatas.DsGlobal.Tables["TypeDepense"].Select($"id = {row["idTypeDepense"]}");
                if (ligneType.Length > 0)
                {
                    row["TypeTexte"] = ligneType[0]["libelle"];
                }
                else
                {
                    row["TypeTexte"] = "Inconnu";
                }
            }

            // Cache les colonnes techniques dont l'utilisateur n'a pas besoin
            ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["idTypeDepense"].Visible = false;
            if (ucRecapMissionEntierFinal.DataGridViewDepenses.Columns.Contains("nomPlanete"))
            {
                ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["nomPlanete"].Visible = false;
            }
            if (ucRecapMissionEntierFinal.DataGridViewDepenses.Columns.Contains("numeroMission"))
            {
                ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["numeroMission"].Visible = false;
            }
            if (ucRecapMissionEntierFinal.DataGridViewDepenses.Columns.Contains("id"))
            {
                ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["id"].Visible = false;
            }

            // Formate la colonne Montant pour afficher le symbole "€"
            ucRecapMissionEntierFinal.DataGridViewDepenses.Columns["montant"].DefaultCellStyle.Format = "0'€'";
        }

        // Affiche les membres de l'équipe dans le DataGridView des membres
        private void AfficherMembresMission(DataRow drMission, string planeteCourante, string numCourant)
        {
            DataTable dtMembre = MesDatas.DsGlobal.Tables["Membre"];
            DataTable dtComposer = MesDatas.DsGlobal.Tables["Composer"];
            DataTable dtCivil = MesDatas.DsGlobal.Tables["Civil"];
            DataTable dtMilitaire = MesDatas.DsGlobal.Tables["Militaire"];

            // Vide le DataGridView et applique le style
            ucRecapMissionEntierFinal.DataGridViewMembres.DataSource = null;
            StyliserDataGridView(ucRecapMissionEntierFinal.DataGridViewMembres);

            // Crée un DataTable temporaire pour construire l'affichage des membres
            DataTable dtAfficheMembres = new DataTable();
            dtAfficheMembres.Columns.Add("Matricule");
            dtAfficheMembres.Columns.Add("Nom Complet");
            dtAfficheMembres.Columns.Add("Planète d'origine");
            dtAfficheMembres.Columns.Add("Métier / Grade");

            // Récupère tous les membres qui composent cette mission
            DataRow[] lignesComposition = dtComposer.Select(
                $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant}"
            );

            foreach (DataRow drComposer in lignesComposition)
            {
                string matriculeTrouve = drComposer["matriculeMembre"].ToString();
                DataRow[] lignesMembre = dtMembre.Select($"matricule = '{matriculeTrouve}'");

                if (lignesMembre.Length > 0)
                {
                    DataRow drMembre = lignesMembre[0];
                    string nomComplet = $"{drMembre["prenom"]} {drMembre["nom"]}";
                    string metier = "";
                    string planeteOrigine = "";

                    // Détermine si le membre est militaire (matricule commençant par "M") ou civil
                    if (matriculeTrouve.StartsWith("M"))
                    {
                        DataRow[] lignesMilitaire = dtMilitaire.Select($"matriculeMembre = '{matriculeTrouve}'");
                        if (lignesMilitaire.Length > 0)
                        {
                            metier = lignesMilitaire[0]["grade"].ToString();
                            planeteOrigine = "Secret confidentiel"; // La planète des militaires est cachée
                        }
                    }
                    else
                    {
                        DataRow[] lignesCivil = dtCivil.Select($"matriculeMembre = '{matriculeTrouve}'");
                        if (lignesCivil.Length > 0)
                        {
                            metier = lignesCivil[0]["Specialite"].ToString();
                            planeteOrigine = lignesCivil[0]["nomPlaneteOrigine"].ToString();
                        }
                    }

                    dtAfficheMembres.Rows.Add(matriculeTrouve, nomComplet, planeteOrigine, metier);
                }
            }

            // Lie les données au DataGridView
            ucRecapMissionEntierFinal.DataGridViewMembres.DataSource = dtAfficheMembres;
        }

        // Calcule et affiche le bilan des captures d'espèces dans le DataGridView correspondant
        private void AfficherBilanCapturesMission(string planeteCourante, string numCourant)
        {
            DataTable dtObjectif = MesDatas.DsGlobal.Tables["ObjectifCapture"];
            DataTable dtCapture = MesDatas.DsGlobal.Tables["Capturer"];
            DataTable dtEspece = MesDatas.DsGlobal.Tables["Espece"];

            // Vide et recrée la table BilanCapture dans le DataSet
            DataTable dtBilanCapture = MesDatas.DsGlobal.Tables["BilanCapture"];
            dtBilanCapture.Rows.Clear();

            // Collecte tous les IDs d'espèces concernées (objectifs + captures réelles)
            // HashSet évite les doublons automatiquement
            var idsEspecesMission = new HashSet<int>();

            DataRow[] lignesObjectifs = dtObjectif.Select(
                $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant}"
            );
            DataRow[] lignesCaptures = dtCapture.Select(
                $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant}"
            );

            foreach (DataRow row in lignesObjectifs)
            {
                idsEspecesMission.Add(Convert.ToInt32(row["idEspeceEnnemi"]));
            }
            foreach (DataRow row in lignesCaptures)
            {
                idsEspecesMission.Add(Convert.ToInt32(row["idEspeceEnnemi"]));
            }

            // Pour chaque espèce, calcule les statistiques et les ajoute au bilan
            foreach (int idEspece in idsEspecesMission)
            {
                // Récupère le nom de l'espèce
                DataRow[] lignesEspece = dtEspece.Select($"id = {idEspece}");
                string nomEspece = "Inconnue";
                if (lignesEspece.Length > 0)
                {
                    nomEspece = lignesEspece[0]["nom"].ToString();
                }

                // Récupère l'objectif initial de capture pour cette espèce
                int objectifInitial = 0;
                DataRow[] ligneObjectif = dtObjectif.Select(
                    $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant} AND idEspeceEnnemi = {idEspece}"
                );
                if (ligneObjectif.Length > 0)
                {
                    objectifInitial = Convert.ToInt32(ligneObjectif[0]["objectif"]);
                }

                // Récupère le nombre d'aliens réellement capturés
                int nombreCaptures = 0;
                DataRow[] ligneCapture = dtCapture.Select(
                    $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant} AND idEspeceEnnemi = {idEspece}"
                );
                if (ligneCapture.Length > 0)
                {
                    nombreCaptures = Convert.ToInt32(ligneCapture[0]["nombre"]);
                }

                // Calcule le taux de capture en pourcentage
                double tauxCapture = 0;
                if (objectifInitial > 0)
                {
                    // Formule : (captures / objectif) * 100, arrondi à 1 décimale
                    tauxCapture = Math.Round(((double)nombreCaptures / objectifInitial) * 100, 1);
                }
                else if (nombreCaptures > 0)
                {
                    // Pas d'objectif mais des captures ont eu lieu (capture bonus/imprévue)
                    tauxCapture = 100.0;
                }

                dtBilanCapture.Rows.Add(nomEspece, objectifInitial, nombreCaptures, tauxCapture);
            }

            // Applique le style et lie les données au DataGridView
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.DataSource = null;
            StyliserDataGridView(ucRecapMissionEntierFinal.DataGridViewBilanCapture);
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.DataSource = dtBilanCapture;

            // Renomme les colonnes pour un affichage lisible
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.Columns["NomEspece"].HeaderText = "Espèce Ennemie";
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.Columns["ObjectifInitial"].HeaderText = "Objectif Initial";
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.Columns["NombreCaptures"].HeaderText = "Capturés";
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.Columns["TauxCapture"].HeaderText = "Taux de Capture";

            // Formate la colonne Taux pour afficher le symbole '%'
            ucRecapMissionEntierFinal.DataGridViewBilanCapture.Columns["TauxCapture"].DefaultCellStyle.Format = "0.0'%'";
        }

        // Affiche les entrées du journal de bord de la mission
        private void AfficherJournalDeBordMission(string planeteCourante, string numCourant)
        {
            DataTable dtJournalDeBord = MesDatas.DsGlobal.Tables["JournalDeBord"];

            // Filtre le journal pour n'afficher que les entrées de cette mission
            DataView viewJdb = new DataView(dtJournalDeBord);
            viewJdb.RowFilter = $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numero = {numCourant}";

            // Lie la vue filtrée au BindingSource (permet la navigation entrée par entrée)
            bsJournalDeBord.DataSource = viewJdb;
            ucRecapMissionEntierFinal.LierDonneesRecapEntier(bsJournalDeBord);

            // Revient à la première entrée du journal si il y en a
            if (bsJournalDeBord.Count > 0)
            {
                bsJournalDeBord.Position = 0;
            }
        }

        // Affiche les contacts avec les informateurs dans le DataGridView correspondant
        private void AfficherContactsInformateursMission(string planeteCourante, string numCourant)
        {
            // Réinitialise complètement le DataGridView avant de le remplir
            ucRecapMissionEntierFinal.DataGridViewContactInformateur.Rows.Clear();
            ucRecapMissionEntierFinal.DataGridViewContactInformateur.Columns.Clear();
            StyliserDataGridView(ucRecapMissionEntierFinal.DataGridViewContactInformateur);

            // Définit les colonnes du tableau
            ucRecapMissionEntierFinal.DataGridViewContactInformateur.Columns.Add("Informateur", "Informateur");
            ucRecapMissionEntierFinal.DataGridViewContactInformateur.Columns.Add("DateContact", "Date du contact");
            ucRecapMissionEntierFinal.DataGridViewContactInformateur.Columns.Add("SommeVersee", "Somme Versée");
            ucRecapMissionEntierFinal.DataGridViewContactInformateur.Columns.Add("Appreciation", "Appréciation");

            // Remplit le tableau si la table Contact existe dans le DataSet
            if (MesDatas.DsGlobal.Tables.Contains("Contact"))
            {
                DataTable dtContact = MesDatas.DsGlobal.Tables["Contact"];
                string filtre = $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant}";
                DataRow[] contactsMission = dtContact.Select(filtre);

                foreach (DataRow dr in contactsMission)
                {
                    string informateur = dr["nomCodeInformateur"].ToString();

                    // Formate la date du contact en français
                    string dateContact = "";
                    if (dr["dateC"] != DBNull.Value)
                    {
                        dateContact = Convert.ToDateTime(dr["dateC"]).ToString("dd/MM/yyyy");
                    }

                    // Formate la somme versée avec 2 décimales
                    string sommeVersee = "0,00 €";
                    if (dr["sommeVersee"] != DBNull.Value)
                    {
                        sommeVersee = Convert.ToDecimal(dr["sommeVersee"]).ToString("N2") + " €";
                    }

                    string appreciation = dr["appreciation"].ToString();

                    ucRecapMissionEntierFinal.DataGridViewContactInformateur.Rows.Add(
                        informateur, dateContact, sommeVersee, appreciation
                    );
                }
            }

            // Cache le tableau s'il est vide, l'affiche sinon
            if (ucRecapMissionEntierFinal.DataGridViewContactInformateur.Rows.Count <= 0)
            {
                ucRecapMissionEntierFinal.DataGridViewContactInformateur.Visible = false;
            }
            else
            {
                ucRecapMissionEntierFinal.DataGridViewContactInformateur.Visible = true;
            }
        }

        // Affiche l'objectif Databaz de la mission et les négociations effectuées
        private void AfficherNegociationDatabaz(DataRow drMission, string planeteCourante, string numCourant)
        {
            // Affiche l'objectif Databaz défini lors de la création de la mission
            int objectifDatabaz = 0;
            if (drMission["objectifDatabaz"] != DBNull.Value)
                objectifDatabaz = Convert.ToInt32(drMission["objectifDatabaz"]);

            ucRecapMissionEntierFinal.TextBoxObjectifDatabaz =
                $"Objectif Databaz de la mission : {objectifDatabaz} unité(s)";

            // Récupère les négociations de cette mission
            StyliserDataGridView(ucRecapMissionEntierFinal.DataGridViewNegociations);
            ucRecapMissionEntierFinal.DataGridViewNegociations.Rows.Clear();
            ucRecapMissionEntierFinal.DataGridViewNegociations.Columns.Clear();

            ucRecapMissionEntierFinal.DataGridViewNegociations.Columns.Add("Espece", "Espèce Alliée");
            ucRecapMissionEntierFinal.DataGridViewNegociations.Columns.Add("QuantiteNegociee", "Quantité Négociée (Databaz)");

            if (MesDatas.DsGlobal.Tables.Contains("Negocier") && MesDatas.DsGlobal.Tables.Contains("Espece"))
            {
                DataTable dtNegocier = MesDatas.DsGlobal.Tables["Negocier"];
                DataTable dtEspece = MesDatas.DsGlobal.Tables["Espece"];

                string filtre = $"nomPlanete = '{planeteCourante.Replace("'", "''")}' AND numeroMission = {numCourant}";
                DataRow[] lignesNegociation = dtNegocier.Select(filtre);

                foreach (DataRow dr in lignesNegociation)
                {
                    int idEspece = Convert.ToInt32(dr["idEspeceAllie"]);
                    int qte = Convert.ToInt32(dr["qteDataBaz"]);

                    DataRow[] lignesEspece = dtEspece.Select($"id = {idEspece}");
                    string nomEspece = lignesEspece.Length > 0 ? lignesEspece[0]["nom"].ToString() : "Inconnue";

                    ucRecapMissionEntierFinal.DataGridViewNegociations.Rows.Add(nomEspece, qte);
                }
            }

            // Si aucune négociation, on affiche quand même la grille vide
        }


        // =====================================================================
        // NAVIGATION DANS LE JOURNAL DE BORD
        // =====================================================================

        // Va à la première entrée du journal
        private void pcbPremierJournal_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MoveFirst();
        }

        // Va à l'entrée précédente du journal
        private void pcbPrecedentJournal_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MovePrevious();
        }

        // Va à l'entrée suivante du journal
        private void pcbSuivantJournal_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MoveNext();
        }

        // Va à la dernière entrée du journal
        private void pcbDernierJournal_Click(object sender, EventArgs e)
        {
            bsJournalDeBord.MoveLast();
        }


        // =====================================================================
        // BOUTON RETOUR ACCUEIL
        // =====================================================================

        // Ferme le tableau de bord et revient au formulaire principal
        private void btnAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // =====================================================================
        // FILTRES
        // =====================================================================

        // Met à jour le texte affiché quand on bouge la barre du budget minimum
        private void hsbFiltreBudgetMinimum_ValueChanged(object sender, EventArgs e)
        {
            txtFiltreBudgetMinimum.Text = $"Budget minimum : {hsbFiltreBudgetMinimum.Value}€";
        }

        // Applique les filtres quand on relâche la barre du budget minimum
        private void hsbFiltreBudgetMinimum_MouseUp(object sender, MouseEventArgs e)
        {
            pcbAppliquerFiltres_Click(sender, EventArgs.Empty);
        }

        // Met à jour le texte affiché quand on bouge la barre du budget maximum
        private void hsbFiltreBudgetMaximum_ValueChanged(object sender, EventArgs e)
        {
            txtFiltreBudgetMaximum.Text = $"Budget maximum : {hsbFiltreBudgetMaximum.Value}€";
        }

        // Applique les filtres quand on relâche la barre du budget maximum
        private void hsbFiltreBudgetMaximum_MouseUp(object sender, MouseEventArgs e)
        {
            pcbAppliquerFiltres_Click(sender, EventArgs.Empty);
        }

        // Applique les filtres quand on change la planète sélectionnée
        private void cboFiltrePlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcbAppliquerFiltres_Click(sender, EventArgs.Empty);
        }

        // Applique les filtres quand on change le chef sélectionné
        private void cboFiltreChef_SelectedIndexChanged(object sender, EventArgs e)
        {
            pcbAppliquerFiltres_Click(sender, EventArgs.Empty);
        }

        // Quand on coche "Missions passées" : décoche les autres cases et applique le filtre
        private void cboMissionPasse_CheckedChanged(object sender, EventArgs e)
        {
            if (cboMissionPasse.Checked)
            {
                cboMissionFutur.Checked = false;
                cboMissionPresent.Checked = false;
            }
            pcbAppliquerFiltres_Click(sender, e);
        }

        // Quand on coche "Missions en cours" : décoche les autres cases et applique le filtre
        private void cboMissionPresent_CheckedChanged(object sender, EventArgs e)
        {
            if (cboMissionPresent.Checked)
            {
                cboMissionPasse.Checked = false;
                cboMissionFutur.Checked = false;
            }
            pcbAppliquerFiltres_Click(sender, e);
        }

        // Quand on coche "Missions futures" : décoche les autres cases et applique le filtre
        private void cboMissionFutur_CheckedChanged(object sender, EventArgs e)
        {
            if (cboMissionFutur.Checked)
            {
                cboMissionPasse.Checked = false;
                cboMissionPresent.Checked = false;
            }
            pcbAppliquerFiltres_Click(sender, e);
        }

        // Applique tous les filtres actifs et met à jour l'affichage du carrousel
        private void pcbAppliquerFiltres_Click(object sender, EventArgs e)
        {
            // Si le filtrage est désactivé (pendant le reset), on ne fait rien
            if (_filtrageDesactive)
            {
                return;
            }

            DataTable dtToutesMissions = MesDatas.DsGlobal.Tables["Mission"];

            // Crée une table vide avec la même structure pour y copier les missions filtrées
            dtMissionsCourantes = dtToutesMissions.Clone();

            int minBudget = hsbFiltreBudgetMinimum.Value;
            int maxBudget = hsbFiltreBudgetMaximum.Value;

            // Récupère la planète et le chef sélectionnés dans les ComboBox
            string filtrePlanete = cboFiltrePlanete.SelectedValue?.ToString() ?? "Toutes les planètes";
            string filtreChef = cboFiltreChef.SelectedValue?.ToString() ?? "";

            foreach (DataRow row in dtToutesMissions.Rows)
            {
                // --- Filtre 1 : Budget ---
                int budget = Convert.ToInt32(row["budget"]);
                if (budget < minBudget || budget > maxBudget)
                {
                    continue; // Budget hors de la fourchette → on passe à la suivante
                }

                // --- Filtre 2 : Période (passée / en cours / future) ---
                bool statutValide = false;
                bool aucunFiltreDate = !cboMissionPasse.Checked && !cboMissionPresent.Checked && !cboMissionFutur.Checked;

                // EstMissionEnCours renvoie : 0 = en cours, -1 = future, 1 = passée
                int statutMission = EstMissionEnCours(row["nomPlanete"].ToString(), Convert.ToInt32(row["numero"]));

                if (aucunFiltreDate)
                {
                    // Aucune case cochée → toutes les missions passent
                    statutValide = true;
                }
                else
                {
                    if (cboMissionPasse.Checked && statutMission == 1) statutValide = true;
                    if (cboMissionPresent.Checked && statutMission == 0) statutValide = true;
                    if (cboMissionFutur.Checked && statutMission == -1) statutValide = true;
                }

                if (!statutValide)
                {
                    continue; // Période ne correspond pas → on passe à la suivante
                }

                // --- Filtre 3 : Planète ---
                if (filtrePlanete != "Toutes les planètes" && row["nomPlanete"].ToString() != filtrePlanete)
                {
                    continue; // Planète ne correspond pas → on passe à la suivante
                }

                // --- Filtre 4 : Chef de mission ---
                // filtreChef est vide si "Tous les chefs" est sélectionné
                if (filtreChef != "" && row["matriculeChef"].ToString() != filtreChef)
                {
                    continue; // Chef ne correspond pas → on passe à la suivante
                }

                // --- Tous les filtres sont passés → on garde cette mission ---
                dtMissionsCourantes.ImportRow(row);
            }

            // Met à jour les sources de données des cartes mission
            for (int i = 0; i < bsMissions.Count; i++)
            {
                bsMissions[i].DataSource = dtMissionsCourantes;
            }

            // Remet la pagination au début après un changement de filtre
            indexRecapMission = 0;
            AfficherMissionsVisibles();

            // Gère le cas où aucun résultat ne correspond aux filtres
            if (dtMissionsCourantes.Rows.Count == 0)
            {
                // Cache toutes les cartes et le récap complet
                foreach (var uc in ucMissions)
                {
                    uc.Visible = false;
                }
                ucRecapMissionEntierFinal.Visible = false;
                missionOuverte = -1;

                // Affiche le message "aucun résultat"
                pnlConteneurMission.BackColor = Color.Black;
                txtAucunMissionCorrespond.Visible = true;
            }
            else
            {
                // Cache le message "aucun résultat" et réaffiche les cartes
                txtAucunMissionCorrespond.Visible = false;
                pnlConteneurMission.BackColor = Color.Transparent;
                pnlConteneurMission.SendToBack();
                AfficherMissionsVisibles();
                ucRecapMissionEntierFinal.Visible = false;
            }
        }

        // Remplit les ComboBox de filtres avec les planètes et chefs disponibles
        private void InitialiserFiltresCombobox()
        {
            // On désactive le filtrage pendant l'initialisation pour éviter les déclenchements en cascade
            _filtrageDesactive = true;

            DataTable dtMissions = MesDatas.DsGlobal.Tables["Mission"];
            DataTable dtMembres = MesDatas.DsGlobal.Tables["Membre"];

            // --- ComboBox des planètes ---
            DataTable dtPlanetesFiltre = new DataTable();
            dtPlanetesFiltre.Columns.Add("nomPlanete", typeof(string));

            // Option par défaut pour afficher toutes les planètes
            dtPlanetesFiltre.Rows.Add("Toutes les planètes");

            // Récupère les noms de planètes uniques parmi toutes les missions
            var planetesUniques = dtMissions.AsEnumerable()
                .Select(r => r.Field<string>("nomPlanete"))
                .Distinct();

            foreach (string planete in planetesUniques)
            {
                dtPlanetesFiltre.Rows.Add(planete);
            }

            cboFiltrePlanete.DataSource = dtPlanetesFiltre;
            cboFiltrePlanete.DisplayMember = "nomPlanete";
            cboFiltrePlanete.ValueMember = "nomPlanete";
            cboFiltrePlanete.DropDownStyle = ComboBoxStyle.DropDownList; // Pas de saisie manuelle
            cboFiltrePlanete.SelectedIndex = 0;

            // --- ComboBox des chefs ---
            DataTable dtChefsFiltre = new DataTable();
            dtChefsFiltre.Columns.Add("matricule", typeof(string));
            dtChefsFiltre.Columns.Add("nomComplet", typeof(string));

            // Option par défaut pour afficher tous les chefs
            dtChefsFiltre.Rows.Add("", "Tous les chefs");

            // Récupère les matricules uniques des chefs ayant dirigé au moins une mission
            var chefsUniques = dtMissions.AsEnumerable()
                .Select(r => r.Field<string>("matriculeChef"))
                .Distinct();

            foreach (string matricule in chefsUniques)
            {
                DataRow[] ligneMembre = dtMembres.Select($"matricule = '{matricule}'");
                if (ligneMembre.Length > 0)
                {
                    string nomComplet = $"{ligneMembre[0]["nom"]} {ligneMembre[0]["prenom"]}";
                    dtChefsFiltre.Rows.Add(matricule, nomComplet);
                }
            }

            cboFiltreChef.DataSource = dtChefsFiltre;
            cboFiltreChef.DisplayMember = "nomComplet";
            cboFiltreChef.ValueMember = "matricule";
            cboFiltreChef.DropDownStyle = ComboBoxStyle.DropDownList; // Pas de saisie manuelle
            cboFiltreChef.SelectedIndex = 0;

            // Réactive le filtrage maintenant que l'initialisation est terminée
            _filtrageDesactive = false;
        }

        // Remet tous les filtres à leur valeur par défaut
        private void pcbResetFiltres_Click(object sender, EventArgs e)
        {
            // On désactive le filtrage pour éviter qu'il se déclenche à chaque reset individuel
            _filtrageDesactive = true;

            cboFiltreChef.SelectedIndex = 0;
            cboFiltrePlanete.SelectedIndex = 0;

            hsbFiltreBudgetMaximum.Value = hsbFiltreBudgetMaximum.Maximum - 999;
            hsbFiltreBudgetMinimum.Value = hsbFiltreBudgetMinimum.Minimum;

            cboMissionFutur.Checked = false;
            cboMissionPresent.Checked = false;
            cboMissionPasse.Checked = false;

            // Réactive le filtrage et l'applique une seule fois avec les valeurs par défaut
            _filtrageDesactive = false;
            pcbAppliquerFiltres_Click(sender, e);
        }


        // =====================================================================
        // ÉDITION D'UNE MISSION
        // =====================================================================

        // Ouvre le formulaire d'édition pour la mission actuellement ouverte dans le récap
        private void OuvrirEditionMission(int missionIndex)
        {
            DataTable dtMissions = this.dtMissionsCourantes;
            DataRow drMission = dtMissions.Rows[missionOuverte];
            string planeteCourante = drMission["nomPlanete"].ToString();
            string numCourant = drMission["numero"].ToString();

            frmEditionMission formEdition = new frmEditionMission(planeteCourante, Convert.ToInt32(numCourant));

            // Si l'édition est confirmée (DialogResult.OK), on recharge les données et le récap
            if (formEdition.ShowDialog() == DialogResult.OK)
            {
                SAE24_Stargate.frmStargate.ChargerBaseComplete();
                AfficherRecapEntier(missionOuverte);
            }
        }


        // =====================================================================
        // CHOIX DU FOND D'ÉCRAN
        // =====================================================================

        // Active le fond coloré (image de test) et décoche les autres options
        private void cboFondColore_CheckedChanged(object sender, EventArgs e)
        {
            if (cboFondColore.Checked)
            {
                cboFondPasColore.Checked = false;
                cboChoixCouleur.Checked = false;
                txtCodeRGB.Visible = false;
                pnlCouleurChoisie.BackColor = Color.Black;
                this.BackgroundImage = System.Drawing.Image.FromFile("image/fondTestTDB.jpg");
            }

            // Si aucune option n'est cochée, on remet celle-ci par défaut
            if (!cboFondColore.Checked && !cboFondPasColore.Checked && !cboChoixCouleur.Checked)
            {
                cboFondColore.Checked = true;
            }
        }

        // Active le fond sans couleur (image officielle) et décoche les autres options
        private void cboFondPasColore_CheckedChanged(object sender, EventArgs e)
        {
            if (cboFondPasColore.Checked)
            {
                cboFondColore.Checked = false;
                cboChoixCouleur.Checked = false;
                txtCodeRGB.Visible = false;
                pnlCouleurChoisie.BackColor = Color.Black;
                this.BackgroundImage = System.Drawing.Image.FromFile("image/fondPourTableauDeBordV2.png");
            }

            // Si aucune option n'est cochée, on remet celle-ci par défaut
            if (!cboFondColore.Checked && !cboFondPasColore.Checked && !cboChoixCouleur.Checked)
            {
                cboFondPasColore.Checked = true;
            }
        }

        // Ouvre un sélecteur de couleur et applique la couleur choisie comme fond
        private void cboChoixCouleur_Click(object sender, EventArgs e)
        {
            if (cboChoixCouleur.Checked)
            {
                cboFondColore.Checked = false;
                cboFondPasColore.Checked = false;

                ColorDialog selecteurCouleur = new ColorDialog();
                if (selecteurCouleur.ShowDialog() == DialogResult.OK)
                {
                    System.Drawing.Color couleurChoisie = selecteurCouleur.Color;
                    this.BackColor = couleurChoisie;
                    this.BackgroundImage = null;
                    pnlCouleurChoisie.BackColor = couleurChoisie;

                    // Affiche le code RGB de la couleur sélectionnée
                    int rouge = couleurChoisie.R;
                    int vert = couleurChoisie.G;
                    int bleu = couleurChoisie.B;
                    txtCodeRGB.Text = $"RGB : {rouge}, {vert}, {bleu}";
                    txtCodeRGB.Visible = true;
                }
            }

            // Si aucune option n'est cochée, on remet le fond sans couleur par défaut
            if (!cboFondColore.Checked && !cboFondPasColore.Checked && !cboChoixCouleur.Checked)
            {
                cboFondPasColore.Checked = true;
            }
        }


        // =====================================================================
        // FERMETURE DU RÉCAP COMPLET
        // =====================================================================

        // Cache le panneau de récapitulatif complet
        private void PictureBoxFermerRecapComplet_Click(object sender, EventArgs e)
        {
            ucRecapMissionEntierFinal.Visible = false;
        }


        // =====================================================================
        // GÉNÉRATION DU PDF
        // =====================================================================

        // Génère et exporte un rapport PDF complet de la mission actuellement ouverte
        private void PictureBoxCréationPDF_Click(object sender, EventArgs e)
        {
            // Vérifie qu'une mission est bien ouverte
            if (missionOuverte < 0)
            {
                MessageBox.Show("Aucune mission ouverte.");
                return;
            }

            // Récupère toutes les tables nécessaires depuis le DataSet
            DataTable dtMissions = this.dtMissionsCourantes;
            DataTable dtMembre = MesDatas.DsGlobal.Tables["Membre"];
            DataTable dtDepense = MesDatas.DsGlobal.Tables["Depense"];
            DataTable dtComposer = MesDatas.DsGlobal.Tables["Composer"];
            DataTable dtCivil = MesDatas.DsGlobal.Tables["Civil"];
            DataTable dtMilitaire = MesDatas.DsGlobal.Tables["Militaire"];
            DataTable dtObjectif = MesDatas.DsGlobal.Tables["ObjectifCapture"];
            DataTable dtCapture = MesDatas.DsGlobal.Tables["Capturer"];
            DataTable dtEspece = MesDatas.DsGlobal.Tables["Espece"];
            DataTable dtJournalDeBord = MesDatas.DsGlobal.Tables["JournalDeBord"];
            DataTable dtTypeDepense = MesDatas.DsGlobal.Tables["TypeDepense"];

            // Récupère les données de base de la mission ouverte
            DataRow drMission = dtMissions.Rows[missionOuverte];
            string planete = drMission["nomPlanete"].ToString();
            int numeroMission = Convert.ToInt32(drMission["numero"]);
            int budgetInitial = 0;
            if (drMission["budget"] != DBNull.Value)
            {
                budgetInitial = Convert.ToInt32(drMission["budget"]);
            }

            // Calcule le total des dépenses et le budget restant
            int totalDepenses = 0;
            foreach (DataRow dr in dtDepense.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission}"))
            {
                totalDepenses += Convert.ToInt32(dr["montant"]);
            }
            int budgetRestant = budgetInitial - totalDepenses;

            // Récupère le nom du chef de mission
            DataRow[] ligneChef = dtMembre.Select($"matricule = '{drMission["matriculeChef"]}'");
            string nomChef = "Inconnu";
            if (ligneChef.Length > 0)
            {
                nomChef = $"{ligneChef[0]["nom"]} {ligneChef[0]["prenom"]}";
            }

            // Détermine le statut textuel de la mission
            int statutMission = EstMissionEnCours(planete, numeroMission);
            string statutTexte = "Terminée";
            if (statutMission == 0)
            {
                statutTexte = "En cours";
            }
            else if (statutMission == -1)
            {
                statutTexte = "Future";
            }

            // ── Initialisation du document PDF ──────────────────────────────────
            PdfDocument document = new PdfDocument();
            document.Info.Title = $"Mission {planete}-{numeroMission}";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XTextFormatter tf = new XTextFormatter(gfx);

            double margeG = 40;
            double largeurPage = page.Width - margeG * 2;
            double y = 40; // Position verticale courante

            // Définition des polices utilisées dans le PDF
            XFont fontTitre = new XFont("Agency FB", 20, XFontStyle.Bold);
            XFont fontSection = new XFont("Agency FB", 13, XFontStyle.Bold);
            XFont fontGras = new XFont("Agency FB", 11, XFontStyle.Bold);
            XFont fontNormal = new XFont("Agency FB", 11, XFontStyle.Regular);
            XFont fontPetit = new XFont("Agency FB", 9, XFontStyle.Regular);

            // Couleur dorée style Stargate
            XColor couleurSection = XColor.FromArgb(184, 134, 11);

            // ── Fonctions locales pour construire le PDF ─────────────────────────

            // Vérifie si on est en bas de page et crée une nouvelle page si nécessaire
            void verifierPage()
            {
                if (y > page.Height - 60)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    tf = new XTextFormatter(gfx);
                    y = 40;
                }
            }

            // Dessine un titre de section en doré avec un trait en dessous
            void ajouterSection(string titre)
            {
                verifierPage();
                y += 8;
                gfx.DrawString(titre, fontSection, new XSolidBrush(couleurSection),
                    new XRect(margeG, y, largeurPage, 16), XStringFormats.CenterLeft);
                y += 18;
                gfx.DrawLine(new XPen(couleurSection, 0.5), margeG, y, margeG + largeurPage, y);
                y += 6;
            }

            // Dessine une ligne "label : valeur" avec fond alterné optionnel
            void ajouterLigne(string label, string valeur, bool fond = false, XBrush couleurTexte = null)
            {
                verifierPage();
                if (fond)
                {
                    gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(235, 235, 235)), margeG, y - 1, largeurPage, 14);
                }

                XBrush pinceau = couleurTexte ?? XBrushes.Black;
                gfx.DrawString(label + " :", fontGras, pinceau, new XRect(margeG, y, largeurPage / 2, 14), XStringFormats.CenterLeft);
                gfx.DrawString(valeur, fontNormal, pinceau, new XRect(margeG + largeurPage / 2, y, largeurPage / 2, 14), XStringFormats.CenterLeft);
                y += 16;
            }

            // Dessine un tableau à partir d'un DataTable avec proportions de colonnes optionnelles
            void ajouterTableau(DataTable tableDonnees, string messageVide, int[] proportions = null)
            {
                if (tableDonnees.Rows.Count == 0)
                {
                    verifierPage();
                    gfx.DrawString(messageVide, fontPetit, XBrushes.Gray,
                        new XRect(margeG, y, largeurPage, 14), XStringFormats.CenterLeft);
                    y += 18;
                    return;
                }

                verifierPage();

                int nombreColonnes = tableDonnees.Columns.Count;
                double[] largeursColonnes = new double[nombreColonnes];

                // Calcul des largeurs de colonnes selon les proportions fournies ou en parts égales
                if (proportions != null && proportions.Length == nombreColonnes)
                {
                    for (int i = 0; i < nombreColonnes; i++)
                    {
                        largeursColonnes[i] = (largeurPage * proportions[i]) / 100.0;
                    }
                }
                else
                {
                    double largeurEquitable = largeurPage / nombreColonnes;
                    for (int i = 0; i < nombreColonnes; i++)
                    {
                        largeursColonnes[i] = largeurEquitable;
                    }
                }

                // En-tête du tableau (fond noir, texte doré)
                gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(40, 40, 40)), margeG, y, largeurPage, 16);
                double posX = margeG;
                for (int col = 0; col < nombreColonnes; col++)
                {
                    gfx.DrawString(tableDonnees.Columns[col].ColumnName, fontGras, XBrushes.Gold,
                        new XRect(posX + 2, y + 1, largeursColonnes[col] - 4, 14), XStringFormats.CenterLeft);
                    posX += largeursColonnes[col];
                }
                y += 17;

                // Lignes de données avec alternance de fond
                bool ligneAlterne = false;
                foreach (DataRow ligne in tableDonnees.Rows)
                {
                    verifierPage();

                    if (ligneAlterne)
                    {
                        gfx.DrawRectangle(new XSolidBrush(XColor.FromArgb(245, 245, 245)), margeG, y - 1, largeurPage, 14);
                    }

                    posX = margeG;
                    for (int col = 0; col < nombreColonnes; col++)
                    {
                        string texte = ligne[col]?.ToString() ?? "";
                        gfx.DrawString(texte, fontNormal, XBrushes.Black,
                            new XRect(posX + 2, y, largeursColonnes[col] - 4, 14), XStringFormats.CenterLeft);
                        posX += largeursColonnes[col];
                    }

                    y += 15;
                    ligneAlterne = !ligneAlterne;
                }

                y += 4; // Espace de sécurité sous le tableau
            }

            // ── Contenu du PDF ────────────────────────────────────────────────────

            // TITRE PRINCIPAL
            gfx.DrawString($"RAPPORT DE MISSION — {planete}-{numeroMission}",
                fontTitre, new XSolidBrush(couleurSection),
                new XRect(margeG, y, largeurPage, 24), XStringFormats.CenterLeft);
            y += 30;
            gfx.DrawLine(new XPen(couleurSection, 1), margeG, y, margeG + largeurPage, y);
            y += 10;

            // INFORMATIONS GÉNÉRALES
            ajouterSection("INFORMATIONS GÉNÉRALES");
            bool alterner = false;
            ajouterLigne("Planète", planete, alterner); alterner = !alterner;
            ajouterLigne("Numéro", numeroMission.ToString(), alterner); alterner = !alterner;
            ajouterLigne("Chef de mission", nomChef, alterner); alterner = !alterner;
            ajouterLigne("Date de départ", drMission["dateDepart"].ToString(), alterner); alterner = !alterner;
            ajouterLigne("Date de retour", drMission["dateRetour"].ToString(), alterner); alterner = !alterner;
            ajouterLigne("Statut", statutTexte, alterner); alterner = !alterner;
            ajouterLigne("Budget initial", $"{budgetInitial} €", alterner); alterner = !alterner;
            ajouterLigne("Total dépenses", $"{totalDepenses} €", alterner); alterner = !alterner;

            // Le budget restant s'affiche en rouge s'il est inférieur ou égal à 500€
            XBrush couleurBudget = null;
            if (budgetRestant <= 500)
            {
                couleurBudget = XBrushes.Red;
            }
            ajouterLigne("Budget restant", $"{budgetRestant} €", alterner, couleurBudget);

            // FEUILLE DE ROUTE
            ajouterSection("FEUILLE DE ROUTE");
            string feuilleDeRoute = drMission["feuilleDeRoute"]?.ToString();
            if (string.IsNullOrWhiteSpace(feuilleDeRoute))
            {
                feuilleDeRoute = "Aucune feuille de route saisie.";
            }
            verifierPage();
            tf.DrawString(feuilleDeRoute, fontNormal, XBrushes.Black, new XRect(margeG, y, largeurPage, 60));
            y += 65;

            // ÉQUIPE DE LA MISSION
            ajouterSection("ÉQUIPE DE LA MISSION");
            DataTable dtEquipe = new DataTable();
            dtEquipe.Columns.Add("Matricule");
            dtEquipe.Columns.Add("Nom complet");
            dtEquipe.Columns.Add("Planète d'origine");
            dtEquipe.Columns.Add("Métier / Grade");

            foreach (DataRow drComposer in dtComposer.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission}"))
            {
                string matricule = drComposer["matriculeMembre"].ToString();
                DataRow[] ligneMembre = dtMembre.Select($"matricule = '{matricule}'");
                if (ligneMembre.Length == 0) continue;

                string nomComplet = $"{ligneMembre[0]["prenom"]} {ligneMembre[0]["nom"]}";
                string metier = "";
                string planeteOrigine = "";

                if (matricule.StartsWith("M"))
                {
                    DataRow[] ligneMilitaire = dtMilitaire.Select($"matriculeMembre = '{matricule}'");
                    if (ligneMilitaire.Length > 0)
                    {
                        metier = ligneMilitaire[0]["grade"].ToString();
                        planeteOrigine = "Confidentiel";
                    }
                }
                else
                {
                    DataRow[] ligneCivil = dtCivil.Select($"matriculeMembre = '{matricule}'");
                    if (ligneCivil.Length > 0)
                    {
                        metier = ligneCivil[0]["Specialite"].ToString();
                        planeteOrigine = ligneCivil[0]["nomPlaneteOrigine"].ToString();
                    }
                }

                dtEquipe.Rows.Add(matricule, nomComplet, planeteOrigine, metier);
            }
            ajouterTableau(dtEquipe, "Aucun membre enregistré pour cette mission.", new int[] { 10, 30, 30, 30 });

            // SUIVI DES DÉPENSES
            ajouterSection("SUIVI DES DÉPENSES");
            DataTable dtDepenseTemp = new DataTable();
            dtDepenseTemp.Columns.Add("Date");
            dtDepenseTemp.Columns.Add("Type");
            dtDepenseTemp.Columns.Add("Montant");
            dtDepenseTemp.Columns.Add("Motif");

            foreach (DataRow drDepense in dtDepense.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission}"))
            {
                string typeLibele = "Inconnu";
                if (dtTypeDepense != null)
                {
                    DataRow[] ligneType = dtTypeDepense.Select($"id = {drDepense["idTypeDepense"]}");
                    if (ligneType.Length > 0)
                    {
                        typeLibele = ligneType[0]["libelle"].ToString();
                    }
                }
                dtDepenseTemp.Rows.Add(
                    drDepense["dateD"]?.ToString() ?? "",
                    typeLibele,
                    $"{drDepense["montant"]} €",
                    drDepense["motif"]?.ToString() ?? ""
                );
            }
            ajouterTableau(dtDepenseTemp, "Aucune dépense enregistrée.", new int[] { 20, 20, 20, 40 });

            // Ligne récapitulative du budget (rouge si dépassement)
            verifierPage();
            XBrush couleurResume = new XSolidBrush(couleurSection);
            if (budgetRestant < 500)
            {
                couleurResume = XBrushes.Red;
            }
            gfx.DrawString($"Total : {totalDepenses} €  |  Restant : {budgetRestant} €",
                fontGras, couleurResume,
                new XRect(margeG, y, largeurPage, 14), XStringFormats.CenterRight);
            y += 18;

            // BILAN DES CAPTURES
            ajouterSection("BILAN DES CAPTURES D'ESPÈCES");
            var idEspeces = new HashSet<int>();

            foreach (DataRow drEspece in dtObjectif.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission}"))
            {
                idEspeces.Add(Convert.ToInt32(drEspece["idEspeceEnnemi"]));
            }
            foreach (DataRow drEspece in dtCapture.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission}"))
            {
                idEspeces.Add(Convert.ToInt32(drEspece["idEspeceEnnemi"]));
            }

            DataTable dtBilan = new DataTable();
            dtBilan.Columns.Add("Espèce");
            dtBilan.Columns.Add("Objectif");
            dtBilan.Columns.Add("Capturés");
            dtBilan.Columns.Add("Taux");

            foreach (int idEspece in idEspeces)
            {
                DataRow[] ligneEspece = dtEspece.Select($"id = {idEspece}");
                string nomEspece = "Inconnue";
                if (ligneEspece.Length > 0)
                {
                    nomEspece = ligneEspece[0]["nom"].ToString();
                }

                int objectif = 0;
                DataRow[] ligneObjectif = dtObjectif.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission} AND idEspeceEnnemi = {idEspece}");
                if (ligneObjectif.Length > 0)
                {
                    objectif = Convert.ToInt32(ligneObjectif[0]["objectif"]);
                }

                int capture = 0;
                DataRow[] ligneCapture = dtCapture.Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission} AND idEspeceEnnemi = {idEspece}");
                if (ligneCapture.Length > 0)
                {
                    capture = Convert.ToInt32(ligneCapture[0]["nombre"]);
                }

                double taux = 0;
                if (objectif > 0)
                {
                    taux = Math.Round((double)capture / objectif * 100, 1);
                }
                else if (capture > 0)
                {
                    taux = 100.0;
                }

                dtBilan.Rows.Add(nomEspece, objectif.ToString(), capture.ToString(), $"{taux} %");
            }
            ajouterTableau(dtBilan, "Aucune capture enregistrée.", new int[] { 30, 20, 20, 30 });

            // CONTACTS ET INFORMATEURS
            ajouterSection("CONTACTS ET INFORMATEURS");
            DataTable dtContacts = new DataTable();
            dtContacts.Columns.Add("Informateur");
            dtContacts.Columns.Add("Date contact");
            dtContacts.Columns.Add("Somme versée");
            dtContacts.Columns.Add("Appréciation");

            if (MesDatas.DsGlobal.Tables.Contains("Contact"))
            {
                foreach (DataRow drContact in MesDatas.DsGlobal.Tables["Contact"].Select($"nomPlanete = '{planete}' AND numeroMission = {numeroMission}"))
                {
                    string dateContact = "";
                    if (drContact["dateC"] != DBNull.Value)
                    {
                        dateContact = Convert.ToDateTime(drContact["dateC"]).ToString("dd/MM/yyyy");
                    }

                    string somme = "0,00 €";
                    if (drContact["sommeVersee"] != DBNull.Value)
                    {
                        somme = $"{Convert.ToDecimal(drContact["sommeVersee"]):N2} €";
                    }

                    dtContacts.Rows.Add(drContact["nomCodeInformateur"], dateContact, somme, drContact["appreciation"]);
                }
            }
            ajouterTableau(dtContacts, "Aucun contact répertorié.", new int[] { 10, 20, 20, 50 });

            // JOURNAL DE BORD
            ajouterSection("JOURNAL DE BORD");
            DataRow[] entrees = dtJournalDeBord.Select($"nomPlanete = '{planete}' AND numero = {numeroMission}");

            if (entrees.Length == 0)
            {
                verifierPage();
                gfx.DrawString("Aucune entrée dans le journal de bord.", fontPetit, XBrushes.Gray,
                    new XRect(margeG, y, largeurPage, 14), XStringFormats.CenterLeft);
                y += 18;
            }
            else
            {
                foreach (DataRow drJournal in entrees)
                {
                    verifierPage();

                    // Récupère la date de l'entrée si elle existe
                    string dateJournal = "";
                    if (drJournal.Table.Columns.Contains("dateJ") && drJournal["dateJ"] != DBNull.Value)
                    {
                        dateJournal = Convert.ToDateTime(drJournal["dateJ"]).ToString("dd/MM/yyyy");
                    }

                    // Récupère le contenu de l'entrée
                    string contenu = "";
                    if (drJournal.Table.Columns.Contains("contenu"))
                    {
                        contenu = drJournal["contenu"]?.ToString() ?? "";
                    }
                    else
                    {
                        contenu = drJournal[drJournal.Table.Columns.Count - 1]?.ToString() ?? "";
                    }

                    // Affiche la date en gras puis le texte en dessous
                    gfx.DrawString($"— {dateJournal}", fontGras, XBrushes.Black,
                        new XRect(margeG, y, largeurPage, 14), XStringFormats.CenterLeft);
                    y += 15;
                    verifierPage();

                    string texteContenu = string.IsNullOrWhiteSpace(contenu) ? "(entrée vide)" : contenu;
                    tf.DrawString(texteContenu, fontNormal, XBrushes.Black,
                        new XRect(margeG + 10, y, largeurPage - 10, 40));
                    y += 45;
                }
            }

            // Petit texte de pied de page discret
            verifierPage();
            gfx.DrawString("Document généré automatiquement par le Tableau de Bord Stargate.",
                fontPetit, XBrushes.Gray,
                new XRect(margeG, y + 10, largeurPage, 14), XStringFormats.CenterRight);

            // ── Sauvegarde du PDF ─────────────────────────────────────────────
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers PDF|*.pdf";
            saveFileDialog.FileName = $"Mission_{planete}_{numeroMission}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
                MessageBox.Show("PDF exporté avec succès !", "Export réussi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // =====================================================================
        // UTILITAIRES
        // =====================================================================

        // Vérifie si une mission est passée, en cours ou future
        // Retourne : 0 = en cours, -1 = future, 1 = passée (ou non déterminée)
        private int EstMissionEnCours(string nomPlanete, int numeroMission)
        {
            DataTable dtMissions = MesDatas.DsGlobal.Tables["Mission"];

            // Cherche la ligne de la mission dans la table
            // .Replace("'", "''") protège contre les apostrophes dans les noms de planètes
            DataRow[] lignes = dtMissions.Select($"nomPlanete = '{nomPlanete.Replace("'", "''")}' AND numero = {numeroMission}");
            DataRow drMission = lignes[0];

            // Essaie de convertir les dates de départ et de retour
            if (DateTime.TryParse(drMission["dateDepart"].ToString(), out DateTime dateDepart) &&
                DateTime.TryParse(drMission["dateRetour"].ToString(), out DateTime dateRetour))
            {
                DateTime aujourdHui = DateTime.Today;

                if (aujourdHui >= dateDepart && aujourdHui <= dateRetour)
                {
                    return 0; // Mission en cours
                }
                else if (aujourdHui < dateDepart)
                {
                    return -1; // Mission future
                }
            }

            return 1; // Mission passée (ou dates non lisibles)
        }

        // Applique un style uniforme "Stargate" (noir et doré) à un DataGridView
        private void StyliserDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false; // Cache la colonne vide à gauche
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.Black;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Style des cellules
            DataGridViewCellStyle styleCellule = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.White,
                Font = new Font("Agency FB", 14, FontStyle.Regular),
                SelectionBackColor = Color.FromArgb(50, 50, 50),
                SelectionForeColor = Color.Gold,
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            dgv.DefaultCellStyle = styleCellule;

            // Style des en-têtes de colonnes
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Black,
                ForeColor = Color.Gold,
                Font = new Font("Agency FB", 13, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgv.EnableHeadersVisualStyles = false; // Nécessaire pour appliquer notre style
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        }
    }
}