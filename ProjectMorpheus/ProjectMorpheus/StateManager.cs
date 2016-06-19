using ProjectMorpheus.States;
using SFML.Graphics;
using System.Collections.Generic;

namespace ProjectMorpheus
{
    internal static class StateManager
    {
        private static Stack<State> states;

        private static State currentState {
            get {
                return states.Peek();
            }
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

        public static void Update() {
            currentState.Update();
        }

        public static void Draw(RenderWindow window) {
            currentState.Draw(window);
        }
    }
}
