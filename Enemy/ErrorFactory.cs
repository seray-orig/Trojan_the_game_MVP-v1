using System;
using System.Text;
using Trojan_MVP_v1.Core;

namespace Trojan_MVP_v1.Enemy
{
    public static class ErrorFactory
    {
        private static DateTime _start = DateTime.Now;
        private static TimeSpan _end;
        private static DateTime _errorStart;
        public static StringBuilder ErrorTime = new StringBuilder();

        public static int ErrorCode = 0;

        public static int DifficultyLimiter = 0;   // 50+ Переход в Хард мод, 100+ финальная босс ошибка и победа
        private static int spawnrate = 40;
        // Заскриптованные ошибки, которые обязаны вызваться на определённом этапе
        private static bool ErrorOne = true;
        private static bool ErrorFour = true;
        private static bool ErrorFive = true;
        private static bool ErrorTen = true;

        public static StringBuilder Error = new StringBuilder();

        private static void ErrorLogic()
        {
            _end = DateTime.Now - _start;

            if (GameState.IsErrorRun)
                ErrorRun();
            else
                NoErrors();
            
            if (_end.Seconds >= spawnrate)
            {
                DifficultyLimiter+=2;

                if (DifficultyLimiter >= 10 && ErrorOne && !GameState.IsErrorRun)
                {
                    ErrorRun();
                    GameState.IsErrorRun = true;
                    ErrorOne = false;
                }
                else if (DifficultyLimiter >= 40 && ErrorFour && !GameState.IsErrorRun)
                {
                    ErrorRun();
                    GameState.IsErrorRun = true;
                    ErrorFour = false;
                }
                else if (DifficultyLimiter >= 50 && ErrorFive && !GameState.IsErrorRun)
                {
                    ErrorRun();
                    GameState.IsErrorRun = true;
                    ErrorFive = false;
                }
                else if (DifficultyLimiter >= 100 && ErrorTen && !GameState.IsErrorRun)
                {
                    ErrorRun();
                    GameState.IsErrorRun = true;
                    ErrorTen = false;
                }
                else if (Random.Shared.Next(100) >= 60 && !GameState.IsErrorRun)    // Вероятность выпадения ошибки 40%
                {
                    ErrorRun();
                    GameState.IsErrorRun = true;
                }
                spawnrate = 25 - Random.Shared.Next(15);
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
            { 1, new TimeSpan(0, 2, 0) },
            { 2, new TimeSpan(0, 0, 40) },
            { 3, new TimeSpan(0, 1, 20) },
            { 4, new TimeSpan(0, 2, 30) },
            { 5, new TimeSpan(0, 5, 0) },
            { 6, new TimeSpan(0, 1, 30) },
            { 7, new TimeSpan(0, 7, 0) },
            { 8, new TimeSpan(0, 0, 20) },
            { 9, new TimeSpan(0, 2, 30) },
            { 10, new TimeSpan(0, 10, 0) },
        };

        private static void ErrorRun()
        {
            var ErrorList = new List<int>(9);

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
                if (DifficultyLimiter >= 100)
                {

                }
                else if (DifficultyLimiter > 85)
                    ErrorList.Add(9);
                else if (DifficultyLimiter > 75)
                    ErrorList.Add(8);
                else if (DifficultyLimiter >= 70)
                    ErrorList.Add(7);
                else if (DifficultyLimiter > 60)
                    ErrorList.Add(6);
                else if (DifficultyLimiter >= 50)
                {
                    ErrorList.Add(5);
                    if (ErrorFive)
                        ErrorCode = 5;
                }
                else if (DifficultyLimiter >= 30)
                {
                    ErrorList.Add(4);
                    if (ErrorFour)
                        ErrorCode = 4;
                }
                else if (DifficultyLimiter > 20)
                    ErrorList.Add(3);
                else if (DifficultyLimiter > 10)
                    ErrorList.Add(2);
                else if (DifficultyLimiter <= 10)
                {
                    ErrorList.Add(1);
                    if (ErrorOne)
                        ErrorCode = 1;
                }

                if (ErrorCode == 0)
                {
                    ErrorCode = ErrorList[Random.Shared.Next(ErrorList.Count)];
                }

                _errorStart = DateTime.Now;

                Error.Clear();
                Error.Append("Критическая ошибка код: " + ErrorCode);
            }
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
            Error.Append("Ошибок не обнаружено " + spinnerChar[spinnerIndex] + " " + DifficultyLimiter);
        }
    }
}
