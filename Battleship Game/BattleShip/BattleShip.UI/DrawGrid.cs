using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class DrawGrid
    {
        public void InitializeBoard(Board _board)
        {
            //initialize shot history as unknown
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                   // _board.ShotHistory[new Coordinate(i, j)] = ShotHistory.Unknown;
                }
            }
        }
        public void Draw(Board _board)
        {
            char x = 'A';
            ConsoleColor prevColor = Console.ForegroundColor;

            //draw 1-10 on top row
            for (int i = 0; i < 1; i++)
            {

                Console.Write("\n\t   _");
                for (int j = 0; j < 10; j++)
                {

                    Console.Write((j + 1));
                    if (j == 9)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("_|_");
                    }
                }
                Console.WriteLine();
            }

            //draw grid 
            for (int j = 1; j < 11; j++)
            {
                //draw Alpha characters
                Console.Write($"\t{x}_|_");
                x++;
                for (int i = 1; i < 11; i++)
                {
                    //check shothistory for unknown/hit/miss and draw corresponding letter
                   
                    if (_board.ShotHistory.ContainsKey(new Coordinate(i, j)) && _board.ShotHistory[new Coordinate(i, j)] == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("H");
                        Console.ForegroundColor = prevColor;
                    }
                    else if ((_board.ShotHistory.ContainsKey(new Coordinate(i, j)) && _board.ShotHistory[new Coordinate(i, j)] == ShotHistory.Miss))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("M");
                        Console.ForegroundColor = prevColor;

                    }
                    else
                    {

                        Console.Write(" ");

                    }
                    if (i == 10)
                    {
                        Console.Write("_|");
                    }
                    else
                    {
                        Console.Write("_|_");
                    }
                }
                Console.WriteLine();
            }
        }

        // Drawing board with the ships
        public void DrawShips(Board _board)
        {
            Console.WriteLine();
            char x = 'A';
            ConsoleColor prevColor = Console.ForegroundColor;

            //draw number on top row
            for (int i = 0; i < 1; i++)
            {
                Console.Write("\t   _");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write((j + 1));
                    if (j == 9)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write("_|_");
                    }
                }
                Console.WriteLine();
            }
            for (int j = 1; j < 11; j++)
            {
                //draw alpha characters
                Console.Write($"\t{x}_|_");
                x++;
                for (int i = 1; i < 11; i++)
                {
                    //check shothistory for hit/miss and draw corresponding letter
                    if ((_board.ShotHistory.ContainsKey(new Coordinate(i, j)) && _board.ShotHistory[new Coordinate(i, j)] == ShotHistory.Hit))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("H");
                        Console.ForegroundColor = prevColor;
                    }
                    else if ((_board.ShotHistory.ContainsKey(new Coordinate(i, j)) &&
                              _board.ShotHistory[new Coordinate(i, j)] == ShotHistory.Miss))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("M");
                        Console.ForegroundColor = prevColor;
                    }
                    else
                    {
                        for (int k = 1; k < _board._currentShipIndex + 1; k++)
                        {
                            if (_board._ships[k - 1].BoardPositions.Contains(new Coordinate(i, j)))
                            {
                                Console.Write("S");
                                break;
                            }
                            else if (k == _board._currentShipIndex)
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    


                    if (i == 10)
                    {
                        Console.Write("_|");
                    }
                    else
                    {
                        Console.Write("_|_");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

