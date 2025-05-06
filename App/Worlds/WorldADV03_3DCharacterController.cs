using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3_Tutorial.App.Worlds.ClassesWorldADV03;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;

namespace KWEngine3_Tutorial.App.Worlds
{
    internal class WorldADV03_3DCharacterController : World
    {
        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) Window.SetWorld(new WorldSelect());
        }

        public override void Prepare()
        {
            SetCameraPosition(0, 7.5f, 10.0f);
            SetCameraTarget(0, 1, 0);
            SetColorAmbient(0.5f, 0.5f, 0.5f);

            KWEngine.LoadModel("Player", "./App/Models/Toon.glb");
            KWEngine.LoadModel("Plane", "./App/Models/PlaneRender.obj");
            KWEngine.LoadCollider("Plane", "./App/Models/PlaneCollider.obj", ColliderType.PlaneCollider);

            Player p = new Player();
            p.Name = "Player";
            p.SetModel("Player");
            p.IsCollisionObject = true;
            p.IsShadowCaster = true;
            //p.SetHitboxToCapsule(true, CapsuleHitboxType.Sloped);
            p.SetPosition(Player.PLAYER_START);
            p.SetScale(0.5f);
            p.SetHitboxScale(0.75f, 1.0f, 1.5f);
            AddGameObject(p);

            Immovable i = new Immovable();
            i.Name = "Plane";
            i.SetModel("Plane");
            i.SetColliderModel("Plane");
            i.IsCollisionObject = true;
            i.IsShadowCaster = true;
            AddGameObject(i);

            Box box01 = new Box();
            box01.Name = "Box01";
            box01.IsCollisionObject = true;
            box01.SetPosition(-0.5f, 3.5f, -2.0f);
            box01.SetScale(1.5f, 0.5f, 1.5f);
            box01.SetColor(1, 0, 1);
            box01.IsShadowCaster = true;
            AddGameObject(box01);

            LightObject sun = new LightObjectSun(ShadowQuality.High, SunShadowType.Default);
            sun.Name = "Sun";
            sun.SetPosition(-10, 10, 0);
            sun.SetNearFar(1, 20);
            sun.SetFOV(16);
            sun.SetColor(1, 1, 1, 2.5f);
            AddLightObject(sun);
        }
    }
}
