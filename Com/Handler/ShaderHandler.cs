using System;
using System.Collections.Generic;

namespace Com.Engine
{
    public static class ShaderHandler
    {
        private static Dictionary<string, ShaderProgram> ShaderPrograms = new Dictionary<string, ShaderProgram>();

        public static void Add(string key, ShaderProgram ShaderProgram)
        {
            if (!ShaderPrograms.ContainsKey(key))
            {
                ShaderPrograms.Add(key, ShaderProgram);
            }
            else
            {
                Console.WriteLine($"ShaderProgram mit Schlüssel '{key}' existiert bereits.");
            }
        }

        public static ShaderProgram Get(string key)
        {
            if (ShaderPrograms.ContainsKey(key))
            {
                return ShaderPrograms[key];
            }
            else
            {
                Console.WriteLine($"ShaderProgram mit Schlüssel '{key}' nicht gefunden.");
                return null;
            }
        }

        public static void Delete(string key)
        {
            if (ShaderPrograms.ContainsKey(key))
            {
                ShaderPrograms[key].Delete();
                ShaderPrograms.Remove(key);
            }
            else
            {
                Console.WriteLine($"ShaderProgram mit Schlüssel '{key}' nicht gefunden.");
            }
        }

        public static void Clear()
        {
            foreach (var ShaderProgram in ShaderPrograms.Values)
            {
                ShaderProgram.Delete();
            }
            ShaderPrograms.Clear();
        }
    }
}
