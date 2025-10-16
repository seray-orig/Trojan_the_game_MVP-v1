using System.ComponentModel.Design;
using System.Text;

namespace Trojan_MVP_v1.Core
{
    internal static class Renderer
    {

        private static char _debugRenderSymbol = ' ';   // Любой символ за место пробела, если нужно что-то проверить
        private static char _debugInternalSymbol = ' ';

        public static void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(GameState.PlayerScreen.ToString());
            GameState.PlayerCurrentScreenLength = Console.CursorTop * GameState.ConsoleWidth + Console.CursorLeft;

            // Убираем остатки прошлого экрана, если текста было больше чем в этом рендере
            Console.Write(new string(_debugRenderSymbol, Math.Max(0, GameState.PlayerLastScreenLength - GameState.PlayerCurrentScreenLength)) );

            GameState.PlayerLastScreenLength = GameState.PlayerCurrentScreenLength;
        }

        public static void Center(List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            GameState.PlayerScreen.Append(_debugInternalSymbol, ((GameState.ConsoleHeight / 2) - (Text.Count / 2 + 1)) * GameState.ConsoleWidth);
            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleWidth / 2) - (line.Length / 2));
                GameState.PlayerScreen.Append(line);
                CompleteTheString();
            }
        }

        public static void BuildBasic(List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            CompleteTheString();
            int xPos = 0;
            int yPos = 0;
            int padding = 3; // расстояние между элементами

            foreach (var hotkey in Text)
            {
                // Если элемент не помещается на текущую строку — перенос
                if (xPos + hotkey.Length > GameState.ConsoleWidth)
                {
                    CompleteTheString();
                    yPos++; xPos = 0;
                }

                // Добавляем отступ, если не в начале строки
                if (xPos > 0)
                {
                    GameState.PlayerScreen.Append(new string(_debugInternalSymbol, padding));
                    xPos += padding;
                }
                GameState.PlayerScreen.Append(new string(_debugInternalSymbol, padding));
                xPos += padding;
                GameState.PlayerScreen.Append(hotkey);
                xPos += hotkey.Length;
            }

            // Разделительная линия под интерфейсом
            CompleteTheString();
            GameState.PlayerScreen.Append(new string('_', GameState.ConsoleWidth));
        }

        public static void BuildManual(string Title, List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            CompleteTheString();

            GameState.PlayerScreen.Append( new string(_debugInternalSymbol, 3) + Title);
            CompleteTheString();

            for (int i = 0; i < 3; i++)
                CompleteTheString();

            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append( new string(_debugInternalSymbol, 3) + line );
                CompleteTheString();
            }
        }

        public static void BuildError(List<string> Text)
        {
            GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleHeight / 2 - 
                (GameState.PlayerScreen.Length / GameState.ConsoleWidth)) * GameState.ConsoleWidth);
            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleWidth / 2) - (line.Length / 2));
                GameState.PlayerScreen.Append(line);
                CompleteTheString();
            }
        }

        // Завершает строку пустотой
        private static void CompleteTheString()
        {
            GameState.PlayerScreen.Append( new string(_debugInternalSymbol, GameState.ConsoleWidth - (GameState.PlayerScreen.Length % GameState.ConsoleWidth)) );
        }
    }
}
