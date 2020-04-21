using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Filters
{
    public class MovieShopExceptionFilter: HandleErrorAttribute
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public override void OnException(ExceptionContext filterContext)
		{
            //          • You need to catch that exception
            //		○ Get the exception details such as exception type
            //		○ Exception message
            //		○ Any inner exception
            //		○ StackTrace
            //		○ Date time when Exception happened
            //		○ For which User exception happened ?
            //		○ URL where the exception happened
            //		○ Browser which user is using when exception happened
            //	•  Log those exception, usually we log them in text files, sometime Database but its rare
            //		○ We can use any popular 3rd party Logging Frameworks to log the exception
            //			§ Nlog
            //			§ SeriLog
            //			§ Log4net
            //		○ Download those from nuget
            //	• Send emails when exception happens to the Development Team
            //Always show a friendly error Page to the user

            var controllerName = (string) filterContext.RouteData.Values["controller"];
            var actionName = (string) filterContext.RouteData.Values["action"];

            // create a Model for HandleErrorInfo, which is already built-in in MVC
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            var dateTimeExceptionHappened = DateTime.Now.TimeOfDay.ToString();
            var stackTrace = filterContext.Exception.StackTrace;
            var exceptionMessage = filterContext.Exception.Message;
            var innerException = filterContext.Exception.InnerException;
            Logger.Info(exceptionMessage);
            filterContext.Result = new ViewResult
            {
                ViewName = View,
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            // Http Status Code 500 should be used when and exception happens
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;


            // Now use NLog to log above details to the Text Files.
            // Sedn out Emails to the Dev Team
            // To send emails in C# Mailkit..download from Nuget
            //https://github.com/jstedfast/MailKit
            //https://nlog-project.org/
            base.OnException(filterContext);
        }
    }
}