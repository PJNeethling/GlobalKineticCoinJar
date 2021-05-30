namespace GlobalKinetic.CoinJar.Framework.Interfaces
{
    public interface ICoin
    {
        ICurrency Value { get; }
        IVolume Volume { get; }
    }
}
