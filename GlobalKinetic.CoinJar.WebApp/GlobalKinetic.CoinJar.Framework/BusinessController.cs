using GlobalKinetic.CoinJar.Framework.Interfaces;
using GlobalKinetic.CoinJar.Framework.Models;
using System;
using static GlobalKinetic.CoinJar.Framework.Models.CoinJarModel;

namespace GlobalKinetic.CoinJar.Framework
{
    public class BusinessController : IDisposable
    {
        private readonly ICoinJar _coinJar;

        #region Constructor
        public BusinessController()
        {
            if (Context.CoinJarInstance == null)
                _coinJar = new CoinJarModel();
            else
                _coinJar = Context.CoinJarInstance;
        }
        #endregion

        #region Public Methods
        public void AddCoin(int coinTypeID)
        {
            ICoin coin = null;

            //Determine which coin type has been selected 
            switch (coinTypeID)
            {
                case (int)CoinTypes.Penny:
                    {
                        coin = new Penny();
                        break;
                    }
                case (int)CoinTypes.Nickel:
                    {
                        coin = new Nickel();
                        break;
                    }
                case (int)CoinTypes.Dime:
                    {
                        coin = new Dime();
                        break;
                    }
                case (int)CoinTypes.Quarter:
                    {
                        coin = new Quarter();
                        break;
                    }
                case (int)CoinTypes.HalfDollar:
                    {
                        coin = new HalfDollar();
                        break;
                    }
                case (int)CoinTypes.Dollar:
                    {
                        coin = new Dollar();
                        break;
                    }
                default: break;
            }

            if (coin != null)
                _coinJar.AddCoin(coin);
        }

        public ICoinJar GetCoinJar() => _coinJar;
        public decimal GetJarMaxVolume() => Context.CoinJarInstance.JarMaxVolume; //If I were to implement the other methods on the interface, I would have used them here. (GetJarMaxVolume())
        public decimal GetTotalAmount() => _coinJar.GetTotalAmount();
        public decimal GetTotalVolume() => Context.CoinJarInstance.TotalVolume; //If I were to implement the other methods on the interface, I would have used them here. (GetTotalVolume())
        public void Reset() => _coinJar.Reset();
        #endregion


        #region IDisposable Members
        public void Dispose()
        {
            //If we were worked with databases in this class, this Dispose method would be used to dispose the data access.
        }
        #endregion
    }
}
