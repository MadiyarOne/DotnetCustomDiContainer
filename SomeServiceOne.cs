namespace CustomDiContainer;

public class SomeServiceOne : ISomeService
{
    private readonly IRandomGuidProvider _provider;

    public SomeServiceOne(IRandomGuidProvider provider)
    {
        _provider = provider;
    }

    public void PrintSomething()
    {
        Console.WriteLine(_provider.RandomGuid);
    }
}