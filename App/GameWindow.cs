using KWEngine3;
using KWEngine3_Tutorial.App.Worlds;

namespace KWEngine3_ExampleProject.App
{
    public class GameWindow : GLWindow
    {
        public GameWindow() : base(1280, 720)
        {
            World11a_WorldSwitch world = new World11a_WorldSwitch();
            SetWorld(world);
        }
    }
}
