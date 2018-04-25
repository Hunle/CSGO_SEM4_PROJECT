using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DB

    public class BalanceRepositorycs : BaseRepository
{ 
     
    
        public void Save(Balance balance)
        {
            if (balance.Id > 0)
            {
                //its an update, it has an id
                Balance existingBalance = Load(balance.Id);
                existingBalance.Amount = balance.Amount;
                
            }
            else
            {
                context.Balances.Add(balance);
            }
            context.SaveChanges();
        }

        public Balance Load(int id)
        {
            return context.Balances.Where(x => x.Id == id).FirstOrDefault();
            //return context.Developers.FirstOrDefault(x => x.Id == id);
        }

        public List<Balance> LoadAll()
        {
            return context.Balances.ToList();
        }

        public void Delete(int id)
        {
            Balance balanceToDelete = Load(id);
            context.Balances.Remove(balanceToDelete);
            context.SaveChanges();
        }
    }


