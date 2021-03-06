﻿using ProjectMorpheus.Tiles;
using SFML.Graphics;
using SFML.System;
using System;
using System.Linq;

namespace ProjectMorpheus
{
    internal static class TileManager
    {
        private static Tile[][] map;
        private static Vector2i mapSize;

        public static Vector2f Camera { get; private set; }

        public static void ClearMap(int width, int height) {
            map = new Tile[width][];
            for (int i = 0; i < width; ++i) {
                map[i] = Enumerable.Repeat(new FlatTile(), height).ToArray();
            }

            mapSize.X = width;
            mapSize.Y = height;

            //TODO: not hardcode tilesize
            Camera = new Vector2f(32 * width / 2, 32 * height / 2);
        }

        public static void SetTile(int x, int y, Tile tile) {
            map[x][y] = tile;
        }

        public static Tile GetTile(int x, int y) {
            return map[x][y];
        }

        public static Tile Click(int x, int y) {
            return null;
        }

        public static void MoveCameraRelative(float dx, float dy) {
            //TODO: clamp
            Camera = new Vector2f(Camera.X + dx, Camera.Y + dy);
        }

        public static void MoveCameraAbsolute(float x, float y) {
            Camera = new Vector2f(x, y);
        }

        public static void Draw(RenderWindow window) {
            int tileSize = 32; //TODO: not hardcode
            Vector2u windowSize = window.Size;
            int tilingWidth = (int)windowSize.X / tileSize;
            int tilingHeight = (int)windowSize.Y / tileSize;

            int leftIndex = (int)Math.Floor(Camera.X / tileSize);
            if (leftIndex < 0) leftIndex = 0;
            int rightIndex = leftIndex + tilingWidth + 1;
            if (rightIndex >= mapSize.X) rightIndex = mapSize.X - 1;
            int topIndex = (int)Math.Floor(Camera.Y / tileSize);
            if (topIndex < 0) topIndex = 0;
            int bottomIndex = topIndex + tilingHeight + 1;
            if (bottomIndex >= mapSize.Y) bottomIndex = mapSize.Y - 1;

            for (int x = leftIndex; x <= rightIndex; ++x) {
                for (int y = topIndex; y <= bottomIndex; ++y) {
                    Vector2f tilePos = new Vector2f(x * tileSize - Camera.X, y * tileSize - Camera.Y);
                    map[x][y].Draw(tilePos, window);
                }
            }
        }
    }
}
