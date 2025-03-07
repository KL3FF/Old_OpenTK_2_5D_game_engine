using OpenTK.Mathematics;


namespace Com.Engine.Library
{
    

    public abstract class BasicInstance
    {


        public float depth = 0;

     

        public abstract void Draw(Matrix4 view, Matrix4 projection);
        
        public abstract void Step(double dt);
    }


}