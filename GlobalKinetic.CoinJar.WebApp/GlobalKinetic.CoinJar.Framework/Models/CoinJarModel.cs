using GlobalKinetic.CoinJar.API.Exceptions;
using GlobalKinetic.CoinJar.Framework.Exceptions;
using GlobalKinetic.CoinJar.Framework.Implementations;
using GlobalKinetic.CoinJar.Framework.Interfaces;

namespace GlobalKinetic.CoinJar.Framework.Models
{
    public class CoinJarModel : ICoinJar
    {
        #region Private Fields
        private FluidOunces totalVolume;
        private ICurrency actualAmount;
        private IVolume actualVolume; 
        #endregion

        #region Constructor
        public CoinJarModel()
        {
            totalVolume = new FluidOunces(42);
            actualAmount = new USCurrency();
            actualVolume = new FluidOunces();
        }
        #endregion

        #region Public Properties
        public IVolume TotalVolume
        {
            get
            {
                return totalVolume;
            }
        }

        public ICurrency ActualAmount
        {
            get
            {
                return actualAmount;
            }
            set
            {
                actualAmount = value;
            }
        }

        public IVolume ActualVolume
        {
            get
            {
                return actualVolume;
            }
            set
            {
                actualVolume = value;
            }
        } 
        #endregion

        #region Public Methods
        public void AddCoin(ICoin coin)
        {
            if (coin.GetType().BaseType != typeof(UsCoin))
                throw new InValidCoinException("MyCoinJar accepts only UsCoin");

            if (Context.CoinJarInstance.TotalVolume.Unit < (Context.CoinJarInstance.ActualVolume.Unit + coin.Volume.Unit))
                throw new CoinOverFlowException();

            Context.CoinJarInstance.ActualVolume.Unit += coin.Volume.Unit;
            Context.CoinJarInstance.ActualAmount.UnitPrice += coin.Value.UnitPrice;
        }

        public void Reset()
        {
            Context.CoinJarInstance.ActualVolume = new FluidOunces();
            Context.CoinJarInstance.ActualAmount = new USCurrency();
        }
        #endregion

        #region Public Enums
        public enum CoinTypes
        {
            Penny = 1,
            Nickel = 2,
            Dime = 3,
            Quarter = 4,
            HalfDollar = 5,
            Dollar = 6
        } 
        #endregion

    }
}
