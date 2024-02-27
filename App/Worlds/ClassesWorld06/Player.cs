using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld06
{
    public class Player : GameObject
    {
        public override void Act()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (Keyboard.IsKeyDown(Keys.A))
            {
                MoveOffset(-0.01f, 0f, 0f);
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                MoveOffset(+0.01f, 0f, 0f);
            }
            if (Keyboard.IsKeyDown(Keys.W))
            {
                MoveOffset(0f, 0f, -0.01f);
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                MoveOffset(0f, 0f, +0.01f);
            }
            if (Keyboard.IsKeyDown(Keys.Q))
            {
                MoveOffset(0f, -0.01f, 0f);
            }
            if (Keyboard.IsKeyDown(Keys.E))
            {
                MoveOffset(0f, +0.01f, 0f);
            }
        }
    }
}
