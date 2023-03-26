using System.Net.Mail;

namespace EscolaDotNet.Prog1
{
    internal class Pessoa
    {
        private int id;
        private string nome = string.Empty;
        private MailAddress? email;
        private string? telefone;
        private string? endereco;
        private char? sexo;
        private DateTime? dataDeNascimento;
        private Pessoa? filiacao;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public MailAddress? Email { get => email; set => email = value; } //o caracter ? torna a variavél anulavel
        public string? Telefone { get => telefone; set => telefone = value; }
        public string? Endereco { get => endereco; set => endereco = value; }
        public char? Sexo { get => sexo; set => sexo = value; }
        public DateTime? DataDeNascimento { get => dataDeNascimento; set => dataDeNascimento = value; }
        public Pessoa? Filiacao { get => filiacao; set => filiacao = value; }


    }

}
