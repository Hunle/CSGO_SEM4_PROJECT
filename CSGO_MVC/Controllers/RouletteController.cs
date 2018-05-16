using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSGO_MVC.Models;

namespace CSGO_MVC.Controllers 

{
    public class RouletteController
    {
        static List<Field> Fieldlist = new List<Field>();
        private FieldController fctrl = new FieldController();
        private SeedController sctrl = new SeedController();
        private   Random random;
        private   Random random2;
        int[] Seedlist { get; set; }
        private int Seed { get; set; }
        public Field winnerfield { get; set; }





        public RouletteController(Random random)
        {
            var list = fctrl.GetAll();
            foreach (var item in list)
            {
                Fieldlist.Add(item);
            }
            Seedlist = sctrl.GetNumber().ToArray();
            random = new Random(Seed);
            random2 = new Random(Seed);
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);

            var timer = new System.Threading.Timer((e) =>
            {
                getRandomSeed();
            }, null, startTimeSpan, periodTimeSpan);
        }

        public int getRandomSeed()
        {
            for (int i = 0; i < 50; i++)
            {
                Seed = Seedlist[random2.Next(0, Seedlist.Length)];
                Seedlist.Take(Seed);
                if(Seedlist.Length == 0)
                {
                    Seedlist = sctrl.GetNumber().ToArray();
                }
            }
            return Seed;

        }
           
            public Field RouletteGame(Bet accountbet)
            {
                RouletteController roulette = new RouletteController(new Random(2));

                // spin it, do it. 
                for (int i = 0; i < 50; i++)                 

                {

                winnerfield =  Fieldlist[random.Next(Fieldlist.Count())];
                Console.WriteLine(winnerfield.Color);
                Console.WriteLine(winnerfield.Number.ToString());
                if((accountbet.Betfield.Number == winnerfield.Number) && (accountbet.Betfield.Color.Equals(winnerfield.Color)))
                {
                    Console.WriteLine("Congratulations, " + accountbet.Betmaker.UserName + "! Your prize is" + (accountbet.BetValue *= accountbet.BetValue));
                    accountbet.Betmaker.accountbalance.Amount += accountbet.BetValue;
                }
                else
                {
                    Console.WriteLine("You have lost your bet! Your bet value of" + accountbet.BetValue + " Will be substracted from your balance.");
                        accountbet.Betmaker.accountbalance.Amount -= accountbet.BetValue;

                }
                

                
                
                }
            return winnerfield;
            }





        }
    }
