using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Entities
{
  /// <summary>
  /// Record Nesnesi C# 9.0 ve sonrasında gelen bir özellik. Value Object tanımı için kullanılır. Immutable bir type'dır. 
  /// Sadece value değerlerden oluşur, bir ID gibi kimlik alanına ihtiyaç duymaz.
  /// </summary>
  public record Money
  {
    public string Currency { get; init; } // para birimi
    public decimal Amount { get; init; } // para miktarı


    Money(decimal amount,string currency)
    {
      Amount = amount;
      Currency = currency;
    }

    public static Money Zero(string currency)
    {
      return new Money(0, currency);
    }

    public static Money Create(decimal amount,string currency)
    {
      return new Money(amount, currency);
    }

    public override string ToString() => $"{Amount} {Currency}"; // 100 TL

    /// <summary>
    /// Paranın üzerinden bir miktar para eklendiği durum
    /// </summary>
    /// <param name="obj1">Anapara</param>
    /// <param name="obj2">Çıkarılacak olan Miktar</param>
    /// <returns></returns>
    public static Money operator +(Money obj1, Money obj2)
    {
      return new Money(obj1.Amount + obj2.Amount, obj1.Currency);
    }

    /// <summary>
    /// paranın üzerinden bir miktar paranın çıkarıldığı durum
    /// </summary>
    /// <param name="obj1">Anapara</param>
    /// <param name="obj2">Çıkarılacak olan Miktar </param>
    /// <returns></returns>
    public static Money operator -(Money obj1, Money obj2)
    {
      return new Money(obj1.Amount - obj2.Amount, obj1.Currency);
    }


    /// <summary>
    /// İki para değerini value üzerinden kıyasalama işlemi
    /// </summary>
    /// <param name="obj1">Money 1</param>
    /// <param name="obj2">Money 2</param>
    /// <returns></returns>
    public static bool operator <(Money obj1, Money obj2)
    {

      return obj1.Amount < obj2.Amount && obj1.Currency == obj2.Currency;
    }

    public static bool operator >(Money obj1, Money obj2)
    {

      return obj1.Amount > obj2.Amount && obj1.Currency == obj2.Currency;
    }


    public static bool operator <=(Money obj1, Money obj2)
    {

      return obj1.Amount < obj2.Amount && obj1.Currency == obj2.Currency;
    }

    public static bool operator >=(Money obj1, Money obj2)
    {

      return obj1.Amount > obj2.Amount && obj1.Currency == obj2.Currency;
    }

  }
}
