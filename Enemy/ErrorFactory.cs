using System;
using System.Text;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Enemy
{
    public static class ErrorFactory
    {
        private static DateTime _start = DateTime.Now;  // Хрень начала отсчёта, что бы вычислить _end
        private static TimeSpan _end;                   // Хрень что бы вычислить больше ли она spawnrate
        private static DateTime _errorStart;    // Обратный отсчёт на решение ошибки, не успел - бан
        public static StringBuilder Error = new StringBuilder();
        public static StringBuilder ErrorTime = new StringBuilder();

        public static int ErrorCode = 0;
        private static TimeSpan spawnrate = new TimeSpan(0, 1, 0);  // Первая ошибка появится спустя минуту, для всех остальных значение изменится
        private static List<int> ErrorList = new List<int>() // Здесь заскриптованная последовательность ошибок
        {
            1, 2, 3, 2, 4, 1, 5
        };

        private static void ErrorLogic()
        {
            _end = DateTime.Now - _start;

            if (GameState.IsErrorRun)
            {
                _start = DateTime.Now;
                ErrorRun();
            }
            else
                NoErrors();
            
            if (_end >= spawnrate && !GameState.IsErrorRun)
            {
                ErrorRun();
                GameState.IsErrorRun = true;
                spawnrate = new TimeSpan(0, 0, 25);
                _start = DateTime.Now;
            }
        }

        public static void CheckError()
        {
            ErrorLogic();
        }

        // Здесь задаётся время даваемое для исправления ошибки соответственно её коду
        private static Dictionary<int, TimeSpan> ErrorProperties = new Dictionary<int, TimeSpan>()
        {
            { 1, new TimeSpan(0, 1, 0) },
            { 2, new TimeSpan(0, 0, 30) },
            { 3, new TimeSpan(0, 1, 0) },
            { 4, new TimeSpan(0, 1, 0) },
            { 5, new TimeSpan(0, 2, 0) },
            { 6, new TimeSpan(0, 1, 30) },
            { 7, new TimeSpan(0, 7, 0) },
            { 8, new TimeSpan(0, 0, 20) },
            { 9, new TimeSpan(0, 2, 30) },
            { 10, new TimeSpan(0, 10, 0) },
        };

        private static void ErrorRun()
        {
            if (GameState.IsErrorRun) // Обновляем ошибку, если она уже существует
            {
                Error.Clear();
                Error.Append("Критическая ошибка код: " + ErrorCode);

                ErrorTime.Clear();
                ErrorTime.Append( $"{(ErrorProperties[ErrorCode] - (DateTime.Now - _errorStart)):mm\\:ss}" );

                if (ErrorProperties[ErrorCode] - (DateTime.Now - _errorStart) <= TimeSpan.Zero)
                    UpdateSystem.NextScene();
            }
            else    // Создаём новую ошибку
            {
                ErrorCode = ErrorList[0];

                _errorStart = DateTime.Now;

                Error.Clear();
                Error.Append("Критическая ошибка код: " + ErrorCode);
            }
        }

        public static void ErrorSolve()
        {
            if (ErrorList.Count > 0)
                ErrorList.RemoveAt(0);
            else
                UpdateSystem.NextScene();

            GameState.ErrorsWereSolved++;
            GameState.IsErrorRun = false;
            ErrorTime.Clear();
        }

        private static readonly string[] spinnerChar = new string[] { "|", "/", "-", "\\" };
        private static int spinnerIndex = 0;
        private static void NoErrors()
        {
            if (GameState.CurrentFrame < 11)
                GameState.CurrentFrame++;
            else
                GameState.CurrentFrame = 1;

            if (GameState.CurrentFrame % 5 == 0)
            {
                spinnerIndex = (spinnerIndex + 1) % spinnerChar.Length;
            }

            Error.Clear();
            Error.Append("Ошибок не обнаружено " + spinnerChar[spinnerIndex]);
        }
    }
}
