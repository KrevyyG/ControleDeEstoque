using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjTesteForm
{
    class Lote : Usuarios
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ProjTesteFormV4 - Testes\ControleDeEstoque.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public int IdLote { get; private set; }
        public int KgBotij { get; private set; }
        public int QtdeEnv { get; private set; }
        public string DataAtual { get; private set; }

        public Lote()
        {

        }

        public Lote(int idLote)
        {
            IdLote = idLote;
        }

        public Lote(int kgBotij, int qtdeEnv, string nmUsu, string dataAtual)
        {
            KgBotij = kgBotij;
            QtdeEnv = qtdeEnv;
            DataAtual = dataAtual;
            NomeUsu = nmUsu;
        }

        public Lote(int idLote, int kgBotij, int qtdeEnv, string dataAtual, string nmUsu)
        {
            IdLote = idLote;
            KgBotij = kgBotij;
            QtdeEnv = qtdeEnv;
            DataAtual = dataAtual;
            NomeUsu = nmUsu;
        }

        public void AbrirConexaoLote()
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

        public void AdicionarLote(int kgBotij, int qtdeEnv, string dataAtual, string nmUsu)
        {
            string sql;
            int retorno;
            AbrirConexaoLote();

            try
            {
                sql = "SELECT * FROM BOTIJAO WHERE KGBOTIJ = " + kgBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    cmd.Dispose();
                    sql = "INSERT INTO LOTE (KGBOTIJENV, QTDEENV, DATARECEB, USURESP) VALUES (" + kgBotij + ", " + qtdeEnv + ", '" + dataAtual + "', '" + nmUsu + "')";
                    cmd = new SqlCommand(sql, conexao);
                    retorno = cmd.ExecuteNonQuery();
                    if (retorno > 0)
                    {
                        MessageBox.Show("Cadastro efetuado.");
                        Menu.KgBotijLote = string.Empty;
                        Menu.QtdeEnvLote = string.Empty;
                        Menu.DataLote = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Cadastro não realizado.");
                        Menu.KgBotijLote = kgBotij.ToString();
                        Menu.QtdeEnvLote = qtdeEnv.ToString();
                        Menu.DataLote = dataAtual;
                    }
                }
                else
                {
                    MessageBox.Show("Permitido apenas o cadastro de lote \npara botijões previamente cadastrados.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }

        }

        public void ConsultarLote(int idLote)
        {
            string sql;
            try
            {
                AbrirConexaoLote();
                sql = "SELECT * FROM LOTE WHERE ID = " + idLote;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Menu.KgBotijaoLote = dr["KGBOTIJENV"].ToString();
                    Menu.QtdeBotijLote = dr["QTDEENV"].ToString();
                    Menu.DataBotijLote = dr["DATARECEB"].ToString();
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

        public void AlterarLote(int idLote, int kgBotij, int qtdeEnv, string dataAtual, string nmUsu)
        {
            string sql;
            int retorno;
            AbrirConexaoLote();
            try
            {
                sql = "SELECT * FROM BOTIJAO WHERE KGBOTIJ = " + kgBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Close();
                    cmd.Dispose();
                    sql = "UPDATE LOTE SET KGBOTIJENV = "+ kgBotij + ", QTDEENV = " + qtdeEnv + ", DATARECEB = '"+ dataAtual + "', USURESP = '" + nmUsu + "' WHERE ID = " + idLote;
                    cmd = new SqlCommand(sql, conexao);
                    retorno = cmd.ExecuteNonQuery();
                    if (retorno > 0)
                    {
                        MessageBox.Show("Alteração efetuada.");
                        Menu.KgBotijLote = string.Empty;
                        Menu.QtdeEnvLote = string.Empty;
                        Menu.DataLote = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Alteração não efetuada.");
                        Menu.KgBotijLote = kgBotij.ToString();
                        Menu.QtdeEnvLote = qtdeEnv.ToString();
                        Menu.DataLote = dataAtual;
                    }
                }
                else
                {
                    MessageBox.Show("Permitido apenas o cadastro de lote \npara botijões previamente cadastrados.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }
    }
}
