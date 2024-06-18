using Labb1_Implementera.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
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



            map.CreateMap(enemyNavy,false);

            TakeTurns(enemyNavy, map, hitPostionList, Coordinates);
        }

        private void TakeTurns(Navy enemyNavy, GameBoard map, HitPostionList hitPostionList, Dictionary<char, int> coordinates)
        {
            do
            {
                //TODO Better message
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Where to shoot?");
                string input = Console.ReadLine();
                //TODO add invalid target
                Position pos = TestInput(input, coordinates);

                hitPostionList.Add(pos.X, pos.Y);
            } while (true);

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
