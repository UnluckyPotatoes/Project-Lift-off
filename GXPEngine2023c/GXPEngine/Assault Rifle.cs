using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    public class Assault_Rifle : Weapon
    {
        public Assault_Rifle(): base(35, 7f, 2f, 2f, "Assets/rifle_inHand.png") 
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

