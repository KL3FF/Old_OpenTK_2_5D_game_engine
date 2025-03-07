
using OpenTK.Mathematics;


namespace Com.Engine.Library
{

    class TestGui : BasicGui
    {

        public float x = 0;
        public float y = 0;


        public TestGui(float x,float y, float depth)
        {
            this.x = x;
            this.y = y;
            base.depth = depth;
        }
        

        public override void Draw(Matrix4 view, Matrix4 orthoProjection)
        {
            ModelHandler.DrawGui(view, orthoProjection, 0.0f, 0.0f, 200.0f,200.0f, "default", "test2", new Vector2(0.0f, 0.0f), new Vector2(1.0f, 1.0f));
           
        }

        public override void Step(double dt)
        {

        }
    }


}