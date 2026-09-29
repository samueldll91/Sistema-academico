using Sistema_academico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_academico
{
    class Professor : Pessoa, IRelatorio
    {
        private double Salario { get; set; }
        public List<string> Turmas { get; set; }



        public Professor(string nome, string cpf, DateTime dataNascimento, double salario)
       : base(nome, cpf, dataNascimento)
        {
            Salario = salario;
            
            Turmas = new List<string>();

        }

        protected override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Salário: {Salario:C2}");
            Console.WriteLine("Turmas:");

            if (Turmas.Count == 0)
            {
                Console.WriteLine("Nenhuma turma atribuída.");
            }
            else
            {
                Console.WriteLine(string.Join(", ", Turmas));

            }


        }

        public void ExibirDados()
        {
            ExibirInformacoes(); // chamada aqui DENTRO da classe funciona, porque é protected acessado de dentro
        }
        public string GerarRelatorio()
        {
            return $"[PROFESSOR] {Nome} - {Turmas.Count} turma(s) - Salário {Salario:C2}";
        }
    }
}
