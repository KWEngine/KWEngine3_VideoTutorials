using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld11;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World11a_WorldSwitch : World
    {
        public override void Act()
        {
            if(Keyboard.IsKeyPressed(Keys.Space))
            {
                Player p = GetGameObjectByName<Player>("Player #1");
                if(p != null)
                {
                    PlayerInfo pInfo = new PlayerInfo();
                    pInfo.Position = p.Position;
                    pInfo.Model = p.GetModelName();

                    World11b_WorldSwitch w11b = new World11b_WorldSwitch();
                    w11b.SetPlayerInfo(pInfo);
                    Window.SetWorld(w11b);
                }

                
            }
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 2.5f, 2.5f);
            SetCameraTarget(0f, 1f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.0f, 0.25f, 0.5f);

            Player p = new Player();
            p.Name = "Player #1";
            p.SetModel("Robot");
            // ?
            // ?
            AddGameObject(p);
        }
    }
}
