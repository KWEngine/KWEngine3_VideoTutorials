using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld08;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SkiaSharp;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World08_Textures : World
    {
        public override void Act()
        {
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(10f, 10f, 10f);
            SetCameraTarget(0f, 2f, 0f);
            SetBackgroundFillColor(1f, 1f, 1f);

            Sphere s = new Sphere();
            s.SetModel("KWSphere");
            s.Name = "Sphere #1";
            s.SetPosition(-3f, 4f, 0f);
            s.SetScale(4f);
            s.SetTexture("./App/Textures/worldmap_albedo.jpg", TextureType.Albedo);
            AddGameObject(s);

            Box b1 = new Box();
            b1.SetModel("KWCube");
            b1.Name = "Box #1";
            b1.SetPosition(-3f, 0f, 0f);
            b1.SetScale(4f);
            b1.SetTexture("./App/Textures/tiles_albedo.jpg", TextureType.Albedo);
            b1.SetTextureRepeat(2f, 2f);
            AddGameObject(b1);

            Box b2 = new Box();
            b2.SetModel("KWPlatform");
            b2.Name = "Box #2";
            b2.SetPosition(+3f, 0f, 0f);
            b2.SetScale(4f, 2f, 4f);
            b2.SetTexture("./App/Textures/tiles_albedo.jpg", TextureType.Albedo, 0);
            b2.SetTexture("./App/Textures/sand_albedo.dds", TextureType.Albedo, 1);
            b2.SetTexture("./App/Textures/sand_albedo.dds", TextureType.Albedo, 2);
            b2.SetTextureRepeat(1f, 1f, 0); // top/bottom
            b2.SetTextureRepeat(4f, 2f, 1); // left/right
            b2.SetTextureRepeat(4f, 2f, 2); // front/back

            AddGameObject(b2);
        }
    }
}
