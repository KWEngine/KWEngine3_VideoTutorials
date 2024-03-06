using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld08;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SkiaSharp;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World08_Textures : World
    {
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(10f, 10f, 10f);
            SetCameraTarget(0f, 2f, 0f);
            SetBackgroundFillColor(1f, 1f, 1f);
        }
    }
}
