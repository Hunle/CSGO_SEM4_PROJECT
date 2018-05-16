using CSGO_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace CSGO_MVC.Arnes_Repo
{
    public class UserRepository
    {
        SteamAccountContext context = new SteamAccountContext();
        public SteamAccount GetByUsernameAndPassword(SteamAccount steam)
        {
            return context.Accounts.Where(u => u.UserName == steam.UserName & u.Password == steam.Password).FirstOrDefault();
        }
    }
}