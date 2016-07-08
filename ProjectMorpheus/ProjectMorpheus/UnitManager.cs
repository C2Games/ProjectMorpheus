using ProjectMorpheus.Units;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus
{
    internal static class UnitManager
    {
        private static Unit[][] map;

        public static void ClearMap(int width, int height) {
            map = new Unit[width][];
            for (int i = 0; i < width; ++i) {
                map[i] = Enumerable.Repeat<Unit>(null, height).ToArray();
            }
        }

        public static void PlaceUnit(int x, int y, Unit unit) {
            map[x][y] = unit;
        }

        public static Unit GetUnit(int x, int y) {
            return map[x][y];
        }

        public static void Draw(RenderWindow window) {
            
        }

        public static Unit Click(int x, int y) {
            return null;
        }
    }
}
