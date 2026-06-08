using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace SAE24_Stargate
{
    public partial class frmMDP : Form
    {
        private SoundPlayer bruitageIdentificationLancement = new SoundPlayer("sons/bruitageIdentificationLancement.wav");
        private SoundPlayer bruitageErrorHard = new SoundPlayer("sons/bruitageErrorHard.wav");
        public frmMDP()
        {
            InitializeComponent();


        }

        private async void btnValider_Click(object sender, EventArgs e)
        {
            try
            {
                //Récupération du mot de passe en fonction du login
                string sql = $"SELECT mdp FROM Admin WHERE login = '{txtLogin.Text}'";
                SQLiteCommand cmd = new SQLiteCommand(sql, Connexion.Connec);
                object resultat = cmd.ExecuteScalar();

                //Test si la requête a renvoyé un résultat non null
                if (resultat != DBNull.Value && resultat != null)
                {
                    string mdpStocke = resultat.ToString();

                    //Vérification du mot de passe
                    bool valide = BCrypt.Net.BCrypt.Verify(txtMDP.Text, mdpStocke);         //Résultat de l'authentification

                    if (valide)
                    {
                        frmNM frmNM = new frmNM();
                        frmNM.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        erpMDP.SetError(txtMDP, "Mot de passe incorrect");
                        bruitageErrorHard.Play();
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
                else
                {
                    erpLogin.SetError(txtLogin, "Login incorrect");
                    bruitageErrorHard.Play();
                    for (int i = 0; i < 4; i++)
                    {
                        await Task.Delay(20);
                        this.Left += 10;
                        this.Top += 10;
                        await Task.Delay(20);
                        this.Left -= 10;
                        this.Top -= 10;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            erpLogin.SetError(txtLogin, "");
            erpMDP.SetError(txtMDP, "");
        }

        private void frmMDP_Load(object sender, EventArgs e)
        {
            bruitageIdentificationLancement.Play();
        }
    }
}