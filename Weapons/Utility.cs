using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Enemy;

namespace Trojan_MVP_v1.Weapons
{
    internal static class Utility
    {
        public static int UtilityCode;
        private static string Title;
        private static DateTime _start;
        private static TimeSpan _end;
        private static bool idkHowElseToImplementThis = false;
        private static bool _canStart = false;

        public static void Run()
        {
            Title = "Утилита " + UtilityCode;

            if (!idkHowElseToImplementThis)
            {
                _start = DateTime.Now;
                idkHowElseToImplementThis = true;
            }
            _end = DateTime.Now - _start;
            GameState.CurrentUtilityTitle.Clear();
            GameState.CurrentUtilityTitle.Append(Title);
            GameState.IsUtilityRun = true;

            if (_end.Seconds < 5)
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Проверка наличия критических ошибок.");
            }
            else if (!_canStart)
            {
                idkHowElseToImplementThis = false;
                _canStart = true;
            }
            else
            {
                _canStart = false;
                idkHowElseToImplementThis = false;
                if (ErrorFactory.ErrorCode == 5 && (UtilityCode == 3 || UtilityCode == 4))  // Говнакод пошёл (ну я хз как иначе) 23.10.2025 16:47
                {
                    if (_canStart && !GameState.UtilityHistory[0] && UtilityCode == 4)
                    {
                        GameState.UtilityHistory[0] = true;
                    }
                    if (GameState.UtilityHistory[0] && UtilityCode == 3)
                    {
                        if (GameState.UtilityHistory[1])
                            GameState.UtilityHistory[2] = true;
                        else
                        {
                            GameState.UtilityHistory[1] = true;
                        }
                    }
                }
                GameState.IsUtilityRun = false;
                GameState.CurrentUtility = null;
            }

            if (_canStart) // Ошибки нет, либо не верная утилита
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Не обнаружено.");
            }
            if (_canStart && ErrorFactory.ErrorCode == UtilityCode && GameState.IsErrorRun)
            {
                ErrorFactory.ErrorSolve();
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Исправлено.");
            }
            if (ErrorFactory.ErrorCode == 5 && (UtilityCode == 3 || UtilityCode == 4))
            {
                if (_canStart && !GameState.UtilityHistory[0] && UtilityCode == 4)
                {
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Обнаружена подозрительная активность.");
                }
                if (_canStart &&  GameState.UtilityHistory[0] == true && UtilityCode == 3)
                {
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Обнаружена подозрительная активность.");
                }
                if (_canStart && GameState.UtilityHistory[0] == true && GameState.UtilityHistory[1] && GameState.UtilityHistory[2])
                {
                    for (int i = 0; i < 3; i++)
                        GameState.UtilityHistory[i] = false;

                    ErrorFactory.ErrorSolve();
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Исправлено.");
                }
            }
        }
    }
}
