using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EscolaDotNet.Prog1
{
    internal class Aluno
    {
        //cria um propriedade estatica, ou seja, pertencente a classe Aluno e não suas instâncias
        //a propriedade é um array de instâncias da própria classe Aluno
        public static List<Aluno> listaAlunos = new List<Aluno>();

        // fazendo com arrays public static Aluno[] listaAlunos = new Aluno[25];

        //cria um propriedade estatica privada para armazenar quantas instancias já foram criadas
        private static int _quantidadeAlunos { get; set; }
        //método publico para conseguir acessar a quantidade de isntâncias já criadas
        // não possui método set, assim não tem como modificar a propriedade fora dela mesma
        public static int quantidadeAlunos
        {
            get { return _quantidadeAlunos; }
        }
        //método publico que retorna o indíce da instância Aluno dentro da lista de instâncias
        //se não houve na lista nenhuma instância que tenha o nome passado então retorna -1
        
        
        //como fazer usando arrays
        //public static int ExisteAluno(string nomeAluno)
        //{
        //    //TODO Fazer com foreach
        //    //TODO Fazer com IndexOf
        //    for (int i = 0; i < listaAlunos.Length; i++)
        //    {
        //        if (nomeAluno == listaAlunos[i]._nome)
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        public static bool ExisteAluno(string nomeAluno)
        {
            return listaAlunos.Exists(x => x._nome == nomeAluno);
        }
        private string _nome { get; set; }
        public string nome { get; }
        private string _email { get; set; }
        private string _tel { get; set; }
        private string _endereco { get; set; }
        private char _sexo { get; set; }
        private int _idade { get; set; }
        
        //fazendo com arrays
        //private int[] _notas { get; set; } = new int[4] { -1, -1, -1, -1 };
        //public int[] notas
        //{
        //    get
        //    {
        //        return _notas;
        //    }
        //    set
        //    {
        //        _notas = value;
        //    }
        //}
        private List<int> _notas { get; set; } = new List<int>();
        public Aluno(string nome, string email, string tel, string endereco, char sexo, int idade)
        {
            this._nome = nome;
            this._email = email;
            this._tel = tel;
            this._endereco = endereco;
            this._sexo = sexo;
            this._idade = idade;
            _quantidadeAlunos++;
        }
    }
}
