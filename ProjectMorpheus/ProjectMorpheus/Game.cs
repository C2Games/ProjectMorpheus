using ProjectMorpheus.Tiles;
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

            window.KeyPressed += InputManager.OnKeyPressed;
            window.KeyReleased += InputManager.OnKeyReleased;
            window.MouseButtonPressed += InputManager.OnMousePressed;
            window.MouseButtonReleased += InputManager.OnMouseReleased;
            window.MouseMoved += InputManager.OnMouseMoved;

            window.Closed += OnClosed;
        }

        private static HashSet<Keyboard.Key> debug = new HashSet<Keyboard.Key>();

        private static bool debugLeft = false;
        private static bool debugRight = false;
        private static bool debugUp = false;
        private static bool debugDown = false;

        private static void Update() {
            while (InputManager.KeyAvailable()) {
                KeyboardCommand kc = InputManager.GetKeyCommand();
                switch (kc.Key) {
                    case Keyboard.Key.A:
                        debugLeft = kc.Pressed;
                        break;
                    case Keyboard.Key.D:
                        debugRight = kc.Pressed;
                        break;
                    case Keyboard.Key.W:
                        debugUp = kc.Pressed;
                        break;
                    case Keyboard.Key.S:
                        debugDown = kc.Pressed;
                        break;
                }
            }

            if (debugLeft) TileManager.MoveCameraRelative(-32 / 30f, 0);
            if (debugRight) TileManager.MoveCameraRelative(32 / 30f, 0);
            if (debugUp) TileManager.MoveCameraRelative(0, -32 / 30f);
            if (debugDown) TileManager.MoveCameraRelative(0, 32 / 30f);
        }

        private static void Draw() {
            window.Clear();

            //Text info = new Text();
            //info.Font = ContentManager.GetFont("testfont");
            //info.Position = new Vector2f(0, 0);
            //info.Color = Color.White;
            //StringBuilder sb = new StringBuilder();
            //sb.Append(string.Format("{0} : {1}\n", InputManager.GetMouseLocation().X, InputManager.GetMouseLocation().Y));
            //foreach (Keyboard.Key k in debug) {
            //    sb.Append(k.ToString());
            //}
            //info.DisplayedString = sb.ToString();
            //window.Draw(info);

            TileManager.Draw(window);
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
