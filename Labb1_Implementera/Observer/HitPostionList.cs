using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//observer
namespace Labb1_Implementera.Observer
{
    public class HitPostionList : ISubject
    {
       private List<Position> hitPosition = new List<Position> ();
        private readonly List<IObserver> observers = new List<IObserver> ();
        public void RegisterObserver(IObserver observer)
        {
            observers.Add (observer);
        }

        public void UnregisterObserver(IObserver observer)
        {
            observers.Remove (observer);
        }
        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(hitPosition);
            }
        }

        public void Add(int x, int y)
        {
            Position pos = new Position(x,y);
            hitPosition.Add(pos);
            NotifyObservers();
        }

        public List<Position> GetList()
        {
            return hitPosition;
        }
    }
}
