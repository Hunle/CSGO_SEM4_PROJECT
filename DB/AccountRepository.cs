using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.Entity;

namespace DB
{
    public class AccountRepository : BaseRepository
    {
        public void Save(Account account)
        {
            if (account.Id > 0)
            {
                //its an update, it has an id
                Account existingAccount = Load(account.Id);
                existingAccount.SteamId = account.SteamId;
                existingAccount.Username = account.Username;
                existingAccount.UserStatus = account.UserStatus;
                existingAccount.TradeLink = account.TradeLink;
            }
            else
            {
                context.Accounts.Add(account);
            }
            context.SaveChanges();
        }

        public Account Load(int id)
        {
            //return context.Accounts.Where(x => x.Id == id).FirstOrDefault();
            
            Account Acc = context.Accounts.Find(id);
            return Acc;
        }

        public IEnumerable<Account> LoadAll()
        {

            return context.Accounts;
        }

        public void Delete(int id)
        {
            Account accountToDelete = Load(id);
            context.Accounts.Remove(accountToDelete);
            context.SaveChanges();
        }
    }
}

