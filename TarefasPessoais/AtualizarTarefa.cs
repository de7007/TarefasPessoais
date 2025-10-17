using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TarefasPessoais
{
    public partial class AtualizarTarefa : Form
    {
        DAOTarefa dao;
        public AtualizarTarefa()
        {
            dao = new DAOTarefa();
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }//codigo tarefa

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//descricao

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//prioridade

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }//prazo

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//lembrete

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//codigo usuario

        private void button1_Click(object sender, EventArgs e)
        {
            string descricao = textBox2.Text;
            string prioridade = listBox1.Text;
            DateTime prazo = Convert.ToDateTime(dateTimePicker1.Value);
            string lembrete = textBox1.Text;
            int usuarioCodigo = Convert.ToInt32(textBox4.Text);
            //atualizar
            int codigo = Convert.ToInt32(textBox5.Text);
            dao.Atualizar(codigo, "descricao", descricao);
            dao.Atualizar(codigo, "prioridade", prioridade);
            dao.Atualizar(codigo, "prazo", prazo);
            dao.Atualizar(codigo, "lembrete", lembrete);
            dao.Atualizar(codigo, "usuarioCodigo", usuarioCodigo);
            //mensagem
            MessageBox.Show("Atualizar com sucesso!");
            textBox2.Text = "";
            listBox1.Text = "";
            textBox1.Text = "";
            textBox4.Text = "";
        }//atualizar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar

        private void button3_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox5.Text);
            textBox2.Text = dao.ConsultarDescricao(codigo);
            listBox1.Text = dao.ConsultarPrioridade(codigo);
            //dateTimePicker1.Value = DateTimePickerFormat(dao.ConsultarPrazo(codigo));
            textBox1.Text = dao.ConsultarLembrete(codigo);
            textBox4.Text = dao.ConsultarUsuarioCodigo(codigo);
        }//buscar

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }//prioridade
    }//fim da classe
}//fim do projeto
