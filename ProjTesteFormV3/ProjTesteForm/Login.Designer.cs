
namespace ProjTesteForm
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUsuLogin = new System.Windows.Forms.TextBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtSenhaLogin = new System.Windows.Forms.TextBox();
            this.pnTitulo = new System.Windows.Forms.Panel();
            this.btnFecharLogin = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.pnCentro = new System.Windows.Forms.Panel();
            this.pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.pnCentro.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(4, 23);
            this.panel1.TabIndex = 2;
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.pnMenu.Controls.Add(this.panel1);
            this.pnMenu.Controls.Add(this.flowLayoutPanel2);
            this.pnMenu.Controls.Add(this.flowLayoutPanel1);
            this.pnMenu.Controls.Add(this.txtUsuLogin);
            this.pnMenu.Controls.Add(this.picLogo);
            this.pnMenu.Controls.Add(this.btnLogin);
            this.pnMenu.Controls.Add(this.txtSenhaLogin);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(153, 420);
            this.pnMenu.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 262);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(147, 1);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 231);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(147, 1);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // txtUsuLogin
            // 
            this.txtUsuLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.txtUsuLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuLogin.ForeColor = System.Drawing.Color.Silver;
            this.txtUsuLogin.Location = new System.Drawing.Point(3, 212);
            this.txtUsuLogin.MaxLength = 10;
            this.txtUsuLogin.Name = "txtUsuLogin";
            this.txtUsuLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsuLogin.Size = new System.Drawing.Size(147, 13);
            this.txtUsuLogin.TabIndex = 4;
            this.txtUsuLogin.Text = "USUÁRIO";
            this.txtUsuLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsuLogin.Enter += new System.EventHandler(this.txtUsuLogin_Enter);
            this.txtUsuLogin.Leave += new System.EventHandler(this.txtUsuLogin_Leave);
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(153, 121);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(0, 297);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(153, 25);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.TabStop = false;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtSenhaLogin
            // 
            this.txtSenhaLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.txtSenhaLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenhaLogin.ForeColor = System.Drawing.Color.Silver;
            this.txtSenhaLogin.Location = new System.Drawing.Point(3, 243);
            this.txtSenhaLogin.MaxLength = 10;
            this.txtSenhaLogin.Name = "txtSenhaLogin";
            this.txtSenhaLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSenhaLogin.Size = new System.Drawing.Size(147, 13);
            this.txtSenhaLogin.TabIndex = 5;
            this.txtSenhaLogin.Text = "SENHA";
            this.txtSenhaLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaLogin.Enter += new System.EventHandler(this.txtSenhaLogin_Enter);
            this.txtSenhaLogin.Leave += new System.EventHandler(this.txtSenhaLogin_Leave);
            // 
            // pnTitulo
            // 
            this.pnTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(3)))), ((int)(((byte)(59)))));
            this.pnTitulo.Controls.Add(this.btnFecharLogin);
            this.pnTitulo.Controls.Add(this.btnMinimizar);
            this.pnTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnTitulo.Name = "pnTitulo";
            this.pnTitulo.Size = new System.Drawing.Size(477, 39);
            this.pnTitulo.TabIndex = 6;
            this.pnTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.geral_MouseDown);
            this.pnTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.geral_MouseMove);
            this.pnTitulo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.geral_MouseUp);
            // 
            // btnFecharLogin
            // 
            this.btnFecharLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnFecharLogin.Image")));
            this.btnFecharLogin.Location = new System.Drawing.Point(445, 6);
            this.btnFecharLogin.Name = "btnFecharLogin";
            this.btnFecharLogin.Size = new System.Drawing.Size(25, 25);
            this.btnFecharLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFecharLogin.TabIndex = 0;
            this.btnFecharLogin.TabStop = false;
            this.btnFecharLogin.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(421, 6);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(25, 25);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMinimizar.TabIndex = 1;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // pnCentro
            // 
            this.pnCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(62)))));
            this.pnCentro.Controls.Add(this.pnTitulo);
            this.pnCentro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCentro.Location = new System.Drawing.Point(153, 0);
            this.pnCentro.Name = "pnCentro";
            this.pnCentro.Size = new System.Drawing.Size(477, 420);
            this.pnCentro.TabIndex = 2;
            // 
            // Login
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(630, 420);
            this.Controls.Add(this.pnCentro);
            this.Controls.Add(this.pnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(630, 420);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFecharLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.pnCentro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Panel pnTitulo;
        private System.Windows.Forms.PictureBox btnFecharLogin;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.Panel pnCentro;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtUsuLogin;
        private System.Windows.Forms.TextBox txtSenhaLogin;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

