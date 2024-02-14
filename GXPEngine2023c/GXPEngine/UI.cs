using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

    public class UI : Canvas
    {

        public UI(): base(100,100,false)
        {
            
            PlayerHealthBar playerHealthBar = new PlayerHealthBar();
            AddChild(playerHealthBar);
        }
    }

