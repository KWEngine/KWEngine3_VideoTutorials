using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorldADV02
{
    public class Player : GameObject
    {
        private int _mode = 0;
        private float _velocityY = 0f;
        private const float GRAVITY = 0.001f;
        private float _timestampLastTextureSwitch = 0f;
        private bool _isLookingLeft = false;

        public Player()
        {
            SetModel("KWQuad");
            SetScale(1f, 1f, 1f);
            SetHitboxScale(0.3333f, 1f, 1f);
            SetTexture("./App/Textures/spritesheet.png");
            SetTextureRepeat(1f/7f, 1f/3f);
            SetTextureOffset(0, 0);
            HasTransparencyTexture = true;
            SetTextureClip(0.333f, 0.15f);
            IsCollisionObject = true;
            BlendTextureStates = false;
        }

        public override void Act()
        {
            bool isMoving = false;
            if (Keyboard.IsKeyDown(Keys.A))
            {
                MoveAlongVector(LookAtVectorLocalRight, -0.01f);
                isMoving = true;
                _isLookingLeft = true;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                MoveAlongVector(LookAtVectorLocalRight, +0.01f);
                isMoving = true;
                _isLookingLeft = false;
            }

            if (_mode == 0) // mode 0 = stand on ground
            {
                if (Keyboard.IsKeyPressed(Keys.W))
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
            if(_isLookingLeft)
            {
                SetTextureRepeat(-Math.Abs(TextureRepeat.X), TextureRepeat.Y);
            }
            else
            {
                SetTextureRepeat(Math.Abs(TextureRepeat.X), TextureRepeat.Y);
            }

            if (WorldTime - _timestampLastTextureSwitch > 1f / 10f)
            {
                float textureOffsetX = TextureOffset.X;
                float textureOffsetY = TextureOffset.Y;
                
                if (_mode == 0)
                {
                    if (isMoving)
                    {
                        textureOffsetY = 1f;
                    }
                    else
                    {
                        textureOffsetY = 0f;
                    }
                    textureOffsetX = (textureOffsetX + 1) % 7;
                }
                else
                {
                    textureOffsetX = 1;
                    textureOffsetY = 1;
                }

                SetTextureOffset(textureOffsetX, textureOffsetY);
                _timestampLastTextureSwitch = WorldTime;
            }
        }

        private void HandleGroundDetection()
        {
            Vector3 rayPositionLeft = new Vector3(AABBLeft, AABBLow, Position.Z);
            Vector3 rayPositionRight = new Vector3(AABBRight, AABBLow, Position.Z);
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
                int rayState = 0;
                float newYPosition;
                float rayDistanceLeft = float.MaxValue;
                float rayDistanceRight = float.MaxValue;
                if (rayLeft.IsValid && AABBLow - rayLeft.IntersectionPoint.Y <= 0f && _velocityY < 0f)
                {
                    rayDistanceLeft = MathHelper.Min(rayLeft.Distance, rayDistanceLeft);
                    rayState = 1;
                }
                else if (rayRight.IsValid && AABBLow - rayRight.IntersectionPoint.Y <= 0f && _velocityY < 0f)
                {
                    rayDistanceRight = MathHelper.Min(rayRight.Distance, rayDistanceRight);
                    rayState = 1;
                }

                if(rayDistanceLeft <= rayDistanceRight)
                {
                    newYPosition = rayLeft.IntersectionPoint.Y;
                }
                else
                {
                    newYPosition = rayRight.IntersectionPoint.Y;
                }

                if(rayState > 0)
                {
                    _mode = 0;
                    _velocityY = 0f;
                    SetPositionY(newYPosition, PositionMode.BottomOfAABBHitbox);
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
