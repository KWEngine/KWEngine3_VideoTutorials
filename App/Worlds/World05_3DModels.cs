using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld05;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World05_3DModels : World
    {
        public override void Act()
        {
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 5f, 5f);
            SetCameraTarget(0f, 1f, 0f);
            SetBackgroundFillColor(0.5f, 0f, 0.5f);

            Player p = new Player();
            p.SetModel("Robot");
            p.SetScale(1f);
            AddGameObject(p);
        }
    }
}
