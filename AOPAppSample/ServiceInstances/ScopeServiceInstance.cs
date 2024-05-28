namespace AOPAppSample.ServiceInstances
{
  public class ScopeServiceInstance
  {
    public Guid Id { get; set; }

    public ScopeServiceInstance()
    {
      Id = Guid.NewGuid();
    }

  }
}
