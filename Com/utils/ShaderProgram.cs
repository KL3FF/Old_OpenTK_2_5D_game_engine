using OpenTK.Graphics.OpenGL4;
namespace Com.Engine
{


    public class ShaderProgram
    {

        public int ID;
        public  ShaderProgram(string vertexShaderFilepath, string fragmentShaderFilepath)
        {
               // ========================
            // Erstellung und Konfiguration des Shader-Programms
            // ========================
            ID = GL.CreateProgram(); // Erstelle ein Shader-Programm

            // --- Vertex Shader ---
            // Erzeuge und lade den Vertex Shader
            int vertexShader = GL.CreateShader(ShaderType.VertexShader);
            // "../../../Com/Shaders/Default.vert"
            GL.ShaderSource(vertexShader, LoadShaderSource(vertexShaderFilepath)); // Lädt den Shader-Quellcode
            GL.CompileShader(vertexShader); // Kompiliere den Shader

            // --- Fragment Shader ---
            // Erzeuge und lade den Fragment Shader
            int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            // "../../../Com/Shaders/Default.frag"
            GL.ShaderSource(fragmentShader, LoadShaderSource(fragmentShaderFilepath)); // Lädt den Fragment-Shader
            GL.CompileShader(fragmentShader); // Kompiliere den Fragment-Shader

            // Anhängen der Shader an das Programm
            GL.AttachShader(ID, vertexShader);
            GL.AttachShader(ID, fragmentShader);
            
            // Linke die Shader
            GL.LinkProgram(ID); 

            // Lösche die Shader, da sie nun im Shader-Programm enthalten sind
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);
        }
    
        public void Bind()
        {
          // Unbinde die Textur
            GL.UseProgram(ID);
        }
        public void Unbind()
        {
            // Unbinde die Textur
            GL.UseProgram(0);
        }
        public void Delete()
        {
            GL.DeleteShader(ID);
        }

        // Hilfsmethode zum Laden des Shader-Quellcodes aus einer Datei
        public static string LoadShaderSource(string filePath)
        {
            string shaderSource = "";

            try
            {
                // Öffnet die Datei und liest den gesamten Inhalt in einen String ein
                using (StreamReader reader = new StreamReader(filePath))
                {
                    shaderSource = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                // Gibt eine Fehlermeldung aus, falls das Laden fehlschlägt
                Console.WriteLine("Fehler beim Laden des Shaders: " + e.Message);
            }

            return shaderSource;
        }
    }

}