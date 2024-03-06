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
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);


            ExplosionDetails details = new ExplosionDetails();
            details.Position = new Vector3(4f, 0f, 0f);
            details.Radius = 8f;
            WorldEvent e = new WorldEvent(2.5f, "Explosion", details);
            AddWorldEvent(e);
        }

        protected override void OnWorldEvent(WorldEvent e)
        {
            if (e.Description == "Explosion")
            {
                ExplosionDetails details = e.Tag as ExplosionDetails;

                ExplosionObject ex = new ExplosionObject(64, 0.5f, details.Radius, 5f, ExplosionType.SkullRingY);
                ex.SetPosition(details.Position);
                AddExplosionObject(ex);
            }

        }
    }
}
