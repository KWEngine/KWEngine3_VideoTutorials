using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld03;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World03_MultipleClasses : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetBackgroundFillColor(0.5f, 0.5f, 0.5f);
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);

            Player p = new Player();
            p.SetModel("KWCube"); // alternativ: KWSphere
            p.Name = "Player #1";
            p.SetScale(2f, 2f, 2f);
            p.SetPosition(-4f, 0f, 3f);
            p.SetColor(1f, 1f, 0f);
            AddGameObject(p);

            Enemy e = new Enemy();
            e.SetModel("KWCube");
            e.Name = "Enemy #1";
            e.SetScale(2f, 2f, 2f);
            e.SetColor(1f, 0f, 1f);
            e.SetPosition(4f, 0f, -3f);
            AddGameObject(e);
        }
    }
}
