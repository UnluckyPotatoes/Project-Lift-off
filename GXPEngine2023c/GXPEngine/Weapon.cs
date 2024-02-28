using GXPEngine;
using GXPEngine.Core;
using System;
using TiledMapParser;

public class Weapon : Sprite
{
    private float cooldown;
    private float r;
    private float px;
    private float py;
    private float damage;
    private float fireRate;
    private Player player1;
    private Player player2;

    public float setWeaponDamage(float db)
    {
        damage += db;
        return damage;
    }
    public float setWeaponFireRate(float fr)
    {
        fireRate += fr;
        return fireRate;
    }

    public Weapon(float d, float f, string weaponName) : base(weaponName, false, false)
    {

        SetOrigin(width / 2, height / 2);
        damage = d;
        fireRate = f;
        
    }

    public float getWeaponDamage() { return damage; }
    public void Updater(float px, float py, Projectile projectile)
    {
        Inhand(px, py);
        if (Input.GetMouseButton(0))
        {
            Action(projectile);
        }
        cooldown -= Time.deltaTime;
    }

    void Inhand(float px, float py)
    {
        //Location of gun in respect to parent point towards the mouse
        int mouseX = Input.mouseX; int mouseY = Input.mouseY;
        float mouseFX = mouseX; float mouseFY = mouseY;
        Vector2 mouse = new Vector2(mouseX, mouseY);


        float xDis = mouse.x - px;
        float yDis = py - mouse.y;

        rotation = Mathf.Atan2(xDis, yDis) * 180f / Mathf.PI;
        r = (rotation - 90) * Mathf.PI / 180f;
        SetXY(256 * Mathf.Cos(r), 256 * Mathf.Sin(r));
    }

    void Action(Projectile projectile)
    {
        px = parent.x;
        py = parent.y;
        if (cooldown <= 0)
        {   
            
            Shoot(projectile);
            Console.WriteLine("shoot");
            cooldown = 1000 / fireRate;
        }
    }

    void Shoot(Projectile p)
    {
        p.x = px; p.y = py;
        p.beginX = px; p.beginY = py;
        game.AddChild(p);
    }



}

