using ProjectMorpheus.States;
using SFML.Graphics;
using System.Collections.Generic;

namespace ProjectMorpheus
{
    internal static class StateManager
    {
        private static Stack<State> states;

        public static State CurrentState() {
            return states.Peek();
        }

        public static void Load() {
            states = new Stack<State>();
        }

        public static void AddState(State state) {
            states.Push(state);
        }

        public static void PopState() {
            states.Pop();
        }

        public static void ReplaceState(State state) {
            states.Pop();
            states.Push(state);
        }

        public static void Update(List<KeyboardCommand> keyCommands, List<MouseCommand> mouseCommands) {
            CurrentState().Update(keyCommands, mouseCommands);
        }

        public static void Draw(RenderWindow window) {
            CurrentState().Draw(window);
        }
    }
}
