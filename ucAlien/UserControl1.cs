using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucAlien
{
    public partial class ucAlienCarte: UserControl
    {
        public ucAlienCarte()
        {
            InitializeComponent();
        }

        public int IdAlien { get; set; }

        public string NomAlien
        {
            set { lblNomAlien.Text = value; }
        }

        public string CouleurAlien
        {   
            set { 
                lblCouleurAlien.Text = value;
                lblCouleurAlien.ForeColor = CouleursAlien(value); 
            }
        }

        public string OrigineAlien
        {
            set
            {
                if (value == "Inconnu")
                {
                    lblOrigin.Text = "Origine : Inconnue";
                }   
                else { lblOrigin.Text = value; } 
            }
        }

        public string CategorieAlien
        {
            set
            {
                if (value == "Ennemi")
                {
                    lblEnnemi.Text = "Ennemi";
                    lblEnnemi.ForeColor = Color.Red;
                }
                else if(value == "Allie"){ 
                    lblEnnemi.Text = "Allié";
                    lblEnnemi.ForeColor = Color.Lime;
                }
                else
                {
                    lblEnnemi.Text = "Neutre";
                    lblEnnemi.ForeColor = Color.White;
                }
            }
        }

        public Image ImageAlien
        {
            set { pcbAlien.Image = value; }
        }

        private void pcbAlien_Click(object sender, EventArgs e)
        {
        }

        public void AjouterOrigine(string origine)
        {
            if (lblOrigin.Text == "" || lblOrigin.Text == "Origine : Inconnue")
                lblOrigin.Text = $"Origine : {origine}";
            else
                lblOrigin.Text += $", {origine}";
        }

        private Color CouleursAlien(string couleur)
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
    }
}
