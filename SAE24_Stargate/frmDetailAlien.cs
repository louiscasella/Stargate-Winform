using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ucInfoPlanetes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.CompilerServices;
using System.Media;

namespace SAE24_Stargate
{
    public partial class frmDetailAlien : Form
    {
        private int idAlien; // variable globable pour stocker l'identifiant de l'alien dont on affiche les détails
        private SoundPlayer bruitAlien; // variable pour stocker le son de l'alien

        public frmDetailAlien(int _idAlien)
        {
            InitializeComponent();
            idAlien = _idAlien; // stocker l'identifiant de l'alien passé en paramètre au formulaire

            // Charger le son correspondant au nom de l'alien
            DataRow[] ligneAlien = MesDatas.DsGlobal.Tables["Espece"].Select($"id = '{idAlien}'");
            if (ligneAlien.Length > 0)
            {
                string nomAlien = ligneAlien[0]["nom"].ToString();
                string cheminSon = System.IO.Path.Combine(Application.StartupPath, "sons", "bruitAlien", nomAlien + ".wav");
                if (System.IO.File.Exists(cheminSon))
                    bruitAlien = new SoundPlayer(cheminSon);
            }
        }

        private void frmDetailAlien_Load(object sender, EventArgs e)
        {
            bruitAlien.Play(); // jouer le son de l'alien si il existe

            genererCarteAlien(); // appel de la fonction de génération de la carte de l'alien
            genererGraphique(); // appel de la fonction de génération du graphique des planètes habitées par l'alien
        }

        private void genererCarteAlien()
        {
            DataRow[] ligneAlien = MesDatas.DsGlobal.Tables["Espece"].Select($"id = '{idAlien}'"); // on récupère les informations de l'alien dans le dataset à partir de son identifiant

            if (ligneAlien.Length > 0)
            {
                DataRow ligne = ligneAlien[0]; // on prend la première ligne (il ne devrait y en avoir qu'une)

                lblNom.Text = ligne["nom"].ToString(); // nom de l'alien

                // Affichage de la couleur de l'alien
                lblCouleur.Text = ligne["couleur"].ToString();
                lblCouleur.ForeColor = CouleursAlien(ligne["couleur"].ToString());

                pcbAlien.Image = Image.FromFile($@"alien\{ligne["nom"].ToString()}.png");


                // Catégorie (allié ou ennemi)
                DataRow[] ligneEnnemi = MesDatas.DsGlobal.Tables["Ennemi"].Select($"idEspece = '{idAlien}'"); // on récupère les informations de l'ennemi
                DataRow[] ligneAllie = MesDatas.DsGlobal.Tables["Allie"].Select($"idEspece = '{idAlien}'"); // on récupère les informations de l'allié

                if (ligneEnnemi.Length > 0) // si l'alien est un ennemi, on remplit les informations d'ennemi
                {
                    lblEnnemi.Text = "Ennemi";
                    lblEnnemi.ForeColor = Color.Red;
                    lblInstrument.Text = $"Arme : {ligneEnnemi[0]["typeArme"].ToString()}";
                    lblDegre.Text = $"Degré d'agressivité : {ligneEnnemi[0]["degreAgressivite"].ToString()}";
                    pcbContact.Visible = false; // on cache l'icône de contact pour les ennemis
                }

                else if (ligneAllie.Length > 0) // si l'alien est un allié, on remplit les informations d'allié
                {

                    lblEnnemi.Text = "Allié";
                    lblEnnemi.ForeColor = Color.Lime;
                    lblInstrument.Text = $"Instrument de musique : {ligneAllie[0]["instrumentMusique"].ToString()}";
                    lblDegre.Text = $"Degré de bienveillance : {ligneAllie[0]["degreBienveillance"].ToString()}";
                    lblContact.Text = $"Date de premier contact : {ligneAllie[0]["datePremierContact"].ToString()}";
                }
                else // si l'alien n'est ni un allié ni un ennemi, on affiche "Neutre" et on cache les informations d'ennemi et d'allié
                {
                    lblEnnemi.Text = "Neutre";
                    lblEnnemi.ForeColor = Color.White;
                    pcbContact.Visible = false;
                    pcbInstrument.Visible = false;
                    pcbOrigine.Visible = false;
                    lblContact.Visible = false;
                    lblDegre.Visible = false;
                    lblDegre.Visible = false;
                    lblInstrument.Visible = false;
                }
            }
        }

        private void genererGraphique()
        {
            DataRow[] ligneHabiter = MesDatas.DsGlobal.Tables["Habiter"].Select($"idEspece = '{idAlien}'"); // on récupère les informations des planètes habitées par l'alien à partir de son identifiant

            if (ligneHabiter.Length == 0) // si l'alien n'habite aucune planète, on affiche un message indiquant qu'aucune origine n'est connue
            {
                Label lblAucuneOrigine = new Label();
                lblAucuneOrigine.Text = "Aucune origine connue";
                lblAucuneOrigine.ForeColor = Color.Gray;
                lblAucuneOrigine.Font = new Font("Arial", 16, FontStyle.Regular);
                lblAucuneOrigine.AutoSize = true;
                pnlGraph.Controls.Add(lblAucuneOrigine);
                return;
            }


            // Création du graphique en camembert à l'aide de la bibliothèque System.Windows.Forms.DataVisualization.Charting
            Font policeAgency = new Font("AgencyFb", 14, FontStyle.Regular);
            Chart chart = new Chart();
            chart.Dock = DockStyle.Fill;

            chart.BackColor = Color.Black;

            ChartArea chartArea = new ChartArea("Main");

            chartArea.BackColor = Color.Black;

            chart.ChartAreas.Add(chartArea);

            Series serie = new Series("Planetes");
            serie.ChartType = SeriesChartType.Pie;

            serie.LabelForeColor = Color.White;

            serie.Font = policeAgency;

            foreach (DataRow row in ligneHabiter) // pour chaque planète habitée par l'alien, on ajoute une part au graphique avec le nom de la planète et le pourcentage d'habitants de l'alien sur cette planète
            {
                string nomPlanete = row["nomPlanete"].ToString();
                double pourcentage = Convert.ToDouble(row["pourcentage"]);

                DataPoint point = new DataPoint();
                point.SetValueXY(nomPlanete, pourcentage);
                point.Font = policeAgency;
                point.Label = $"{nomPlanete}\n{pourcentage}%";
                serie.Points.Add(point);
            }

            chart.Series.Add(serie);

            pnlGraph.Controls.Add(chart);
        }

        private Color CouleursAlien(string couleur) // fonction pour convertir une couleur au format string en une couleur utilisable (Color)
        {
            switch (couleur)
            {
                case "Orange": return Color.Orange;
                case "Violet": return Color.MediumPurple;
                case "Pourpre": return Color.Purple;
                case "Rose": return Color.Pink;
                case "Marron": return Color.Brown;
                case "Gris": return Color.Gray;
                case "Vert": return Color.Lime;
                case "Bleu": return Color.Blue;
                default: return Color.LightGray; // couleur inconnue
            }
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}