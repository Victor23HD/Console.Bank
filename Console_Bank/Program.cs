using System;
using Console_Bank.Class;

namespace Console_Bank
{
    class Program
    {
        public static void Main()
        {
            Account baseAccount = new Account(AccountType.PhysicalPerson, 500.00, 500.00, "Victor");
            Account anotherAccount = new Account(AccountType.PhysicalPerson, 1000.00, 1000.00, "Steve");
            double n1;
            
            inicio:
            Console.Clear();
            Console.WriteLine("welcome to dio bank!");
            Console.WriteLine("Enter the desired option: ");

            Console.WriteLine("1- List accounts\n2- Insert new account" +
                "\n3- Transfer\n4- To withdraw\n5- Deposit\n" +
                "E- Exit\n");

            string option = Console.ReadLine();

            option = option.ToUpper();
            while (option.ToUpper() != "E")
            {
                switch (option)
                {
                    case "1":
                        Console.WriteLine(baseAccount);
                        Console.WriteLine(anotherAccount);
                        Console.ReadLine();
                        goto inicio;
                        break;
                    case "2":
                        Console.Write("\nName: ");
                        string name = Console.ReadLine();
                        Console.Write("Type Account: [PhysicalPerson/LegalPerson]");
                        string a = Console.ReadLine();
                        AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), a);
                        Console.Write("Balance: ");
                        double balance = double.Parse(Console.ReadLine());
                        Console.Write("Credit: ");
                        double credit = double.Parse(Console.ReadLine());
                        ERROR1:
                        Console.Write("What account? [baseAccount = b/ anotherAccount = a]");
                        string value = Console.ReadLine();
                        if (value.ToUpper() == "A")
                        {
                            anotherAccount = new Account(accountType, balance, credit, name);
                            Console.WriteLine(baseAccount);
                            Console.WriteLine(anotherAccount);
                            Console.ReadLine();
                            goto inicio;

                        }
                        else if (value.ToUpper() == "B")
                        {  
                            baseAccount = new Account(accountType, balance, credit, name);
                            Console.WriteLine(baseAccount);
                            Console.WriteLine(anotherAccount);
                            Console.ReadLine();
                            goto inicio;
                        }
                        else
                        {
                            Console.WriteLine("Enter a valid account");
                            Console.WriteLine();
                            goto ERROR1;

                        }
                        break;
                    case "3":
                        Console.Write("enter a value: ");
                        n1 = double.Parse(Console.ReadLine());
                        baseAccount.Transfer(n1, anotherAccount);
                        Console.WriteLine("transfer made successfully!");
                        Console.ReadLine();
                        goto inicio;
                        break;
                    case "4":
                        Console.Write("what amount do you want to withdraw? ");
                        n1 = double.Parse(Console.ReadLine());
                        baseAccount.toWithdraw(n1);
                        Console.WriteLine("Withdraw made successfully!");
                        Console.ReadLine();
                        goto inicio;
                        break;
                    case "5":
                        Console.Write("what is the deposit amount? ");
                        n1 = double.Parse(Console.ReadLine());
                        baseAccount.Deposit(n1);
                        Console.ReadLine();
                        goto inicio;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("Thanks for using our services!!!");
            }

        }
    }
}

