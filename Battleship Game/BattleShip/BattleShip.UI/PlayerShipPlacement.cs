using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
using BattleShip.UI.StartMenu;

namespace BattleShip.UI
{
    public class PlayerShipPlacement
    {
        DrawGrid grid = new DrawGrid();

        public void SetShip(Board _board, ShipType type)
        {
            PlaceShipRequest _request = new PlaceShipRequest();
            bool valid = false;
            do
            {
                _request.ShipType = type;
                int num1, num2;

                //Choosing Coordinates
                Console.WriteLine();
                Console.Write("\n{0} (5 Spaces): \n\tPlease Choose Starting Coordinate: ",Enum.GetName(typeof(ShipType),type));
                string coordinateString = Console.ReadLine();
                TransformCoords coords = new TransformCoords();
                num1 = coords.Conversion(coordinateString, out num2);

                _request.Coordinate = new Coordinate(num2, num1);

                //Choosing Direction
                Console.Write("\n\tPlease Choose The Direction (Up/Down/Right/Left): ");
                string directionString = Console.ReadLine();

                //validating direction chosen
                if (directionString.ToUpper() == Enum.GetName(typeof(ShipDirection), (int)0).ToUpper())
                {
                    _request.Direction = ShipDirection.Up;
                }
                else if (directionString.ToUpper() == Enum.GetName(typeof(ShipDirection), (int)1).ToUpper())
                {
                    _request.Direction = ShipDirection.Down;
                }
                else if (directionString.ToUpper() == Enum.GetName(typeof(ShipDirection), (int)2).ToUpper())
                {
                    _request.Direction = ShipDirection.Left;
                }
                else if (directionString.ToUpper() == Enum.GetName(typeof(ShipDirection), (int)3).ToUpper())
                {
                    _request.Direction = ShipDirection.Right;
                }

                //ouput error message if position is invalid
                else
                {
                    ConsoleColor preColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n********Please Choose A Valid Direction********");
                    Console.ForegroundColor = preColor;
                    continue;
                }
                var request = _board.PlaceShip(_request);
                if (ShipPlacement.Ok != request)
                {
                    ConsoleColor preColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n********P'lease Choose A Valid Location********");
                    Console.ForegroundColor = preColor;

                }
                else if (ShipPlacement.Ok == request)
                {
                    valid = true;
                }
            } while (!valid);
        }

    }
}
