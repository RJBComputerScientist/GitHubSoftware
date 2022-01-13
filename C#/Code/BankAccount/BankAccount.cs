using System;
using System.Collections.Generic;

namespace Banking
{
    class BankAccount
    {
        public string Number { get; }
        //^^ public members .. ^^ properties
        public string Owner { get; set; }
        //^^ public members
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions){
                // ^^^ like a for of loop
                    balance += item.Amount;
                }

                return balance;
            }
        }
        private static int accountNumberSeed = 1234567890;
        //^^ static field .. FIELDS
        //Decimal is a floating point number
        private readonly decimal minimumBalance;
        // ^^^ a field
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            //Represents an instant in time, typic^^^ally expressed as a date and time of day.
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);

        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            //                                                  ^^^^ OPTIONAL ARGUEMENT
            // this.Owner = Owner;
            // this.Balance = initialBalance;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            //DateTime.Now is a property that^^ returns the current date and time.
        }
        private List<Transaction> allTransactions = new List<Transaction>();
        //^^^ field
        public string GetAccountHistory(){
            //method returning a string
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
        // public class InterestEarningAccount : BankAccount
        // {
        //     public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance){
        //         //                                                  syntax to indic^^^^ate a call to a base class constructor 
        // }
        // }

        // public class LineOfCreditAccount : BankAccount
        // {
        // }

        // public class GiftCardAccount : BankAccount
        // {
        // }

        public virtual void PerformMonthEndTransactions() { }
        //^^^ virtual method .. has nothing in it
    }
}