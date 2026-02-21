using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class WorldSelect : World
    {
        private List<HUDObject> _displayedHUDObjects = new List<HUDObject>();
        private List<string> _worldNamesStd = new List<string>() { "Einleitung", "Objekte erzeugen", "Unterschiedliche Objekte", "Kollisionsbehandlung",
                                                            "3D-Modelle laden", "Mausinteraktionen", "Hintergrundbilder", "Texturen verwenden",
                                                            "HUD-Objekte anzeigen", "Partikeleffekte", "Welten wechseln", "Events planen",
                                                            "Terrain und Bodengewächse", "Licht und Schatten", "2D-Objekte animieren", "First-Person-Ansicht",
                                                            "Third-Person-Ansicht"};
        private List<string> _worldNamesAdv = new List<string>() { "Wegfindungs-KI", "2D-Player-Controller", "3D-Player-Controller" };

        public override void Act()
        {
            foreach(HUDObjectText hot in  _displayedHUDObjects)
            {
                if(hot.IsMouseCursorOnMe())
                {
                    hot.SetColorEmissiveIntensity(1.0f);
                    if (Mouse.IsButtonPressed(MouseButton.Left))
                    {
                        hot.SetColorEmissive(1f, 0.5f, 0f);
                        string worldname = hot.Name;
                        LoadWorldByName(worldname);
                    }
                    
                }
                else
                {
                    hot.SetColorEmissiveIntensity(0.0f);
                }
            }
        }

        public override void Prepare()
        {
            MouseCursorReset();
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(1f, 1f, 1f);

            HUDObjectText h1 = new HUDObjectText("Grundlagen-Tutorials");
            h1.SetCharacterDistanceFactor(0.85f);
            h1.SetTextAlignment(TextAlignMode.Left);
            h1.SetPosition(32f, 32f);
            h1.SetColor(0.5f, 0.5f, 0f);
            AddHUDObject(h1);

            float sizePerHUDObject = 600;
            float currentX = 64f;
            float currentY = 64f;
            for(int i = 1; i <= _worldNamesStd.Count; i++)
            {
                HUDObjectText h = new HUDObjectText("World #" + i.ToString().PadLeft(2, '0') + ": " + _worldNamesStd[i - 1]);
                h.Name = i.ToString();
                h.SetFont(FontFace.OpenSans);
                h.SetScale(28f);
                h.SetColorEmissive(0f, 0.5f, 0f);
                h.SetColorOutline(0.75f, 0.75f, 0.75f, 0.25f);
                h.SetCharacterDistanceFactor(1.0f);
                h.SetTextAlignment(TextAlignMode.Left);
                h.SetPosition(currentX, currentY);
                h.SetColor(0, 0, 0);
                AddHUDObject(h);
                _displayedHUDObjects.Add(h);

                if(currentX > Window.Width - sizePerHUDObject * 1.25f)
                {
                    currentY += 28f;
                    currentX = 64f;
                }
                else
                {
                    currentX += sizePerHUDObject;
                }
            }

            currentY += 64f;
            HUDObjectText h2 = new HUDObjectText("Weiterführende Tutorials");
            h2.SetCharacterDistanceFactor(0.85f);
            h2.SetTextAlignment(TextAlignMode.Left);
            h2.SetPosition(32f, currentY);
            h2.SetColor(0.5f, 0.5f, 0f);
            AddHUDObject(h2);
            
            currentY += 32f;
            currentX = 64f;
            for (int i = 1; i <= _worldNamesAdv.Count; i++)
            {
                HUDObjectText h = new HUDObjectText("World #ADV" + i.ToString().PadLeft(2, '0') + ": " + _worldNamesAdv[i - 1]);
                h.Name = "ADV" + i.ToString();
                h.SetFont(FontFace.OpenSans);
                h.SetScale(28f);
                h.SetColorEmissive(0f, 0.5f, 0f);
                h.SetColorOutline(0.75f, 0.75f, 0.75f, 0.25f);
                h.SetCharacterDistanceFactor(1.0f);
                h.SetTextAlignment(TextAlignMode.Left);
                h.SetPosition(currentX, currentY);
                h.SetColor(0, 0, 0);
                AddHUDObject(h);
                _displayedHUDObjects.Add(h);

                if (currentX > Window.Width - sizePerHUDObject * 1.25f)
                {
                    currentY += 28f;
                    currentX = 64f;
                }
                else
                {
                    currentX += sizePerHUDObject;
                }
            }
        }

        private void LoadWorldByName(string name)
        {
            if(name.StartsWith("ADV"))
            {
                name = name.Substring(3);
                int index = Convert.ToInt32(name);
                LoadAdvancedWorldByIndex(index);
            }
            else
            {
                int index = Convert.ToInt32(name);
                switch(index)
                {
                    case 1: Window.SetWorld(new World01_Intro()); break;
                    case 2: Window.SetWorld(new World02_GameObjects()); break;
                    case 3: Window.SetWorld(new World03_MultipleClasses()); break;
                    case 4: Window.SetWorld(new World04_CollisionDetection()); break;
                    case 5: Window.SetWorld(new World05_3DModels()); break;
                    case 6: Window.SetWorld(new World06_MouseActions()); break;
                    case 7: Window.SetWorld(new World07_Backgrounds()); break;
                    case 8: Window.SetWorld(new World08_Textures()); break;
                    case 9: Window.SetWorld(new World09_HUDObjects()); break;
                    case 10: Window.SetWorld(new World10_ParticleFX()); break;
                    case 11: Window.SetWorld(new World11a_WorldSwitch()); break;
                    case 12: Window.SetWorld(new World12_PlannedEvents()); break;
                    case 13: Window.SetWorld(new World13_TerrainAndFoliage()); break;
                    case 14: Window.SetWorld(new World14_LightsAndShadows()); break;
                    case 15: Window.SetWorld(new World15_2DSprites()); break;
                    case 16: Window.SetWorld(new World16_FirstPersonView()); break;
                    case 17: Window.SetWorld(new World17_ThirdPersonCamera()); break;
                }
            }
        }

        private void LoadAdvancedWorldByIndex(int index)
        {
            if (index == 1)
                Window.SetWorld(new WorldADV01_FlowFieldNavigation());
            else if(index == 2)
                Window.SetWorld(new WorldADV02_2DPlatformerMechanics());
            else if(index == 3)
                Window.SetWorld(new WorldADV03_3DCharacterController());
        }
    }
}
