using KWEngine3_ExampleProject.App;

namespace KWEngine3_ExampleProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (GameWindow gw = new GameWindow())
            {
                gw.Run();
            }
        }
    }
}