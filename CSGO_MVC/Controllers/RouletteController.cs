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
        private static  Random random;
        private static  Random random2; 
        private int Seed { get; set; }





        public RouletteController(Random random)
        {
            var list = fctrl.GetAll();
            foreach (var item in list)
            {
                Fieldlist.Add(item);
            }
            random = new Random(Seed);
            random2 = new Random(Seed);
        }

        public int getRandomSeed()
        {
            int[] Seedlist = sctrl.GetNumber().ToArray();

            int i;
            for (i = 0; i < 50; i++)
            {
                Seed = Seedlist[random2.Next(0, Seedlist.Length)];
            }
            return Seed;

        }


            public Field Letsgo()
            {
                Random random = new Random();
                Fieldlist
            }


            public static string SlotText(int slot)
            {
                if (Fieldlist[slot] >= 0)
                {
                    return Fieldlist[slot].ToString();
                }
                else
                {
                    return "Else siger noget andet";
                }
            }
            public static ConsoleColor SlotColor(int slot)
            {
                if (wheel[slot] > 0)
                {
                    //Odd = red , Even = black
                    return (wheel[slot] % 2 == 0) 
                }
                else
                {
                    //0 = green
                    return ConsoleColor.Green;
                }

            }


 
        
            static public Field RouletteGame(Bet accountbet)
            {
                RouletteController roulette = new RouletteController(new Random(2));

                // spin it, do it. 
                for (int i = 0; i < 50; i++)                 

                {

                   Field winnerfield =  Fieldlist[random.Next(Fieldlist.Count())];
                
                }
            
            }





        }
    }
