

using CustomDiContainer;
using CustomDiContainer.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        var services = new DiServiceCollection();

        // services.RegisterSingleton<RandomGuidGenerator>();
        // services.RegisterSingleton<RandomGuidGenerator>();
        
        services.RegisterTransient<ISomeService, SomeServiceOne>();
        services.RegisterTransient<IRandomGuidProvider,RandomGuidProvider >();
        
        DiContainer container = services.GenerateContainer();

        var someService1 = container.GetService<ISomeService>();
        var someService2 = container.GetService<ISomeService>();
        
        someService1.PrintSomething();
        someService2.PrintSomething();
    }
}