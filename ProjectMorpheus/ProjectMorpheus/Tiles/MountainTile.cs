using SFML.Graphics;

namespace ProjectMorpheus.Tiles
{
    internal class MountainTile : Tile
    {
        private static Sprite sprite;

        public MountainTile() {
            if (sprite == null) {
                sprite = new Sprite(ContentManager.GetTexture("texture_mountaintile"));
            }
        }

        protected override Sprite tileSprite() {
            return sprite;
        }

        public override int GetDefenseValue() {
            return 0; //TODO
        }

        public override bool IsInfantryPassable() {
            return true;
        }

        public override bool IsVehiclePassable() {
            return false;
        }

        public override bool IsAirPassable() {
            return true;
        }
    }
}
