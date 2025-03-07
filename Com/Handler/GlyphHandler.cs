using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace Com.Engine.Library
{
    public static class GlyphHandler
    {
        // Dictionary von char -> Glyph
        public static Dictionary<int, Glyph> Glyphs = new Dictionary<int, Glyph>();

        // FNT-Datei laden und in Glyphs speichern
        public static void LoadFnt(string path)
        {
            try
            {
                // JSON-Daten aus der Datei lesen
                string json = File.ReadAllText(path);

                // JSON in eine Liste von Glyph-Objekten deserialisieren
                List<Glyph>? glyphs = JsonSerializer.Deserialize<List<Glyph>>(json);

                if (glyphs != null)
                {
                    // Alle Glyphen in das Dictionary einfügen
                    foreach (var glyph in glyphs)
                    {
                        // Die ID in ein char umwandeln und als Schlüssel verwenden
                        Glyphs[glyph.ID] = new Glyph(glyph.ID, glyph.X, glyph.Y, glyph.Width, glyph.Height, glyph.XOffset, glyph.YOffset, glyph.XAdvance);
                    }
                }
                else
                {
                    Console.WriteLine("Fehler: Die JSON-Daten konnten nicht deserialisiert werden.");
                }
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Fehler beim Deserialisieren der JSON-Daten: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Fehler beim Lesen der Datei: {e.Message}");
            }
        }
        public static void Clear()
        {
            Glyphs.Clear();
        }
        public static Glyph Get(int key)
        {
            return Glyphs[key];
        }

    }

    // Glyph-Struct, der die Eigenschaften eines Glyphen beschreibt
    public struct Glyph
    {
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int XOffset { get; set; }
        public int YOffset { get; set; }
        public int XAdvance { get; set; }

        // Konstruktor für Glyphen
        public Glyph(int id, int x, int y, int width, int height, int xoffset, int yoffset, int xadvance)
        {
            ID = id;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            XOffset = xoffset;
            YOffset = yoffset;
            XAdvance = xadvance;
        }
    }
}
