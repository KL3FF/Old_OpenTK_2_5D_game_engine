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
using System.IO.Compression;

namespace Com.Engine
{

    class TestInstance : BasicInstance
    {
        public float x = 0;
        public float y = 0;
        private float speed = 5.0f;
        private float direction = 1.0f; // 1 = nach oben, -1 = nach unten

        public TestInstance(float x, float y, float depth)
        {
            this.x = x;
            this.y = MathHelper.Lerp(-10f, 10f, Random.Shared.NextSingle()); // Random Start Y
            base.depth = depth;
        }

        public override void Draw(Matrix4 view, Matrix4 projection)
        {
            ModelHandler.Draw(view, projection, x, y, depth, "default", "test2", new Vector2(0.0f, 0.0f), new Vector2(1.0f, 1.0f));
        }

        public override void Step(double dt)
        {
            y += (float)(speed * direction * dt);

            if (y >= 10f)
            {
                y = 10f;       // Fix auf 10
                direction = -1; // Umkehren nach unten
            }

            if (y <= -10f)
            {
                y = -10f;      // Fix auf -10
                direction = 1; // Umkehren nach oben
            }
        }
    }
}
