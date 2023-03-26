using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Mail;

namespace EscolaDotNet.Prog1
{
       internal class Aluno: Pessoa
    {
        //cria um propriedade estatica, ou seja, pertencente a classe Aluno e não suas instâncias
        //a propriedade é uma lista de instâncias da própria classe Aluno
        public static List<Aluno> listaAlunos = new();

        //cria um propriedade estatica privada para armazenar quantas instancias já foram criadas
        //assim tem como implementar um função para saber o tamanho da turma
        private static int _quantidadeAlunos { get; set; }
        //método publico para conseguir acessar a quantidade de instâncias já criadas
        // não possui um setter, assim não tem como modificar a propriedade fora dela mesma
        public static int quantidadeAlunos
        {
            get { return _quantidadeAlunos; }
        }

        
        // retorna true se existe algum aluno na lista com o nome passado
        public static bool ExisteAluno(string nomeAluno)
        {
            return listaAlunos.Exists(x => x.Nome == nomeAluno);
        }
               
        private List<int> _notas { get; set; }
        //uma forma mais concissa de implementar getters e setters
        public List<int> notas
        {
            get => _notas;
            set => _notas = value;
        }
        //método construtor da classe Aluno
        public Aluno(string nome, MailAddress? email, string? tel, string? endereco, char? sexo, DateTime? dataNascimento)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = tel;
            this.Endereco = endereco;
            this.Sexo = sexo;
            this.DataDeNascimento = dataNascimento;
            //quando a classe é instânciada o construtor da classe é chamado
            //então a cada instância a quantidade de alunos recebe mais 1.
            _quantidadeAlunos++;
            this._notas = new List<int>();
        }
    }
}
