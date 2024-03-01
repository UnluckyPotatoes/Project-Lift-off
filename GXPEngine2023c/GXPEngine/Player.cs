using GXPEngine;
using System;
using TiledMapParser;

public class Player : Character
{
    public GameObject[] invSlot = new GameObject[3];
    private float speed = 2;
    private float invulernableWindow = 0.5f;
    private float invulernableWindowTimer;
    private int playerIndex;
    private WeaponManager weaponManager;
    private Pistol pistol;
    private Assault_Rifle assaultRifle;
    private Shotgun shotgun;
    private Weapon activeWeapon;
    private Sound currentSound;
    private float stepTimer;
    private float stepTimerInterval = 0.5f;

    private float pistolAmmoGained = 4;
    private float assaultRifleAmmoGained = 6;
    private float shotgunAmmoGained = 2;

    public float Speed { get { return speed; } }
    public float InvulernableWindow { get { return invulernableWindow; } }
    public Pistol Pistol { get { return pistol; } }
    public Assault_Rifle AssaultRifle { get { return assaultRifle; } }
    public Shotgun Shotgun { get {  return shotgun; } }

    public float PistolAmmoGained { get { return pistolAmmoGained; } }
    public float AssaultAmmoGained { get { return assaultRifleAmmoGained; } } 
    public float ShotgunAmmoGained { get { return shotgunAmmoGained; } }

    MyGame _myGame; // reference to mygame

    public int PlayerIndex   // property
    {
        get { return playerIndex; }   // get method
    }


    public Player(TiledObject obj = null) : base("Assets/improved_spritesheet_character.png", 5, 3)
    {
        health = obj.GetFloatProperty("Health");
        maxHealth = obj.GetFloatProperty("maxHealth");
        playerIndex = obj.GetIntProperty("playerIndex");
        
        collider.isTrigger = true;
        _myGame = (MyGame)game;
        weaponManager = new WeaponManager();
        pistol = new Pistol();
        assaultRifle = new Assault_Rifle();
        shotgun = new Shotgun();
        AddChild(pistol);
    }

    void Update()
    {
        if (Input.GetKeyDown(Key.P)) // to insta kill player for testing 
        {
            health -= 10;
        }

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



            if (c is AmmoCase) 
            { 
                AmmoCase am = (AmmoCase)c;
                switch (am.GetAmmoType)
                {
                    case 0:
                        pistol.Ammo += pistolAmmoGained;
                    break;
                    case 1:
                        assaultRifle.Ammo += assaultRifleAmmoGained;
                    break;
                    case 2:
                        shotgun.Ammo += shotgunAmmoGained;
                    break;
                }
                am.Destroy();
            }



            if (c is Buffs) 
            {
                
                Buffs buffs = (Buffs)c;
                AddBuff(buffs.buffType);
                buffs.Destroy();
            
            }

        }
        MovePlayer();

        if (Input.GetKeyDown(Key.TAB))
        {
            ChangeWeapon();
        }

        if (IsDead(health))
        {
            LateDestroy();
            // play gameOver sound
            _myGame.SetCurrentLevel(4);
        }
    }

    private void AddBuff(string type) 
    {
        Console.WriteLine("Buff pickUp" + type);
        switch (type)
        {
            //character buffs
            case "speed":
                speed *= 1.1f;
                Console.Write("speed");
                break;
            case "invulernableWindow":
                invulernableWindow *= 1.1f;
                Console.Write("invulernableWindow");
                break;
            case "health":
                health = maxHealth;
                Console.Write("health");
                break;

            //weapon buffs

                //weapon damage buff
            case "pistolDamage":
                pistol.WeaponDamage *= 1.1f;
                Console.WriteLine("pistolDamage");
                break;
            case "assaultDamage":
                assaultRifle.WeaponDamage *= 1.1f;
                Console.WriteLine("assaultDamage");
                break;
            case "shotgunDamage":
                shotgun.WeaponDamage *= 1.1f;
                Console.WriteLine("shotgunDamage");
                break;

                //weapon firerate buff
            case "pistolFireRate":
                pistol.WeaponFireRate *= 1.1f;
                Console.WriteLine("pistolFireRate");
                break;
            case "assaultFireRate":
                assaultRifle.WeaponFireRate *= 1.1f;
                Console.WriteLine("assaultFireRate");
                break;
            case "shotgunFireRate":
                shotgun.WeaponFireRate *= 1.1f;
                Console.WriteLine("shotgunFireRate");
                break;

                //weapon ammo buffs
            case "pistolAmmoGained":
                pistolAmmoGained += 1;
                Console.WriteLine("pistoAmmoGained");
                break;
            case "assaultAmmoGained":
                assaultRifleAmmoGained += 1;
                Console.WriteLine("assaultAmmoGained");
                break;
            case "shotgunAmmoGained":
                shotgunAmmoGained += 1;
                Console.WriteLine("shotgunAmmoGained");
                break;




        }
    
    
    
    }
    private void ChangeWeapon()
    {

        WeaponCheck();
        RemoveChild(activeWeapon);
        weaponManager.DoSwitchWeapon();
        WeaponCheck();
        AddChild(activeWeapon);
        
    }

    private void WeaponCheck() 
    {
        switch (weaponManager.CurrentWeapon)
        {
            case WeaponManager.Weapons.WMPistol:
                activeWeapon = pistol;
                break;
            case WeaponManager.Weapons.WMAssaultRifle:
                activeWeapon = assaultRifle;
                break;
            case WeaponManager.Weapons.WMShotgun:
                activeWeapon = shotgun;
                break;
        }

    }

    public void ApplySound(Sound steppingSound)
    {
        currentSound = steppingSound;
        
    }

    void Step()
    {
        currentSound.Play();
    }

    void MovePlayer()
    {
        float px = 0;
        float py = 0;

        if (Input.GetKey(Key.W)) { py = -speed; SetCycle(11, 5); }
        if (Input.GetKey(Key.A)) { px = -speed; SetCycle(0, 3); }
        if (Input.GetKey(Key.S)) { py = speed;  SetCycle(0, 3); }
        if (Input.GetKey(Key.D)) { px = speed;  SetCycle(5, 3); }

        MoveUntilCollision(px, 0);
        MoveUntilCollision(0, py);
        if (px != 0 || py != 0)
        {
            if (stepTimer == 0)
            {
                Step();
            }
            stepTimer += Time.deltaTime / 1000f;
            if (stepTimer >= stepTimerInterval)
            {
                stepTimer = 0;
            }
        }
        else
        {
            stepTimer = 0;
        }
    }


    public void UpdateInventory(int i, GameObject f)
    {
        invSlot[i] = f;
    }




}

