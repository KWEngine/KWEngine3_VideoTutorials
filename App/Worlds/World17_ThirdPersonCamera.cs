using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld17;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World17_ThirdPersonCamera : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetColorAmbient(0.5f, 0.5f, 0.5f);
            SetBackgroundSkybox("./App/Textures/background_skybox.png");
            SetBackgroundBrightnessMultiplier(2f);
            SetCameraFOV(90);

            Platform platform = new Platform();
            platform.SetModel("KWCube");
            platform.SetTexture("./App/Textures/sand_albedo.dds");
            platform.SetScale(10f, 1f, 10f);
            platform.SetPosition(0f, -0.5f, 0f);
            platform.SetTextureRepeat(2f, 2f);
            platform.IsCollisionObject = true;
            platform.IsShadowCaster = true;
            AddGameObject(platform);

            Player p = new Player();
            p.SetModel("Robot");
            p.SetRotation(0, 180, 0);
            p.SetPosition(0f, 0f, 4f, PositionMode.BottomOfAABBHitbox);
            p.IsShadowCaster = true;
            AddGameObject(p);

            MouseCursorGrab();

            HUDObject crosshair = new HUDObjectImage("./App/Textures/crosshair.png");
            crosshair.Name = "Crosshair";
            crosshair.CenterOnScreen();
            crosshair.SetScale(32f);
            AddHUDObject(crosshair);

            LightObject sun = new LightObject(LightType.Sun, ShadowQuality.High);
            sun.SetPosition(-25f, 50f, 10f);
            sun.SetTarget(0f, 0f, 0f);
            sun.SetFOV(50f);
            sun.SetNearFar(25f, 250f);
            sun.SetColor(1f, 1f, 1f, 2f);
            AddLightObject(sun);
        }
    }
}
