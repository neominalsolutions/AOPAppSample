using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.SeedWork
{
  /// <summary>
  /// Tüm entityler buradan türesin
  /// </summary>
  public abstract class Entity
  {
    public Guid Id { get; init; }

    public int? SequenceNo { get; init; }

    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Id GUID
    /// CreateAt
    /// </summary>
    public Entity()
    {
      Id = Guid.NewGuid();
      CreatedAt = DateTime.Now;
    }

    /// <summary>
    /// Id GUID
    /// CreateAt Date
    /// SequenNumber Int
    /// </summary>
    public Entity(int sequenceNumber)
    {
      Id = Guid.NewGuid();
      CreatedAt = DateTime.Now;
      SequenceNo = sequenceNumber;
    }
  }
}
