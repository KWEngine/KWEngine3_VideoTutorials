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
        private const float GRAVITY = 0.01f;
        public override void Act()
        {
            if (Keyboard.IsKeyDown(Keys.A))
            {
                MoveAlongVector(LookAtVectorLocalRight, -0.01f);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                MoveAlongVector(LookAtVectorLocalRight, +0.01f);
            }

            if (_mode == 0) // stand on ground
            {
                if (Keyboard.IsKeyPressed(Keys.Space))
                {
                    _mode = 1;
                    _velocityY = 0.3f;
                }
            }
            else // in air
            {
                _velocityY -= GRAVITY;
                MoveOffset(0f, _velocityY, 0f);
            }

            if (_mode == 1)
            {
                Vector3 testPositionLeft = new Vector3(AABBLeft, AABBLow + 0.25f, Center.Z);
                Vector3 testPositionRight = new Vector3(AABBRight, AABBLow + 0.25f, Center.Z);
                List<RayIntersection> rayResultsLeft = RaytraceObjectsNearbyFast(testPositionLeft, -Vector3.UnitY);
                List<RayIntersection> rayResultsRight = RaytraceObjectsNearbyFast(testPositionRight, -Vector3.UnitY);
                RayIntersection rayIntersectionLeft = new RayIntersection();
                RayIntersection rayIntersectionRight = new RayIntersection();
                if (rayResultsLeft.Count > 0)
                {
                    rayIntersectionLeft = rayResultsLeft[0];
                }
                if (rayResultsRight.Count > 0)
                {
                    rayIntersectionRight = rayResultsRight[0];
                }

                if (rayIntersectionLeft.IsValid || rayIntersectionRight.IsValid)
                {
                    if (rayIntersectionLeft.IsValid)
                    {
                        if (rayIntersectionLeft.Distance <= 0.25f)
                        {
                            SetPositionY(AABBLow + (0.25f - rayIntersectionLeft.Distance));
                            _mode = 0;
                            _velocityY = 0f;
                        }
                    }
                    if (rayIntersectionRight.IsValid)
                    {
                        if (rayIntersectionRight.Distance <= 0.25f)
                        {
                            SetPositionY(AABBLow + (0.25f - rayIntersectionRight.Distance));
                            _mode = 0;
                            _velocityY = 0f;
                        }
                    }
                }
            }

        }
    }
}
