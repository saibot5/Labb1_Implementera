using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//observer
namespace Labb1_Implementera.Observer
{
    public interface IObserver
    {
        void Update(List<Position> hitPositionList);
    }
}
