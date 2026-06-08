namespace SAE24_Stargate
{
    partial class frmMDP
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
            this.components = new System.ComponentModel.Container();
            this.grpMDP = new System.Windows.Forms.GroupBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.txtMDP = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.erpLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.erpMDP = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpMDP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMDP)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMDP
            // 
            this.grpMDP.Controls.Add(this.btnValider);
            this.grpMDP.Controls.Add(this.txtMDP);
            this.grpMDP.Controls.Add(this.txtLogin);
            this.grpMDP.Controls.Add(this.label3);
            this.grpMDP.Controls.Add(this.label2);
            this.grpMDP.Controls.Add(this.label1);
            this.grpMDP.Font = new System.Drawing.Font("Agency FB", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMDP.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.grpMDP.Location = new System.Drawing.Point(20, 20);
            this.grpMDP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpMDP.Name = "grpMDP";
            this.grpMDP.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpMDP.Size = new System.Drawing.Size(740, 420);
            this.grpMDP.TabIndex = 0;
            this.grpMDP.TabStop = false;
            this.grpMDP.Text = "Authentification";
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.Gold;
            this.btnValider.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnValider.Font = new System.Drawing.Font("Agency FB", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnValider.Location = new System.Drawing.Point(546, 347);
            this.btnValider.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(130, 53);
            this.btnValider.TabIndex = 1;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // txtMDP
            // 
            this.txtMDP.BackColor = System.Drawing.Color.White;
            this.txtMDP.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMDP.Location = new System.Drawing.Point(272, 219);
            this.txtMDP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMDP.Name = "txtMDP";
            this.txtMDP.Size = new System.Drawing.Size(404, 47);
            this.txtMDP.TabIndex = 4;
            this.txtMDP.UseSystemPasswordChar = true;
            this.txtMDP.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtLogin
            // 
            this.txtLogin.BackColor = System.Drawing.Color.White;
            this.txtLogin.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(272, 130);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(404, 47);
            this.txtLogin.TabIndex = 3;
            this.txtLogin.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(60, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mot de passe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Agency FB", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(60, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Agency FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(185, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "⚠️  Accès restreint  ⚠️";
            // 
            // erpLogin
            // 
            this.erpLogin.ContainerControl = this;
            // 
            // erpMDP
            // 
            this.erpMDP.ContainerControl = this;
            // 
            // frmMDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.grpMDP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMDP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vérification de l\'autorisation";
            this.Load += new System.EventHandler(this.frmMDP_Load);
            this.grpMDP.ResumeLayout(false);
            this.grpMDP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.erpLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpMDP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMDP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.TextBox txtMDP;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider erpLogin;
        private System.Windows.Forms.ErrorProvider erpMDP;
    }
}