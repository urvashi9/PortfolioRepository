using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI.StartMenu
{
    public class Player
    {
        public string name;
        public Board _board = new Board();
        PlayerShipPlacement _placement = new PlayerShipPlacement();
        DrawGrid grid = new DrawGrid();
        TransformCoords startDictionary = new TransformCoords();
        

        public void SetBoard()
        {

            //draw empty board
            grid.InitializeBoard(_board);

            //draw grid with ships as they are placed
            Console.WriteLine("\t **********\\/ Place Your Ships \\/**********");
            grid.Draw(_board);
            _placement.SetShip(_board,ShipType.Carrier);
            Console.Clear();

            Console.WriteLine("\t *********\\/ Place Your Ships \\/**********");
            grid.DrawShips(_board);
            _placement.SetShip(_board, ShipType.Battleship);
            Console.Clear();

            Console.WriteLine("\t *********\\/ Place Your Ships \\/**********");
            grid.DrawShips(_board);
            _placement.SetShip(_board, ShipType.Cruiser);
            Console.Clear();

            Console.WriteLine("\t *********\\/ Place Your Ships \\/**********");
            grid.DrawShips(_board);
            _placement.SetShip(_board, ShipType.Submarine);
            Console.Clear();

            Console.WriteLine("\t *********\\/ Place Your Ships \\/*********");
            grid.DrawShips(_board);
            _placement.SetShip(_board, ShipType.Destroyer);
            Console.Clear();

            grid.DrawShips(_board);


        }
     
    }
    
}
