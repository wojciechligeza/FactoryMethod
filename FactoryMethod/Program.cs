using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new SavingsFactory() as ISavingsFactory;
            var account = factory.GetSavingsAccount("ING");
            var nationalAccount = factory.GetSavingsAccount("PKO");

            Console.WriteLine($"Saldo z konta ING wynosi {account.Balance} zł" +
                              $" a z konto PKO BP wynosi {nationalAccount.Balance} zł");

            Console.ReadKey();
        }
    }

    // PRODUKT
    public abstract class SavingsAccount
    {
        public decimal Balance { get; set; }
    }

    // KONKRETNY PRODUKT 1
    public class IngSavingsAccount : SavingsAccount
    {
        public IngSavingsAccount()
        {
            Balance = 5000;
        }
    }

    // KONKRETNY PRODUKT 2
    public class PkoSavingsAccount : SavingsAccount
    {
        public PkoSavingsAccount()
        {
            Balance = 2000;
        }
    }

    // KREATOR
    interface ISavingsFactory
    {
        SavingsAccount GetSavingsAccount(string accountNumber);
    }

    // KONKTRETNY KREATOR
    public class SavingsFactory : ISavingsFactory
    {
        public SavingsAccount GetSavingsAccount(string accountNumber)
        {
            if (accountNumber.Contains("ING"))
            {
                return new IngSavingsAccount();
            }
            else if (accountNumber.Contains("PKO"))
            {
                return new PkoSavingsAccount();
            }
            else
            {
                throw new ArgumentException("Niepoprawny numer konta");
            }
        }
    }
}
