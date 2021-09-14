﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjTesteForm
{
    class Lote : Usuarios
    {
        SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Acer\OneDrive\Documentos\Projetos\ProjInter\ProjTesteFormV3\ControleDeEstoque.mdf;Integrated Security=True");
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
                sql = "INSERT INTO LOTE (KGBOTIJENV, QTDEENV, DATARECEB, USURESP) VALUES (" + kgBotij + ", " + qtdeEnv + ", '" + dataAtual + "', '" + nmUsu + "')";
                cmd = new SqlCommand(sql, conexao);
                retorno = cmd.ExecuteNonQuery();
                if (retorno > 0)
                {
                    MessageBox.Show("Cadastro efetuado");
                    Menu.KgBotijLote = "";
                    Menu.QtdeEnvLote = "";
                    Menu.DataLote = "  /  /";
                }
                else
                {
                    MessageBox.Show("Cadastro não realizado");
                    Menu.KgBotijLote = kgBotij.ToString();
                    Menu.QtdeEnvLote = qtdeEnv.ToString();
                    Menu.DataLote = dataAtual;
                }
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql: " + ex.Message);
            }

        }

    }
}