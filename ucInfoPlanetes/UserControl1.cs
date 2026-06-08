using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucInfoPlanetes
{
    public partial class ucPlanete : UserControl
    {
        public ucPlanete()
        {
            InitializeComponent();
        }

        private DataRow lignePlanete; // Variable pour stocker la ligne de données de la planète

        public DataRow LignePlanete
        {
            set { lignePlanete = value; } // Propriété pour définir la ligne de données de la planète
        }

        // Propriété pour définir le nom de la planète 
        public string NomPlanete
        {
            set { lblPlanete.Text = value; }
        }

        // Propriété pour définir la température de la planète
        public string Temperature
        {
            set
            {
                if (value == "Inconnu")
                {
                    lblTemperature.Text = "Température : Inconnue";
                }
                else { lblTemperature.Text = $"Température : {value}°"; }
            }
        }

        // Propriété pour définir la gravité de la planète
        public string Gravite
        {
            set
            {
                if (value == "Inconnu")
                {
                    lblGravite.Text = "Gravité : Inconnue";
                }
                else { lblGravite.Text = $"Gravité : {value}"; }
            }
        }

        // Propriété pour définir la présence de Databaz sur la planète

        public int QtDataBaz
        {
            set
            {
                if (value == -1)
                {
                    lblDatabaz.Text = "Présence de DataBaz inconnu";
                    lblDatabaz.ForeColor = Color.Gray;
                }
                else if (value == 0)
                {
                    lblDatabaz.Text = "Pas de présence de DataBaz";
                    lblDatabaz.ForeColor = Color.Red;
                }
                else if (value == 1)
                {
                    lblDatabaz.Text = "Présence de DataBaz";
                    lblDatabaz.ForeColor = Color.Lime;
                }
            }
        }

        // Propriété pour définir l'image de la planète
        public Image ImagePlanete
        {
            set { pbPlanete.Image = value; }
        }

        // Événement de clic sur l'image de la planète 
        private void pbPlanete_Click(object sender, EventArgs e)
        {
        }
    }
}
