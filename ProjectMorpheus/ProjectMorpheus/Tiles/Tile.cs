using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus.Tiles
{
    internal class Tile
    {
        protected const int tileSize = 32;

        protected abstract Sprite tileSprite();

        public abstract int GetDefenseValue();

        public abstract int GetMoveCost();

        public abstract bool IsInfantryPassable();

        public abstract bool IsVehiclePassable();

        public abstract bool IsAirPassable();

        public void Draw(Vector2f tilePos, RenderWindow window) {
            tileSprite().Position = tilePos;
            window.Draw(tileSprite());
        }
    }
}
