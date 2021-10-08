using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjTesteForm
{
    class Usuarios
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ProjTesteFormV3\ControleDeEstoque.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public int IdUsu { get; }
        public string Nome { get; private set; }
        public string NomeUsu { get; internal set; }
        public string SenhaUsu { get; private set; }

        public Usuarios()
        {

        }

        public Usuarios(int id)
        {
            IdUsu = id;
        }

        public Usuarios(string nome, string nmUsu, string senha)
        {
            Nome = nome;
            NomeUsu = nmUsu;
            SenhaUsu = senha;
        }

        public Usuarios(int id, string nome, string nmUsu, string senha)
        {
            IdUsu = id;
            Nome = nome;
            NomeUsu = nmUsu;
            SenhaUsu = senha;
        }

        public void AbrirConexaoUsu()
        {
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão: " + ex.Message);
            }
        }

        public void ValidarLogin(string nomeusu, string senhausu)
        {
            AbrirConexaoUsu();
            string sql;
            try
            {  
                sql = "SELECT * FROM USUARIO WHERE NOMEUSU = '" + nomeusu + "'";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (dr["SENHA"].ToString() == senhausu)
                    {
                        dr.Close();
                        SessaoSistema.UsuLoginSessao = nomeusu;
                        Login.loginSucess = true;
                        Menu menu = new Menu();
                        menu.Show();
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta.");
                        
                    }
                    dr.Close();
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.");
                }
                cmd.Dispose();
                conexao.Close();
                conexao.Dispose();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        public void CadastrarUsuario(string nome, string nmusu, string senha, string confSenha)
        {
            string sql;
            int retorno;
            AbrirConexaoUsu();
            try
            {
                sql = "SELECT * FROM USUARIO WHERE NOMEUSU = '" + nmusu + "'";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Nome de Usuário ja utilizado.");
                    Menu.NomeCompUsu = nome;
                    Menu.NmUsuUsu = nmusu;
                    Menu.SenhaUsu = senha;
                    Menu.ConfSenhaUsu = confSenha;
                }
                else
                {
                    if (senha != confSenha)
                    {
                        MessageBox.Show("Senhas não correspondem.");
                        Menu.NomeCompUsu = nome;
                        Menu.NmUsuUsu = nmusu;
                        Menu.SenhaUsu = senha;
                        Menu.ConfSenhaUsu = confSenha;
                    }
                    else
                    {
                        dr.Close();
                        cmd.Dispose();
                        sql = "INSERT INTO USUARIO (NOME, NOMEUSU, SENHA) VALUES ('" + nome + "', '" + nmusu + "', '" + senha + "')";
                        cmd = new SqlCommand(sql, conexao);
                        retorno = cmd.ExecuteNonQuery();
                        if (retorno > 0)
                        {
                            MessageBox.Show("Cadastro efetuado.");
                            Menu menu = new Menu();
                            menu.CamposPadrao();
                            Menu.NomeCompUsu = string.Empty;
                            Menu.NmUsuUsu = string.Empty;
                            Menu.SenhaUsu = string.Empty;
                            Menu.ConfSenhaUsu = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Cadastro não realizado.");
                        }
                    }
                }
                cmd.Dispose();
                conexao.Close();
                conexao.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        public void ConsultarUsuario(int id)
        {
            AbrirConexaoUsu();
            string sql;
            try
            {
                sql = "SELECT * FROM USUARIO WHERE ID = " + id;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Menu.NomeCompUsu = dr["NOME"].ToString();
                    Menu.NmUsuUsu = dr["NOMEUSU"].ToString();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        public void AlterarUsuario(int id, string nome, string nmusu, string senha, string confSenha)
        {
            string sql;
            int retorno;
            AbrirConexaoUsu();
            try
            {
                sql = "SELECT * FROM USUARIO WHERE ID = '" + id + "'";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Menu.NmUsuUsu = dr["NOMEUSU"].ToString();
                    if (Menu.NmUsuUsu != nmusu)
                    {
                        cmd.Dispose();
                        dr.Close();
                        sql = "SELECT * FROM USUARIO WHERE NOMEUSU = '" + nmusu + "'";
                        cmd = new SqlCommand(sql, conexao);
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            MessageBox.Show("Nome de Usuário ja utilizado.");
                            Menu.NomeCompUsu = nome;
                            Menu.NmUsuUsu = nmusu;
                            Menu.SenhaUsu = senha;
                            Menu.ConfSenhaUsu = confSenha;
                        }
                        else
                        {
                            if (senha == "")
                            {
                                MessageBox.Show("Digite a mesma senha ou uma \nnova senha para continuar.");
                                Menu.NomeCompUsu = nome;
                                Menu.NmUsuUsu = nmusu;
                                Menu.SenhaUsu = senha;
                                Menu.ConfSenhaUsu = confSenha;
                            }
                            else if (senha != confSenha)
                            {
                                MessageBox.Show("Senhas não correspondem.");
                                Menu.NomeCompUsu = nome;
                                Menu.NmUsuUsu = nmusu;
                                Menu.SenhaUsu = senha;
                                Menu.ConfSenhaUsu = confSenha;
                            }
                            else
                            {
                                dr.Close();
                                cmd.Dispose();
                                sql = "UPDATE USUARIO SET NOME = '" + nome + "', NOMEUSU = '" + nmusu + "', SENHA = '" + senha + "' WHERE ID =" + id;
                                cmd = new SqlCommand(sql, conexao);
                                retorno = cmd.ExecuteNonQuery();
                                if (retorno > 0)
                                {
                                    MessageBox.Show("Alteração efetuada.");
                                    Menu menu = new Menu();
                                    Menu.NomeCompUsu = string.Empty;
                                    Menu.NmUsuUsu = string.Empty;
                                    Menu.SenhaUsu = string.Empty;
                                    Menu.ConfSenhaUsu = string.Empty;
                                }
                                else
                                {
                                    MessageBox.Show("Alteração não realizada.");
                                    Menu.NomeCompUsu = nome;
                                    Menu.NmUsuUsu = nmusu;
                                    Menu.SenhaUsu = senha;
                                    Menu.ConfSenhaUsu = confSenha;
                                }
                            }
                        }
                    }
                    else if (Menu.NmUsuUsu == "GERENTE")
                    {
                        MessageBox.Show("Não é possível alterar \no usuário GERENTE");
                    }
                    else
                    {
                        if (senha == "")
                        {
                            MessageBox.Show("Digite a mesma senha ou uma \nnova senha para continuar.");
                            Menu.NomeCompUsu = nome;
                            Menu.NmUsuUsu = nmusu;
                            Menu.SenhaUsu = senha;
                            Menu.ConfSenhaUsu = confSenha;
                        }
                        else if (senha != confSenha)
                        {
                            MessageBox.Show("Senhas não correspondem.");
                            Menu.NomeCompUsu = nome;
                            Menu.NmUsuUsu = nmusu;
                            Menu.SenhaUsu = senha;
                            Menu.ConfSenhaUsu = confSenha;
                        }
                        else
                        {
                            dr.Close();
                            cmd.Dispose();
                            sql = "UPDATE USUARIO SET NOME = '" + nome + "', SENHA = '" + senha + "' WHERE ID =" + id;
                            cmd = new SqlCommand(sql, conexao);
                            retorno = cmd.ExecuteNonQuery();
                            if (retorno > 0)
                            {
                                MessageBox.Show("Alteração efetuada.");
                                Menu.NomeCompUsu = string.Empty;
                                Menu.NmUsuUsu = string.Empty;
                                Menu.SenhaUsu = string.Empty;
                                Menu.ConfSenhaUsu = string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("Alteração não realizada.");
                                Menu.NomeCompUsu = nome;
                                Menu.NmUsuUsu = nmusu;
                                Menu.SenhaUsu = senha;
                                Menu.ConfSenhaUsu = confSenha;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuário não encontrado.");
                }
                cmd.Dispose();
                conexao.Close();
                conexao.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        public void RemoverUsuario(int id)
        {
            string sql;
            int retorno;
            AbrirConexaoUsu();
            try
            {
                sql = "SELECT * FROM USUARIO WHERE ID = '" + id + "'";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Menu.NmUsuUsu = dr["NOMEUSU"].ToString();
                    if (Menu.NmUsuUsu != "GERENTE")
                    {
                        cmd.Dispose();
                        dr.Close();
                        sql = "DELETE USUARIO WHERE ID = " + id;
                        cmd = new SqlCommand(sql, conexao);
                        retorno = cmd.ExecuteNonQuery();
                        if (retorno > 0)
                        {
                            MessageBox.Show("Usuário excluído.");
                            Menu menu = new Menu();
                            Menu.NomeCompUsu = string.Empty;
                            Menu.NmUsuUsu = string.Empty;
                            Menu.SenhaUsu = string.Empty;
                            Menu.ConfSenhaUsu = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Usuário não foi excluído.");
                        }
                        cmd.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Não é possível excluir \no usuário GERENTE.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }
    }
}
