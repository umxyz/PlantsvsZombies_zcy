using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;

namespace ZombiesVsPlants.MyZombie
{
    class FlagZombie : Zombie
    {
        public new int AttackTime;
        public FlagZombie(Street street, Floor floor) : base(street, floor)
        {
            Power = 3;
            Hp = 5;
            Speed = 4;
            Dir = Direction.LEFT;
            Type = "FlagZombie";

            loadImage();
        }


        public FlagZombie(int x, int y)
        {
            X = x;
            Y = y;
            Hp = 5;
            Speed = 4;
            Dir = Direction.LEFT;
            Type = "FlagZombie";

            loadImage();
        }

        public override void Dead()
        {
            Dispear();

            NormalZombie zombie = new NormalZombie(this.Street, this.Floor);
            zombie.X = X;
            zombie.Y = Y;
            //loaddeadImage();
            Map.addZombie(zombie);

        }
    }
}
