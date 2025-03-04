using OpenTK.Mathematics;

namespace Com.Engine
{
    public static class VerticeHandler{

        private static Dictionary<string, List<Vector3>> vertices = new Dictionary<string, List<Vector3>>();

        public static void Add(string key, List<Vector3> verts){
            if(!vertices.ContainsKey(key)){
                vertices[key] = verts;
            }
         
        }
        public static List<Vector3> Get(string key){
            return vertices[key];
        }
        public static void Clear()
        {
            vertices.Clear();
        }

     
        public static void Delete(string key)
        {
            vertices.Remove(key);
        }

    }



}



 