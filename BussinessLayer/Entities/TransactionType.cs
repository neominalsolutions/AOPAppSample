using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Entities
{
  // Enum yerine Nesne olarak tuttuk.
  public record TransactionType
  {
    public string Key { get; init; }
    public int Value { get; init; }

    TransactionType(string key,int value)
    {
      Key = key;
      Value = value;
    }
    public static TransactionType Create(string key,int value)
    {
      return new TransactionType(key, value);
    }

  }
}
