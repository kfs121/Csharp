using System;
using System.Threading;

namespace prj2
{
    class MainGame
    {
        static public bool IsGameOver { get; set; }
        static long preShootTime = DateTime.Now.Ticks;
        const long shootTerm = 3000000;
        static void Main(string[] args)
        {
            IsGameOver = false;
            MapManager mapManager = MapManager.CreateMapManager();
            EnemiesHandler enemiesHandler = EnemiesHandler.CreateEnemiesHandler();
            PlayerObject playerObj = PlayerObject.CreatePlayerObj();
            int playerSpeed = 40;

            Console.CursorVisible = false;

            mapManager.printAllField();
            mapManager.DrawConsole(playerObj, playerObj.IMAGE);
            enemiesHandler.OneWave();
            new Thread(enemiesHandler.MoveEnemies).Start();

            while (!IsGameOver)
            {
                if (Console.KeyAvailable)
                {
                    mapManager.DrawConsole(playerObj, playerObj.REMOVE_IMAGE);

                    if (PlayerControl.IsKeyDown(EKeyCode.Left) && playerObj.posX - playerObj.IMAGE_SIZE > 1)
                    {
                        playerObj.posX = playerObj.posX - 1;
                    }
                    if (PlayerControl.IsKeyDown(EKeyCode.Right) && playerObj.posX + playerObj.IMAGE_SIZE < (int)MapSizeInfo.MaxX - 2)
                    {
                        playerObj.posX = playerObj.posX + 1;
                    }
                    if (PlayerControl.IsKeyDown(EKeyCode.Up) && playerObj.posY > 0)
                    {
                        playerObj.posY = playerObj.posY - 1;
                    }
                    if (PlayerControl.IsKeyDown(EKeyCode.Down) && playerObj.posY < (int)MapSizeInfo.MaxY - 2)
                    {
                        playerObj.posY = playerObj.posY + 1;
                    }
                    if (PlayerControl.IsKeyDown(EKeyCode.Space))
                    {
                        if(DateTime.Now.Ticks - preShootTime > shootTerm)
                        {
                            preShootTime = DateTime.Now.Ticks;
                            new BulletObject(playerObj.posX, playerObj.posY);
                        }
                    }
                    mapManager.DrawConsole(playerObj, playerObj.IMAGE);
                    Thread.Sleep(playerSpeed);
                }
            }
            PrintGameOver();            
        }
        public static void PrintGameOver()
        {
            StringObject strObj = new StringObject(0, (int)MapSizeInfo.MaxY, "GameOver!!");
            strObj.DrawString();
        }
    }
}
