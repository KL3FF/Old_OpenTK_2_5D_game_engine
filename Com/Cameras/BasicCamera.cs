using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace Com.Engine.Library
{
    public abstract class BasicCamera
    {

        public float SPEED = 8f;
        public float SCREENWIDTH;
        public float SCREENHEIGHT;
        public Vector3 position;
        // public Vector3 velocity;

         public Vector3 up = Vector3.UnitY;
         public Vector3 front = -Vector3.UnitZ;
         public Vector3 right = Vector3.UnitX;

        public abstract Matrix4 GetViewMatrix();
        public abstract Matrix4 GetIdentity();
        public abstract Matrix4 GetProjectionMatrix();

        public abstract Matrix4 GetOrthoProjectionMatrix();
        public abstract void InputController(KeyboardState input, MouseState mouse, FrameEventArgs e);
        public abstract void Update(KeyboardState input, MouseState mouse, FrameEventArgs e);

    }

}