using System.Collections.Generic;
using System.Collections;
using System;
using System.Threading;

namespace prj2
{
    class EnemiesHandler
    {
        private List<EnemyObject> enemies = new List<EnemyObject>(); 
        private static EnemiesHandler enemiesHandler = null;   
        MapManager mapManager = MapManager.CreateMapManager();
        Random rand = new Random();
        const int ENEMY_MOVE_X = 8;
        const int ENEMY_MOVE_Y = 1;
        int enemySpeed = 200;

        private EnemiesHandler() { }

        public static EnemiesHandler CreateEnemiesHandler()
        {
            if (enemiesHandler == null)
            {
                enemiesHandler = new EnemiesHandler();
            }
            return enemiesHandler;
        }

        public void AddEnemy(EnemyObject enemy)
        {
            enemies.Add(enemy);
            mapManager.DrawConsole(enemy, enemy.IMAGE);
        }

        public void OneWave()
        {
            int enemyNum = 8;
            int enemyX = 7;
            int enemyY = 2;
            for (int i = 0; i < enemyNum; i++)
            {
                enemiesHandler.AddEnemy(new EnemyObject(enemyX, enemyY));
                enemyX += 10;
                if (enemyX > 45)
                {
                    enemyX = 12;
                    enemyY = 4;
                }
            }
        }


        public void HitEnemy(int x, int y)
        {
            EnemyObject enemy;
            for (int i = 0; i < enemies.Count; i++)
            {
                enemy = enemies[i];
                if (enemy.posY == y)
                {
                    if ((enemy.posX - enemy.IMAGE_SIZE -1) <= x && (enemy.posX + enemy.IMAGE_SIZE + 1) >= x)
                    {
                        mapManager.DrawConsole(enemy, enemy.REMOVE_IMAGE);
                        enemies.RemoveAt(i);
                        if (enemies.Count == 0)
                        {
                            MainGame.IsGameOver = true;
                        }
                    }
                }
            }
        }

        public void MoveEnemies()
        {
            while (!MainGame.IsGameOver)
            { 
                MoveAllX(1);
                MoveAllY(1);
                MoveAllX(-1);
                MoveAllY(1);
            }
        }

        private void MoveAllX(int direction)
        {
            for (int i = 0; i < ENEMY_MOVE_X; i++)
            {
                RandomShoot();
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (MainGame.IsGameOver)
                    {
                        return;
                    }
                    EnemyObject enemy = enemies[j];
                    mapManager.DrawConsole(enemy, enemy.REMOVE_IMAGE);
                    enemy.posX = enemy.posX + direction;
                    mapManager.DrawConsole(enemy, enemy.IMAGE);
                }
                Thread.Sleep(enemySpeed);
            }
        }

        private void MoveAllY(int direction)
        {
            for (int i = 0; i < ENEMY_MOVE_Y; i++)
            {
                if (MainGame.IsGameOver)
                {
                    return;
                }
                RandomShoot();
                for (int j = 0; j < enemies.Count; j++)
                {
                    EnemyObject enemy = enemies[j];
                    mapManager.DrawConsole(enemy, enemy.REMOVE_IMAGE);
                    enemy.posY = enemy.posY + direction;
                    mapManager.DrawConsole(enemy, enemy.IMAGE);
                }
                Thread.Sleep(enemySpeed);
            }
        }


        public void RandomShoot()
        {
            if (rand.Next(4) == 1 && enemies.Count !=0 )
            {
                EnemyObject enemy = enemies[rand.Next(enemies.Count)];
                new EnemyBulletObject(enemy.posX, enemy.posY);
            }
        }

    }
}
