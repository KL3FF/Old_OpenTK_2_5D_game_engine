using System;
using System.Collections.Generic;

namespace Com.Engine
{
    public static class TextureHandler
    {
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

        public static void AddTexture(string key, Texture texture)
        {
            if (!textures.ContainsKey(key))
            {
                textures.Add(key, texture);
            }
            else
            {
                Console.WriteLine($"Texture mit Schlüssel '{key}' existiert bereits.");
            }
        }

        public static Texture GetTexture(string key)
        {
            if (textures.ContainsKey(key))
            {
                return textures[key];
            }
            else
            {
                Console.WriteLine($"Texture mit Schlüssel '{key}' nicht gefunden.");
                return null;
            }
        }

        public static void DeleteTexture(string key)
        {
            if (textures.ContainsKey(key))
            {
                textures[key].Delete();
                textures.Remove(key);
            }
            else
            {
                Console.WriteLine($"Texture mit Schlüssel '{key}' nicht gefunden.");
            }
        }

        public static void Clear()
        {
            foreach (var texture in textures.Values)
            {
                texture.Delete();
            }
            textures.Clear();
        }
    }
}
