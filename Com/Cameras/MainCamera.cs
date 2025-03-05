using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;



namespace Com.Engine
{
    public class MainCamera
    {

        private float SPEED = 8f;
        public float SCREENWIDTH;
        public float SCREENHEIGHT;
        public Vector3 position;
        // public Vector3 velocity;

        Vector3 up = Vector3.UnitY;
        Vector3 front = -Vector3.UnitZ;
        Vector3 right = Vector3.UnitX;

        // view rotations

        private bool firstMove = true;
        public Vector2 lastPos;

     
        public MainCamera(float width, float height, Vector3 position)
        {
            SCREENWIDTH = width;
            SCREENHEIGHT = height;
            this.position = position;
        }
        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(position, position + front, up);
        }
        public Matrix4 GetIdentity()
        {
            return Matrix4.Identity;
        }
        public Matrix4 GetProjectionMatrix()
        {

            return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), SCREENWIDTH / SCREENHEIGHT, 0.1f, 1000.0f);


        }

        public Matrix4 GetOrthoProjectionMatrix()
        {

   
            return Matrix4.CreateOrthographicOffCenter(0.0f, SCREENWIDTH, SCREENHEIGHT, 0.0f, -1.0f, 1.0f); // 2D Projektion
        }
        // public static Matrix4 CreateOrthographicOffCenter2(float left, float right, float bottom, float top, float zNear, float zFar)
        // {
        //     float m00 = 2.0f / (right - left);
        //     float m11 = 2.0f / (top - bottom);
        //     float m22 = -2.0f / (zFar - zNear);
        //     float m30 = -(right + left) / (right - left);
        //     float m31 = -(top + bottom) / (top - bottom);
        //     float m32 = -(zFar + zNear) / (zFar - zNear);
            
        //     return new Matrix4(
        //         m00, 0, 0, m30,
        //         0, m11, 0, m31,
        //         0, 0, m22, m32,
        //         0, 0, 0, 1
        //     );
        // }
        public void InputController(KeyboardState input, MouseState mouse, FrameEventArgs e)
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

            if (firstMove)
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }
            else
            {
                // var deltaX = mouse.X - lastPos.X;
                // var deltaY = mouse.Y - lastPos.Y;
                // lastPos = new Vector2(mouse.X, mouse.Y);
                // yaw += deltaX * SENSITIVITY * (float)e.Time;
                // pitch -= deltaY * SENSITIVITY * (float)e.Time;
                // UpdateVectors();
            }
        }
        public void Update(KeyboardState input, MouseState mouse, FrameEventArgs e)
        {
            InputController(input, mouse, e);
        }

    }

}