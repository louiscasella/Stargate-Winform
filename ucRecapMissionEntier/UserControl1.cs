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
    public partial class ucRecapMissionEntier : UserControl
    {
        private BindingSource bsJournal;
        public ucRecapMissionEntier()
        {
            InitializeComponent();
        }

        private void ucRecapMissionEntier_Load(object sender, EventArgs e)
        {
            pcbGaucheJournal.BackgroundImage = Image.FromFile("image/angle-left-solid.png");
            pcbDroiteJournal.BackgroundImage = Image.FromFile("image/angle-right-solid.png");
            pcbFullGaucheJournal.BackgroundImage = Image.FromFile("image/angles-left-solid.png");
            pcbFullDroiteJournal.BackgroundImage = Image.FromFile("image/angles-right-solid.png");
            pcbCréationPDF.BackgroundImage = Image.FromFile("image/file-pdf-solid.png");
            pcbEditionMission.BackgroundImage = Image.FromFile("image/pen-to-square-regular.png");
            pcbGaucheJournal.BackgroundImageLayout = ImageLayout.Zoom;
            pcbDroiteJournal.BackgroundImageLayout = ImageLayout.Zoom;
            pcbFullGaucheJournal.BackgroundImageLayout = ImageLayout.Zoom;
            pcbFullDroiteJournal.BackgroundImageLayout = ImageLayout.Zoom;
            pcbCréationPDF.BackgroundImageLayout = ImageLayout.Zoom;
            pcbEditionMission.BackgroundImageLayout = ImageLayout.Zoom;
        }

        public void LierDonneesRecapEntier(BindingSource bs)
        {
            this.bsJournal = bs;
            this.txtCommentaireJournalDeBord.DataBindings.Clear();
            this.txtDateJournalDeBord.DataBindings.Clear();

            this.txtCommentaireJournalDeBord.DataBindings.Add("Text", bs, "commentaires");
            this.txtDateJournalDeBord.DataBindings.Add("Text", bs, "dateJ");
        }
        private void pcbFullGaucheJournal_Click(object sender, EventArgs e)
        {
            if (this.bsJournal != null)
            {
                this.bsJournal.MoveFirst();
            }
        }

        private void pcbGaucheJournal_Click(object sender, EventArgs e)
        {
            if (this.bsJournal != null)
            {
                this.bsJournal.MovePrevious();
            }
        }

        private void pcbDroiteJournal_Click(object sender, EventArgs e)
        {
            if (this.bsJournal != null)
            {
                this.bsJournal.MoveNext();
            }
        }

        private void pcbFullDroiteJournal_Click(object sender, EventArgs e)
        {
            if (this.bsJournal != null)
            {
                this.bsJournal.MoveLast();
            }
        }

        public string TextBoxTitreRecap
        {
            set { txtRecapitulatif.Text = value; }
        }

        public string TextBoxPlaneteVisitee
        {
            set { txtPlaneteVisitee.Text = value; }
        }

        public string TextBoxNumeroMission
        {
            set { txtNumeroMission.Text = value; }
        }

        public string TextBoxDateDepartEtRetour
        {
            set { txtDateDepartEtRetour.Text = value; }
        }

        public string TextBoxBudgetPreMission
        {
            set { txtBudgetPreMission.Text = value; }
        }

        public TextBox TextBoxBudgetPostMission
        {
            get { return txtBudgetPostMission; }
        }


        public string TextBoxJournalDeBord
        {
            set { txtJournalDeBord.Text = value; }
        }

        public string TextBoxChefRecapEntier
        {
            set { txtChef.Text = value; }
        }

        public GroupBox GroupBoxFeuilleDeRoute
        {
            get { return grpFeuilleDeRoute; }
        }

        public string TextBoxContenuFeuilleDeRoute
        {
            set { txtContenuFeuilleDeRoute.Text = value; }
        }

        public DataGridView DataGridViewMembres
        {
            get { return dgvMembres; }
        }

        public string TextBoxDateJournalDeBord
        {
            set { txtDateJournalDeBord.Text = value; }
        }

        public string TextBoxCommentaireJournalDeBord
        {
            set { txtCommentaireJournalDeBord.Text = value; }
        }

        public DataGridView DataGridViewBilanCapture
        {
            get { return dgvBilanCapture; }
        }
        public DataGridView DataGridViewDepenses
        {
            get { return dgvDepenses; }
        }

        public TextBox TextBoxEditionMission
        {
            get { return txtEditionMission; }
        }

        public TextBox TextBoxVersionPDF
        {
            get { return txtVersionPDF; }
        }

        public PictureBox PictureBoxEditionMission
        {
            get { return pcbEditionMission; }
        }

        public PictureBox PictureBoxCréationPDF
        {
            get { return pcbCréationPDF; }
        }
        public Action<int> OnDemandeEdition { get; set; }

        private void pcbEditionMission_Click(object sender, EventArgs e)
        {

            int numero = 0;
            if (int.TryParse(txtNumeroMission.Text, out int result))
            {
                numero = result;
            }

            OnDemandeEdition?.Invoke(numero);
        }

        public DataGridView DataGridViewContactInformateur
        {
            get { return dgvContactInformateur; }
        }

        public TextBox TextBoxAucunContactInformateur
        {
            get { return txtAucunContactInformateur; }
        }

        public PictureBox PictureBoxFermerRecapComplet
        {
            get { return pcbFermerRecapEntier; }
        }

        public PictureBox PictureBoxImageMission
        {
            get { return picImageMission; }
        }

        public string TextBoxObjectifDatabaz
        {
            set { txtObjectifDatabaz.Text = value; }
        }

        public DataGridView DataGridViewNegociations
        {
            get { return dgvNegociations; }
        }
    }
}