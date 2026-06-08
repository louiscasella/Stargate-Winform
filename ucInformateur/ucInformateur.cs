using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE24_Stargate
{
    public partial class ucInformateur : UserControl
    {
        DataSet dsInfo;         //Toute la table
        DataView dvInfo;        //La où l'on applique les filtres
        public ucInformateur(DataSet info)
        {
            InitializeComponent();

            dsInfo = info;
        }

        private void ucInformateur_Load(object sender, EventArgs e)
        {
            //Ajout des images des flèches de navigation
            btnDroite.BackgroundImage = Image.FromFile("image/chevron-right-solid.png");
            btnGauche.BackgroundImage = Image.FromFile("image/chevron-left-solid.png");

            // Sécurité : si la table Info n'existe pas ou est vide, on ne fait rien
            if (!dsInfo.Tables.Contains("Info") || dsInfo.Tables["Info"].Rows.Count == 0)
            {
                dvInfo = new DataView(new DataTable("Info"));
                majAffichage(new DataRow[0]);
                return;
            }

            //Ajout des missions (qui ont des informateurs) dans la combo box
            for (int i = 0; i < dsInfo.Tables["Info"].Rows.Count; i++)
            {
                //Pour pas ajouter plusieurs fois la même mission
                if (!cboMission.Items.Contains(dsInfo.Tables["Info"].Rows[i][0] + " - " + dsInfo.Tables["Info"].Rows[i][1]))
                {
                    cboMission.Items.Add(dsInfo.Tables["Info"].Rows[i][0] + " - " + dsInfo.Tables["Info"].Rows[i][1]);
                }
            }

            //De base on a pas séléctionné de mission donc on remplis juste avec tout la table
            dvInfo = new DataView(dsInfo.Tables["Info"]);
            majAffichage(dvInfo.ToTable().Select());
            dgvContact.DataSource = dvInfo;
            styleDGV();
        }


        int currentIndice = 0;
        private void btnDroite_Click(object sender, EventArgs e)
        {
            //Bloque pour pas dépacer le nombre max d'Informateur
            if (currentIndice < dvInfo.ToTable().Select().Length - 1)
            {
                currentIndice++;
                majAffichage(dvInfo.ToTable().Select());
            }
        }

        private void btnGauche_Click(object sender, EventArgs e)
        {
            //Bloque pour pas être en dehors du tableau
            if (currentIndice > 0)
            {
                currentIndice--;
                majAffichage(dvInfo.ToTable().Select());
            }
        }

        private void majAffichage(DataRow[] informateur)
        {
            if (informateur == null || informateur.Length == 0)
            {
                lblIndice.Text = "0/0";
                lblName.Text = "";
                lblEspece.Text = "";
                lblContact.Text = "";
                lblTotal.Text = "";
                pcbContact.BackgroundImage = null;
                return;
            }

            // S'assurer que currentIndice reste dans les bornes
            if (currentIndice >= informateur.Length)
                currentIndice = 0;
            //Num mission
            lblIndice.Text = (currentIndice + 1).ToString() + "/" + informateur.Length.ToString();

            //Nom mission
            lblName.Text = informateur[currentIndice][0] + " - " + informateur[currentIndice][1];

            //Espèce
            lblEspece.Text = informateur[currentIndice][3].ToString();

            //Nom de code + nom
            lblContact.Text = "  " + informateur[currentIndice][2] + " :\n" + informateur[currentIndice][4];

            //Somme total reçu
            lblTotal.Text = "Somme total reçue : " + informateur[currentIndice][5] + " €";

            //Image
            pcbContact.BackgroundImage = Image.FromFile($"image/informateur/{informateur[currentIndice][2]}.png");
        }
        //Permet de vider la combo box pour ne plus avoir le filtre de la mission
        //et avoir tous les informateurs
        private void btnVider_Click(object sender, EventArgs e)
        {
            cboMission.SelectedIndex = -1;
        }

        private void cboMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            //On vérifie si c'est -1 car sinon la requete planterait
            if (cboMission.SelectedIndex != -1)
            {
                //Variable
                string planete = planeteMission();
                string numMission = cboMission.Text.Substring(planete.Length + 3);

                //Initialisation de dvInfo avec la table info puis application du filtre
                dvInfo = new DataView(dsInfo.Tables["Info"]);
                dvInfo.RowFilter = $"nomPlanete = '{planete}' AND numeroMission = {numMission}";

                //Mise à jour de dgvContact et du affichage sur la droite
                dgvContact.DataSource = dvInfo;
                styleDGV();
                currentIndice = 0;
                majAffichage(dvInfo.ToTable().Select());
            }
            else
            {
                //Réinitialisation de dvInfo avec la table info puis maj de l'affichage
                dvInfo = new DataView(dsInfo.Tables["Info"]);
                dgvContact.DataSource = dvInfo;
                styleDGV();
                currentIndice = 0;
                majAffichage(dvInfo.ToTable().Select());
            }
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

        private void styleDGV()
        {
            //Ajout de nom plus stylé à dgvContact
            dgvContact.Columns["nomPlanete"].HeaderText = "Planète";
            dgvContact.Columns["numeroMission"].HeaderText = "N° Mission";
            dgvContact.Columns["espece"].HeaderText = "Espèce";
            dgvContact.Columns["nomCodeInformateur"].HeaderText = "Code";
            dgvContact.Columns["nom"].HeaderText = "Nom";
            dgvContact.Columns["total"].HeaderText = "Somme reçue";

            //Largeurs adaptées au contenu
            dgvContact.Columns["nomPlanete"].Width = 110;
            dgvContact.Columns["numeroMission"].Width = 110;
            dgvContact.Columns["espece"].Width = 90;
            dgvContact.Columns["nomCodeInformateur"].Width = 60;
            dgvContact.Columns["nom"].Width = 160;
            dgvContact.Columns["total"].Width = 150;

            //Style de l'en tête
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.Font = new Font("Agency FB", 20, FontStyle.Bold);
            headerStyle.ForeColor = Color.Black;
            headerStyle.BackColor = Color.Gold;
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.SelectionBackColor = Color.Gold;        //La même que de base comme ça on la voie pas
            dgvContact.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvContact.ColumnHeadersHeight = 45;

            // Style des cellules
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Font = new Font("Agency FB", 17, FontStyle.Regular);
            cellStyle.ForeColor = Color.White;
            cellStyle.BackColor = Color.FromArgb(105, 105, 105);
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.SelectionForeColor = Color.Black;
            cellStyle.SelectionBackColor = Color.Khaki;
            dgvContact.DefaultCellStyle = cellStyle;
        }


    }
}