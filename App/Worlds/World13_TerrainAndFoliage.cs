using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld13;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World13_TerrainAndFoliage : World
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
            SetColorAmbient(1f, 1f, 1f);

            Player p = new Player();
            p.SetModel("Robot");
            p.SetPosition(0f, 3f, 5f);
            p.SetScale(2f);
            p.IsCollisionObject = true;
            AddGameObject(p);

            CreateWalls();

            TerrainObject to = new TerrainObject("Terrain1");
            to.IsCollisionObject = true;
            AddTerrainObject(to);

            FoliageObject fo = new FoliageObject(FoliageType.GrassFresh, 10000);
            fo.AttachToTerrain(to);
            fo.SetPosition(-12.5f, 0f, 12.5f);
            fo.SetScale(3f, 2f, 2f);
            fo.SetPatchSize(17.5f, 12.5f);
            fo.SetSwayFactor(0.15f);
            AddFoliageObject(fo);
        }

        private void CreateWalls()
        {
            Wall w1 = new Wall();
            w1.SetPosition(-10f, 2.5f, 5f);
            w1.SetScale(10f, 5f, 2f);
            w1.SetTextureRepeat(4.0f, 1.0f, 0);                                       // oben/unten
            w1.SetTextureRepeat(4.0f, 2.0f, 1);                                       // links/rechts
            w1.SetTextureRepeat(4.0f, 2.0f, 2);                                       // vorne/hinten
            AddGameObject(w1);

            Wall w2 = new Wall();
            w2.SetPosition(5f, 2.5f, -10f);
            w2.SetRotation(0f, 45f, 0f);
            w2.SetScale(10f, 5f, 5f);
            w2.SetTextureRepeat(4.0f, 2.0f, 0);                                       // oben/unten
            w2.SetTextureRepeat(4.0f, 2.0f, 1);                                       // links/rechts
            w2.SetTextureRepeat(4.0f, 2.0f, 2);                                       // vorne/hinten
            AddGameObject(w2);

            Wall w3 = new Wall();
            w3.SetPosition(5f, 2.5f, 12.5f);
            w3.SetRotation(0f, -25f, 0f);
            w3.SetScale(10f, 5f, 5f);
            w3.SetTextureRepeat(4.0f, 2.0f, 0);                                       // oben/unten
            w3.SetTextureRepeat(4.0f, 2.0f, 1);                                       // links/rechts
            w3.SetTextureRepeat(4.0f, 2.0f, 2);                                       // vorne/hinten
            AddGameObject(w3);
        }
    }
}
