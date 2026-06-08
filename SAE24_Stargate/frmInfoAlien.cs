using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ucAlien;

namespace SAE24_Stargate
{
    public partial class frmInfoAlien : Form
    {
        public frmInfoAlien()
        {
            InitializeComponent();
        }

        private DataTable dtAliens; // DataTable globale avec toutes les infos

        private void frmInfoAlien_Load(object sender, EventArgs e)
        {
            try
            {
                construireDtAliens(); // construit la DataTable avec toutes les infos nécessaires pour les filtres et l'affichage
                remplirComboCouleur(); // remplit les ComboBox avec les valeurs uniques de la DataTable
                remplirComboNom();
                remplirComboPlanete();
                remplirComboCategorie();
                appliquerFiltres(); // applique les filtres pour afficher tous les aliens au départ (filtre vide)
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void construireDtAliens()
        {
            // Création de la DataTable avec toutes les colonnes nécessaires
            dtAliens = new DataTable();
            dtAliens.Columns.Add("id", typeof(int));
            dtAliens.Columns.Add("nom", typeof(string));
            dtAliens.Columns.Add("couleur", typeof(string));
            dtAliens.Columns.Add("categorie", typeof(string));
            dtAliens.Columns.Add("origine", typeof(string));

            foreach (DataRow ligne in MesDatas.DsGlobal.Tables["Espece"].Rows) // pour chaque espèce, on récupère les infos nécessaires pour remplir la DataTable
            {
                int idEspece = Convert.ToInt32(ligne["id"]); // ID de l'espèce
                string nom = ligne["nom"].ToString(); // Nom de l'espèce
                string couleur = ligne["couleur"].ToString(); // Couleur de l'espèce

                // Catégorie
                string categorie; // On vérifie si l'espèce est présente dans la table Ennemi ou Allie pour déterminer sa catégorie
                DataRow[] ligneEnnemi = MesDatas.DsGlobal.Tables["Ennemi"].Select($"idEspece = '{idEspece}'");
                DataRow[] ligneAllie = MesDatas.DsGlobal.Tables["Allie"].Select($"idEspece = '{idEspece}'");
                if (ligneEnnemi.Length > 0) // Si l'espèce est présente dans la table Ennemi, elle est catégorisée comme "Ennemi"
                    categorie = "Ennemi";
                else if (ligneAllie.Length > 0) // Si l'espèce est présente dans la table Allie, elle est catégorisée comme "Allie"
                    categorie = "Allie";
                else
                    categorie = "Neutre";  // Si l'espèce n'est présente ni dans la table Ennemi ni dans la table Allie, elle est catégorisée comme "Neutre"

                // Origine
                string origine = "";
                DataRow[] ligneHabiter = MesDatas.DsGlobal.Tables["Habiter"].Select($"idEspece = '{idEspece}'"); // On récupère toutes les planètes associées à l'espèce dans la table Habiter pour construire la chaîne d'origine
                if (ligneHabiter.Length == 0)
                {
                    origine = "Inconnu";
                }
                else
                {
                    foreach (DataRow rowHabiter in ligneHabiter) // pour chaque planète associée à l'espèce, on ajoute son nom à la chaîne d'origine
                        origine += rowHabiter["NomPlanete"].ToString() + ", "; // On ajoute chaque planète à la chaîne d'origine, séparée par une virgule
                    origine = origine.TrimEnd(',', ' '); // enlève la dernière virgule
                }

                dtAliens.Rows.Add(idEspece, nom, couleur, categorie, origine); // On ajoute une ligne à la DataTable avec toutes les infos de l'espèce
            }
        }

        private void remplirComboCouleur()
        {
            cboCouleur.Items.Add("Toutes"); // Ajout de l'option "Toutes" (option de base) pour ne pas filtrer par couleur
            foreach (DataRow ligne in dtAliens.Rows) // pour chaque ligne de la DataTable, on récupère la couleur et on l'ajoute à la ComboBox si elle n'est pas déjà présente
            {
                string couleur = ligne["couleur"].ToString();
                if (!cboCouleur.Items.Contains(couleur))
                    cboCouleur.Items.Add(couleur);
            }
            cboCouleur.SelectedIndex = 0;
        }

        private void remplirComboNom()
        {
            cboNom.Items.Add("Tous"); // Ajout de l'option "Tous" (option de base) pour ne pas filtrer par nom
            foreach (DataRow ligne in dtAliens.Rows) // pour chaque ligne de la DataTable, on récupère le nom et on l'ajoute à la ComboBox si elle n'est pas déjà présente
            {
                string nom = ligne["nom"].ToString();
                if (!cboNom.Items.Contains(nom))
                    cboNom.Items.Add(nom);
            }
            cboNom.SelectedIndex = 0;
        }

        private void remplirComboPlanete()
        {
            cboPlanete.Items.Add("Toutes"); // Ajout de l'option "Toutes" (option de base) pour ne pas filtrer par planète
            foreach (DataRow ligne in dtAliens.Rows)
            {
                // L'origine peut contenir plusieurs planètes séparées par des virgules
                string[] planetes = ligne["origine"].ToString().Split(','); // On split la chaîne d'origine pour récupérer chaque planète individuellement
                foreach (string planete in planetes) // pour chaque planète de l'origine, on la nettoie et on l'ajoute à la ComboBox si elle n'est pas déjà présente
                {
                    string planeteNettoyee = planete.Trim(); // On nettoie la chaîne de la planète en enlevant les espaces avant et après (liés au split)
                    if (!cboPlanete.Items.Contains(planeteNettoyee) && planeteNettoyee != "Inconnu")
                        cboPlanete.Items.Add(planeteNettoyee);
                }
            }
            cboPlanete.SelectedIndex = 0;
        }

        private void remplirComboCategorie() // Les catégories sont fixes (Allie, Ennemi, Neutre), on les ajoute directement à la ComboBox
        {
            cboCategorie.Items.Add("Toutes");
            cboCategorie.Items.Add("Allie");
            cboCategorie.Items.Add("Ennemi");
            cboCategorie.Items.Add("Neutre");
            cboCategorie.SelectedIndex = 0;
        }

        // à chaque changement de sélection dans une ComboBox, on applique les filtres pour mettre à jour l'affichage des aliens
        private void cboNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            appliquerFiltres();
        }

        private void cboCouleur_SelectedIndexChanged(object sender, EventArgs e)
        {
            appliquerFiltres();
        }

        private void cboPlanete_SelectedIndexChanged(object sender, EventArgs e)
        {
            appliquerFiltres();
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            appliquerFiltres();
        }

        private void appliquerFiltres() // construit une chaîne de filtre à partir des sélections des ComboBox et applique ce filtre à la DataTable pour afficher les aliens correspondants
        {

            if (cboCouleur.SelectedItem == null || cboNom.SelectedItem == null || cboPlanete.SelectedItem == null || cboCategorie.SelectedItem == null) return; // Vérifie que les ComboBox ont une sélection avant de construire le filtre

            string couleurFiltre = cboCouleur.SelectedItem.ToString(); // Récupère les sélections des ComboBox pour construire le filtre
            string nomFiltre = cboNom.SelectedItem.ToString();
            string planeteFiltre = cboPlanete.SelectedItem.ToString();
            string categorieFiltre = cboCategorie.SelectedItem.ToString();

            string filtre = ""; // Construction de la chaîne de filtre en fonction des sélections des ComboBox. Si une ComboBox est sur l'option de base (ex "Toutes"), elle n'ajoute pas de condition au filtre

            if (couleurFiltre != "Toutes") // L'option de base pour la couleur est "Toutes", si la sélection est différente, on ajoute une condition de filtre pour la couleur
            {
                if (filtre != "") filtre += " AND "; // Si le filtre n'est pas vide, on ajoute "AND" pour séparer les conditions
                filtre += $"couleur = '{couleurFiltre}'";
            }

            if (nomFiltre != "Tous") // pareillement ...
            {
                if (filtre != "") filtre += " AND ";
                filtre += $"nom = '{nomFiltre}'";
            }

            if (planeteFiltre != "Toutes")
            {
                if (filtre != "") filtre += " AND ";
                filtre += $"origine LIKE '%{planeteFiltre}%'"; // Pour la planète, comme une espèce peut avoir plusieurs planètes d'origine, on utilise LIKE pour vérifier si la chaîne d'origine contient la planète sélectionnée
            }

            if (categorieFiltre != "Toutes")
            {
                if (filtre != "") filtre += " AND ";
                filtre += $"categorie = '{categorieFiltre}'";
            }

            genererUcAlien(filtre); // on génère les UserControls des aliens en appliquant le filtre
        }

        private void genererUcAlien(string filtre)
        {
            flpAlien.Controls.Clear(); // On vide le FlowLayoutPanel avant de générer les UserControls pour éviter d'avoir des doublons à chaque changement de filtre

            DataRow[] aliensFiltres = dtAliens.Select(filtre); // On applique le filtre à la DataTable pour récupérer les lignes correspondantes aux sélections des ComboBox

            foreach (DataRow ligne in aliensFiltres) // pour chaque ligne correspondant au filtre, on génère un UserControl ucAlienCarte avec les infos de l'espèce et on l'ajoute au FlowLayoutPanel
            {
                int idEspece = Convert.ToInt32(ligne["id"]);

                ucAlienCarte uc = new ucAlienCarte();
                uc.NomAlien = ligne["nom"].ToString();
                uc.CouleurAlien = ligne["couleur"].ToString();
                uc.ImageAlien = Image.FromFile($@"alien\{ligne["nom"].ToString()}.png");
                uc.CategorieAlien = ligne["categorie"].ToString();
                uc.AjouterOrigine(ligne["origine"].ToString());

                uc.pcbAlien.Click += (s, args) => // Ajout d'un événement Click sur le PictureBox de l'UserControl pour ouvrir le formulaire de détail de l'alien
                {
                    frmDetailAlien detail = new frmDetailAlien(idEspece);
                    detail.Show();
                };

                flpAlien.Controls.Add(uc);
            }
        }

        private void pcbResetFiltres_Click(object sender, EventArgs e) // Réinitialise les ComboBox pour enlever tous les filtres et afficher tous les aliens
        {
            cboCouleur.SelectedIndex = 0;
            cboNom.SelectedIndex = 0;
            cboPlanete.SelectedIndex = 0;
            cboCategorie.SelectedIndex = 0;
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}