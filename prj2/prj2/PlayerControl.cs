using System;
using System.Threading;
namespace prj2
{
    enum EKeyCode
    {
        Left = 0x25,
        Up,
        Right,
        Down,
        Space = 0x20
    }
    static class PlayerControl
    {
        private const int KEY_PRESSED = 0x8000;

        public static bool IsKeyDown(EKeyCode key)
        {
            return (GetKeyState((int)key) & KEY_PRESSED) != 0;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(int key);
    }
}
