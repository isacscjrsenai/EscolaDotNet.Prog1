using EscolaDotNet.Prog1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Net.Mail;


namespace EscolaDotNet.Prog1
{
    internal class Program
    {
        //----------------------------------------//
        //            Classe Comandos             //
        // Contém as funções :                    //
        //   - cadastro de aluno                  //
        //    - apaga aluno                       //
        //    - Registra nota de aluno            // 
        //    - Calcula média de nota de aluno    //
        //----------------------------------------//    
        public class Comandos
        {
            //-------------------------------------------------------------------------------//
            //                               Funçao Cadastra Alunos                          //
            //                                                                               //  
            // Pergunta o nome do aluno; telefone;endereço; sexo e idade.                    //
            // Adiciona a lista de alunos um nova instância da classe Aluno com os argumentos//
            // das perguntas.                                                                //
            //-------------------------------------------------------------------------------// 
            static void CadastraAluno()
            {
                string nomeAluno = "";
                MailAddress? emailAluno = new("teste@teste.com");
                string? telAluno ="";
                string? enderecoAluno = "";
                char? sexoAluno = ' ';
                DateTime? dataNascimentoAluno = DateTime.Now;
                bool valido = false;
                while(!valido)
                {
                    Console.WriteLine("Digite o nome do aluno(a)");
                    try
                    {
                        nomeAluno = Console.ReadLine();
                        // o método All da classe string retorna verdadeiro se todos os caracteres
                        // dessa string forem letras ou forem espaço
                        valido = nomeAluno.All(c => Char.IsLetter(c) || c == ' ');
                        if (!valido)
                        {
                            throw new FormatException();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite um nome válido");
                    }
                }
                //reinicia a variavel valido para a próxima pergunta
                valido = false;
                while (!valido)
                {
                    Console.WriteLine("Digite o email do aluno:");
                    try
                    {
                        emailAluno = new MailAddress(Console.ReadLine()!);
                        //Se o construtor da classe MailAddress não levantar um FormatException
                        //Então o email é valido 
                        valido = true;  
                         
                        
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite um email válido");
                    }
                }
                valido = false;
                while (!valido)
                {
                    Console.WriteLine("Digite o tel do aluno(a) no formato (xx) xxxxx-xxxx" );
                    try
                    {
                        telAluno = Console.ReadLine();
                        //verifica se o telefone digitado é um telefone usando expressão regular
                        //O métod IsMatch retorna verdadeiro se a string tiver dois números entre
                        // parênteses \(\d{2}\) um espaço seguido de 5 números um traço e 4 números
                        // a barra invertida \ serve para indicar que o parênteses não é da 
                        // organização da expressão regular e sim algo a se procurrar
                        // \d{n} indica a quantidade de caracteres númericos
                        valido = Regex.IsMatch(telAluno!, @"\(\d{2}\) \d{5}-\d{4}");
                        if (!valido)
                        {
                            throw new FormatException();
                        }
                    }
                    catch ( FormatException )
                    {
                        Console.WriteLine("Digite um telefone válido");
                    }
                }
                valido = false;
                
                
                Console.WriteLine("Digite o endereço do aluno(a)");
                enderecoAluno = Console.ReadLine();

                while (!valido) 
                {
                    Console.WriteLine("Digite o sexo do aluno(a) (M ou F)");
                    try
                    {
                        sexoAluno = char.Parse(Console.ReadLine()!);
                        valido = sexoAluno is 'M' or 'F';
                        if (!valido)
                        {
                            throw new FormatException();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite M ou F para o sexo do aluno(a)");
                    }
                }
                valido=false;

                while (!valido)
                {
                    Console.WriteLine("Digite a data de nascimento do aluno(a) no formato dd/MM/aaaa");
                    try
                    {
                        dataNascimentoAluno = DateTime.Parse(Console.ReadLine()!);
                        valido = true;
                    }
                    //Se a Data não tiver no formato certo o método Parse da classe DateTime vai
                    //lançar um excessão do tipo FormatException
                    catch (FormatException)
                    {
                        Console.WriteLine("Digite uma data de nascimento válida");
                    }
                }
                valido = false;
                
                
                //Cria um instância da classe Aluno como o parâmetro validados acima
                Aluno.listaAlunos.Add(new Aluno(nomeAluno, emailAluno, telAluno, enderecoAluno, sexoAluno, dataNascimentoAluno));
                Console.WriteLine("Aluno Registrado");
            }
            //Deleta o aluno da lista
            //Recebe uma string contendo um nome de aluno
            //Procura o indice da instância na lista de alunos que possui o atributo nome igual
            //a string passada como parâmetro da função
            //Remove da lista de alunos da classe Aluno a instância achada
            static void DeletaAluno(string nomeAluno)
            {
                Aluno.listaAlunos.Remove(Aluno.listaAlunos[Aluno.listaAlunos.FindIndex( x => x.Nome == nomeAluno)]);
            }

            // Armazena a nota do aluno
            // Recebe uma string com o nome do aluno e qual avaliação se quer gravar a nota
            // se o anulo existe, procura pelo aluno na lista de aluno da classe Aluno
            // Guarda o indice da lista de aluno a qual o aluno foi cadastrado em i
            // Pergunta qual a nota da avaliação do aluno informando o aluno e qual avaliação 
            // Grava em um lista temporária as notas desse aluno
            // Se a lista não esta populada ou se a nota das avaliações ainda não existe
            // Adiciona a lista a nota da avaliação e informa que a avaliação x do aluno y foi registrada
            // Caso contrário, ou seja, a lista já esta populada e a nota pra avaliação já existe
            // Substitui o valor e informa que houve substituição da nota da avaliação x do aluno y
            static void RegistraNota(string nomeAluno, int avaliacao)
            {
                bool valido = false;
                int nota = 0;
                if (Aluno.ExisteAluno(nomeAluno))
                {
                    int i = Aluno.listaAlunos.FindIndex(x => x.Nome == nomeAluno);
                    Console.WriteLine($"Digite a {avaliacao}ª nota do aluno {Aluno.listaAlunos[i].Nome}:");
                    List<int> notas = Aluno.listaAlunos[i].notas;
                    //testa se a nota é válida
                    while (!valido)
                    {
                        try
                        {
                            //Se a nota não for válida, ou seja, se não for digitado um inteiro
                            //O método Parse da classe int vai lançar uma excessão do tipo FormatException
                            nota = int.Parse(Console.ReadLine());
                            valido = true;
                            
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Digite uma nota válida");
                        }
                    }
                    if (notas.Count == 0 | notas.Count < avaliacao)
                    {
                        Aluno.listaAlunos[i].notas.Add(nota);
                        Console.WriteLine($"Nota {avaliacao} do aluno {nomeAluno} registrada com sucesso");
                    }
                    else
                    {
                        Aluno.listaAlunos[i].notas[avaliacao-1] = nota;
                        Console.WriteLine($"Nota {avaliacao} do aluno {nomeAluno} modificada com sucesso");
                    }
                }
                else Console.WriteLine("Não existe cadastro desse ano");
            }
            // Calcula a média do aluno
            // Recebe uma string com o nome do aluno
            // Se o aluno existe, acha o aluno na lista de aluno e armazena o indice de onde foi achado
            // Usando o indice armazenado guarda em um lista as notas do aluno
            // A variavel média recebe a soma das notas dividido pelo tamanho da lista de notas 
            // Se a media for menor que 7 muda a cor da fonte para vermelho e informa a nota
            // Senão, ou seja, a nota é maior que 7 informa a média na cor verde
            static void CalculaMediaAluno(string nomeAluno)
            {
                if (Aluno.ExisteAluno(nomeAluno))
                {
                    int i = Aluno.listaAlunos.FindIndex(x => x.Nome == nomeAluno);
                    string aluno = Aluno.listaAlunos[i].Nome;
                    List<int> notas = Aluno.listaAlunos[i].notas;
                    double media = notas.Sum() / notas.Count;
                    Console.Write($"A média das notas do aluno {aluno} é de:");
                    if (media < 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(media);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(media);
                    }
                }
                else
                {
                    Console.WriteLine("Não existe cadastro desse aluno");
                }

            }

            public static void ExecutaComando(string comando)
            {
                //==========================================================================
                // Recebe um string com o comando 
                // Separa as palavras da string 
                // Analisa a primeira palavra caso for aluno
                // Analisa a última palavra do comando caso haja os flags: del, nota e media
                // Chama o função especifica que lida com o flag
                //==========================================================================

                //separa a string recebida do comando em sub strings e coloca em um array de strings
                var resultado = comando.Split(' ');
                switch(resultado[0])
                {   
                    //caso a primeira substring do comando for aluno
                    case "aluno":
                        //analisa a última substring
                        switch(resultado[^1])
                        {   
                            case "-novo":
                                //caso a última substring do comando for -novo
                                //limpa o console
                                //chama a função CadastraAluno
                                //e aguarda o usuário digitar algo
                                //quando for digitado algo sai do análise da última substring
                                Console.Clear();
                                Comandos.CadastraAluno();
                                Console.ReadKey();
                                break;
                            case "-del":
                                //caso a última substring do comando for -del
                                //limpa o console
                                //concatena as substring que formam o nome do aluno de volta em uma só string
                                //chama a função DeletaAluno usando a variavel delAluno como argumento
                                // e aguarda o usuário digitar algo
                                //quando for digitado algo sai da análise última substring
                                Console.Clear();
                                string delAluno = string.Join(" ", resultado[1..^1]);
                                Comandos.DeletaAluno(delAluno);
                                Console.ReadKey();
                                break;
                            case "-media":
                                //caso a última substring do comando for -media
                                //limpa o console
                                //concatena as substrings que formam o nome do aluno de volta em uma só string
                                //guarda na variavél alunoDaMedia
                                //chama a função CalculeMediaAluno usando alunoDaMedia como argumento
                                Console.Clear();
                                string alunoDaMedia = string.Join(" ", resultado[1..^1]);
                                Comandos.CalculaMediaAluno(alunoDaMedia);
                                Console.ReadKey();
                                break;
                        }
                        
                        //separa a ultima substring em mais outras substrings usando '-' como divisor
                        string[] cmdnota = resultado[^1].Split('-');
                        //se a primeira substring for nota executa a funçao RegistraNota
                        if (cmdnota[1] =="nota")
                        {
                            Console.Clear();
                            //concatena as substring do comando que correspondem ao nome do aluno
                            string alunoDaNota = string.Join(" ", resultado[1..^1]);
                            //chama a função RegistraNota com os argumentos alunoDaNota e a ultima substring
                            //que se trata de qual avaliação do aluno a nota se trata
                            Comandos.RegistraNota(alunoDaNota, int.Parse(cmdnota[^1]));
                            Console.ReadKey();
                        }
                        break;

                    default: 
                        Console.WriteLine("Comando inválido");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            string comando = "";
            void MostraComandos()
            {
                //Cola a cor da fonte do console em branco
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("LISTA DE COMANDOS");
                Console.WriteLine("aluno -novo para cadastrar um novo aluno");
                Console.WriteLine("aluno 'nome do aluno' -del para deletar o registro de um aluno");
                Console.WriteLine("aluno 'nome do aluno' -nota-x para registrar a nota x do aluno");
                Console.WriteLine("aluno 'nome do aluno' -media para visualizar a média do aluno");
            }
            
            while (true)
            {
                //Quando algo for digitado o programa tenta executar, a função
                // ExecutaComando verifica se é um comando e se for chama a função responsável
                MostraComandos();
                comando = Console.ReadLine();
                if (comando != "")
                {
                    Comandos.ExecutaComando(comando);
                    Console.Clear();
                }
                

            }

        }
    }
}


    


