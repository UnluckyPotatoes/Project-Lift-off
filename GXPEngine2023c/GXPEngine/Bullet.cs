using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

internal class Bullet : Projectile
{
    

    public Bullet(float r) : base("Assets/triangle.png", 12, 1, 7)
    {
        rotation = r;
    }

    void Update()
    {
        Shot();
    }


}

