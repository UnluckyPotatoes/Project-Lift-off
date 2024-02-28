﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class WeaponInventory : EasyDraw
{
    private Player player;
    private Weapon[] weapons;
    private Weapon weapon1;
    private Weapon weapon2;
    private Weapon weapon3;
    
    

    public WeaponInventory() : base(1920, 1080, false)
    {
        FindWeapons();
        ShowWeapons();
    }


    private void FindWeapons()
    {
       player = game.FindObjectOfType<Player>();
        if (player != null) 
        {
            weapon1 = player.Pistol;
            weapon2 = player.AssaultRifle;
        }





        
    }
    private void ShowWeapons()
    {
        Sprite Pistol = new Sprite("Assets/pistol_inInventory.png", false, false) { y = 160, x = 160 };
        Pistol.SetOrigin(Pistol.width / 2, Pistol.height / 2);
        AddChild(Pistol);
        
        Sprite AssaultRifle = new Sprite("Assets/rifle_inInventory.png", false, false) { y = 320, x = 160 };
        AssaultRifle.SetOrigin(AssaultRifle.width / 2, AssaultRifle.height / 2);
        AddChild(AssaultRifle);
        

    }


    private void UpdateWeapons()
    {
        Text(" ", true);
        Text("x" + weapon1.Ammo, 240, 160);
        Text("x" + weapon2.Ammo, 240, 320);
    }

    void Update() 
    { 
        UpdateWeapons();
    }
    

    


}
