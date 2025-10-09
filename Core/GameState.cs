using System.Text;
using Trojan_MVP_v1.Scenes;

namespace Trojan_MVP_v1.Core
{
    internal static class GameState
    {
        public static int ConsoleHeight { get; set; } = Console.WindowHeight;
        public static int ConsoleWidth { get; set; } = Console.WindowWidth;
        public static bool IsRunning { get; set; } = true;
        public static StringBuilder PlayerScreen = new StringBuilder();
        public static StringBuilder PlayerInterface = new StringBuilder();
        public static Action CurrentScene;

        public static string CurrentUI { get; set; } = "WelcomeScene";
        public static string? PreviousUI { get; set; } = null;

        // Флаг, что интерфейс поменялся
        public static bool UIChanged => PreviousUI != CurrentUI;
    }
}
