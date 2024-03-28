using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld10;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World10_ParticleFX : World
    {
        public override void Act()
        {
            if(Mouse.IsButtonPressed(MouseButton.Left))
            {
                Vector3 mousePosition = HelperIntersection.GetMouseIntersectionPointOnPlane(Plane.XZ, 0f);
                ExplosionObject e = new ExplosionObject(64, 1f, 4f, 2f, ExplosionType.DollarRingY);
                e.SetAlgorithm(ExplosionAnimation.WhirlwindUp);
                e.SetColorEmissive(1f, 1f, 1f, 0.1f);
                e.SetPosition(mousePosition);
                AddExplosionObject(e);
            }
            else if(Mouse.IsButtonPressed(MouseButton.Right))
            {
                ParticleObject p = new ParticleObject(4f, ParticleType.BurstOneUps);
                p.SetPosition(0f, 0f, 0f);
                p.SetColor(0f, 1f, 0f, 1f);
                AddParticleObject(p);
            }
        }

        public override void Prepare()
        {
            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);
        }
    }
}
