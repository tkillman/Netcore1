using NetCore.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.services.interfaces
{
    public interface IUser
    {
        bool MatchTheUserInfo(LoginInfo login);
    }
}
