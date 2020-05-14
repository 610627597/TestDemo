using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSO.Controllers
{
    public class RegisterUserController : Controller
    {
        /// <summary>
        /// 登陆身份验证
        /// </summary>
        /// <returns></returns>
        public ActionResult Register(string account)
        {
            HttpContext httpContext = System.Web.HttpContext.Current;
            Hashtable userOnline =(Hashtable)HttpContext.Application["Online"];
            if (userOnline != null)
            {
                var ide = userOnline.GetEnumerator();
                while (ide.MoveNext())
                {
                    if(ide.Value!=null && ide.Value.ToString() == account)
                    {
                        userOnline[ide.Key] = "-1";
                        break;
                    }
                }
            }
            else
            {
                userOnline = new Hashtable();
            }
            userOnline[Session.SessionID] = account;
            httpContext.Application.Lock();
            httpContext.Application["Online"] = userOnline;
            httpContext.Application.UnLock();

            return RedirectToAction("Index", "Home");
        }
    }
}