using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus.Tiles
{
    internal abstract class AnimatedTile : Tile
    {
        protected int frame = 0;
        protected IntRect rect = new IntRect(0, 0, tileSize, tileSize);

        protected abstract int animationLength();

        public override void Draw(Vector2f tilePos, RenderWindow window) {
            base.Draw(tilePos, window);

            frame = (frame + 1) % animationLength();
            rect.Left = frame * tileSize;
            tileSprite().TextureRect = rect;
        }
    }
}
