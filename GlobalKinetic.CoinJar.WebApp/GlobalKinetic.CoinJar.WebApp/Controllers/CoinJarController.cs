using GlobalKinetic.CoinJar.Framework;
using GlobalKinetic.CoinJar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GlobalKinetic.CoinJar.WebApp.Controllers
{
    public class CoinJarController : Controller
    {
        public CoinJarController() { }

        #region Action Results
        /*Coin Jar Page*/
        public ActionResult Index()
        {
            using (var bc = new BusinessController())
            {
                //Always reset the coin jar on first page load.
                bc.Reset();

                return View(new CoinJarViewModel(bc.GetCoinJar().TotalVolume));
            }
        }
        #endregion

        #region Json Results
        public JsonResult AddCoinToJar(int? coinTypeID)
        {
            if (coinTypeID == null)
                return Json(new { success = false });

            using (var bc = new BusinessController())
            {
                bc.AddCoin(coinTypeID.Value);
                return Json(new
                {
                    success = true,
                    actualVolume = bc.GetActualVolume(),
                    actualAmmount = bc.GetActualAmount()
                });
            }
        }

        public JsonResult ResetCount()
        {
            using (var bc = new BusinessController())
            {
                bc.Reset();
                return Json(new
                {
                    success = true,
                    actualVolume = bc.GetActualVolume(),
                    actualAmmount = bc.GetActualAmount()
                });
            }
        }
        #endregion
    }
}