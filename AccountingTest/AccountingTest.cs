using BussinessLayer.Entities;
using BussinessLayer.Exceptions;
using BussinessLayer.SeedWork;
using Moq;
using System.Security.Principal;
using Xunit;

namespace AccountingTest
{
  public class AccountingTest
  {
    /// <summary>
    /// Aþaðýdaki durumda bir exception alýyorsak testen geçtik
    /// </summary>
    //[Fact]
    // Test methodu parametreli çalýþýyorsa Theory
    // Test Methoduna InlineData parametrik deðer geçebiliriz.
    [Theory]
    [InlineData(1000,500)]
    [InlineData(1000, 5000)]
    [InlineData(10000, 10000)]

    public void BalanceUnSufficientTest(decimal depositAmount,decimal withDrawAmount)
    {
      // Arrange
      // Ön Hazýrlýk, Setup iþlemi
      Account acc = Account.Create("324324-3243243-23432432", "TL");
      acc.Deposit(Money.Create(depositAmount, "TL"));


      // Act aþamasý test methodlarýný tetikleme
      Action testAction = () => acc.WithDraw(Money.Create(withDrawAmount, "TL"));

      // Assert
      // sonucu test etme
      Assert.ThrowsAny<BalanceUnsuffientException>(testAction);

    }

    [Fact]
    public void DailyMoneyTransferLimit()
    {
      Account account = Account.Create("324324-3243243-23432432", "TL");

      account.Deposit(Money.Create(1000, "TL"));
      account.Deposit(Money.Create(10000, "TL"));
      account.Deposit(Money.Create(15000, "TL"));


      // Assert
      Assert.Equal(26000, account.Balance.Amount);


    }

    // Test Methodu parametresiz çalýþýyorsa [Fact]
    [Fact]
    public void DailyMoneyTransferLimitWithMoq()
    {
      // Simüle sýnýflar üzerinden test yapar.
      // Mock<IAccount>(); IAccount imzasýna sahip bir moq nesnesi oluþturulmuþ oldu.
      var accountMock = new Mock<IAccount>();

      // Moq için nesnenin bir Interface üzerinden türemesi ve Interface üzeirnde imzalar ile moq tanýmý yapýlýyor. 

      var money  = Money.Create(1000, "TL");
      accountMock.Setup(acm => acm.Balance).Returns(money); // Returns setup sonucu dönmesi muhtemel deðer

      // accountMock.Object Instance alýnan objeye ulaþýlan kýsým.

      // Assert
      Assert.Equal(1000, accountMock.Object.Balance.Amount);


    }
  }
}