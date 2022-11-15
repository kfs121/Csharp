using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;


namespace prj2
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
            IMAGE_SIZE = img.Length / 2;
            REMOVE_IMAGE = getRemoveImg();
            COLOR = color;
        }

        private string getRemoveImg()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < IMAGE.Length; i++)
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
        private PlayerObject() : base(START_X, START_Y, PLAYER_IMAGE, PLAYER_COLOR)
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

        public void HitPlayer(int x, int y)
        {
            MapManager mapManager = MapManager.CreateMapManager();
            EnemiesHandler enemiesHandler = EnemiesHandler.CreateEnemiesHandler();
            if (posY == y)
            {
                if ((playerObj.posX - playerObj.IMAGE_SIZE) <= x && (playerObj.posX + playerObj.IMAGE_SIZE) >= x)
                {
                    mapManager.insertObj(playerObj, REMOVE_IMAGE);
                    //enemiesHandler.ClearEnemies();
                    MainGame.IsGameOver = true;
                }
            }
        }
    }


    class BulletObject : GameObject
    {
        const string BULLET_IMAGE = "!";
        const ConsoleColor BULLET_COLOR = ConsoleColor.Red;
        MapManager mapManager = MapManager.CreateMapManager();
        EnemiesHandler enemiesHandler = EnemiesHandler.CreateEnemiesHandler();
        static Stopwatch stopwatch = new Stopwatch();

        public BulletObject(int x, int y) : base(x, y - 1, BULLET_IMAGE, BULLET_COLOR)
        {
                new Thread(shoot).Start();
        }

        private void shoot()
        {
            int speed = 50;
            for (int i = posY; i > 0; i--)
            {
                if (MainGame.IsGameOver)
                {
                    return;
                }
                posY--;
                if (mapManager.checkObj(posX, posY))
                {
                    enemiesHandler.HitEnemy(posX, posY);
                    return;
                }
                mapManager.DrawConsole(this, BULLET_IMAGE);
                Thread.Sleep(speed);
                if (MainGame.IsGameOver)
                {
                    return;
                }
                mapManager.DrawConsole(this, REMOVE_IMAGE);
            }
        }
    }

    class EnemyObject : GameObject
    {
        const string ENEMY_IMAGE = "[XUX]";
        const ConsoleColor ENEMY_COLOR = ConsoleColor.Green;

        public EnemyObject(int x, int y) : base(x, y, ENEMY_IMAGE, ENEMY_COLOR)
        {
        }
    }




    class EnemyBulletObject : GameObject
    {
        const string BULLET_IMAGE = "V";
        const ConsoleColor BULLET_COLOR = ConsoleColor.Blue;
        MapManager mapManager = MapManager.CreateMapManager();
        PlayerObject playerObj = PlayerObject.CreatePlayerObj();

        public EnemyBulletObject(int x, int y) : base(x, y + 1, BULLET_IMAGE, BULLET_COLOR)
        {
            if (!MainGame.IsGameOver)
            {
                new Thread(shoot).Start();
            }
            
        }

        private void shoot()
        {
            int speed = 80;
            for (int i = posY; i < (int)MapSizeInfo.MaxY - 2; i++)
            {
                if (MainGame.IsGameOver)
                {
                    return;
                }
                posY++;
                if (mapManager.checkObj(posX, posY))
                {
                    playerObj.HitPlayer(posX, posY);
                    return;
                }
                mapManager.DrawConsole(this, BULLET_IMAGE);
                Thread.Sleep(speed);
                if (MainGame.IsGameOver)
                {
                    return;
                }
                mapManager.DrawConsole(this, REMOVE_IMAGE);
            }
        }
    }

    class StringObject : GameObject
    {
        const ConsoleColor WORDS_COLOR = ConsoleColor.White;
        MapManager mapManager = MapManager.CreateMapManager();
        public StringObject(int x, int y, String words) : base(x, y, words, WORDS_COLOR)
        {
            posX += IMAGE_SIZE;
        }

        public void DrawString()
        {
            mapManager.DrawConsole(this, IMAGE);
        }
    }
}
