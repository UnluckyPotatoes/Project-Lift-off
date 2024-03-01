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
    private int pistolAmmoGained = 4;
    private int assaultRifleAmmoGained = 6;
    private int shotgunAmmoGained = 2;




    public Pistol Pistol { get { return pistol; } }
    public Assault_Rifle AssaultRifle { get { return assaultRifle; } }
    public Shotgun Shotgun { get {  return shotgun; } }

    MyGame _myGame; // reference to mygame


    public int PlayerIndex   // property
    {
        get { return playerIndex; }   // get method
    }


    public Player(TiledObject obj = null) : base("Assets/charcater_f3_copy.png", 1, 1)
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
        switch (type)
        {
            case "speed":
                speed *= 1.1f;
                break;
            case "pistolDamage":
                pistol.WeaponDamage *= 1.1f;
                break;
            case "assaultDamage":
                assaultRifle.WeaponDamage *= 1.1f;
                break;
            case "shotgunDamage":
                shotgun.WeaponDamage *= 1.1f;
                break;
            case "pistolFireRate":
                pistol.WeaponFireRate *= 1.1f;
                break;
            case "assaultFireRate":
                assaultRifle.WeaponFireRate *= 1.1f;
                break;
            case "shotgunFireRate":
                shotgun.WeaponFireRate *= 1.1f;
                break;
            case "pistolAmmoGained":
                pistolAmmoGained += 1;
                break;
            case "assaultAmmoGained":
                assaultRifleAmmoGained += 1;
                break;
            case "shotgunAmmoGained":
                shotgunAmmoGained += 1;
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

        if (Input.GetKey(Key.W)) { py = -speed; }
        if (Input.GetKey(Key.A)) { px = -speed; }
        if (Input.GetKey(Key.S)) { py = speed; }
        if (Input.GetKey(Key.D)) { px = speed; }

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

