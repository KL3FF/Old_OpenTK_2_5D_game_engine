using System;
using System.Collections.Generic;

namespace Com.Engine
{
    public static class ShaderHandler
    {
        private static Dictionary<string, ShaderProgram> ShaderPrograms = new Dictionary<string, ShaderProgram>();

        public static void Add(string key, string vertexShaderFilepath, string fragmentShaderFilepath)
        {
            if (!ShaderPrograms.ContainsKey(key))
            {
                ShaderPrograms.Add(key, new ShaderProgram(vertexShaderFilepath, fragmentShaderFilepath));
            }
            else
            {
                Console.WriteLine($"ShaderProgram mit Schlüssel '{key}' existiert bereits.");
            }
        }

        public static ShaderProgram Get(string key)
        {
         
                return ShaderPrograms[key];
          
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
