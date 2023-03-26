# Média de Notas
## Programa em C# para o terminal

### Esse programa tem carater educacional então está comentado linha por linha de forma didática. 
### Sinta-se livre para modifica-lo a vontade.

O programa apresenta comandos que o usuário pode digitar no terminal.
aluno -novo 
aluno 'nome do aluno' -del
aluno 'nome do aluno' -notas-x
aluno 'nome do aluno' -media

Ao digitar o comando aluno -novo será perguntado:
- O nome do aluno
- O email do aluno
- O telefone
- O sexo
- O endereço
- A data de nascimento

Se todos os campos forem digitados corretamente o programa grava as informações, senão avisa para o usuario que o formato esta errado e o usuário tem que digitar certo.

Se o comando for aluno 'nome do aluno' -notas-x onde o x é um numero correspondente a qual avaliação o programa pergunta qual foi a nota.
Se a nota for digitada corretamente, ou seja, o usuário não digitar um número o programa avisa para digitar corretamente.

O comando aluno 'nome do 'aluno' -media mostra a média do aluno, se a média for menor que 7 mostra a nota em vermelho se for maior mostra em verde.

Se for digitado os comandos com um nome de aluno que não foi registrado pelo comando aluno -novo o programa avisa que tal aluno não existe na lista de alunos.

O comando aluno 'nome do aluno' -del deleta o aluno da lista de alunos.

O programa é feito usando o paradigma OO, então cada aluno é um objeto da classe Aluno que herda caracteristica da classe Pessoa, os comandos estão dentro da classe Comando.
Todo os campos são tratados, então não tem como digitar um email errado e nem informar um data de nascimento ou um telefone em formato não preestabelecido.
Para o email é usada a classe MailAdress da built-in class System.Net.Mail então ao digitar qualquer coisa que não seja email a propria classe lença um excessão do tipo FormatException.
A mesma coisa acontece com a data de nascimento onde é usada a classe DateTime.
O número de telefone é tratado usando expressão regular e o sexo usando a palavra reservada do C# "is".

Toda instância de Aluno é guardada dentro da própria classe Aluno em um atributo estático, a classe conta quantas instâncias dela existem através de outro atributo estático.
Todos atributos da classe Pessoas são privados e são acessados por métodos públicos, garantindo uma certa segurança na utilização da classe e das classes filhas como a Aluno.
