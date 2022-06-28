namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main()
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
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
                    case "6":
                        Apagar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadKey();
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                System.Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta Física ou 2 para Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine()!;

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine()!);

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine()!);

            Conta novaConta = new Conta(
            tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo,
            credito: entradaCredito,
            nome: entradaNome!);

            listContas.Add(novaConta);
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine()!);

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine()!);

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine()!);

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine()!);

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Apagar()
        {
            Console.Write("Digite o número da conta a ser apagada: ");
            int indiceConta = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Atenção, essa ação não poderá ser desfeita!");
            Console.WriteLine("Todos os dados serão perdidos e NÃO será mais possível realizar operações nesta conta");
            Console.Write("Deseja realmente continuar? (s/n): ");
            char resultado = char.Parse(Console.ReadLine()!);

            if (resultado == 's' || resultado == 'S'){
                listContas.Remove(listContas[indiceConta]);
            }

            ObterOpcaoUsuario();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("------------------------");
            Console.WriteLine("6- Apagar conta");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine()!.ToUpper();
            Console.WriteLine();

            return opcaoUsuario;
        }
    }
}
