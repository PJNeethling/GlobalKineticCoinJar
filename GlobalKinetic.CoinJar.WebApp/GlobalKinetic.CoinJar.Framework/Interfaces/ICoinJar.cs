namespace GlobalKinetic.CoinJar.Framework.Interfaces
{
    public interface ICoinJar
    {
        IVolume TotalVolume { get; }
        ICurrency ActualAmount { get; }
        IVolume ActualVolume { get; }
        void AddCoin(ICoin coin);
        void Reset();
    }
}
