using OpenTK.Graphics.OpenGL;
using StbImageSharp;

namespace Com.Engine
{


    public class Texture
    {
        public int ID;
        public Texture(string filePath)
        {
            ID = GL.GenTexture();
            GL.ActiveTexture(TextureUnit.Texture0); // Aktiviert die Textur-Einheit 0
            GL.BindTexture(TextureTarget.Texture2D, ID); // Binde die Textur

            // Setze die Parameter für die Textur
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat); // Wiederholen der Textur auf der x-Achse
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat); // Wiederholen der Textur auf der y-Achse
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest); // Filter für das Verkleinern
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest); // Filter für das Vergrößern

            // ========================
            // Allgemeine Texturen Laden
            // ========================
            StbImage.stbi_set_flip_vertically_on_load(1); // Stellt sicher, dass Texturen vertikal korrekt geladen werden
            ImageResult testTexture = ImageResult.FromStream(File.OpenRead(filePath), ColorComponents.RedGreenBlueAlpha); // Lädt die Textur

            // Lade die Textur-Daten
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, testTexture.Width, testTexture.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, testTexture.Data);
            // Unbinde die Textur
            Unbind();
        }
    
        public void Bind()
        {
          // Unbinde die Textur
            GL.BindTexture(TextureTarget.Texture2D, ID);
        }
        public void Unbind()
        {
            // Unbinde die Textur
            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
        public void Delete()
        {
            GL.DeleteTexture(ID);
        }


    }

}