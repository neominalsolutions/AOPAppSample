using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Entities
{
  /// <summary>
  /// Para Giriş Çıkış işlemleri burada tutulsun
  /// </summary>
  public class AccountTransaction
  {
    public TransactionType Type { get; init; }
    public DateTime TransactionAt { get; init; }
    public Money TransactionMoney { get; set; }

    AccountTransaction(TransactionType transactionType, Money money)
    {
      TransactionAt = DateTime.Now;
      Type = transactionType;
      TransactionMoney = Money.Create(money.Amount, money.Currency);
    }

    public static AccountTransaction Create(TransactionType transactionType, Money money)
    {
      return new AccountTransaction(transactionType, money);
    }

  }
}
