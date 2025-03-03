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
using System.Diagnostics.Tracing;
using System.Dynamic;



namespace Com.Engine
{
    public static class SceneHandler
    {
        public static BasicScenes currentScene = new TitleScenes(); // Startszene

        public static void Set(BasicScenes newScene)
        {
            Console.WriteLine($"Szene gewechselt zu: {newScene.GetType().Name}");

            currentScene = newScene;
        }
    }
}
