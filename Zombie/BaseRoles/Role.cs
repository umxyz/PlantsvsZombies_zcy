using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyEnum;

namespace ZombiesVsPlants
{
    class Role : Element
    {
        private int speed;
        private int hp;
        private Direction dir;
        private Street street;
        private Floor floor;
        private RoleStatus rolesStatus;
        //要攻击的敌人
        private Role enemy;

        public Role(Street s, Floor f) : base((int)s, (int)f)
        {
            street = s;
            floor = f;
        }

        public Role()
        {

        }

        public virtual void Run()
        {

        }

        public virtual void Dead()
        {

        }

        public virtual void Dispear()
        {

        }

        public virtual void Attack()
        {
            Enemy.Hp--;
            if (Enemy.Hp <= 0)
            {
                Enemy.RolesStatus = RoleStatus.DEAD;
                RolesStatus = RoleStatus.MOVE;
            }
        }

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        internal RoleStatus RolesStatus
        {
            get { return rolesStatus; }
            set { rolesStatus = value; }
        }

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        public Direction Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        internal Role Enemy
        {
            get { return enemy; }
            set { enemy = value; }
        }

        public Floor Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        public Street Street
        {
            get { return street; }
            set { street = value; }
        }
    }
}
