using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledMapParser;
using GXPEngine;

    internal class WeaponBuff : Pickup
    {
        private float damageBuff;
        private float fireRateBuff;
        public float getDamageBuff() { return damageBuff; }
        public float getFireRateBuff() { return fireRateBuff; }
        public WeaponBuff(TiledObject obj = null) : base("Chest.png") 
        {
            damageBuff = obj.GetFloatProperty("damageBuff");
            fireRateBuff = obj.GetFloatProperty("fireRateBuff");
        }
    }

