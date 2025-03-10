using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Com.Engine.Library
{
    public static class ModelHandler
    {

        // Statische Variablen zum Speichern des letzten verwendeten Shaders und Texturen
        private static string lastShader = "";
        private static string lastTexture = "";



        public static void Draw(ref Matrix4 view, ref Matrix4 projection, float x, float y, float z, float width, float height, float angle, string shader, string texture, Vector2 texStart, Vector2 texEnd)
        {

            
            // Überprüfen, ob der Shader gewechselt hat
            if ((lastShader != shader) || (lastShader == ""))
            {
                // Binde den neuen Shader
                // if (lastShader != ""){
                //     ShaderHandler.Unbind(lastShader);
                // }
                ShaderHandler.Bind(shader);
                lastShader = shader;  // Speichere den aktuellen Shader
                ShaderHandler.lastShader = lastShader;
            }

            // Überprüfen, ob die Textur gewechselt hat
            if ((lastTexture != texture) || (lastShader == ""))
            {
                // Binde die neue Textur
                // if (lastTexture != ""){
                //     TextureHandler.Unbind(lastTexture);
                // }
                TextureHandler.Bind(texture);
                lastTexture = texture;  // Speichere die aktuelle Textur
                TextureHandler.lastTexture = lastTexture;
            }
            int shaderID = ShaderHandler.Get(shader).ID;


            // Setze den Uniform-Wert für den Ausschnitt
            int texStartLocation = GL.GetUniformLocation(shaderID, "texStart");
            int texEndLocation = GL.GetUniformLocation(shaderID, "texEnd");

            GL.Uniform2(texStartLocation, texStart);
            GL.Uniform2(texEndLocation, texEnd);

            // Transformationen für das Modell  rotation * scaling * große
            Matrix4 model = Matrix4.CreateScale(width / 128, height / 128, 0f) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-angle)) * Matrix4.CreateTranslation(x / 128, y / 128, -10.0f + (z / 128));

            // Hole Locations für die Uniforms
            int modelLocation = GL.GetUniformLocation(shaderID, "model");
            int viewLocation = GL.GetUniformLocation(shaderID, "view");
            int projectionLocation = GL.GetUniformLocation(shaderID, "projection");

            // Setze Uniforms
            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            // Zeichne das Modell
            GL.DrawElements(PrimitiveType.Triangles, IndiceHandler.Get("defaultIndice").Count, DrawElementsType.UnsignedInt, 0);

        }


        public static void DrawGui(ref Matrix4 view, ref Matrix4 projection, float x, float y, float width, float height, float angle, string shader, string texture, Vector2 texStart, Vector2 texEnd)
        {
            // Überprüfen, ob der Shader gewechselt hat
            if ((lastShader != shader) || (lastShader == ""))
            {
                // Binde den neuen Shader
                // if (lastShader != ""){
                //     ShaderHandler.Unbind(lastShader);
                // }
                ShaderHandler.Bind(shader);
                lastShader = shader;  // Speichere den aktuellen Shader
                ShaderHandler.lastShader = lastShader;
            }

            // Überprüfen, ob die Textur gewechselt hat
            if ((lastTexture != texture) || (lastShader == ""))
            {
                // Binde die neue Textur
                // if (lastTexture != ""){
                //     TextureHandler.Unbind(lastTexture);
                // }
                TextureHandler.Bind(texture);
                lastTexture = texture;  // Speichere die aktuelle Textur
                TextureHandler.lastTexture = lastTexture;
            }
            int shaderID = ShaderHandler.Get(shader).ID;
            // Setze den Uniform-Wert für den Ausschnitt
            int texStartLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "texStart");
            int texEndLocation = GL.GetUniformLocation(ShaderHandler.Get(shader).ID, "texEnd");

            GL.Uniform2(texStartLocation, texStart);
            GL.Uniform2(texEndLocation, texEnd);

            // Transformationen für das Modell  rotation * scaling * große
            Matrix4 model = Matrix4.CreateScale(width, height, 0f) * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(angle)) * Matrix4.CreateTranslation(x, y, 0f);

            // Hole Locations für die Uniforms
            int modelLocation = GL.GetUniformLocation(shaderID, "model");
            int viewLocation = GL.GetUniformLocation(shaderID, "view");
            int projectionLocation = GL.GetUniformLocation(shaderID, "projection");

            // Setze Uniforms
            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            // Zeichne das Modell
            GL.DrawElements(PrimitiveType.Triangles, IndiceHandler.Get("defaultIndice").Count, DrawElementsType.UnsignedInt, 0);
        }








        public static void LastUnbind()
        {
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
