using GXPEngine;
using System;

public class Projectile : Sprite
{
    public float beginX;
    public float beginY;


    readonly int range;
    readonly float damage;
    readonly float speed;

    public Projectile(string projectileName, int bRange, float bDamage, float bSpeed) : base(projectileName)
    {
        scale = 0.5f;
        SetOrigin(width / 2, height / 2);
        range = bRange;
        damage = bDamage;
        speed = bSpeed;
    }

    public void Shot()
    {
        Moving();
    }

    private void Moving()
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

    private Boolean RangeCheck()
    {
        if (x > beginX + 16 * range || x < beginX - 16 * range ||
            y > beginY + 16 * range || y < beginY - 16 * range)
        {
            return true;
        }
        return false;
    }



    private void End()
    {
        Destroy();
    }
}

