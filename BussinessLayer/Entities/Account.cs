using BussinessLayer.Exceptions;
using BussinessLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BussinessLayer.Entities
{
  public class Account:Entity, IAccount
  {
    public Money Balance { get;  set; }  // Document Based olarak tutacak isek Embeded Document olarak, Document nesnesi içerisinde tanımlanabilir.
    // RDMS sistemlerde Account_Balance_Amount, Account_Balance_Currency Property ile Account entity üzerinden value Objectleri property olarak saklıyoruz. 
    public string AccountNumber { get; init; }

    public string CloseReason { get; private set; }

    public DateTime? ClosedAt { get; private set; }

    public bool Closed { get; private set; }




    private List<AccountTransaction> transactions = new List<AccountTransaction>();

    // Bu sayede set edilemeyen bir liste tanımı yaptık.
    // sebebi transactionlarda sadece deposit ve withdraw işleminde girilmelidir. 
    public IImmutableList<AccountTransaction> Transactions => transactions.ToImmutableList();
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
    ///
    /// </summary>
    
    // Günlük en fazla 100 TL Hesaba para yatırılabilsin
    
    public void Deposit(Money money)
    {
  
      var dailyTransactionAmounts = this.transactions
        .Where(x => x.TransactionAt.Date == DateTime.Now.Date)
        .Select(a => a.TransactionMoney).ToList();

      // şuanki miktardan başlayarak üzerine eklesin
      var daiyTotalTransactionAmount = money;

      dailyTransactionAmounts.ForEach(transactionMoney =>
      {
        daiyTotalTransactionAmount += transactionMoney;
      });

      if(daiyTotalTransactionAmount > Money.Create(100000,money.Currency))
      {
        throw new DailyTransferLimitException();
      }
      else
      {
        Balance += money;
        var type = TransactionType.Create("Deposit", 200);
        transactions.Add(AccountTransaction.Create(type, money));
      }

    }

    /// <summary>
    /// Para çekme işlemi
    /// </summary>
    public void WithDraw(Money money)
    {
      
      if(money > Balance)
      {
        throw new BalanceUnsuffientException();
      }
      else
      {
        Balance -= money;
        var type = TransactionType.Create("WithDraw", 300);
        transactions.Add(AccountTransaction.Create(type, money));
      }

    }

    public void Close(string closeReason)
    {
      CloseReason = closeReason;
      ClosedAt = DateTime.Now;
      Closed = true;
    }


  }
}
