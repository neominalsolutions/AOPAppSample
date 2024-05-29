using BussinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.SeedWork
{
  public interface IAccount
  {
     Money Balance { get; set; }
     void Deposit(Money money);
  }
}
