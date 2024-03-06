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
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetBackgroundFillColor(0.5f, 0f, 0.5f);

            Player p = new Player();
            p.Name = "Player #1";
            p.SetPosition(-3f, 0f, +2f);
            p.SetScale(2f);
            p.IsCollisionObject = true;
            AddGameObject(p);

            Enemy e = new Enemy();
            e.Name = "Enemy #1";
            e.SetPosition(3f, 0f, -2f);
            e.SetScale(2f);
            e.SetColor(1f, 0f, 0f);
            e.IsCollisionObject = true;
            AddGameObject(e);

            Ghost g = new Ghost();
            g.Name = "Booh!";
            g.SetPosition(-3f, 1f, -3f);
            g.SetScale(1);
            g.SetOpacity(0.25f);
            g.SetColor(0f, 1f, 1f);
            g.IsCollisionObject = true;
            AddGameObject(g);
        }
    }
}
