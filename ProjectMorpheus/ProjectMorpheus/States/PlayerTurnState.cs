using ProjectMorpheus.Units;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus.States
{
    internal class PlayerTurnState : State
    {
        private Teams team;

        public PlayerTurnState(Teams team) {
            this.team = team;
        }

        private float cameraDx = 0;
        private float cameraDy = 0;

        public override void Update(List<KeyboardCommand> keyCommands, List<MouseCommand> mouseCommands) {

            foreach (KeyboardCommand k in keyCommands) {
                if (k.Key == Keyboard.Key.A && k.Pressed) cameraDx += -2;
                else if (k.Key == Keyboard.Key.D && k.Pressed) cameraDx += 2;
                else if (k.Key == Keyboard.Key.W && k.Pressed) cameraDy += -2;
                else if (k.Key == Keyboard.Key.S && k.Pressed) cameraDy += 2;

                if (k.Key == Keyboard.Key.A && !k.Pressed) cameraDx -= -2;
                else if (k.Key == Keyboard.Key.D && !k.Pressed) cameraDx -= 2;
                else if (k.Key == Keyboard.Key.W && !k.Pressed) cameraDy -= -2;
                else if (k.Key == Keyboard.Key.S && !k.Pressed) cameraDy -= 2;
                //TODO: menus, etc
            }

            foreach (MouseCommand m in mouseCommands) {
                //TODO: Update terrain info (mouse move)
                //(maybe highlight tile)
                // mouse camera scrolling

                if (m.Button == Mouse.Button.Left && m.Pressed) {

                    Unit selected = UnitManager.Click(m.Location.X, m.Location.Y);
                    if (selected != null) {
                        StateManager.AddState(new UnitMoveState(selected));
                        continue;
                    }

                    //do buildings
                }
            }

            TileManager.MoveCameraRelative(cameraDx, cameraDy);

        }

        public override void Draw(RenderWindow window) {

        }
    }
}
