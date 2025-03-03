using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.IO;
using StbImageSharp;

namespace Com.Engine
{
    public static class ModelHandler
    {

        // Statische Variablen zum Speichern des letzten verwendeten Shaders und Texturen
        private static string lastShader = null;
        private static string lastTexture = null;



        public static void Draw(Matrix4 view, Matrix4 projection, float x, float y, float z, string shader, string texture)
        {

            // Überprüfen, ob der Shader gewechselt hat
            if (lastShader != shader)
            {
                // Binde den neuen Shader
                ShaderHandler.Unbind(lastShader);
                ShaderHandler.Bind(shader);
                lastShader = shader;  // Speichere den aktuellen Shader
            }


            // Überprüfen, ob die Textur gewechselt hat
            if (lastTexture != texture)
            {
                // Binde die neue Textur
                TextureHandler.Unbind(lastTexture);
                TextureHandler.Bind(texture);
                lastTexture = texture;  // Speichere die aktuelle Textur
            }


            // Shader binden
            ShaderHandler.Bind(shader);
            // Textur binden
            TextureHandler.Bind(texture);

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
        public static void LastUnbind()
        {
            if (lastShader != null)
            {
                ShaderHandler.Unbind(lastShader);  // Nur unbinden, wenn ein Shader gebunden war
            }
            if (lastTexture != null)
            {
                TextureHandler.Unbind(lastTexture);  // Nur unbinden, wenn eine Textur gebunden war
            }
        }


    }
}
