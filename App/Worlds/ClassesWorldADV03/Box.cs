using KWEngine3.GameObjects;
using System;
using System.Collections.Generic;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorldADV03
{
    public class Box : Collider
    {
        private const float YMAX = 5.0f;
        private const float YMIN = 3.5f;
        private bool _up = true;
        private float _timestampLastMovement = 2;

        public override void Act()
        {
            /*
            if (WorldTime > _timestampLastMovement)
            {
                if (_up)
                {
                    MoveOffset(0, +0.005f, 0);
                    if (Position.Y >= YMAX)
                    {
                        SetPositionY(YMAX);
                        _up = false;
                        _timestampLastMovement += 2;
                    }
                }
                else
                {
                    MoveOffset(0, -0.005f, 0);
                    if (Position.Y <= YMIN)
                    {
                        SetPositionY(YMIN);
                        _up = true;
                        _timestampLastMovement += 2;
                    }
                }
            }
            */
        }
    }
}
