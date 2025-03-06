namespace Com.Engine
{
    public class TestScene : BasicScene
    {
        public override void Init()
        {



            ShaderHandler.Add("default", "../../../Com/Shaders/Default.vert", "../../../Com/Shaders/Default.frag");
            TextureHandler.Add("test2", "../../../Com/Textures/test2.png");

            ShaderHandler.Add("gui", "../../../Com/Shaders/gui.vert", "../../../Com/Shaders/gui.frag");


            for (int i = 0; i < 5000; i++)
            {
                float a = (((float)i)/20)-2.5f;
                InstanceHandler.Add(new TestInstance(0.5f+a, -0.5f, -10.0f-a));
            }

            GuiHandler.Add(new TestGui(0.0f,0.0f,0.0f));


        }

    }
}