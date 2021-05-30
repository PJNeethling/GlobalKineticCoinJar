using GlobalKinetic.CoinJar.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using static GlobalKinetic.CoinJar.Framework.Models.CoinJarModel;

namespace GlobalKinetic.CoinJar.WebApp.Models
{
    public class CoinJarViewModel
    {
        #region Constructor
        public CoinJarViewModel(IVolume totalVolume = null)
        {
            TotalVolume = totalVolume;
            CoinTypes = Enum.GetValues(typeof(CoinTypes))
                            .Cast<CoinTypes>()
                            .ToList();

        }
        #endregion

        #region Public Properties
        public IVolume TotalVolume { get; set; }

        public ICurrency ActualAmount { get; set; }

        public IVolume ActualVolume { get; set; }
        public List<CoinTypes> CoinTypes { get; } 
        #endregion
    }
}
