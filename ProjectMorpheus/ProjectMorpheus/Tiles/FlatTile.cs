using SFML.Graphics;

namespace ProjectMorpheus.Tiles
{
    internal class FlatTile : Tile
    {
        private static Sprite sprite;

        public FlatTile() {
            if (sprite == null) {
                sprite = new Sprite(ContentManager.GetTexture("texture_flattile"));
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
            return true;
        }

        public override bool IsAirPassable() {
            return true;
        }
    }
}
