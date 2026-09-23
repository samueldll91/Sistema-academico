using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_academico
{
    class Professor : Pessoa
    {
        private int Salario { get; set; }
        private List<string> Turmas { get; set; }


        public Professor(string nome, string cpf, DateTime dataNascimento, int salario, List<string> turmas)
       : base(nome, cpf, dataNascimento)
        {
            Salario = salario;
            Turmas = turmas;
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



    }
}
