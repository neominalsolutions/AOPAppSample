namespace AOPAppSample.ServiceInstances
{
  public class TransientServiceInstance
  {
    public Guid Id { get; set; }

    public TransientServiceInstance()
    {
      Id = Guid.NewGuid();
    }
  }
}
