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
        }

        public static ShaderProgram Get(string key)
        {
            return ShaderPrograms[key];
        }

        public static void Clear()
        {
            foreach (var ShaderProgram in ShaderPrograms.Values)
            {
                ShaderProgram.Delete();
            }
            ShaderPrograms.Clear();
        }

        public static void Bind(string key)
        {
            // Unbinde die Textur
            Get(key).Bind();
        }
        public static void Unbind(string key)
        {

            Get(key).Unbind();
        }
        public static void Delete(string key)
        {
            Get(key).Delete();
            ShaderPrograms.Remove(key);
        }

    }
}
