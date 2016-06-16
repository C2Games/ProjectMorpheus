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
        private int frame = 0;

        private abstract int animationLength();

        public void Draw(Vector2f tilePos, RenderWindow window) {
            base.Draw(tilePos, window);
            frame++;
            IntRect rect = tileSprite().TextureRect;
            rect.Left = frame * tileSize;
            tileSprite().TextureRect = rect;
        }
    }
}
