using EnumsNET;
using GlobalKinetic.CoinJar.Framework;
using GlobalKinetic.CoinJar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using static GlobalKinetic.CoinJar.Framework.Models.CoinJarModel;

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
                //This can be taken out, but then the coin jar will only be cleared using the reset method or restarting the app.
                bc.Reset();

                //If I were to implement the other methods on the interface, I would have used them here. (GetJarMaxVolume())
                //Instead of below Context.CoinJarInstance.JarMaxVolume, i would use bc.GetJarMaxVolume()
                return View(new CoinJarViewModel(Context.CoinJarInstance.JarMaxVolume));
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
                try
                {
                    bc.AddCoin(coinTypeID.Value);
                    var coinName = ((CoinTypes)coinTypeID).AsString(EnumFormat.Description);
                    return Json(new
                    {
                        success = true,
                        message = $"{coinName} added successfully.",
                        actualVolume = bc.GetTotalVolume(),
                        actualAmmount = bc.GetTotalAmount()
                    });
                }
                catch (Exception ex)
                {
                    return Json(new
                    {
                        success = false,
                        message = $"Coin add failed: {ex.Message} ",
                        actualVolume = bc.GetTotalVolume(),
                        actualAmmount = bc.GetTotalAmount()
                    });
                }
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
                    message = "Coin jar has been cleared.",
                    actualVolume = bc.GetTotalVolume(),
                    actualAmmount = bc.GetTotalAmount()
                });
            }
        }
        #endregion
    }
}