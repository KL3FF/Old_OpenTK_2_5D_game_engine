namespace Com.Engine
{
    public static class TextureHandler
    {
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();

        public static void Add(string key, string filepath)
        {
       
                textures.Add(key, new Texture(filepath));
          
        }

        public static Texture Get(string key)
        {
            return textures[key];
        }

        public static void Clear()
        {
            foreach (var texture in textures.Values)
            {
                texture.Delete();
            }
            textures.Clear();
        }
        public static void Bind(string key)
        {
            // Unbinde die Textur
            Get(key).Bind();
        }
        public static void Unbind(string key)
        {
            // Unbinde die Textur
            Get(key).Unbind();
        }
        public static void Delete(string key)
        {
            Get(key).Delete();
            textures.Remove(key);
        }




    }
}
