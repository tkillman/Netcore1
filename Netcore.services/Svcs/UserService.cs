
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
            //Lambda
            //user = _context.Users.Where(u => u.UserId.Equals(userid) && u.Password.Equals(password)).FirstOrDefault();

            //FromSql

            //Table
            //user = _context.Users.FromSql("SELECT UserId, UserName, UserEmail, Password, IsMembershipWidthdrawn, JoinedUtcDate FROM dbo.[User]").FirstOrDefault();
            ////View
            //user = _context.Users.FromSql("SELECT UserId, UserName, UserEmail, Password, IsMembershipWidthdrawn, JoinedUtcDate FROM dbo.uvwUser")
            //                    .Where(u => u.UserId.Equals(userid) && u.Password.Equals(password)).FirstOrDefault();

            //Function
            //user = _context.Users.FromSql($"SELECT UserId, UserName, UserEmail, Password, IsMembershipWidthdrawn, JoinedUtcDate FROM dbo.ufnUser{userid}, {password}")
            //                    .FirstOrDefault();

            //Stored Procedure
            // stored Procedure의 인자값은 strling만 가능하다. int count = 1; count.Tostring() 를 인자로 줘야한다.
            user = _context.Users.FromSql("dbo.uspCheckLoginByUserId @p0, @p1", new [] {userid, password}).FirstOrDefault();


            if (user == null) {
                //int rowAffected = _context.Database.ExecuteSqlCommand($"Update dbo.[User] SET AccessFailedCount += 1 WHERE UserId= {userid}");

                int rowAffected = _context.Database.ExecuteSqlCommand("dbo.FailedLoginByUserId @p0", parameters : new[] { userid });
            }
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
