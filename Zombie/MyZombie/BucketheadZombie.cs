using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;

namespace ZombiesVsPlants.MyZombie
{
    class BucketheadZombie : Zombie
    {
        public new int AttackTime;
        public BucketheadZombie(Street street, Floor floor) : base(street, floor)
        {
            Power = 8;
            Hp = 10;
            Speed = 8;
            Dir = Direction.LEFT;
            Type = "BucketheadZombie";

            loadImage();
        }


        public BucketheadZombie(int x, int y)
        {
            X = x;
            Y = y;
            Hp = 8;
            Speed = 8;
            Dir = Direction.LEFT;
            Type = "BucketheadZombie";

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
