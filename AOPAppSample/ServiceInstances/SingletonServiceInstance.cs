namespace AOPAppSample.ServiceInstances
{
  public class SingletonServiceInstance
  {
    public Guid Id { get; set; }

    public SingletonServiceInstance()
    {
      Id = Guid.NewGuid();
    }
  }
}
