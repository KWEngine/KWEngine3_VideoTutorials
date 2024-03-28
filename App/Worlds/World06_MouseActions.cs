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
            Window.LoadCursorImage("ComicHand", "./App/Textures/cursor_hand.cur", 0.05f, 0.0f);
            Window.SetCursor("ComicHand");

            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");
            SetColorAmbient(1f, 1f, 1f);
            SetCameraPosition(0f, 5f, 5f);
            SetCameraTarget(0f, 0f, 0f);
            SetBackgroundFillColor(0.5f, 0f, 0.5f);

            Player p = new Player();
            p.SetModel("Robot");
            p.Name = "Player #1";
            p.SetPosition(0f, 0f, -3f);
            p.SetScale(2f);
            p.SetAnimationID(0);
            AddGameObject(p);

            Box b1 = new Box();
            b1.SetPosition(-3f, -0.125f, 2f);
            b1.SetScale(1f, 0.25f, 1f);
            AddGameObject(b1);

            Box b2 = new Box();
            b2.SetPosition(+3f, -0.125f, 2f);
            b2.SetScale(1f, 0.25f, 1f);
            AddGameObject(b2);
        }
    }
}
