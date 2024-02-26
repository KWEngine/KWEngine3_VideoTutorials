using KWEngine3;
using KWEngine3_Tutorial.App.Worlds;

namespace KWEngine3_ExampleProject.App
{
    public class GameWindow : GLWindow
    {
        public GameWindow() : base(1280, 720)
        {
            World03_MultipleClasses world = new World03_MultipleClasses();
            SetWorld(world);
        }
    }
}
