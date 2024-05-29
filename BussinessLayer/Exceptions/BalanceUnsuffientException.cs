using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Exceptions
{
  public class BalanceUnsuffientException:Exception
  {
    public BalanceUnsuffientException(string message = "Bakiye Yetersiz"):base(message)
    {

    }
  }
}
