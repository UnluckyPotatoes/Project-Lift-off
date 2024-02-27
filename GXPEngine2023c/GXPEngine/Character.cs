using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

    public class Character : AnimationSprite
    {
    public float health;
    public float maxHealth;

    public Boolean IsDead(float health)
    {
        if (health <= 0)
        {
            return true;
        }
        return false;
    }


    public Character(string sprite, int rows, int collums) : base(sprite, rows, collums) 
        { 
            
        
        }

    }

