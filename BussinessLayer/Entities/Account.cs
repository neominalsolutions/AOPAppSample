using BussinessLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Entities
{
  public class Account:Entity
  {
    public Money Balance { get; private set; }
    public string AccountNumber { get; init; }


    Account(string accountNumber, string currency)
    {
      
      ArgumentNullException.ThrowIfNull(accountNumber);
      ArgumentNullException.ThrowIfNull(currency);
      
      Balance = Money.Zero(currency.Trim());
      AccountNumber = accountNumber.Trim();
    }

    public static Account Create(string accountNumber,string moneyCurrecy)
    {
      return new Account(accountNumber: accountNumber, currency: moneyCurrecy);
    }

    /// <summary>
    /// Para yatırma
    /// </summary>
    public void Deposit(Money money)
    {
      Balance += money;
    }

    /// <summary>
    /// Para çekme işlemi
    /// </summary>
    public void WithDraw(Money money)
    {
      Balance -= money;
    }


  }
}
