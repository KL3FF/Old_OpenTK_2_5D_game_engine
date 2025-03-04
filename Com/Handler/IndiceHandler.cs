namespace Com.Engine
{
    public static class IndiceHandler{

        private static Dictionary<string, List<uint>> indices = new Dictionary<string, List<uint>>();

        public static void Add(string key, List<uint> inde){
            if(!indices.ContainsKey(key)){
                indices[key] = inde;
            }
         
        }
        public static List<uint> Get(string key){
            return indices[key];
        }
        public static void Clear()
        {
            indices.Clear();
        }

     
        public static void Delete(string key)
        {
            indices.Remove(key);
        }

    }



}



 