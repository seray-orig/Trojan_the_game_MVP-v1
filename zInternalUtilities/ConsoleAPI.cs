using System.Runtime.InteropServices;

namespace Trojan_MVP_v1.InternalUtilities
{

    public static class ConsoleAPI
    {
        // --- WinAPI ---
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        private const int GWL_STYLE = -16;
        private const int WS_SIZEBOX = 0x00040000;
        private const int WS_MAXIMIZEBOX = 0x00010000;
        private const uint SC_CLOSE = 0xF060;
        private const uint MF_GRAYED = 0x00000001;

        public static void LockConsoleWindow()
        {
           IntPtr consoleHandle = GetConsoleWindow();

            // Убираем возможность менять размер или разворачивать окно
            int style = GetWindowLong(consoleHandle, GWL_STYLE);
            style &= ~WS_SIZEBOX;
            style &= ~WS_MAXIMIZEBOX;
            SetWindowLong(consoleHandle, GWL_STYLE, style);
        }
    }

}