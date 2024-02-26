using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld02
{
    public class Player : GameObject
    {
        private int _id = -1;

        public Player(int id)
        {
            _id = id;
        }

        public override void Act()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (_id == 1)
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
            else if (_id == 2)
            {
                if (Keyboard.IsKeyDown(Keys.Left))
                {
                    MoveOffset(-0.01f, 0f, 0f);
                }
                if (Keyboard.IsKeyDown(Keys.Right))
                {
                    MoveOffset(+0.01f, 0f, 0f);
                }
                if (Keyboard.IsKeyDown(Keys.Up))
                {
                    MoveOffset(0f, 0f, -0.01f);
                }
                if (Keyboard.IsKeyDown(Keys.Down))
                {
                    MoveOffset(0f, 0f, +0.01f);
                }
                if (Keyboard.IsKeyDown(Keys.PageDown))
                {
                    MoveOffset(0f, -0.01f, 0f);
                }
                if (Keyboard.IsKeyDown(Keys.PageUp))
                {
                    MoveOffset(0f, +0.01f, 0f);
                }
            }
        }
    }
}
