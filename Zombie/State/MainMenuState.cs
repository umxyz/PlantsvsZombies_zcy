using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ZombiesVsPlants
{
    public class MainMenuState: ISceneState
    {     
        public MainMenuState(string formty):base(formty){
            StartState();
        }

        public override void EndState()
        {
            //throw new NotImplementedException();
            myform.Close();
        }

        public override void Handle(SceneStateController context)
        {
            context.MState = new BattleState("ZombiesVsPlants.BattleForm");
        }

        public override void StartState()
        {
            // throw new NotImplementedException();
            myform.Visible = true;
        }
    }
}
