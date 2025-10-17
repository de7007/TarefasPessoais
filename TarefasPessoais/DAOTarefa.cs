using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    internal class DAOTarefa
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] descricao;
        public string[] prioridade;
        public string[] lembrete;
        public DateTime[] prazo;
        public int[] usuarioCodigo;
        public int i;
        public int contador;
        public string msg;
        public DAOTarefa()
        {
            //Conectar com o banco
            conexao = new MySqlConnection("server=localhost;DataBase=tarefasPessoais;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                conexao.Open();//Tenta abrir a conexao com o Banco de Dados

            }
            catch (Exception erro)
            {
                conexao.Close();//Fechar a conexao
                MessageBox.Show($"Algo deu erado \n\n {erro}");
            }//fim do try_catch
        }//fim do construtor

        public void Inserir(string descricao, string prioridade, DateTime prazo, string lembrete, int usuarioCodigo)
        {
            try
            {
                //Modificar
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = $"{prazo.Year}-{prazo.Month}-{prazo.Day}";

                dados = $"('','{descricao}', '{prioridade}', '{parameter.Value}', '{lembrete}', '{usuarioCodigo}')";
                comando = $"Insert into tarefa(codigo, descricao, prioridade, prazo,lembrete, usuarioCodigo) values{dados}";
                //Lançar os dados no banco
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                string resultado = "" + sql.ExecuteNonQuery();// Comando de inserção/Ações

            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado \n\n {erro}");
            }//fim do catch
        }//fim do inserir

        //Método para preencher o vetor
        public void PreencherVetor()
        {
            string query = "select * from tarefa";//Comando SQL para acesso aos dados
                                                   //Instanciar os vetores
            codigo = new int[150];
            descricao = new string[150];
            prioridade = new string[150];
            prazo = new DateTime[150];
            lembrete = new string[150];
            usuarioCodigo = new int[150];

            //Reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                descricao[i] = "";
                prioridade[i] = "";
                prazo[i] = new DateTime();
                lembrete[i] = "";
                usuarioCodigo[i] = 0;
            }//fim do for


            //Executar o comando no BD
            MySqlCommand coletar = new MySqlCommand(query, conexao);
            //Leitura dos dados do Banco - Por linha
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contador = 0;
            //Buscar os dados do banco e preencher o vetor
            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                descricao[i] = leitura["descricao"] + "";
                prioridade[i] = leitura["prioridade"] + "";
                prazo[i] = Convert.ToDateTime(leitura["prazo"]);
                lembrete[i] = leitura["lembrete"] + "";
                usuarioCodigo[i] = Convert.ToInt32(leitura["usuarioCodigo"]);
                i++;//Ande pelo vetor
                contador++;//Contar exatamente quantos dados foram inseridos
            }//fim do while

            //Fechar a leitura dos dados com o banco de dados
            leitura.Close();
        }//fim do preencher

        public int QuantidadeDeDados()
        {
            return contador;
        }//fim do método

        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";//Instanciando a variável
            for (i = 0; i < contador; i++)
            {
                msg += $"\n\nCódigo: {codigo[i]} \nDescrição: {descricao[i]}\n Prioridade: {prioridade[i]}\n Prazo: {prazo[i]}\n Lembrete: {lembrete[i]}\n Codigo do usuario: {usuarioCodigo[i]}";
            }//fim do for
             //Mostrar todos os dados do BD
            return msg;
        }//fim do método
        public string ConsultarPorCodigo(int codigo)
        {
            PreencherVetor();
            msg = "";
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    msg = $"\nCódigo: {this.codigo[i]} \nDescrição: {descricao[i]}\n Prioridade: {prioridade[i]}\n Prazo: {prazo[i]}\n Lembrete: {lembrete[i]}\n Codigo do usuario: {usuarioCodigo[i]}";
                    return msg;
                }//fim do if
            }//fim do método
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do método

        public string ConsultarDescricao(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return descricao[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não existe";
        }//fim do método

        public string ConsultarPrioridade(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return prioridade[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não existe";
        }//fim do método

        public DateTime ConsultarPrazo(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return prazo[i] ;
                }//fim do if 
            }//fim do for
            return new DateTime();
        }//fim do método

        public string ConsultarLembrete(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return lembrete[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não existe";
        }//fim do método

        public string ConsultarUsuarioCodigo(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return usuarioCodigo[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não existe";
        }//fim do método


        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
               
                string query = $"update tarefa set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //Executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//fim do método

        public string Atualizar(int codigo, string campo, DateTime novoDado)
        {
            try
            {
                //Modificar
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@Date";
                parameter.MySqlDbType = MySqlDbType.Date;
                parameter.Value = $"{novoDado.Year}-{novoDado.Month}-{novoDado.Day}";
                string query = $"update tarefa set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //Executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//fim do método

        public string Atualizar(int codigo, string campo, int novoDado)
        {
            try
            {
                string query = $"update tarefa set {campo} = '{novoDado}' where codigo = '{codigo}'";
                //Executar o comando
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado atualizado com sucesso!";
            }
            catch (Exception erro)
            {
                return $"\nAlgo deu errado!\n\n {erro}";
            }
        }//fim do método

        public string Deletar(int codigo)
        {
            try
            {
                string query = $"delete from tarefa where codigo = '{codigo}'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return resultado + " dado excluído!";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }
        }//fim do método


    }//FIM DO METODO    
}//FIM DO PROJETO
