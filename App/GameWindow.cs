using KWEngine3;
using KWEngine3_Tutorial.App.Worlds;

namespace KWEngine3_ExampleProject.App
{
    public class GameWindow : GLWindow
    {
        public GameWindow() : base(1280, 720)
        {
            World15_2DSprites world = new World15_2DSprites();
            SetWorld(world);
        }
    }
}
