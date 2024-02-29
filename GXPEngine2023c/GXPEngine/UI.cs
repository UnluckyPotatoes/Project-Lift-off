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
    Font upheaval;
    private int _score;
    public int _Score { get { return _score; }
                  set { _score += value; }
    }

    public UI(int width, int height) : base(width, height, false)
    {
        PlayerHealthBar player1HealthBar = new PlayerHealthBar();
        PlayerHealthBar player2HealthBar = new PlayerHealthBar();
        WeaponInventory player1WeaponInventory = new WeaponInventory();
        WeaponInventory player2WeaponInventory = new WeaponInventory();
        AddChild(player1HealthBar);
        AddChild(player1WeaponInventory);

        upheaval = Utils.LoadFont("Assets/upheavtt.ttf", 40);
        score = new EasyDraw(250, 60, false);
        score.TextFont(upheaval);
        score.TextAlign(CenterMode.Min, CenterMode.Center);
        score.Fill(255);
        score.Text("Score: " + _score);
        score.SetXY(1625, 15);
        AddChild(score);

    }

    void Update() 
    {
        score.Text(String.Format("Score: " + _score), true);

    }
        
}

