using EnumsNET;
using GlobalKinetic.CoinJar.API.Exceptions;
using GlobalKinetic.CoinJar.Framework;
using GlobalKinetic.CoinJar.Framework.Exceptions;
using GlobalKinetic.CoinJar.Framework.Interfaces;
using GlobalKinetic.CoinJar.Framework.Models;
using Microsoft.AspNetCore.Mvc;
using static GlobalKinetic.CoinJar.Framework.Models.CoinJarModel;

namespace GlobalKinetic.CoinJar.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/CoinJar")]
    public class CoinJarApiController : Controller
    {
        #region Private Fields
        CoinJarModel _coinJar = Context.CoinJarInstance;
        #endregion

        #region Public Methods
        #region Coin Jar
        [Route("~/api/GetCoinJar")]
        [HttpGet]
        public ICoinJar GetCoinJar()
        {
            using (var bc = new BusinessController())
                return bc.GetCoinJar();
        }

        [Route("~/api/ResetCoinJar")]
        [HttpPost]
        public string ResetCoinJar()
        {
            using (var bc = new BusinessController())
                bc.Reset();

            return "Coin jar have ben cleared out.";
        }

        [Route("~/api/AddCoinJar")]
        [HttpPost]
        public IActionResult ResetCoinJar(int coinTypeID)
        {
            try
            {
                using (var bc = new BusinessController())
                    bc.AddCoin(coinTypeID);

                var coinName = ((CoinTypes)coinTypeID).AsString(EnumFormat.Description);

                return Ok(new
                {
                    message = $"A {coinName} has been added to Jar."
                });
            }
            catch (CoinOverFlowException coinOverFlowException)
            {
                return BadRequest(new
                {
                    errorMessage = $"Seomething went wrong: {coinOverFlowException.Message}"
                });
            }
            catch (InValidCoinException invaidCoinException)
            {
                return BadRequest(new
                {
                    errorMessage = $"Seomething went wrong: {invaidCoinException.Message}"
                });
            }  
            #endregion
            #endregion
        }
}
}