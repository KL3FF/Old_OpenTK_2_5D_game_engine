namespace Com.Engine.Library
{
    public class TestScene : BasicScene
    {
        public override void Init()
        {



            ShaderHandler.Add("default", "../../../Com/Shaders/Default.vert", "../../../Com/Shaders/Default.frag");
            TextureHandler.Add("test2", "../../../Com/Textures/test2.png");
            TextureHandler.Add("test3", "../../../Com/Textures/test3.png");
            // ShaderHandler.Add("gui", "../../../Com/Shaders/gui.vert", "../../../Com/Shaders/gui.frag");


            for (int i = 0; i < 100; i++)
            {
                float a = ((float)i)*8;
                if (i % 2 == 0)
                {
                    InstanceHandler.Add(new TestInstance(0.0f+a, 0.0f, 0.0f-a, 128.0f, 128.0f, 0.0f));
                }
                else
                {
                    InstanceHandler.Add(new TestInstance1(0.0f+a, 0.0f, 0.0f-a, 128.0f, 128.0f, 0.0f));
                }



            }



            // InstanceHandler.Add(new TestInstance(0.0f, 0.0f, 0.0f, 128.0f, 64.0f, 0.0f));
            // InstanceHandler.Add(new TestInstance(128.0f, 0.0f, 0.0f, 128.0f, 128.0f, 0.0f));
            // InstanceHandler.Add(new TestInstance(128.0f, 0.0f, -128.0f, 128.0f, 128.0f, 0.0f));





            GuiHandler.Add(new TestGui(64.0f, 64.0f, 0.0f, 128.0f, 64.0f, 0.0f));
            GuiHandler.Add(new TestGui(192.0f, 192.0f, 0.0f, 128.0f, 128.0f, 0.0f));

        }
    }
}