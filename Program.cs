using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine();
                Console.WriteLine("Cadastre uma conta para utilizar todas as nossas vantagens!");
                ObterOpcaoUsuario();
            }

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContadestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser trasferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContadestino]);
        }

        private static void Depositar()
        {
            VerificarContasCadastradas();

            Console.WriteLine("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            VerificarContasCadastradas();

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarConta()
        {
            Console.WriteLine("Listar contas");
            
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Criar nova conta");
            Console.WriteLine();

            int entradaTipoConta = 0;
            string entradaNome = "";

            try
            {
                Console.Write("Digite 1 para Conta Física ou 2 para Juridica: ");
                entradaTipoConta = int.Parse(Console.ReadLine());
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Opção Inválida! Selecione uma opção válida.");
                Console.WriteLine();
                InserirConta();
            }

            if(entradaTipoConta == 1)
            {
                Console.Write("Digite o Nome do Cliente: ");
                entradaNome = Console.ReadLine();
            }
            else
            {
                Console.Write("Digite o Nome da Empresa: ");
                entradaNome = Console.ReadLine();
            }

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome);
            
            listContas.Add(novaConta);
            Console.WriteLine();
            // entradaTipoConta = 0;
            Console.WriteLine("Conta Criada Com Sucesso, bem vindo ao DIO Bank!");
            ObterOpcaoUsuario();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Lista contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            String opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;

        }

        private static void VerificarContasCadastradas()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.WriteLine();
                Console.WriteLine("Cadastre uma conta para utilizar todas as nossas vantagens!");
                ObterOpcaoUsuario();
            }
        }

    }
}
