using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;

namespace ZombiesVsPlants.MyZombie
{
    class PoleVaultingZombie : Zombie
    {
        public new int AttackTime;
        public PoleVaultingZombie(Street street, Floor floor) : base(street, floor)
        {
            Power = 12;
            Hp = 8;
            Speed = 10;
            Dir = Direction.LEFT;
            Type = "PoleVaultingZombie";

            loadImage();
        }


        public PoleVaultingZombie(int x, int y)
        {
            X = x;
            Y = y;
            Hp = 8;
            Speed = 10;
            Dir = Direction.LEFT;
            Type = "PoleVaultingZombie";

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
