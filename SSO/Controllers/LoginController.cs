using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSO.Controllers
{
    /// <summary>
    /// 登陆
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           if(Request["status"]!=null && Request["status"].ToString() == "-1")
            {
                ViewBag.Message = "账号在别处登陆";
            }
            return View();
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login()
        {
            var account = Request["account"].ToString();
            var password = Request["password"].ToString();
            if(account!=null&&password!=null)
            {
                return RedirectToAction("Register", "RegisterUser",new {account});//登陆成功身份验证
            }
            else
            {
                ViewBag.Message = "用户名或密码错误";
                return View("Index");
            }            
        }



        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult ExitLogin()
        {
            return View();
        }
    }
}