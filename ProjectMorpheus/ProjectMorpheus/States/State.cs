using SFML.Graphics;
using System.Collections.Generic;

namespace ProjectMorpheus.States
{
    internal abstract class State
    {
        public abstract void Update(List<KeyboardCommand> keyCommands, List<MouseCommand> mouseCommands);

        public abstract void Draw(RenderWindow window);
    }
}
