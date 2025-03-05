namespace Com.Engine
{
    public class TestScene : BasicScene
    {
        public override void Init()
        {



            ShaderHandler.Add("default", "../../../Com/Shaders/Default.vert", "../../../Com/Shaders/Default.frag");
            TextureHandler.Add("test2", "../../../Com/Textures/test2.png");

            ShaderHandler.Add("gui", "../../../Com/Shaders/gui.vert", "../../../Com/Shaders/gui.frag");

            InstanceHandler.Add(new TestInstance(0.5f + 5.5f, -0.5f, -10.0f));
            InstanceHandler.Add(new TestInstance(0.0f + 5.5f, 0.0f, -10.0f));
            InstanceHandler.Add(new TestInstance(-0.5f + 5.5f, 0.5f, -10.0f));
            InstanceHandler.Add(new TestInstance(-0.5f + 5.5f, 0.5f, -18.0f));
            InstanceHandler.Add(new TestInstance(0.5f + 5.5f, -0.5f, -18.0f));
            InstanceHandler.Add(new TestInstance(0.0f + 5.5f, 0.0f, -18.0f));
            InstanceHandler.Add(new TestInstance(-0.5f + 5.5f, 0.5f, -14.0f));
            InstanceHandler.Add(new TestInstance(0.5f + 5.5f, -0.5f, -14.0f));
            InstanceHandler.Add(new TestInstance(0.0f + 5.5f, 0.0f, -14.0f));


            InstanceHandler.Add(new TestInstance(0.5f, -0.5f, -10.0f));
            InstanceHandler.Add(new TestInstance(0.0f, 0.0f, -10.0f));
            InstanceHandler.Add(new TestInstance(-0.5f, 0.5f, -10.0f));
            InstanceHandler.Add(new TestInstance(-0.5f, 0.5f, -18.0f));
            InstanceHandler.Add(new TestInstance(0.5f, -0.5f, -18.0f));
            InstanceHandler.Add(new TestInstance(0.0f, 0.0f, -18.0f));
            InstanceHandler.Add(new TestInstance(-0.5f, 0.5f, -14.0f));
            InstanceHandler.Add(new TestInstance(0.5f, -0.5f, -14.0f));
            InstanceHandler.Add(new TestInstance(0.0f, 0.0f, -14.0f));


            InstanceHandler.Add(new TestInstance(0.5f - 0.75f, -0.5f, -10.0f));
            InstanceHandler.Add(new TestInstance(0.0f - 0.75f, 0.0f, -10.0f));
            InstanceHandler.Add(new TestInstance(-0.5f - 0.75f, 0.5f, -10.0f));
            InstanceHandler.Add(new TestInstance(-0.5f - 0.75f, 0.5f, -18.0f));
            InstanceHandler.Add(new TestInstance(0.5f - 0.75f, -0.5f, -18.0f));
            InstanceHandler.Add(new TestInstance(0.0f - 0.75f, 0.0f, -18.0f));
            InstanceHandler.Add(new TestInstance(-0.5f - 0.75f, 0.5f, -14.0f));
            InstanceHandler.Add(new TestInstance(0.5f - 0.75f, -0.5f, -14.0f));
            InstanceHandler.Add(new TestInstance(0.0f - 0.75f, 0.0f, -14.0f));

            GuiHandler.Add(new TestGui(0.0f,0.0f,0.0f));


        }

    }
}