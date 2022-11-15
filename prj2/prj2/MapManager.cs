using System;
using System.Runtime.CompilerServices;


namespace prj2
{
    enum MapSizeInfo
    {
        MaxX = 58,
        MaxY = 20
    }
    class MapManager
    {

        char[,] map = new char[(int)MapSizeInfo.MaxY + 2, (int)MapSizeInfo.MaxX + 1];   //\n
        private static MapManager mapManager = null;
        private MapManager() { }

        public static MapManager CreateMapManager()
        {
            if (mapManager == null)
            {
                mapManager = new MapManager();
                mapManager.setNewField();
            }
            return mapManager;
        }

        private void setNewField()        // 기능 추가시 Get함수로 바꾸고, 배열 프린트 하는 함수 추가하기 
        {
            char x = ' ';
            for (int i = 0; i < (int)MapSizeInfo.MaxY; i++)
            {
                map[i, 0] = '|';
                if (i == (int)MapSizeInfo.MaxY - 1)
                {
                    x = '-';
                }
                for (int j = 1; j < (int)MapSizeInfo.MaxX; j++)
                {
                    map[i, j] = x;
                }
                map[i, (int)MapSizeInfo.MaxX - 1] = '|';
                map[i, (int)MapSizeInfo.MaxX] = '\n';
            }
        }

        public void printAllField()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
            }
        }

        public void insertObj(GameObject obj, string img)
        {
            char[] cImg = img.ToCharArray();
            for (int i = 0; i < cImg.Length; i++)
            {
                map[obj.posY, obj.posX - obj.IMAGE_SIZE + i] = cImg[i];
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DrawConsole(GameObject obj, string img)
        {
            
            Console.SetCursorPosition(obj.posX - obj.IMAGE_SIZE, obj.posY);
            Console.ForegroundColor = obj.COLOR;
            insertObj(obj, img);
            for (int i = 0; i < img.Length; i++)
            {
                Console.Write(map[obj.posY, obj.posX - obj.IMAGE_SIZE + i]);
            }
        }

        public void ClearField()
        {
            for(int i = 1; i < (int)MapSizeInfo.MaxY; i++)
            {
                for (int j = 0; j < (int)MapSizeInfo.MaxX - 1; j++)
                {
                    map[i, j] = ' ';
                }
            }
        }

        public bool checkObj(int x, int y)
        {
            if (map[y, x] != ' ')
            {
                return true;
            }
            return false;
        }
    }
}
