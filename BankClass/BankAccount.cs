using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClass
{
    class BankAccount
    {
        public int AccountNumber { get; }

        public string Owner { get; }

        public decimal Balance { get; private set; }

        private string PinCode { get; }


        public BankAccount (int accountNumber, string owner, decimal initialBalance, string pinCode)
        {
            AccountNumber = accountNumber;
            Owner = owner;
            Balance = initialBalance;
            PinCode = pinCode;
        }

        public bool ValidatePin(string pin)
        {
            return PinCode == pin;
        }

        public void Deposit(decimal amount)
        {
            if(amount > 0 )
            {
                Balance += amount;
                Console.WriteLine($"{amount} har satts in på konto : {AccountNumber}. Nytt saldo {Balance}");
            }
            else
            {
                Console.WriteLine("Insättningsbeloppet måste vara större än 0");
            }

        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance )
            {
                Balance -= amount;

                Console.WriteLine($"{amount} har tagits ut från konto {AccountNumber}. Nytt Saldo : {Balance}");

            }
            else if  (amount > Balance )
            {
                Console.WriteLine("Otillräckligt saldo. försök igen");
            }
            else
            {
                Console.WriteLine("Uttagsbeloppet måste vara större än 0");
            }
        }

        public override string ToString()
        {
            return $"{AccountNumber} Ägare : ({Owner}, Saldo {Balance})";
              
        }
    }
}
