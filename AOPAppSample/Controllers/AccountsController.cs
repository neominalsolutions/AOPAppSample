using BussinessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AOPAppSample.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AccountsController : ControllerBase
  {

    [HttpGet]
    public IActionResult Test()
    {

      // var address = new ShipAddress();
      // address.getCountry().getCity().setCityName('Ankara'); // Law of Demetter yasasına göre ayrıcı bir geliştirme şekli
      // address.country.city.street = 'Anadolu kavağı'; // Law of Demeter yasasına uygun olmayan bir geliştirme örneği
      // address.setCityName('Ankara');

      var account = Account.Create("4589-4512-2121-4569", "TL");
      account.Deposit(Money.Create(1000, "TL"));
      account.Deposit(Money.Create(10000, "TL"));
      account.Deposit(Money.Create(15000, "TL"));
      account.Deposit(Money.Create(80000, "TL"));

      account.WithDraw(Money.Create(50000, "TL"));

      // 26000 yatırdık 20000 çektik 6000 hesapta para kalmalı
      // 4 tane Account Transaction tablosunda kayıt olmalıdır

      return Ok(account);
    }
  }
}
