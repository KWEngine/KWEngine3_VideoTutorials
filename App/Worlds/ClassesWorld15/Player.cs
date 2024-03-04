using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld15
{
    public class Player : GameObject
    {
        private int _mode = 0;
        private float _velocityY = 0f;
        private const float GRAVITY = 0.001f;

        public override void Act()
        {
            bool isMoving = false;
            if (Keyboard.IsKeyDown(Keys.A))
            {
                MoveAlongVector(LookAtVectorLocalRight, -0.01f);
                isMoving = true;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                MoveAlongVector(LookAtVectorLocalRight, +0.01f);
                isMoving = true;
            }

            if (_mode == 0) // mode 0 = stand on ground
            {
                if (Keyboard.IsKeyPressed(Keys.Space))
                {
                    _mode = 1;
                    _velocityY = 0.06f;
                    MoveOffset(0f, _velocityY, 0f);
                }
            }
            else // mode 1 = in air
            {
                _velocityY -= GRAVITY;
                MoveOffset(0f, _velocityY, 0f);
            }

            HandleGroundDetection();
            HandleCollisions();
            HandleAnimation(isMoving);
        }

        private void HandleAnimation(bool isMoving)
        {
            if (_mode == 0)
            {
                if(isMoving)
                {

                }
            }
        }

        private void HandleGroundDetection()
        {
            Vector3 rayPositionLeft = new Vector3(AABBLeft, AABBLow, Position.Z);
            Vector3 rayPositionRight = new Vector3(AABBLeft, AABBLow, Position.Z);
            RayIntersection rayLeft = RaytraceObjectsNearbyFast(rayPositionLeft, -Vector3.UnitY).FirstOrDefault();
            RayIntersection rayRight = RaytraceObjectsNearbyFast(rayPositionRight, -Vector3.UnitY).FirstOrDefault();
            if (_mode == 0)
            {
                if (rayLeft.IsValid == false && rayRight.IsValid == false)
                {
                    _mode = 1;
                }
                else if (rayLeft.IsValid && rayLeft.Distance > 0.01f && rayRight.IsValid && rayRight.Distance > 0.01f)
                {
                    _mode = 1;
                }
            }
            else
            {
                if (rayLeft.IsValid && AABBLow - rayLeft.IntersectionPoint.Y <= 0f && _velocityY < 0f)
                {
                    _mode = 0;
                    _velocityY = 0f;
                    SetPositionY(rayLeft.IntersectionPoint.Y + this.Scale.Y * 0.5f);
                }
                else if (rayRight.IsValid && AABBLow - rayRight.IntersectionPoint.Y <= 0f && _velocityY < 0f)
                {
                    _mode = 0;
                    _velocityY = 0f;
                    SetPositionY(rayLeft.IntersectionPoint.Y + this.Scale.Y * 0.5f);
                }
            }
        }

        private void HandleCollisions()
        {
            List<Intersection> intersections = GetIntersections<Collider>();
            foreach (Intersection i in intersections)
            {
                if (_mode == 1)
                {
                    if (i.MTV.Y < 0f)
                    {
                        _velocityY = 0f;
                    }
                }
                MoveOffset(i.MTV);
            }
        }
    }
}
