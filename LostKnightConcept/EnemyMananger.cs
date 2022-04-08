﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostKnightConcept
{
    class EnemyMananger 
    {
        public Enemy[] enemy;

        int maxEnemies = 50;
        int SkeletonCount = 25;
        int posX;
        int posY;

        private Random rngX = new Random (0);
        private Random rngY = new Random (1);

        public EnemyMananger(Map map)
        {
            int maxNumber = maxEnemies - 1;
            enemy = new Enemy[maxEnemies];
            for (int i = 0; i < maxEnemies; i++)
            {
                if (i < SkeletonCount) enemy[i] = new Skeleton();
                else if (i == maxNumber) enemy[i] = new Ghoul();
                else enemy[i] = new Ghost();               
            }
        }

        public void Draw(Render render, Map map, Global global)
        {
            for (int i = 0; i < maxEnemies; i++)
            {               
                if (map.IsFloor(posX, posY) == true && map.CheckCameraBoundX(posX, global) == true )
                {
                    enemy[i].Draw(posX + i, posY + i, enemy[i].name, render, map); 
                }
                else return;
            }
        }

        public void UpdateEnemies(Player player, Map map, Render render)
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                enemy[i].Move(map, player, render);
            }
        }       
    }
}
