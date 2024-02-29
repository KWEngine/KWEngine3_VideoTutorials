using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld10
{
    public class Player : GameObject
    {
        public override void Act()
        {
            bool hasMoved = HandleMovement();
            if (HasAnimations)
            {
                if (hasMoved)
                {
                    SetAnimationID(2);
                    SetAnimationPercentageAdvance(0.005f);
                }
                else
                {
                    SetAnimationID(0);
                    SetAnimationPercentageAdvance(0.001f);
                }
            }
        }

        private bool HandleMovement()
        {
            bool hasMoved = false;
            if (Keyboard.IsKeyDown(Keys.A))
            {
                MoveOffset(-0.01f, 0f, 0f);
                hasMoved = true;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                MoveOffset(+0.01f, 0f, 0f);
                hasMoved = true;
            }
            if (Keyboard.IsKeyDown(Keys.W))
            {
                MoveOffset(0f, 0f, -0.01f);
                hasMoved = true;
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                MoveOffset(0f, 0f, +0.01f);
                hasMoved = true;
            }
            if (Keyboard.IsKeyDown(Keys.Q))
            {
                MoveOffset(0f, -0.01f, 0f);
                hasMoved = true;
            }
            if (Keyboard.IsKeyDown(Keys.E))
            {
                hasMoved = true;
                MoveOffset(0f, +0.01f, 0f);
            }

            return hasMoved;
        }
    }
}
