using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;


public class Menu : EasyDraw
{
   public Menu() : base(300, 100, false)
    {
        Sprite button = new Sprite("game_PlayButton.jpg");

        this.DrawSprite(button);


        if (Input.GetKey(Key.ENTER)); // idea is if you press enter, you will play the game, i just need an easy blinking anim for the button and a background
        {
            
        }
    }
}
