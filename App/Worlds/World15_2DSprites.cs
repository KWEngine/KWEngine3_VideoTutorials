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
            SetCameraPosition(0f, 1f, 25f);
            SetCameraTarget(0f, 1f, 0f);
            SetCameraFOV(10);

            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0f, 0f, 1f);

            Player p = new Player();
            p.SetModel("KWQuad");
            p.SetPosition(0f, 0.5f, 0f);
            p.SetScale(1f, 1f, 1f);
            //p.SetHitboxScale(0.25f, 0.825f, 1f);
            p.SetTexture("./App/Textures/spritesheet.png");
            p.SetTextureRepeat(1f / 7f, 1f / 3f);
            p.SetTextureOffset(0, 1);
            //p.HasTransparencyTexture = true;
            p.IsCollisionObject = true;
            p.BlendTextureStates = false;
            AddGameObject(p);

            Platform platform1 = new Platform();
            platform1.SetModel("KWQuad");
            platform1.SetTexture("./App/Textures/brick_albedo.png");
            platform1.SetScale(10f, 1f, 1f);
            platform1.SetPosition(0f, -0.5f, 0f);
            platform1.SetTextureRepeat(10f, 1f);
            platform1.IsCollisionObject = true;
            AddGameObject(platform1);

            Platform platform2 = new Platform();
            platform2.SetModel("KWQuad");
            platform2.SetTexture("./App/Textures/brick_albedo.png");
            platform2.SetScale(1f, 0.125f, 1f);
            platform2.SetPosition(-3f, 0.125f / 2f, 0f);
            platform2.SetTextureRepeat(1f, 0.25f);
            platform2.SetTextureOffset(0, 0.125f);
            platform2.IsCollisionObject = true;
            AddGameObject(platform2);


        }
    }
}
