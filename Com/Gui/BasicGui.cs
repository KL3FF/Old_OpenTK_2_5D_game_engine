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



namespace Com.Engine.Library
{
    

    public abstract class BasicGui
    {


        public float depth = 0;

     

        public abstract void Draw(Matrix4 view, Matrix4 orthoProjection);
        
        public abstract void Step(double dt);
    }


}