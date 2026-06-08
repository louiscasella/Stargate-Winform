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
using System.Windows.Media;
using System.Media;

namespace SAE24_Stargate
{
    public partial class frmStargate : Form
    {
        private MediaPlayer backgroundMusic = new MediaPlayer();
        public frmStargate()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); 

            PlayBackgroundMusic();
        }

        public static void ChargerBaseComplete()
        {
            try
            {
                string sqlListeTables = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name"; //On créer une requête qui sélectionne toutes les tables
                SQLiteCommand cmd = new SQLiteCommand(sqlListeTables, Connexion.Connec); //On lance la requête et on se connecte

                MesDatas.DsGlobal.Clear(); //On s'assure que le DataSet est vide avant de charger

                using (SQLiteDataReader reader = cmd.ExecuteReader()) //On ouvre temporairement un reader pour lister les tables
                {
                    while (reader.Read())   //Tant qu'on est pas passé par chaque table
                    {
                        string nomTable = reader["name"].ToString(); //On créer une variable nomTable qui est égal au nom de la table dans le reader
                        string sqlData = $"SELECT * FROM [{nomTable}]"; //Pour chaque table trouvée, on utilise un DataAdapter pour remplir le DataSet
                        SQLiteDataAdapter da = new SQLiteDataAdapter(sqlData, Connexion.Connec);
                        da.Fill(MesDatas.DsGlobal, nomTable); //On remplit le DataSet qui se trouve dans mesDatas.cs
                                                              // Conversion des dates au format français dd/MM/yyyy
                        string[] formatsAcceptes = { "yyyy-MM-dd", "MM/dd/yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "yyyy/MM/dd" };
                        foreach (DataTable table in MesDatas.DsGlobal.Tables)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                foreach (DataColumn col in table.Columns)
                                {
                                    if (row[col] == DBNull.Value) continue;
                                    string valeur = row[col].ToString().Trim();
                                    if (valeur.Length < 8 || valeur.Length > 10) continue;

                                    if (DateTime.TryParseExact(valeur, formatsAcceptes,
                                        System.Globalization.CultureInfo.InvariantCulture,
                                        System.Globalization.DateTimeStyles.None, out DateTime date))
                                    {
                                        string formatFr = date.ToString("dd/MM/yyyy");
                                        if (valeur != formatFr)
                                            row[col] = formatFr;
                                    }
                                }
                            }
                        }
                    }
                }
                //MessageBox.Show($"{MesDatas.DsGlobal.Tables.Count} tables");    //Pour vérifier qu'on ai le bon nombre de tables
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement de la base : " + ex.Message); //Message d'erreur en cas de problème
            }
            finally
            {
                Connexion.FermerConnexion(); //Fermer la connexion pour être sûr
            }
        }

        private void PlayBackgroundMusic()
        {
            try
            {
                backgroundMusic.Open(new Uri("sons/musiqueDeFond.mp3", UriKind.Relative));
                backgroundMusic.Volume = 0.2; // 0.2 correspond à 20% du volume maximum
                backgroundMusic.Play();
                backgroundMusic.MediaEnded += (sender, e) => { backgroundMusic.Position = TimeSpan.Zero; backgroundMusic.Play(); }; // La musique recommence automatiquement quand elle se termine
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de lecture : " + ex.Message);
            }
        }

        private void frmStargate_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(@"image/fondPourAcceuil.png");
            btnTDB.BackgroundImage = Image.FromFile(@"image/tableauDeBord.png");
            btnDR.BackgroundImage = Image.FromFile(@"image/planete/Malaria.png");
            btnIP.BackgroundImage = Image.FromFile(@"image/infoPlanete.png");
            btnNM.BackgroundImage = Image.FromFile(@"image/nouvelleMissionsSansFumée.png");
            btnStat.BackgroundImage = Image.FromFile(@"image/planete/Saturne.png");
            btnQuitter.BackgroundImage = Image.FromFile(@"image/quitter.png");

            positionDeBase_NM = btnNM.Location;
            positionDeBase_IP = btnIP.Location;
            positionDeBase_DR = btnDR.Location;
            positionDeBase_Stat = btnStat.Location;
            positionDeBase_TDB = btnTDB.Location;
            positionDeBase_Contact = btnContact.Location;
            positionDeBase_Quitter = btnQuitter.Location;

            posFinaleLabels["lblNM"] = lblNM.Top;
            posFinaleLabels["lblIP"] = lblIP.Top;
            posFinaleLabels["lblDR"] = lblDR.Top;
            posFinaleLabels["lblStat"] = lblStat.Top;
            posFinaleLabels["lblTDB"] = lblTDB.Top;
            posFinaleLabels["lblContact"] = lblContact.Top;
            posFinaleLabels["lblQuitter"] = lblQuitter.Top;

            frmTableauDeBord frmTableauDeBord = new frmTableauDeBord();
            frmTableauDeBord.ShowDialog();

        }

        private void btnTB_Click(object sender, EventArgs e)
        {
            frmTableauDeBord frmTableauDeBord = new frmTableauDeBord();
            frmTableauDeBord.ShowDialog();
        }

        private void btnDR_Click(object sender, EventArgs e)
        {
            frmInfoAlien frmInfoAlien = new frmInfoAlien();
            frmInfoAlien.ShowDialog();
        }

        private void btnIP_Click(object sender, EventArgs e)
        {
            frmInfoPlanetes frmInfoPlanetes = new frmInfoPlanetes();
            frmInfoPlanetes.ShowDialog();
        }

        private void btnNM_Click(object sender, EventArgs e)
        {
            frmMDP frmMDP = new frmMDP();
            frmMDP.ShowDialog();
            if(Global.ouvrirTDB == true)
            {
                frmTableauDeBord frmTableauDeBord = new frmTableauDeBord();
                frmTableauDeBord.ShowDialog();
                Global.ouvrirTDB = false;
            }
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            frmStat frmStat = new frmStat();
            frmStat.ShowDialog();
        }

        private Point positionDeBase_NM;
        private Point positionDeBase_IP;
        private Point positionDeBase_DR;
        private Point positionDeBase_Stat;
        private Point positionDeBase_TDB;
        private Point positionDeBase_Contact;
        private Point positionDeBase_Quitter;

        // === btnNM ===
        private async void btnNM_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("NM");
            if (animationsEnCours["NM"]) return;
            animationsEnCours["NM"] = true;
            _ = AfficherLabel(lblNM);
            await AnimationMouvement(btnNM, positionDeBase_NM, "NM");
        }
        private async void btnNM_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["NM"] = false;
            await MasquerLabel(lblNM);
        }

        // === btnIP ===
        private async void btnIP_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("IP");
            if (animationsEnCours["IP"]) return;
            animationsEnCours["IP"] = true;
            _ = AfficherLabel(lblIP);
            await AnimationMouvement(btnIP, positionDeBase_IP, "IP");
        }
        private async void btnIP_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["IP"] = false;
            await MasquerLabel(lblIP);
        }

        // === btnDR ===
        private async void btnDR_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("DR");
            if (animationsEnCours["DR"]) return;
            animationsEnCours["DR"] = true;
            _ = AfficherLabel(lblDR);
            await AnimationMouvement(btnDR, positionDeBase_DR, "DR");
        }
        private async void btnDR_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["DR"] = false;
            await MasquerLabel(lblDR);
        }

        // === btnStat ===
        private async void btnStat_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("Stat");
            if (animationsEnCours["Stat"]) return;
            animationsEnCours["Stat"] = true;
            _ = AfficherLabel(lblStat);
            await AnimationMouvement(btnStat, positionDeBase_Stat, "Stat");
        }
        private async void btnStat_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["Stat"] = false;
            await MasquerLabel(lblStat);
        }

        // === btnTDB ===
        private async void btnTDB_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("TDB");
            if (animationsEnCours["TDB"]) return;
            animationsEnCours["TDB"] = true;
            _ = AfficherLabel(lblTDB);
            await AnimationMouvement(btnTDB, positionDeBase_TDB, "TDB");
        }
        private async void btnTDB_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["TDB"] = false;
            await MasquerLabel(lblTDB);
        }

        // === btnContact ===
        private async void btnContact_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("Contact");
            if (animationsEnCours["Contact"]) return;
            animationsEnCours["Contact"] = true;
            _ = AfficherLabel(lblContact);
            await AnimationMouvement(btnContact, positionDeBase_Contact, "Contact");
        }
        private async void btnContact_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["Contact"] = false;
            await MasquerLabel(lblContact);
        }

        // === btnContact ===
        private async void btnQuitter_MouseEnter(object sender, EventArgs e)
        {
            await ResetTout("Quitter");
            if (animationsEnCours["Quitter"]) return;
            animationsEnCours["Quitter"] = true;
            _ = AfficherLabel(lblQuitter);
            await AnimationMouvement(btnQuitter, positionDeBase_Quitter, "Quitter");
        }
        private async void btnQuitter_MouseLeave(object sender, EventArgs e)
        {
            animationsEnCours["Quitter"] = false;
            await MasquerLabel(lblQuitter);
        }

        private Dictionary<string, bool> animationsEnCours = new Dictionary<string, bool>
        {
            { "NM", false }, { "IP", false }, { "DR", false }, { "Stat", false }, { "TDB", false }, { "Contact", false }, {"Quitter", false}
        };

        // === Méthode commune d'animation ===
        private async Task AnimationMouvement(PictureBox composant, Point posBase, string cle)
        {
            bool allerRetour = false;

            while (animationsEnCours[cle])
            {
                if (!allerRetour)
                {
                    composant.Left += 1;
                    composant.Top -= 1;
                    if (composant.Left >= posBase.X + 20) allerRetour = true;
                }
                else
                {
                    composant.Left -= 1;
                    composant.Top += 1;
                    if (composant.Left <= posBase.X) allerRetour = false;
                }

                await Task.Delay(80);
            }

            while (composant.Location != posBase)
            {
                if (composant.Left > posBase.X) composant.Left -= 1;
                if (composant.Left < posBase.X) composant.Left += 1;
                if (composant.Top > posBase.Y) composant.Top -= 1;
                if (composant.Top < posBase.Y) composant.Top += 1;
                await Task.Delay(80);
            }
        }

        private Dictionary<string, int> posFinaleLabels = new Dictionary<string, int>
        {
            { "lblNM", 0 }, { "lblIP", 0 }, { "lblDR", 0 }, { "lblStat", 0 }, { "lblTDB", 0 }, { "lblContact", 0 }, {"lblQuitter", 0}
        };

        private async Task AfficherLabel(Label label)
        {
            if (label.Name == "lblNM") label.Text = "Nouvelle Mission";
            else if (label.Name == "lblIP") label.Text = "Info planètes";
            else if (label.Name == "lblDR") label.Text = "Données Races";
            else if (label.Name == "lblStat") label.Text = "Statistiques";
            else if (label.Name == "lblTDB") label.Text = "Tableau de Bord";
            else if (label.Name == "lblContact") label.Text = "Contacts";
            else if (label.Name == "lblQuitter") label.Text = "Quitter";

            posFinaleLabels[label.Name] = label.Top;
            label.Top = posFinaleLabels[label.Name] + 50;
            label.Visible = true;

            while (label.Top > posFinaleLabels[label.Name])
            {
                label.Top -= 5;
                await Task.Delay(1);
            }
        }

        private async Task MasquerLabel(Label label)
        {
            while (label.Top < posFinaleLabels[label.Name] + 50)
            {
                label.Top += 5;
                await Task.Delay(1);
            }

            label.Visible = false;
            label.Top = posFinaleLabels[label.Name];
        }

        private async Task ResetTout(string cleException)
        {
            foreach (var cle in new[] { "NM", "IP", "DR", "Stat", "TDB", "Contact", "Quitter" })
            {
                if (cle == cleException) continue;
                animationsEnCours[cle] = false;
            }

            // Petite pause pour laisser les boucles while se terminer
            await Task.Delay(100);

            // Reset forcé des positions
            btnNM.Location = positionDeBase_NM;
            btnIP.Location = positionDeBase_IP;
            btnDR.Location = positionDeBase_DR;
            btnStat.Location = positionDeBase_Stat;
            btnTDB.Location = positionDeBase_TDB;
            btnContact.Location = positionDeBase_Contact;
            btnQuitter.Location = positionDeBase_Quitter;

            lblNM.Visible = false; lblNM.Top = posFinaleLabels["lblNM"];
            lblIP.Visible = false; lblIP.Top = posFinaleLabels["lblIP"];
            lblDR.Visible = false; lblDR.Top = posFinaleLabels["lblDR"];
            lblStat.Visible = false; lblStat.Top = posFinaleLabels["lblStat"];
            lblTDB.Visible = false; lblTDB.Top = posFinaleLabels["lblTDB"];
            lblContact.Visible = false; lblContact.Top = posFinaleLabels["lblContact"];
            lblQuitter.Visible = false; lblQuitter.Top = posFinaleLabels["lblQuitter"];
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A la revoyure, lieutenant.");
            this.Close();

        }

        private void pcblogo_Click(object sender, EventArgs e)
        {
            frmNousContacter nousContacter = new frmNousContacter();
            nousContacter.ShowDialog();
        }
    }
}
public static class Global
{
    // Ta variable booléenne accessible partout, initialisée à "false" par défaut
    public static bool ouvrirTDB { get; set; } = false;
}