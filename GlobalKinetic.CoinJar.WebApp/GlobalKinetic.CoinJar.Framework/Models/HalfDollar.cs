using GlobalKinetic.CoinJar.Framework.Implementations;

namespace GlobalKinetic.CoinJar.Framework.Models
{
    public class HalfDollar : UsCoin
    {
        #region Constructor
        //Source for the coins is Wikipedia: https://en.wikipedia.org/wiki/Coins_of_the_United_States_dollar
        //Source to convert the  grams to fluid ounces is Metric Calculator: https://metric-calculator.com/convert-g-to-fl-oz.htm
        public HalfDollar() : base((decimal)0.0534, (decimal)0.5) { } //Fluid Ounches is rounded to 4 decimals.
        #endregion
    }
}
