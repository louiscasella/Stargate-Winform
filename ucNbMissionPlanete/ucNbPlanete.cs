using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE24_Stargate
{
    public partial class ucNbMissionPlanete: UserControl
    {
        DataSet monDS;
        public ucNbMissionPlanete(DataSet ds)
        {
            InitializeComponent();
            this.monDS = ds;
            majAffichage();
            //Met les flèches sur les images
            btnDroite.BackgroundImage = Image.FromFile("image/chevron-right-solid.png");
            btnGauche.BackgroundImage = Image.FromFile("image/chevron-left-solid.png");
        }

        int currentIndice = 1;

        private void btnDroite_Click(object sender, EventArgs e)
        {
            if (currentIndice < monDS.Tables["Planete"].Rows.Count - 2)
            {
                currentIndice++;
                majAffichage();
            }
        }

        private void btnGauche_Click(object sender, EventArgs e)
        {
            if (currentIndice > 1)
            {
                currentIndice--;
                majAffichage();
            }
        }

        //Met à jour l'affichage
        private void majAffichage()
        {
            //Indice
            lblIndiceGauche.Text = currentIndice.ToString() + "/" + monDS.Tables["Planete"].Rows.Count.ToString();
            lblIndice.Text = (currentIndice + 1).ToString() + "/" + monDS.Tables["Planete"].Rows.Count.ToString();
            lblIndiceDroite.Text = (currentIndice + 2).ToString() + "/" + monDS.Tables["Planete"].Rows.Count.ToString();

            //On met le bon nom pour chaque label
            lblNameGauche.Text = monDS.Tables["Planete"].Rows[currentIndice - 1][0].ToString();
            lblName.Text = monDS.Tables["Planete"].Rows[currentIndice][0].ToString();
            lblNameDroite.Text = monDS.Tables["Planete"].Rows[currentIndice + 1][0].ToString();

            //Attribution des images 
            pcbGauche.BackgroundImage = Image.FromFile("image/planete/" + lblNameGauche.Text + ".png");
            pcbCentre.BackgroundImage = Image.FromFile("image/planete/" + lblName.Text + ".png");
            pcbDroite.BackgroundImage = Image.FromFile("image/planete/" + lblNameDroite.Text + ".png");

            //Attribution du nombre de mission
            lblNbMissionGauche.Text = nbMission(lblNameGauche.Text).ToString() + " Mission(s)";
            lblNbMission.Text = nbMission(lblName.Text).ToString() + " Mission(s)";
            lblNbMissionDroite.Text = nbMission(lblNameDroite.Text).ToString() + " Mission(s)";
        }
        
        //Renvoie le nombre de mission pour une planete
        private int nbMission(String planete)
        {
            DataRow[] missions = monDS.Tables["Mission"].Select($"nomPlanete = '{planete}'");

            if (missions != null)
            {
                return missions.Length;
            }
            return 0;
        }
    }
}
