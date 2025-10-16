using System.Text;
using Trojan_MVP_v1.Enemy;
using Trojan_MVP_v1.Interfaces;
using Trojan_MVP_v1.Scenes;

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
            //"Welcome",
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
                    Renderer.BuildUtility();
                    InputHandler.CurrentKeyHandler = Utilities.HotKeys;
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

        }
    }
}
