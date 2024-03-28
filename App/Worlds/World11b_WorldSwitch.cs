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
    public class World11b_WorldSwitch : World
    {
        private PlayerInfo _pInfo;

        public override void Act()
        {

        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 2.5f, 2.5f);
            SetCameraTarget(0f, 1f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.5f, 0.25f, 0.0f);

            Player p = new Player();
            p.Name = "Player #1";
            p.SetModel("Robot");
            if(_pInfo != null)
            {
                p.SetModel(_pInfo.Model);
                p.SetPosition(_pInfo.Position);
            }
            AddGameObject(p);
        }

        public void SetPlayerInfo(PlayerInfo pInfo)
        {
            _pInfo = pInfo;
        }
    }
}
