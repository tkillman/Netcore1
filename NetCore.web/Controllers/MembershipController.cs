using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Netcore.Data.DataModels;
using Netcore.services.Svcs;
using Netcore.services.interfaces;
using NetCore.web.Models;
using NetCore.Data.ViewModels;

namespace NetCore.web.Controllers
{
    public class MembershipController : Controller
    {
        private IUser _user;

        public MembershipController(IUser iuser) {
            _user = iuser;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginInfo login)
        {
            // 종속성
            // Data => Service => Web

            string message = String.Empty;
            if (ModelState.IsValid)
            {
                //string userId = "jadejs";
                //string password = "123456";
                
                //서비스 개념
                // 서비스의 재사용성, 모듈화
                if (_user.MatchTheUserInfo(login))
                {
                    TempData["Message"] = "로그인이 성공적으로 이루어졌습니다.";
                    return RedirectToAction("Index", "Membership");
                }
                else {
                    message = "로그인되지 않았습니다.";
                }
            }
            else {
                message = "로그인 정보를 올바르게 입력하세요.";
            }

            ModelState.AddModelError(string.Empty, message);
            return View(login);
        }
    }
}