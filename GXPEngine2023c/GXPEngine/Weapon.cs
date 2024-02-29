using GXPEngine;
using GXPEngine.Core;
using System;
using TiledMapParser;

public class Weapon : Sprite
{
    private float cooldown;
    private float r; // rotation
    private float px; // playerX
    private float py; // playerY
    private float damage;
    private float fireRate;
    private Player player1; // is not being used
    private Player player2; // is not being used
    private float ammo = 5;
    private Sound pistolShot = new Sound("Assets/Gunshot1Pistol.wav");
    public float Ammo { get { return ammo; } }

    public float setWeaponDamage(float db) // is not being used
    {
        damage += db; // what does the b mean?
        return damage;
    }
    public float setWeaponFireRate(float fr) // is not being used
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

    public float getWeaponDamage() { return damage; } // is not being used
    public void Updater(float px, float py, Projectile projectile)
    {
        /*pistolShot = new Sound("Assets/Gunshot1Pistol.wav");*/
        Inhand(px, py);
        if (Input.GetMouseButton(0))
        {
            Action(projectile);
            pistolShot.Play();
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
        if (cooldown <= 0 && ammo > 0)
        {
            ammo -= 1;
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

