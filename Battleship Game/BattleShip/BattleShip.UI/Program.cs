using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.UI.StartMenu;
using System.Media;
using System.Threading;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SoundPlayer IntroSound = new SoundPlayer(@".\Sound\introSound.wav");           
            IntroSound.Play();
            //workflow
            bool playAgain = false;
            IntroScreen introShip = new IntroScreen();
            introShip.IntroscreenBattle();
            IntroSound.Stop();
            
            do
            {
                
                Player p1 = new Player();
                Player p2 = new Player();               
                Introduction _intro = new Introduction();
                _intro.StartUpMenu(p1, p2);
                Game playGame = new Game();
                playGame.PlayerTurn(p1, p2);
                Console.WriteLine("\n\tWould you like to play again?(Y/N)");
                string YesNo = Console.ReadLine();
                if (YesNo.ToUpper() == "Y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            } while (playAgain);
            Console.WriteLine("\n\tThank you for playing!");
            Console.ReadLine();
        }
    }
}
