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


namespace Com.Engine
{
    public abstract class BasicScenes
    {
        public virtual void Start()
        {
            Console.WriteLine("Szene gestartet: " + this.GetType().Name);
        }

        public virtual void Update()
        {
            // Hier kommt die Logik für die Szene
        }

        public virtual void Render()
        {
            // Hier wird gezeichnet
        }
    }
}