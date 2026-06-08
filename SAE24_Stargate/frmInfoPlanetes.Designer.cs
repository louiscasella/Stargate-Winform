namespace SAE24_Stargate
{
    partial class frmInfoPlanetes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInfoPlanetes));
            this.flpPlanetes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInfoPlanetes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccueil = new System.Windows.Forms.Button();
            this.pcbLogo = new System.Windows.Forms.PictureBox();
            this.txtFiltresMissions = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // flpPlanetes
            // 
            this.flpPlanetes.AllowDrop = true;
            this.flpPlanetes.AutoScroll = true;
            this.flpPlanetes.BackColor = System.Drawing.Color.Black;
            this.flpPlanetes.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.flpPlanetes.Location = new System.Drawing.Point(24, 125);
            this.flpPlanetes.Margin = new System.Windows.Forms.Padding(4);
            this.flpPlanetes.Name = "flpPlanetes";
            this.flpPlanetes.Size = new System.Drawing.Size(1887, 1003);
            this.flpPlanetes.TabIndex = 0;
            // 
            // lblInfoPlanetes
            // 
            this.lblInfoPlanetes.AutoSize = true;
            this.lblInfoPlanetes.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoPlanetes.Font = new System.Drawing.Font("Agency FB", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoPlanetes.ForeColor = System.Drawing.Color.Gold;
            this.lblInfoPlanetes.Location = new System.Drawing.Point(739, 49);
            this.lblInfoPlanetes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfoPlanetes.Name = "lblInfoPlanetes";
            this.lblInfoPlanetes.Size = new System.Drawing.Size(625, 72);
            this.lblInfoPlanetes.TabIndex = 1;
            this.lblInfoPlanetes.Text = "Informations sur les planetes";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnAccueil);
            this.panel1.Controls.Add(this.pcbLogo);
            this.panel1.Controls.Add(this.txtFiltresMissions);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1894, 95);
            this.panel1.TabIndex = 6;
            // 
            // btnAccueil
            // 
            this.btnAccueil.BackColor = System.Drawing.Color.Black;
            this.btnAccueil.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAccueil.BackgroundImage")));
            this.btnAccueil.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccueil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccueil.Font = new System.Drawing.Font("Agency FB", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccueil.ForeColor = System.Drawing.Color.White;
            this.btnAccueil.Location = new System.Drawing.Point(1690, 3);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Size = new System.Drawing.Size(201, 89);
            this.btnAccueil.TabIndex = 18;
            this.btnAccueil.Text = "Revenir à la page d\'accueil";
            this.btnAccueil.UseVisualStyleBackColor = false;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            // 
            // pcbLogo
            // 
            this.pcbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pcbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogo.Image")));
            this.pcbLogo.Location = new System.Drawing.Point(39, 2);
            this.pcbLogo.Name = "pcbLogo";
            this.pcbLogo.Size = new System.Drawing.Size(90, 90);
            this.pcbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLogo.TabIndex = 17;
            this.pcbLogo.TabStop = false;
            // 
            // txtFiltresMissions
            // 
            this.txtFiltresMissions.BackColor = System.Drawing.Color.Black;
            this.txtFiltresMissions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFiltresMissions.Font = new System.Drawing.Font("Agency FB", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltresMissions.ForeColor = System.Drawing.Color.White;
            this.txtFiltresMissions.Location = new System.Drawing.Point(451, 0);
            this.txtFiltresMissions.Name = "txtFiltresMissions";
            this.txtFiltresMissions.ReadOnly = true;
            this.txtFiltresMissions.Size = new System.Drawing.Size(1098, 96);
            this.txtFiltresMissions.TabIndex = 16;
            this.txtFiltresMissions.Text = "Informations sur les planètes :";
            this.txtFiltresMissions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmInfoPlanetes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInfoPlanetes);
            this.Controls.Add(this.flpPlanetes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInfoPlanetes";
            this.Text = "frmInfoPlanetes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInfoPlanetes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPlanetes;
        private System.Windows.Forms.Label lblInfoPlanetes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccueil;
        private System.Windows.Forms.PictureBox pcbLogo;
        private System.Windows.Forms.TextBox txtFiltresMissions;
    }
}