using SFML.Audio;
using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace ProjectMorpheus
{
    internal static class ContentManager
    {
        private static Dictionary<string, Texture> textures;
        private static Dictionary<string, Font> fonts;
        private static Dictionary<string, SoundBuffer> soundBuffers;

        public static void Load() {
            textures = new Dictionary<string, Texture>();
            fonts = new Dictionary<string, Font>();
            soundBuffers = new Dictionary<string, SoundBuffer>();
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

        public static void LoadSound(string filename, string soundname) {
            soundBuffers.Add(soundname, new SoundBuffer(filename));
        }

        public static SoundBuffer GetSound(string soundname) {
            if (!soundBuffers.ContainsKey(soundname)) {
                throw new ArgumentException("No such sound loaded.");
            }
            return soundBuffers[soundname];
        }


    }
}
