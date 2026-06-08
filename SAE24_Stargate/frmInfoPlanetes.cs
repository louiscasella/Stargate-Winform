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

namespace SAE24_Stargate
{
    public partial class frmInfoPlanetes : Form
    {
        public frmInfoPlanetes()
        {
            InitializeComponent();
        }

        private void frmInfoPlanetes_Load(object sender, EventArgs e)
        {
            try
            {
                genererUcPlanete(); // appel de la fonction de génération des UserControls pour les planètes
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void genererUcPlanete()
        {
            foreach (DataRow ligne in MesDatas.DsGlobal.Tables["Planete"].Rows) // pour chaque ligne de la table "Planete" de la base de données
            {
                ucPlanete uc = new ucPlanete(); // création d'un nouvel UserControl pour la planète
                uc.NomPlanete = ligne["nom"].ToString(); // nom de la planète

                if (ligne["temperature"] == DBNull.Value) // si la température est inconnue, on affiche "Inconnu"
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
                else
                {
                    uc.QtDataBaz = 0; // sinon, on affiche l'absence de dataBAZ dans le user control
                }

                uc.ImagePlanete = Image.FromFile($@"planete\{ligne["nom"].ToString()}.png");


                uc.pbPlanete.Click += (s, args) => // ajout d'un événement click sur l'image de la planète pour ouvrir le formulaire de détails de la planète 
                {
                    frmMoreInfoPlanetes detail = new frmMoreInfoPlanetes(ligne[0].ToString()); // création d'une instance du formulaire de détails de la planète en lui passant l'identifiant de la planète en paramètre
                    detail.Show();
                };

                flpPlanetes.Controls.Add(uc); // ajout du UserControl de la planète au FlowLayoutPanel qui les contient

            }
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}