using System.Text;
using Trojan_MVP_v1.Enemy;
using Trojan_MVP_v1.Interfaces;
using Trojan_MVP_v1.Scenes;
using Trojan_MVP_v1.Weapons;

namespace Trojan_MVP_v1.Core
{
    internal static class UpdateSystem
    {
        public static void Update()
        {
            UpdateSceneState();
        }

        ////////////////////////////////////////////////////////
        //                                                    //
        //                       Сцены                        //
        //                                                    //
        ////////////////////////////////////////////////////////
        private static Dictionary<string, Action> Scenes = new Dictionary<string, Action>
        {
            {
                "Welcome",
                () =>
                {
                    Renderer.Center(Welcome.Text);
                    InputHandler.CurrentKeyHandler = Welcome.HotKeys;
                }
            },

            {
                "Workplace",
                () =>
                {
                    UpdateInterface();
                    UpdateError();
                    UpdateUtility();
                }
            },
            {
                "GameOver",
                () =>
                {
                    Renderer.Center(GameOver.Text);
                }
            }
        };

        private static List<string> SceneOrder = new List<string>
        {
            "Welcome",
            "Workplace",
            "GameOver"
        };

        private static byte CurrentScene = 0;

        private static void UpdateSceneState()
        {
            Scenes[SceneOrder[CurrentScene]].Invoke();
        }

        public static void NextScene()
        {
            CurrentScene++;
        }

        ////////////////////////////////////////////////////////
        //                                                    //
        //                      Интерфейсы                    //
        //                                                    //
        ////////////////////////////////////////////////////////
        private static Dictionary<string, Action> Interfaces = new Dictionary<string, Action>()
        {
            {
                "Basic",
                () =>
                {
                    Renderer.BuildBasic(Basic.Text);
                    InputHandler.CurrentKeyHandler = Basic.HotKeys;
                }
            },
            {
                "Manual",
                () =>
                {
                    Renderer.BuildManual(Manual.BuildTitle(), Manual.Text);
                    InputHandler.CurrentKeyHandler = Manual.HotKeys;
                }
            },
            {
                "Utilities",
                () =>
                {
                    Renderer.BuildUtilitiesInterface(Utilities.BuildTitle(), Utilities.Text);
                    InputHandler.CurrentKeyHandler = Utilities.HotKeys;
                }
            },
            {
                "Email",
                () =>
                {
                    Renderer.BuildEmail(Email.Title, Email.EngiText, Email.UrText);
                    InputHandler.CurrentKeyHandler = Email.HotKeys;
                }
            },
        };

        private static StringBuilder CurrentInterface = new StringBuilder("Basic");

        public static void SetInterface(string Interface)
        {
            CurrentInterface.Clear();
            CurrentInterface.Append(Interface);
        }

        private static void UpdateInterface()
        {
            Interfaces[CurrentInterface.ToString()].Invoke();
        }

        ////////////////////////////////////////////////////////
        //                                                    //
        //                       Ошибки                       //
        //                                                    //
        ////////////////////////////////////////////////////////
        private static void UpdateError()
        {
            ErrorFactory.CheckError();
            if (CurrentInterface.ToString() == "Basic")
                Renderer.BuildError(new List<string>() { ErrorFactory.Error.ToString(), ErrorFactory.ErrorTime.ToString() });
        }

        ////////////////////////////////////////////////////////
        //                                                    //
        //                      Утилиты                       //
        //                                                    //
        ////////////////////////////////////////////////////////
        private static void UpdateUtility()
        {
            if (GameState.CurrentUtility != null)
                GameState.CurrentUtility.Invoke();
            if (CurrentInterface.ToString() == "Basic" && GameState.IsUtilityRun)
                Renderer.BuildUtility();

            // Логика почтового ящика и 7-й ошибки
            if (Email.showEnterButton)
            {
                GameState._emailStart = DateTime.Now;
            }
            else
            {
                if (DateTime.Now - GameState._emailStart >= new TimeSpan(0, 0, 15))
                {
                    if (GameState.emailState == 3)
                    {
                        Basic.Text[2] = ("P - Открыть почтовый ящик*");
                        GameState._emailStart = DateTime.Now;
                        GameState.emailState++;
                    }
                    else if (GameState.emailState == 5)
                    {
                        Basic.Text[2] = ("P - Открыть почтовый ящик*");
                        GameState._emailStart = DateTime.Now;
                        GameState.emailState++;
                    }
                    else if (GameState.emailState >= 6)
                    {
                        if (GameState.emailState == 6)
                            Basic.Text[2] = ("P - Открыть почтовый ящик*");
                        GameState.emailState = 7;
                        GameState._emailStart = DateTime.Now;
                    }
                    else
                    {
                        Basic.Text[2] = ("P - Открыть почтовый ящик*");
                        Email.showEnterButton = true;
                        GameState.emailState++;
                        if (GameState.emailState == 5)
                            ErrorFactory.ErrorSolve();
                    }
                }
            }
        }
    }
}
