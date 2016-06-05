using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.UI.StartMenu;
using System.Media;
using System.Threading;

namespace BattleShip.UI
{
    class Game
    {
        
        DrawGrid _grid=new DrawGrid();

        public void PlayerTurn(Player player1, Player player2)
        {
            bool _victory1 = false;
            bool _victory2 = false;
            int turn = 0;
            while (!_victory1 && !_victory2)
            {
                Console.Clear();
                if (turn % 2 == 0)//player1 turn
                    _victory1 = PlayerFire(player1, player2);
                else//player 2 turn
                    _victory2 = PlayerFire(player2, player1);

                Console.ReadLine();
                turn++;
            }
            if (_victory1 == true)
            {
                VictoryScreen(player1,player2);
            }
            else
            {
                VictoryScreen(player2, player1);
            }
            Console.ReadLine();

        }

        public bool PlayerFire(Player pTurn,Player pOpponent)
        {
            int playerShotX, playerShotY;
            bool tryAgain = true;
            bool wonOrNot = false;
            ConsoleColor preColor = Console.ForegroundColor;
            while (tryAgain)
            {
                Console.WriteLine($"\t***********\\/ Opponent's Board \\/***********");
                _grid.Draw(pOpponent._board);

                Console.WriteLine($"\n\n\t*************\\/ Your Board \\/*************");
                _grid.DrawShips(pTurn._board);

                Console.Write($"\n\t {pTurn.name}, please choose a coordinate to fire at: ");
                string playerShot = Console.ReadLine();

                SoundPlayer fireSound = new SoundPlayer(@".\Sound\fireSound.wav");
                fireSound.Play();
                Thread.Sleep(1500);
                fireSound.Stop();

                TransformCoords shotCoords = new TransformCoords();
                playerShotX = shotCoords.Conversion(playerShot, out playerShotY);
                FireShotResponse _response = pOpponent._board.FireShot(new Coordinate(playerShotY, playerShotX));

                Console.Clear();
                switch (_response.ShotStatus)
                {
                    case ShotStatus.Duplicate:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\a****************Duplicate shot! Please try again.****************");
                        Console.ForegroundColor = preColor;
                        break;
                    case ShotStatus.Hit:
                        Console.Clear();
                        SoundPlayer hitSound = new SoundPlayer(@".\Sound\hitSound1.wav");
                        hitSound.Play();
                        _grid.Draw(pOpponent._board);
                        Console.WriteLine($"\n\tOh you hit their ship!");
                        Thread.Sleep(3000);                     
                        tryAgain = false;
                        hitSound.Stop();
                        break;
                    case ShotStatus.HitAndSunk:
                        Console.Clear();
                        SoundPlayer hitAndSunkSound = new SoundPlayer(@".\Sound\HitAndSink.wav");
                        hitAndSunkSound.Play();
                        _grid.Draw(pOpponent._board);
                        Console.WriteLine($"\n\tYou just sunk their {_response.ShipImpacted}! Good going!");
                        Thread.Sleep(4500);
                        tryAgain = false;
                        hitAndSunkSound.Stop();
                        break;
                    case ShotStatus.Invalid:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\a****************Invalid shot! Please try again.****************");
                        Console.ForegroundColor = preColor;
                        break;
                    case ShotStatus.Victory:
                        tryAgain = false;
                        wonOrNot = true;
                        break;
                    default:
                        Console.Clear();
                        SoundPlayer missSound = new SoundPlayer(@".\Sound\MissSound.wav");
                        missSound.Play();
                        _grid.Draw(pOpponent._board);
                        Console.WriteLine("\n\tAww! You missed! Try harder next time.");
                        Thread.Sleep(3500);
                        tryAgain = false;
                        missSound.Stop();
                        break;
                }
                
            }
            return wonOrNot;
        }

        public void VictoryScreen(Player winner,Player loser)
        {
            SoundPlayer victorySound = new SoundPlayer(@".\Sound\Victory.wav");
            victorySound.Play();
            Console.WriteLine($"\t{winner.name}, you win! You're the most KICKASS player ever!! \n\tAnd oh {loser.name}, you kinda suck!");
            Console.WriteLine($"\t***********\\/ {winner.name}'s Board \\/***********");
            _grid.DrawShips(winner._board);
            Console.WriteLine($"\n\t*************\\/ {loser.name}'s Board \\/*************");
            _grid.DrawShips(loser._board);
            Thread.Sleep(1500);
            victorySound.Stop();            
        }
    }
}
