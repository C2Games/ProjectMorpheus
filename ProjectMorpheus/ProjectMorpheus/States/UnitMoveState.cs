using ProjectMorpheus.Units;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus.States
{
    internal class UnitMoveState : State
    {
        private Unit selectedUnit;
        public UnitMoveState(Unit unit) {
            selectedUnit = unit;
        }

        public override void Update(List<KeyboardCommand> keyCommands, List<MouseCommand> mouseCommands) {

        }

        public override void Draw(RenderWindow window) {

        }
    }
}
