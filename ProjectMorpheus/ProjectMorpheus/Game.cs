using ProjectMorpheus.States;
using ProjectMorpheus.Tiles;
using ProjectMorpheus.Units;
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

            ContentManager.LoadFont(@"C:\Windows\Fonts\Arial.ttf", "testfont");
            ContentManager.LoadTexture(@"C:\Users\Chris\Desktop\textest.png", "texture_flattile");

            TileManager.ClearMap(100, 100);
            for (int x = 0; x < 100; ++x) {
                for (int y = 0; y < 100; ++y) {
                    TileManager.SetTile(x, y, new FlatTile());
                }
            }

            window = new RenderWindow(new VideoMode(400, 400), "Test");
            window.SetKeyRepeatEnabled(false);

            window.KeyPressed += InputManager.OnKeyPressed;
            window.KeyReleased += InputManager.OnKeyReleased;
            window.MouseButtonPressed += InputManager.OnMousePressed;
            window.MouseButtonReleased += InputManager.OnMouseReleased;
            window.MouseMoved += InputManager.OnMouseMoved;

            window.Resized += OnResized;
            window.Closed += OnClosed;

            StateManager.Load();
            StateManager.AddState(new PlayerTurnState(Teams.Placeholder1));
        }

        private static HashSet<Keyboard.Key> debug = new HashSet<Keyboard.Key>();

        private static bool debugLeft = false;
        private static bool debugRight = false;
        private static bool debugUp = false;
        private static bool debugDown = false;

        private static void Update() {
            List<KeyboardCommand> keys = new List<KeyboardCommand>(InputManager.GetKeyCommands());
            List<MouseCommand> mouse = new List<MouseCommand>(InputManager.GetMouseCommands());
            StateManager.Update(keys, mouse);
        }

        private static void Draw() {
            window.Clear();

            TileManager.Draw(window);
            StateManager.Draw(window);
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

        private static void OnResized(object sender, SizeEventArgs e) {
            (sender as RenderWindow).SetView(new View(new FloatRect(0, 0, e.Width, e.Height)));
        }

        private static void OnClosed(object sender, EventArgs e) {
            (sender as RenderWindow).Close();
        }
    }
}
