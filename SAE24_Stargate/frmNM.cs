using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAE24_Stargate
{
    public partial class frmNM : Form
    {
        private SoundPlayer bruitageIdentificationReussie = new SoundPlayer("sons/bruitageIdentificationRéussie.wav");
        private SoundPlayer bruitageErrorHard = new SoundPlayer("sons/bruitageErrorHard.wav");
        public frmNM()
        {
            InitializeComponent();
        }

        //Une list qui contient les matricule des militaires
        List<string> listChef = new List<string>();

        //Un dictionnaire qui a pour valeur le matricule des militaires et des civil
        //et comme clé le text afficher dans la combo box ("nom prenom - Militaire/Civil : Metier")
        Dictionary<string, string> dicoMember = new Dictionary<string, string>();

        //Un dictionnaire qui a pour valeur l'id des aliens
        //et comme clé le text afficher dans la combo box ("nom alien - couleur")
        Dictionary<string, string> dicoCap = new Dictionary<string, string>();

        private void frmNM_Load(object sender, EventArgs e)
        {
            bruitageIdentificationReussie.Play();
            //ajout du fond
            this.BackgroundImage = Image.FromFile(@"image/interieur.png");

            //ajout de l'image boutton maison
            btnMaison.BackgroundImage = Image.FromFile(@"image/maison.png");

            //ajout des planete dans la combo box planete
            string requete = @"SELECT nom FROM Planete";
            SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
            SQLiteDataReader resultat = cmd.ExecuteReader();
            while (resultat.Read())
            {
                cboPlanete.Items.Add(resultat[0].ToString());
            }
            cboPlanete.SelectedIndex = 0;

            //ajout des ennemis dans la combo box capture
            requete = @"SELECT nom, couleur, id FROM Espece
                        WHERE id IN(SELECT idEspece FROM Ennemi)
                        ORDER BY nom, couleur";
            cmd = new SQLiteCommand(requete, Connexion.Connec);
            resultat = cmd.ExecuteReader();
            while (resultat.Read())
            {
                cboCap.Items.Add(resultat[0].ToString() + " - " + resultat[1].ToString());
                dicoCap[resultat[0].ToString() + " - " + resultat[1].ToString()] = resultat[2].ToString();
            }
            cboCap.SelectedIndex = 0;

            //désactivation du groupe box equipe et objectif 
            //(permet de bloquer l'utilisation des controle et de les griser)
            changementEtatGRP(grpEO);
            //On les désactive eux aussi pour ne pas avoir de problème par exemple choisir un chef déjà en mission
            changementEtatPNL(pnlDate);
            changementEtatPNL(pnlParametre);
        }


        int numMission = 0;     //Numéro de la mission qui serra utiliser lors des prochaines insertions

        private void btnPlanete_Click(object sender, EventArgs e)
        {
            if (btnPlanete.Tag.ToString() == "true")
            {
                erpMN.SetError(lblMissionName, "");

                string requete = @"SELECT MAX(numero) FROM Mission
                                WHERE nomPlanete = '" + cboPlanete.Text + "'";

                SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
                if (cmd.ExecuteScalar() != DBNull.Value)
                {
                    numMission = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }
                else
                {
                    numMission = 1;
                }
                lblMissionName.Text = cboPlanete.Text + " - " + numMission.ToString();

                changementEtatPNL(pnlPlanete);
                changementEtatPNL(pnlDate);
            }
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            if (btnDate.Tag.ToString() == "true")
            {
                if (dtpDepart.Value < DateTime.Today || dtpRetour.Value <= dtpDepart.Value)
                {
                    erpDate.SetError(dtpRetour, "Erreur de date");
                    bruitageErrorHard.Play();
                }
                else if (Convert.ToInt32(lblNbMembreDispo.Text) <= 0)
                {
                    erpDate.SetError(lblNbMembreDispo, "Impossible de faire une mission avec 0 membre");
                    bruitageErrorHard.Play();
                }
                else
                {
                    changementEtatPNL(pnlParametre);
                    changementEtatPNL(pnlDate);

                    //ajout des militaire dans la combo box chef
                    String requete = $@"SELECT me.nom, me.prenom, mi.grade, me.matricule FROM Membre me
                            JOIN Militaire mi ON me.matricule = mi.matriculeMembre
                            WHERE mi.matriculeMembre NOT IN 
                                (SELECT matriculeMembre FROM Composer c
	                             JOIN Mission m ON m.nomPlanete = c.nomPlanete AND m.numero = c.numeroMission
	                             WHERE dateDepart <= '{dtpRetour.Value.ToString("yyyy-MM-dd")}' 
                                 AND dateRetour >= '{dtpDepart.Value.ToString("yyyy-MM-dd")}') 
                            ORDER BY me.nom, me.prenom";
                    SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
                    SQLiteDataReader resultat = cmd.ExecuteReader();
                    while (resultat.Read())
                    {
                        cboChef.Items.Add(resultat[0].ToString() + " " + resultat[1].ToString() + " - " + resultat[2].ToString());
                        listChef.Add(resultat[3].ToString());
                    }
                    cboChef.SelectedIndex = 0;
                }
            }
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            //ajout des militaire dans la combo box chef
            String requete = $@"SELECT count(matricule) FROM Membre
                                WHERE matricule NOT IN 
                                    (SELECT matriculeMembre FROM Composer c
	                                 JOIN Mission m ON m.nomPlanete = c.nomPlanete AND m.numero = c.numeroMission
	                                 WHERE dateDepart <= '{dtpRetour.Value.ToString("yyyy-MM-dd")}' 
                                     AND dateRetour >= '{dtpDepart.Value.ToString("yyyy-MM-dd")}')";
            SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
            String resultat = cmd.ExecuteScalar().ToString();

            lblNbMembreDispo.Text = resultat;

            erpDate.SetError(dtpRetour, "");
        }

        //Autorise uniquement les chiffres dans les textbox
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btnVM_Click(object sender, EventArgs e)
        {
            bool cestOk = true;                     //variable pour bloquer l'insersion en cas d'erreur
            if (btnVM.Tag.ToString() == "true")     //verrifie si le bouton est actif (on utilise un tag au lieu de enable pour garder la couleur)
            {
                //désactive toute les erreurs
                erpFeuille.SetError(txtFeuille, "");
                erpMembre.SetError(lblPersonne, "");
                erpDB.SetError(lblTonne, "");
                erpBudget.SetError(lblEuro, "");

                //verifie chaque problème potantiel et s'il y en a un 
                //on met cestOk à flase pour bloquer l'insertion                
                if (txtFeuille.Text == "")
                {
                    cestOk = false;
                    erpFeuille.SetError(txtFeuille, "Feuille de voyage vide");
                    bruitageErrorHard.Play();
                }
                if (txtNbMembre.Text == "" || Convert.ToInt32(txtNbMembre.Text) < 1 || Convert.ToInt32(txtNbMembre.Text) > Convert.ToInt32(lblNbMembreDispo.Text))
                {
                    cestOk = false;
                    erpMembre.SetError(lblPersonne, "Nombre de membre vide, insufisant ou supérieur au nombre de membre dispo");
                    bruitageErrorHard.Play();
                }
                if (txtDB.Text == "" || Convert.ToInt32(txtDB.Text) < 0)
                {
                    cestOk = false;
                    erpDB.SetError(lblTonne, "Data baze vide ou null");
                    bruitageErrorHard.Play();
                }
                if (txtBudget.Text == "" || Convert.ToInt32(txtBudget.Text) < 1)
                {
                    cestOk = false;
                    erpBudget.SetError(lblEuro, "Budget vide ou null");
                    bruitageErrorHard.Play();
                }

                if (cestOk)     //Donc s'il n'y a pas d'erreur
                {

                    //ouvre la petite fenetre pour le chargement
                    frmChargement chargement = new frmChargement("des missions");
                    chargement.ShowDialog();

                    //ajout du chef dans la list des membres
                    lstMember.Items.Add(cboChef.Text);

                    //ajout du nombre de membre restant
                    lblNbMR.Text = (Convert.ToInt32(txtNbMembre.Text) - 1).ToString();

                    //variable pour l'insertion
                    string planete = cboPlanete.Text;
                    string idChef = listChef[cboChef.SelectedIndex];
                    string dateDepart = dtpDepart.Value.ToString("yyyy-MM-dd");
                    string dateRetour = dtpRetour.Value.ToString("yyyy-MM-dd");
                    string feuilleRoute = txtFeuille.Text;
                    string nbMembre = txtNbMembre.Text;
                    string dataBaz = txtDB.Text;
                    string budget = txtBudget.Text;

                    //requete
                    string requete = $@"INSERT INTO Mission
                                        (nomPlanete,numero,matriculeChef,
                                         dateDepart,dateRetour,feuilleDeRoute,
                                         nbMembreRequis,objectifDataBaz,budget)
                                        VALUES ('{planete}',{numMission},'{idChef}',
                                                '{dateDepart}','{dateRetour}','{feuilleRoute}',
                                                 {nbMembre},{dataBaz},{budget})";

                    SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
                    cmd.ExecuteNonQuery();


                    //ajout des membre dans la combo box membre (tout d'abord on fait tous les militaires puis tous les civils)
                    requete = $@"SELECT me.nom, me.prenom, mi.grade, me.matricule FROM Membre me
                        JOIN Militaire mi ON me.matricule = mi.matriculeMembre
                        WHERE me.matricule NOT IN 
                                    (SELECT matriculeMembre FROM Composer c
	                                 JOIN Mission m ON m.nomPlanete = c.nomPlanete AND m.numero = c.numeroMission
	                                 WHERE dateDepart <= '{dtpRetour.Value.ToString("yyyy-MM-dd")}' 
                                     AND dateRetour >= '{dtpDepart.Value.ToString("yyyy-MM-dd")}')
                        ORDER BY me.nom, me.prenom";
                    cmd = new SQLiteCommand(requete, Connexion.Connec);
                    SQLiteDataReader resultat = cmd.ExecuteReader();
                    while (resultat.Read())
                    {
                        cboMember.Items.Add(resultat[0].ToString() + " " + resultat[1].ToString() + " - Militaire : " + resultat[2].ToString());
                        dicoMember[resultat[0].ToString() + " " + resultat[1].ToString() + " - Militaire : " + resultat[2].ToString()] = resultat[3].ToString();
                    }
                    requete = $@"SELECT me.nom, me.prenom, ci.Specialite, me.matricule FROM Membre me
                        JOIN Civil ci ON me.matricule = ci.matriculeMembre
                        WHERE me.matricule NOT IN 
                                    (SELECT matriculeMembre FROM Composer c
	                                 JOIN Mission m ON m.nomPlanete = c.nomPlanete AND m.numero = c.numeroMission
	                                 WHERE dateDepart <= '{dtpRetour.Value.ToString("yyyy-MM-dd")}' 
                                     AND dateRetour >= '{dtpDepart.Value.ToString("yyyy-MM-dd")}')
                        ORDER BY me.nom, me.prenom";
                    cmd = new SQLiteCommand(requete, Connexion.Connec);
                    resultat = cmd.ExecuteReader();
                    while (resultat.Read())
                    {
                        cboMember.Items.Add(resultat[0].ToString() + " " + resultat[1].ToString() + " - Civil : " + resultat[2].ToString());
                        dicoMember[resultat[0].ToString() + " " + resultat[1].ToString() + " - Civil : " + resultat[2].ToString()] = resultat[3].ToString();
                    }


                    //désactivation de pnlParametre et activation de pnlMember
                    changementEtatPNL(pnlMember);
                    changementEtatPNL(pnlParametre);

                }
            }
        }
        private void lstMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On vérifie qu'un élément est bien sélectionné
            if (lstMember.SelectedIndex > 0)
            {
                // Supprime l'élément sélectionné
                lstMember.Items.RemoveAt(lstMember.SelectedIndex);

                lblNbMR.Text = (Convert.ToInt32(txtNbMembre.Text) - lstMember.Items.Count).ToString();
            }
        }
        private void cboMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            erpAjoutMem.SetError(cboMember, "");
            string membre = cboMember.Text;

            if (lstMember.Items.Contains(membre) || GetChef() == membre)
            {
                erpAjoutMem.SetError(cboMember, "Membre déjà présent dans la liste");
                bruitageErrorHard.Play();
            }
            else if (txtNbMembre.Text != "" && lstMember.Items.Count < Convert.ToInt32(txtNbMembre.Text))
            {
                erpAjoutMem.SetError(cboMember, "");
                lstMember.Items.Add(membre);
                lblNbMR.Text = (Convert.ToInt32(txtNbMembre.Text) - lstMember.Items.Count).ToString();
            }
            else
            {
                erpAjoutMem.SetError(cboMember, "Plus de place pour cette mission");
                bruitageErrorHard.Play();
            }
        }

        private void btnVmem_Click(object sender, EventArgs e)
        {
            if (btnVmem.Tag.ToString() == "true")
            {
                if (Convert.ToInt32(lblNbMR.Text) == 0)
                {
                    erpAjoutMem.SetError(lblNbMR, "");

                    string planete = cboPlanete.Text;

                    string requete = @"INSERT INTO Composer
                                       (nomPlanete, numeroMission, matriculeMembre)
                                       VALUES";

                    for (int i = 0; i < lstMember.Items.Count; i++)
                    {
                        string matricule;
                        if (i == 0)
                        {
                            matricule = listChef[cboChef.SelectedIndex];
                        }
                        else
                        {
                            matricule = dicoMember[lstMember.Items[i].ToString()];
                        }

                        requete += $"('{planete}','{numMission}','{matricule}'),";
                    }
                    requete = requete.Substring(0, requete.Length - 1);

                    SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
                    cmd.ExecuteNonQuery();

                    frmChargement frmCherg = new frmChargement("des membres");
                    frmCherg.ShowDialog();

                    //désactivation de l'ajout de membre et activation de l'ajout d'alien
                    changementEtatGRP(grpEO);
                }
                else
                {
                    erpAjoutMem.SetError(lblNbMR, "Il faut encore ajouter " + lblNbMR.Text + " membres");
                    bruitageErrorHard.Play();
                }
            }
        }

        private void btnCap_Click(object sender, EventArgs e)
        {
            if (btnCap.Tag.ToString() == "true")
            {
                erpCap.SetError(txtCap, "");
                if (txtCap.Text == "" || Convert.ToInt32(txtCap.Text) < 1)
                {
                    erpCap.SetError(txtCap, "Valeur insufisante ou vide");
                    bruitageErrorHard.Play();
                }
                else
                {
                    int indice = capExiste(cboCap.Text);
                    int nb = 0;
                    if (indice != -1)
                    {
                        nb = Convert.ToInt32(lstCap.Items[indice].ToString().Substring(cboCap.Text.Length + 28));      //ancient objectif
                        lstCap.Items.RemoveAt(indice);
                    }

                    lstCap.Items.Add(cboCap.Text + " --> objectif de captures : " + (nb + Convert.ToInt32(txtCap.Text)).ToString());
                }
            }
        }

        private void btnVcap_Click(object sender, EventArgs e)
        {
            if (btnVcap.Tag.ToString() == "true")
            {
                if (Convert.ToInt32(lstCap.Items.Count) > 0)    //verifie que la listbox n'est pas vide
                {
                    SQLiteTransaction transaction = Connexion.Connec.BeginTransaction();
                    try
                    {
                        string requete = @"INSERT INTO ObjectifCapture
                                                (nomPlanete,numeroMission,idEspeceEnnemi,objectif)
                                                VALUES";
                        //Ajoute chaque alien dans la requete pour l'insertion
                        for (int i = 0; i < lstCap.Items.Count; i++)
                        {
                            //variable pour la requete
                            string planete = cboPlanete.Text;
                            string idEsepece = dicoCap[justeNom(lstCap.Items[i].ToString())];
                            string objectif = lstCap.Items[i].ToString().Substring(justeNom(lstCap.Items[i].ToString()).Length + 28);

                            requete += $"('{planete}',{numMission},{idEsepece},{objectif}),";
                        }

                        requete = requete.Substring(0, requete.Length - 1); //retir la "," à la fin de la requete

                        SQLiteCommand cmd = new SQLiteCommand(requete, Connexion.Connec);
                        cmd.Transaction = transaction;
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Erreur lors de l'insertion : " + ex.Message, "Erreur");
                        return;         //permet de quiter la fonction sans désactiver la zone des aliens et sans lancer la fenetre de sauvegarde
                    }
                }

                frmChargement frmCherg = new frmChargement("des captures");
                frmCherg.ShowDialog();

                //désactivation de l'ajout d'objectif de capture
                changementEtatPNL(pnlCap);

                frmMissionTermine frmMissionTermine = new frmMissionTermine();
                frmMissionTermine.ShowDialog();

                this.Close();
            }
        }

        private void lstCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            // On vérifie qu'un élément est bien sélectionné
            if (lstCap.SelectedIndex >= 0)
            {
                // Supprime l'élément sélectionné
                lstCap.Items.RemoveAt(lstCap.SelectedIndex);
            }
        }

        private void btnMaison_Click(object sender, EventArgs e)
        {
            if (btnVM.Tag.ToString() == "true")
            {
                frmVerifQuitter verif = new frmVerifQuitter();
                verif.ShowDialog();

                if (verif.Quitter)
                {
                    this.Close();
                }
            }
            else if (btnVcap.Tag.ToString() == "false" && btnVmem.Tag.ToString() == "false")
            {
                this.Close();
            }
            else
            {
                erpMaison.SetError(btnMaison, "Le formulaire n'a pas été entièrement completé");
                bruitageErrorHard.Play();
            }
        }



        //Renvoie le nom de l'alien sans le --> Objectif : et le chiffre
        private string justeNom(string nomEtNb)
        {
            int i = 0;

            while (i < nomEtNb.Length)
            {
                if (nomEtNb.Substring(i, 2) == "--")
                {
                    return nomEtNb.Substring(0, i - 1);
                }
                i++;
            }
            return "";
        }

        //verrifie si un extraterrestre est déjà dans lstCap si oui il renvoie l'indice sinon il renvoie -1
        private int capExiste(string extraterrestre)
        {
            int i = 0;

            while (i < lstCap.Items.Count)
            {
                if (extraterrestre.Length < lstCap.Items[i].ToString().Length && extraterrestre == lstCap.Items[i].ToString().Substring(0, extraterrestre.Length))
                {
                    return i;
                }

                i++;
            }

            return -1;
        }


        //Désactive les controls et grises les labels et les buttons 
        //dans les panel du groupe box en paramète
        private void changementEtatGRP(GroupBox grp)
        {

            foreach (Control c in grp.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    Panel p = (Panel)c;
                    changementEtatPNL(p);
                }
            }
        }

        //Désactive les controls et grises les labels et les buttons
        private void changementEtatPNL(Panel pnl)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c.GetType() == typeof(Label))
                {
                    Label lblTempo = (Label)c;
                    if (lblTempo.ForeColor != Color.Gray)
                    {
                        lblTempo.ForeColor = Color.Gray;
                    }
                    else if (lblTempo.Tag != null && lblTempo.Tag.ToString() == "titre")
                    {
                        lblTempo.ForeColor = Color.Khaki;
                    }
                    else
                    {
                        lblTempo.ForeColor = Color.White;
                    }

                }
                else if (c.GetType() == typeof(Button))
                {
                    Button btnTempo = (Button)c;
                    if ((string)btnTempo.Tag != "false")
                    {
                        btnTempo.ForeColor = Color.Gray;
                        btnTempo.Tag = "false";
                        btnTempo.Cursor = Cursors.Default;
                    }
                    else
                    {
                        btnTempo.ForeColor = Color.Black;
                        btnTempo.Tag = "true";
                        btnTempo.Cursor = Cursors.Hand;
                    }
                }
                else
                {
                    c.Enabled = !c.Enabled;
                }
            }
        }

        //ajoute et renvoie le nom du chef (cboChef.Text) avec le " Militaire :"
        private string GetChef()
        {
            string chef = "";
            int i = 0;

            while (i < cboChef.Text.Length && cboChef.Text.Substring(i, 1) != "-")
            {
                chef += cboChef.Text.Substring(i, 1);
                i++;
            }
            chef += "- Militaire :" + cboChef.Text.Substring(i + 1);

            return chef;
        }

    }
}