using SFML.Graphics;

namespace ProjectMorpheus.States
{
    internal abstract class State
    {
        public abstract void Update();

        public abstract void Draw(RenderWindow window);
    }
}
