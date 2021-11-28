using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjTesteForm
{
    class Botijao : Usuarios
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ControleDeEstoque\ControleDeEstoque.mdf;Integrated Security=True");
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
                    MessageBox.Show("Botijão de "+ kgBotij +"Kg já cadastrado.");
                    Menu.KgBotij = string.Empty;
                }
                else
                {
                    int retorno;
                    try
                    {
                        dr.Close();
                        cmd.Dispose();
                        sql = "INSERT INTO BOTIJAO (KGBOTIJ, QTDECHEIA, QTDEVAZIA, QTDESEMBOTIJ) VALUES (" + kgBotij +", 0, 0, 0)";
                        cmd = new SqlCommand(sql, conexao);
                        retorno = cmd.ExecuteNonQuery();
                        if (retorno > 0)
                        {
                            MessageBox.Show("Cadastro efetuado.");
                            Menu.KgBotij = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Cadastro não realizado.");
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
                    MessageBox.Show("Botijão não encontrado.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        public void ConsultarIDBotijao(int kgBotij)
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
                    dr.Read();
                    Menu.IdBotij = dr["ID"].ToString();
                }
                else
                {
                    MessageBox.Show("Botijão não encontrado.");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
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
                    MessageBox.Show("Botijão de " + kgBotij + "Kg já cadastrado.");
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
                            MessageBox.Show("Alteração efetuada.");
                            Menu.KgBotij = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Alteração não realizada.");
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
                MessageBox.Show("Erro no comando sql: " + ex.Message);
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
                    MessageBox.Show("Botijão excluído.");
                }
                else
                {
                    MessageBox.Show("Botijão não foi excluído.");
                }
                Menu.KgBotij = string.Empty;
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }
        }

        public void ConsultarEstoque(int idBotij)
        {
            string sql;
            try
            {
                AbrirConexaoBotijao();
                sql = "SELECT * FROM BOTIJAO WHERE ID = " + idBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Menu.IdBotijEstoque = dr["ID"].ToString();
                    Menu.KgBotijEstoque = dr["KGBOTIJ"].ToString();
                    Menu.QtdeCheiaEstoque = dr["QTDECHEIA"].ToString();
                    Menu.QtdeVaziaEstoque = dr["QTDEVAZIA"].ToString();
                    Menu.QtdeSemBotijEstoque = dr["QTDESEMBOTIJ"].ToString();
                    Menu.IdUltLoteEstoque = dr["ULTIMOLOTE"].ToString();
                    Menu.UsuRespEstoque = dr["USURESP"].ToString();
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

        public void AdicionarEstoque(int idLote, bool abatSemBotij, string nmUsu)
        {
            AbrirConexaoBotijao();
            string sql;
            int retorno;
            try
            {
                sql = "SELECT * FROM LOTE WHERE ID = " + idLote;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string kgBotij = dr["KGBOTIJENV"].ToString();
                    string qtdeBotij = dr["QTDEENV"].ToString();
                    
                    dr.Close();
                    cmd.Dispose();
                    sql = "SELECT * FROM BOTIJAO WHERE KGBOTIJ = " + kgBotij;
                    cmd = new SqlCommand(sql, conexao);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        string qtdeCheia = dr["QTDECHEIA"].ToString();
                        string qtdeVazia = dr["QTDEVAZIA"].ToString();
                        string qtdeSemBotij = dr["QTDESEMBOTIJ"].ToString();                        

                        dr.Close();
                        cmd.Dispose();
                        if (abatSemBotij == false)
                        {
                            int nvQtdeCheia = int.Parse(qtdeCheia) + int.Parse(qtdeBotij);
                            int nvQtdeVazia = int.Parse(qtdeVazia) - int.Parse(qtdeBotij);
                            if (nvQtdeVazia < 0)
                            {
                                nvQtdeVazia = 0;
                            }
                            sql = "UPDATE BOTIJAO SET QTDECHEIA = " + nvQtdeCheia + ", QTDEVAZIA =" + nvQtdeVazia + ", ULTIMOLOTE =" + idLote + ", USURESP ='" + nmUsu + "' WHERE KGBOTIJ = " + kgBotij;
                            cmd = new SqlCommand(sql, conexao);
                            retorno = cmd.ExecuteNonQuery();
                            if (retorno > 0)
                            {
                                MessageBox.Show("Estoque Adicionado.");
                            }
                            else
                            {
                                MessageBox.Show("Estoque não adicionado.");
                            }
                            Menu.KgBotijaoLote = "";
                            Menu.QtdeBotijLote = "";
                            Menu.IdBotij = "";
                            cmd.Dispose();
                            dr.Close();
                        }
                        else
                        {
                            int nvQtdeCheia = int.Parse(qtdeCheia) + int.Parse(qtdeBotij);
                            int nvQtdeSemBotij = int.Parse(qtdeSemBotij) - int.Parse(qtdeBotij);
                            int nvQtdeVazia = int.Parse(qtdeVazia);
                            if (nvQtdeSemBotij < 0)
                            {
                                nvQtdeVazia = nvQtdeVazia - (-1 * (nvQtdeSemBotij));
                                nvQtdeSemBotij = 0;
                                if (nvQtdeVazia < 0)
                                {
                                    nvQtdeVazia = 0;
                                }
                            }
                            sql = "UPDATE BOTIJAO SET QTDECHEIA = " + nvQtdeCheia + ", QTDEVAZIA =" + nvQtdeVazia + ", QTDESEMBOTIJ =" + nvQtdeSemBotij +", ULTIMOLOTE =" + idLote + ", USURESP ='" + nmUsu + "' WHERE KGBOTIJ = " + kgBotij;
                            cmd = new SqlCommand(sql, conexao);
                            retorno = cmd.ExecuteNonQuery();
                            if (retorno > 0)
                            {
                                MessageBox.Show("Estoque Adicionado.");
                            }
                            else
                            {
                                MessageBox.Show("Estoque não adicionado.");
                            }
                            Menu.KgBotijaoLote = "";
                            Menu.QtdeBotijLote = "";
                            Menu.IdBotij = "";
                            cmd.Dispose();
                            dr.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Botijão não ecnontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Lote não ecnontrado.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

        public void RemoverEstoque(int idBotij, int qtde, bool retBotij)
        {
            AbrirConexaoBotijao();
            string sql;
            int retorno;
            try
            {
                sql = "SELECT * FROM BOTIJAO WHERE ID = " + idBotij;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    string qtdeCheia = dr["QTDECHEIA"].ToString();
                    string qtdeVazia = dr["QTDEVAZIA"].ToString();
                    string qtdeSemBotij = dr["QTDESEMBOTIJ"].ToString();

                    cmd.Dispose();
                    if (retBotij == true)
                    {
                        int nvQtdeCheia = int.Parse(qtdeCheia) - qtde;
                        int nvQtdeVazia = int.Parse(qtdeVazia) + qtde;
                        if (nvQtdeCheia <= 0)
                        {
                            MessageBox.Show("Não há essa \nquantidade em estoque.");
                        }
                        else
                        {
                            dr.Close();
                            sql = "UPDATE BOTIJAO SET QTDECHEIA = " + nvQtdeCheia + ", QTDEVAZIA =" + nvQtdeVazia + "WHERE ID = " + idBotij;
                            cmd = new SqlCommand(sql, conexao);
                            retorno = cmd.ExecuteNonQuery();
                            if (retorno > 0)
                            {
                                MessageBox.Show("Quantidade removida.");
                            }
                            else
                            {
                                MessageBox.Show("Quantidade não removida.");
                            }
                            Menu.KgBotijaoLote = "";
                            Menu.QtdeBotijLote = "";
                            cmd.Dispose();
                            dr.Close();
                        }
                    }
                    else
                    {
                        int nvQtdeCheia = int.Parse(qtdeCheia) - qtde;
                        int nvQtdeSemBotij = int.Parse(qtdeSemBotij) + qtde;
                        if (nvQtdeCheia <= 0)
                        {
                            MessageBox.Show("Não há essa \nquantidade em estoque.");
                        }
                        else
                        {
                            dr.Close();
                            sql = "UPDATE BOTIJAO SET QTDECHEIA = " + nvQtdeCheia + ", QTDESEMBOTIJ =" + nvQtdeSemBotij + "WHERE ID = " + idBotij;
                            cmd = new SqlCommand(sql, conexao);
                            retorno = cmd.ExecuteNonQuery();
                            if (retorno > 0)
                            {
                                MessageBox.Show("Quantidade removida.");
                            }
                            else
                            {
                                MessageBox.Show("Quantidade não removida.");
                            }
                            Menu.KgBotijaoLote = "";
                            Menu.QtdeBotijLote = "";
                            cmd.Dispose();
                            dr.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Botijão não ecnontrado.");
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }
        }

    }
}
