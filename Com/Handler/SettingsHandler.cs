using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
public static class SettingsHandler
{
    public static bool IsFullscreen = false;
    public static bool IsVSyncEnabled = true;
    public static int FPS = 60;
    public static int ViewWidth = 1280;
    public static int ViewHeight = 720;


    public static int RenderWidth = 1280;
    public static int RenderHeight = 720;



    public static bool IsBorderless = false;

    public static void SaveSettings()
    {
        string filePath = GetSettingsPath();


        var settings = new List<string>
        {
            $"Fullscreen={IsFullscreen}",
            $"VSync={IsVSyncEnabled}",
            $"FPS={FPS}",
            $"ViewWidth={ViewWidth}",
            $"ViewHeight={ViewHeight}",
            $"RenderWidth={RenderWidth}",
            $"RenderHeight={RenderHeight}",
            $"BorderlessFullscreen={IsBorderless}"
        };

        try
        {
            File.WriteAllLines(filePath, settings);
            Console.WriteLine($"Fullscreen: {IsFullscreen}, VSync: {IsVSyncEnabled}, FPS: {FPS}, ViewWidth: {ViewWidth}, ViewHeight: {ViewHeight}, RenderWidth: {RenderWidth}, RenderHeight: {RenderHeight}, Borderless: {IsBorderless}");
            Console.WriteLine("Settings gespeichert.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
        }
    }


    public static void LoadSettings(GameWindow gwindow)
    {
        string filePath = GetSettingsPath();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Keine Settings gefunden. Erstelle Standarddatei.");
            SaveSettings(); // Speichern der Standardwerte
            return; // Abbrechen, um zu verhindern, dass wir mit einer leeren Datei fortfahren
        }

        try
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('=');
                if (parts.Length != 2) continue;

                string key = parts[0].Trim();
                string value = parts[1].Trim();

                try
                {
                    switch (key)
                    {
                        case "ViewWidth":
                            ViewWidth = int.Parse(value);
                            break;

                        case "ViewHeight":
                            ViewHeight = int.Parse(value);
                            break;

                        case "RenderWidth":
                            RenderWidth = int.Parse(value); // Korrektur: hier RenderWidth statt ViewWidth
                            break;

                        case "RenderHeight":
                            RenderHeight = int.Parse(value); // Korrektur: hier RenderHeight statt ViewHeight
                            break;

                        case "BorderlessFullscreen":
                            IsBorderless = bool.Parse(value);
                            gwindow.WindowBorder = IsBorderless ? WindowBorder.Hidden : WindowBorder.Resizable;
                            break;

                        case "Fullscreen":
                            IsFullscreen = bool.Parse(value);
                            gwindow.WindowState = IsFullscreen ? WindowState.Fullscreen : WindowState.Normal;
                            break;

                        case "VSync":
                            IsVSyncEnabled = bool.Parse(value);
                            gwindow.VSync = IsVSyncEnabled ? VSyncMode.On : VSyncMode.Off;
                            break;

                        case "FPS":
                            FPS = int.Parse(value);
                            gwindow.UpdateFrequency = FPS;
                            break;

                        default:
                            Console.WriteLine($"Unbekannter Key: {key}. Erstelle Standardsettings.");
                            SaveSettings(); // Speichern der Standardwerte
                            return; // Sofort abbrechen, wenn ein unbekannter Key gefunden wird
                    }
                       gwindow.ClientSize = new Vector2i(ViewWidth, ViewHeight);
                    Console.WriteLine($"Fullscreen: {IsFullscreen}, VSync: {IsVSyncEnabled}, FPS: {FPS}, ViewWidth: {ViewWidth}, ViewHeight: {ViewHeight}, RenderWidth: {RenderWidth}, RenderHeight: {RenderHeight}, Borderless: {IsBorderless}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler beim Verarbeiten der Zeile '{line}': {ex.Message}");
                    SaveSettings(); // Speichern der Standardwerte
                    return; // Sofort abbrechen, wenn ein Fehler auftritt
                }
            }

            Console.WriteLine("Settings geladen.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden der Settings-Datei: {ex.Message}");
            SaveSettings(); // Speichern der Standardwerte
        }
    }

    public static void Fullscreen(GameWindow gwindow)
    {
        IsFullscreen = !IsFullscreen;
        gwindow.WindowState = IsFullscreen ? WindowState.Fullscreen : WindowState.Normal;
        SaveSettings();
    }

    public static void Borderless(GameWindow gwindow)
    {
        IsBorderless = !IsBorderless;
        gwindow.WindowBorder = IsBorderless ? WindowBorder.Hidden : WindowBorder.Resizable;
        SaveSettings();
    }
    public static void VSync(GameWindow gwindow)
    {

        IsVSyncEnabled = !IsVSyncEnabled;
        gwindow.VSync = IsVSyncEnabled ? VSyncMode.On : VSyncMode.Off;
        SaveSettings();
    }





    public static void SetFPS(GameWindow gwindow, int fps)
    {
        switch (fps)
        {
            case 0:
                FPS = 0;
                gwindow.UpdateFrequency = 0;
                break;
            case 30:
            case 60:
            case 90:
            case 120:
            case 144:
                FPS = fps;
                gwindow.UpdateFrequency = fps;

                break;

            case -1:
                FPS = 0;
                gwindow.UpdateFrequency = 0;
                break;

            default:
                FPS = 30;
                gwindow.UpdateFrequency = 30;
                break;
        }

        SaveSettings();
    }

    public static void PrintSettings()
    {
        // Gibt alle Einstellungen in einer Zeile aus
        //Console.Clear();
        //Console.WriteLine(FPS);

        //Console.WriteLine($"Fullscreen: {IsFullscreen}, VSync: {IsVSyncEnabled}, FPS: {FPS}, ViewWidth: {ViewWidth}, ViewHeight: {ViewHeight}, RenderWidth: {RenderWidth}, RenderHeight: {RenderHeight}, Borderless: {IsBorderless}");
    }

    private static string GetSettingsPath()
    {
        string folder = "";

        if (OperatingSystem.IsWindows())
            folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        else if (OperatingSystem.IsLinux())
            folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config");
        else if (OperatingSystem.IsMacOS())
            folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Library/Application Support");

        folder = Path.Combine(folder, "ComEngine");

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
            Console.WriteLine("Settings Ordner erstellt.");
        }

        string filePath = Path.Combine(folder, "settings.txt");

        if (!File.Exists(filePath))
        {
            File.Create(filePath).Close();
            Console.WriteLine("Settings Datei erstellt.");
        }

        return filePath;
    }
}
