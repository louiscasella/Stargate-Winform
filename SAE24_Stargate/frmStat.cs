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
using ucInfoPlanetes;

namespace SAE24_Stargate
{
    public partial class frmStat : Form
    {
        public frmStat()
        {
            InitializeComponent();
            frmStargate.ChargerBaseComplete();
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            liaison(pcbMember);
            if (pcbMember.Visible)
            {
                ucMember ucMember = new ucMember(MesDatas.DsGlobal);

                ucMember.Location = new Point(30, 10);

                pnlStat.Controls.Add(ucMember);
            }
        }

        private void btnBudget_Click(object sender, EventArgs e)
        {
            liaison(pcbBudget);
            if (pcbBudget.Visible)
            {
                ucBudget ucBudget = new ucBudget(MesDatas.DsGlobal);

                ucBudget.Location = new Point(30, 10);

                pnlStat.Controls.Add(ucBudget);
            }
        }

        private void btnPlanete_Click(object sender, EventArgs e)
        {
            liaison(pcbPlanete);
            if (pcbPlanete.Visible)
            {
                ucNbMissionPlanete nbMissionPlanete = new ucNbMissionPlanete(MesDatas.DsGlobal);
                nbMissionPlanete.Location = new Point(30, 10);

                pnlStat.Controls.Add(nbMissionPlanete);
            }
        }

        private void btnDepense_Click(object sender, EventArgs e)
        {
            liaison(pcbDepense);
            if (pcbDepense.Visible)
            {
                // Panel de fond
                Panel pnlDepense = new Panel();
                pnlStat.Controls.Add(pnlDepense);
                pnlDepense.Location = new Point(30, 10);
                pnlDepense.Size = new Size(1575, 1012);
                pnlDepense.BackColor = Color.Black;

                // Initialisation du DataGridView
                DataGridView dgvDepense = new DataGridView();
                pnlDepense.Controls.Add(dgvDepense);
                dgvDepense.Location = new Point(50, 30);
                dgvDepense.Size = new Size(1470, 950);
                dgvDepense.ReadOnly = true;
                dgvDepense.RowHeadersVisible = false;
                dgvDepense.EnableHeadersVisualStyles = false;
                dgvDepense.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Taille des lignes et colonnes
                dgvDepense.RowTemplate.Height = 40;
                dgvDepense.ColumnHeadersHeight = 50;
                dgvDepense.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvDepense.AllowUserToResizeColumns = false;
                dgvDepense.AllowUserToResizeRows = false;
                dgvDepense.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgvDepense.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

                // Style général (lignes)
                dgvDepense.Font = new Font("Agency FB", 18f);
                dgvDepense.BackgroundColor = Color.FromArgb(105, 105, 105);
                dgvDepense.DefaultCellStyle.BackColor = Color.FromArgb(105, 105, 105);
                dgvDepense.DefaultCellStyle.ForeColor = Color.White;
                dgvDepense.DefaultCellStyle.SelectionBackColor = Color.Khaki;
                dgvDepense.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvDepense.GridColor = Color.Khaki;

                // Style de l'en-tête
                dgvDepense.ColumnHeadersDefaultCellStyle.BackColor = Color.Gold;
                dgvDepense.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dgvDepense.ColumnHeadersDefaultCellStyle.Font = new Font("Agency FB", 20f, FontStyle.Bold);
                dgvDepense.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.Gold;

                // Chargement des données
                string requete = @"SELECT d.dateD || ' | ' || d.motif || ' | ' || d.montant || ' €' AS 'Dépenses les plus importantes',
                          m.nomPlanete || ' - ' || m.numero AS 'Mission',
                          c.nom || ' ' || c.prenom AS 'Chef'
                          FROM Depense d
                          JOIN Mission m ON m.nomPlanete = d.nomPlanete AND m.numero = d.numeroMission
                          JOIN Membre c ON c.matricule = m.matriculeChef
                          WHERE d.montant = (SELECT MAX(d2.montant)
                                             FROM Depense d2
                                             WHERE d2.nomPlanete = d.nomPlanete 
                                             AND d2.numeroMission = d.numeroMission)";

                SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
                SQLiteDataReader reader = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvDepense.DataSource = dt;

                // La 1ère colonne est plus large car elle contient le plus d'infos
                dgvDepense.Columns[0].Width = 700;
            }
        }

        private void btnInformateur_Click(object sender, EventArgs e)
        {
            liaison(pcbInfo);
            if (pcbInfo.Visible)
            {
                DataSet monDS = MesDatas.DsGlobal;

                // Supprimer la table Info si elle existe déjà (elle sera rechargée proprement)
                if (monDS.Tables.Contains("Info"))
                    monDS.Tables.Remove("Info");

                string requete = @"SELECT c.nomPlanete, c.numeroMission, c.nomCodeInformateur, e.nom as espece, i.nom, 
                                    SUM(c.sommeVersee) AS total FROM Contact c
                                    JOIN Informateur i ON c.nomCodeInformateur = i.nomCode
                                    JOIN Espece e ON i.idEspeceEnnemi = e.id
                                    GROUP BY c.nomPlanete, c.numeroMission, c.nomCodeInformateur
                                    HAVING SUM(c.sommeVersee) = (
                                        SELECT MIN(total) FROM (
                                            SELECT SUM(sommeVersee) AS total
                                            FROM Contact
                                            WHERE nomPlanete = c.nomPlanete AND numeroMission = c.numeroMission
                                            GROUP BY nomPlanete, numeroMission, nomCodeInformateur))";

                SQLiteDataAdapter da = new SQLiteDataAdapter(requete, Connexion.Connec);

                DataTable dt = new DataTable("Info");
                da.Fill(dt);

                monDS.Tables.Add(dt);

                ucInformateur ucInfo = new ucInformateur(monDS);
                ucInfo.Location = new Point(30, 10);
                pnlStat.Controls.Add(ucInfo);
            }
        }


        private void liaison(PictureBox pcbActif)
        {
            PictureBox[] tousLesBoutons = { pcbMember, pcbBudget, pcbPlanete, pcbDepense, pcbInfo };

            //Permet de ouvrir quand il n'y a aucune liaison et de le fermer quand on appuye sur le bouton actif
            pnlStat.Visible = !pcbActif.Visible;
            pnlStat.Controls.Clear();

            // Active le bouton actif et masquer les autres
            foreach (PictureBox pcb in tousLesBoutons)
            {
                pcb.Visible = (pcb == pcbActif) && !pcbActif.Visible;
            }
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}