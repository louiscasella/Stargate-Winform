using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE24_Stargate
{
    public partial class frmChargement : Form
    {
        public string typeChargement = "";
        public frmChargement(string typeChargement)
        {
            InitializeComponent();
            this.typeChargement = typeChargement;
        }

        private async void frmChargement_Load(object sender, EventArgs e)
        {
            lblChargement.Text = "Chargement " + typeChargement;
            for (int i = 0; i < 100; i++)
            {
                pgbChargement.Value++;
                await Task.Delay(20);
            }
            await Task.Delay(500);
            this.Close();
        }
    }
}