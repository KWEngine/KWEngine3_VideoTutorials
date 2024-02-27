using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld06;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World06_MouseActions : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetBackgroundFillColor(0.5f, 0f, 0.5f);

            Player p = new Player();
            p.SetModel("Robot");
            p.Name = "Player #1";
            p.SetPosition(0f, 0f, -3f);
            p.SetScale(2f);
            p.IsCollisionObject = true;
            p.SetAnimationID(0);
            AddGameObject(p);
        }
    }
}
