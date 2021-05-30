using System;

namespace GlobalKinetic.CoinJar.Framework.Exceptions
{
    public class CoinOverFlowException : Exception
    {
        #region Constructor
        public CoinOverFlowException()
            : base("Coins overflowed the jar")
        {
        } 
        #endregion
    }
}
