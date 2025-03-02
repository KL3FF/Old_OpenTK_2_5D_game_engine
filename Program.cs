using OpenTK;
using System;
using System.Drawing;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;



namespace Com.Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            using (Game1 game = new Game1(1280, 720, "Hello World"))
            {
                game.Run();
            }

         
        }
    }
}
