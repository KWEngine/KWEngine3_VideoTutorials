using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds.ClassesWorld03
{
    public class Enemy : GameObject
    {
        public override void Act()
        {
            Player p = CurrentWorld.GetGameObjectByName<Player>("Player #1");
            if(p != null)
            {
                /*
                TurnTowardsXZ(p.Position);
                if (GetDistanceTo(p) > 3f)
                {
                    Move(0.005f);
                }
                */

                if (GetDistanceTo(p) > 3f)
                {
                    Vector3 enemyToPlayerDirection = p.Position - this.Position;
                    enemyToPlayerDirection.NormalizeFast();
                    MoveAlongVector(enemyToPlayerDirection, 0.005f);
                }
            }
        }
    }
}
