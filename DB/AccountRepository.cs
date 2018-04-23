using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DB
{
    class AccountRepository : BaseRepository
    {
        public void Save(Account account)
        {
            if (account.Id > 0)
            {
                //its an update, it has an id
                Account existingAccount = Load(account.Id);
                existingAccount.SteamId = account.SteamId;
                existingAccount.Name = account.Name;
                existingAccount.Status = account.Status;
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
            return context.Accounts.Where(x => x.Id == id).FirstOrDefault();
            //return context.Developers.FirstOrDefault(x => x.Id == id);
        }

        public List<Account> LoadAll()
        {
            return context.Accounts.ToList();
        }

        public void Delete(int id)
        {
            Account accountToDelete = Load(id);
            context.Accounts.Remove(accountToDelete);
            context.SaveChanges();
        }
    }
}

