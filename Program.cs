// using System;
// using System.Collections.Generic;
// using System.Drawing;
// using System.Text;
// using System.Threading.Tasks;
// using OpenTK.Graphics.OpenGL;
// using OpenTK.Mathematics;
// using OpenTK.Windowing.Common;
// using OpenTK.Windowing.Desktop;
// using OpenTK.Windowing.GraphicsLibraryFramework;
// using System.IO;
// using StbImageSharp;

using OpenTK.Windowing.Common;
namespace Com.Engine
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            using (Game1 game = new Game1(1280, 720, "Hello World"))
            {
                game.WindowState = WindowState.Normal; 
                //game.WindowState = WindowState.Fullscreen; 
        

                game.Run();
            }

         
        }
    }
}
