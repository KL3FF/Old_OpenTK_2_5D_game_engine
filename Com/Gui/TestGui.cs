
using OpenTK.Mathematics;


namespace Com.Engine.Library
{

    class TestGui : BasicGui
    {

        public float x = 0;
        public float y = 0;
        public float angle;



        public float width = 0.0f;
        public float height = 0.0f;

        public TestGui(float x, float y, float depth, float width, float height, float angle)
        {
            this.x = x;
            this.y = y ;
            base.depth = depth;
            this.angle = angle;
            this.width = width;
            this.height = height;
        }


        public override void Draw(ref Matrix4 view, ref Matrix4 orthoProjection)
        {
            ModelHandler.DrawGui(ref view, ref orthoProjection, x, y, width, height, angle, "default", "test2", new Vector2(0.0f, 0.0f), new Vector2(1.0f, 1.0f));

        }

        public override void Step(double dt)
        {
            this.angle += 1.0f*(float)dt;
            if (this.angle >= 360)
            {
                this.angle -= 360f;
            }
        }
    }


}