using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyPlant;

namespace ZombiesVsPlants.MyLand
{
    class Land : Element
    {
        private Street street;
        private Floor floor;
        private bool isEmpty;
        public string plantName;

        public Land(Street s, Floor f)
        {
            this.street = s;
            this.floor = f;
            isEmpty = true;
            this.PlantName = "";
        }

        public void Clear()
        {
            isEmpty = true;
        }

        public virtual Plant GrowPlant(string type)
        {
            if (isEmpty && Controller.gameStatus == GameStatus.START)
            {
                //创建植物
                var assembly = System.Reflection.Assembly.GetExecutingAssembly();
                Type classType = assembly.GetType("ZombiesVsPlants.MyPlant." + type);
                Plant p = (Plant)Activator.CreateInstance(classType);
                //初始化
                p.Instance(this.Street, this.Floor);
                if (type == "FlowerPot" || type == "LilyPad" || type == "PumpkinHead")
                    isEmpty = true;
                else
                    isEmpty = false;
                p.Land = this;

                return p;
            }
            else
                return null;
        }

        public Floor Floor
        {
            get { return floor; }
            set { floor = value; }
        }

        internal Street Street
        {
            get { return street; }
            set { street = value; }
        }

        public bool IsEmpty
        {
            get { return isEmpty; }
            set { isEmpty = value; }
        }

        public string PlantName
        {
            get { return plantName; }
            set { plantName = value; }
        }
    }
}
