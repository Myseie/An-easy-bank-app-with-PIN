using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankClass
{
    class BankManager
    {
        private List<BankAccount> accounts = new List<BankAccount>();

        private int nextAccountNumber = 1001;

        public void OpenAccount(string owner, decimal initialDeposit, string pinCode)
        {
            BankAccount newAccount = new BankAccount(nextAccountNumber, owner, initialDeposit, pinCode);

            accounts.Add(newAccount);

            nextAccountNumber++;

            Console.WriteLine($"Ett nytt konto har öppnats för {owner} med kontonummer {newAccount}");
        }

        private bool AuthenticAccount(BankAccount account)
        {
            Console.Write("Ange Pinkod : ");
             
            string enteredPin = Console.ReadLine();

            if (account.ValidatePin(enteredPin))
            {
                return true;

            }
            else
            {
                Console.WriteLine("Felaktig pin");
                return false;

            }
        }

        public void Deposit(int accountNumber, decimal amount)
        {
            BankAccount account = FindAccount(accountNumber);
            if (account != null)
            {
                account.Deposit(amount);
            }
        }

        public void Withdraw(int accountNumber, decimal amount)
        {
            BankAccount account = FindAccount(accountNumber);

            if (account != null)
            {
                account.Withdraw(amount);
            }
        }

        public void ShowAccount(int accountNumber)
        {
            BankAccount account = FindAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine(account);
            }
        }

        public void ShowAllAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("Inga konton som har öppnats än");
            } 
            else
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine(account);

                }
            }
        }

        private BankAccount FindAccount(int accountNumber)
        {
            return accounts.Find(a => a.AccountNumber == accountNumber);
        }

            
    }
}
