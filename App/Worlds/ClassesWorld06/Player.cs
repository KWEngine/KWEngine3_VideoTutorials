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
        private Vector3 _currentTargetPosition = Vector3.Zero;
        private bool _isCurrentTargetSet = false;

        public override void Act()
        {
            if (_isCurrentTargetSet == false)
            {
                TurnTowardsMouse();
            }
            else
            {
                MoveTowardsTarget();
            }

            CheckClickOnTarget();
        }

        private void TurnTowardsMouse()
        {
            Vector3 mousePosition = HelperIntersection.GetMouseIntersectionPointOnPlane(Plane.XZ, 0f);
            TurnTowardsXZ(mousePosition);
        }

        private void CheckClickOnTarget()
        {
            if(Mouse.IsButtonPressed(MouseButton.Left) && HelperIntersection.IsMouseCursorOnAnyFast<Box>(out Box b))
            {
                TurnTowardsXZ(b.Position);
                _currentTargetPosition = b.Position;
                _isCurrentTargetSet = true;
            }
        }

        private void MoveTowardsTarget()
        {
            float distanceToTarget = GetDistanceTo(_currentTargetPosition, true);
            if (distanceToTarget > 0.25f)
            {
                Move(0.01f);
                SetAnimationID(2);
                SetAnimationPercentageAdvance(0.005f);
            }
            else
            {
                SetAnimationID(0);
                _isCurrentTargetSet = false;
            }
        }
    }
}
