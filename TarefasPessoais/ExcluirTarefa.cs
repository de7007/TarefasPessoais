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
    public partial class ExcluirTarefa : Form
    {
        DAOTarefa dao;
        public ExcluirTarefa()
        {
            dao = new DAOTarefa();
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }//codigo

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox5.Text);
            MessageBox.Show(dao.Deletar(codigo));
            textBox5.Text = "";
        }//exlcuir

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar
    }//fim da classe
}//fim do projeto
