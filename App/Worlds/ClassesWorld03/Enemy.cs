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
            if (p != null)
            {
                Vector3 playerPosition = p.Position;
                TurnTowardsXZ(playerPosition);

                if(GetDistanceTo(playerPosition) > 3f)
                {
                    Move(0.01f);
                }
            }

        }
    }
}
