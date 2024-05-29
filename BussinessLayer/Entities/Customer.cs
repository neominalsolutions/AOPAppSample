using BussinessLayer.SeedWork;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Entities
{
  // Not: Class tanımlarında
  // Data Structure olarak nesneleri tutumayacağız. (Sadece props vardır, Kalıtım ile genişlemezler, genelde veri tutmak amaçlı tercih edilirler)
  // Object tipi ile tanım yapıcaz. (Katılım vari işlemler ile genişlerler, props değerleri ve davranışaları, olayları vardır.)
  public class Customer : Entity
  {
    // Data Members (fields, properties, events, methods (behaviours)) 
    // Code Defensing tekniğini uyguladık
    public string? FirstName { get; init; }
    public string? LastName { get; init; }

    public Account MainAccount { get; init; }

    private readonly List<Account> accounts = new List<Account>();
    public ImmutableList<Account> Accounts => accounts.ToImmutableList();

    public string FullName { get
      {
        return $"{FirstName} {LastName}";  
      }
    }

    Customer(string firstName,string lastName, string accountNumber)
    {
      ArgumentNullException.ThrowIfNull(firstName);
      ArgumentNullException.ThrowIfNull(lastName);
      FirstName = firstName.Trim();
      LastName = lastName.Trim().ToUpper();
      MainAccount = Account.Create(accountNumber, "TL");
    }

    /// <summary>
    /// Yeni bir Hesap Müşterisi oluşturma
    /// Behaviour
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    public static Customer Create(string firstName,string lastName, string accountNumber)
    {
      return new Customer(firstName, lastName, accountNumber);
    }

    /// <summary>
    /// Muüşterinin hesabını kapama işlemi
    /// Müşteri hesabı, müşteri üzerinden kapatılabilidiğinde Customer Entity Account Entity için Information Expert oldu
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <param name="closeReason"></param>
    /// <exception cref="Exception"></exception>
    public void CloseAccount(string accountNumber, string closeReason)
    {
      var account = accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

      if(account is not null)
      {
        account.Close(closeReason);
      }
      else
      {
        throw new Exception("Hesap bulunamdı");
      }
    }

  }
}
