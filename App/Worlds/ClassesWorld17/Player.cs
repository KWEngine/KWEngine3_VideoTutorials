using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld17
{
    public class Player : GameObject
    {
        private Vector2 _currentCameraRotation = new Vector2(0, 0);
        private float _limitYUp = 5;
        private float _limitYDown = -75;
        private Vector3 _cameraOffset = new Vector3(0f, 0.75f, 0f);

        public override void Act()
        {
            AddRotationY(-MouseMovement.X * KWEngine.MouseSensitivity);
            UpdateCameraPosition(MouseMovement * KWEngine.MouseSensitivity);

            HandleMovement();
        }

        private void UpdateCameraPosition(Vector2 msMovement)
        {
            _currentCameraRotation.X += msMovement.X;
            _currentCameraRotation.Y += msMovement.Y;
            if (_currentCameraRotation.Y < _limitYDown)
            {
                _currentCameraRotation.Y = _limitYDown;
            }
            if (_currentCameraRotation.Y > _limitYUp)
            {
                _currentCameraRotation.Y = _limitYUp;
            }

            Vector3 newCamPos = HelperRotation.CalculateRotationForArcBallCamera(
                    Center + _cameraOffset,          // Drehpunkt
                    5f,                              // Distanz zum Drehpunkt
                    _currentCameraRotation.X,        // Drehung links/rechts
                    _currentCameraRotation.Y,        // Drehung oben/unten
                    false,                           // invertiere links/rechts?
                    false                            // invertiere oben/unten?
            );

            CurrentWorld.SetCameraPosition(newCamPos);
            CurrentWorld.SetCameraTarget(Center + _cameraOffset);
        }

        private void HandleMovement()
        {
            int forward = 0;
            int strafe = 0;

            if (Keyboard.IsKeyDown(Keys.A))
                strafe -= 1;
            if (Keyboard.IsKeyDown(Keys.D))
                strafe += 1;
            if (Keyboard.IsKeyDown(Keys.W))
                forward += 1;
            if (Keyboard.IsKeyDown(Keys.S))
                forward -= 1;

            MoveAndStrafeAlongCameraXZ(forward, strafe, 0.01f);

            if (HasAnimations)
            {
                if (strafe != 0 || forward != 0)
                {
                    SetAnimationID(2);
                    SetAnimationPercentageAdvance(0.006f);
                }
                else
                {
                    SetAnimationID(0);
                    SetAnimationPercentageAdvance(0.005f);
                }
            }
        }
    }
}
