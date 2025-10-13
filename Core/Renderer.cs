using System.Text;

namespace Trojan_MVP_v1.Core
{
    internal static class Renderer
    {

        private static char _debugRenderSymbol = ' ';   // Любой символ за место пробела, если нужно что-то проверить
        private static char _debugCenterSymbol = ' ';

        public static void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(GameState.PlayerScreen.ToString());
            GameState.PlayerCurrentScreenLength = Console.CursorTop * GameState.ConsoleWidth + Console.CursorLeft;
            // Убираем остатки прошлого экрана, если текста было больше чем в этом рендере
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

        public static void BuildInterface(List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            GameState.PlayerScreen.Append(EmptyString());
            int xPos = 0;
            int yPos = 0;
            int padding = 3; // расстояние между элементами

            foreach (var hotkey in Text)
            {
                // Если элемент не помещается на текущую строку — перенос
                if (xPos + hotkey.Length > GameState.ConsoleWidth)
                {
                    GameState.PlayerScreen.AppendLine();
                    yPos++; xPos = 0;
                }

                // Добавляем отступ, если не в начале строки
                if (xPos > 0)
                {
                    GameState.PlayerScreen.Append(new string(' ', padding));
                    xPos += padding;
                }
                GameState.PlayerScreen.Append(new string(' ', padding));
                xPos += padding;
                GameState.PlayerScreen.Append(hotkey);
                xPos += hotkey.Length;
            }

            // Разделительная линия под интерфейсом
            GameState.PlayerScreen.AppendLine();
            GameState.PlayerScreen.Append(new string('_', GameState.ConsoleWidth));
        }

        private static string EmptyString()
        {
            return new string(' ', GameState.ConsoleWidth);
        }
    }
}
