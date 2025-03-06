using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace Com.Engine.Library
{
    public class MainCamera : BasicCamera
    {

     
     
        public MainCamera(float width, float height)
        {
            base.SCREENWIDTH = width;
            base.SCREENHEIGHT = height;
        }
        public override Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, position + front, up);
        }
        public override Matrix4 GetIdentity()
        {
            return Matrix4.Identity;
        }
        public override Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), SCREENWIDTH / SCREENHEIGHT, 0.1f, 1000.0f);
        }

        public override Matrix4 GetOrthoProjectionMatrix()
        {
            return Matrix4.CreateOrthographicOffCenter(0.0f, SCREENWIDTH, SCREENHEIGHT, 0.0f, -1.0f, 1.0f); // 2D Projektion
        }
        public override void InputController(KeyboardState input, MouseState mouse, FrameEventArgs e)
        {
            if (input.IsKeyDown(Keys.W))
            {
                position += up * SPEED * (float)e.Time;
            }
            if (input.IsKeyDown(Keys.A))
            {
                position -= right * SPEED * (float)e.Time;
            }
            if (input.IsKeyDown(Keys.S))
            {
                position -= up * SPEED * (float)e.Time;
            }
            if (input.IsKeyDown(Keys.D))
            {
                position += right * SPEED * (float)e.Time;
            }


        }
        public override void Update(KeyboardState input, MouseState mouse, FrameEventArgs e)
        {
            InputController(input, mouse, e);
        }

    }

}