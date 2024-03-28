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
        private bool _isLookingRight = true;
        private float _timestampLastAnimationChange = 0.0f;
        private float _textureOffsetX = 0.0f;
        private float _textureOffsetY = 0.0f;

        public override void Act()
        {
            bool hasMoved = false;

            if (Keyboard.IsKeyDown(Keys.A))
            {
                hasMoved = true;
                _isLookingRight = false;
                MoveOffset(-0.01f, 0f, 0f);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                hasMoved = true;
                _isLookingRight = true;
                MoveOffset(+0.01f, 0f, 0f);
            }

            if(hasMoved)
            {
                _textureOffsetY = 1f;
            }
            else
            {
                _textureOffsetY = 0f;
            }

            float currentTime = WorldTime;
            if(currentTime - _timestampLastAnimationChange > 0.067f)
            {
                _textureOffsetX = (_textureOffsetX + 1f) % 7f;
                _timestampLastAnimationChange = currentTime;
            }
            SetTextureOffset(_textureOffsetX, _textureOffsetY);

            if(_isLookingRight == false)
            {
                SetTextureRepeat(-1f / 7f, 1f / 3f);
            }
            else
            {
                SetTextureRepeat(+1f / 7f, 1f / 3f);
            }
        }
    }
}
