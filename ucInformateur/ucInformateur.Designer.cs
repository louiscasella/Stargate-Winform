using System.Windows.Forms;

namespace SAE24_Stargate
{
    partial class ucInformateur
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEspece = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.pcbContact = new System.Windows.Forms.PictureBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnDroite = new System.Windows.Forms.PictureBox();
            this.btnGauche = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIndice = new System.Windows.Forms.Label();
            this.dgvContact = new System.Windows.Forms.DataGridView();
            this.cboMission = new System.Windows.Forms.ComboBox();
            this.btnVider = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDroite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGauche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblEspece);
            this.panel2.Controls.Add(this.lblContact);
            this.panel2.Controls.Add(this.pcbContact);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Location = new System.Drawing.Point(1213, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 740);
            this.panel2.TabIndex = 1;
            // 
            // lblEspece
            // 
            this.lblEspece.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspece.Location = new System.Drawing.Point(0, 98);
            this.lblEspece.Name = "lblEspece";
            this.lblEspece.Size = new System.Drawing.Size(360, 70);
            this.lblEspece.TabIndex = 7;
            this.lblEspece.Text = "Nom Espece";
            this.lblEspece.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContact
            // 
            this.lblContact.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(0, 553);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(360, 98);
            this.lblContact.TabIndex = 6;
            this.lblContact.Text = "nom code + nom";
            this.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pcbContact
            // 
            this.pcbContact.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbContact.Location = new System.Drawing.Point(5, 200);
            this.pcbContact.Name = "pcbContact";
            this.pcbContact.Size = new System.Drawing.Size(350, 350);
            this.pcbContact.TabIndex = 5;
            this.pcbContact.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(0, 651);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(360, 89);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(360, 70);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Mission";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDroite
            // 
            this.btnDroite.BackColor = System.Drawing.Color.Gold;
            this.btnDroite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDroite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDroite.Location = new System.Drawing.Point(1475, 839);
            this.btnDroite.Name = "btnDroite";
            this.btnDroite.Size = new System.Drawing.Size(100, 100);
            this.btnDroite.TabIndex = 3;
            this.btnDroite.TabStop = false;
            this.btnDroite.Click += new System.EventHandler(this.btnDroite_Click);
            // 
            // btnGauche
            // 
            this.btnGauche.BackColor = System.Drawing.Color.Gold;
            this.btnGauche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGauche.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGauche.Location = new System.Drawing.Point(1213, 839);
            this.btnGauche.Name = "btnGauche";
            this.btnGauche.Size = new System.Drawing.Size(100, 100);
            this.btnGauche.TabIndex = 4;
            this.btnGauche.TabStop = false;
            this.btnGauche.Click += new System.EventHandler(this.btnGauche_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // lblIndice
            // 
            this.lblIndice.BackColor = System.Drawing.Color.Gold;
            this.lblIndice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblIndice.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblIndice.Location = new System.Drawing.Point(1319, 866);
            this.lblIndice.Name = "lblIndice";
            this.lblIndice.Size = new System.Drawing.Size(148, 50);
            this.lblIndice.TabIndex = 6;
            this.lblIndice.Text = "0/0";
            this.lblIndice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvContact
            // 
            this.dgvContact.AllowUserToAddRows = false;
            this.dgvContact.AllowUserToDeleteRows = false;
            this.dgvContact.AllowUserToResizeColumns = false;
            this.dgvContact.AllowUserToResizeRows = false;
            this.dgvContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContact.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContact.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContact.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContact.EnableHeadersVisualStyles = false;
            this.dgvContact.GridColor = System.Drawing.Color.Khaki;
            this.dgvContact.Location = new System.Drawing.Point(3, 351);
            this.dgvContact.Name = "dgvContact";
            this.dgvContact.ReadOnly = true;
            this.dgvContact.RowHeadersVisible = false;
            this.dgvContact.RowHeadersWidth = 100;
            this.dgvContact.RowTemplate.Height = 34;
            this.dgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContact.Size = new System.Drawing.Size(1204, 588);
            this.dgvContact.TabIndex = 7;
            // 
            // cboMission
            // 
            this.cboMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMission.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMission.FormattingEnabled = true;
            this.cboMission.Location = new System.Drawing.Point(478, 7);
            this.cboMission.Name = "cboMission";
            this.cboMission.Size = new System.Drawing.Size(472, 48);
            this.cboMission.TabIndex = 8;
            this.cboMission.SelectedIndexChanged += new System.EventHandler(this.cboMission_SelectedIndexChanged);
            // 
            // btnVider
            // 
            this.btnVider.BackColor = System.Drawing.Color.Gold;
            this.btnVider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVider.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVider.Location = new System.Drawing.Point(1008, 97);
            this.btnVider.Name = "btnVider";
            this.btnVider.Size = new System.Drawing.Size(199, 57);
            this.btnVider.TabIndex = 9;
            this.btnVider.Text = "Vider";
            this.btnVider.UseVisualStyleBackColor = false;
            this.btnVider.Click += new System.EventHandler(this.btnVider_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboMission);
            this.panel1.Location = new System.Drawing.Point(3, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 59);
            this.panel1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(450, 50);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mission avec des Informateurs :";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(718, 57);
            this.label3.TabIndex = 10;
            this.label3.Text = "Informateurs les moins payé lors d\'une mission :";
            // 
            // ucInformateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnVider);
            this.Controls.Add(this.dgvContact);
            this.Controls.Add(this.lblIndice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGauche);
            this.Controls.Add(this.btnDroite);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ucInformateur";
            this.Size = new System.Drawing.Size(1585, 1000);
            this.Load += new System.EventHandler(this.ucInformateur_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDroite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGauche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContact)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcbContact;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox btnDroite;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblEspece;
        private System.Windows.Forms.PictureBox btnGauche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIndice;
        private DataGridView dgvContact;
        private ComboBox cboMission;
        private Button btnVider;
        private Panel panel1;
        private Label label2;
        private Label label3;
    }
}
