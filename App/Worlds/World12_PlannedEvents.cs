using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld12;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World12_PlannedEvents : World
    {
        public override void Act()
        {
            
        }

        public override void Prepare()
        {
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);

            ExplosionDetails ed = new ExplosionDetails();
            ed.Position = new Vector3(-2f, 0f, 0f);
            ed.Radius = 4f;

            WorldEvent we = new WorldEvent(3f, "Explosion", ed);
            AddWorldEvent(we);
        }

        protected override void OnWorldEvent(WorldEvent e)
        {
            if(e.Description == "Explosion")
            {
                ExplosionDetails ed = (ExplosionDetails)e.Tag;

                ExplosionObject eo = new ExplosionObject(64, 0.5f, ed.Radius, 2f, ExplosionType.CubeRingY);
                eo.SetPosition(ed.Position);
                AddExplosionObject(eo);
            }
        }
    }
}
