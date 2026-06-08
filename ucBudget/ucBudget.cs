using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SAE24_Stargate
{
    public partial class ucBudget : UserControl
    {
        DataSet monDS;
        List<int> budgets = new List<int>();

        public ucBudget(DataSet ds)
        {
            InitializeComponent();
            monDS = ds;

            //Met les images
            pcbInitial.BackgroundImage = Image.FromFile("image/euro.png");
            pcbActuel.BackgroundImage = Image.FromFile("image/euro2.png");

            //Ajoute les missions dans la combo box et ajoute le budget de celle si dans une list
            DataTable tblMission = ds.Tables["Mission"];
            for (int i = 0; i < tblMission.Rows.Count; i++)
            {
                if (Convert.ToInt32(tblMission.Rows[i][2]) > 10)
                {
                    string tempo = tblMission.Rows[i][0] + " - " + tblMission.Rows[i][1];

                    budgets.Add(Convert.ToInt32(tblMission.Rows[i][8]));

                    cboMission.Items.Add(tempo);
                }
            }
        }

        private void cboBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            //On met le bon budget initial
            lblBudgetInitial.Text = budgets[cboMission.SelectedIndex].ToString() + " €";

            //On récupère le numéro de la mission avec la taille du nom de la planete + 3 (pour le " - ")
            int numMission = Convert.ToInt32(cboMission.Text.Substring(planeteMission().Length + 3));

            //On récupère les dépences 
            DataRow[] depenses = monDS.Tables["Depense"].Select($@"
                                 nomPlanete = '{planeteMission()}'
                                 AND numeroMission = {numMission}");


            //Création du dataTable qu'on utilisera pour remplire le dataGridView
            DataTable tableau = new DataTable();
            tableau.Columns.Add("date");
            tableau.Columns.Add("motif");
            tableau.Columns.Add("montant");

            int budgetActuel = budgets[cboMission.SelectedIndex]; //On l'initialise au budget de départ
            foreach (DataRow row in depenses)
            {
                tableau.Rows.Add(
                    row[3],         //date
                    row[5],         //motif
                    row[4]          //montant
                );
                budgetActuel -= Convert.ToInt32(row[4]);    //On lui soustrait toutes les dépenses effectué
            }
            lblBudgetActuel.Text = budgetActuel.ToString();

            dgvBudget.DataSource = tableau;
        }

        //Renvoie le nom de la planete séléctionnée dans la combo box
        private string planeteMission()
        {
            int i = 0;
            while (cboMission.Text.Substring(i, 3) != " - ") //tant que la partie de i de longueur 3 du text dans la combo box n'est pas égale à " - " on décale en ajoutant 1 à i 
            {
                i++;
            }

            return cboMission.Text.Substring(0, i); //vu que de i à i+3 on a " - " on sait que de 0 à i c'est le nom de la planete
        }

    }
}
