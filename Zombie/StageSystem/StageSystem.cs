using System;
using System.Collections.Generic;
using System.Text;


namespace ZombiesVsPlants
{
    public class StageSystem: IGameSystem
    {
        int mLv = 1;
        private int mCountOfEnemyKilled=0;
        IStageHandler mRootHandler;
        public int countOfEnemyKilled
        {
            set
            {
                mCountOfEnemyKilled = value;
            }
        }
        public override void Init()
        {
            base.Init();
            InitStageChain();
            mFacade.RegisterObserver(GameEventType.EnemyKilled, new EnemyKilledObserverStageSystem(this));
        }

        public override void Update()
        {
            base.Update();
            mRootHandler.Handle(mLv);
        }

        private void InitStageChain()
        {

            int lv = 1;
            NormalStageHandler handler1 = new NormalStageHandler(this, lv++, 3, CharacterName.nZombie, 4, 0.05f);
            NormalStageHandler handler2 = new NormalStageHandler(this, lv++, 13, CharacterName.nZombie, 10, 0.1f);
            NormalStageHandler handler3 = new NormalStageHandler(this, lv++, 23, CharacterName.nZombie, 10, 2f);
            NormalStageHandler handler4 = new NormalStageHandler(this, lv++, 33, CharacterName.nZombie, 10, 0.3f);
            NormalStageHandler handler5 = new NormalStageHandler(this, lv++, 43, CharacterName.nZombie, 10, 0.4f);
            NormalStageHandler handler6 = new NormalStageHandler(this, lv++, 53, CharacterName.nZombie, 10, 0.5f);
            NormalStageHandler handler7 = new NormalStageHandler(this, lv++, 63, CharacterName.nZombie, 10, 0.6f);
            NormalStageHandler handler8 = new NormalStageHandler(this, lv++, 73, CharacterName.nZombie, 10, 0.7f);
            NormalStageHandler handler9 = new NormalStageHandler(this, lv++, 83, CharacterName.nZombie, 10, 0.8f);
            NormalStageHandler handler10 = new NormalStageHandler(this, lv++, 93, CharacterName.nZombie, 10, 0.9f);
            NormalStageHandler handler11 = new NormalStageHandler(this, lv++, 999999, CharacterName.nZombie, 9999999, 0.25f);

            handler1.SetNextHandler(handler2).SetNextHandler(handler3).SetNextHandler(handler4).SetNextHandler(handler5).SetNextHandler(handler6).SetNextHandler(handler7).SetNextHandler(handler8).SetNextHandler(handler9).SetNextHandler(handler10).SetNextHandler(handler11);
            mRootHandler = handler1;
        }
        public int CountOfEnemyKilled
        {
            set
            {
                mCountOfEnemyKilled = value;
            }
        }
        public int GetCountOfEnemyKilled()
        {
            return mCountOfEnemyKilled;
        }
        public void EnterNextStage()
        {
            
            mLv++;
           // mFacade.NotifySubject(GameEventType.NewStage);
        }
    }
}
