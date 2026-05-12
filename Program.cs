using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Banks.Models;
using Banks.Interfaces;
using Banks.Loggers;

class Program
{
    static async Task Main()
    {
        var accounts = new List<BankAccount>();

        while (true)
        {
            Console.Clear();

            Console.WriteLine("--- BEM VINDO AO BANCO DO BRASIL ---");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1 - Criar conta");
            Console.WriteLine("2 - Listar contas");
            Console.WriteLine("3 - Depositar");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Transferir");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("");

            var option = Console.ReadLine();
            Console.WriteLine("");

            switch (option)
            {
                case "1":
                    CreateAccount(accounts);
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;

                case "2":
                    ListAccounts(accounts);
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;

                case "3":
                    Deposit(accounts);
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;

                case "4":
                    Withdraw(accounts);
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;

                case "5":
                    Transfer(accounts);
                    Console.WriteLine("");
                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();

                    break;

                case "0":
                    return;
            }
        }

    }

    static void CreateAccount(List<BankAccount> accounts)
    {
        string name;

        while (true)
        {
            Console.WriteLine("Qual seu nome?");
            name = Console.ReadLine();
            Console.WriteLine("");

            if (!string.IsNullOrWhiteSpace(name) && !name.All(char.IsDigit))
                break;

            Console.WriteLine("Nome inválido.\n");
        }

        decimal value;
        bool success;

        while (true)
        {
            Console.WriteLine("Qual valor inicial da conta?");
            success = decimal.TryParse(Console.ReadLine(), out value);

            if (success)
                break;

            Console.WriteLine("Valor inválido.\n");
        }


        var account = new BankAccount(name, value, new ConsoleLogger());
        accounts.Add(account);

        Console.WriteLine("Conta criada com sucesso!");
    }

    static void ListAccounts(List<BankAccount> accounts)
    {
        if (accounts.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada.");
            return;
        }

        Console.WriteLine("--- LISTA DE CONTAS ---");

        foreach (var account in accounts)
        {
            Console.WriteLine($"Nome: {account.Name} - Saldo: R$ {account.Balance}");
        }
    }

    static void Deposit(List<BankAccount> accounts)
    {
        Console.WriteLine("Digite o nome da conta:");
        string name = Console.ReadLine();
        Console.WriteLine("");

        var account = accounts.FirstOrDefault(account => account.Name == name);

        if (account == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        Console.WriteLine("Digite o valor do depósito:");

        if (!decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.WriteLine("");

        if (account.Deposit(value))
        {
            Console.WriteLine("Depósito realizado com sucesso!");
        }
    }

    static void Withdraw(List<BankAccount> accounts)
    {
        Console.WriteLine("Digite o nome da conta:");
        string name = Console.ReadLine();
        Console.WriteLine("");

        var account = accounts.FirstOrDefault(account => account.Name == name);

        if (account == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        Console.WriteLine("Digite o valor do saque:");

        if (!decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.WriteLine("");

        if (account.Withdraw(value))
        {
            Console.WriteLine("Saque realizado com sucesso!");
        }

    }

    static void Transfer(List<BankAccount> accounts)
    {
        Console.WriteLine("Digite o nome da conta de origem:");
        string originName = Console.ReadLine();
        Console.WriteLine("");

        var account = accounts.FirstOrDefault(account => account.Name == originName);

        if (account == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        Console.WriteLine("Digite o nome da conta de destino:");
        string destinName = Console.ReadLine();
        Console.WriteLine("");

        var account2 = accounts.FirstOrDefault(account => account.Name == destinName);

        if (account2 == null)
        {
            Console.WriteLine("Conta não encontrada.");
            return;
        }

        Console.WriteLine("Digite o valor da transferencia:");

        if (!decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.WriteLine("");
        if (account.Transfer(account2, value))
        {
            Console.WriteLine("Transferencia realizada com sucesso!");
        }
    }

}


