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
            SetColorAmbient(0.5f, 0.5f, 0.5f);
            SetBackgroundSkybox("./App/Textures/background_skybox.png");
            SetCameraFOV(90);

            
        }
    }
}
