using System.Reflection.Metadata;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Com.Engine
{

    public class Game1 : GameWindow
    {
        public Game1() : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
 

            // Zentriert das Fenster basierend auf der angegebenen Breite und Höhe
 
            // Setzt den Fenstertitel
            this.Title = "title";

            // int maxTextureSize;
            // GL.GetInteger(GetPName.MaxTextureSize, out maxTextureSize);
            // Console.WriteLine("Maximale Texturgröße: " + maxTextureSize);

             //this.CenterWindow(new Vector2i(SettingsHandler.Width, SettingsHandler.Height));
    
            SettingsHandler.LoadSettings(this);
            SettingsHandler.SetFPS(this,60);
        }


        MainCamera camera;



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




            camera = new MainCamera(SettingsHandler.RenderWidth,SettingsHandler.RenderHeight);
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
            

            // Anpassen des Viewports, sodass die Zeichnung der Szene zur neuen Fenstergröße passt
            GL.Viewport(0, 0, e.Width, e.Height);
     
            SettingsHandler.ViewWidth = e.Width;
            SettingsHandler.ViewHeight = e.Height;
         

            if (!IsFullscreen){
                SettingsHandler.RenderWidth = SettingsHandler.ViewWidth;
                SettingsHandler.RenderHeight = SettingsHandler.ViewHeight;
            }

            camera.SCREENWIDTH = SettingsHandler.RenderWidth;
            camera.SCREENHEIGHT = SettingsHandler.RenderHeight;




            base.OnResize(e);
            SettingsHandler.SaveSettings();
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

            Console.Clear();
            double fps = 1.0 / args.Time; // args.Time gibt die Zeit pro Frame in Sekunden aus
            Console.WriteLine($"FPS: {fps:F2}"); // FPS mit zwei Nachkommastellen ausgeben

            MouseState mouse = MouseState;
            KeyboardState input = KeyboardState;


            if (input.IsKeyDown(Keys.Escape))
            {
                Close(); // Beendet das Spiel
            }



            if (KeyboardState.IsKeyPressed(Keys.F11))
            {
                SettingsHandler.Fullscreen(this);
            }

            if (KeyboardState.IsKeyPressed(Keys.F10))
            {
                SettingsHandler.Borderless(this);
            }
            if (KeyboardState.IsKeyPressed(Keys.F9))
            {
                SettingsHandler.Borderless(this);
            }
            if (KeyboardState.IsKeyPressed(Keys.F8))
            {
                SettingsHandler.VSync(this);
            }
        
            SettingsHandler.PrintSettings();

            InstanceHandler.AllUpdate(args.Time);



            camera.Update(input, mouse, args);
            base.OnUpdateFrame(args);
        }




    }
}
