using System.ComponentModel.Design;
using System.Globalization;
using System.Text;
using Trojan_MVP_v1.Interfaces;

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

            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append( new string(_debugInternalSymbol, 3) + line );
                CompleteTheString();
            }
        }

        public static void BuildError(List<string> Text)
        {
            CompleteTheString();
            GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
            GameState.PlayerScreen.Append("Проблем исправлено сегодня: " + GameState.ErrorsWereSolved);
            CompleteTheString();

            GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleHeight / 2 - 
                (GameState.PlayerScreen.Length / GameState.ConsoleWidth)) * GameState.ConsoleWidth);
            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleWidth / 2) - (line.Length / 2));
                GameState.PlayerScreen.Append(line);
                CompleteTheString();
            }
        }

        public static void BuildUtilitiesInterface(string Title, List<string> Text)
        {
            GameState.PlayerScreen.Clear();
            CompleteTheString();

            GameState.PlayerScreen.Append(new string(_debugInternalSymbol, 3) + Title);
            CompleteTheString();

            GameState.PlayerScreen.Append(_debugInternalSymbol, ((GameState.ConsoleHeight / 2) - (Text.Count / 2 + 1)) * GameState.ConsoleWidth);
            foreach (var line in Text)
            {
                GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleWidth / 2) - (line.Length / 2));
                GameState.PlayerScreen.Append(line);
                CompleteTheString();
            }
        }

        public static void BuildUtility()
        {
            GameState.PlayerScreen.Append(_debugInternalSymbol, (GameState.ConsoleHeight - 12 -
                (GameState.PlayerScreen.Length / GameState.ConsoleWidth)) * GameState.ConsoleWidth);
            GameState.PlayerScreen.Append(new string('_', GameState.ConsoleWidth));
            CompleteTheString();

            GameState.PlayerScreen.Append(new string(_debugInternalSymbol, 3) + GameState.CurrentUtilityTitle);
            CompleteTheString();

            GameState.PlayerScreen.Append(_debugInternalSymbol, ( (GameState.ConsoleHeight - 2 -
                GameState.PlayerScreen.Length / GameState.ConsoleWidth) / 2 ) * GameState.ConsoleWidth);
            GameState.PlayerScreen.Append(_debugInternalSymbol, GameState.ConsoleWidth / 2 - GameState.CurrentUtilityText.Length / 2);
            GameState.PlayerScreen.Append(GameState.CurrentUtilityText);
        }

        public static void BuildEmail(string Title, List<string> EngiText, List<string> UrText)
        {
            GameState.PlayerScreen.Clear();
            CompleteTheString();
            GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
            GameState.PlayerScreen.Append(Title);
            CompleteTheString();
            GameState.PlayerScreen.Append(new string('_', GameState.ConsoleWidth));
            CompleteTheString();

            if (GameState.emailState >= 0)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[0]);
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[1]);
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[2]);
                CompleteTheString();
            }
            if (GameState.emailState >= 1)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, GameState.ConsoleWidth - 10 - UrText[0].Length);
                GameState.PlayerScreen.Append(UrText[0]);
                CompleteTheString();
            }
            if (GameState.emailState >= 2)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[3]);
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[4]);
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[5]);
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[6]);
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[7]);
                CompleteTheString();
            }
            if (GameState.emailState >= 3)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, GameState.ConsoleWidth - 10 - UrText[1].Length);
                GameState.PlayerScreen.Append(UrText[1]);
                CompleteTheString();
            }
            if (GameState.emailState >= 4)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[8]);
                CompleteTheString();
            }
            if (GameState.emailState >= 5)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[9]);
                CompleteTheString();
            }
            if (GameState.emailState >= 6)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, GameState.ConsoleWidth - 10 - UrText[2].Length);
                GameState.PlayerScreen.Append(UrText[2]);
                CompleteTheString();
            }
            if (GameState.emailState >= 7)
            {
                CompleteTheString();
                GameState.PlayerScreen.Append(_debugInternalSymbol, 3);
                GameState.PlayerScreen.Append(EngiText[10]);
                CompleteTheString();
            }

            if (Email.showEnterButton)
            {
                GameState.PlayerScreen.Append(_debugInternalSymbol, GameState.ConsoleHeight * GameState.ConsoleWidth -
                    GameState.PlayerScreen.Length - GameState.ConsoleWidth * 3);
                GameState.PlayerScreen.Append(_debugInternalSymbol, GameState.ConsoleWidth - 10 - "Enter".Length);
                GameState.PlayerScreen.Append("Enter");
                CompleteTheString();
            }
        }

        // Завершает строку пустотой
        public static void CompleteTheString()
        {
            GameState.PlayerScreen.Append( new string(_debugInternalSymbol, GameState.ConsoleWidth - (GameState.PlayerScreen.Length % GameState.ConsoleWidth)) );
        }
    }
}
