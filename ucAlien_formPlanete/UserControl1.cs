using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucAlien_formPlanete
{
    public partial class ucAlienPlanete: UserControl
    {
        public int Haut // définir la position du haut du UserControl
        {
            set { this.Top = value; }
        }
        public int Gauche // définir la position de gauche du UserControl
        {
            set { this.Left = value; }
        }

        public ucAlienPlanete()
        {
            InitializeComponent();
        }

        public string NomAlien
        {
            set { lblNomAlien.Text = value; }
        }

        public Image ImageAlien
        {
            set { pcbAlien.Image = value; }
        }

        public int AllieEnnemi
        {
            set
            {
                if (value == 0) // 0 pour allié, 1 pour ennemi
                {
                    lblEnnemiAllie.Text = "Allié";
                    lblEnnemiAllie.ForeColor = Color.Lime;
                }
                
                else
                {
                    lblEnnemiAllie.Text = "Ennemi"; 
                    lblEnnemiAllie.ForeColor = Color.Red;
                }
            }
        }
    }
}
