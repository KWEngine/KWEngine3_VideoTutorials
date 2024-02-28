using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld09;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SkiaSharp;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World09_HUDObjects : World
    {
        public override void Act()
        {
           
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);

            Player p = new Player();
            p.SetModel("Robot");
            p.Name = "Player #1";
            p.SetPosition(0f, 0f, 0f);
            p.SetScale(1f);
            AddGameObject(p);
        }
    }
}
