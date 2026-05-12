using System.Text.Json.Serialization;
using Banks.Interfaces;
using Banks.Loggers;

namespace Banks.Models
{
    public class BankAccount
    {
        private readonly ILogger logger;

        public string Name
        {
            get; private set;
        }

        public decimal Balance 
        { 
            get; private set;
        
        }

        public string Branch
        {
            get; private set;
        }



        [JsonConstructor]

        public BankAccount(string name, decimal balance) : this(name, balance, new ConsoleLogger())
        {    
        }
        
        public BankAccount(string name, decimal balance, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Nome inválido.", nameof(name));
            }
            if (balance < 0)
            {
                throw new Exception("Saldo não pode ser negativo.");
            }
            Name = name;
            Balance = balance;
            this.logger = logger;
        }

        public bool Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                logger.Log($"Não é possível depositar {amount} na conta de {Name}.");
                return false;
            }
            
            Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                logger.Log($"Saldo insuficiente para operação na conta de {Name}");
                return false;
            }

            Balance -= amount;
            return true;
        }
        
        public bool Transfer(BankAccount otherAccount, decimal amount)
        {
            if (otherAccount == null)
            {
                logger.Log("Conta de destino inválida.");
                return false;
            }
            
            if(Withdraw(amount))
            {
                otherAccount.Deposit(amount);
                Console.WriteLine($"{Name} transferiu R${amount} para {otherAccount.Name}");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"{Name} - Saldo: R$ {Balance}");
        }

    }

}