using Labb1_Implementera.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Factories
{
    //FACTORY
    internal class ShipCreator
    {
        public Ship CreateShip(string type, HitPostionList hitPostionList)
        {
            switch (type.ToUpper())
            {
                case "CARRIER":
                    return new Carrier(hitPostionList);
                case "BATTLESHIP":
                    return new Battleship(hitPostionList);
                case "DESTROYER":
                    return new Destroyer(hitPostionList);
                case "SUBMARINE":
                    return new Submarine(hitPostionList);
                case "PATROLBOAT":
                    return new PatrolBoat(hitPostionList);
                default:
                    throw new ArgumentException("Invalid ship type");
            }
        }
    }
}
