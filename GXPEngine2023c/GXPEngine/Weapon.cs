using GXPEngine;
using GXPEngine.Core;
using System;

public enum WeaponSounds
    { 
    Pistol,
    AssaultRifle,
    Shotgun
    }



public class Weapon : Sprite
{
    private float cooldown;
    private float r; // rotation
    private float px; // playerX
    private float py; // playerY
    private float range;
    private float speed;
    private float damage;
    private float fireRate;
    private Player player1; // is not being used
    private Player player2; // is not being used
    private float ammo = 15;
    private Sound pistolShot = new Sound("Assets/Gunshot1Pistol.wav");
    private Sound shotgunShot = new Sound("Assets/Gunshot2Shotgun.wav");
    private Sound assaultRifleShot = new Sound("Assets/Gunshot3machine.wav");
    private Sound[] gunsounds;



    public float Ammo
    {
        get { return ammo; } 
        set { ammo = value; }
    }

    public float WeaponDamage 
    { 
        get { return damage; }
        set { damage = value; }
    }
    
    public float WeaponFireRate 
    {
        get {return fireRate; }
        set { fireRate = value; }
    }

    public float WeaponRange 
    {
        get { return range; }
        set { range = value; }
    }
 
    public Weapon(int wRange, float wSpeed, float wDamage, float wFireRate, string weaponName) : base(weaponName, false, false)
    {
        SetOrigin(width / 2, height / 2);
        range = wRange;
        speed = wSpeed;
        damage = wDamage;
        fireRate = wFireRate;
    }

    private WeaponSounds weaponSounds;
    
    public void Updater(float px, float py)
    {
        Inhand(px, py);


        if (this is Pistol && Input.GetMouseButtonDown(0)) { Action(1); weaponSounds = WeaponSounds.Pistol; }
        if (this is Assault_Rifle && Input.GetMouseButton(0)) { Action(1); weaponSounds = WeaponSounds.AssaultRifle; }
        if (this is Shotgun && Input.GetMouseButtonDown(0)) { Action(5); weaponSounds = WeaponSounds.Shotgun; }


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
        r = (rotation - 90)
            * Mathf.PI / 180f;
        SetXY(256 * Mathf.Cos(r), 256 * Mathf.Sin(r));
    }

    void Action(int pellets)
    {


        float rot = rotation;
        px = parent.x;
        py = parent.y;
        if (cooldown <= 0 && ammo > 0)
        {

            switch (weaponSounds)
            {
                case WeaponSounds.Pistol:
                    pistolShot.Play();
                    break;
                case WeaponSounds.AssaultRifle:
                    assaultRifleShot.Play();
                    break;
                case WeaponSounds.Shotgun:
                    shotgunShot.Play();
                    break;
            }


            ammo -= 1;
            for (int i = 0; i < pellets; i++)
            {
                switch (i)
                {
                    case 0:
                        rot = rotation;
                        break;
                    case 1:
                        rot = rotation + 10;
                        break;
                    case 2:
                        rot = rotation - 10;
                        break;
                    case 3:
                        rot = rotation + 20;
                        break;
                    case 4:
                        rot = rotation - 20;
                        break;
                }
                Shoot(new Bullet(rot, range, damage, speed));
            }
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

