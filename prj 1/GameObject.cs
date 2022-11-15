using System;
using System.Text;
using System.Threading;


namespace prj_1
{
    class GameObject
    {
        public readonly int IMAGE_SIZE;
        public readonly string IMAGE;
        public readonly string REMOVE_IMAGE;
        public readonly ConsoleColor COLOR;

        public int posX { get; set; }
        public int posY { get; set; }

        public GameObject(int x, int y, String img, ConsoleColor color)
        {
            posX = x;
            posY = y;
            IMAGE = img;
            IMAGE_SIZE = img.Length/2;
            REMOVE_IMAGE = getRemoveImg();
            COLOR = color;
        }

        private string getRemoveImg()
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < IMAGE.Length; i++)
            {
                sb.Append(" ");
            }

            return sb.ToString();
        }
    }

    class PlayerObject : GameObject
    {
        const string PLAYER_IMAGE = ">-0-<";
        const ConsoleColor PLAYER_COLOR = ConsoleColor.Yellow;
        const int START_X = (int)MapSizeInfo.MaxX / 2;
        const int START_Y = (int)MapSizeInfo.MaxY / 2 + 7;

        private static PlayerObject playerObj = null;
        private PlayerObject() :base(START_X, START_Y, PLAYER_IMAGE, PLAYER_COLOR)
        { 
        }

        public static PlayerObject CreatePlayerObj()
        {
            if (playerObj == null)
            {
                playerObj = new PlayerObject();
            }
            return playerObj; 
        }
    }

    
    class BulletObject : GameObject
    {
        const string BULLET_IMAGE = "!";
        const ConsoleColor BULLET_COLOR = ConsoleColor.Red;
        MapManager mapManager = MapManager.CreateMapManager();
        EnemiesHandler enemiesHandler = EnemiesHandler.CreateEnemiesHandler();

        public BulletObject(int x, int y) : base(x, y - 1, BULLET_IMAGE, BULLET_COLOR)
        {
            new Thread(shoot).Start();
        }

        //슛 함수
        private void shoot()
        {
            int speed = 50;
            for(int i = posY; i > 0; i--)
            {
                posY--;
                if (mapManager.checkObj(posX, posY))
                {
                    enemiesHandler.HitEnemy(posX, posY);
                    return;
                }
                mapManager.DrawConsole(this, BULLET_IMAGE);
                Thread.Sleep(speed);
                mapManager.DrawConsole(this, REMOVE_IMAGE);
            }
        }
    }

    class EnemyObject : GameObject
    {
        const string ENEMY_IMAGE = "[XUX]";
        const ConsoleColor ENEMY_COLOR = ConsoleColor.Green;

        public EnemyObject(int x, int y) : base(x,y, ENEMY_IMAGE, ENEMY_COLOR)
        {
        }
    }
}
