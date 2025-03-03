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
    public static class IboHandler
    {
        private static Dictionary<string, IBO> IBOs = new Dictionary<string, IBO>();

        public static void Add(string key, List<uint> data)
        {
            if (!IBOs.ContainsKey(key))
            {
                IBOs.Add(key, new IBO(data));
            }
        }

        public static IBO Get(string key)
        {
            return IBOs[key];
        }
        public static void Clear()
        {
            foreach (var IBO in IBOs.Values)
            {
                IBO.Delete();
            }
            IBOs.Clear();
        }

        public static void Bind(string key)
        {
            Get(key).Bind();
        }
        public static void Unbind(string key)
        {
            Get(key).Unbind();
        }
        public static void Delete(string key)
        {
            Get(key).Delete();
            IBOs.Remove(key);
        }



    }

}
