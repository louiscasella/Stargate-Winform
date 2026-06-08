using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SAE24_Stargate;
using static System.Net.Mime.MediaTypeNames;
using ucInfoPlanetes;
using ucAlien;
using ucAlien_formPlanete;

namespace SAE24_Stargate
{
    public partial class frmMoreInfoPlanetes : Form
    {
        public string planete;
        public frmMoreInfoPlanetes(string nomPlanete)
        {
            InitializeComponent();
            planete = nomPlanete; // recuperer le nom de la planète sélectionnée depuis le formulaire précédent
        }

        private void frmMoreInfoPlanetes_Load(object sender, EventArgs e)
        {

            genererUcPlanete(planete); // générer le UserControl de la planète sélectionnée

            genererUcAlien(); // générer les UserControl des aliens présents sur la planète sélectionnée

            genererMissions(); // générer les missions effectuées sur la planète sélectionnée

        }

        private void genererUcPlanete(String planete)
        {
            // recupérer les données de la planète sélectionnée
            DataRow[] lignePlanete = MesDatas.DsGlobal.Tables["Planete"].Select($"Nom = '{planete}'");

            if (lignePlanete.Length > 0)
            {
                DataRow ligne = lignePlanete[0]; // on prend la première ligne (il ne devrait y en avoir qu'une)

                ucPlanete uc = new ucPlanete();
                uc.NomPlanete = ligne["nom"].ToString();

                if (ligne["temperature"] == DBNull.Value) // si la température est inconnue, on donne "inconnu" au user control
                {
                    uc.Temperature = "Inconnu";
                }
                else
                {
                    uc.Temperature = ligne["temperature"].ToString(); // sinon on affiche la température
                }
                if (ligne["gravite"] == DBNull.Value) // pareillement ...
                {
                    uc.Gravite = "Inconnu";
                }
                else
                {
                    uc.Gravite = ligne["gravite"].ToString();
                }
                if (ligne["dataBazON"] == DBNull.Value) // si la donnée de la base de données est inconnue, on affiche renvoie -1 au user control pour qu'il affiche "Inconnu"
                {
                    uc.QtDataBaz = -1;
                }
                else if (Convert.ToInt32(ligne["dataBazON"]) == 1) // sinon, si la donnée de la base de données est égale à 1, on affiche la présence de dataBAZ dans le user control
                {
                    uc.QtDataBaz = 1;
                }
                else // sinon, on affiche l'absence de dataBAZ dans le user control
                {
                    uc.QtDataBaz = 0;
                }

                uc.ImagePlanete = System.Drawing.Image.FromFile($@"planete\{ligne["nom"].ToString()}.png");

                pnlInfoPla.Controls.Add(uc); // ajouter le UserControl de la planète dans le panel prévu à cet effet
            }
        }

        private void genererUcAlien()
        {
            DataRow[] ligneHabiter = MesDatas.DsGlobal.Tables["Habiter"].Select($"NomPlanete = '{planete}'"); // chercher les lignes correspondantes dans la table Habiter pour savoir quels aliens vivent sur la planète sélectionnée

            int Haut = 0;

            foreach (DataRow row in ligneHabiter)
            {
                // Récupère l'idEspece depuis Habiter
                int idEspece = Convert.ToInt32(row["idEspece"]); // on récupère l'idEspece pour pouvoir chercher les informations de l'espèce dans la table Espece

                // Cherche l'espece correspondante dans la table Espece
                DataRow[] ligneEspece = MesDatas.DsGlobal.Tables["Espece"].Select($"id = '{idEspece}'"); // on cherche la ligne de la table Espece qui correspond à l'idEspece récupéré dans Habiter

                if (ligneEspece.Length > 0)
                {
                    string nomAlien = ligneEspece[0]["nom"].ToString();
                    string couleurAlien = ligneEspece[0]["couleur"].ToString();

                    // Crée et rempli le UserControl
                    ucAlienPlanete uc = new ucAlienPlanete();
                    uc.NomAlien = nomAlien;
                    uc.ImageAlien = System.Drawing.Image.FromFile($@"Alien\{couleurAlien}.png"); // on utilise la couleur de l'espèce pour afficher l'image correspondante

                    DataRow[] ligneEnnemi = MesDatas.DsGlobal.Tables["Ennemi"].Select($"idEspece = '{idEspece}'"); // cherche les lignes correspondantes dans la table Ennemi pour savoir si c'est un allié ou un ennemi

                    if (ligneEnnemi.Length > 0)
                        uc.AllieEnnemi = 1; // Ennemi
                    else
                        uc.AllieEnnemi = 0; // Allié

                    uc.Haut = Haut;
                    uc.Gauche = 0;

                    // Ajoute le UC dans un panel
                    pnlAlienPresence.Controls.Add(uc);

                    Haut += uc.Height;
                }
            }

            if (ligneHabiter.Length == 0) // si pas d'alien alors création d'un label qui indique la non présence
            {
                Label lblAucunAlien = new Label();
                lblAucunAlien.Text = "Aucun alien recensé sur cette planète";
                lblAucunAlien.ForeColor = Color.Gray;
                lblAucunAlien.Font = new Font("Arial", 15, FontStyle.Regular);
                pnlAlienPresence.Controls.Add(lblAucunAlien);
            }

        }

        private void genererMissions()
        {
            DataRow[] ligneMissions = MesDatas.DsGlobal.Tables["Mission"].Select($"nomPlanete = '{planete}'"); // chercher les lignes correspondantes dans la table Mission pour savoir quelles missions ont été effectuées sur la planète sélectionnée

            int Haut = 0;

            foreach (DataRow row in ligneMissions)
            {
                Label lblMission = new Label(); // créer un label pour chaque mission trouvée
                lblMission.Text = $"Mission {row["numero"]} | Départ : {Convert.ToDateTime(row["dateDepart"]).ToShortDateString()} | Retour : {Convert.ToDateTime(row["dateRetour"]).ToShortDateString()} | Chef : {row["matriculeChef"]}";

                lblMission.ForeColor = Color.White; // couleur
                lblMission.Font = new Font("Arial", 10, FontStyle.Regular); // police
                lblMission.AutoSize = true;

                lblMission.Top = Haut;
                lblMission.Left = 0;

                pnlMissions.Controls.Add(lblMission);
                Haut += 30;
            }

            if (ligneMissions.Length == 0) // si aucune mission alors création d'un label qui indique que aucune mission n'a été effectuée
            {
                Label lblAucuneMission = new Label();
                lblAucuneMission.Text = "Aucune mission effectuée sur cette planète";
                lblAucuneMission.ForeColor = Color.Gray;
                lblAucuneMission.Font = new Font("Arial", 15, FontStyle.Regular);
                pnlMissions.Controls.Add(lblAucuneMission);
            }
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}