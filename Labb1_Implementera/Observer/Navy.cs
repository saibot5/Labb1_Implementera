using Labb1_Implementera.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Observer
{
    internal class Navy
    {
        public List<Ship> Ships { get; set; } = new List<Ship>();
        public List<Position> AllShipsPosition = new List<Position>();

        public Navy(HitPostionList hitPostionList)
        {
            CreateShips(hitPostionList);
            GenerateShipPositions();
        }



        private void CreateShips(HitPostionList hitPostionList)
        {
            ShipCreator shipCreator = new ShipCreator();
            Ships.Add(shipCreator.CreateShip("CARRIER", hitPostionList));
            Ships.Add(shipCreator.CreateShip("BATTLESHIP", hitPostionList));
            Ships.Add(shipCreator.CreateShip("DESTROYER", hitPostionList));
            Ships.Add(shipCreator.CreateShip("SUBMARINE", hitPostionList));
            Ships.Add(shipCreator.CreateShip("PATROLBOAT", hitPostionList));

        }



        private void GenerateShipPositions()
        {
            foreach (var ship in Ships)
            {
                ship.Positions = GenerateRandomPos(ship.Size);
            }
        }

        private List<Position> GenerateRandomPos(int size)
        {
                List<Position> positions = new List<Position>();
            Random random = new Random();

            //odd horizontal. even Vertical
            bool posExists;
            do
            {
                positions.Clear();
                int direction = random.Next(1, size);
                int row = random.Next(1, 11);
                int col = random.Next(1, 11);

                if (direction % 2 != 0)
                {
                    if (row - size > 0)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            Position pos = new Position(row - i, col);
                            positions.Add(pos);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < size; i++)
                        {
                            Position pos = new Position(row + i, col);
                            positions.Add(pos);
                        }
                    }
                }
                else
                {
                    if (col - size > 0)
                    {
                        for (int i = 0; i < size; i++)
                        {
                            Position pos = new Position(row, col - i);

                            positions.Add(pos);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < size; i++)
                        {
                            Position pos = new Position(row, col + i);
                            positions.Add(pos);
                        }
                    }
                }
                posExists = positions.Where(AP => AllShipsPosition.Exists(ShipPos => ShipPos.X == AP.X && ShipPos.Y == AP.Y)).Any();

            }
            while (posExists);

            AllShipsPosition.AddRange(positions);
            return positions;
        }
    }
}
