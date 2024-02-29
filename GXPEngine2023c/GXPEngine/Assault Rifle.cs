using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    public class Assault_Rifle : Weapon
    {
        public Assault_Rifle(): base(1, 2f, "Assets/rifle_inHand.png") 
        {
            SetOrigin(width / 2, height / 2);
        }
        void Update()
        {
             if (parent != null) 
             {
                Updater(parent.x, parent.y);
                
             }
        }
    }

