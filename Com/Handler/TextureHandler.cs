using System;
using System.Collections.Generic;

namespace Com.Engine
{
    public static class TextureHandler
    {
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

        public static void Add(string key, string filepath)
        {
            if (!textures.ContainsKey(key))
            {
                textures.Add(key, new Texture(filepath));
            }
            else
            {
                Console.WriteLine($"Texture mit Schlüssel '{key}' existiert bereits.");
            }
        }

        public static Texture Get(string key)
        {
         
                return textures[key];
          
        }

        public static void Delete(string key)
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
