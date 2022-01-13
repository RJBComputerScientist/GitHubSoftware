using System;

namespace Banking
{
  class GiftCardAccount : BankAccount{
    //^^ able to define a new class
 private decimal _monthlyDeposit = 0m;

public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
    => _monthlyDeposit = monthlyDeposit;
    //^^ one liner
  public override void PerformMonthEndTransactions(){
    if (_monthlyDeposit != 0){
        MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
    }
}
  }

}