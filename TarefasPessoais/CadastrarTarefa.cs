using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    public partial class CadastrarTarefa : Form
    {
        DAOTarefa dao;
        public CadastrarTarefa()
        {
            dao = new DAOTarefa();
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }//descrição

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//prioridade

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }//prazo

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//lembrete

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //coletar os dados
                string descricao = textBox2.Text;
                string prioridade = listBox1.Text;
                DateTime prazo = Convert.ToDateTime(dateTimePicker1.Value);
                string lembrete = textBox1.Text;
                int usuarioCodigo = Convert.ToInt32(textBox4.Text);   

                dao.Inserir(descricao, prioridade, prazo, lembrete, usuarioCodigo);
                //Confirmar que foi inserido
                MessageBox.Show($"Cadastrado Com Sucesso!! :) \nDescrição: {descricao} " +
                                                            $"\nPrioridade: {prioridade} " +
                                                            $"\nPrazo: {prazo}" +
                                                            $"\nLembrete: {lembrete}" +
                                                            $"\nCodigo do usuário: {usuarioCodigo}");
                textBox1.Text = "";
                textBox2.Text = "";
                listBox1.Text = "";
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu errado!! :( \n\n{ex}");
            }
        }//cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//usuario

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }//prioridade
    }//fim da classe
}//fim do projeto
