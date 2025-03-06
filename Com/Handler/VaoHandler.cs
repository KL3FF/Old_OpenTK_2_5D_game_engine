namespace Com.Engine.Library
{
    public static class VaoHandler
    {
        private static Dictionary<string, VAO> VAOs = new Dictionary<string, VAO>();

        public static void Add(string key)
        {
            if (!VAOs.ContainsKey(key))
            {
                VAOs.Add(key, new VAO());
            }
        }

        public static VAO Get(string key)
        {
            return VAOs[key];
        }
        public static void Clear()
        {
            foreach (var VAO in VAOs.Values)
            {
                VAO.Delete();
            }
            VAOs.Clear();
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
            VAOs.Remove(key);
        }

        public static void LinkToVAO(string key, int location, int size, VBO vbo)
        {
            Get(key).LinkToVAO(location, size, vbo);

        }




    }

}
