using Sistema_academico.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_academico
{
    class Aluno : Pessoa,IRelatorio
    {
        private string Matricula { get; set; }
        private double[] Notas { get; set; }
        private static readonly string[] Materias = { "Matemática", "Português", "História" };

        public Aluno(string nome, string cpf, DateTime dataNascimento, string matricula, Double[] notas)
            : base(nome, cpf, dataNascimento)
        {
            Matricula = matricula;
            Notas = notas;  
        }

        protected override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Matrícula: {Matricula}");

            Console.WriteLine($"Boletim");

            for( int i = 0; i < Notas.Length; i++)
            {
                Console.WriteLine($"{Materias[i]}: {Notas[i]}");
            }

        }

        public void Mostrar()
        {
            ExibirInformacoes(); // chamada aqui DENTRO da classe funciona, porque é protected acessado de dentro
        }
        public string GerarRelatorio()
        {
            return $"[ALUNO] {Nome} - Matrícula {Matricula} - {Notas.Length} notas lançadas";
        }

    }
}
