using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Hastane.Attribute
{
    public class LoglamaAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DataModel.Log yeniLog = new DataModel.Log();

            var cerez = filterContext.HttpContext.Request.Cookies;

            yeniLog.MetotAdi = filterContext.ActionDescriptor.ActionName;
            yeniLog.IP = filterContext.HttpContext.Request.UserHostAddress;
            yeniLog.Tarayici = filterContext.HttpContext.Request.Browser.Browser;
            if (filterContext.ActionParameters.Count>0)
            {
                JavaScriptSerializer seri = new JavaScriptSerializer();
                yeniLog.Parametre = seri.Serialize(filterContext.ActionParameters);
            }
            //yeniLog.Parametre = filterContext.ActionParameters.ToString();
            yeniLog.Tarih = DateTime.Now;

            DataModel.HastaneModel model = new DataModel.HastaneModel();
            model.Log.Add(yeniLog);
            model.SaveChanges();
        }
    }
}