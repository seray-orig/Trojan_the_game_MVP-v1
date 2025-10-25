using Trojan_MVP_v1.Core;
using Trojan_MVP_v1.Enemy;

namespace Trojan_MVP_v1.Weapons
{
    internal static class Utility
    {
        public static int UtilityCode;
        private static List<bool> UtilityHistory = new List<bool>(2) { false, false };
        private static string Title;
        private static DateTime _start;
        private static TimeSpan _end;
        private static bool idkHowElseToImplementThis = false;
        private static bool _canStart = false;
        private static bool _errSolve = false;
        private static bool err10 = false;
        private static bool err10_2 = true;

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
                if (ErrorFactory.ErrorCode == 5 && (UtilityCode == 3 || UtilityCode == 4))  // Говнакод пошёл (ну я хз как иначе) 23.10.2025 16:47
                {
                    if (_canStart && !UtilityHistory[0] && UtilityCode == 4)
                    {
                        UtilityHistory[0] = true;
                    }
                    if (UtilityHistory[0] && UtilityCode == 3)
                    {
                        UtilityHistory[1] = true;
                    }
                }
                if (ErrorFactory.ErrorCode == 6 && (UtilityCode == 2 || UtilityCode == 1))
                {
                    if (_canStart && !UtilityHistory[0] && UtilityCode == 2)
                    {
                        UtilityHistory[0] = true;
                    }
                    if (UtilityHistory[0] && UtilityCode == 1)
                    {
                        UtilityHistory[1] = true;
                    }
                }

                _canStart = false;
                _errSolve = false;
                idkHowElseToImplementThis = false;
                GameState.IsUtilityRun = false;
                GameState.CurrentUtility = null;
            }

            if (_canStart) // Если ошибки нет, либо не верная утилита
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Не обнаружено.");
            }
            if (_canStart && ErrorFactory.ErrorCode == UtilityCode && GameState.IsErrorRun)
            {
                ErrorFactory.ErrorSolve();
                _errSolve = true;
            }
            if (ErrorFactory.ErrorCode == 5 && (UtilityCode == 3 || UtilityCode == 4))
            {
                if (_canStart && !UtilityHistory[0] && UtilityCode == 4)
                {
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Обнаружена подозрительная активность.");
                }
                if (_canStart &&  UtilityHistory[0] && !UtilityHistory[1] && UtilityCode == 3)
                {
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Обнаружена подозрительная активность.");
                }
                if (_canStart && UtilityHistory[0] && UtilityHistory[1] && UtilityCode == 3)
                {
                    for (int i = 0; i < 2; i++)
                        UtilityHistory[i] = false;

                    ErrorFactory.ErrorSolve();
                    _errSolve = true;
                }
            }
            if (ErrorFactory.ErrorCode == 6 && (UtilityCode == 2 || UtilityCode == 1))
            {
                if (_canStart && !UtilityHistory[0] && UtilityCode == 2)
                {
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Обнаружена подозрительная активность.");
                }
                if (_canStart && UtilityHistory[0] && !UtilityHistory[1] && UtilityCode == 1)
                {
                    GameState.CurrentUtilityText.Clear();
                    GameState.CurrentUtilityText.Append("Обнаружена подозрительная активность.");
                }
                if (_canStart && UtilityHistory[0] && UtilityHistory[1] && UtilityCode == 1)
                {
                    for (int i = 0; i < 2; i++)
                        UtilityHistory[i] = false;

                    ErrorFactory.ErrorSolve();
                    _errSolve = true;
                }
            }
            if (UtilityCode != 5)
                err10 = false;
            if (err10 || ErrorFactory.ErrorCode == 10 && UtilityCode == 5)
            {
                GameState.CurrentUtilityTitle.Clear();
                GameState.CurrentUtilityTitle.Append("Змейка");
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Змейка съела нолик");
                ErrorFactory.ErrorCode = 1;
                if (err10_2)
                {
                    ErrorFactory._errorStart = DateTime.Now;
                    err10_2 = false;
                }
                err10 = true;
            }
            else if (ErrorFactory.ErrorCode != 10 && UtilityCode == 5)
            {
                GameState.CurrentUtilityTitle.Clear();
                GameState.CurrentUtilityTitle.Append("Змейка");
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Игра не работает");
            }
            if (_errSolve)
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Исправлено.");
            }
        }
    }
}
