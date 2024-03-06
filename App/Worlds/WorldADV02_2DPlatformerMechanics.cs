using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorldADV02;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class WorldADV02_2DPlatformerMechanics : World
    {
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetCameraPosition(0f, 1f, 25f);
            SetCameraTarget(0f, 1f, 0f);
            SetCameraFOV(10);

            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(1f, 1f, 1f);

            Platform platformLeft = new Platform();
            platformLeft.SetModel("KWQuad");
            platformLeft.SetTexture("./App/Textures/brick_albedo.png");
            platformLeft.SetScale(10f, 1f, 1f);
            platformLeft.SetPosition(-5f, -0.5f, 0f);
            platformLeft.SetTextureRepeat(10f, 1f);
            platformLeft.SetColor(1f, 1f, 0f);
            platformLeft.IsCollisionObject = true;
            AddGameObject(platformLeft);

            Platform platformRight = new Platform();
            platformRight.SetModel("KWQuad");
            platformRight.SetTexture("./App/Textures/brick_albedo.png");
            platformRight.SetScale(10f, 1f, 1f);
            platformRight.SetPosition(5f, -0.5f, 0f);
            platformRight.SetTextureRepeat(10f, 1f);
            platformRight.SetColor(0f, 1f, 1f);
            platformRight.IsCollisionObject = true;
            AddGameObject(platformRight);

            Platform platformHigh = new Platform();
            platformHigh.SetModel("KWQuad");
            platformHigh.SetTexture("./App/Textures/brick_albedo.png");
            platformHigh.SetScale(1f, 0.125f, 1f);
            platformHigh.SetPosition(-3f, 1.5f + 0.125f / 2f, 0f);
            platformHigh.SetTextureRepeat(1f, 0.125f);
            platformHigh.SetTextureOffset(0, 0.125f);
            platformHigh.IsCollisionObject = true;
            AddGameObject(platformHigh);

            Player p = new Player();
            p.SetPosition(0f, 0f, 0f, PositionMode.BottomOfAABBHitbox);
            AddGameObject(p);
        }
    }
}
