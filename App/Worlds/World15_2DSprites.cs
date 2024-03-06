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

            Platform platform = new Platform();
            platform.SetModel("KWQuad");
            platform.SetTexture("./App/Textures/brick_albedo.png");
            platform.SetScale(10f, 1f, 1f);
            platform.SetPosition(0f, -0.5f, 0f);
            platform.SetTextureRepeat(10f, 1f);
            platform.IsCollisionObject = true;
            AddGameObject(platform);

            Player p = new Player();
            p.SetModel("KWQuad");
            p.SetPosition(0f, 0.5f, 0f);
            p.SetTexture("./App/Textures/spritesheet.png");
            p.SetTextureRepeat(1f / 7f, 1f / 3f);
            p.SetTextureOffset(0, 0);
            p.HasTransparencyTexture = true;
            p.SetTextureClip(0.333f, 0.15f);
            p.BlendTextureStates = false;
            AddGameObject(p);
        }
    }
}
