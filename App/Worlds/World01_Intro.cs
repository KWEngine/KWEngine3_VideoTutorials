using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld01;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World01_Intro : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetBackgroundFillColor(1f, 0f, 1f);

            Player p = new Player();
            p.Name = "Player #1";
            p.SetPosition(0f, 0f, 0f);
            p.SetScale(2f);
            AddGameObject(p);
        }
    }
}
