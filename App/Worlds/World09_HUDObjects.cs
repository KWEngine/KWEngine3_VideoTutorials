using System;
using System.Collections.Generic;
using KWEngine3;
using KWEngine3.GameObjects;
using KWEngine3.Helper;
using KWEngine3_Tutorial.App.Worlds.ClassesWorld09;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace KWEngine3_Tutorial.App.Worlds
{
    public class World09_HUDObjects : World
    {
        private Player _p;

        public override void Act()
        {
            if (Keyboard.IsKeyPressed(Keys.Escape)) { Window.SetWorld(new WorldSelect()); return; }

            HUDObjectText coordinates = GetHUDObjectTextByName("HUDCoordinates");
            if(coordinates != null)
            {
                int posX = (int)_p.Position.X;
                int posY = (int)_p.Position.Y;
                int posZ = (int)_p.Position.Z;

                coordinates.SetText("(" + (posX >= 0 ? "+" + posX : posX) + "|" + (posY >= 0 ? "+" + posY : posY) + "|" + (posZ >= 0 ? "+" + posZ : posZ) + ")");
            }

            HUDObjectImage catLogo = GetHUDObjectImageByName("HUDCatLogo");
            if(catLogo != null)
            {
                if(catLogo.IsMouseCursorOnMe())
                {
                    catLogo.SetColorEmissive(1f, 1f, 0f);
                    if (Mouse.IsButtonDown(MouseButton.Left))
                    {
                        catLogo.SetColorEmissiveIntensity(0.5f);
                    }
                    else
                    {
                        catLogo.SetColorEmissiveIntensity(0.25f);
                    }
                }
                else
                {
                    catLogo.SetColorEmissive(1f, 1f, 0f);
                    catLogo.SetColorEmissiveIntensity(0.0f);
                }
            }
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 10f, 0f);
            SetCameraTarget(0f, 0f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);

            _p = new Player();
            _p.SetModel("Robot");
            _p.Name = "Player #1";
            _p.SetPosition(0f, 0f, 0f);
            _p.SetScale(1f);
            AddGameObject(_p);

            HUDObjectText textPosition = new HUDObjectText("Position:");
            textPosition.Name = "HUDPosition";
            textPosition.SetPosition(8, 16);
            textPosition.SetScale(32);
            textPosition.SetTextAlignment(TextAlignMode.Left);
            textPosition.SetCharacterDistanceFactor(0.8f);
            AddHUDObject(textPosition);

            HUDObjectText textCoordinates = new HUDObjectText("");
            textCoordinates.Name = "HUDCoordinates";
            textCoordinates.SetPosition(256, 16);
            textCoordinates.SetScale(32);
            textCoordinates.SetTextAlignment(TextAlignMode.Left);
            textCoordinates.SetCharacterDistanceFactor(0.8f);
            AddHUDObject(textCoordinates);

            HUDObjectImage imageCatLogo = new HUDObjectImage("./App/Textures/hud_catlogo.png");
            imageCatLogo.Name = "HUDCatLogo";
            imageCatLogo.SetScale(64, 96);
            imageCatLogo.SetPosition(Window.Width - imageCatLogo.Scale.X - 4, imageCatLogo.Scale.X + 4);
            AddHUDObject(imageCatLogo);

        }
    }
}
