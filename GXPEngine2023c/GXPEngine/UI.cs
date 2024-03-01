using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using GXPEngine;

public class UI : Canvas
{
    private EasyDraw score;
    private EasyDraw speed;
    private EasyDraw InvulernableWindow;
    private EasyDraw pistolDamage;
    private EasyDraw assaultDamage;
    private EasyDraw shotgunDamage;
    private EasyDraw pistolFireRate;
    private EasyDraw assaultFireRate;
    private EasyDraw shotgunFireRate;
    private EasyDraw pistolAmmoGained;
    private EasyDraw assaultAmmoGained;
    private EasyDraw shotgunAmmoGained;

    private Font upheaval;
    private Player player;
    private int _score;
    public int _Score { get { return _score; }
                  set { _score = value; }
    }

    public UI(int width, int height) : base(width, height, false)
    {
        player = game.FindObjectOfType<Player>();
        
        
        
        UIBuilder();

    }

    private void UIBuilder() 
    {
        UIScore();  
        UIHealth();
        UIWeaponInventory();
        UIStats();
    }


    private void UIScore() {
        upheaval = Utils.LoadFont("Assets/upheavtt.ttf", 40);
        score = new EasyDraw(320, 60, false);
        score.TextFont(upheaval);
        score.TextAlign(CenterMode.Min, CenterMode.Center);
        score.Fill(255);
        score.SetXY(1610, 15);
        AddChild(score);
    }

    private void UIHealth() 
    {
        PlayerHealthBar player1HealthBar = new PlayerHealthBar();
        PlayerHealthBar player2HealthBar = new PlayerHealthBar();
        AddChild(player1HealthBar);
    }

    private void UIWeaponInventory() 
    {
        WeaponInventory player1WeaponInventory = new WeaponInventory();
        WeaponInventory player2WeaponInventory = new WeaponInventory();
        AddChild(player1WeaponInventory);
    }



    private void UIStats() 
    {
        upheaval = Utils.LoadFont("Assets/upheavtt.ttf", 30);

        //speed
        speed = new EasyDraw(320, 60, false);
        speed.TextFont(upheaval);
        speed.TextAlign(CenterMode.Min, CenterMode.Center);
        speed.Fill(255);
        speed.SetXY(1610, 95);
        AddChild(speed);

        //pistolDamage
        pistolDamage = new EasyDraw(320, 60, false);
        pistolDamage.TextFont(upheaval);
        pistolDamage.TextAlign(CenterMode.Min, CenterMode.Center);
        pistolDamage.Fill(255);
        pistolDamage.SetXY(0, 180);
        AddChild(pistolDamage);

        //assaultDamage
        assaultDamage = new EasyDraw(320, 60, false);
        assaultDamage.TextFont(upheaval);
        assaultDamage.TextAlign(CenterMode.Min, CenterMode.Center);
        assaultDamage.Fill(255);
        assaultDamage.SetXY(0, 400);
        AddChild(assaultDamage);

        //shotgunDamage
        shotgunDamage = new EasyDraw(320, 60, false);
        shotgunDamage.TextFont(upheaval);
        shotgunDamage.TextAlign(CenterMode.Min, CenterMode.Center);
        shotgunDamage.Fill(255);
        shotgunDamage.SetXY(0, 620);
        AddChild(shotgunDamage);

        //pistolFireRate
        pistolFireRate = new EasyDraw(320, 60, false);
        pistolFireRate.TextFont(upheaval);
        pistolFireRate.TextAlign(CenterMode.Min, CenterMode.Center);
        pistolFireRate.Fill(255);
        pistolFireRate.SetXY(0, 220);
        AddChild(pistolFireRate);

        //assaultFireRate
        assaultFireRate = new EasyDraw(320, 60, false);
        assaultFireRate.TextFont(upheaval);
        assaultFireRate.TextAlign(CenterMode.Min, CenterMode.Center);
        assaultFireRate.Fill(255);
        assaultFireRate.SetXY(0, 440);
        AddChild(assaultFireRate);

        //shotgunFireRate
        shotgunFireRate = new EasyDraw(320, 60, false);
        shotgunFireRate.TextFont(upheaval);
        shotgunFireRate.TextAlign(CenterMode.Min, CenterMode.Center);
        shotgunFireRate.Fill(255);
        shotgunFireRate.SetXY(0, 660);
        AddChild(shotgunFireRate);

        //pistolAmmoGained
        pistolAmmoGained = new EasyDraw(250, 60, false);
        pistolAmmoGained.TextFont(upheaval);
        pistolAmmoGained.TextAlign(CenterMode.Min, CenterMode.Center);
        pistolAmmoGained.Fill(255);
        pistolAmmoGained.SetXY(0, 260);
        AddChild(pistolAmmoGained);

        //assaultAmmoGained
        assaultAmmoGained = new EasyDraw(320, 60, false);
        assaultAmmoGained.TextFont(upheaval);
        assaultAmmoGained.TextAlign(CenterMode.Min, CenterMode.Center);
        assaultAmmoGained.Fill(255);
        assaultAmmoGained.SetXY(0, 480);
        AddChild(assaultAmmoGained);

        //shotgunAmmoGained
        shotgunAmmoGained = new EasyDraw(320, 60, false);
        shotgunAmmoGained.TextFont(upheaval);
        shotgunAmmoGained.TextAlign(CenterMode.Min, CenterMode.Center);
        shotgunAmmoGained.Fill(255);
        shotgunAmmoGained.SetXY(0, 700);
        AddChild(shotgunAmmoGained);


    }

    void Update() 
    {
        score.Text(String.Format("Score: " + _score), true);
        speed.Text(String.Format("Speed: " + player.Speed), true);

        pistolDamage.Text(String.Format("Damage: " + player.Pistol.WeaponDamage), true);
        assaultDamage.Text(String.Format("Damage: " + player.AssaultRifle.WeaponDamage), true);
        shotgunDamage.Text(String.Format("Damage: " + player.Shotgun.WeaponDamage), true);

        pistolFireRate.Text(String.Format("FireRate: " + player.Pistol.WeaponFireRate), true);
        assaultFireRate.Text(String.Format("FireRate: " + player.AssaultRifle.WeaponFireRate), true);
        shotgunFireRate.Text(String.Format("FireRate: " + player.Shotgun.WeaponFireRate), true);

        pistolAmmoGained.Text(String.Format("+Ammo: " + player.PistolAmmoGained), true);
        assaultAmmoGained.Text(String.Format("+Ammo: " + player.AssaultAmmoGained), true);
        shotgunAmmoGained.Text(String.Format("+Ammo: " + player.ShotgunAmmoGained), true);

    }
        
}

