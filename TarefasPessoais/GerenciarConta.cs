using Google.Protobuf.WellKnownTypes;
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
    public partial class GerenciarConta : Form
    {
        DAOUsuario dao;
        public GerenciarConta()
        {
            dao = new DAOUsuario();
            InitializeComponent();
            //textBox1.Text = dao.ConsultarNome(codigo);
            //textBox2.Text = dao.ConsultarEmail(codigo);
            //textBox3.Text = dao.ConsultarSenha(codigo);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//nome

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//email

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//senha

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string email = textBox2.Text;
            string senha = textBox3.Text;
            //atualizar
            int codigo = Convert.ToInt32(textBox1.Text);
            dao.Atualizar(codigo, "nome", nome);
            dao.Atualizar(codigo, "email", email);
            dao.Atualizar(codigo, "senha", senha);
            //mensagem
            MessageBox.Show("Atualizado com sucesso!");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }//atualizar

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text;
            MessageBox.Show(dao.Deletar(email));
        }//excluir

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar
    }//fim da classe
}//fim do projeto
