using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class WorldSelect : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(1f, 1f, 1f);
        }
    }
}
