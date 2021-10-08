using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProjTesteForm
{
    public partial class Menu : Form
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ProjTesteFormV4 - Testes\ControleDeEstoque.mdf;Integrated Security=True");
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
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão: " + ex.Message);
            }

            //txt que mostra usuário logado
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
            txtAdcKgBotij.Text = string.Empty;
            txtAltKgBotij.Text = string.Empty;
            txtRmvKgBotij.Text = string.Empty;
            txtAdcKgBotijEstoque.Text = string.Empty;
            txtAdcIdBotijEstoque.Text = string.Empty;
            txtAdcKgBotijEstoque.Text = string.Empty;
            rdbAbtQtdeSBotijSim.Checked = false;
            rdbAbtQtdeSBotijNao.Checked = false;
            txtRmvKgBotijEstoque.Text = string.Empty;
            txtRmvQtdeEstoque.Text = string.Empty;
            txtAdcQtdeLoteEstoque.Text = string.Empty;
            rdbRetBotijSim.Checked = false;
            rdbRetBotijNao.Checked = false;
            txtAdcKgBotijLote.Text = string.Empty;
            txtAdcQtdeBotijLote.Text = string.Empty;
            maskAdcDtLote.Text = string.Empty;
            txtAltKgBotijLote.Text = string.Empty;
            txtAltQtdeLote.Text = string.Empty;
            maskAltDtLote.Text = string.Empty;
            txtAdcNmCompUsu.Text = string.Empty;
            txtAdcNmUsuUsu.Text = string.Empty;
            txtAdcSenhaUsu.Text = string.Empty;
            txtAdcConfirSenhaUsu.Text = string.Empty;
            txtConsNomeCompUsu.Text = string.Empty;
            txtConsNmUsuUsu.Text = string.Empty;
            txtAltNomeCompUsu.Text = string.Empty;
            txtAltNomeUsuUsu.Text = string.Empty;
            txtAltSenhaUsu.Text = string.Empty;
            txtAltConfirSenhaUsu.Text = string.Empty;
            txtRmvNomeCompUsu.Text = string.Empty;
            txtRmvNomeUsuUsu.Text = string.Empty;
            txtConsKgBotij.Text = string.Empty;
            txtConsKgBotijLote.Text = string.Empty;
            txtConsQtdeLote.Text = string.Empty;
            maskConsDtLote.Text = string.Empty;
            txtConsKgBotijEstoque.Text = string.Empty;
            txtConsQtdeCheiaEstoque.Text = string.Empty;
            txtConsQtdeVaziaEstoque.Text = string.Empty;
            txtConsQtdeSemBotijEstoque.Text = string.Empty;
            txtConsIdUltLoteEstoque.Text = string.Empty;
            txtConsUsuRespEstoque.Text = string.Empty;
        }
        #endregion

        #region Região de Botijão
        public static string KgBotij { get; set; }
        public static string IdBotij { get; set; }

        // Abrir/Fechar submenu
        private void btnBotij_Click(object sender, EventArgs e)
        {
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
            txtAdcKgBotij.Text = string.Empty;
        }

        // Botão para adicionar botijão
        private void btnRotAdcBotij_Click(object sender, EventArgs e)
        {
            if (txtAdcKgBotij.Text != "2" && txtAdcKgBotij.Text != "5" && txtAdcKgBotij.Text != "8" && txtAdcKgBotij.Text != "13" && txtAdcKgBotij.Text != "20" && txtAdcKgBotij.Text != "45" && txtAdcKgBotij.Text != "90")
            {
                MessageBox.Show("Só possível cadastrar botijões de \n2Kg, 5Kg, 8Kg, 13Kg, 20Kg, 45Kg e 90Kg.");
                txtAdcKgBotij.Text = string.Empty;
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

        // Método para carregar comboBox da rotina
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
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        // Botão para abrir rotina de consulta de botijões
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
            txtConsKgBotij.Text = string.Empty;
        }
        // Botão para consultar de botijões
        private void btnRotConsBotij_Click(object sender, EventArgs e)
        {
            Botijao consBotij = new Botijao(int.Parse(cbConsIdBotij.Text));
            consBotij.ConsultarBotijao(int.Parse(cbConsIdBotij.Text));
            txtConsKgBotij.Text = KgBotij;
        }

        #endregion

        #region Região da rotina Alterar Botijão
        // Médtodo para carregar comboBox da rotina
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
                    MessageBox.Show("Imposível carregar comboBox.");
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
            txtAltKgBotij.Text = string.Empty;
        }

        // Botão para Alterar botijões
        private void btnRotAltBotij_Click(object sender, EventArgs e)
        {
            if (SessaoSistema.UsuLoginSessao == "GERENTE")
            {
                if (txtAltKgBotij.Text != "2" && txtAltKgBotij.Text != "5" && txtAltKgBotij.Text != "8" && txtAltKgBotij.Text != "13" && txtAltKgBotij.Text != "20" && txtAltKgBotij.Text != "45" && txtAltKgBotij.Text != "90")
                {
                    MessageBox.Show("Só possível cadastrar botijões de \n2Kg, 5Kg, 8Kg, 13Kg, 20Kg, 45Kg e 90Kg.");
                    txtAltKgBotij.Text = string.Empty;
                }
                else
                {
                    Botijao altBotij = new Botijao(int.Parse(cbAltIdBotij.Text), int.Parse(txtAltKgBotij.Text));
                    altBotij.AlterarBotijao(int.Parse(cbAltIdBotij.Text), int.Parse(txtAltKgBotij.Text));
                    txtAltKgBotij.Text = KgBotij;
                }
            }
            else
            {
                MessageBox.Show("Apenas o usuário GERENTE \npode realizar alterações!");
            }
        }

        // Evento para permitir apenas números no campo
        private void txtAltKgBotij_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Região da rotina Remover Botijão

        // Método para cagar comboBox da rotina
        public void CarregarCbBotijRmv()
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
                    cbRmvIdBotij.DataSource = dt;
                    cbRmvIdBotij.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        // Botão para abrir rotina de exclusão de botijões
        private void btnRmvBotij_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnRmvBotij);
            CarregarCbBotijRmv();
            CamposPadrao();
        }

        // Botão x para fechar rotina
        private void btnFecharRotRmvBotij_Click(object sender, EventArgs e)
        {
            pnRmvBotij.Visible = false;
            txtRmvKgBotij.Text = string.Empty;
        }

        // Botão para carregar dados do botijão
        private void btnRotRmvCarregarBotij_Click(object sender, EventArgs e)
        {
            Botijao consBotij = new Botijao(int.Parse(cbRmvIdBotij.Text));
            consBotij.ConsultarBotijao(int.Parse(cbRmvIdBotij.Text));
            txtRmvKgBotij.Text = KgBotij;
        }

        // Botão para remover botijão
        private void btnRotRmvBotij_Click(object sender, EventArgs e)
        {
            if (SessaoSistema.UsuLoginSessao == "GERENTE")
            {
                Botijao rmvBotij = new Botijao(int.Parse(cbRmvIdBotij.Text));
                rmvBotij.RemoverBotijao(int.Parse(cbRmvIdBotij.Text));
                txtRmvKgBotij.Text = KgBotij;
                CarregarCbBotijRmv();
            }
            else
            {
                MessageBox.Show("Apenas o usuário GERENTE \npode realizar exclusões.");
            }
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
        public static bool abateSemBotij = false;

        //Abrir rotina para adição de estoque
        private void btnAdcEstoque_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAdcEstoque);
            CamposPadrao();
            CarregarCbAdcBotijIdLote();
        }

        // Botão para fechar rotina
        private void btnFecharRotAdcEstoque_Click(object sender, EventArgs e)
        {
            pnAdcEstoque.Visible = false;
            txtAdcIdBotijEstoque.Text = string.Empty;
            txtAdcKgBotijEstoque.Text = string.Empty;
            txtAdcQtdeLoteEstoque.Text = string.Empty;
            rdbAbtQtdeSBotijSim.Checked = false;
            rdbAbtQtdeSBotijNao.Checked = false;
        }

        // Método para carregar comboBox da rotina
        public void CarregarCbAdcBotijIdLote()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM LOTE ORDER BY ID DESC";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbAdcBotijIdLote.DataSource = dt;
                    cbAdcBotijIdLote.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        // Botão para carregar dados
        private void btnRotAdcBotijCarregarLote_Click(object sender, EventArgs e)
        {
            Lote lote = new Lote(int.Parse(cbAdcBotijIdLote.Text));
            lote.ConsultarLote(int.Parse(cbAdcBotijIdLote.Text));
            txtAdcKgBotijEstoque.Text = KgBotijaoLote;
            txtAdcQtdeLoteEstoque.Text = QtdeBotijLote;
            Botijao botij = new Botijao();
            botij.ConsultarIDBotijao(int.Parse(KgBotijaoLote));
            txtAdcIdBotijEstoque.Text = IdBotij;
        }

        // Botão para adicionar estoque
        private void btnRotAdcEstoque_Click(object sender, EventArgs e)
        {
            if (rdbAbtQtdeSBotijSim.Checked == false && rdbAbtQtdeSBotijNao.Checked == false)
            {
                MessageBox.Show("Selecione uma opção para \nabate de botijão.");
            }
            else
            {
                if (rdbAbtQtdeSBotijSim.Checked == true)
                {
                    abateSemBotij = true;
                    Botijao estoque = new Botijao();
                    estoque.AdicionarEstoque(int.Parse(cbAdcBotijIdLote.Text), abateSemBotij, SessaoSistema.UsuLoginSessao);
                    txtAdcKgBotijEstoque.Text = KgBotijaoLote;
                    txtAdcQtdeLoteEstoque.Text = QtdeBotijLote;
                    txtAdcIdBotijEstoque.Text = IdBotij;
                    rdbAbtQtdeSBotijSim.Checked = false;
                    rdbAbtQtdeSBotijNao.Checked = false;
                }
                else
                {
                    abateSemBotij = false;
                    Botijao estoque = new Botijao();
                    estoque.AdicionarEstoque(int.Parse(cbAdcBotijIdLote.Text), abateSemBotij, SessaoSistema.UsuLoginSessao);
                    txtAdcKgBotijEstoque.Text = KgBotijaoLote;
                    txtAdcQtdeLoteEstoque.Text = QtdeBotijLote;
                    txtAdcIdBotijEstoque.Text = IdBotij;
                    rdbAbtQtdeSBotijSim.Checked = false;
                    rdbAbtQtdeSBotijNao.Checked = false;
                }
            }
        }
        #endregion

        #region Região da rotina Remover estoque
        public static bool retBotij;

        //Abrir rotina para remoção de estoque
        private void btnRmvEstoque_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnRmvEstoque);
            CamposPadrao();
            CarregarCbRmvIdBotijEstoque();
        }

        //Botão x para fechar a rotina
        private void btnFecharRotRmvEstoque_Click(object sender, EventArgs e)
        {
            pnRmvEstoque.Visible = false;
            txtRmvKgBotijEstoque.Text = string.Empty;
            txtRmvQtdeEstoque.Text = string.Empty;
            rdbRetBotijSim.Checked = false;
            rdbRetBotijNao.Checked = false;
        }

        //Método para carregar comboBox da rotina
        public void CarregarCbRmvIdBotijEstoque()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM BOTIJAO";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbRmvIdBotijEstoque.DataSource = dt;
                    cbRmvIdBotijEstoque.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        //Botão para carregar dados
        private void btnRotRmvBotijCarregar_Click(object sender, EventArgs e)
        {
            Botijao consEstoque = new Botijao(int.Parse(cbRmvIdBotijEstoque.Text));
            consEstoque.ConsultarEstoque(int.Parse(cbRmvIdBotijEstoque.Text));
            txtRmvKgBotijEstoque.Text = KgBotijEstoque;
        }

        //Botão para remover estoque
        private void btnRotRmvEstoque_Click(object sender, EventArgs e)
        {
            if (rdbRetBotijSim.Checked == false && rdbRetBotijNao.Checked == false)
            {
                MessageBox.Show("Selecione uma opção para \nretorno de botijão.");
            }
            else if (txtRmvQtdeEstoque.Text == "")
            {
                MessageBox.Show("Necessário adicionar uma quantidade \npara ser removida do estoque.");
            }
            else
            {
                if (rdbRetBotijSim.Checked == true)
                {
                    retBotij = true;
                    Botijao estoque = new Botijao();
                    estoque.RemoverEstoque(int.Parse(cbRmvIdBotijEstoque.Text), int.Parse(txtRmvQtdeEstoque.Text), retBotij);
                    txtRmvKgBotijEstoque.Text = KgBotijaoLote;
                    txtRmvQtdeEstoque.Text = QtdeBotijLote;
                    rdbAbtQtdeSBotijSim.Checked = false;
                    rdbAbtQtdeSBotijNao.Checked = false;
                }
                else
                {
                    retBotij = false;
                    Botijao estoque = new Botijao();
                    estoque.RemoverEstoque(int.Parse(cbRmvIdBotijEstoque.Text), int.Parse(txtRmvQtdeEstoque.Text), retBotij);
                    txtRmvKgBotijEstoque.Text = KgBotijaoLote;
                    txtRmvQtdeEstoque.Text = QtdeBotijLote;
                    rdbAbtQtdeSBotijSim.Checked = false;
                    rdbAbtQtdeSBotijNao.Checked = false;
                }
            }
        }

        //Evento para limitar campo para aceitar apenas números
        private void txtRmvQtdeEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Região da rotina Consultar estoque
        public static string IdBotijEstoque;
        public static string KgBotijEstoque;
        public static string QtdeCheiaEstoque;
        public static string QtdeVaziaEstoque;
        public static string QtdeSemBotijEstoque;
        public static string IdUltLoteEstoque;
        public static string UsuRespEstoque;

        //Abrir rotina para consulta de estoque
        private void btnConsEstoque_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsEstoque);
            CamposPadrao();
            CarregarCbConsEstoqueIdBotij();
        }

        //Botão x para fechar a rotina
        private void btnFecharRotConsEstoque_Click(object sender, EventArgs e)
        {
            pnConsEstoque.Visible = false;
            txtConsKgBotijEstoque.Text = string.Empty;
            txtConsQtdeCheiaEstoque.Text = string.Empty;
            txtConsQtdeVaziaEstoque.Text = string.Empty;
            txtConsQtdeSemBotijEstoque.Text = string.Empty;
            txtConsIdUltLoteEstoque.Text = string.Empty;
            txtConsUsuRespEstoque.Text = string.Empty;
        }

        //Método para carregar comboBox da rotina
        public void CarregarCbConsEstoqueIdBotij()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM BOTIJAO";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbConsEstoqueIdBotij.DataSource = dt;
                    cbConsEstoqueIdBotij.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        //Botão para consultar estoque
        private void btnRotConsEstoque_Click(object sender, EventArgs e)
        {
            Botijao consEstoque = new Botijao(int.Parse(cbConsEstoqueIdBotij.Text));
            consEstoque.ConsultarEstoque(int.Parse(cbConsEstoqueIdBotij.Text));
            txtConsKgBotijEstoque.Text = KgBotijEstoque;
            txtConsQtdeCheiaEstoque.Text = QtdeCheiaEstoque;
            txtConsQtdeVaziaEstoque.Text = QtdeVaziaEstoque;
            txtConsQtdeSemBotijEstoque.Text = QtdeSemBotijEstoque;
            txtConsIdUltLoteEstoque.Text = IdUltLoteEstoque;
            txtConsUsuRespEstoque.Text = UsuRespEstoque;
        }

        #endregion

        #endregion

        #region Região de Lote

        public static string KgBotijaoLote { get; set; }
        public static string QtdeBotijLote { get; set; }
        public static string DataBotijLote { get; set; }

        // Abrir/Fechar submenu
        private void btnLote_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(pnSubLote);
        }

        #region Região da rotina Adicionar lote
        public static string KgBotijLote { get; set; }
        public static string QtdeEnvLote { get; set; }
        public static string DataLote { get; set; }

        // Abrir rotina para adição de lote
        private void btnAdcLote_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAdcLote);
            CamposPadrao();
        }

        // Botão x para fechar a rotina
        private void btnFecharRotAdcLote_Click(object sender, EventArgs e)
        {
            pnAdcLote.Visible = false;
            txtAdcKgBotijLote.Text = string.Empty;
            txtAdcQtdeBotijLote.Text = string.Empty;
            maskAdcDtLote.Text = string.Empty;
        }

        // Evento para limitar campo aceitar apenas números
        private void txtAdcKgBotijLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        // Evento para limitar campo aceitar apenas números
        private void txtAdcQtdeBotijLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        // Botão para adicionar lote
        private void btnRotAdcLote_Click(object sender, EventArgs e)
        {
            if (txtAdcKgBotijLote.Text == string.Empty || txtAdcQtdeBotijLote.Text == string.Empty || maskAdcDtLote.Text == "  /  /")
            {
                MessageBox.Show("Todos os campos são de \npreenchimento obrigatório.");
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
            CarregarCbLoteAlt();
        }

        // Botão x para fechar a rotina
        private void btnFecharRotAltLote_Click(object sender, EventArgs e)
        {
            pnAltLote.Visible = false;
            txtAltKgBotijLote.Text = string.Empty;
            txtAltQtdeLote.Text = string.Empty;
            maskAltDtLote.Text = string.Empty;
        }

        // Método para carregar comboBox da rotina
        public void CarregarCbLoteAlt()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM LOTE ORDER BY ID DESC";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbAltIdLote.DataSource = dt;
                    cbAltIdLote.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        // Botão carregar dados
        private void btnRotAltCarregarLote_Click(object sender, EventArgs e)
        {

            Lote lote = new Lote(int.Parse(cbAltIdLote.Text));
            lote.ConsultarLote(int.Parse(cbAltIdLote.Text));
            txtAltKgBotijLote.Text = KgBotijaoLote;
            txtAltQtdeLote.Text = QtdeBotijLote;
            maskAltDtLote.Text = DataBotijLote;
        }

        // Botão para alterar Lote
        private void btnRotAltLote_Click(object sender, EventArgs e)
        {
            if (txtAltKgBotijLote.Text == string.Empty || txtAltQtdeLote.Text == string.Empty || maskAltDtLote.Text == "  /  /")
            {
                MessageBox.Show("Todos os campos são de \npreenchimento obrigatório.");
            }
            else
            {
                Lote lote = new Lote(int.Parse(cbAltIdLote.Text), int.Parse(txtAltKgBotijLote.Text), int.Parse(txtAltQtdeLote.Text), maskAltDtLote.Text, SessaoSistema.UsuLoginSessao);
                lote.AlterarLote(int.Parse(cbAltIdLote.Text), int.Parse(txtAltKgBotijLote.Text), int.Parse(txtAltQtdeLote.Text), maskAltDtLote.Text, SessaoSistema.UsuLoginSessao);
                txtAltKgBotijLote.Text = KgBotijLote;
                txtAltQtdeLote.Text = QtdeEnvLote;
                maskAltDtLote.Text = DataLote;
            }
        }

        // Evento para limitar campo a aceitar apenas números
        private void txtAltKgBotijLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        // Evento para limitar campo a aceitar apenas números
        private void txtAltQtdeLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Região da rotina Consulta lote
        //Abrir rotina para consulta de lote
        private void btnConsLote_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsLote);
            CarregarCbLoteCons();
            CamposPadrao();
        }

        // Botão x para fechar a rotina
        private void btnFecharRotConsLote_Click(object sender, EventArgs e)
        {
            pnConsLote.Visible = false;
            txtConsKgBotijLote.Text = string.Empty;
            txtConsQtdeLote.Text = string.Empty;
            maskConsDtLote.Text = string.Empty;
        }

        // Método para carregar comboBox da rotina
        public void CarregarCbLoteCons()
        {

            string sql;
            try
            {
                sql = "SELECT ID FROM LOTE ORDER BY ID DESC";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    cbConsIdLote.DataSource = dt;
                    cbConsIdLote.DisplayMember = "ID";
                }
                else
                {
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        // Botão para consultar Lote
        private void btnRotConsLote_Click(object sender, EventArgs e)
        {
            Lote lote = new Lote(int.Parse(cbConsIdLote.Text));
            lote.ConsultarLote(int.Parse(cbConsIdLote.Text));
            txtConsKgBotijLote.Text = KgBotijaoLote;
            txtConsQtdeLote.Text = QtdeBotijLote;
            maskConsDtLote.Text = DataBotijLote;
        }

        #endregion
        #endregion

        #region Região de Usuários
        public static string NomeCompUsu { get; set; }
        public static string NmUsuUsu { get; set; }
        public static string SenhaUsu { get; set; }
        public static string ConfSenhaUsu { get; set; }

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

        //Botão x para fechar a rotina
        private void btnFecharRotAdcUsuario_Click(object sender, EventArgs e)
        {
            pnAdcUsuario.Visible = false;
            txtAdcNmCompUsu.Text = string.Empty;
            txtAdcNmUsuUsu.Text = string.Empty;
            txtAdcSenhaUsu.Text = string.Empty;
            txtAdcConfirSenhaUsu.Text = string.Empty;
        }

        //Botão para adicionar usuário
        private void btnRotAdcUsu_Click(object sender, EventArgs e)
        {
            if (txtAdcNmCompUsu.Text == "" || txtAdcNmUsuUsu.Text == "" || txtAdcSenhaUsu.Text == "")
            {
                MessageBox.Show("Todsos os campos \nsão obrigatórios.");
            }
            else
            {
                Usuarios adcusu = new Usuarios(txtAdcNmCompUsu.Text, txtAdcNmUsuUsu.Text, txtAdcSenhaUsu.Text);
                adcusu.CadastrarUsuario(txtAdcNmCompUsu.Text, txtAdcNmUsuUsu.Text, txtAdcSenhaUsu.Text, txtAdcConfirSenhaUsu.Text);
                txtAdcNmCompUsu.Text = NomeCompUsu;
                txtAdcNmUsuUsu.Text = NmUsuUsu;
                txtAdcSenhaUsu.Text = SenhaUsu;
                txtAdcConfirSenhaUsu.Text = ConfSenhaUsu;
            }

        }
        #endregion

        #region Região da rotina Consultar usuários
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

        //Abrir rotina para consulta de usuários
        private void btnConsUsu_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnConsUsuario);
            CarregarCbUsuCons();
            CamposPadrao();
        }

        //Botão x para fechar a rotina
        private void btnFecharRotConsUsuario_Click(object sender, EventArgs e)
        {
            pnConsUsuario.Visible = false;
            txtConsNomeCompUsu.Text = string.Empty;
            txtConsNmUsuUsu.Text = string.Empty;
        }

        //Botão para consultar usuário
        private void btnRotConsUsu_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(int.Parse(cbConsIdUsu.Text));
            usuario.ConsultarUsuario(int.Parse(cbConsIdUsu.Text));
            txtConsNomeCompUsu.Text = NomeCompUsu;
            txtConsNmUsuUsu.Text = NmUsuUsu;
        }

        #endregion

        #region Região da rotina Alterar usuários
        //Método para carregar comboBox da rotina
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
                    MessageBox.Show("Imposível carregar comboBox.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

        //Abrir rotina para alteração de usuários
        private void btnAltUsu_Click(object sender, EventArgs e)
        {
            EsconderSubMenu();
            MostrarRotinas(pnAltUsuario);
            CarregarCbUsuAlt();
            CamposPadrao();
        }

        //Botão x para fechar rotina
        private void btnFecharRotAltUsuario_Click(object sender, EventArgs e)
        {
            pnAltUsuario.Visible = false;
            txtAltNomeCompUsu.Text = string.Empty;
            txtAltNomeUsuUsu.Text = string.Empty;
            txtAltSenhaUsu.Text = string.Empty;
            txtAltConfirSenhaUsu.Text = string.Empty;
        }

        //Botão para carregar dados
        private void btnRotAltCarregarUsu_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(int.Parse(cbAltIdUsu.Text));
            usuario.ConsultarUsuario(int.Parse(cbAltIdUsu.Text));
            txtAltNomeCompUsu.Text = NomeCompUsu;
            txtAltNomeUsuUsu.Text = NmUsuUsu;
        }

        //Botão para Alterar usuário
        private void btnRotAltUsu_Click(object sender, EventArgs e)
        {
            if (SessaoSistema.UsuLoginSessao == "GERENTE")
            {
                if (txtAltNomeCompUsu.Text == "" || txtAltNomeUsuUsu.Text == "" || txtAltSenhaUsu.Text == "")
                {
                    MessageBox.Show("Todos os campos \nsão obrigatórios.");
                }
                else
                {
                    Usuarios altUsu = new Usuarios(int.Parse(cbAltIdUsu.Text), txtAltNomeCompUsu.Text, txtAltNomeUsuUsu.Text, txtAltSenhaUsu.Text);
                    altUsu.AlterarUsuario(int.Parse(cbAltIdUsu.Text), txtAltNomeCompUsu.Text, txtAltNomeUsuUsu.Text, txtAltSenhaUsu.Text, txtAltConfirSenhaUsu.Text);
                    txtAltNomeCompUsu.Text = NomeCompUsu;
                    txtAltNomeUsuUsu.Text = NmUsuUsu;
                    txtAltSenhaUsu.Text = SenhaUsu;
                    txtAltConfirSenhaUsu.Text = ConfSenhaUsu;
                }
            }
            else
            {
                MessageBox.Show("Apenas o usuário GERENTE \npode realizar alterações.");
            }


        }

        #endregion

        #region Região da rotina Remover usuários
        //Método para carregar combobox da rotina
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

        //Botão x para fechar a rotina
        private void btnFecharRotRmvUsuario_Click(object sender, EventArgs e)
        {
            pnRmvUsuario.Visible = false;
            txtRmvNomeCompUsu.Text = string.Empty;
            txtRmvNomeUsuUsu.Text = string.Empty;
        }

        //Botão para carregar dados
        private void btnRotRmvCarregarUsu_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios(int.Parse(cbRmvIdUsu.Text));
            usuario.ConsultarUsuario(int.Parse(cbRmvIdUsu.Text));
            txtRmvNomeCompUsu.Text = NomeCompUsu;
            txtRmvNomeUsuUsu.Text = NmUsuUsu;
        }

        //Botão para remover usuário
        private void btnRotRmvUsu_Click(object sender, EventArgs e)
        {

            if (SessaoSistema.UsuLoginSessao == "GERENTE")
            {
                Usuarios rmvusu = new Usuarios(int.Parse(cbRmvIdUsu.Text));
                rmvusu.RemoverUsuario(int.Parse(cbRmvIdUsu.Text));
                CarregarCbUsuRmv();
                txtRmvNomeCompUsu.Text = NomeCompUsu;
                txtRmvNomeUsuUsu.Text = NmUsuUsu;
            }
            else
            {
                MessageBox.Show("Apenas o usuário GERENTE \npode realizar exclusões.");
            }

        }
        #endregion
        #endregion  
    }
}