using Labb1_Implementera.Factories;
using Labb1_Implementera.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera
{
    //SINGLETON
    internal class GameManager
    {
        private static volatile GameManager instance;
        private static object lockObject = new object();

        private GameManager() { }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new GameManager();
                        }
                    }
                }
                return instance;
            }
        }


        //TODO GAME LOGIC

        public void StartGame()
        {
           
           
            Console.WriteLine("press 2 for cheat mode (visible enemy ships). press any other key to start regular mode");
           
        
            
            bool visibleShips;

            if (Console.ReadKey().Key == ConsoleKey.D2) 
            {
                visibleShips = true;
            }
            else
            {
                visibleShips = false;
            }
            Console.Clear();

            HitPostionList hitPostionList = new HitPostionList();
            Navy enemyNavy = new Navy(hitPostionList);
            GameBoard map = new GameBoard(hitPostionList);

            Dictionary<char, int> Coordinates =
                     new Dictionary<char, int>
                     {
                         { 'A', 1 },
                         { 'B', 2 },
                         { 'C', 3 },
                         { 'D', 4 },
                         { 'E', 5 },
                         { 'F', 6 },
                         { 'G', 7 },
                         { 'H', 8 },
                         { 'I', 9 },
                         { 'J', 10 }
                     };



            map.CreateMap(enemyNavy, visibleShips);

            TakeTurns(enemyNavy, map, hitPostionList, Coordinates);
        }

        private void TakeTurns(Navy enemyNavy, GameBoard map, HitPostionList hitPostionList, Dictionary<char, int> coordinates)
        {
            bool win = false;
            int turnsTaken = 0;
            do
            {
                //TODO Better message
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Where to shoot?");
                string input = Console.ReadLine();
                //TODO add invalid target
                Position pos = TestInput(input, coordinates);

                hitPostionList.Add(pos.X, pos.Y);
                turnsTaken++;
                int sunkenShips = 0;
                foreach(Ship ship in enemyNavy.Ships)
                {
                    if (ship.isSunk == true)
                    {
                        sunkenShips++;
                    }
                }
                if (sunkenShips == 5)
                {
                    win = true;
                }

            } while (!win);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"You won in {turnsTaken} turns");
        }

        private Position TestInput(string input, Dictionary<char, int> coordinates)
        {
            Position pos = new Position(-1, -1);
            char[] inputSplit = input.ToUpper().ToCharArray();

            if (coordinates.TryGetValue(inputSplit[0], out int value))
            {
                pos.X = value;
            }
            else
            {
                return pos;
            }

            if (inputSplit.Length == 3)
            {

                if (inputSplit[1] == '1' && inputSplit[2] == '0')
                {
                    pos.Y = 10;
                    return pos;
                }
                else
                {
                    return pos;
                }


            }
            if (inputSplit[1] - '0' > 9)
            {
                return pos;
            }
            else
            {
                pos.Y = inputSplit[1] - '0';
            }
            return pos;
        }
    }
}
