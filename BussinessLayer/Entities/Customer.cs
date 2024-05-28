using BussinessLayer.SeedWork;
using System;
using System.Collections.Generic;
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

    public Account Account { get; init; }

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
      Account = Account.Create(accountNumber, "TL");
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

  }
}
