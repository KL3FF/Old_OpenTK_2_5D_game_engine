using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

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

            UpdateFrequency = 0.0;
            VSync = VSyncMode.Off;

        }


        MainCamera camera;

        // Eigenschaften zur Speicherung der FensterabmessungenShaderProgram Ge
        private int _width { get; set; }
        private int _height { get; set; }



        // Diese Methode wird aufgerufen, sobald das Fenster geladen wird (Initialisierung)
        protected override void OnLoad()
        {

            base.OnLoad();

            SceneHandler.Set(new TestScene());


            GL.Disable(EnableCap.Multisample);


            VerticeHandler.Add("defaultVertices", new List<Vector3>() { new Vector3(-0.5f, 0.5f, 0.0f), new Vector3(0.5f, 0.5f, 0.0f), new Vector3(0.5f, -0.5f, 0.0f), new Vector3(-0.5f, -0.5f, 0.0f) });
            TexCoordsHandler.Add("defaultTexCoords", new List<Vector2>() { new Vector2(0f, 1f), new Vector2(1f, 1f), new Vector2(1f, 0f), new Vector2(0f, 0f) });
            IndiceHandler.Add("defaultIndice", new List<uint> { 0, 1, 2, 2, 3, 0 });

            VaoHandler.Add("stageVAO");
            VboHandler.Add("stageVBO", VerticeHandler.Get("defaultVertices"));
            VaoHandler.LinkToVAO("stageVAO", 0, 3, VboHandler.Get("stageVBO"));
            VboHandler.Add("stageUVVBO", TexCoordsHandler.Get("defaultTexCoords"));
            VaoHandler.LinkToVAO("stageVAO", 1, 2, VboHandler.Get("stageUVVBO"));
            IboHandler.Add("stageIBO", IndiceHandler.Get("defaultIndice"));

    
            VaoHandler.Add("guiVAO");
            VboHandler.Add("guiVBO",VerticeHandler.Get("defaultVertices"));
            VaoHandler.LinkToVAO("guiVAO", 0, 3, VboHandler.Get("stageVBO"));
            VboHandler.Add("guiUVVBO", TexCoordsHandler.Get("defaultTexCoords"));
            VaoHandler.LinkToVAO("guiVAO", 1, 2, VboHandler.Get("guiUVVBO"));
            IboHandler.Add("guiIBO", IndiceHandler.Get("defaultIndice"));




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


            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);






            // Setzt die Hintergrundfarbe und löscht den Farbpuffer
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            // Camera 3D
    
            VaoHandler.Bind("stageVAO");
            IboHandler.Bind("stageIBO");
            InstanceHandler.AllRender(camera.GetViewMatrix(), camera.GetProjectionMatrix());
            VaoHandler.Unbind("stageVAO");
            IboHandler.Unbind("stageIBO");

            VaoHandler.Bind("guiVAO");
            IboHandler.Bind("guiIBO");
            GuiHandler.AllRender(camera.GetIdentity(),camera.GetOrthoProjectionMatrix());
            VaoHandler.Unbind("guiVAO");
            IboHandler.Unbind("guiIBO");







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

            InstanceHandler.AllUpdate(args.Time);



            camera.Update(input, mouse, args);
            base.OnUpdateFrame(args);
        }




    }
}
