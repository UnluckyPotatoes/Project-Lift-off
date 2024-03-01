using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class Bullet : Projectile
{
    

    public Bullet(float r, int bRange, float bDamage, float bSpeed) : base("Assets/triangle.png", bRange, bDamage, bSpeed)
    {
        rotation = r;
    }

    void Update()
    {
        Shot();
    }


}

