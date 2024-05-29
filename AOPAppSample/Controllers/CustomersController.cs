using BussinessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AOPAppSample.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomersController : ControllerBase
  {

    [HttpGet]
    public IActionResult Sample()
    {
      var customer = Customer.Create(firstName:"Ali", lastName: "Tan", accountNumber:"TR 8500 4563 7895 4563 5001");

      customer.CloseAccount("TR 8500 4563 7895 4563 5001", "İş Değişikliği");

      customer.MainAccount.Deposit(Money.Create(10, "TL"));
      customer.MainAccount.WithDraw(Money.Create(5, "TL"));


      string fName =  customer.FullName;

      var money1 =  Money.Zero(currency:"TL");
      money1 += Money.Create(amount:50,currency: "TL");
      money1 -= Money.Create(amount:10, currency: "TL"); // 40 TL

      bool r1 = money1 > Money.Create(amount: 60, currency: "TL"); // false


      return Ok();
    }
  }
}
