using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld15;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World15_2DSprites : World
    {
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetCameraPosition(0f, 1f, 20f);
            SetCameraTarget(0f, 1f, 0f);
            SetCameraFOV(10);

            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(1f, 1f, 1f);
        }
    }
}
