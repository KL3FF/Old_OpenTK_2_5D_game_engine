using OpenTK.Mathematics;
namespace Com.Engine.Library
{
    public static class VboHandler
    {
        private static Dictionary<string, VBO> VBOs = new Dictionary<string, VBO>();

        public static void Add(string key, List<Vector3> data)
        {
            if (!VBOs.ContainsKey(key))
            {
                VBOs.Add(key, new VBO(data));
            }
        }
        public static void Add(string key, List<Vector2> data)
        {
            if (!VBOs.ContainsKey(key))
            {
                VBOs.Add(key, new VBO(data));
            }
        }


        public static VBO Get(string key)
        {
            return VBOs[key];
        }
        public static void Clear()
        {
            foreach (var VBO in VBOs.Values)
            {
                VBO.Delete();
            }
            VBOs.Clear();
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
            VBOs.Remove(key);
        }



    }

}
