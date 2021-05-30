using GlobalKinetic.CoinJar.Framework.Interfaces;

namespace GlobalKinetic.CoinJar.Framework.Implementations
{
    public class FluidOunces : IVolume
    {
        #region Constructor
        public FluidOunces(decimal volume = 0)
        {
            Unit = volume;
        }
        #endregion

        #region Public Properties
        public decimal Unit { get; set; }

        #endregion    
    }
}
