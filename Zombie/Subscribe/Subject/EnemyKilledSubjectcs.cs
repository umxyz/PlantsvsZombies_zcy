using System;
using System.Collections.Generic;
using System.Text;


namespace ZombiesVsPlants
{
    class EnemyKilledSubjectcs:ISubject
    {
        private int mKilledCount = 0;

        public int killedCount { get { return mKilledCount; } }

        public override void Notify()
        {
            mKilledCount++;
            base.Notify();
        }
    }
}
