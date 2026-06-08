namespace SAE24_Stargate
{
    partial class ucMember
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cboMember = new System.Windows.Forms.ComboBox();
            this.dgvMember = new System.Windows.Forms.DataGridView();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numMission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboMember
            // 
            this.cboMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMember.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMember.FormattingEnabled = true;
            this.cboMember.Location = new System.Drawing.Point(522, 6);
            this.cboMember.Name = "cboMember";
            this.cboMember.Size = new System.Drawing.Size(883, 48);
            this.cboMember.TabIndex = 0;
            this.cboMember.SelectedIndexChanged += new System.EventHandler(this.cboMember_SelectedIndexChanged);
            // 
            // dgvMember
            // 
            this.dgvMember.AllowUserToAddRows = false;
            this.dgvMember.AllowUserToDeleteRows = false;
            this.dgvMember.AllowUserToResizeColumns = false;
            this.dgvMember.AllowUserToResizeRows = false;
            this.dgvMember.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMember.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMember.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMember.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nom,
            this.prenom,
            this.Statut,
            this.planete,
            this.numMission});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMember.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMember.EnableHeadersVisualStyles = false;
            this.dgvMember.GridColor = System.Drawing.Color.Gold;
            this.dgvMember.Location = new System.Drawing.Point(30, 203);
            this.dgvMember.Name = "dgvMember";
            this.dgvMember.ReadOnly = true;
            this.dgvMember.RowHeadersVisible = false;
            this.dgvMember.RowHeadersWidth = 51;
            this.dgvMember.RowTemplate.Height = 34;
            this.dgvMember.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvMember.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMember.Size = new System.Drawing.Size(1502, 758);
            this.dgvMember.TabIndex = 1;
            // 
            // nom
            // 
            this.nom.DataPropertyName = "nom";
            this.nom.HeaderText = "Nom";
            this.nom.MinimumWidth = 6;
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // prenom
            // 
            this.prenom.DataPropertyName = "prenom";
            this.prenom.HeaderText = "Prénom";
            this.prenom.MinimumWidth = 6;
            this.prenom.Name = "prenom";
            this.prenom.ReadOnly = true;
            // 
            // Statut
            // 
            this.Statut.DataPropertyName = "statut";
            this.Statut.HeaderText = "Civil/Militaire";
            this.Statut.MinimumWidth = 6;
            this.Statut.Name = "Statut";
            this.Statut.ReadOnly = true;
            // 
            // planete
            // 
            this.planete.DataPropertyName = "planete";
            this.planete.HeaderText = "Planète";
            this.planete.MinimumWidth = 6;
            this.planete.Name = "planete";
            this.planete.ReadOnly = true;
            // 
            // numMission
            // 
            this.numMission.DataPropertyName = "numMission";
            this.numMission.HeaderText = "Numéro Mission";
            this.numMission.MinimumWidth = 6;
            this.numMission.Name = "numMission";
            this.numMission.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboMember);
            this.panel1.Location = new System.Drawing.Point(30, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1423, 62);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Membre d\'équipage :";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gold;
            this.label2.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(375, 57);
            this.label2.TabIndex = 2;
            this.label2.Text = "Camarade de mission :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvMember);
            this.Controls.Add(this.panel1);
            this.Name = "ucMember";
            this.Size = new System.Drawing.Size(1567, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMember)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMember;
        private System.Windows.Forms.DataGridView dgvMember;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statut;
        private System.Windows.Forms.DataGridViewTextBoxColumn planete;
        private System.Windows.Forms.DataGridViewTextBoxColumn numMission;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
