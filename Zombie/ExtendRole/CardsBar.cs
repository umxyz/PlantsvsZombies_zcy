﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZombiesVsPlants.API;

namespace ZombiesVsPlants.ExtendRole
{
    class CardsBar
    {
        private int width, height;
        private Map map;

        public CardsBar(Map map)
        {
            width = 118;
            height = 10;
            this.map = map;

        }

        public void initCard(PlantCard pc)
        {
            int x = 0, y = 0;
            x = width;
            y = y + height * (map.Plantscards.Count + 1)
                + (map.Plantscards.Count) * MyAPI.CardHeight;
            if (y <= 600 - MyAPI.CardHeight)
            {
                pc.X = x;
                pc.Y = y;
                map.addCard(pc);
            }
        }
    }
}
