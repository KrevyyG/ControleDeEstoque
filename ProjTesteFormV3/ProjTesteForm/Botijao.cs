using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjTesteForm
{
    class Botijao : Usuarios
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ProjTesteFormV3\ControleDeEstoque.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;

        public int IdBotij { get; }
        public int KgBotij { get; private set; }
        public int QtdeCheia { get; private set; }
        public int QtdeVazia { get; private set; }
        public int QtdeSemBotij { get; private set; }
        public int IdLote { get; private set; }
        public string NmUsu { get; private set; }

        public Botijao()
        {

        }

        public Botijao(int id)
        {
            IdBotij = id;
        }

        public Botijao(int idBotij, int kgbotij)
        {
            IdBotij = idBotij;
            KgBotij = kgbotij;
        }

        public Botijao(int idBotij, int qtdeBotij, int idLote, string nmusu)
        {
            IdBotij = idBotij;
            QtdeCheia = qtdeBotij;
            IdLote = idLote;
            NmUsu = nmusu;
        }

        public Botijao(int idBotij, int qtdeBotij, int qtdeVazia, int qtdeSemBotij, int idLote, string nmusu)
        {
            IdBotij = idBotij;
            QtdeCheia = qtdeBotij;
            QtdeVazia = qtdeVazia;
            QtdeSemBotij = qtdeSemBotij;
            IdLote = idLote;
            NmUsu = nmusu;
        }

        public void AbrirConexaoBotijao()
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

        public void AdicionarBotijao(int kgBotij)
        {
            AbrirConexaoBotijao();
            string sql;
            try
            {
                sql = "SELECT * FROM BOTIJAO WHERE KGBOTIJ = " + kgBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Botijão de "+ kgBotij +"Kg já cadastrado!");
                    Menu.KgBotij = string.Empty;
                }
                else
                {
                    int retorno;
                    try
                    {
                        dr.Close();
                        cmd.Dispose();
                        sql = "INSERT INTO BOTIJAO (KGBOTIJ) VALUES ("+ kgBotij +")";
                        cmd = new SqlCommand(sql, conexao);
                        retorno = cmd.ExecuteNonQuery();
                        if (retorno > 0)
                        {
                            MessageBox.Show("Cadastro efetuado!");
                            Menu.KgBotij = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Cadastro não realizado!");
                            Menu.KgBotij = kgBotij.ToString();
                        }
                        cmd.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro no comando sql: " + ex.Message);
                    }
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

        public void ConsultarBotijao(int idBotij)
        {
            AbrirConexaoBotijao();
            string sql;
            try
            {
                sql = "SELECT * FROM BOTIJAO WHERE ID = " + idBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Menu.KgBotij = dr["KGBOTIJ"].ToString();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado!");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

        public void AlterarBotijao(int idBotij, int kgBotij)
        {
            AbrirConexaoBotijao();
            string sql;
            try
            {
                sql = "SELECT * FROM BOTIJAO WHERE KGBOTIJ = " + kgBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    MessageBox.Show("Botijão de " + kgBotij + "Kg já cadastrado!");
                    Menu.KgBotij = string.Empty;
                }
                else
                {
                    int retorno;
                    try
                    {
                        dr.Close();
                        cmd.Dispose();
                        sql = "UPDATE BOTIJAO SET KGBOTIJ = "+ kgBotij + "WHERE ID = "+ idBotij;
                        cmd = new SqlCommand(sql, conexao);
                        retorno = cmd.ExecuteNonQuery();
                        if (retorno > 0)
                        {
                            MessageBox.Show("Alteração efetuada!");
                            Menu.KgBotij = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Alteração não realizada!");
                            Menu.KgBotij = kgBotij.ToString();
                        }
                        cmd.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro no comando sql: " + ex.Message);
                    }
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

        public void RemoverBotijao(int idBotij)
        {
            string sql;
            int retorno;
            AbrirConexaoBotijao();
            try
            {
                sql = "DELETE BOTIJAO WHERE ID = " + idBotij;
                cmd = new SqlCommand(sql, conexao);
                retorno = cmd.ExecuteNonQuery();
                if (retorno > 0)
                {
                    MessageBox.Show("Registro excluído");
                }
                else
                {
                    MessageBox.Show("Registro não excluído");
                }
                Menu.KgBotij = string.Empty;
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERRO:" + ex.Message);
            }
        }
    }
}
