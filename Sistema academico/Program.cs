using Sistema_academico.Interface;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

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
                DateTime datanascimento;
                bool valido;

                do
                {
                    Console.Write(mensagem);

                 valido = DateTime.TryParseExact(
                 Console.ReadLine(),
                 "dd/MM/yyyy",
                 CultureInfo.InvariantCulture,
                 DateTimeStyles.None,
                 out datanascimento
                 );
                    if (!valido)
                        Console.WriteLine("Data inválida! Use o formato dd/mm/aaaa.");

                } while (!valido);

                return datanascimento;
            }

            //metodo matricula
            static int LerMatricula(string mensagem)
            {
                int matricula;
                bool valido;

                do
                {
                    Console.Write(mensagem);
                    bool convertida = int.TryParse(Console.ReadLine(), out matricula);

                    // válido se converteu E está entre 100000 (menor número de 6 dígitos)
                    // e 999999 (maior número de 6 dígitos)
                    valido = convertida && matricula >= 100000 && matricula <= 999999;

                    if (!valido)
                        Console.WriteLine("Matrícula inválida! Digite um número com exatamente 6 dígitos.");

                } while (!valido);

                return matricula;
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


            static int LerInt(string mensagem)
            {
                int valor;
                bool valido;
                do
                {
                    Console.Write(mensagem);
                    valido = int.TryParse(Console.ReadLine(), out valor);
                    if (!valido)
                        Console.WriteLine("Valor inválido! Digite um número inteiro válido.");
                } while (!valido);
                return valor;
            }

            static string Lernome(string mensagem)
            {
                string nome;
                bool valido;

                do
                {
                    Console.Write(mensagem);
                    nome = Console.ReadLine();
                    valido = nome.Length > 0 && !nome.Any(char.IsDigit);
                    if (!valido)
                        Console.WriteLine("Nome invaldio! Não pode ser vazio ou  conter números! ");

                } while (!valido);
                return nome;
            }








            // FECHANDO METODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO


            static void CadastrarAluno()
            {
                try
                {
                    Console.WriteLine();
                    string nome = Lernome("Digite seu nome : ");
                    Console.WriteLine();

                    string cpf = LerCpf("CPF (somente números, 11 dígitos): ");
                    Console.WriteLine();



                    DateTime dataNascimento = LerData("Data de Nascimento (dd/mm/aaaa): ");
                    Console.WriteLine();

                    string matricula = LerMatricula("Matrícula (6 dígitos): ").ToString();
                    // Array fixo de 3 notas
                    double[] notas = new double[3];
                    notas[0] = LerDouble("Nota de Matemática: ");
                    notas[1] = LerDouble("Nota de Português: ");
                    notas[2] = LerDouble("Nota de História: ");

                   
                    Console.Clear();
                    Aluno novoAluno = new Aluno(nome, cpf, dataNascimento, matricula, notas);
                    listaAlunos.Add(novoAluno);

                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("------------------------------");
                    
                    Console.WriteLine("Aluno cadastrado com sucesso!");
                    Console.WriteLine("------------------------------");
                    novoAluno.Mostrar();
                    Console.WriteLine();
                    Console.WriteLine("Digite Qualquer Tecla para sair");
                    Console.ReadKey();
                    Console.Clear();

                }
                catch (Exception ex)
                {
                    // Rede de segurança: qualquer erro inesperado não derruba o programa
                    Console.WriteLine($"Erro ao cadastrar aluno: {ex.Message}");
                }
            }


























            static void CadastrarProfessor()
            {
                try
                {
                    Console.WriteLine();
                    string nome = Lernome("Digite seu nome : ");
                    Console.WriteLine();

                    string cpf = LerCpf("CPF (somente números, 11 dígitos): ");
                    Console.WriteLine();



                    DateTime dataNascimento = LerData("Data de Nascimento (dd/mm/aaaa): ");
                    Console.WriteLine();

                    string matricula = LerMatricula("Matrícula (6 dígitos): ").ToString();

                    double salario = LerDouble("Salario : ");



                    Professor novoProfessor = new Professor(nome, cpf, dataNascimento, salario);
                    int quantidadeTurmas = LerInt("Quantas turmas esse professor leciona? ");

                    for (int i = 1; i <= quantidadeTurmas; i++)
                    {
                        Console.Write($"Nome da turma {i}: ");
                        string nomeTurma = Console.ReadLine();
                        novoProfessor.Turmas.Add(nomeTurma);
                    }
                    listaProfessores.Add(novoProfessor);

                    Console.WriteLine();
                    Console.Clear();
                    Console.WriteLine("Professor cadastrado com sucesso!");
                    novoProfessor.ExibirDados();
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao cadastrar professor: {ex.Message}");
                }
            }

        }





        static void ListarTodos()
            
        {
           
            if (listaAlunos.Count == 0 && listaProfessores.Count == 0)
            {
                Console.WriteLine("Nenhum cadastro encontrado ainda.");
                return;
            }

            // Junta Alunos e Professores numa única lista do tipo Pessoa.
            // Isso só é possível por causa da HERANÇA (os dois "são" Pessoa).
            List<Pessoa> todasAsPessoas = new List<Pessoa>();
            todasAsPessoas.AddRange(listaAlunos);
            todasAsPessoas.AddRange(listaProfessores);

           
          

            Console.WriteLine("===== RELATÓRIO RESUMIDO (via Interface) =====");
            foreach (Pessoa pessoa in todasAsPessoas)
            {
                // INTERFACE em ação: só funciona porque Aluno e Professor
                // implementar IRelatorio
                if (pessoa is IRelatorio relatorio)
                {
                    Console.WriteLine(relatorio.GerarRelatorio());
                }
            }
            Console.WriteLine();




        }
    }
}


