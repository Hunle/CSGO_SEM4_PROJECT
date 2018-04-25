using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DB
{
   public  class BetRepository : BaseRepository
    {
       
            public void Save(Bet bet)
            {
                if (bet.Id > 0)
                {
                    //its an update, it has an id
                    Bet existingBet = Load(bet.Id);
                    existingBet.BetValue = bet.BetValue;
                    existingBet.Date = bet.Date;
                    existingBet.Status = bet.Status;
                    existingBet.Max = bet.Max;
                    existingBet.Min = bet.Min;
                }
                else
                {
                    context.Bets.Add(bet);
                }
                context.SaveChanges();
            }

            public Bet Load(int id)
            {
                return context.Bets.Where(x => x.Id == id).FirstOrDefault();
                //return context.Developers.FirstOrDefault(x => x.Id == id);
            }

            public List<Bet> LoadAll()
            {
                return context.Bets.ToList();
            }

            public void Delete(int id)
            {
                Bet betToDelete = Load(id);
                context.Bets.Remove(betToDelete);
                context.SaveChanges();
            }
        }
    }


