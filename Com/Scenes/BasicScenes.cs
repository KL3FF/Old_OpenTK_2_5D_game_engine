namespace Com.Engine
{
    public abstract class BasicScenes
    {
        public virtual void Start()
        {
            Console.WriteLine("Szene gestartet: " + this.GetType().Name);
        }

        public virtual void Update()
        {
            // Hier kommt die Logik für die Szene
        }

        public virtual void Render()
        {
            // Hier wird gezeichnet
        }
    }
}