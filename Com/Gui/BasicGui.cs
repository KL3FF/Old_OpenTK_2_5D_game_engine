
using OpenTK.Mathematics;



namespace Com.Engine.Library
{
    

    public abstract class BasicGui
    {


        public float depth = 0;

     

        public abstract void Draw(ref Matrix4 view,ref Matrix4 orthoProjection);
        
        public abstract void Step(double dt);
    }


}