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
        private static bool _solve = false;

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
                _solve = false;
                idkHowElseToImplementThis = false;
                GameState.IsUtilityRun = false;
                GameState.CurrentUtility = null;
            }

            if (_solve || (_canStart && ErrorFactory.ErrorCode == UtilityCode && GameState.IsErrorRun))
            {
                if (!_solve)
                {
                    ErrorFactory.ErrorSolve();
                }

                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Исправлено.");
                _solve = true;
            }
            else if (_canStart)
            {
                GameState.CurrentUtilityText.Clear();
                GameState.CurrentUtilityText.Append("Не обнаружено.");
            }
        }
    }
}
