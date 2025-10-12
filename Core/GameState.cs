using System.Text;
using Trojan_MVP_v1.Scenes;

namespace Trojan_MVP_v1.Core
{
    internal static class GameState
    {
        public static int ConsoleHeight { get; set; } = Console.WindowHeight;
        public static int ConsoleWidth { get; set; } = Console.WindowWidth;
        public static bool IsRunning { get; set; } = true;

        public static int cmdPixels = ConsoleHeight * ConsoleWidth;
        public static StringBuilder PlayerScreen = new StringBuilder(cmdPixels);
        public static int PlayerCurrentScreenLenght = 0;
        public static int PlayerLastScreenLenght = 0;
        public static StringBuilder PlayerInterface = new StringBuilder(cmdPixels);

        public static Action CurrentScene;

        /*  // Похоже уже не нужно
        public static string CurrentUI { get; set; } = "WelcomeScene";
        public static string? PreviousUI { get; set; } = null;

        // Флаг, что интерфейс поменялся
        public static bool UIChanged => PreviousUI != CurrentUI;
        */
    }
}
