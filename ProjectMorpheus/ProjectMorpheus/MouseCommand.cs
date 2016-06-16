using SFML.System;
using SFML.Window;

namespace ProjectMorpheus
{
    internal class MouseCommand
    {
        public Mouse.Button Button { get; private set; }

        public bool Pressed { get; private set; }

        public Vector2i Location { get; private set; }

        public MouseCommand(Mouse.Button button, bool pressed, Vector2i location) {
            Button = button;
            Pressed = pressed;
            Location = location;
        }
    }
}
