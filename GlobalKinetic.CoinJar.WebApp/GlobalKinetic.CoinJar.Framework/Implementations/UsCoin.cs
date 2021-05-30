using GlobalKinetic.CoinJar.Framework.Interfaces;

namespace GlobalKinetic.CoinJar.Framework.Implementations
{
    public abstract class UsCoin : ICoin
    {
        #region Constructor
        public UsCoin(decimal volume, decimal value)
        {
            Volume = new FluidOunces(volume);
            Value = new USCurrency(value);
        }
        #endregion

        #region Public Properties
        public IVolume Volume { get; private set; }
        public ICurrency Value { get; private set; } 
        #endregion
    }
}
