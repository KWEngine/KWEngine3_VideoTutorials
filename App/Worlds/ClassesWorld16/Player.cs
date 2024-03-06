using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld16
{
    public class Player : GameObject
    {
        public override void Act()
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

            CurrentWorld.AddCameraRotationFromMouseDelta();
            MoveAndStrafeAlongCameraXZ(forward, strafe, 0.01f);
            CurrentWorld.UpdateCameraPositionForFirstPersonView(Center, Settings.CAM_OFFSET);

            // Optional:
            TurnTowardsXZ(CurrentWorld.CameraPosition + CurrentWorld.CameraLookAtVector);

            HUDObject crosshair = CurrentWorld.GetHUDObjectImageByName("Crosshair");
            if (crosshair != null)
            { 
                List<RayIntersection> hits = HelperIntersection.RayTraceObjectsForViewVectorFastest(
                    CurrentWorld.CameraPosition, 
                    CurrentWorld.CameraLookAtVector, 
                    this, 
                    0f, 
                    true, 
                    typeof(Target)
                    );

                if(hits.Count > 0 )
                {
                    RayIntersection firstHit = hits[0];
                    if (firstHit.Object is Target)
                    {
                        crosshair.SetColor(1f, 0f, 0f);
                    }
                    else
                    {
                        crosshair.SetColor(1f, 1f, 1f);
                    }
                }
                else
                {
                    crosshair.SetColor(1f, 1f, 1f);
                }
            }
        }
    }
}
