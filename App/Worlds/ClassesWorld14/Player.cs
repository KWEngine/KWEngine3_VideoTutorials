using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld14
{
    public class Player : GameObject
    {
        public override void Act()
        {
            HandleMouseCursor();
            HandleMovement();
            HandleTerrain();
            HandleCollisions();
        }

        private void HandleCollisions()
        {
            List<Intersection> intersections = GetIntersections();
            foreach (Intersection intersection in intersections)
            {
                if(intersection.Object is Wall)
                {
                    MoveOffset(intersection.MTV);
                }
            }
        }

        private void HandleMouseCursor()
        {
            Vector3 mousePos = HelperIntersection.GetMouseIntersectionPointOnPlane(Plane.XZ, 1f);
            TurnTowardsXZ(mousePos);
        }

        private void HandleTerrain()
        {
            RayTerrainIntersection rti = RaytraceTerrainBelowPosition(this.Position + new Vector3(0f, 3f, 0f));
            if(rti.IsValid)
            {
                this.SetPosition(rti.IntersectionPoint);
            }
        }

        private void HandleMovement()
        {
            bool isMoving = false;
            if(Keyboard.IsKeyDown(Keys.A))
            {
                isMoving = true;
                MoveAlongVector(CurrentWorld.CameraLookAtVectorLocalRightXZ, -0.02f);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                isMoving = true;
                MoveAlongVector(CurrentWorld.CameraLookAtVectorLocalRightXZ, +0.02f);
            }
            if (Keyboard.IsKeyDown(Keys.W))
            {
                isMoving = true;
                MoveAlongVector(CurrentWorld.CameraLookAtVectorXZ, +0.02f);
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                isMoving = true;
                MoveAlongVector(CurrentWorld.CameraLookAtVectorXZ, -0.02f);
            }

            if(HasAnimations)
            {
                if (isMoving)
                {
                    SetAnimationID(2);
                    SetAnimationPercentageAdvance(0.005f);
                }
                else
                {
                    SetAnimationID(0);
                    SetAnimationPercentage(0f);
                }
            }
        }
    }
}
