using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Bank.Class
{
    public class Account
    {

        public AccountType AccountType { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }
        public Account(AccountType accountType, double balance, double credit, string name)
        {
            AccountType = accountType;
            Balance = balance;
            Credit = credit;
            Name = name;
        }

        public bool toWithdraw(double amount)
        {
 
            if (this.Balance - amount < (this.Credit*-1))
            {
                Console.WriteLine("Insufficient funds!");
                return false;
            }
            else
            {
                this.Balance -= amount;
                Console.WriteLine("{0}'s account balance is: {1}",
                    this.Name,this.Balance.ToString("F2"),
                    CultureInfo.InvariantCulture);

                return true;
            }


        }
        public  void Deposit(double amount)
        {
            this.Balance += amount;

            Console.WriteLine("{0}'s account balance is: {1}",
                    this.Name, this.Balance.ToString("F2"),
                    CultureInfo.InvariantCulture);

        }

        public void Transfer(double transferValue, Account destAccount)
        {
            if (this.toWithdraw(transferValue))
            {
                destAccount.Deposit(transferValue);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name} / {this.AccountType}");
            sb.AppendLine($"Balance: ${this.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Credit: ${this.Credit.ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();

        }

    }
}
