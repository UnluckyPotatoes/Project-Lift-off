﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

    public class Pickup : Sprite
    {
        public Pickup(string img) : base(img)
        {
            SetOrigin(width/2 , height/2);
            collider.isTrigger = true;
        }
    }
