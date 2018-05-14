using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace CSGO_MVC.Controllers 

{
    public class RouletteController
    {
        static List<Field> Fieldlist = new List<Field>();
        
            
        Random random;
        static void Main(string[] args)
        {
            public RouletteController(Random random)
            {
                this.random = random;
                Fieldlist.Add;
            }

            public int RandomSlot()
            {
                return random.Next(wheel.Length);
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
                    return (wheel[slot] % 2 == 0) ? ConsoleColor.Black : ConsoleColor.Red;
                }
                else
                {
                    //0 = green
                    return ConsoleColor.Green;
                }

            }


 
        
            static void Main(string[] args)
            {
                RouletteController roulette = new RouletteController(new Random(2));

                // spin it, do it. 
                for (int i = 0; i < 50; i++)
                {
                    int slot = roulette.RandomSlot();
                    ConsoleColor color = RouletteController.SlotColor(slot);
                    string text = RouletteController.SlotText(slot);
                    Console.WriteLine("{0} {1}", text, color);
                    Console.ReadLine();


                }

            }





        }
    }
