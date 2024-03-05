using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorldADV01
{
    public class Wall : GameObject
    {
        public Wall()
        {
            SetModel("KWPlatform");
            SetTexture("./App/Textures/wall_albedo.png", TextureType.Albedo, 0); // oben/unten
            SetTexture("./App/Textures/wall_albedo.png", TextureType.Albedo, 1); // links/rechts
            SetTexture("./App/Textures/wall_albedo.png", TextureType.Albedo, 2); // vorne/hinten
            SetTexture("./App/Textures/wall_normal.png", TextureType.Normal, 0); // oben/unten
            SetTexture("./App/Textures/wall_normal.png", TextureType.Normal, 1); // links/rechts
            SetTexture("./App/Textures/wall_normal.png", TextureType.Normal, 2); // vorne/hinten
            IsShadowCaster = true;
            IsCollisionObject = true;
            FlowFieldCost = 255;
        }

        public override void Act()
        {
            
        }
    }
}
