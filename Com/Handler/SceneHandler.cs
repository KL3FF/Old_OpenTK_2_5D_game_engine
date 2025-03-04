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
