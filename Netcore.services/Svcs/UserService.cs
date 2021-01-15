using Netcore.Data.DataModels;
using Netcore.services.interfaces;
using NetCore.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netcore.services.Svcs
{
    public class UserService : IUser
    {
        #region private methods
        private IEnumerable<User> GetUserInfos() {
            return new List<User>()
                {
                    new User () {
            UserId = "jadejs",
            UserName ="김정수",
            UserEmail = "jadejskim@gmail.com",
            Password = "123456"
                    }

                };
        }

        private bool checkTheUserInfo(string userid, string password) {
            return GetUserInfos().Where(u => u.UserId.Equals(userid) && u.Password.Equals(password)).Any(); 
        }
        #endregion

        bool IUser.MatchTheUserInfo(LoginInfo login) {
            return checkTheUserInfo(login.UserId, login.Password);
        }
    }
}
