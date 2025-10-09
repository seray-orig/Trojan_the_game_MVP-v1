using System.Text;

namespace Trojan_MVP_v1.Core
{
    internal static class Renderer
    {
        public static void Render()
        {
            if (GameState.UIChanged)
            {
                Console.Clear();
                GameState.PreviousUI = GameState.CurrentUI;
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(GameState.PlayerScreen.ToString());
        }

        public static void Center(List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            GameState.PlayerScreen.Append('\n', (GameState.ConsoleHeight / 2) - Text.Count);
            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append(' ', (GameState.ConsoleWidth / 2) - (line.Length / 2));
                GameState.PlayerScreen.Append(line+'\n');
            }
        }
    }
}
