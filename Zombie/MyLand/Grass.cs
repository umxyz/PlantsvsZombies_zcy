﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsFormsApplication3;
using ZombiesVsPlants.MyPlant;

namespace ZombiesVsPlants.MyLand
{
    class Grass : Land
    {
        public Grass(Street s, Floor f) : base(s, f)
        {

        }

        public override Plant GrowPlant(string type)
        {
            Plant p = base.GrowPlant(type);

            return p;
        }
    }
}
