using GXPEngine;

public class UI : Canvas
{

    public UI(int width, int height) : base(width, height, false)
    {
        PlayerHealthBar player1HealthBar = new PlayerHealthBar();
        PlayerHealthBar player2HealthBar = new PlayerHealthBar();
        AddChild(player1HealthBar);
        

    }
}

