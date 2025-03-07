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


namespace Com.Engine.Library
{
    public static class GuiHandler
    {

    // Verwende ein Dictionary, um die Instanzen nach ihrer 'depth' zu sortieren
        // Der Wert ist eine Liste, um mehrere Instanzen mit derselben depth zu speichern
        private static SortedDictionary<float, List<BasicGui>> instances = new SortedDictionary<float, List<BasicGui>>();


        // Alle Instanzen zeichnen
        public static void AllUpdate(double dt)
        {
            foreach (var instanceList in instances.Values)  // Iteriere durch alle Listen von Instanzen
            {
                foreach (var instance in instanceList)  // Zeichne jede Instanz
                {
                    instance.Step(dt);
                }
            }
        }

        // Alle Instanzen zeichnen
        public static void AllRender(Matrix4 view, Matrix4 orthoProjection)
        {
            foreach (var instanceList in instances.Values)  // Iteriere durch alle Listen von Instanzen
            {
                //GL.Disable(EnableCap.DepthTest);
                foreach (var instance in instanceList)  // Zeichne jede Instanz
                {

                    instance.Draw(view, orthoProjection);
                }
                //GL.Enable(EnableCap.DepthTest);
            }
        }   
        
        // Eine Instanz hinzufügen
        public static void Add(BasicGui instance)
        {
            if (!instances.ContainsKey(instance.depth))
            {
                instances[instance.depth] = new List<BasicGui>();  // Erstelle eine neue Liste für diese depth, falls noch nicht vorhanden
            }
            instances[instance.depth].Add(instance);  // Füge die Instanz zur Liste hinzu
        }

        // Eine Instanz entfernen
        public static void Remove(BasicGui instance)
        {
            if (instances.ContainsKey(instance.depth))
            {
                instances[instance.depth].Remove(instance);  // Entferne die Instanz aus der Liste
                if (instances[instance.depth].Count == 0)
                {
                    instances.Remove(instance.depth);  // Wenn keine Instanzen mehr für diese depth übrig sind, entferne den Schlüssel
                }
            }
        }
   
    }

}