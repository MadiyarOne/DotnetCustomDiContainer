namespace CustomDiContainer.DependencyInjection;

public class DiServiceCollection
{
    private List<ServiceDescriptor> _descriptors = new();


    public void RegisterSingleton<TService>()
    {
        _descriptors.Add(new ServiceDescriptor(typeof(TService),ServiceLifeTime.Singleton));
    }

    public void RegisterSingleton<TService>(TService implementation)
    {
        _descriptors.Add(new ServiceDescriptor(implementation,ServiceLifeTime.Singleton));
    }

    public void RegisterTransient<TService>()
    {
        _descriptors.Add(new ServiceDescriptor(typeof(TService),ServiceLifeTime.Transient));
    }
    
    public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
    {
        _descriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation) ,ServiceLifeTime.Transient));
    }
    
    public DiContainer GenerateContainer()
    {
        return new DiContainer(_descriptors);
    }


}