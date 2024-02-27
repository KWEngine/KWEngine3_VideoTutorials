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
        private bool _isBackground2d = false;
        private float _background2dOffset = 0f;

        public override void Act()
        {
            if(Keyboard.IsKeyPressed(Keys.B))
            {
                if (_isBackground2d)
                {
                    SetBackgroundSkybox("./App/Textures/background_skybox.png", 0f, SkyboxType.CubeMap);
                    _isBackground2d = false;
                }
                else
                {
                    SetBackground2D("./App/Textures/background_2d.png");
                    SetBackground2DRepeat(GetBackgroundImageSize().X / Window.Width, GetBackgroundImageSize().Y / Window.Height);
                    _isBackground2d = true;
                }
            }

            if(_isBackground2d)
            {
                SetBackground2DOffset(_background2dOffset, 0f);
                _background2dOffset += 0.0005f;
            }
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
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

            SetBackgroundSkybox("./App/Textures/background_skybox.png", 0f, SkyboxType.CubeMap);
        }
    }
}
