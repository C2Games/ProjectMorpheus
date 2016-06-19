using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace ProjectMorpheus
{
    internal static class InputManager
    {
        private static Queue<KeyboardCommand> keyboardQueue;
        private static Queue<MouseCommand> mouseQueue;
        private static Vector2i mouseLocation;

        public static void Load() {
            keyboardQueue = new Queue<KeyboardCommand>();
            mouseQueue = new Queue<MouseCommand>();
            mouseLocation = new Vector2i(0, 0);
        }

        public static void OnKeyPressed(object sender, KeyEventArgs e) {
            keyboardQueue.Enqueue(new KeyboardCommand(e.Code, true));
        }

        public static void OnKeyReleased(object sender, KeyEventArgs e) {
            keyboardQueue.Enqueue(new KeyboardCommand(e.Code, false));
        }

        public static void OnMousePressed(object sender, MouseButtonEventArgs e) {
            mouseQueue.Enqueue(new MouseCommand(e.Button, true, new Vector2i(e.X, e.Y)));
        }

        public static void OnMouseReleased(object sender, MouseButtonEventArgs e) {
            mouseQueue.Enqueue(new MouseCommand(e.Button, false, new Vector2i(e.X, e.Y)));
        }

        public static void OnMouseMoved(object sender, MouseMoveEventArgs e) {
            mouseLocation.X = e.X;
            mouseLocation.Y = e.Y;
        }

        public static bool KeyAvailable() {
            return keyboardQueue.Count > 0;
        }

        public static KeyboardCommand PeekKeyCommand() {
            return keyboardQueue.Peek();
        }

        public static KeyboardCommand GetKeyCommand() {
            return keyboardQueue.Dequeue();
        }

        public static bool MouseAvailable() {
            return keyboardQueue.Count > 0;
        }

        public static MouseCommand PeekMouseCommand() {
            return mouseQueue.Peek();
        }

        public static MouseCommand GetMouseCommand() {
            return mouseQueue.Dequeue();
        }

        public static Vector2i GetMouseLocation() {
            return mouseLocation;
        }
    }
}
