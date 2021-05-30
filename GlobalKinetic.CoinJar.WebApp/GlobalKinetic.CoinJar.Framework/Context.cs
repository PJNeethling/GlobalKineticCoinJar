using GlobalKinetic.CoinJar.Framework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlobalKinetic.CoinJar.Framework
{
    public static class Context
    {
        #region Private Fields
        static CoinJarModel _coinJarInstance;
        #endregion

        #region Public Properties
        public static CoinJarModel CoinJarInstance
        {
            get
            {
                if (_coinJarInstance == null)
                    _coinJarInstance = new CoinJarModel();
                
                return _coinJarInstance;
            }
            set
            {
                _coinJarInstance = value;
            }
        }
        #endregion
    }
}
