using GlobalKinetic.CoinJar.API.Exceptions;
using GlobalKinetic.CoinJar.Framework.Exceptions;
using GlobalKinetic.CoinJar.Framework.Implementations;
using GlobalKinetic.CoinJar.Framework.Interfaces;
using System.ComponentModel;

namespace GlobalKinetic.CoinJar.Framework.Models
{
    public class CoinJarModel : ICoinJar
    {
        #region Private Fields
        private decimal jarMaxVolume;
        private decimal totalAmount = 0;
        private decimal totalVolume = 0;
        #endregion

        #region Constructor
        public CoinJarModel()
        {
            //Requirement of 42 for the assesment.
            //Change to a lower number quicker test if the Jar is full.
            jarMaxVolume = 42;
        }
        #endregion

        #region Public Properties
        public decimal JarMaxVolume
        {
            get
            {
                return jarMaxVolume;
            }
        }

        public decimal TotalAmount
        {
            get
            {
                return totalAmount;
            }
            set
            {
                totalAmount = value;
            }
        }

        public decimal TotalVolume
        {
            get
            {
                return totalVolume;
            }
            set
            {
                totalVolume = value;
            }
        }
        #endregion

        #region Public Methods
        public void AddCoin(ICoin coin)
        {
            if (coin.GetType().BaseType != typeof(UsCoin))
                throw new InValidCoinException("MyCoinJar accepts only UsCoin");

            if (Context.CoinJarInstance.JarMaxVolume < (Context.CoinJarInstance.TotalVolume + coin.Volume))
                throw new CoinOverFlowException();

            Context.CoinJarInstance.TotalVolume += coin.Volume;
            Context.CoinJarInstance.TotalAmount += coin.Amount;
        }
        public decimal GetTotalAmount() => Context.CoinJarInstance.TotalAmount;

        public decimal GetTotalVolume() => Context.CoinJarInstance.TotalVolume;

        public void Reset()
        {
            Context.CoinJarInstance.TotalVolume = 0;
            Context.CoinJarInstance.TotalAmount = 0;
        }
        #endregion

        #region Public Enums
        public enum CoinTypes
        {
            [Description("Penny")]
            Penny = 1,
            [Description("Nickel")]
            Nickel = 2,
            [Description("Dime")]
            Dime = 3,
            [Description("Quarter")]
            Quarter = 4,
            [Description("Half Dollar")]
            HalfDollar = 5,
            [Description("Dollar")]
            Dollar = 6
        }
        #endregion

    }
}
