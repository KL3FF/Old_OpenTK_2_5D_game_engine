using OpenTK.Graphics.OpenGL;  // OpenGL API für Rendering
using StbImageSharp;          // Bildlade-Bibliothek (PNG, JPG, etc.)
using FreeTypeSharp;          // Für Schriftarten (FreeType)
using System.IO;              // Für Datei-Handling (File.OpenRead)

namespace Com.Engine.Library
{
    // Basisklasse für alle Texturen
    public abstract class Texture
    {
        public abstract void Bind();    // Textur aktivieren
        public abstract void Unbind();  // Textur deaktivieren
        public abstract void Delete();  // Textur aus dem Speicher löschen
    }

    // Normale Bild-Textur (PNG, JPG, etc.)
    public class ImgTexture : Texture
    {
        public int ID;  // OpenGL-Textur-ID

        public ImgTexture(string filePath)
        {
            // 1. Textur-Objekt erstellen
            ID = GL.GenTexture();
            GL.ActiveTexture(TextureUnit.Texture0);        // TextureUnit 0 aktivieren
            GL.BindTexture(TextureTarget.Texture2D, ID);   // Textur binden

            // 2. Textur-Parameter setzen
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);  // X-Richtung
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);  // Y-Richtung
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest); // Pixelige Textur
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            // 3. Bild-Datei laden
            StbImage.stbi_set_flip_vertically_on_load(1);  // Bild umdrehen (OpenGL hat y-Achse oben)
            var image = ImageResult.FromStream(File.OpenRead(filePath), ColorComponents.RedGreenBlueAlpha); // Bild laden

            // 4. Bild in OpenGL-Textur umwandeln
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);

            Unbind();  // Textur wieder deaktivieren
        }

        public override void Bind() => GL.BindTexture(TextureTarget.Texture2D, ID);  // Textur aktivieren
        public override void Unbind() => GL.BindTexture(TextureTarget.Texture2D, 0); // Textur deaktivieren
        public override void Delete() => GL.DeleteTexture(ID);                       // Textur aus VRAM löschen
    }

    // text-Textur (Glyphen Texturen zu einer Textur kombinieren)
    public class TextTexture : Texture
    {
        public int ID;

        public TextTexture(string text)
        {
            List<Glyph> glyphs = new List<Glyph>();  // Liste für Speichern für Glypen 
            int totalTextWidth = 0;                      // Gesamte Breite des Textes
            int maxHeight = 0;                       // Höchster Buchstabe

            // 🔎 Über jeden Buchstaben iterieren
            foreach (char character in text)
            {
                if (GlyphHandler.Glyphs.TryGetValue(character, out var glyph)) // Glyph im Dictionary suchen
                {
                    glyphs.Add(glyph);
                    totalTextWidth += glyph.XAdvance;   // Breite zur Gesamtbreite addieren // TODO nochmal überlegen und in betracht ziehen das wir auch einen zeilen umbruch prüfen müssen
                    maxHeight = Math.Max(maxHeight, glyph.Height); // Höhe aktualisieren
                }
            }

            // 1. Textur erstellen
            ID = GL.GenTexture();
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.Texture2D, ID);

            // 2. Texturparameter setzen
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            // 3. Leere Textur erstellen
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, totalTextWidth, maxHeight, 0, PixelFormat.Rgba, PixelType.UnsignedByte, IntPtr.Zero);

            int currentX = 0;  // Startpunkt X

            // Glyphen zeichnen
            foreach (var glyph in glyphs)
            {
                // var texture = FontHandler.GetFontTexture(glyph.ImageName);  // Glyph-Textur holen
                // texture.Bind();

                // // Die Glyphen Textur auf die finale Textur kopieren
                // GL.CopyTexSubImage2D(TextureTarget.Texture2D, 0, currentX, 0, 0, 0, glyph.Width, glyph.Height);

                // currentX += glyph.XAdvance; // X-Position verschieben
            }

            Unbind(); // Textur wieder deaktivieren
        }

        public override void Bind() => GL.BindTexture(TextureTarget.Texture2D, ID);
        public override void Unbind() => GL.BindTexture(TextureTarget.Texture2D, 0);
        public override void Delete() => GL.DeleteTexture(ID);
    }
}
