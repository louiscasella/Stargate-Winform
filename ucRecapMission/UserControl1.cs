using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace SAE24_Stargate
{
    public partial class ucRecapMission : UserControl
    {

        public ucRecapMission()
        {
            InitializeComponent();
            DesactiverTousLesTabStops(this);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void DesactiverTousLesTabStops(Control conteneur)
        {
            foreach (Control c in conteneur.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).TabStop = false;
                }

                // Si le contrôle contient lui-même d'autres contrôles (ex: Panel), on fouille dedans
                if (c.HasChildren)
                {
                    DesactiverTousLesTabStops(c);
                }
            }
        }

        public event EventHandler BoutonRecapClique;

        public void LierDonneesRecap(BindingSource bs)
        {
            this.txtNomMission.DataBindings.Clear();
            this.txtDateDepart.DataBindings.Clear();
            this.txtDateRetour.DataBindings.Clear();
            this.txtBudget.DataBindings.Clear();
            this.txtNumeroMissionEnBas.DataBindings.Clear();

            this.txtNomMission.DataBindings.Add("Text", bs, "MissionAffichage");
            this.txtDateDepart.DataBindings.Add("Text", bs, "dateDepart");
            this.txtDateRetour.DataBindings.Add("Text", bs, "dateRetour");
            this.txtBudget.DataBindings.Add("Text", bs, "budget", true, DataSourceUpdateMode.Never, "", "#,##0 €");
        }
        private void picBoutonRecapJaune_Click(object sender, EventArgs e)
        {
            BoutonRecapClique?.Invoke(this, EventArgs.Empty);
        }

        public string TextBoxNumeroMissionEnBas
        {
            get { return txtNumeroMissionEnBas.Text; }
            set { txtNumeroMissionEnBas.Text = value; }
        }

        public string textBoxNomMission
        {
            set { txtNomMission.Text = value; }
        }

        public string textBoxChef
        {
            set { txtChef.Text = value; }
        }

        public string textBoxDateDepart
        {
            set { txtDateDepart.Text = value; }
        }

        public string textBoxDateRetour
        {
            set { txtDateRetour.Text = value; }
        }

        public string textBoxBudget
        {
            set { txtBudget.Text = value; }
        }

        private void picBoutonRecapJaune_MouseEnter(object sender, EventArgs e)
        {
            picBoutonRecapJaune.BackgroundImage = System.Drawing.Image.FromFile("image/scroll-solid-teal.png");
            picBoutonRecapJaune.Top -= 4;
            picBoutonRecapJaune.Left -= 4;
            picBoutonRecapJaune.Height += 2;
            picBoutonRecapJaune.Width += 2;
        }

        private void picBoutonRecapJaune_MouseLeave(object sender, EventArgs e)
        {
            picBoutonRecapJaune.BackgroundImage = System.Drawing.Image.FromFile("image/scroll-solid.png");
            picBoutonRecapJaune.Top += 4;
            picBoutonRecapJaune.Left += 4;
            picBoutonRecapJaune.Height -= 2;
            picBoutonRecapJaune.Width -= 2;
        }

        public PictureBox PictureBoxImageMission
        {
            get { return pcbImageMission; }
        }
    }
}
