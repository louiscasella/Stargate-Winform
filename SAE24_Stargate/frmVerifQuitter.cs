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
    public partial class frmVerifQuitter : Form
    {
        public bool Quitter { get; private set; } = false;

        public frmVerifQuitter()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Quitter = true;
            this.Close();
        }

        private void btnPasQuitter_Click(object sender, EventArgs e)
        {
            Quitter = false;
            this.Close();
        }

        private async void frmVerifQuitter_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                this.Left += 10;
                this.Top += 10;
                await Task.Delay(20);
                this.Left -= 10;
                this.Top -= 10;
                await Task.Delay(20);
            }
        }
    }
}
