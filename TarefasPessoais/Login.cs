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
        public Login()
        {
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
            try
            { 
            
                string email = textBox2.Text;
                string senha = textBox3.Text;
                DAOUsuario daoUsuario= new DAOUsuario();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Usuario errado:( \n\n{ex}");
            }

            MenuUsuario menuUsuario = new MenuUsuario();
            menuUsuario.Show();
        }//entrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fechar
    }//fim do metodo
}//fim do projeto
