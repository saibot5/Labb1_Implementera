using Labb1_Implementera.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_Implementera.Factories
{
    public abstract class Ship : IObserver
    {

        public string Name { get; set; }
        public int Size { get; set; }
        public List<Position> Positions { get; set; }
        public bool isSunk { get; set; } = false;

        //observer
        public Ship(HitPostionList hitPostionList)
        {
            hitPostionList.RegisterObserver(this);
        }
        public void Update(List<Position> hitPositionList)
        {
            isSunk = Positions.Where(P => !hitPositionList.Any(H => P.X == H.X && P.Y == H.Y)).ToList().Count == 0;
        }
    }

    public class Carrier : Ship
    {
        public Carrier(HitPostionList hitPostionList) : base(hitPostionList)
        {
            Name = "Carrier";
            Size = 5;
        }
    }

    public class Battleship : Ship
    {
        public Battleship(HitPostionList hitPostionList) : base(hitPostionList)
        {
            Name = "Battleship";
            Size = 4;
        }
    }

    public class Destroyer : Ship
    {
        public Destroyer(HitPostionList hitPostionList) : base(hitPostionList)
        {
            Name = "Destroyer";
            Size = 3;
        }
    }
    public class Submarine : Ship
    {
        public Submarine(HitPostionList hitPostionList) : base(hitPostionList)
        {
            Name = "Submarine";
            Size = 3;
        }
    }

    public class PatrolBoat : Ship
    {
        public PatrolBoat(HitPostionList hitPostionList) : base(hitPostionList)
        {
            Name = "PatrolBoat";
            Size = 2;
        }
    }
}
