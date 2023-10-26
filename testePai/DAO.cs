using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace testePai
{
    class DAO
    {
        public MySqlConnection conexao;//Conexao com o banco de dados
        public string[] nome;//Vetor que guarda o nome
        public int[] CPF;//Vetor que guarda o tipo
        public double[] valor;//Vetor que guarda a descrição
        public int[] dataE;//Vetor que guarda o orçamento
        public int i;//Variavel do Vetor
        public int contador;//Contador do i

        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;database=testePai;Uid=root;password=");
            try
            {
                conexao.Open();//Abrir a conexão com o banco de dados
            }
            catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado!\n\n" + erro.Message);
            }//Fim do construtor
        }//Fim da DAO

        //Métodos de inserção
        public string Inserir(string nome,int CPF,double valor,int dataE, string nomeTabela)
        {
            string inserir = $"Insert into {nomeTabela}(nome, CPF, valor, dataE) values('{nome}','{CPF}','{valor}','{dataE}')";
            MySqlCommand sql = new MySqlCommand(inserir, conexao);
            string resultado = sql.ExecuteNonQuery() + " Executado";
            return resultado;
        }//Fim da inserir

        //Método de Busca
        public void PreencherVetor(string nome, string nomeTabela)
        {
            string query = $"Select * from {nomeTabela} where nome = '{nome}'";

            //Instanciar
            this.nome = new string[100];
            this.CPF = new int[100];
            this.valor = new double[100];
            this.dataE = new int[100];

            //Preparar o comando
            MySqlCommand sql = new MySqlCommand(query, conexao);

            //Leitor
            MySqlDataReader leitura = sql.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                CPF[i] = Convert.ToInt32(leitura["CPF"]);//Mostra o dado que deseja pegar
                valor[i] = Convert.ToDouble(leitura["valor"]);//Mostra o dado que deseja pegar
                dataE[i] = Convert.ToInt32(leitura["dataE"]);//Mostra o dado que deseja pegar
                i++;
                contador++;
            }//Fim do while

            //Encerrando a comunicaxão
            leitura.Close();
        }//Fim do método
        public int QuatidadeDados()
        {
            return contador;
        }//Fim do método Quantidade de Dados
    }//Fim da Classe
}//Fim do Projeto
