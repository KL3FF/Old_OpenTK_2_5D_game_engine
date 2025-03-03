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

    public class Game1 : GameWindow
    {
        public Game1(int width, int height, string title) : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this._width = width;
            this._height = height;

            // Zentriert das Fenster basierend auf der angegebenen Breite und Höhe
            this.CenterWindow(new Vector2i(this._width, this._height));
            // Setzt den Fenstertitel
            this.Title = title;

            int maxTextureSize;
            GL.GetInteger(GetPName.MaxTextureSize, out maxTextureSize);
            Console.WriteLine("Maximale Texturgröße: " + maxTextureSize);
            

        }


        MainCamera camera;

        // Eigenschaften zur Speicherung der FensterabmessungenShaderProgram Ge
        private int _width { get; set; }
        private int _height { get; set; }

 

        // Diese Methode wird aufgerufen, sobald das Fenster geladen wird (Initialisierung)
        protected override void OnLoad()
        {
            base.OnLoad();

            VerticeHandler.Add("defaultVertices", new List<Vector3>() { new Vector3(-0.5f, 0.5f, 0.0f), new Vector3(0.5f, 0.5f, 0.0f), new Vector3(0.5f, -0.5f, 0.0f), new Vector3(-0.5f, -0.5f, 0.0f) });
            TexCoordsHandler.Add("defaultTexCoords", new List<Vector2>() { new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0f), new Vector2(0f, 0f) });
            IndiceHandler.Add("defaultIndice", new List<uint> { 0, 1, 2, 2, 3, 0 });

     
            VSync = VSyncMode.On;        // VSync aktivieren

            VaoHandler.Add("defaultVAO");
            VboHandler.Add("defaultVBO", VerticeHandler.Get("defaultVertices"));
            VaoHandler.LinkToVAO("defaultVAO", 0, 3, VboHandler.Get("defaultVBO"));
            VboHandler.Add("defaultUVVBO", TexCoordsHandler.Get("defaultTexCoords"));
            VaoHandler.LinkToVAO("defaultVAO", 1, 2, VboHandler.Get("defaultUVVBO"));
            IboHandler.Add("dafaultIBO", IndiceHandler.Get("defaultIndice"));


            ShaderHandler.Add("default", "../../../Com/Shaders/Default.vert", "../../../Com/Shaders/Default.frag");
            TextureHandler.Add("test2", "../../../Com/Textures/test2.png");



            camera = new MainCamera(_width, _height, Vector3.Zero);
        }

        // Diese Methode wird aufgerufen, wenn das Fenster geschlossen bzw. entladen wird
        protected override void OnUnload()
        {

         
            base.OnUnload();
            VaoHandler.Clear();
            VboHandler.Clear();
            IboHandler.Clear();
            ShaderHandler.Clear();
            TextureHandler.Clear();
            VerticeHandler.Clear();
            TexCoordsHandler.Clear();
            IndiceHandler.Clear();
        }

        // Wird aufgerufen, wenn sich die Fenstergröße ändert
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            // Anpassen des Viewports, sodass die Zeichnung der Szene zur neuen Fenstergröße passt
            GL.Viewport(0, 0, e.Width, e.Height);
            this._width = e.Width;
            this._height = e.Height;
            camera.SCREENWIDTH = this._width;
            camera.SCREENHEIGHT = this._height;
        }

        // Wird für jedes Frame aufgerufen, um die Szene zu rendern
        protected override void OnRenderFrame(FrameEventArgs args)
        {

            Console.WriteLine(args.Time);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            

            // Binde das VAO und das IBO für beide Modelle
            VaoHandler.Bind("defaultVAO");
            IboHandler.Bind("dafaultIBO");


            // Setzt die Hintergrundfarbe und löscht den Farbpuffer
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // Camera
            Matrix4 view = camera.GetViewMatrix();
            Matrix4 projection = camera.GetProjectionMatrix();

            // Modelle rendern

            ModelHandler.Draw(view, projection, 0.0f, 0.0f, -13.0f, "default", "test2",  new Vector2(0.0f, 0.0f),new Vector2(1.0f, 1.0f));
            ModelHandler.Draw(view, projection, 0.0f, 0.0f, -10.0f, "default", "test2",  new Vector2(0.0f, 0.0f),new Vector2(1.0f, 1.0f));

            GL.Disable(EnableCap.DepthTest); 
            ModelHandler.Draw(view, projection,-0.5f, 0.5f, -9.0f, "default", "test2",  new Vector2(0.0f, 0.0f),new Vector2(1.0f, 1.0f));
            ModelHandler.Draw(view, projection, -0.0f, 0.0f, -9.0f, "default", "test2",  new Vector2(0.0f, 0.0f),new Vector2(1.0f, 1.0f));
             GL.Enable(EnableCap.DepthTest);
            // ModelHandler.LastUnbind();
            VaoHandler.Unbind("defaultVAO");
            IboHandler.Unbind("dafaultIBO");

            // Tausche die Puffer
            Context.SwapBuffers();
            base.OnRenderFrame(args);
        }





        // Wird aufgerufen, um jedes Frame Logik oder Eingaben zu verarbeiten
        protected override void OnUpdateFrame(FrameEventArgs args)
        {


            MouseState mouse = MouseState;
            KeyboardState input = KeyboardState;


            if (input.IsKeyDown(Keys.Escape))
            {
                Close(); // Beendet das Spiel
            }



            if (KeyboardState.IsKeyPressed(Keys.F11))
            {
                if (WindowState == WindowState.Fullscreen)
                {
                    WindowState = WindowState.Normal;
                }
                else
                {
                    WindowState = WindowState.Fullscreen;
                }
            }


            camera.Update(input, mouse, args);
            base.OnUpdateFrame(args);
        }




    }
}
