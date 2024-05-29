using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Exceptions
{
  public class DailyTransferLimitException:Exception
  {
    public DailyTransferLimitException(string message = "Günlük para çekme limitini aştınız"):base(message)
    {

    }
  }
}
