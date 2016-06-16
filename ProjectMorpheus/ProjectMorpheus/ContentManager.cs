using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMorpheus
{
    internal static class ContentManager
    {
        private static Dictionary<string, Texture> textures;

        public static void Load() {
            textures = new Dictionary<string, Texture>();
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
    }
}
