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
        private Player _p;
        private PlayerInfo _playerInfo;

        public void SetPlayerInfo(PlayerInfo pInfo)
        {
            _playerInfo = pInfo;
        }

        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) { Window.SetWorld(new WorldSelect()); return; }

            if (Keyboard.IsKeyPressed(Keys.F1))
            {
                PlayerInfo switchInfo = new PlayerInfo();
                switchInfo.Position = _p.Position;
                switchInfo.Scale = _p.Scale;

                World11a_WorldSwitch newWorld = new World11a_WorldSwitch();
                newWorld.SetPlayerInfo(switchInfo);
                Window.SetWorld(newWorld);
            }
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.5f, 0.25f, 0.0f);

            _p = new Player();
            _p.SetModel("Robot");
            _p.Name = "Player #1";
            if (_playerInfo != null)
            {
                _p.SetPosition(_playerInfo.Position);
                _p.SetScale(_playerInfo.Scale);
            }
            else
            {
                _p.SetPosition(0f, 0f, 0f);
                _p.SetScale(1f);
            }
            AddGameObject(_p);
        }
    }
}
