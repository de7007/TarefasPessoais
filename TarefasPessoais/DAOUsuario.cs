using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarefasPessoais
{
    internal class DAOUsuario
    {
        public MySqlConnection conexao;//Criando uma chave para a classe MYSQLCONNECTION
        public string dados;
        public string comando;
        public int[] codigo;
        public string[] nome;
        public string[] email;
        public string[] senha;
        public int i;
        public int contador;
        public string msg;
        public DAOUsuario()
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

        public void Inserir(string nome, string email, string senha)
        {
            try
            {
                dados = $"('','{nome}', '{email}', '{senha}')";
                comando = $"Insert into usuario(codigo, nome, email, senha) values{dados}";
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
            string query = "select * from usuario";//Comando SQL para acesso aos dados
                                                 //Instanciar os vetores
            codigo = new int[150];
            nome = new string[150];
            email = new string[150];
            senha = new string[150];

            //Reafirmar que eu quero preencher com 0 e "" os vetores
            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                email[i] = "";
                senha[i] = "";
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
                nome[i] = leitura["nome"] + "";
                email[i] = leitura["email"] + "";
                senha[i] = leitura["senha"] + "";
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
                msg += $"\n\nCódigo: {codigo[i]} \nNome: {nome[i]}\n Email: {email[i]}\n Senha: {senha[i]}";
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
                    msg = $"\nCódigo: {this.codigo[i]} \nNome: {nome[i]}\n Email: {email[i]}\n Senha: {senha[i]}";
                    return msg;
                }//fim do if
            }//fim do método
            return "\n\nCódigo informado não foi encontrado!";
        }//fim do método

        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return nome[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não exite";
        }//fim do método

        public string ConsultarEmail(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return email[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não exite";
        }//fim do método

        public string ConsultarSenha(int codigo)
        {
            PreencherVetor();
            for (i = 0; i < contador; i++)
            {
                if (this.codigo[i] == codigo)
                {
                    return senha[i] + "";
                }//fim do if 
            }//fim do for
            return "Codigo não exite";
        }//fim do método

        public string Atualizar(int codigo, string campo, string novoDado)
        {
            try
            {
                string query = $"update usuario set {campo} = '{novoDado}' where codigo = '{codigo}'";
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
                string query = $"delete from usuario where codigo = '{codigo}'";
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
