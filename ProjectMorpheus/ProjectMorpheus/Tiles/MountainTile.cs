using ProjectMorpheus.Units;
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

        public override bool IsPassable(UnitType type) {
            if (type == UnitType.Vehicle) {
                return false;
            }
            else {
                return true;
            }
        }
    }
}
