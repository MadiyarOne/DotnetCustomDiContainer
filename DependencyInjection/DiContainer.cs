namespace CustomDiContainer.DependencyInjection;

public class DiContainer
{
    private readonly Dictionary<Type, ServiceDescriptor> _descriptors;


    public DiContainer(List<ServiceDescriptor> descriptors)
    {
        _descriptors = descriptors.ToDictionary(descriptor => descriptor.ServiceType);
    }

    public object GetService(Type type)
    {
        var descriptor = _descriptors[ type];

        if (descriptor == null)
            throw new Exception($"Service of type {type.Name} is not registered!");

        if (descriptor.Implementation != null)
            return descriptor.Implementation;

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsAbstract || actualType.IsInterface)
        {
            throw new Exception("can not instantiate abstract classes or interfaces");
        }

        var constructorInfo = actualType.GetConstructors().First();

        var parameters = constructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();
        
        
        var impl = Activator.CreateInstance(actualType, parameters);


        if (descriptor.LifeTime == ServiceLifeTime.Singleton)
        {
            descriptor.Implementation = impl;
        }

        return impl;
    }
    
    public T GetService<T>()
    {
        return (T) GetService(typeof(T));
    }
}