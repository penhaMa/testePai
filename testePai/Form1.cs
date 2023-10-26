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
    public partial class Form1 : Form
    {
        Buscar busca;
        DAO conectar;
        public Form1()
        {
            InitializeComponent();
            conectar = new DAO();
            busca = new Buscar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Adiciona Dados
                string result = conectar.Inserir(nome.Text, Convert.ToInt32(textBox1.Text),Convert.ToDouble(valor.Text),Convert.ToInt32(data.Text), "cadastro"); ;
                MessageBox.Show(result);
            }
            catch (Exception erro)
            {
                //Mostra se der Erro
                MessageBox.Show("Algo deu errado!\n\n" + erro.Message);
            }//Fim do try catch

        }//Cadastrar

        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void valor_TextChanged(object sender, EventArgs e)
        {

        }

        private void data_TextChanged(object sender, EventArgs e)
        {

        }

        private void buscar_Click(object sender, EventArgs e)
        {
            busca.ShowDialog();
        }
    }//Fim da classe
}//Fim do Projeto
