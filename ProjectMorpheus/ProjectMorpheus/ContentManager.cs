using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace ProjectMorpheus
{
    internal static class ContentManager
    {
        private static Dictionary<string, Texture> textures;
        private static Dictionary<string, Font> fonts;

        public static void Load() {
            textures = new Dictionary<string, Texture>();
            fonts = new Dictionary<string, Font>();
        }

        public static void LoadTexture(string filename, string texname) {
            textures.Add(texname, new Texture(filename));
        }

        public static Texture GetTexture(string texname) {
            if (!textures.ContainsKey(texname)) {
                throw new ArgumentException("No such texture loaded.");
            }

            return textures[texname];
        }

        public static void LoadFont(string filename, string fontname) {
            fonts.Add(fontname, new Font(filename));
        }

        public static Font GetFont(string fontname) {
            if (!fonts.ContainsKey(fontname)) {
                throw new ArgumentException("No such font loaded.");
            }

            return fonts[fontname];
        }
    }
}
