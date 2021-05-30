using GlobalKinetic.CoinJar.Framework.Interfaces;

namespace GlobalKinetic.CoinJar.Framework.Implementations
{
    public class USCurrency : ICurrency
    {
        #region Constructor
        public USCurrency(decimal value = 0)
        {
            UnitPrice = value;
        }
        #endregion
        #region Public Properties
        public decimal UnitPrice { get; set; }

        #endregion    
    }
}
