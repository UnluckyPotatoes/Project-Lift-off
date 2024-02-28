﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    internal class Pistol : Weapon
    {
    
        public Pistol() : base(1, 0.75f, "Assets/triangle.png") 
        {
            SetOrigin(width / 2, height / 2);
    }

        void Update() 
        {         
            if (parent != null) {
                Updater(parent.x, parent.y, new Bullet(rotation));

            } 
        }
    }
