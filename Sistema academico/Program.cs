using System.Globalization;

namespace Sistema_academico
{
     class Program
    {
        static List<Aluno> listaAlunos = new List<Aluno>();
        static List<Professor> listaProfessores = new List<Professor>();



        static void Main(string[] args)
        {
            int opcao;

            do
            {
                Console.WriteLine("===== SISTEMA DE GESTÃO ACADÊMICA =====");
                Console.WriteLine("1 - Cadastrar Aluno");
                Console.WriteLine("2 - Cadastrar Professor");
                Console.WriteLine("3 - Listar todos (relatório geral)");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                

                bool opcaoValida = int.TryParse(Console.ReadLine(), out opcao);
                if (!opcaoValida)
                {
                    Console.WriteLine("Opção inválida. Digite um número.");
                    opcao = -1; // valor "neutro" só pra não bater com nenhum case e não sair do loop
                    continue;
                  
                }
                

                switch (opcao)
                {
                    case 1:
                        CadastrarAluno();
                        break;
                    case 2:
                        CadastrarProfessor();
                        break;
                    case 3:
                        ListarTodos();
                        break;
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }





            } while (opcao != 0);

            //metodo valido para eu ler o os meus atributos de data, cpf e double, para não ficar repetindo o mesmo código em cada cadastro ///////////////////////////////////////////////////////////////////////////////////////////////////////
            static DateTime LerData(string mensagem)
            {
                DateTime valor;
                bool valido;

                do
                {
                    Console.Write(mensagem);
                    valido = DateTime.TryParse(Console.ReadLine(), out valor);

                    if (!valido)
                        Console.WriteLine("Data inválida! Use o formato dd/mm/aaaa.");

                } while (!valido);

                return valor;
            }
        
            static string LerCpf(string mensagem)
            {
                string cpf;
                bool valido;
                do
                {
                    Console.Write(mensagem);
                    cpf = Console.ReadLine();
                    // Validação simples: CPF deve ter 11 dígitos e ser numérico
                    valido = cpf.Length == 11 && cpf.All(char.IsDigit);
                    if (!valido)
                        Console.WriteLine("CPF inválido! Deve conter exatamente 11 dígitos numéricos.");
                } while (!valido);
                return cpf;
            }


            static double LerDouble(string mensagem)
            {
                double valor;
                bool valido;
                do
                {
                    Console.Write(mensagem);
                    valido = double.TryParse(Console.ReadLine(), out valor);
                    if (!valido)
                        Console.WriteLine("Valor inválido! Digite um número válido.");
                } while (!valido);
                return valor;
            }

          


            


            // FECHANDO METODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO


            static void CadastrarAluno()
            {
                try
                {
                    Console.WriteLine();
                    Console.WriteLine("Digite seu nome");
                    string nome = Console.ReadLine();
                    Console.WriteLine();

                    string cpf = LerCpf("CPF (somente números, 11 dígitos): ");
                    Console.WriteLine();

               

                    DateTime dataNascimento = LerData("Data de Nascimento (dd/mm/aaaa): ");
                    Console.WriteLine();

                    Console.WriteLine("Digite o Numero da Sua Matricula : ");
                    string matricula = Console.ReadLine();
                // Array fixo de 3 notas
                double[] notas = new double[3];
                notas[0] = LerDouble("Nota de Matemática: ");
                notas[1] = LerDouble("Nota de Português: ");
                notas[2] = LerDouble("Nota de História: ");

                Aluno novoAluno = new Aluno(nome, cpf, dataNascimento, matricula, notas);
                listaAlunos.Add(novoAluno);

                Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("------------------------------");
                Console.WriteLine("Aluno cadastrado com sucesso!");
                    Console.WriteLine("------------------------------");
                    novoAluno.Mostrar();

            }
            catch (Exception ex)
            {
                // Rede de segurança: qualquer erro inesperado não derruba o programa
                Console.WriteLine($"Erro ao cadastrar aluno: {ex.Message}");
            }
        }

 
            























                 static void CadastrarProfessor()
            {

            }



            static void ListarTodos()
            {

            }




        }
}
}

