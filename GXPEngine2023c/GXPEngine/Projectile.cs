using System;
using GXPEngine;

public class Projectile : Sprite
{
    public float beginX;
    public float beginY;


    readonly int range;
    readonly float damage;
    readonly float speed;

    public Projectile(string projectileName, int r, float d, float s) : base(projectileName)
    {
        SetOrigin(width / 2, height / 2);
        range = r;
        damage = d;
        speed = s;
    }

    public void Shot()
    {
        Moving();
    }

    void Moving()
    {
        //Movement of projectile
        Move(0, -speed);
        if (RangeCheck()) 
        {
            End();
        }

        //on collision
        GameObject[] cols = GetCollisions();
        foreach (GameObject c in cols)
        {
            if (c is Enemy)
            {
                Enemy enemy = (Enemy)c;
                enemy.health -= damage;
                End();
            }
            
        }
    }

    Boolean RangeCheck()
    {
        if (x > beginX + 16 * range || x < beginX - 16 * range ||
            y > beginY + 16 * range || y < beginY - 16 * range)
        {
            return true;
        }
        return false;
    }

   

    void End()
    {
        Destroy();
    }
}
    
