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
        private Vector3 _targetPosition = Vector3.Zero;
        private bool _active = false;


        public override void Act()
        {
            if(_active == false)
            {
                Vector3 mousePosition = HelperIntersection.GetMouseIntersectionPointOnPlane(Plane.XZ, 0f);
                TurnTowardsXZ(mousePosition);

                SetAnimationID(0);
                if(Mouse.IsButtonPressed(MouseButton.Left))
                {
                    if (HelperIntersection.IsMouseCursorOnAnyFast<Box>(out Box targetObject) == true)
                    {

                        _targetPosition = mousePosition;
                        _active = true;
                    }
                }
            }
            else
            {
                SetAnimationID(2);
                SetAnimationPercentageAdvance(0.006f);
                Move(0.01f);
                
                if(GetDistanceTo(_targetPosition) < 1f)
                {
                    _active = false;
                }
            }
        }
    }
}
