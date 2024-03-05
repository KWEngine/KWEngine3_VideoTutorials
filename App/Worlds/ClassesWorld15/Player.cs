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
        private float _timestampLastTextureSwitch = 0f;
        private bool _isLookingLeft = false;

        public Player()
        {
            
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
                float textureOffsetY;
                
                if (isMoving)
                {
                    textureOffsetY = 1f;
                }
                else
                {
                    textureOffsetY = 0f;
                }
                textureOffsetX = (textureOffsetX + 1) % 7;

                SetTextureOffset(textureOffsetX, textureOffsetY);
                _timestampLastTextureSwitch = WorldTime;
            }
        }
    }
}
