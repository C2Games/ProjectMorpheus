using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace ProjectMorpheus
{
    public abstract class Game
    {
        private static RenderWindow window;

        public static void Main(String[] args) {
            Game.Load();
            Game.GameLoop();
        }

        private static void Load() {
            window = new RenderWindow(new VideoMode(400, 400), "Test");

            window.KeyPressed += InputManager.OnKeyPressed;
            window.KeyReleased += InputManager.OnKeyReleased;
            window.MouseButtonPressed += InputManager.OnMousePressed;
            window.MouseButtonReleased += InputManager.OnMouseReleased;
            window.MouseMoved += InputManager.OnMouseMoved;

            window.Closed += OnClosed;
        }

        public abstract void Update(Time elapsed);

        private static void GameLoop() {
            while (window.IsOpen) {
                window.Clear();
                window.DispatchEvents();
                window.Display();
            }
        }

        private static void OnClosed(object sender, EventArgs e) {
            (sender as RenderWindow).Close();
        }
    }
}
