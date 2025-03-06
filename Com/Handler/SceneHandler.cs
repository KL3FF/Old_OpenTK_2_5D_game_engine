namespace Com.Engine.Library
{
    public static class SceneHandler
    {
        public static BasicScene currentScene = new BasicScene(); // Startszene

        public static void Set(BasicScene newScene)
        {
            Console.WriteLine($"Szene gewechselt zu: {newScene.GetType().Name}");

            currentScene = newScene;
            currentScene.Init();
        }
    }
}
