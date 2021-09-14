using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjTesteForm
{
    public partial class Menu : Form
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ProjTesteFormV3\ControleDeEstoque.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public Menu()
        {
            InitializeComponent();
            //Comando para iniciar pannels invisíveis
            CustomizarDesign();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            //txt que mostra usuário logado
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão: " + ex.Message);
            }
            txtUsuMenu.Text = SessaoSistema.UsuLoginSessao;
        }

        #region Comandos para deixar tela movimentável
        bool mover;
        Point pos_ini;

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
        #endregion

        # region Botões para interações com tela
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SessaoSistema.UsuLoginSessao = "";
            Login login = new Login();
            this.Close();
            login.Show();
        }
        #endregion

        #region Esconder pannels
        public void CustomizarDesign()
        {
            pnSubBotij.Visible = false;
            pnSubEstoque.Visible = false;
            pnSubLote.Visible = false;
            pnSubUsu.Visible = false;
            pnAdcBotij.Visible = false;
            pnConsBotij.Visible = false;
            pnAltBotij.Visible = false;
            pnRmvBotij.Visible = false;
            pnAdcEstoque.Visible = false;
            pnRmvEstoque.Visible = false;
            pnConsEstoque.Visible = false;
            pnAdcLote.Visible = false;
            pnAltLote.Visible = false;
            pnConsLote.Visible = false;
            pnAdcUsuario.Visible = false;
            pnConsUsuario.Visible = false;
            pnAltUsuario.Visible = false;
            pnRmvUsuario.Visible = false;
        }
        #endregion

        #region Metodos para mostrar e esconder submenu
        public void EsconderSubMenu()
        {
            if (pnSubBotij.Visible == true)
            {
                pnSubBotij.Visible = false;
            }
            if (pnSubEstoque.Visible == true)
            {
                pnSubEstoque.Visible = false;
            }
            if (pnSubLote.Visible == true)
            {
                pnSubLote.Visible = false;
            }
            if (pnSubUsu.Visible == true)
            {
                pnSubUsu.Visible = false;
            }
        }

        public void MostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                EsconderSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }

        }
        #endregion

        #region Metodos para mostrar e esconder pannels rotinas
        public void EsconderRotinas()
        {
            if (pnAdcBotij.Visible == true)
            {
                pnAdcBotij.Visible = false;
            }
            if (pnConsBotij.Visible == true)
            {
                pnConsBotij.Visible = false;
            }
            if (pnAltBotij.Visible == true)
            {
                pnAltBotij.Visible = false;
            }
            if (pnRmvBotij.Visible == true)
            {
                pnRmvBotij.Visible = false;
            }
            if (pnAdcEstoque.Visible == true)
            {
                pnAdcEstoque.Visible = false;
            }
            if (pnRmvEstoque.Visible == true)
            {
                pnRmvEstoque.Visible = false;
            }
            if (pnConsEstoque.Visible == true)
            {
                pnConsEstoque.Visible = false;
            }
            if (pnAdcLote.Visible == true)
            {
                pnAdcLote.Visible = false;
            }
            if (pnAltLote.Visible == true)
            {
                pnAltLote.Visible = false;
            }
            if (pnConsLote.Visible == true)
            {
                pnConsLote.Visible = false;
            }
            if (pnAdcUsuario.Visible == true)
            {
                pnAdcUsuario.Visible = false;
            }
            if (pnConsUsuario.Visible == true)
            {
                pnConsUsuario.Visible = false;
            }
            if (pnAltUsuario.Visible == true)
            {
                pnAltUsuario.Visible = false;
            }
            if (pnRmvUsuario.Visible == true)
            {
                pnRmvUsuario.Visible = false;
            }
        }

        public void MostrarRotinas(Panel rotina)
        {
            if (rotina.Visible == false)
            {
                EsconderRotinas();
                rotina.Visible = true;
            }
            else
            {
                rotina.Visible = false;
            }

        }
        #endregion

        #region Definir campos como padrão
        public void CamposPadrao()
        {
            txtAdcKgBotij.Text = "";
            txtAltKgBotij.Text = "";
            txtRmvKgBotij.Text = "";
            txtAdcIdLoteEstoque.Text = "";
            txtAdcKgBotijEstoque.Text = "";
            txtAdcIdBotijEstoque.Text = "";
            txtAdcKgBotijEstoque.Text = "";
            rdbAbtQtdeSBotijSim.Checked = false;
            rdbAbtQtdeSBotijNao.Checked = false;
            txtRmvKgBotijEstoque.Text = "";
            txtRmvQtdeEstoque.Text = "";
            rdbRetBotijSim.Checked = false;
            rdbRetBotijNao.Checked = false;
            txtAdcKgBotijLote.Text = "";
            txtAdcQtdeBotijLote.Text = "";
            maskAdcDtLote.Text = "";
            txtAltKgBotijLote.Text = "";
            txtAltQtdeLote.Text = "";
            txtAltDtLote.Text = "";
            txtAdcNmCompUsu.Text = "";
            txtAdcNmUsuUsu.Text = "";
            txtAdcSenhaUsu.Text = "";
            txtAdcConfirSenhaUsu.Text = "";
            txtConsNomeCompUsu.Text = "";
            txtConsNmUsuUsu.Text = "";
            txtAltNomeCompUsu.Text = "";
            txtAltNomeUsuUsu.Text = "";
            txtAltSenhaUsu.Text = "";
            txtAltConfirSenhaUsu.Text = "";
            txtRmvNomeCompUsu.Text = "";
            txtRmvNomeUsuUsu.Text = "";
            txtConsKgBotij.Text = "";
        }
        #endregion

        #region Região de Botijão


        // Abrir/Fechar submenu

        public static string KgBotij { get; set; }

        private void btnBotij_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarSubMenu(pnSubBotij);
        }

        #region Região da rotina Adicionar Botijão
        //Abrir rotina para adição de botijão
        private void btnAdcBotij_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAdcBotij);
            CamposPadrao();
        }

        //Botão x para fechar rotina
        private void btnFecharRotAdcBotij_Click(object sender, EventArgs e)
        {
            pnAdcBotij.Visible = false;
            txtAdcKgBotij.Text = "";
        }

        // Botão para adicionar botijão
        private void btnRotAdcBotij_Click(object sender, EventArgs e)
        {
            if (txtAdcKgBotij.Text != "2" && txtAdcKgBotij.Text != "5" && txtAdcKgBotij.Text != "8" && txtAdcKgBotij.Text != "13" && txtAdcKgBotij.Text != "20" && txtAdcKgBotij.Text != "45" && txtAdcKgBotij.Text != "90")
            {
                MessageBox.Show("Só possível cadastrar botijões de \n2Kg, 5Kg, 8Kg, 13Kg, 20Kg, 45Kg e 90Kg");
                txtAdcKgBotij.Text = "";
            }
            else
            {
                Botijao adcBotij = new Botijao();
                adcBotij.AdicionarBotijao(int.Parse(txtAdcKgBotij.Text));
                txtAdcKgBotij.Text = KgBotij;
            }
        }

        // Comando para permitir apenas números no txt de adicionar botijões
        private void txtRotAdcKgBotij_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Região da rotina Consultar Botijão
        // Botão para abrir rotina de consulta de botijões

        public void CarregarCbBotijCons()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM BOTIJAO ORDER BY ID";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbConsIdBotij.DataSource = dt;
                    cbConsIdBotij.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox!");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        private void btnConsBotij_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsBotij);
            CarregarCbBotijCons();
            CamposPadrao();
        }

        // Botão x para fechar rotina
        private void btnFecharRotConsBotij_Click(object sender, EventArgs e)
        {
            pnConsBotij.Visible = false;
        }

        private void btnRotConsBotij_Click(object sender, EventArgs e)
        {
            Botijao consBotij = new Botijao(int.Parse(cbConsIdBotij.Text));
            consBotij.ConsultarBotijao(int.Parse(cbConsIdBotij.Text));
            txtConsKgBotij.Text = KgBotij;
        }

        #endregion

        #region Região da rotina Alterar Botijão

        public void CarregarCbBotijAlt()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM BOTIJAO ORDER BY ID";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbAltIdBotij.DataSource = dt;
                    cbAltIdBotij.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox!");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        // Botão para abrir rotina de alterações de botijões
        private void btnAltBotij_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAltBotij);
            CarregarCbBotijAlt();
            CamposPadrao();
        }

        // Botão x para fechar rotina
        private void btnFecharRotAltBotij_Click(object sender, EventArgs e)
        {
            pnAltBotij.Visible = false;
        }

        #endregion

        #region Região da rotina Remover Botijão
        // Botão para abrir rotina de exclusão de botijões
        private void btnRmvBotij_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnRmvBotij);
            CamposPadrao();
        }

        // Botão x para fechar rotina
        private void btnFecharRotRmvBotij_Click(object sender, EventArgs e)
        {
            pnRmvBotij.Visible = false;
        }
        #endregion

        #endregion

        #region Região de Estoque

        // Abrir/Fechar submenu
        private void btnEstoque_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnSubEstoque);
        }

        #region Região da rotina Adicionar estoque
        //Abrir rotina para adição de estoque
        private void btnAdcEstoque_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAdcEstoque);
            CamposPadrao();
        }

        // Botão para fechar rotina
        private void btnFecharRotAdcEstoque_Click(object sender, EventArgs e)
        {
            pnAdcEstoque.Visible = false;
            txtAdcIdBotijEstoque.Text = "";
            txtAdcKgBotijEstoque.Text = "";
            txtAdcIdLoteEstoque.Text = "";
            txtAdcQtdeLoteEstoque.Text = "";
            rdbAbtQtdeSBotijSim.Checked = false;
            rdbAbtQtdeSBotijNao.Checked = false;
        }
        #endregion

        #region Região da rotina Remover estoque
        //Abrir rotina para remoção de estoque
        private void btnRmvEstoque_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnRmvEstoque);
            CamposPadrao();
        }

        private void btnFecharRotRmvEstoque_Click(object sender, EventArgs e)
        {
            pnRmvEstoque.Visible = false;
        }
        #endregion

        #region Região da rotina Consultar estoque
        //Abrir rotina para consulta de estoque
        private void btnConsEstoque_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsEstoque);
            CamposPadrao();
        }

        private void btnFecharRotConsEstoque_Click(object sender, EventArgs e)
        {
            pnConsEstoque.Visible = false;
        }
        #endregion

        #endregion

        #region Região de Lote

        // Abrir/Fechar submenu
        private void btnLote_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnSubLote);
        }

        #region Região da rotina Adicionar lote
        // Abrir rotina para adição de lote

        public static string KgBotijLote { get; set; }
        public static string QtdeEnvLote { get; set; }
        public static string DataLote { get; set; }

        private void btnAdcLote_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAdcLote);
            CamposPadrao();
        }

        private void btnFecharRotAdcLote_Click(object sender, EventArgs e)
        {
            pnAdcLote.Visible = false;
        }

        private void txtAdcKgBotijLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtAdcQtdeBotijLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void btnRotAdcLote_Click(object sender, EventArgs e)
        {
            if (txtAdcKgBotijLote.Text == "" || txtAdcQtdeBotijLote.Text == "" || maskAdcDtLote.Text == "  /  /")
            {
                MessageBox.Show("Todos os campos são de \npreenchimento obrigatório!");
            }
            else
            {
                Lote adcLote = new Lote();
                adcLote.AdicionarLote(int.Parse(txtAdcKgBotijLote.Text), int.Parse(txtAdcQtdeBotijLote.Text), maskAdcDtLote.Text, SessaoSistema.UsuLoginSessao);
                txtAdcKgBotijLote.Text = KgBotijLote;
                txtAdcQtdeBotijLote.Text = QtdeEnvLote;
                maskAdcDtLote.Text = DataLote;

            }
        }

        #endregion

        #region Região da rotina Alteração lote
        // Abrir rotina para alteração de lote
        private void btnAltLote_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAltLote);
            CamposPadrao();
        }
        private void btnFecharRotAltLote_Click(object sender, EventArgs e)
        {
            pnAltLote.Visible = false;
        }
        #endregion

        #region Região da rotina Consulta lote
        //Abrir rotina para consulta de lote
        private void btnConsLote_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsLote);
            CamposPadrao();
        }
        private void btnFecharRotConsLote_Click(object sender, EventArgs e)
        {
            pnConsLote.Visible = false;
        }
        #endregion
        #endregion

        #region Região de Usuários
        // Abrir/Fechar submenu
        private void btnUsu_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnSubUsu);

        }

        #region Região da rotina Adicionar usuários
        //Abrir rotina para adição de usuários 
        private void btnAdcUsu_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAdcUsuario);
            CamposPadrao();

        }
        private void btnFecharRotAdcUsuario_Click(object sender, EventArgs e)
        {
            pnAdcUsuario.Visible = false;
            txtAdcNmCompUsu.Text = "";
            txtAdcNmUsuUsu.Text = "";
            txtAdcSenhaUsu.Text = "";
            txtAdcConfirSenhaUsu.Text = "";
        }

        private void btnRotAdcUsu_Click(object sender, EventArgs e)
        {
            Usuarios adcusu = new Usuarios(txtAdcNmCompUsu.Text, txtAdcNmUsuUsu.Text, txtAdcSenhaUsu.Text);
            adcusu.CadastrarUsuario(txtAdcNmCompUsu.Text, txtAdcNmUsuUsu.Text, txtAdcSenhaUsu.Text, txtAdcConfirSenhaUsu.Text);
        }
        #endregion

        #region Região da rotina Consultar usuários
        //Abrir rotina para consulta de usuários

        public static string NomeCompUsu { get; set; }
        public static string NmUsuUsu { get; set; }


        //Metodo para carregar ComboBox de Consulta de Usuario

        public void CarregarCbUsuCons()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM USUARIO ORDER BY ID";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbConsIdUsu.DataSource = dt;
                    cbConsIdUsu.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox!");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }
        private void btnConsUsu_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsUsuario);
            CarregarCbUsuCons();
            CamposPadrao();
        }
        private void btnFecharRotConsUsuario_Click(object sender, EventArgs e)
        {
            pnConsUsuario.Visible = false;
            txtConsNomeCompUsu.Text = "";
            txtConsNmUsuUsu.Text = "";
        }
        private void btnRotConsUsu_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(int.Parse(cbConsIdUsu.Text));
            usuario.ConsultarUsuario(int.Parse(cbConsIdUsu.Text));
            txtConsNomeCompUsu.Text = NomeCompUsu;
            txtConsNmUsuUsu.Text = NmUsuUsu;
        }

        #endregion

        #region Região da rotina Alterar usuários
        //Abrir rotina para alteração de usuários
        public void CarregarCbUsuAlt()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM USUARIO ORDER BY ID";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbAltIdUsu.DataSource = dt;
                    cbAltIdUsu.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox!");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }
        private void btnAltUsu_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAltUsuario);
            CarregarCbUsuAlt();
            CamposPadrao();
        }
        private void btnFecharRotAltUsuario_Click(object sender, EventArgs e)
        {
            pnAltUsuario.Visible = false;
            txtAltNomeCompUsu.Text = "";
            txtAltNomeUsuUsu.Text = "";
            txtAltSenhaUsu.Text = "";
            txtAltConfirSenhaUsu.Text = "";
        }
        private void btnRotAltCarregarUsu_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(int.Parse(cbAltIdUsu.Text));
            usuario.ConsultarUsuario(int.Parse(cbAltIdUsu.Text));
            txtAltNomeCompUsu.Text = NomeCompUsu;
            txtAltNomeUsuUsu.Text = NmUsuUsu;
        }
        private void btnRotAltUsu_Click(object sender, EventArgs e)
        {
            Usuarios altUsu = new Usuarios(int.Parse(cbAltIdUsu.Text), txtAltNomeCompUsu.Text, txtAltNomeUsuUsu.Text, txtAltSenhaUsu.Text);
            altUsu.AlterarUsuario(int.Parse(cbAltIdUsu.Text), txtAltNomeCompUsu.Text, txtAltNomeUsuUsu.Text, txtAltSenhaUsu.Text, txtAltConfirSenhaUsu.Text);
        }

        #endregion

        #region Região da rotina Remover usuários

        public void CarregarCbUsuRmv()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM USUARIO ORDER BY ID";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbRmvIdUsu.DataSource = dt;
                    cbRmvIdUsu.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox!");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

        //Abrir rotina para exclusão de usuários
        private void btnRmvUsu_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnRmvUsuario);
            CarregarCbUsuRmv();
            CamposPadrao();
        }
        private void btnFecharRotRmvUsuario_Click(object sender, EventArgs e)
        {
            pnRmvUsuario.Visible = false;
            txtRmvNomeCompUsu.Text = "";
            txtRmvNomeUsuUsu.Text = "";
        }
        private void btnRotRmvCarregarUsu_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(int.Parse(cbRmvIdUsu.Text));
            usuario.ConsultarUsuario(int.Parse(cbRmvIdUsu.Text));
            txtRmvNomeCompUsu.Text = NomeCompUsu;
            txtRmvNomeUsuUsu.Text = NmUsuUsu;
        }
        private void btnRotRmvUsu_Click(object sender, EventArgs e)
        {
            Usuarios rmvusu = new Usuarios(int.Parse(cbRmvIdUsu.Text));
            rmvusu.RemoverUsuario(int.Parse(cbRmvIdUsu.Text));
            CarregarCbUsuRmv();
        }



        #endregion

        #endregion

        private void btnRotAltBotij_Click(object sender, EventArgs e)
        {
            if (txtAltKgBotij.Text != "2" && txtAltKgBotij.Text != "5" && txtAltKgBotij.Text != "8" && txtAltKgBotij.Text != "13" && txtAltKgBotij.Text != "20" && txtAltKgBotij.Text != "45" && txtAltKgBotij.Text != "90")
            {
                MessageBox.Show("Só possível cadastrar botijões de \n2Kg, 5Kg, 8Kg, 13Kg, 20Kg, 45Kg e 90Kg");
                txtAltKgBotij.Text = "";
            }
            else
            {
                Botijao altBotij = new Botijao(int.Parse(cbAltIdBotij.Text), int.Parse(txtAltKgBotij.Text));
                altBotij.AlterarBotijao(int.Parse(cbAltIdBotij.Text), int.Parse(txtAltKgBotij.Text));
                txtAltKgBotij.Text = KgBotij;
            }
        }
    }
}