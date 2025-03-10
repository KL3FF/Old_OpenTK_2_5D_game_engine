using OpenTK.Mathematics;

namespace Com.Engine.Library
{

    class TestInstance1 : BasicInstance
    {
        public float x = 0;
        public float y = 0;
        private float speed = 2.0f;
        private float direction = 1.0f;

        private float angle = 0.0f;


        public float width = 0.0f;
        public float height = 0.0f;

        public TestInstance1(float x, float y, float depth, float width, float height, float angle)
        {
            this.x = x;
            this.y = y + MathHelper.Lerp(-512f, 512f, Random.Shared.NextSingle()); // Random Start Y
            base.depth = depth;
            this.angle = angle;
            this.width = width;
            this.height = height;
        }


        public override void Draw(ref Matrix4 view, ref Matrix4 projection)
        {
            ModelHandler.Draw(ref view, ref projection, x, y, depth, width, height, angle, "default", "test3", new Vector2(0.0f, 0.0f), new Vector2(1.0f, 1.0f));
        }


        public override void Step(double dt)
        {
            this.angle += 1.0f * (float)dt;
            if (this.angle >= 360)
            {
                this.angle -= 360f;
            }

            y += (float)(speed * direction * dt);

            if (y >= 512.0f)
            {
                y = 512.0f;       // Fix auf 10
                direction = -1; // Umkehren nach unten
            }

            if (y <= -512.0f)
            {
                y = -512.0f;      // Fix auf -10
                direction = 1; // Umkehren nach oben
            }
        }
    }
}
