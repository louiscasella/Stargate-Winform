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
    public partial class ucMember: UserControl
    {
        DataSet monDS;
        List<string> lstMember = new List<string>();

        public ucMember(DataSet ds)
        {
            InitializeComponent();
            monDS = ds;

            //On ajoute toute les membres dans la combo box
            DataTable tblMembre = ds.Tables["Membre"];
            for (int i = 0; i < tblMembre.Rows.Count ; i++) 
            {
                //Les membres sont écrit sous la forme "nom prénom : militaire/civil" 
                string tempo = tblMembre.Rows[i][1] + " " + tblMembre.Rows[i][2] + " : ";
                if (tblMembre.Rows[i][0].ToString().Substring(0, 1) == "M")
                {
                    tempo += "Militaire";
                }
                else
                {
                    tempo += "Civil";
                }
                
                
                lstMember.Add(tblMembre.Rows[i][0].ToString());     //Et là on ajoute dans une list le matricule du membre 
                cboMember.Items.Add(tempo);
            }
        }

        private void cboMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            //On récupère toutes les missions au quel le membre à participé
            DataRow[] missions = monDS.Tables["Composer"].Select($"matriculeMembre = '{lstMember[cboMember.SelectedIndex]}'");

            if (missions.Length == 0)
            {
                dgvMember.DataSource = null;
                return;                
            }

            //On fait la requete
            string requete = $@"matriculeMembre <> '{lstMember[cboMember.SelectedIndex]}' AND (";
            foreach (DataRow row in missions)
            {
                requete += $"(nomPlanete = '{row["nomPlanete"]}' AND numeroMission = {row["numeroMission"]}) OR";
            }
            requete = requete.Substring(0, requete.Length - 3) + ")";


            //On récupère touts les coéquipié avec la requete
            DataRow[] coequipiers = monDS.Tables["Composer"].Select(requete);

            //Création du dataTable qu'on utilisera pour remplire le dataGridView
            DataTable tableau = new DataTable();
            tableau.Columns.Add("nom");
            tableau.Columns.Add("prenom");
            tableau.Columns.Add("statut");
            tableau.Columns.Add("planete");
            tableau.Columns.Add("numMission");

            foreach (DataRow row in coequipiers)
            {
                // Retrouver les infos du membre via son Id
                DataRow membre = monDS.Tables["Membre"].Select($"matricule = '{row["matriculeMembre"]}'").FirstOrDefault();

                if (membre != null)
                {
                    string Statut = "";
                    if (row["matriculeMembre"].ToString().Substring(0,1) == "M")
                    {
                        Statut = "Militaire";
                    }
                    else
                    {
                        Statut = "Civil";
                    }

                    tableau.Rows.Add(
                        membre[1],              //Nom
                        membre[2],              //Prénom
                        Statut,                 //"Civil" ou "Militaire"
                        row["nomPlanete"],      //Planète
                        row["numeroMission"]    //Numéro Mission
                    );
                }
            }
            dgvMember.DataSource = tableau;
        }
    }
}
