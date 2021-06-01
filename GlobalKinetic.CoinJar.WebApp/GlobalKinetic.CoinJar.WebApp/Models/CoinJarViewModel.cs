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
        public CoinJarViewModel(decimal totalVolume = 0)
        {
            TotalVolume = totalVolume;
            CoinTypes = Enum.GetValues(typeof(CoinTypes))
                            .Cast<CoinTypes>()
                            .ToList();

        }
        #endregion

        #region Public Properties
        public decimal TotalVolume { get; set; }

        public decimal ActualAmount { get; set; }

        public decimal ActualVolume { get; set; }
        public List<CoinTypes> CoinTypes { get; } 
        #endregion
    }
}
