using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using GXPEngine;

public class UI : Canvas
{
    EasyDraw score;

    EasyDraw speed;
    EasyDraw InvulernableWindow;
    EasyDraw pistolDamage;
    EasyDraw assaultDamage;
    EasyDraw shotgunDamage;
    EasyDraw pistolFireRate;
    EasyDraw assaultFireRate;
    EasyDraw shotgunFireRate;
    EasyDraw pistolAmmoGained;
    EasyDraw assaultAmmoGained;
    EasyDraw shotgunAmmoGained;

    Font upheaval;
    Player player;
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
        score = new EasyDraw(250, 60, false);
        score.TextFont(upheaval);
        score.TextAlign(CenterMode.Min, CenterMode.Center);
        score.Fill(255);
        score.Text("Score: " + _score);
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


        //speed
        upheaval = Utils.LoadFont("Assets/upheavtt.ttf", 30);
        speed = new EasyDraw(250, 60, false);
        speed.TextFont(upheaval);
        speed.TextAlign(CenterMode.Min, CenterMode.Center);
        speed.Fill(255);
        score.Text("Speed: " + player.Speed);
        speed.SetXY(1610, 95);
        AddChild(speed);

        //pistolDamage
        pistolDamage = new EasyDraw(250, 60, false);
        pistolDamage.TextFont(upheaval);
        pistolDamage.TextAlign(CenterMode.Min, CenterMode.Center);
        pistolDamage.Fill(255);
        pistolDamage.Text("pistolDamage: " + player.Pistol.WeaponDamage);
        pistolDamage.SetXY(1610, 135);
        AddChild(pistolDamage);
        //assaultDamage
        //shotgunDamage

        //pistolFireRate
        //assaultFireRate
        //shotgunFireRate

        //pistolAmmoGained
        //assaultAmmoGained
        //shotgunAmmoGained







    }

    void Update() 
    {
        score.Text(String.Format("Score: " + _score), true);
        speed.Text(String.Format("Speed: " + player.Speed), true);
        pistolDamage.Text(String.Format("pistol Damage: " + player.Pistol.WeaponDamage), true);




    }
        
}

