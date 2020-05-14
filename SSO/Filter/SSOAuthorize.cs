using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSO.Filter
{
    /// <summary>
    /// .net 身份验证
    /// </summary>
    public class SSOAuthorize:AuthorizeAttribute
    {
        /// <summary>
        /// 重写时，提供一个入口点用于进行自定义授权检查。
        /// </summary>
        /// <param name="httpContext">上下文</param>
        /// <returns></returns>
        protected override bool  AuthorizeCore(HttpContextBase httpContext)
        {
            Hashtable onlines = (Hashtable)httpContext.Application["Online"];
            if (onlines != null)
            {
                var ide = onlines.GetEnumerator();
                while (ide.MoveNext())
                {
                    //说明多次登陆
                    if(ide.Key.ToString() == httpContext.Session.SessionID && ide.Value.ToString()=="-1")
                    {
                        //把这个session对应的用户踢出
                        onlines.Remove(httpContext.Session.SessionID);
                        httpContext.Application.Lock();
                        httpContext.Application["Online"] = onlines;
                        httpContext.Application.UnLock();
                        httpContext.Response.Redirect("/Login/Index?status=-1", true);
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
            return true;
        }
    }

}