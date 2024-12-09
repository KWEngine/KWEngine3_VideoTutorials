using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorldADV01
{
    public class Companion : GameObject
    {
        public override void Act()
        {
            FlowField f = CurrentWorld.GetFlowFieldByName("FlowField #1");
            if (f != null)
            {
                if(f.HasTarget)
                {
                    MoveAlongVector(f.GetBestDirectionForPosition(this.Position), 0.05f);
                    if(HelperVector.GetDistanceBetweenVectorsXZ(f.TargetPosition, this.Position) < 0.001f)
                    {
                        f.UnsetTarget();
                    }
                }
            }

            HandleTerrain();
            HandleCollisions();
        }

        private void HandleTerrain()
        {
            RayTerrainIntersection rti = RaytraceTerrainBelowPosition(this.Position);
            if (rti.IsValid)
            {
                this.SetPosition(rti.IntersectionPoint + new Vector3(0f, 0.5f, 0f));
            }
        }

        private void HandleCollisions()
        {
            List<Intersection> intersections = GetIntersections();
            foreach (Intersection intersection in intersections)
            {
                if (intersection.Object is Wall)
                {
                    MoveOffset(intersection.MTV);
                }
            }
        }
    }
}
