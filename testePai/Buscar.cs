using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testePai
{
    public partial class Buscar : Form
    {
        DAO consul;
        public Buscar()
        {
            consul = new DAO();
            InitializeComponent();
            ConfigurarDataGrid();//Configura o DataGrid
            NomeColunas();//Nomear os títulos das colunas  
        }

        private void Buscar_Load(object sender, EventArgs e)
        {

        }

        public void NomeColunas()
        {
            dataGridView1.Columns[0].Name = "CPF";//Adiciona um nome a coluna 1
            dataGridView1.Columns[1].Name = "valor";//Adiciona um nome a coluna 2
            dataGridView1.Columns[2].Name = "dataE";//Adiciona um nome a coluna 3

        }//Fim do método consultar

        public void ConfigurarDataGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Adicionar Linhas
            dataGridView1.AllowUserToDeleteRows = false;//Deletar Linhas
            dataGridView1.AllowUserToResizeColumns = false;//Redimensionar Colunas
            dataGridView1.AllowUserToResizeRows = false;//Redimensionar Linhas

            dataGridView1.ColumnCount = 3;//Número de Colunas
        }
        public void AdicionarDados()
        {
            consul.PreencherVetor(nome.Text, "cadastro");
            for (int i = 0; i < consul.QuatidadeDados(); i++)
            {
                dataGridView1.Rows.Add(consul.CPF[i], consul.valor[i], consul.dataE[i]);
            }//Adicionando dados no dataGridView1
        }//Fim do método

        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdicionarDados();
        }
    }//Fim da Classe
}//Fim do Projeto
