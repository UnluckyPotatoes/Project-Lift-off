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
    public int _score = 0;

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
        score.Text("score: 0");
        score.SetXY(1635, 15);
        AddChild(score);

    }
        public void SetScore(int scoreCount)
        {
            score.Text(String.Format("Health: " + scoreCount), true);
        }
}

