using System;

namespace Banking
{
 class LineOfCreditAccount : BankAccount{
     public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit){ 
}
 public override void PerformMonthEndTransactions()
{
    if (Balance > 500m)
    {
        var interest = Balance * 0.05m;
        MakeDeposit(interest, DateTime.Now, "apply monthly interest");
    }
}
protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
//                                  ^^^                 boolean arguement returns a transaction
    isOverdrawn
    ? new Transaction(-20, DateTime.Now, "Apply overdraft fee")
    : default;
  }
    
}