using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGO_MVC.Models;
using DB.Arnes_Repo;

namespace CSGO_MVC.Arnes_Repo
{
    public class AccountApplication
    {
        
            UserRepository userRepo = new UserRepository();
            public SteamAccount GetByUsernameAndPassword(SteamAccount steam)
            {
                return userRepo.GetByUsernameAndPassword(steam);
            }
        }
    
}