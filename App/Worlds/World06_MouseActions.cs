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
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            Window.LoadCursorImage("Hand", "./App/Textures/cursor_hand.cur", 0.05f, 0.05f);
            Window.SetCursor("Hand");

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
            p.SetAnimationID(0);
            AddGameObject(p);

            ClassesWorld06.Box b1 = new ClassesWorld06.Box();
            b1.Name = "Box #1";
            b1.SetPosition(-4f, -0.125f, 3f);
            b1.SetScale(2f, 0.25f, 2f);
            b1.SetColor(1f, 1f, 0f);
            AddGameObject(b1);

            ClassesWorld06.Box b2 = new ClassesWorld06.Box();
            b2.Name = "Box #2";
            b2.SetPosition(+4f, -0.125f, 3f);
            b2.SetScale(2f, 0.25f, 2f);
            b2.SetColor(1f, 1f, 0f);
            AddGameObject(b2);
        }
    }
}
