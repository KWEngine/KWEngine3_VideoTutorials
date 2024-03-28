using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld04;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World04_CollisionDetection : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("TreasureChest", "./App/Models/TreasureChest.fbx");

            SetBackgroundFillColor(0.5f, 0.5f, 0.5f);
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);

            Player p = new Player();
            p.SetPosition(-3f, 0f, 2f);
            p.SetScale(2f, 2f, 2f);
            p.SetColor(1f, 1f, 0f);
            p.IsCollisionObject = true;
            AddGameObject(p);

            Enemy e = new Enemy();
            e.SetModel("TreasureChest");
            e.SetPosition(3f, 0f, -2f);
            e.SetScale(2f, 2f, 2f);
            e.SetColor(1f, 0f, 1f);
            e.IsCollisionObject = true;
            AddGameObject(e);

            Ghost g = new Ghost();
            g.SetPosition(-3f, 0f, -2f);
            g.SetColor(0f, 0f, 1f);
            g.SetOpacity(0.5f);
            g.IsCollisionObject = true;
            AddGameObject(g);
        }
    }
}
