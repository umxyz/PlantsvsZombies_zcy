using System;
using System.Collections.Generic;
using System.Text;


namespace ZombiesVsPlants
{
    public interface IObserver
    {
          void Update();
          void SetSubject(ISubject sub);
    }
}
