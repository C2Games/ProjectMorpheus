using SFML.Window;

namespace ProjectMorpheus
{
    internal class KeyboardCommand
    {
        public Keyboard.Key Key { get; private set; }

        public bool Pressed { get; private set; }

        public KeyboardCommand(Keyboard.Key key, bool pressed) {
            Key = key;
            Pressed = pressed;
        }
    }
}
