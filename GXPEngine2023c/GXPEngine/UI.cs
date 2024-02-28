using GXPEngine;

public class UI : Canvas
{

    public UI(int width, int height) : base(width, height, false)
    {
        PlayerHealthBar player1HealthBar = new PlayerHealthBar();
        PlayerHealthBar player2HealthBar = new PlayerHealthBar();
        WeaponInventory player1WeaponInventory = new WeaponInventory();
        WeaponInventory player2WeaponInventory = new WeaponInventory();
        AddChild(player1HealthBar);
        AddChild(player1WeaponInventory);

    }
}

