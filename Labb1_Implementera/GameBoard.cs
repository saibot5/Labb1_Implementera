using Labb1_Implementera.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera
{
    internal class GameBoard : IObserver
    {
        private Navy enemyNavy;

        //observer
        public GameBoard(HitPostionList hitPostionList) 
        {
            hitPostionList.RegisterObserver(this);
        }

        public void Update(List<Position> hitPositionList)
        {
            //Redraw Map
            PrintMap(hitPositionList);
        }

        public void CreateMap(Navy navy)
        {
            
            enemyNavy = navy;
            List<Position> hitPositionList = new List<Position>();
            PrintMap(hitPositionList);
        }


        public void PrintMap(List<Position> hitList)
        {
            Console.Clear();
            PrintHeader();
            Console.WriteLine();

            char row = 'A';
            try
            {
                for (int x = 1; x < 11; x++)
                {
                    for (int y = 1; y < 11; y++)
                    {
                        bool keepGoing = true;

                        if (y == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("[" + row + "]");
                            row++;
                        }
                        if (hitList.Any(H => H.X == x && H.Y == y) && enemyNavy.AllShipsPosition.Any(A => A.X == x && A.Y == y))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("[*]");
                            keepGoing = false;
                        }
                        else if (hitList.Any(H => H.X == x && H.Y == y))
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("[X]");
                            keepGoing = false;
                        }

                        if (enemyNavy.AllShipsPosition.Any(A => A.X == x && A.Y == y) && !hitList.Any(H => H.X == x && H.Y == y))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("[O]");
                            keepGoing = false;
                        }

                        if (keepGoing)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("[~]");
                        }

                        if (y == 10)
                        {
                            Console.Write("      ");
                        }
                    }

                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {

                string error = e.Message.ToString();
            }

            printShipStatus();
        }

        private void printShipStatus()
        {
            foreach (var ship in enemyNavy.Ships)
            {
                if (ship.isSunk)
                {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ship.Name}[{ship.Size}]");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{ship.Name}[{ship.Size}]");
                }
            }
        }

        static void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("[ ]");
            for (int i = 1; i < 11; i++)
                Console.Write("[" + i + "]");


        }
    }
}
