using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_academico
{
    class Pessoa
    {
        protected string Nome { get; set; }
        protected string Cpf { get; set; }
        protected DateTime DataNascimento { get; set; }


        public Pessoa(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;


        }


        protected virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine();
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine();
            Console.WriteLine($"Data de Nascimento: {DataNascimento:dd/MM/yyyy}");
            Console.WriteLine();
        }

        public void ExibirDados()
        {
            ExibirInformacoes(); // chamada aqui DENTRO da classe funciona, porque é protected acessado de dentro
        }
    }
}
