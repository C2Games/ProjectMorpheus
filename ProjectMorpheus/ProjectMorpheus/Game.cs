using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus
{
    public abstract class Game
    {
        public static void Main(String[] args)
        {
            Game.Test();
            
        }
        public abstract void Update(Time elapsed);

        public static void Test() {
            RenderWindow window = new RenderWindow(new VideoMode(400, 400), "Test");
            window.KeyPressed += keypresstest;
            window.Closed += OnClosed;

            while (window.IsOpen) {
                window.Clear();
                window.DispatchEvents();
                window.Display();
            }
        }

        private static void keypresstest(object sender, KeyEventArgs e) {
            Console.Write(e.Code.ToString());
        }

        private static void OnClosed(object sender, EventArgs e) {
            (sender as RenderWindow).Close();
        }
    }
}
