using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;

namespace ZombiesVsPlants.MyZombie
{
    class ConeheadZombie : Zombie
    {
        public new int AttackTime;
        public ConeheadZombie(Street street, Floor floor) : base(street, floor)
        {
            Power = 5;
            Hp = 8;
            Speed = 6;
            Dir = Direction.LEFT;
            Type = "ConeheadZombie";

            loadImage();
        }


        public ConeheadZombie(int x, int y)
        {
            X = x;
            Y = y;
            Hp = 8;
            Speed = 6;
            Dir = Direction.LEFT;
            Type = "ConeheadZombie";

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
