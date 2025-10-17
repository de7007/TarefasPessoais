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
    public partial class Login : Form
    {
        DAOUsuario dao;
        public Login()
        {
            dao = new DAOUsuario();
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//email

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//senha

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox2.Text;
            string senha = textBox3.Text;
            Boolean resultado = dao.VerificarLogin(email, senha);
            if ( resultado == true)
            {
                MenuUsuario menuUsuario = new MenuUsuario();
                menuUsuario.Show();
            }
            else
            {
                MessageBox.Show("Usuário e/ou senha estão incorretos");
            }

            
        }//entrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fechar

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }//fim do metodo
}//fim do projeto
