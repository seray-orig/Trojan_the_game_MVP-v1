namespace Trojan_MVP_v1.Core
{
    internal static class InputHandler
    {
        // Делегат, который будет указывать на метод обработки нажатий
        public static Action<ConsoleKey>? CurrentKeyHandler;

        public static void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.Escape)
                {
                    Game.Shutdown();
                    break;
                }

                CurrentKeyHandler?.Invoke(key);
            }
        }
    }
}