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
    public partial class ConsultarTarefa : Form
    {
        DAOTarefa dao;
        public ConsultarTarefa()
        {
            dao = new DAOTarefa();
            InitializeComponent();
            ConfigurarGrid();
            NomeDados();
            dao.PreencherVetor();
            AdicionarDados();
        }

        public void AdicionarDados()
        {
            for (int i = 0; i < dao.QuantidadeDeDados(); i++)
            {
                dataGridView1.Rows.Add(dao.codigo[i], dao.descricao[i], dao.prioridade[i], dao.prazo[i], dao.lembrete[i], dao.usuarioCodigo[i]);
            }
        }//fim do método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//adicionar linhas
            dataGridView1.AllowUserToDeleteRows = false;//apagar linhas
            dataGridView1.AllowUserToResizeColumns = false;//Modificar colunas
            dataGridView1.AllowUserToResizeRows = false;//Modificar linhas
            dataGridView1.ColumnCount = 6;
        }//fim do ConfigurarGrid

        public void NomeDados()
        {
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Descrição";
            dataGridView1.Columns[2].Name = "Prioridade";
            dataGridView1.Columns[3].Name = "Prazo";
            dataGridView1.Columns[4].Name = "Lembrete";
            dataGridView1.Columns[5].Name = "Código de Usuário";
        }//fim do método

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//dataGrid

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }//voltar
    }//fim da classe
}//fim do metodo
