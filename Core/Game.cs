using Trojan_MVP_v1.Scenes;
using Trojan_MVP_v1.Utilities;

namespace Trojan_MVP_v1.Core
{
    public static class Game
    {
        private const int Tickrate = 30; // тиков в секунду
        private static readonly int _frameTime = 1000 / Tickrate; // миллисекунд между тиками "кадрами"

        public static void Run()
        {
            Initialize();

            GameLoop();
        }

        private static void Initialize()
        {
            ConsoleAPI.LockConsoleWindow();
            Console.Title = "Trojan_MVP_версия-1";
            Console.CursorVisible = false;
            Console.Clear();
        }

        private static void GameLoop()
        {
            while (GameState.IsRunning)
            {
                DateTime frameStart = DateTime.Now;

                InputHandler.HandleInput();
                UpdateSystem.Update();
                Renderer.Render();

                // Подгон под тикрейт
                int elapsed = (int)(DateTime.Now - frameStart).TotalMilliseconds;
                int delay = Math.Max(0, _frameTime - elapsed);
                Thread.Sleep(delay);
            }
        }

        public static void Shutdown()
        {
            GameState.IsRunning = false;
        }
    }
}
