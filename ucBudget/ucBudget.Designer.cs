namespace SAE24_Stargate
{
    partial class ucBudget
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
            this.cboMission = new System.Windows.Forms.ComboBox();
            this.dgvBudget = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Motif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Montant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcbActuel = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBudgetActuel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblBudgetInitial = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbInitial = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbActuel)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInitial)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboMission
            // 
            this.cboMission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMission.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMission.FormattingEnabled = true;
            this.cboMission.Location = new System.Drawing.Point(523, 10);
            this.cboMission.Name = "cboMission";
            this.cboMission.Size = new System.Drawing.Size(883, 48);
            this.cboMission.TabIndex = 0;
            this.cboMission.SelectedIndexChanged += new System.EventHandler(this.cboBudget_SelectedIndexChanged);
            // 
            // dgvBudget
            // 
            this.dgvBudget.AllowUserToAddRows = false;
            this.dgvBudget.AllowUserToDeleteRows = false;
            this.dgvBudget.AllowUserToResizeColumns = false;
            this.dgvBudget.AllowUserToResizeRows = false;
            this.dgvBudget.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBudget.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBudget.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBudget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBudget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Motif,
            this.Montant});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBudget.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBudget.EnableHeadersVisualStyles = false;
            this.dgvBudget.GridColor = System.Drawing.Color.Gold;
            this.dgvBudget.Location = new System.Drawing.Point(30, 466);
            this.dgvBudget.Name = "dgvBudget";
            this.dgvBudget.ReadOnly = true;
            this.dgvBudget.RowHeadersVisible = false;
            this.dgvBudget.RowHeadersWidth = 51;
            this.dgvBudget.RowTemplate.Height = 44;
            this.dgvBudget.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvBudget.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBudget.Size = new System.Drawing.Size(1640, 495);
            this.dgvBudget.TabIndex = 1;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Motif
            // 
            this.Motif.DataPropertyName = "motif";
            this.Motif.HeaderText = "Motif";
            this.Motif.MinimumWidth = 6;
            this.Motif.Name = "Motif";
            this.Motif.ReadOnly = true;
            // 
            // Montant
            // 
            this.Montant.DataPropertyName = "montant";
            this.Montant.HeaderText = "Montant";
            this.Montant.MinimumWidth = 6;
            this.Montant.Name = "Montant";
            this.Montant.ReadOnly = true;
            // 
            // pcbActuel
            // 
            this.pcbActuel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbActuel.Location = new System.Drawing.Point(20, 20);
            this.pcbActuel.Name = "pcbActuel";
            this.pcbActuel.Size = new System.Drawing.Size(210, 210);
            this.pcbActuel.TabIndex = 0;
            this.pcbActuel.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.Controls.Add(this.lblBudgetActuel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pcbActuel);
            this.panel2.Location = new System.Drawing.Point(1020, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(650, 250);
            this.panel2.TabIndex = 3;
            // 
            // lblBudgetActuel
            // 
            this.lblBudgetActuel.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudgetActuel.Location = new System.Drawing.Point(326, 140);
            this.lblBudgetActuel.Name = "lblBudgetActuel";
            this.lblBudgetActuel.Size = new System.Drawing.Size(213, 50);
            this.lblBudgetActuel.TabIndex = 4;
            this.lblBudgetActuel.Text = "0 €";
            this.lblBudgetActuel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(325, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 50);
            this.label5.TabIndex = 3;
            this.label5.Text = "Budget actuel :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.Controls.Add(this.lblBudgetInitial);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pcbInitial);
            this.panel1.Location = new System.Drawing.Point(30, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 250);
            this.panel1.TabIndex = 4;
            // 
            // lblBudgetInitial
            // 
            this.lblBudgetInitial.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudgetInitial.Location = new System.Drawing.Point(337, 140);
            this.lblBudgetInitial.Name = "lblBudgetInitial";
            this.lblBudgetInitial.Size = new System.Drawing.Size(213, 50);
            this.lblBudgetInitial.TabIndex = 2;
            this.lblBudgetInitial.Text = "0 €";
            this.lblBudgetInitial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(337, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Budget initial :";
            // 
            // pcbInitial
            // 
            this.pcbInitial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbInitial.Location = new System.Drawing.Point(20, 20);
            this.pcbInitial.Name = "pcbInitial";
            this.pcbInitial.Size = new System.Drawing.Size(210, 210);
            this.pcbInitial.TabIndex = 0;
            this.pcbInitial.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gold;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.cboMission);
            this.panel3.Location = new System.Drawing.Point(30, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1422, 70);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(431, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mission avec plus de 10 membres :";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.Font = new System.Drawing.Font("Agency FB", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(648, 54);
            this.label3.TabIndex = 2;
            this.label3.Text = "Dépense de la mission choisie :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ucBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvBudget);
            this.Controls.Add(this.panel3);
            this.Name = "ucBudget";
            this.Size = new System.Drawing.Size(1700, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbActuel)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbInitial)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMission;
        private System.Windows.Forms.DataGridView dgvBudget;
        private System.Windows.Forms.PictureBox pcbActuel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcbInitial;
        private System.Windows.Forms.Label lblBudgetActuel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBudgetInitial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Motif;
        private System.Windows.Forms.DataGridViewTextBoxColumn Montant;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
