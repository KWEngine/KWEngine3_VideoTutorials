using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld16;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World16_FirstPersonView : World
    {
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetBackgroundSkybox("./App/Textures/background_skybox.png");
            SetColorAmbient(0.5f, 0.5f, 0.5f);
            SetBackgroundBrightnessMultiplier(2f);

            PlatformEntity platform = new PlatformEntity();
            platform.SetModel("KWCube");
            platform.SetTexture("./App/Textures/sand_albedo.dds");
            platform.SetScale(10f, 1f, 10f);
            platform.SetPosition(0f, -0.5f, 0f);
            platform.SetTextureRepeat(2f, 2f);
            platform.IsCollisionObject = true;
            platform.IsShadowCaster = true;
            AddGameObject(platform);

            Target t = new Target();
            t.Name = "Target";
            t.SetModel("KWSphere");
            t.SetPosition(0f, 2f, -4f);
            t.SetColor(1f, 0f, 1f);
            t.IsCollisionObject = true;
            t.IsShadowCaster = true;
            AddGameObject(t);

            Player p = new Player();
            p.SetPosition(0f, 1f, 4f);
            p.SetRotation(0f, 180f, 0f);
            p.SetOpacity(0);
            p.IsCollisionObject = true;
            p.IsShadowCaster = false;
            AddGameObject(p);

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
