using System.Text;

namespace Trojan_MVP_v1.Core
{
    internal static class Renderer
    {

        private static char _debugRenderSymbol = ' ';   // Любой символ за место пробела, если нужно что-то проверить
        private static char _debugCenterSymbol = ' ';

        public static void Render()
        {
            /* if (GameState.UIChanged) // Похоже уже не нужно
            {
                Console.Clear();
                GameState.PreviousUI = GameState.CurrentUI;
            }*/
            Console.SetCursorPosition(0, 0);
            Console.Write(GameState.PlayerScreen.ToString());
            GameState.PlayerCurrentScreenLength = Console.CursorTop * GameState.ConsoleWidth + Console.CursorLeft;

            // Дописываем пробелы, стирая остатки прошлого экрана (если текста было больше чем в этом рендере)
            Console.Write( new string(_debugRenderSymbol, Math.Max(0, GameState.PlayerLastScreenLength - GameState.PlayerCurrentScreenLength)) );

            GameState.PlayerLastScreenLength = GameState.PlayerCurrentScreenLength;
        }

        public static void Center(List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            GameState.PlayerScreen.Append(_debugCenterSymbol, ((GameState.ConsoleHeight / 2) - (Text.Count / 2 + 1)) * GameState.ConsoleWidth);
            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append(_debugCenterSymbol, (GameState.ConsoleWidth / 2) - (line.Length / 2));
                GameState.PlayerScreen.Append(line);
                // Выглядит фигово, как буд-то можно упростить или типа того
                GameState.PlayerScreen.Append(_debugCenterSymbol, GameState.ConsoleWidth - ( (GameState.ConsoleWidth / 2) - (line.Length / 2) + line.Length));
            }
        }
    }
}
