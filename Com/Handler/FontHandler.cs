namespace Com.Engine.Library
{
    public static class FontHandler
    {
        private static Dictionary<string, Texture> FontTextures = new();

        public static void RegisterFont(string imageName, string imagePath)
        {
            if (!FontTextures.ContainsKey(imageName))
            {
                Texture texture = new ImgTexture(imagePath);
                FontTextures.Add(imageName, texture);
            }
        }

        public static Texture GetFontTexture(string imageName)
        {
            if (FontTextures.ContainsKey(imageName))
            {
                return FontTextures[imageName];
            }
            else
            {
                throw new Exception($"Font texture '{imageName}' not found.");
            }
        }

        public static void DeleteFont(string imageName)
        {
            if (FontTextures.ContainsKey(imageName))
            {
                FontTextures[imageName].Delete();
                FontTextures.Remove(imageName);
            }
        }

        public static void ClearFonts()
        {
            foreach (var texture in FontTextures.Values)
            {
                texture.Delete();
            }
            FontTextures.Clear();
        }
    }
}
