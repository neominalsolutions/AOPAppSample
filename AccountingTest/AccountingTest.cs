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
    /// A�a��daki durumda bir exception al�yorsak testen ge�tik
    /// </summary>
    //[Fact]
    // Test methodu parametreli �al���yorsa Theory
    // Test Methoduna InlineData parametrik de�er ge�ebiliriz.
    [Theory]
    [InlineData(1000,500)]
    [InlineData(1000, 5000)]
    [InlineData(10000, 10000)]

    public void BalanceUnSufficientTest(decimal depositAmount,decimal withDrawAmount)
    {
      // Arrange
      // �n Haz�rl�k, Setup i�lemi
      Account acc = Account.Create("324324-3243243-23432432", "TL");
      acc.Deposit(Money.Create(depositAmount, "TL"));


      // Act a�amas� test methodlar�n� tetikleme
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

    // Test Methodu parametresiz �al���yorsa [Fact]
    [Fact]
    public void DailyMoneyTransferLimitWithMoq()
    {
      // Sim�le s�n�flar �zerinden test yapar.
      // Mock<IAccount>(); IAccount imzas�na sahip bir moq nesnesi olu�turulmu� oldu.
      var accountMock = new Mock<IAccount>();

      // Moq i�in nesnenin bir Interface �zerinden t�remesi ve Interface �zeirnde imzalar ile moq tan�m� yap�l�yor. 

      var money  = Money.Create(1000, "TL");
      accountMock.Setup(acm => acm.Balance).Returns(money); // Returns setup sonucu d�nmesi muhtemel de�er

      // accountMock.Object Instance al�nan objeye ula��lan k�s�m.

      // Assert
      Assert.Equal(1000, accountMock.Object.Balance.Amount);


    }
  }
}