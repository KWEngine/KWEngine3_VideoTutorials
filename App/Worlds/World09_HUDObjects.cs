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
        public override void Act()
        {
            Player p = GetGameObjectByName<Player>("Player #1");
            if (p != null)
            {
                int x = (int)p.Position.X;
                int y = (int)p.Position.Y;
                int z = (int)p.Position.Z;

                string text = "(" + x + "|" + y + "|" + z + ")";
                HUDObjectText h = GetHUDObjectTextByName("HUDPosition");
                if(h != null)
                {
                    h.SetText(text);
                }
            }

            HUDObject myCat = GetHUDObjectImageByName("HUDCat");
            if(myCat != null)
            {
                if(myCat.IsMouseCursorOnMe() == true)
                {
                    myCat.SetColorEmissiveIntensity(0.4f);
                }
                else
                {
                    myCat.SetColorEmissiveIntensity(0f);
                }
            }
        }

        public override void Prepare()
        {
            KWEngine.LoadModel("Robot", "./App/Models/robotERS.fbx");

            SetCameraPosition(0f, 5f, 5f);
            SetCameraTarget(0f, 1f, 0f);
            SetColorAmbient(1f, 1f, 1f);
            SetBackgroundFillColor(0.25f, 0.25f, 0.25f);

            Player p = new Player();
            p.SetModel("Robot");
            p.Name = "Player #1";
            p.SetScale(2f);
            p.SetPosition(0f, 0f, -4f);
            AddGameObject(p);

            HUDObjectText hudPosition = new HUDObjectText("Beispieltext");
            hudPosition.SetFont(FontFace.XanhMono);
            hudPosition.SetCharacterDistanceFactor(0.8f);
            hudPosition.SetPosition(16, 16);
            hudPosition.SetTextAlignment(TextAlignMode.Left);
            hudPosition.SetColor(1f, 1f, 1f);
            hudPosition.Name = "HUDPosition";
            AddHUDObject(hudPosition);

            HUDObjectImage catLogo = new HUDObjectImage("./App/Textures/hud_catlogo.png");
            catLogo.SetScale(96, 128);
            catLogo.Name = "HUDCat";
            catLogo.SetPosition(Window.Width - 96, 96);
            catLogo.SetColorEmissive(1f, 1f, 0f);
            catLogo.SetColorEmissiveIntensity(0f);
            AddHUDObject(catLogo);
        }
    }
}
