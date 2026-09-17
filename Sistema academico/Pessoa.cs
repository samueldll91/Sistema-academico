using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_academico
{
    class Pessoa
    {
       protected string? Nome { get; set; }
       protected int? Cpf { get; set; }
       protected int? DataNascimento { get; set; }

        public Pessoa(string nome, int cpf, int dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;

            
        }


        protected virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"CPF: {Cpf}");
            Console.WriteLine($"Data de Nascimento: {DataNascimento}");
        }

    }
}
