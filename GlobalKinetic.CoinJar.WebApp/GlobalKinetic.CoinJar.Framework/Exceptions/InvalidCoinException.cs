using System;

namespace GlobalKinetic.CoinJar.API.Exceptions
{
    public class InValidCoinException : Exception
    {
        #region Constructor
        public InValidCoinException(string message)
            : base(message)
        {
        } 
        #endregion
    }
}
