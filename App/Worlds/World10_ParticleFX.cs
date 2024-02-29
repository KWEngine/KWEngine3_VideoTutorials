using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld10;
using OpenTK.Graphics.ES11;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World10_ParticleFX : World
    {
        private Player _p;
        private float _timestampSpawn = 0f;
        public override void Act()
        {
            if(WorldTime - _timestampSpawn > 3f)
            {
                ExplosionObject ex = new ExplosionObject(32, 0.5f, 4f, 2f, ExplosionType.HeartRingY);
                ex.SetPosition(_p.Position);
                ex.SetColorEmissive(1f, 0f, 1f, 2f);
                AddExplosionObject(ex);

                HelperIntersection.get


                _timestampSpawn = WorldTime;
            }
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);

            _p = new Player();
            _p.SetModel("Robot");
            _p.Name = "Player #1";
            _p.SetPosition(0f, 0f, 0f);
            _p.SetScale(1f);
            AddGameObject(_p);
        }
    }
}
