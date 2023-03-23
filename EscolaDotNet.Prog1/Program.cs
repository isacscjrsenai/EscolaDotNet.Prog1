using EscolaDotNet.Prog1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EscolaDotNet.Prog1
{
    internal class Program
    {

        public class Comandos
        {
            static void CadastraAluno()
            {
                string nomeAluno;
                string telAluno;
                string enderecoAluno;
                char sexoAluno;
                int idadeAluno;
                Console.WriteLine("Digite o nome do aluno(a)");
                nomeAluno = Console.ReadLine();
                Console.WriteLine("Digite o tel do aluno(a)");
                telAluno = Console.ReadLine();
                Console.WriteLine("Digite o endereço do aluno(a)");
                enderecoAluno = Console.ReadLine();
                Console.WriteLine("Digite o sexo do aluno(a) (M ou F)");
                sexoAluno = char.Parse(Console.ReadLine());
                Console.WriteLine("Digite a idade do aluno(a)");
                idadeAluno = int.Parse(Console.ReadLine());
                Aluno.listaAlunos.Add(new Aluno(nomeAluno, telAluno, enderecoAluno, enderecoAluno, sexoAluno, idadeAluno));
                Console.WriteLine("Aluno Registrado");
            }

            //como fazer usando arrays
            //static void DeletaAluno(string nomeAluno)
            ////Recebe um nome de aluno
            ////Verifica se o aluno existe na lista de alunos
            ////Se existe o aluno deleta o aluno
            //{
            //    int i = Aluno.ExisteAluno(nomeAluno);
            //    if (i != -1)
            //    {
            //        Console.WriteLine($"Aluno:{Aluno.listaAlunos[i].nome} foi deletado da lista de alunos");
            //        Aluno.listaAlunos[i] = null;
            //    }
            //    else
            //    {
            //        Console.WriteLine("O aluno não existe");
            //    }
            //}
            static void DeletaAluno(string nomeAluno)
            {
                Aluno.listaAlunos.Remove(Aluno.listaAlunos[Aluno.listaAlunos.FindIndex(x => x.nome == nomeAluno)]);
            }

            static void RegistraNota(string nomeAluno, int avaliacao)
            //Recebe um nome de aluno
            //Verifica se o aluno existe na lista de alunos
            //Se o aluno existir registra a nota

            {
                int i = Aluno.ExisteAluno(nomeAluno);
                if (i != -1)
                {
                    Console.WriteLine($"Digite a {avaliacao}ª nota do aluno {Aluno.listaAlunos[i].nome}:");
                    Aluno.listaAlunos[i].notas[avaliacao] = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nota Registrada");
                }
                else
                {
                    Console.WriteLine("O aluno não existe");
                }
            }

            static void CalculaMediaAluno(string nomeAluno)
            //Recebe um nome de aluno
            //Verifica se o aluno existe na lista de alunos
            //Se o aluno existir calcula a média das notas já registradas do aluno
            {
                int quantidadeAvaliacoes = 0;
                double mediaAluno;
                // retorna o indice do array onde o aluno se encontra na lista de alunos
                // se não existe o aluno a função retorna -1
                int i = Aluno.ExisteAluno(nomeAluno);
                //soma as notas existentes do aluno
                int somaNotasAluno = Aluno.listaAlunos[i].notas.Sum();
                //Verifica quantas notas o aluno tem registrada
                //
                for (int j = 0; j <= 3; j++)
                {
                    if (Aluno.listaAlunos[i].notas[j] != -1)
                    {
                        quantidadeAvaliacoes++;
                    }
                }
                mediaAluno = somaNotasAluno / quantidadeAvaliacoes;
                //Se o indice do aluno na lista é diferente de -1, ou seja, ele existe
                //Mostra a média do aluno
                if (i != -1)
                {
                    Console.WriteLine($"A média do aluno(a):{Aluno.listaAlunos[i].nome} é {mediaAluno}.");
                    Aluno.listaAlunos[i] = null;
                }
                //Se não existe o aluno mostra que não existe.
                else
                {
                    Console.WriteLine("O aluno não existe");
                }
            }


            public static void ExecutaComando(string comando)
            {
            //==========================================================================
            // Recebe um string com o comando 
            // Separa as palavras da string 
            // Analisa a primeira palavra procurando aluno
            // Se há a palavra aluno
            // Procura na última palavra do comando pelos flags: del, nota e media
            // Se houver algum desses chama o método especifico que lida com o flag
            //==========================================================================

                //separa a string recebida do comando em sub strings e coloca em um array de strings
                string[] resultado = comando.Split(' ');
                switch(resultado[0])
                {
                    case "aluno":
                        switch(resultado[^1])
                        {
                            case "-novo":
                                Console.Clear();
                                Comandos.CadastraAluno();
                                break;
                            case "-del":
                                Console.Clear();
                                string delAluno = string.Join(" ", resultado[1..^1]);
                                Comandos.DeletaAluno(delAluno);
                                break;
                            case "-media":
                                Console.Clear();
                                string mediaAluno = string.Join(" ", resultado[1..^1]);
                                Comandos.CalculaMediaAluno(mediaAluno);
                                break;
                        }
                        string[] cmdnota = resultado[^1].Split('-');
                        if (cmdnota[0] =="nota")
                        {
                            Console.Clear();
                            string notaAluno = string.Join(" ", resultado[1..^1]);
                            Comandos.RegistraNota(notaAluno, int.Parse(cmdnota[1]));
                        }
                        break;

                    default: 
                        Console.WriteLine("Comando inválido");
                        break;
                }

                // Se o comando for aluno -novo chama o função CadastraAluno()
                //if (comando == "aluno -novo")
                //{
                //    Console.Clear();
                //    CadastraAluno();
                //    
                //}
                //Se a primeira substring for aluno busca pelas flags na última substring
               
                //if (resultado[0] == "aluno")
                //{
                //    //Busca na última substring pela flag -del
                //    if (resultado[^1] == "-del")
                //    {
                //        //concatena em um só string o nome do aluno 
                //        string nomeAluno = string.Join(" ", resultado[1..^1]);
                //        //Chama a função DeletaAluno com o parametro nomeAluno que contém a 
                //        //string concatenada do nome do aluno
                //        Console.Clear();
                //        DeletaAluno(nomeAluno);
                //    }
                //    // Verifica se a última substring contém a flag -nota
                //    if (resultado[^1].Contains("-nota"))
                //    {
                //        // concatena em uma só string o nome do aluno
                //        string nomeAluno = string.Join(" ", resultado[1..^1]);
                //        //Divide a última substring usando o caracter "-" de flag
                //        // Assim a útima substring que nesse caso é -nota-numero da avaliação
                //        // vira duas strings a última é o número da avaliação e é colocada 
                //        // na variável avaliacao como a variável é um int é necessário a conversação
                //        int avaliacao = int.Parse(resultado[^1].Split("-")[^1]) -1;
                //        //Chama a função RegistraNota usando o nome do aluno e o número da avaliação
                //        // como parâmetros
                //        Console.Clear();
                //        RegistraNota(nomeAluno, avaliacao);
                //    }
                //    // Verifica se a última substring é -media
                //    if (resultado[^1] == "-media")
                //    {
                //        // concatena em uma só string o nome do aluno
                //        string nomeAluno = string.Join(" ", resultado[1..^1]);
                //        //Chama a função CalculaMediaAluno usando o nome do aluno como parâmetro
                //        Console.Clear();
                //        CalculaMediaAluno(nomeAluno);
                //    }
                //}
            }
        }
        static void Main(string[] args)
        {
            string comando = "";

            Console.WriteLine("LISTA DE COMANDOS");
            Console.WriteLine("aluno -novo para cadastrar um novo aluno");
            Console.WriteLine("aluno 'nome do aluno' -del para deletar o registro de um aluno");
            Console.WriteLine("aluno 'nome do aluno' -nota-x para registrar a nota x do aluno");
            Console.WriteLine("aluno 'nome do aluno' -media para visualizar a média do aluno");
            while (true)
            {
                //Quando algo for digitado o programa tenta executar, a função
                // ExecutaComando verifica se é um comando e se for chama a função responsável
                comando = Console.ReadLine();
                if (comando != "")
                {
                    Comandos.ExecutaComando(comando);
                }
                

            }

        }
    }
}


    


