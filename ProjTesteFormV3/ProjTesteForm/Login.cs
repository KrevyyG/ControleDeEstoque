using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjTesteForm
{
    public partial class Login : Form
    {
        public bool mover = false;
        public Point pos_ini;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtUsuLogin_Enter(object sender, EventArgs e)
        {
            if (txtUsuLogin.Text == "USUÁRIO")
            {
                txtUsuLogin.Text = "";
                txtUsuLogin.ForeColor = Color.White;
            }
        }

        private void txtSenhaLogin_Enter(object sender, EventArgs e)
        {
            if (txtSenhaLogin.Text == "SENHA")
            {
                txtSenhaLogin.Text = "";
                txtSenhaLogin.ForeColor = Color.White;
                txtSenhaLogin.PasswordChar = '*';
            }
        }

        private void txtUsuLogin_Leave(object sender, EventArgs e)
        {
            if (txtUsuLogin.Text == "")
            {
                txtUsuLogin.Text = "USUÁRIO";
                txtUsuLogin.ForeColor = Color.Silver;
            }
        }

        private void txtSenhaLogin_Leave(object sender, EventArgs e)
        {
            if (txtSenhaLogin.Text == "")
            {
                txtSenhaLogin.Text = "SENHA";
                txtSenhaLogin.ForeColor = Color.Silver;
                txtSenhaLogin.PasswordChar = '\u0000';
            }
        }

        private void geral_MouseDown(object sender, MouseEventArgs e)
        {
            mover = true;
            pos_ini = new Point(e.X, e.Y);
        }

        private void geral_MouseUp(object sender, MouseEventArgs e)
        {
            mover = false;
        }

        private void geral_MouseMove(object sender, MouseEventArgs e)
        {
            if (mover)
            {
                Point novo = PointToScreen(e.Location);
                Location = new Point(novo.X - this.pos_ini.X, novo.Y - this.pos_ini.Y);
            }
        }

        public static bool loginSucess { get; set; } = false;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Metodo para validar Login
            Usuarios login = new Usuarios();
            login.ValidarLogin(txtUsuLogin.Text, txtSenhaLogin.Text);
            if (loginSucess == true)
            {
                this.Hide();
            }
        }
    }
}
