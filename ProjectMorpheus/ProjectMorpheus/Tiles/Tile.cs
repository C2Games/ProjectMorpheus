using SFML.Graphics;
using SFML.System;

namespace ProjectMorpheus.Tiles
{
    internal abstract class Tile
    {
        protected const int tileSize = 32;

        protected abstract Sprite tileSprite();

        public abstract int GetDefenseValue();

        public abstract bool IsInfantryPassable();

        public abstract bool IsVehiclePassable();

        public abstract bool IsAirPassable();

        public virtual void Draw(Vector2f tilePos, RenderWindow window) {
            tileSprite().Position = tilePos;
            window.Draw(tileSprite());
        }
    }
}
