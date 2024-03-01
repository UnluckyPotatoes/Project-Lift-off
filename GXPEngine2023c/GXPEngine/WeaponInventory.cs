using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;
using TiledMapParser;

public class WeaponInventory : EasyDraw
{
    private Player player;
    private Weapon weapon1;
    private Weapon weapon2;
    private Weapon weapon3;
    private Font upheaval;
    private int weaponImgX = 120;
    private int ammoCountX = 240;


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
            weapon3 = player.Shotgun;
        }





        
    }
    private void ShowWeapons()
    {
        Sprite Pistol = new Sprite("Assets/pistol_inInventory.png", false, false) { y = 160, x = weaponImgX };
        Pistol.SetOrigin(Pistol.width / 2, Pistol.height / 2);
        AddChild(Pistol);

        Sprite AssaultRifle = new Sprite("Assets/rifle_inInventory.png", false, false) { y = 380, x = weaponImgX };
        AssaultRifle.SetOrigin(AssaultRifle.width / 2, AssaultRifle.height / 2);
        AddChild(AssaultRifle);

        Sprite Shotgun = new Sprite("Assets/shotgun_inInventory.png", false, false) { y = 580, x = weaponImgX };
        Shotgun.SetOrigin(Shotgun.width / 2, Shotgun.height / 2);
        AddChild(Shotgun);
    }


    private void UpdateWeapons()
    {
        upheaval = Utils.LoadFont("Assets/upheavtt.ttf", 40);
        Text(" ", true);
        Text("x" + weapon1.Ammo, ammoCountX, 160);
        Text("x" + weapon2.Ammo, ammoCountX, 380);
        Text("x" + weapon3.Ammo, ammoCountX, 580);
    }

    void Update()
    {
        UpdateWeapons();
    }





}

