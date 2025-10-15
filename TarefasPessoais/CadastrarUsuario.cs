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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace TarefasPessoais
{
    public partial class CadastrarUsuario : Form
    {
        DAOUsuario dao;
        public CadastrarUsuario()
        {
            InitializeComponent();
            dao = new DAOUsuario();
        }

        private void CadastrarUsuario_Load(object sender, EventArgs e)
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
            try
            {  
                string nome = textBox1.Text;
                string email = textBox2.Text;
                string senha = textBox3.Text;
                dao.Inserir(nome, email, senha);
                //informando que foi cadastrado
                MessageBox.Show($"Cadastrado com sucesso!! :) \nNome: {nome} " +
                                                            $"\nemail: {email}" +
                                                            $"\nsenha: {senha}");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Algo deu errado :( \n\n{ex}");
            }
        }//cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar
    }//fim do metodo
}//fim do projeto
