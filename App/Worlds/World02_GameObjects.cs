using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld02;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World02_GameObjects : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetBackgroundFillColor(1f, 1f, 1f);
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 0f, 10f);
            SetCameraTarget(0f, 0f, 0f);

            Player p = new Player(1);
            p.SetModel("KWCube"); // alternativ: KWSphere
            p.Name = "Player #1";
            p.SetScale(2f, 2f, 2f);
            p.SetPosition(-2f, 0f, 0f);
            p.SetColor(1f, 1f, 0f);
            AddGameObject(p);

            Player p2 = new Player(2);
            p2.SetModel("KWCube"); // alternativ: KWSphere
            p2.Name = "Player #2";
            p2.SetScale(2f, 2f, 2f);
            p2.SetPosition(2f, 0f, 0f);
            p2.SetColor(1f, 0f, 1f);
            AddGameObject(p2);
        }
    }
}
