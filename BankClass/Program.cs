using BankClass;

class Program
{
    static void Main()
    {
        BankManager manager = new BankManager();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n Välj ett alternativ");
            Console.WriteLine("1. Öppna nytt konto");
            Console.WriteLine("2. Sätta in pengar");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Visa kontoinformationen");
            Console.WriteLine("5.Visa alla konton");
            Console.WriteLine("6. Avsluta");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ange ägaren :");
                    string owner = Console.ReadLine();

                    Console.Write("Ange insättningsbelopp : ");
                    decimal initialDeposit = decimal.Parse(Console.ReadLine());

                    Console.Write("Ange en pin-kod : ");
                    string pinCode = Console.ReadLine();

                    manager.OpenAccount(owner, initialDeposit, pinCode);
                    break;

                case "2":
                    Console.Write("Ange kontonummer :");
                    int depositAccount = int.Parse(Console.ReadLine());
                    
                    Console.Write("Ange insättningsbelopp : ");
                    decimal depositAmount = decimal.Parse(Console.ReadLine());

                    manager.Deposit(depositAccount, depositAmount);

                    break;

                case "3":
                    Console.Write("Ange kontonummer : ");
                    int withdrawAccount = int.Parse(Console.ReadLine());

                    Console.Write("Ange uttagsbelopp : ");
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());

                    manager.Withdraw(withdrawAccount, withdrawAmount);
                    
                    break;
                
                case "4":
                    Console.Write("Ange kontonummer : ");
                    int showAccountNumber = int.Parse(Console.ReadLine());

                    manager.ShowAccount(showAccountNumber);

                    break;

                case "5":
                    manager.ShowAllAccounts();

                    break;

                case "6":
                    exit = true;
                    break;


                default:
                    Console.WriteLine("Ogiltligt val. Försök igen.");
                    break;
            }
        }
    }
}