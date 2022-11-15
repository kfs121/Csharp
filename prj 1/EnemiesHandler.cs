using System.Collections.Generic;

namespace prj_1
{
    class EnemiesHandler
    {
        private List<EnemyObject> enemies = new List<EnemyObject>();   //왜 Enum이랑 ArrayList가 이 컴퓨터에서는 안될까..... 진짜 최근 패치가 영향인 듯 하다.
        private static EnemiesHandler enemiesHandler = null;   //.NET 이랑 CORE 최신버전, 구버전 다 설치했는데.. 참조쪽도 찾아봤는데...
        MapManager mapManager = MapManager.CreateMapManager();

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
            int enemyX = 10;
            int enemyY = 2;
            for (int i = 0; i < enemyNum; i++)
            {
                enemiesHandler.AddEnemy(new EnemyObject(enemyX, enemyY));
                enemyX += 10;
                if (enemyX > 45)
                {
                    enemyX = 15;
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
                    if ((enemy.posX - enemy.IMAGE_SIZE) <= x && (enemy.posX + enemy.IMAGE_SIZE) >= x)
                    {
                        mapManager.DrawConsole(enemy, enemy.REMOVE_IMAGE);
                        enemies.RemoveAt(i);
                        if (enemies.Count == 0)
                        {
                            Program.GameOver();
                        }
                    }
                }
            }
        }

    }
}
