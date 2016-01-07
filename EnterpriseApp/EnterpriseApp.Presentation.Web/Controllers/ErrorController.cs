using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseApp.Presentation.Web.Controllers
{
    public class ErrorController : Controller
    {

        // GET: Error
        [AllowAnonymous]
        public ActionResult Index()
        {
            string viewName = "~/Views/Error/Index.cshtml";

            Response.ContentType = "text/html";
            Response.StatusCode = 400;

            HandleErrorInfo errorViewModel = null;

            try
            {
                if (this.RouteData.DataTokens.ContainsKey("errorViewModel"))
                {
                    errorViewModel = this.RouteData.DataTokens["errorViewModel"] as HandleErrorInfo;
                }
                else
                {
                    errorViewModel = new HandleErrorInfo(new Exception("bilinmeyen hata"), "Error", "Index");
                }

                ILog Logger = LogManager.GetLogger(errorViewModel.ControllerName + "." + errorViewModel.ActionName);
                Logger.Error(errorViewModel.Exception.Message);
            }
            catch (Exception e)
            {
                errorViewModel = new HandleErrorInfo(e, "Error", "Index");
            }

            return View(viewName, errorViewModel);
        }

        [AllowAnonymous]
        public ActionResult _401()
        {
            string viewName = "~/Views/Error/_401.cshtml";

            Response.ContentType = "text/html";
            Response.StatusCode = 401;

            HandleErrorInfo errorViewModel = null;

            try
            {
                if (this.RouteData.DataTokens.ContainsKey("errorViewModel"))
                {
                    errorViewModel = this.RouteData.DataTokens["errorViewModel"] as HandleErrorInfo;
                }
                else
                {
                    errorViewModel = new HandleErrorInfo(new Exception("bilinmeyen hata"), "Error", "_401");
                }

                ILog Logger = LogManager.GetLogger(errorViewModel.ControllerName + "." + errorViewModel.ActionName);
                Logger.Error(errorViewModel.Exception.Message);
            }
            catch (Exception e)
            {
                errorViewModel = new HandleErrorInfo(e, "Error", "_401");
            }

            return View(viewName, errorViewModel);
        }

        [AllowAnonymous]
        public ActionResult _403()
        {
            string viewName = "~/Views/Error/_403.cshtml";

            Response.ContentType = "text/html";
            Response.StatusCode = 403;

            HandleErrorInfo errorViewModel = null;

            try
            {
                if (this.RouteData.DataTokens.ContainsKey("errorViewModel"))
                {
                    errorViewModel = this.RouteData.DataTokens["errorViewModel"] as HandleErrorInfo;
                }
                else
                {
                    errorViewModel = new HandleErrorInfo(new Exception("bilinmeyen hata"), "Error", "_403");
                }

                ILog Logger = LogManager.GetLogger(errorViewModel.ControllerName + "." + errorViewModel.ActionName);
                Logger.Error(errorViewModel.Exception.Message);
            }
            catch (Exception e)
            {
                errorViewModel = new HandleErrorInfo(e, "Error", "_403");
            }

            return View(viewName, errorViewModel);

        }

        [AllowAnonymous]
        public ActionResult _404()
        {
            string viewName = "~/Views/Error/_404.cshtml";

            Response.ContentType = "text/html";
            Response.StatusCode = 404;

            HandleErrorInfo errorViewModel = null;

            try
            {
                if (this.RouteData.DataTokens.ContainsKey("errorViewModel"))
                {
                    errorViewModel = this.RouteData.DataTokens["errorViewModel"] as HandleErrorInfo;
                }
                else
                {
                    errorViewModel = new HandleErrorInfo(new Exception("bilinmeyen hata"), "Error", "_404");
                }

                ILog Logger = LogManager.GetLogger(errorViewModel.ControllerName + "." + errorViewModel.ActionName);
                Logger.Error(errorViewModel.Exception.Message);
            }
            catch (Exception e)
            {
                errorViewModel = new HandleErrorInfo(e, "Error", "_404");
            }

            return View(viewName, errorViewModel);
        }



    }
}