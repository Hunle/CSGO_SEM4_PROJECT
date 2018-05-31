using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSGO_MVC.Models
{
    public class SteamAccount
    {
        [Key]
        public int Id { get; set; }

        public long SteamId { get; set; }

        public Balance accountbalance { get; set; }

        //[Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }

        public bool UserStatus { get; set; }

        public string TradeLink { get; set; }

        public List<Skin> AccountSkins { get; set; }

 

        public SteamAccount()
        {
            AccountSkins = new List<Skin>();
            //nødt til at lave mock data.
            AccountSkins.Add(new Skin
            {
                SkinName = "AK47 | Neon Revolution",
                Price = 100,
                SkinState = "Factory New"
            });
            AccountSkins.Add(new Skin
            {
                SkinName = "AWP | Fever Dream",
                Price = 10,
                SkinState = "Minimal wear"
            });
            AccountSkins.Add(new Skin
            {
                SkinName = "M4A4 | Desolate Space StatTrack",
                Price = 50,
                SkinState = "Field Tested"
            });
            Balance accountbalance = new Balance(AccountSkins.Sum(Skin => Skin.Price));
            this.accountbalance = accountbalance;
        }
    }
}
