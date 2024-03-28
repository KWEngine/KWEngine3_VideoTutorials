using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld07;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World07_Backgrounds : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetBackgroundSkybox("./App/Textures/background_skybox.png", 0f, SkyboxType.CubeMap);
            SetBackgroundBrightnessMultiplier(4f);
            SetColorAmbient(0.25f, 0.25f, 0.25f);
            SetCameraPosition(10f, 5f, 10f);
            SetCameraTarget(0f, 2f, 0f);
            SetCameraFOV(120);

            Box b1 = new Box();
            b1.Name = "Box #1";
            b1.SetPosition(0f, +5f, 2f);
            b1.SetScale(2f);
            b1.SetColor(1f, 1f, 0f);
            AddGameObject(b1);

            Box b2 = new Box();
            b2.Name = "Box #2";
            b2.SetPosition(-1f, 2f, 0f);
            b2.SetScale(8f, 4f, 8f);
            b2.SetColor(0f, 1f, 1f);
            AddGameObject(b2);
        }
    }
}
