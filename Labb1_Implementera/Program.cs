using Labb1_Implementera.Observer;

namespace Labb1_Implementera
{
    internal class Program
    {
        /*
          Battleships
           Used patterns:
           factory: Shipcreator
           singleton: gameManager
           observer: hitPositionlist
        */
        static void Main(string[] args)
        {
            GameManager gameManager = GameManager.Instance;
            //create player ships
            //create AI ships


            gameManager.StartGame();
        }
    }
}
