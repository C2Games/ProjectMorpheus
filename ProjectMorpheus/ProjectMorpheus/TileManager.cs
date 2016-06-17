using ProjectMorpheus.Tiles;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus
{
    internal static class TileManager
    {
        private static Tile[][] map;
        private static Vector2i size;
        private static Vector2f camera;

        public static void ClearMap(int width, int height) {
            map = new Tile[width][];
            for (int i = 0; i < width; ++i) {
                map[i] = Enumerable.Repeat(new FlatTile(), height).ToArray();
            }

            size.X = width;
            size.Y = height;

            camera.X = width / 2.0f;
            camera.Y = height / 2.0f;
        }

        public static void SetTile(int x, int y, Tile tile) {
            map[x][y] = tile;
        }

        public static Tile GetTile(int x, int y) {
            return map[x][y];
        }

        public static void MoveCameraRelative(float dx, float dy) {
            //TODO: clamp
            camera.X += dx;
            camera.Y += dy;
        }

        public static void MoveCameraAbsolute(float x, float y) {
            camera.X = x;
            camera.Y = y;
        }

        public static void Draw(RenderWindow window) {
            int tileSize = 32; //TODO: not hardcode
            Vector2u windowSize = window.Size;
            int tilingWidth = (int)windowSize.X / tileSize;
            int tilingHeight = (int)windowSize.Y / tileSize;

            int leftIndex = (int)Math.Floor(camera.X / tileSize), rightIndex = leftIndex + tilingWidth+1; //+1 to not show black on the right edge
            int topIndex = (int)Math.Floor(camera.Y / tileSize), bottomIndex = topIndex + tilingHeight+1;

            /*int leftIndex = (int)Math.Floor((camera.X - (windowSize.X / 2.0f)) / tileSize);
            if (leftIndex < 0) leftIndex = 0;
            int rightIndex = (int)Math.Floor((camera.X + (windowSize.X / 2.0f)) / tileSize);
            if (rightIndex >= size.X) rightIndex = size.X - 1;
            int topIndex = (int)Math.Floor((camera.Y - (windowSize.Y / 2.0f)) / tileSize);
            if (topIndex < 0) topIndex = 0;
            int bottomIndex = (int)Math.Floor((camera.Y + (windowSize.Y / 2.0f)) / tileSize);
            if (bottomIndex >= size.Y) bottomIndex = size.Y - 1;*/

            for (int x = leftIndex; x <= rightIndex; ++x) {
                for (int y = topIndex; y <= bottomIndex; ++y) {
                    Vector2f tilePos = new Vector2f(x * tileSize - camera.X, y * tileSize - camera.Y);
                    map[x][y].Draw(tilePos, window);
                }
            }
        }
    }
}
