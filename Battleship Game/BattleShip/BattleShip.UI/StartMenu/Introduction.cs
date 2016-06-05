using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;

namespace BattleShip.UI.StartMenu
{
    public class Introduction
    {
        public void StartUpMenu(Player p1,Player p2)
        {
            SoundPlayer introSound1 = new SoundPlayer(@".\Sound\introSound1.wav");
            introSound1.Play();
            DrawTitle();   
            Console.Write("Press Enter To Start Kicking Ass");
            Thread.Sleep(2000);
            introSound1.Stop();
            Console.ReadLine();



            //Initializing Players
            Console.Clear();

            Console.Write("Player 1 please enter your kickass name: ");
            p1.name = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(p1.name))
                p1.name = "Player 1";

            Console.Write("Player 2 please enter your kickass name: ");
            p2.name = Console.ReadLine().ToUpper();
            if (string.IsNullOrEmpty(p2.name))
                p2.name = "Player 2";

            // initialize boards
            Console.Clear();
            Console.WriteLine($"{p1.name}, please place your ships\n");
            p1.SetBoard();
            Console.WriteLine($"\n\t{p1.name}, please press enter and pass the keyboard to {p2.name}");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"\n{p2.name}, please place your ships\n");
            p2.SetBoard();
            Console.ReadKey();


        }

        static void DrawTitle()
        {
            Console.Clear();
            Console.WriteLine(@"  _  __  _          _                               ____            _     _     _           _____   _       _           _   _   _ 
 | |/ / (_)        | |        /\                   |  _ \          | |   | |   | |         / ____| | |     (_)         | | | | | |
 | ' /   _    ___  | | __    /  \     ___   ___    | |_) |   __ _  | |_  | |_  | |   ___  | (___   | |__    _   _ __   | | | | | |
 |  <   | |  / __| | |/ /   / /\ \   / __| / __|   |  _ <   / _` | | __| | __| | |  / _ \  \___ \  | '_ \  | | | '_ \  | | | | | |
 | . \  | | | (__  |   <   / ____ \  \__ \ \__ \   | |_) | | (_| | | |_  | |_  | | |  __/  ____) | | | | | | | | |_) | |_| |_| |_|
 |_|\_\ |_|  \___| |_|\_\ /_/    \_\ |___/ |___/   |____/   \__,_|  \__|  \__| |_|  \___| |_____/  |_| |_| |_| | .__/  (_) (_) (_)
                                                                                                               | |                
                                                                                                               |_|                ");
            Console.WriteLine(@"                          __                                           __                ___             
|_/ .  _ |   /\   _  _   |__)  _  |_ |_ |  _  _ |_  .  _     __  __   / _   _   _   _|    |  .  _   _  _ 
| \ | (_ |( /--\ _) _)   |__) (_| |_ |_ | (- _) | ) | |_)    __  __   \__) (_) (_) (_|    |  | ||| (- _) 
                                                      |                                                  ");
        }
    }
}
