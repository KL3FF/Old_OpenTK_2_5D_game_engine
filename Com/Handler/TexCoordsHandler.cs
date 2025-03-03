using System;
using System.Collections.Generic;
using OpenTK.Mathematics;

namespace Com.Engine
{
    public static class TexCoordsHandler{

        private static Dictionary<string, List<Vector2>> texCoords = new Dictionary<string, List<Vector2>>();

        public static void Add(string key, List<Vector2> cords){
            if(!texCoords.ContainsKey(key)){
                texCoords[key] = cords;
            }
         
        }
        public static List<Vector2> Get(string key){
            return texCoords[key];
        }
        public static void Clear()
        {
            texCoords.Clear();
        }

     
        public static void Delete(string key)
        {
            texCoords.Remove(key);
        }

    }



}



 