using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectMorpheus
{
    public static class Game
    {
        private static RenderWindow window;
        private const double MillisecondsPerUpdate = (1.0 / 60.0) * 1000.0;

        public static void Main(String[] args) {
            Game.Load();
            Game.GameLoop();
        }

        private static void Load() {
            ContentManager.Load();
            InputManager.Load();

            ContentManager.LoadFont(@"C:\Windows\Fonts\BAUHS93.ttf", "testfont");

            window = new RenderWindow(new VideoMode(400, 400), "Test");

            window.KeyPressed += InputManager.OnKeyPressed;
            window.KeyReleased += InputManager.OnKeyReleased;
            window.MouseButtonPressed += InputManager.OnMousePressed;
            window.MouseButtonReleased += InputManager.OnMouseReleased;
            window.MouseMoved += InputManager.OnMouseMoved;

            window.Closed += OnClosed;
        }

        private static HashSet<Keyboard.Key> debug = new HashSet<Keyboard.Key>();

        private static void Update() {
            while (InputManager.KeyAvailable()) {
                KeyboardCommand kc = InputManager.GetKeyCommand();
                if (kc.Pressed) {
                    debug.Add(kc.Key);
                }
                else {
                    debug.Remove(kc.Key);
                }
            }
        }

        private static void Draw() {
            window.Clear();

            Text info = new Text();
            info.Font = ContentManager.GetFont("testfont");
            info.Position = new Vector2f(0, 0);
            info.Color = Color.White;
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0} : {1}\n", InputManager.GetMouseLocation().X, InputManager.GetMouseLocation().Y));
            foreach (Keyboard.Key k in debug) {
                sb.Append(k.ToString());
            }
            info.DisplayedString = sb.ToString();
            window.Draw(info);
            window.Display();
        }

        private static void GameLoop() {
            Clock clock = new Clock();
            double previous = clock.ElapsedTime.AsMilliseconds();
            double lag = 0.0;

            while (window.IsOpen) {
                double current = clock.ElapsedTime.AsMilliseconds();
                double elapsed = current - previous;
                previous = current;
                lag += elapsed;

                window.DispatchEvents();

                while (lag >= MillisecondsPerUpdate) {
                    Update();
                    lag -= MillisecondsPerUpdate;
                }

                Draw();
            }
        }

        private static void OnClosed(object sender, EventArgs e) {
            (sender as RenderWindow).Close();
        }
    }
}
