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
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetBackgroundFillColor(0.5f, 0f, 0.5f);

            Player p = new Player(1);
            p.Name = "Player #1";
            p.SetPosition(+2f, 0f, 0f);
            p.SetScale(2f);
            p.SetColor(1f, 1f, 0f);
            AddGameObject(p);

            Player p2 = new Player(2);
            p2.Name = "Player #2";
            p2.SetPosition(-2f, 0f, 0f);
            p2.SetScale(2f);
            p2.SetColor(0f, 1f, 0f);
            AddGameObject(p2);
        }
    }
}
