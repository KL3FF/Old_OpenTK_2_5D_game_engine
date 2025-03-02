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
using System.Runtime.InteropServices.Swift;


namespace Com.Engine
{


    public class VBO
    {
        public int ID;
        public VBO(List<Vector3> data)
        {
            ID = GL.GenBuffer(); // generieren
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID); // verknüpfen
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector3.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw); // Übertrage 

        }
        public VBO(List<Vector2> data)
        {
            ID = GL.GenBuffer(); // generieren
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID); // verknüpfen
            GL.BufferData(BufferTarget.ArrayBuffer, data.Count * Vector2.SizeInBytes, data.ToArray(), BufferUsageHint.StaticDraw); // Übertrage  
        }
        public void Bind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, ID);
        }
        public void Unbind()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
        public void Delete()
        {
            GL.DeleteBuffer(ID);
        }
    }

}