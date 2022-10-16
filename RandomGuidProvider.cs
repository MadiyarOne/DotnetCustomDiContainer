namespace CustomDiContainer;


class RandomGuidProvider : IRandomGuidProvider
{
    public Guid RandomGuid => Guid.NewGuid();
}