using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Com.Engine
{
    public static class ModelHandler
    {

        // Statische Variablen zum Speichern des letzten verwendeten Shaders und Texturen
        private static string lastShader = "";
        private static string lastTexture = "";



        public static void Draw(Matrix4 view, Matrix4 projection, float x, float y, float z, string shader, string texture, Vector2 texStart, Vector2 texEnd)
        {

            // Überprüfen, ob der Shader gewechselt hat
            if ((lastShader != shader) || (lastShader == ""))
            {
                // Binde den neuen Shader
                if (lastShader != ""){
                    ShaderHandler.Unbind(lastShader);
                }
                ShaderHandler.Bind(shader);
                lastShader = shader;  // Speichere den aktuellen Shader
            }
         

            // Überprüfen, ob die Textur gewechselt hat
            if ((lastTexture != texture) || (lastShader == ""))
            {
                // Binde die neue Textur
                if (lastTexture != ""){
                    TextureHandler.Unbind(lastTexture);
                }
                TextureHandler.Bind(texture);
                lastTexture = texture;  // Speichere die aktuelle Textur
            }
        
            // Setze den Uniform-Wert für den Ausschnitt
            int texStartLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "texStart");
            int texEndLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "texEnd");

            GL.Uniform2(texStartLocation, texStart);
            GL.Uniform2(texEndLocation, texEnd);

            // Transformationen für das Modell
            Matrix4 model = Matrix4.Identity;
            Matrix4 translation = Matrix4.CreateTranslation(x, y, z);  // Position für das Modell
            model *= translation;



            // Hole Locations für die Uniforms
            int modelLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "model");
            int viewLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "view");
            int projectionLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "projection");

            // Setze Uniforms
            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            // Zeichne das Modell
            GL.DrawElements(PrimitiveType.Triangles, IndiceHandler.Get("defaultIndice").Count, DrawElementsType.UnsignedInt, 0);
        }
        public static void LastUnbind(){
            if (lastShader != null)
            {
                ShaderHandler.Unbind(lastShader);
     
            }
            if (lastTexture != null)
            {
                TextureHandler.Unbind(lastTexture);
            }
        }


    }
}
