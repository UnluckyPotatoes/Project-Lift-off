using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    public class Pistol : Weapon
    {
    
        public Pistol() : base(1, 0.75f, "Assets/pistol_inHand.png") 
        {
            SetOrigin(width / 2, height / 2);
        }

        void Update() 
        {         
            if (parent != null) {
                Updater(parent.x, parent.y);
            } 
        }
    }

