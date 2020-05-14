using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SSO
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //注意不加上这段代码 session 会在上下文获取不一致 Register 控制器sessionId 与authorize过滤器 sessionId 不一致
        /// <summary>
        /// 会话开始时执行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }

        /// <summary>
        /// 会话结束或过期时执行。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_End(object sender, EventArgs e)
        {
            Hashtable userOnLine = (Hashtable)Application["Online"];
            if (userOnLine != null)
            {
                if (userOnLine[Session.SessionID] != null)
                {
                    userOnLine.Remove(Session.SessionID);
                    Application.Lock();
                    Application["Online"] = userOnLine;
                    Application.UnLock();
                }
            }
        }
    }
}
