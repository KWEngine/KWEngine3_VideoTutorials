using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld14;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World14_LightsAndShadows : World
    {
        public override void Act()
        {
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");
            KWEngine.BuildTerrainModel("Terrain #1", "./App/Textures/heightmap_world13.png", 3);

            SetCameraPosition(0f, 125f, 125f);
            SetCameraTarget(0f, 0f, 0f);
            SetCameraFOV(10f);
            SetColorAmbient(0.25f, 0.25f, 0.25f);

            Player p = new Player();
            p.SetModel("Robot");
            p.SetPosition(0f, 3f, 5f);
            p.SetScale(2f);
            p.IsShadowCaster = true;
            p.IsCollisionObject = true;
            AddGameObject(p);

            CreateTerrainAndFoliage();
            CreateWalls();

            LightObject sun = new LightObjectSun(ShadowQuality.High, SunShadowType.Default);
            sun.SetPosition(-50f, 50f, 50f);
            sun.SetTarget(0f, 0f, 0f);
            sun.SetNearFar(50f, 150f);
            sun.SetFOV(75f);
            sun.SetColor(1f, 1f, 1f, 3f);
            AddLightObject(sun);

            LightObject pointLight = new LightObjectPoint(ShadowQuality.NoShadow);
            pointLight.SetColor(1f, 0f, 0f, 5f);
            pointLight.SetPosition(0f, 3f, 0f);
            pointLight.SetNearFar(0.1f, 3f);
            AddLightObject(pointLight);

        }

        private void CreateWalls()
        {
            Wall w1 = new Wall();
            w1.SetPosition(-10f, 2.5f, 5f);
            w1.SetScale(10f, 5f, 2f);
            w1.SetTextureRepeat(4.0f, 1.0f, 0);                                       // oben/unten
            w1.SetTextureRepeat(4.0f, 2.0f, 1);                                       // links/rechts
            w1.SetTextureRepeat(4.0f, 2.0f, 2);                                       // vorne/hinten
            w1.IsShadowCaster = true;
            AddGameObject(w1);

            Wall w2 = new Wall();
            w2.SetPosition(5f, 2.5f, -10f);
            w2.SetRotation(0f, 45f, 0f);
            w2.SetScale(10f, 5f, 5f);
            w2.SetTextureRepeat(4.0f, 2.0f, 0);                                       // oben/unten
            w2.SetTextureRepeat(4.0f, 2.0f, 1);                                       // links/rechts
            w2.SetTextureRepeat(4.0f, 2.0f, 2);                                       // vorne/hinten
            w2.IsShadowCaster = true;
            AddGameObject(w2);

            Wall w3 = new Wall();
            w3.SetPosition(5f, 2.5f, 12.5f);
            w3.SetRotation(0f, -25f, 0f);
            w3.SetScale(10f, 5f, 5f);
            w3.SetTextureRepeat(4.0f, 2.0f, 0);                                       // oben/unten
            w3.SetTextureRepeat(4.0f, 2.0f, 1);                                       // links/rechts
            w3.SetTextureRepeat(4.0f, 2.0f, 2);                                       // vorne/hinten
            w3.IsShadowCaster = true;
            AddGameObject(w3);
        }

        private void CreateTerrainAndFoliage()
        {
            TerrainObject t = new TerrainObject("Terrain #1");
            t.SetTexture("./App/Textures/sand_normal.dds", TextureType.Normal);
            t.SetTextureRepeat(5f, 5f);
            t.IsShadowCaster = true;
            AddTerrainObject(t);

            FoliageObject f = new FoliageObject(FoliageType.GrassDry);
            f.SetInstanceCount(10000);
            f.AttachToTerrain(t);
            f.SetPosition(-10f, 0f, 12.5f);
            f.SetScale(5f, 1.5f, 5f);
            f.SetPatchSize(17.5f, 12.5f);
            f.SetSwayFactor(0.1f);
            f.IsShadowReceiver = true;
            f.IsSizeReducedAtCorners = true;
            AddFoliageObject(f);
        }
    }
}
