using GXPEngine;
using System;
using TiledMapParser;

public class Player : Character
{
    public GameObject[] invSlot = new GameObject[3];
    readonly float speed = 2;
    readonly float invulernableWindow = 0.5f;
    private float invulernableWindowTimer;
    private int playerIndex;
    private WeaponManager weaponManager;
    private Pistol pistol;
    private Assault_Rifle assaultRifle;
    private Weapon activeWeapon;
    
    public Pistol Pistol { get { return pistol; } }
    public Assault_Rifle AssaultRifle { get { return assaultRifle; } }






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
        weaponManager = new WeaponManager();
        pistol = new Pistol();
        assaultRifle = new Assault_Rifle();
        AddChild(pistol);
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

        if (Input.GetKeyDown(Key.TAB))
        {
            ChangeWeapon();
        }

        if (IsDead(health))
        {
            LateDestroy();
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

