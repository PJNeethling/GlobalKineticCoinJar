using GlobalKinetic.CoinJar.Framework.Interfaces;

namespace GlobalKinetic.CoinJar.Framework.Implementations
{
    public abstract class UsCoin : ICoin
    {
        #region Constructor
        public UsCoin(decimal volume, decimal amount)
        {
            Volume = volume;
            Amount = amount;
        }
        #endregion

        #region Public Properties
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
        #endregion
    }
}
