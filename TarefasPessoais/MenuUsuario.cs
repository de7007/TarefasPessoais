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
    public partial class MenuUsuario : Form
    {
        public MenuUsuario()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarTarefa consultarTarefa = new ConsultarTarefa();
            consultarTarefa.ShowDialog();
        }//consultar

        private void button1_Click(object sender, EventArgs e)
        {
            //GerenciarConta gerenciarConta = new GerenciarConta
            //gerenciarConta.ShowDialog();
        }//gerenciar conta

        private void button2_Click(object sender, EventArgs e)
        {
            CadastrarTarefa cadastrarTarefa = new CadastrarTarefa();
            cadastrarTarefa.ShowDialog();
        }//cadastrar tarefa

        private void button4_Click(object sender, EventArgs e)
        {
            AtualizarTarefa atualizarTarefa = new AtualizarTarefa();
            atualizarTarefa.ShowDialog();
        }//atualizar tarefa

        private void button5_Click(object sender, EventArgs e)
        {
            ExcluirTarefa excluirTarefa = new ExcluirTarefa();
            excluirTarefa.ShowDialog();
        }//excluir tarefa
    }//fim do método
}//fim do projeto
