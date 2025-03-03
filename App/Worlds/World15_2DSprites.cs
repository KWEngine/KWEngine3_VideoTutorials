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
        }

        public override void Prepare()
        {
            SetCameraPosition(0f, 1f, 20f);
            SetCameraTarget(0f, 1f, 0f);
            SetCameraFOV(10);

            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(1f, 1f, 1f);

            PlatformEntity platform1 = new PlatformEntity();
            platform1.SetModel("KWQuad");
            platform1.SetTexture("./App/Textures/brick_albedo.png");
            AddGameObject(platform1);

            Player p = new Player();
            p.SetModel("KWQuad");
            p.SetTexture("./App/Textures/spritesheet.png");
            p.SetPosition(0f, 1f, 0f);
            p.HasTransparencyTexture = true;
            p.SetTextureRepeat(1f / 7f, 1f / 3f);
            p.SetTextureClip(0.25f, 0.15f);
            p.BlendTextureStates = false;
            AddGameObject(p);
        }
    }
}
