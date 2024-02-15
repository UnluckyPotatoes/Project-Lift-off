using GXPEngine;
using System;
using TiledMapParser;

public class Player : AnimationSprite
{
    public GameObject[] invSlot = new GameObject[3];
    readonly float speed = 2;
    readonly float invulernableWindow = 0.5f;
    private float invulernableWindowTimer;
    
    public Player(TiledObject obj = null) : base("Assets/charcater_f3_copy.png", 1, 1)
    {
        health = obj.GetFloatProperty("Health");
        collider.isTrigger = true;
    }

    void Update()
    {
        Animate(0.085f);
        invulernableWindowTimer += (Time.deltaTime / 1000f);
        GameObject[] cols = GetCollisions();
        foreach (GameObject c in cols)
        {
            
            if (c is Enemy && invulernableWindowTimer >= invulernableWindow)
            {
                Enemy enemy = (Enemy)c;
                health -= enemy.GetDamage();
                invulernableWindowTimer = 0;
            }

        }
        MovePlayer();

        if (IsDead(health))
        {
            LateDestroy();
        }
    }

    void MovePlayer()
    {
        float px = 0;
        float py = 0;

        if (Input.GetKey(Key.W)) { py = -speed; }
        if (Input.GetKey(Key.A)) { px = -speed; }
        if (Input.GetKey(Key.S)) { py = speed; }
        if (Input.GetKey(Key.D)) { px = speed; }

        MoveUntilCollision(px, 0);
        MoveUntilCollision(0, py);
    }


    public void UpdateInventory(int i, GameObject f)
    {
        invSlot[i] = f;
    }
}

