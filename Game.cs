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

            Console.WriteLine("Window created!");
        }
        // Definition der Vertex-Daten für ein einfaches Rechteck (jede Zeile repräsentiert x, y, z)
        // float[] _vertices = {
        //     -0.5f,  0.5f, 0.0f,
        //     0.5f, 0.5f, 0.0f,
        //     0.5f, -0.5f, 0.0f,
        //     -0.5f, -0.5f, 0.0f
        // };

        List<Vector3> vertices = new List<Vector3>(){
            // vorne
            new Vector3(-0.5f, 0.5f, 0.0f),
            new Vector3(0.5f, 0.5f, 0.0f),
            new Vector3(0.5f, -0.5f, 0.0f),
            new Vector3(-0.5f, -0.5f, 0.0f),
        };


        // Texturkoordinaten (für Texturen auf dem Rechteck)
        // float[] _texCoords = {
        //     0f, 1f,
        //     1f, 1f,
        //     1f, 0f,
        //     0f, 0f
        // };
        List<Vector2> texCoords = new List<Vector2>(){
            // vorne
            new Vector2(0f, 1f),
            new Vector2(1f, 1f),
            new Vector2(1f, 0f),
            new Vector2(0f, 0f),
        };

        // Indizes für die Dreiecke, die das Rechteck bilden (Verwenden von Element-Buffer)
        List<uint> indices = new List<uint>{
            0,1,2,2,3,0
        };


        VAO vao;
        IBO ibo;
        ShaderProgram shaderProgram;
        Texture texture;


        Camera camera;



        //transomation variables
        float yRot = 0f;



        // Eigenschaften zur Speicherung der Fensterabmessungen
        private int _width { get; set; }
        private int _height { get; set; }

        // Konstruktor des Spiels, der die Fenstergröße und den Fenstertitel setzt


        // Diese Methode wird aufgerufen, sobald das Fenster geladen wird (Initialisierung)
        protected override void OnLoad()
        {

            Console.WriteLine("Window Loaded!");
            base.OnLoad();

            vao = new VAO();
            VBO vbo = new VBO(vertices);
            vao.LinkToVAO(0, 3, vbo);
            VBO uvVBO = new VBO(texCoords);
            vao.LinkToVAO(1, 2, uvVBO);

            ibo = new IBO(indices);
            shaderProgram = new ShaderProgram("../../../Com/Shaders/Default.vert", "../../../Com/Shaders/Default.frag");
            texture = new Texture("../../../Com/Textures/test.png");


            GL.Enable(EnableCap.DepthTest);

            camera = new Camera(_width, _height, Vector3.Zero);
        }

        // Diese Methode wird aufgerufen, wenn das Fenster geschlossen bzw. entladen wird
        protected override void OnUnload()
        {
            Console.WriteLine("Window Unloaded!");
            base.OnUnload();
            vao.Delete();
            ibo.Delete();
            texture.Delete();
            shaderProgram.Delete();
        }

        // Wird aufgerufen, wenn sich die Fenstergröße ändert
        protected override void OnResize(ResizeEventArgs e)
        {
            Console.WriteLine("Window Resized!");
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
            // Setzt die Hintergrundfarbe und löscht den Farbpuffer
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            shaderProgram.Bind();
            vao.Bind();
            ibo.Bind();
            texture.Bind();


            // Transformationen setzen (Model, View, Projection)
            Matrix4 model = Matrix4.Identity;
            Matrix4 view = camera.GetViewMatrix();
            Matrix4 projection = camera.GetProjectionMatrix();

            model = Matrix4.CreateRotationY(yRot);
            Matrix4 translation = Matrix4.CreateTranslation(0f, 0f, -1f);
            model *= translation;



            int modelLocation = GL.GetUniformLocation(shaderProgram.ID, "model");
            int viewLocation = GL.GetUniformLocation(shaderProgram.ID, "view");
            int projectionLocation = GL.GetUniformLocation(shaderProgram.ID, "projection");

            GL.UniformMatrix4(modelLocation, true, ref model);
            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            // Zeichne die Elemente
            GL.DrawElements(PrimitiveType.Triangles, indices.Count, DrawElementsType.UnsignedInt, 0);




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
                if ( WindowState == WindowState.Fullscreen ){
                    WindowState = WindowState.Normal; 
                }
                else{
                    WindowState = WindowState.Fullscreen;
                }
            }


            camera.Update(input, mouse, args);
            base.OnUpdateFrame(args);
        }




    }
}
