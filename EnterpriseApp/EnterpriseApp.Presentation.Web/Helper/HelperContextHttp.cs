using EnterpriseApp.Domain.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;

namespace EnterpriseApp.Presentation.Web.Helper
{
    public class HelperContextHttp : IHelperContext
    {

        public HelperContextHttp()
        {

        }

        public string GetIP()
        {
            string result = "";

            try
            {
                if (HttpContext.Current != null)
                {

                    result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                    if (!string.IsNullOrEmpty(result))
                    {
                        string[] addresses = result.Split(',');
                        if (addresses.Length != 0)
                        {
                            result = addresses[0];
                        }
                    }
                    else
                    {
                        result =
                            HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]
                            + ":"
                            + HttpContext.Current.Request.ServerVariables["REMOTE_PORT"];
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public string GetUserId()
        {
            string result = "0";
            try
            {
                result = HttpContext.Current.User.Identity.IsAuthenticated
                    ? HttpContext.Current.User.Identity.GetUserId() : "0";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public string GetUserName()
        {
            string result = "0";
            try
            {
                result = HttpContext.Current.User.Identity.IsAuthenticated
                    ? HttpContext.Current.User.Identity.GetUserName() : "0";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public IPrincipal GetUser()
        {
            throw new NotImplementedException();
        }

        public string GetSiteBaseFullUrl()
        {
            string result = "~/";
            try
            {
                result = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
                         HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }

        public string GetSiteServerMapPath()
        {
            string result = "~/";
            try
            {
                result = HttpContext.Current.Server.MapPath("~/");
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }

}