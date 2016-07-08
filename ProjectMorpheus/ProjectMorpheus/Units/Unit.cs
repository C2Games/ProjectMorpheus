using ProjectMorpheus.Tiles;
using SFML.Graphics;
using SFML.System;

namespace ProjectMorpheus.Units
{
    internal abstract class Unit
    {
        protected float health;
        protected bool hasMoved;
        protected Teams team;
        protected Teams[] allies;
        protected abstract Sprite unitSprite();
        public abstract UnitType GetUnitType();

        public abstract int GetAttackPower(Unit defender);

        public float GetHealth() {
            return health;
        }

        public void SetHealth(float health) {
            if (health > 10f) {
                health = 10f;
            }
            this.health = health;
        }

        public abstract void Attacked(Unit source);

        public bool HasMoved() {
            return hasMoved;
        }

        public abstract int GetMoveLimit();

        public abstract int GetMoveCost(Tile tile);

        public abstract int GetFuel();

        public abstract int GetAmmo();

        public abstract void GetRange(out int min, out int max);

        public abstract UnitAction[] GetActionsIdle();

        public abstract UnitAction[] GetActionsMoved();
        public virtual void Draw(Vector2f tilePos, RenderWindow window) {
            unitSprite().Position = tilePos;
            window.Draw(unitSprite());
        }
    }
}
