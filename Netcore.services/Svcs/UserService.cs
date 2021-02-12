
using Microsoft.EntityFrameworkCore;
using Netcore.Data.Classes;

//using Netcore.Data.DataModels;
using Netcore.services.interfaces;
using Netcore.services.interfaces.Data;
using NetCore.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Netcore.services.Svcs
{


    public class UserService : IUser
    {

        private DbFirstDbContext _context;

        public UserService(DbFirstDbContext context)
        {
            _context = context;
        }

        #region private methods
        private IEnumerable<User> GetUserInfos() {
            return _context.Users.ToList();
/*            return new List<User>()
                {
                    new User () {
            UserId = "jadejs",
            UserName ="김정수",
            UserEmail = "jadejskim@gmail.com",
            Password = "123456"
                    }

                };
*/
        }

        private User GetUserInfo(string userid, string password) {
            User user;
            user = null;
            //Lambda
            //user = _context.Users.Where(u => u.UserId.Equals(userid) && u.Password.Equals(password)).FirstOrDefault();

            //FromSql

            //Table
            user = _context.Users.FromSql("SELECT UserId, UserName, UserEmail, Password, IsMembershipWidthdrawn, JoinedUtcDate FROM dbo.[User]")
                                             .FirstOrDefault();


            return user;

        }

        private bool checkTheUserInfo(string userid, string password) {
            //return GetUserInfos().Where(u => u.UserId.Equals(userid) && u.Password.Equals(password)).Any();
            return GetUserInfo(userid, password) != null ? true : false;
        }
        #endregion

        bool IUser.MatchTheUserInfo(LoginInfo login) {
            return checkTheUserInfo(login.UserId, login.Password);
        }

    }
}
