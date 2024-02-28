using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld08;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

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
            s.SetPosition(0f, +5f, 2f);
            s.SetScale(2f);
            s.SetTexture("./App/Textures/worldmap_albedo.jpg", TextureType.Albedo);
            AddGameObject(s);

            Box b = new Box();
            b.SetModel("KWCube");
            b.Name = "Box #1";
            b.SetPosition(-1f, 2f, 0f);
            b.SetScale(8f, 4f, 8f);
            b.SetTexture("./App/Textures/tiles_albedo.jpg", TextureType.Albedo);
            AddGameObject(b);
        }
    }
}
