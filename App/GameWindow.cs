using KWEngine3;
using KWEngine3_Tutorial.App.Worlds;

namespace KWEngine3_ExampleProject.App
{
    public class GameWindow : GLWindow
    {
        public GameWindow() : base(1280, 720)
        {
            World04_CollisionDetection world = new World04_CollisionDetection();
            SetWorld(world);
        }
    }
}
